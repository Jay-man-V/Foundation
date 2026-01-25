
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