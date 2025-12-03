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
