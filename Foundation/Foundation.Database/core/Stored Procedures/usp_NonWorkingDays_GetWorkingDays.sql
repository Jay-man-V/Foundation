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
