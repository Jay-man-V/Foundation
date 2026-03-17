-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[ufn_CheckIsWorkingDayOrGetNextWorkingDay]
(
    @countryIsoCode NVARCHAR(10) = 'GB',
	@startDate DATE
)
RETURNS DATE
AS
BEGIN
	-- Declare the return variable here
    DECLARE @returnValue AS DATE

	-- Add the T-SQL statements to compute the return value here

    DECLARE @workingDate AS DATE = @startDate
	DECLARE @windowStartDate AS DATE
    DECLARE @windowEndDate AS DATE

    -- Adjust the given start date based on known non working days
    -- Also take an educated guess
    SELECT
        @windowStartDate = StartDate,
        @windowEndDate = NextEndDate
    FROM
    (
        SELECT
            @workingDate x,
            nwd.[Date] StartDate,
            GREATEST ( LEAD (nwd.[Date], 1, nwd.[Date] ) OVER ( ORDER BY nwd.[Date] ),
            LEAD ( nwd.[Date], 2, nwd.[Date] ) OVER ( ORDER BY nwd.[Date] ) ) AS NextEndDate
        FROM
            core.NonWorkingDay nwd
        WHERE
            nwd.StatusId IN ( SELECT Id FROM ufn_GetListOfActiveStatuses ( DEFAULT ) ) AND
            DATEPART ( YEAR, nwd.[Date]) >= DATEPART ( YEAR, @startDate )
    ) TargetRange
    WHERE
        @workingDate BETWEEN [StartDate] AND [NextEndDate];

    SELECT @windowStartDate = COALESCE ( @windowStartDate, @startDate );
    SELECT @windowEndDate   = COALESCE ( @windowEndDate,   @workingDate );

    WITH
        vw_WeekendDaysForCountry AS
        (
            SELECT
                cnwd.[Id],
                cnwd.[DayOfWeekIndex]
            FROM
                [core].[Country] c
                    INNER JOIN [core].[CountryNonWorkingDay] cnwd ON
                    (
					    cnwd.[CountryId] = c.[Id]
                    )
		    WHERE
                c.StatusId IN ( SELECT Id FROM ufn_GetListOfActiveStatuses ( DEFAULT ) ) AND
                cnwd.StatusId IN ( SELECT Id FROM ufn_GetListOfActiveStatuses ( DEFAULT ) ) AND
			    c.[IsoCode] = @countryIsoCode
        )

    SELECT
        @returnValue = MIN ( dates.[Date] )
    FROM
        dbo.ufn_GetListOfCalendarDates ( @windowStartDate, @windowEndDate ) dates
            LEFT OUTER JOIN core.NonWorkingDay nwd on
            (
                nwd.StatusId IN ( SELECT Id FROM ufn_GetListOfActiveStatuses ( DEFAULT ) ) AND
                nwd.[Date] = dates.[Date]
            )
            LEFT OUTER JOIN vw_WeekendDaysForCountry wdfc ON
            (
                wdfc.[DayOfWeekIndex] = dates.[DayOfWeekIndex]
            )
    WHERE
        nwd.[Id] IS NULL AND
        wdfc.[Id] IS NULL AND
        dates.[Date] >= @startDate
    OPTION ( MAXRECURSION 2000 )

	-- Return the result of the function
	RETURN @returnValue

END


-- =============================================
-- Author:        <Author,,Name>
-- Create date: <Create Date, ,>
-- Description:    <Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[ufn_GetNextWorkingDay]
(
    @countryIsoCode NVARCHAR(10) = 'GB',
    @startDate DATE,
    @intervalType INTEGER = -1,
    @interval  INTEGER = 1
)
RETURNS DATE
AS
BEGIN
    -- Declare the return variable here
    DECLARE @returnValue AS DATE

    -- Add the T-SQL statements to compute the return value here

    -- Adjust the @interval to a standard value for calculations below
    -- 5 = Days
    -- 6 = Weeks
    -- 7 = Months
    -- 8 = Years
    DECLARE @standardInterval INTEGER = @interval
    
    SELECT
        -- @standardInterval is now converted to a number of days for the interval
        @standardInterval = @interval * [simm].[Multiplier]
    FROM
        [core].[ScheduleIntervalMultiplierMatrix] [simm]
    WHERE
        [simm].[FromScheduleIntervalId] = @intervalType AND
        [simm].[ToScheduleIntervalId] = ( SELECT [si].[Id] FROM [core].[ScheduleInterval] [si] WHERE [si].[Name] = 'DAYS' AND [si].[StatusId] IN ( SELECT [las].[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) [las] ) ) AND
        [simm].[StatusId] = 0

    -- Need to account for the weekends, each of the numbers below just need to be estimates to extend the End Date to allow for the Weekends and Bank Holidays
    DECLARE @numberOfWeeks INTEGER = ( ( @standardInterval / 7 ) + 0 ); -- Calculate the number of Weeks spanned by the interval
    DECLARE @numberOfYears INTEGER = ( @standardInterval + ( @interval * 8 ) ); -- Calculate the number of Years spanned by the interval. Estimating 8 Bank Holidays per year
    --DECLARE @nonWorkingDays INTEGER = ( @numberOfWeeks * 2 ) + ( @numberOfYears * 8 ) -- Number of Weekend days + Number of Bank Holiday days, often 8 per year
    DECLARE @nonWorkingDays INTEGER =
        CASE
            WHEN @numberOfWeeks = 0 THEN @standardInterval
            WHEN @numberOfWeeks > 0 AND @numberOfYears = 0 THEN @numberOfWeeks
            WHEN @numberOfYears > 0 THEN @numberOfYears
            ELSE 0
        END;

    -- Adjust the @startDate by the @standardInterval to get the first viable date and then adjust for the non-working days
    -- Adding a constant of 10 to allow for any non-working days that may happen on the End Date, we just need to skip a few dates to be sure of finding the next date
    DECLARE @windowStartDate AS DATE = @startDate;
    DECLARE @windowEndDate AS DATE = DATEADD ( DAY, @standardInterval + @nonWorkingDays + 10, @startDate );

    WITH
        vw_WeekendDaysForCountry AS
        (
            SELECT
                [cnwd].[Id],
                [cnwd].[DayOfWeekIndex],
                null [Date]
            FROM
                [core].[Country] [c]
                    INNER JOIN [core].[CountryNonWorkingDay] [cnwd] ON
                    (
                        [c].[IsoCode] = @countryIsoCode AND
                        [cnwd].[CountryId] = [c].[Id]
                    )
            WHERE
                [c].[StatusId] IN ( SELECT [las].[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) [las] )
        ),

        vw_NonWorkingDaysForCountry AS
        (
            SELECT
                [nwd].[Id],
                DATEPART ( DW, [nwd].[Date] ) [DayOfWeekIndex],
                [nwd].[Date]
            FROM
                [core].[NonWorkingDay] [nwd]
                    INNER JOIN [core].[Country] [c] ON
                    (
                        [c].[StatusId] IN ( SELECT [las].[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) [las] ) AND
                        [c].[IsoCode] = @countryIsoCode AND
                        [c].[Id] = nwd.CountryId
                    )
            WHERE
                [nwd].[StatusId] IN ( SELECT [las].[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) [las] ) AND
                [nwd].[Date] BETWEEN @windowStartDate AND @windowEndDate
        )

    SELECT
        @returnValue = MIN([dates].[Date])
    FROM
        [dbo].[ufn_GetListOfCalendarDates] ( @windowStartDate, @windowEndDate ) [dates]
            LEFT OUTER JOIN vw_WeekendDaysForCountry [wdfc] ON
            (
                [wdfc].[DayOfWeekIndex] = DATEPART ( WEEKDAY, [dates].[Date] )
            )
            LEFT OUTER JOIN vw_NonWorkingDaysForCountry [nwdfc] ON
            (
                [nwdfc].[Date] = [dates].[Date]
            )
    WHERE
        [dates].[Date] >= DATEADD ( DAY, @standardInterval, @startDate ) AND
        [wdfc].[Id] IS NULL AND
        [nwdfc].[Id] IS NULL
    OPTION (MAXRECURSION 2000)

    -- Return the result of the function
    RETURN @returnValue
END


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[ufn_IsNonWorkingDay]
(
    @countryIsoCode VARCHAR ( 10 ) = 'GB',
    @date DATE
)
RETURNS BIT
AS
BEGIN
    -- Declare the return variable here
    DECLARE @returnValue AS BIT

    -- Add the T-SQL statements to compute the return value here
    DECLARE @rowCountNonWorkingDays AS INTEGER
    DECLARE @rowCountCountryNonWorkingDays AS INTEGER

    SELECT
        @rowCountNonWorkingDays = COUNT ( 1 )
    FROM
        [core].[NonWorkingDay] nwd
            INNER JOIN [core].[Country] c ON
            (
                c.[Id] = nwd.[CountryId]
                )
    WHERE
        nwd.[StatusId] IN ( SELECT fn1.[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) fn1 ) AND
        c.[StatusId] IN ( SELECT fn2.[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) fn2 ) AND
        c.[IsoCode] = @countryIsoCode AND
        DATEDIFF ( DAY, nwd.[Date], @date ) = 0

    SELECT
        @rowCountCountryNonWorkingDays = COUNT ( 1 )
    FROM
        [core].[Country] c
            LEFT OUTER JOIN [core].[CountryNonWorkingDay] cnwd ON
            (
                cnwd.[CountryId] = c.[Id] AND
                cnwd.DayOfWeekIndex = DATEPART ( DW, @date )
                )
    WHERE
        cnwd.[StatusId] IN ( SELECT fn1.[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) fn1 ) AND
        c.[StatusId] IN ( SELECT fn2.[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) fn2 ) AND
        c.[IsoCode] = @countryIsoCode

    SELECT
        @returnValue = CASE
                           WHEN @rowCountNonWorkingDays > 0 OR @rowCountCountryNonWorkingDays > 0 THEN 1
                           ELSE 0
            END

    -- Return the result of the function
    RETURN @returnValue
END


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[ufn_GetListOfCalendarDates]
(
    @startDate DATE,
    @endDate DATE
)
RETURNS TABLE
AS
RETURN
(
    WITH
        ListDates(AllDates) AS
        (
            SELECT
                CAST ( DATEADD ( DAY, 0, @startDate ) AS DATE )
            UNION ALL
            SELECT
                CAST ( DATEADD(DAY, 1, AllDates ) AS DATE )
            FROM
                [ListDates] 
            WHERE
                [AllDates] <= DATEADD ( DAY, -1, @endDate )
        )
    SELECT
        AllDates [Date],
        DATEPART ( WEEKDAY, AllDates ) AS [DayOfWeekIndex],
        DATENAME ( WEEKDAY, AllDates ) AS [DayOfWeek]
    FROM
        [ListDates]
)


CREATE FUNCTION [dbo].[ufn_GetListOfActiveStatuses]
(
    @includePending BIT = 0
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT
        [Id],
        [Code]
    FROM
        [core].[Status]
    WHERE
        [Id] IN ( 0, 1 ) OR
        (
            @includePending = 1 AND
            [Id] IN ( 2 )
        )
)


CREATE FUNCTION [dbo].[ufn_GetListOfWorkingDates]
(
    @countryIsoCode NVARCHAR(10) = 'GB',
    @startDate DATE,
    @endDate DATE
)
RETURNS TABLE
AS
RETURN
(
    WITH
	    vw_NonWorkingDaysForCountry AS
	    (
		    SELECT
			    nwd.*
		    FROM
			    [core].[NonWorkingDay] nwd
				    INNER JOIN [core].[Country] c ON
				    (
					    c.Id = nwd.[CountryId]
				    )
		    WHERE
                nwd.StatusId IN ( SELECT Id FROM ufn_GetListOfActiveStatuses ( DEFAULT ) ) AND
                c.StatusId IN ( SELECT Id FROM ufn_GetListOfActiveStatuses ( DEFAULT ) ) AND
			    c.[IsoCode] = @countryIsoCode
	    ),

        vw_WeekendDaysForCountry AS
        (
            SELECT
                cnwd.[Id],
                cnwd.[DayOfWeekIndex]
            FROM
                [core].[Country] c
                    INNER JOIN [core].[CountryNonWorkingDay] cnwd ON
                    (
					    cnwd.[CountryId] = c.[Id]
                    )
		    WHERE
                c.StatusId IN ( SELECT Id FROM ufn_GetListOfActiveStatuses ( DEFAULT ) ) AND
                cnwd.StatusId IN ( SELECT Id FROM ufn_GetListOfActiveStatuses ( DEFAULT ) ) AND
			    c.[IsoCode] = @countryIsoCode
        )

    SELECT
        dates.[Date],
        dates.[DayOfWeekIndex],
        dates.[DayOfWeek]
    FROM
        dbo.ufn_GetListOfCalendarDates ( @startDate, @endDate ) dates
            LEFT OUTER JOIN vw_NonWorkingDaysForCountry nwdfc on
            (
                nwdfc.[Date] = dates.[Date]
            )
            LEFT OUTER JOIN vw_WeekendDaysForCountry wdfc ON
            (
                wdfc.[DayOfWeekIndex] = dates.[DayOfWeekIndex]
            )
    WHERE
        nwdfc.[Id] IS NULL AND
        wdfc.[Id] IS NULL
)


-- =============================================
-- Author:		Jayesh Varsani
-- Create date: 2nd June 2022
-- Description:	Creates/Returns a table of working days between the two given dates
-- =============================================
CREATE PROCEDURE [core].[usp_NonWorkingDays_GetWorkingDays]
    @countryIsoCode NVARCHAR(10) = 'GB',
    @startDate DATE,
    @endDate DATE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
	SET NOCOUNT ON;

    IF OBJECT_ID('tempdb..#workingDaysTemp') IS NOT NULL DROP TABLE #workingDaysTemp

    CREATE TABLE #workingDaysTemp
    (
        dowNumber   INT,
        dowName     VARCHAR(20),
        [Date]      DATE
    )

    DECLARE @loopDate AS DATE = @startDate
    DECLARE @dayOfWeek INT
    DECLARE @nwdCount INT

    WHILE ( @loopDate <= @endDate )
    BEGIN
        SELECT
            @nwdCount = COUNT ( 1 ),
            @dayOfWeek = DATEPART ( WEEKDAY, @loopDate )
        FROM
            [core].[NonWorkingDay] nwd
                INNER JOIN [core].[Country] c ON
                (
                    c.[IsoCode] = @countryIsoCode AND
                    c.[Id] = nwd.[CountryId]
                )
        WHERE
            DATEDIFF ( DAY, Date, @loopDate ) = 0 OR
            DATEPART ( WEEKDAY, @loopDate ) IN
            (
                SELECT
                    DISTINCT [DayOfWeekIndex]
                FROM
                    [core].[Country] c
                        INNER JOIN [core].[CountryNonWorkingDay] cnwd ON
                        (
                            cnwd.[CountryId] = c.[Id]
                        )
                WHERE
                    c.[IsoCode] = @countryIsoCode
            )

        IF @nwdCount = 0 INSERT INTO #workingDaysTemp ( dowNumber, dowName, [Date] ) VALUES ( @dayOfWeek, DATENAME ( WEEKDAY, @loopDate ), @loopDate )

        SET @loopDate = DATEADD ( DAY, 1, @loopDate )
    END

    SELECT
        *
    FROM
        #workingDaysTemp
    ORDER BY
        [Date]

    IF OBJECT_ID ( 'tempdb..#workingDaysTemp' ) IS NOT NULL DROP TABLE #workingDaysTemp

END


-- =============================================
-- Author:		Jayesh Varsani
-- Create date: 2nd June 2022
-- Description:	Creates/Returns a table of working days grouped by Month between the two given dates
-- =============================================
CREATE PROCEDURE [core].[usp_NonWorkingDays_GetWorkingDaysByMonth]
    @countryIsoCode NVARCHAR(10) = 'GB',
    @startDate DATE,
    @endDate DATE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
	SET NOCOUNT ON;

    CREATE TABLE #workingDaysTemp
    (
        dowNumber   INT,
        dowName     VARCHAR(20),
        [Date]      DATE
    )

    DECLARE @loopDate AS DATE = @startDate
    DECLARE @dayOfWeek INT
    DECLARE @nwdCount INT

    WHILE ( @loopDate <= @endDate )
    BEGIN
        SELECT
            @nwdCount = COUNT ( 1 ),
            @dayOfWeek = DATEPART ( WEEKDAY, @loopDate )
        FROM
            core.NonWorkingDay nwd
                INNER JOIN [core].[Country] c ON
                (
                    c.[IsoCode] = @countryIsoCode AND
                    c.[Id] = nwd.[CountryId]
                )
                LEFT OUTER JOIN [core].[CountryNonWorkingDay] cnwd ON
                (
                    cnwd.[CountryId] = c.[Id] AND
                    cnwd.[DayOfWeekIndex] = DATEPART ( WEEKDAY, @loopDate )
                )
        WHERE
            DATEDIFF ( DAY, nwd.[Date], @loopDate ) = 0 OR
            cnwd.[Id] IS NOT NULL            

        --IF @nwdCount = 0 PRINT CAST (@dayOfWeek AS VARCHAR) + ' ' + DATENAME(WEEKDAY, @loopDate) + ' ' + CAST(@loopDate AS VARCHAR)
        IF @nwdCount = 0 INSERT INTO #workingDaysTemp ( dowNumber, dowName, [Date] ) VALUES ( @dayOfWeek, DATENAME ( WEEKDAY, @loopDate ), @loopDate )

        SET @loopDate = DATEADD ( DAY, 1, @loopDate )
    END

    SELECT
        s.[Date],
        SUM ( s.[Count] ) AS [Count]
    FROM
    (
        SELECT
            CAST (
                    CAST ( DATEPART ( YEAR,  ndt.[Date] ) AS VARCHAR ) + '-' +
                    CAST ( DATEPART ( MONTH, ndt.[Date] ) AS VARCHAR ) + '-' +
                    '01'
                AS DATE ) AS [Date],
            COUNT ( 1 ) AS [Count]
        FROM
            #workingDaysTemp ndt
        GROUP BY
            ndt.[Date]
    ) s
    GROUP BY
        s.[Date]
END


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [core].[usp_SequenceGenerator_GetNextId]
    @applicationId INT,
    @userProfileId INT,
	@sequenceName NVARCHAR(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    IF @applicationId IS NULL
        RAISERROR('@applicationId must be specified and cannot be null', 15, 1)

    -- If required, reset action first
    DECLARE @runDate DATETIME = GETDATE()

    UPDATE
        core.SequenceGenerator
    SET
        LastId = 0
    WHERE
        SequenceName = @sequenceName AND
        ResetOnNewDate = 1 AND
        DATEDIFF(DAY, LastUpdatedOn, GETDATE()) >= 1

    -- 
    MERGE INTO
        core.SequenceGenerator AS target
    USING
        (
            SELECT
                Id,
                CreatedByUserProfileId,
                LastUpdatedByUserProfileId,
                CreatedOn,
                LastUpdatedOn,
                ApplicationId,
                ConfigurationScopeId,

                SequenceName,
                NextId
            FROM
            (
                SELECT
                    Id,
                    CreatedByUserProfileId,
                    LastUpdatedByUserProfileId,
                    CreatedOn,
                    LastUpdatedOn,
                    ApplicationId,
                    ConfigurationScopeId,

                    SequenceName,
                    NextId,
                    RANK() OVER (ORDER BY Id DESC) AS Rnk
                FROM
                (
                    SELECT
                        sg.Id,
                        sg.CreatedByUserProfileId,
                        sg.LastUpdatedByUserProfileId,
                        sg.CreatedOn,
                        GETDATE() AS LastUpdatedOn,
                        ApplicationId,
                        ConfigurationScopeId,

                        sg.SequenceName,
                        sg.LastId + 1 AS NextId
                    FROM
                        core.SequenceGenerator sg
                            INNER JOIN core.ConfigurationScope cs ON
                            (
                                cs.Id = sg.ConfigurationScopeId
                            )
                    WHERE
                        sg.StatusId IN ( 0, 1 ) AND
                        sg.SequenceName = @sequenceName AND
                        COALESCE ( sg.ApplicationId, 0 ) IN ( 0, /* Core System Application */ @applicationId ) AND
                        sg.CreatedByUserProfileId IN ( 1, /* System User */ @UserProfileId )
                    UNION ALL
                    SELECT
                        NULL Id,
                        1 AS CreatedByUserProfileId, /* System User */
                        1 AS LastUpdatedByUserProfileId, /* System User */
                        GETDATE() AS CreatedOn,
                        GETDATE() AS LastUpdatedOn,
                        0 AS ApplicationId, /* Core System Application */
                        1 AS ConfigurationScopeId, /* System */

                        @sequenceName AS SequenceName,
                        1 AS NextSequence
                ) s
            ) s
            WHERE
                Rnk = 1
        ) AS source
    ON
    (
        target.Id = source.Id AND
        target.StatusId = 0
    )
    WHEN MATCHED THEN UPDATE SET
        target.LastUpdatedByUserProfileId = source.LastUpdatedByUserProfileId,
        target.LastUpdatedOn = source.LastUpdatedOn,
        target.LastId = source.NextId
    WHEN NOT MATCHED THEN INSERT
        (
            StatusId,
            CreatedByUserProfileId,
            LastUpdatedByUserProfileId,
            CreatedOn,
            LastUpdatedOn,

            ApplicationId,
            ConfigurationScopeId,
            SequenceName,
            LastId
        )
        VALUES
        (
            0,
            source.CreatedByUserProfileId,
            source.LastUpdatedByUserProfileId,
            source.CreatedOn,
            source.LastUpdatedOn,

            source.ApplicationId,
            source.ConfigurationScopeId,
            source.SequenceName,
            source.NextId
        );

    -- Return the correct sequence
    SELECT
        sg.LastId
    FROM
        core.SequenceGenerator sg
    WHERE
        sg.StatusId IN ( 0, 1 ) AND
        sg.SequenceName = @sequenceName AND
        COALESCE ( sg.ApplicationId, 0 ) IN ( 0, /* Core System Application */ @applicationId ) AND
        sg.CreatedByUserProfileId IN ( 1, /* System User */ @UserProfileId )
END


/****** Object:  StoredProcedure [sec].[usp_UserProfile_LoadFromActiveDirectoryUsersFromStaging]    Script Date: 15/05/2021 17:43:10 ******/
CREATE PROCEDURE [sec].[usp_UserProfile_LoadFromActiveDirectoryUsersFromStaging]
(
    @loggedOnUserProfileId INT
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    CREATE TABLE #temp_User
    (
        userProfileId INT,
        userProfileUsername NVARCHAR(100),
        userProfileDisplayName NVARCHAR(250),
        userProfileExternalKeyId NVARCHAR(100),
        activeDirectoryUserObjectSId NVARCHAR(100),
        activeDirectoryUsername NVARCHAR(250),
        activeDirectoryUserFullName NVARCHAR(250)
    )

    INSERT INTO #temp_User
    SELECT
        up.Id,              -- userProfileId
        up.Username,        -- userProfileUsername
        up.DisplayName,     -- userProfileDisplayName
        up.ExternalKeyId,   -- userProfileExternalKeyId
        adu.ObjectSId,      -- activeDirectoryUserObjectSId
        adu.Name,           -- activeDirectoryUsername
        adu.FullName        -- activeDirectoryUserFullName
    FROM
        sec.UserProfile up
            FULL OUTER JOIN stg.ActiveDirectoryUser adu ON
                up.ExternalKeyId = adu.ObjectSId

    -- Update users
    UPDATE
        sec.UserProfile
    SET
        StatusId = 0,
        Username = activeDirectoryUsername,
        DisplayName = activeDirectoryUserFullName,
        LastUpdatedByUserProfileId = @loggedOnUserProfileId,
        LastUpdatedOn = GETDATE(),
        ValidTo = '2100-12-31 23:59:59'
    FROM
        #temp_User sourceTable
    WHERE
        sec.UserProfile.ExternalKeyId = sourceTable.activeDirectoryUserObjectSId

    -- Insert users
    INSERT INTO
        sec.UserProfile
    (
        StatusId,
        CreatedByUserProfileId,
        LastUpdatedByUserProfileId,
        CreatedOn,
        LastUpdatedOn,
        ValidFrom,
        ValidTo,
        ExternalKeyId,
        Username,
        DisplayName,
        IsSystemSupport,
        ContactDetailId
    )
    SELECT
        0,                              -- StatusId
        @loggedOnUserProfileId,         -- CreatedByUserProfileId,
        @loggedOnUserProfileId,         -- LastUpdatedByUserProfileId
        GETDATE(),                      -- CreatedOn
        GETDATE(),                      -- LastUpdatedOn
        GETDATE(),                      -- ValidFrom
        '2100-12-31 23:59:59',          -- ValidTo
        activeDirectoryUserObjectSId,   -- ExternalKeyId
        activeDirectoryUserName,        -- Username
        activeDirectoryUserFullName,    -- DisplayName
        0,                              -- IsSystemSupport
        NULL                            -- ContactDetailId
    FROM
        #temp_User sourceTable
    WHERE
        userProfileId IS NULL AND
        userProfileExternalKeyId IS NULL AND
        activeDirectoryUserObjectSId IS NOT NULL

    -- Delete Users
    UPDATE
        sec.UserProfile
    SET
        StatusId = -1,
        LastUpdatedByUserProfileId = @loggedOnUserProfileId,
        LastUpdatedOn = GETDATE(),
        ValidTo = GETDATE()
    FROM
        sec.UserProfile
            INNER JOIN #temp_User ON
            (
                userProfileId = sec.UserProfile.Id
            )
    WHERE
        userProfileId IS NOT NULL AND
        userProfileExternalKeyId IS NOT NULL AND
        activeDirectoryUserObjectSId IS NULL

    COMMIT
END
