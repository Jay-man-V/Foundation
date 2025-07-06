-- =============================================
-- Author:		Jayesh Varsani
-- Create date: 2nd June 2022
-- Description:	Creates/Returns a table of working days grouped by Month between the two given dates
-- =============================================
CREATE PROCEDURE [core].[usp_NonWorkingDays_GetWorkingDaysByMonth]
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
            core.NonWorkingDay
        WHERE
            DATEDIFF ( D, Date, @loopDate ) = 0 OR
            DATEPART ( WEEKDAY, @loopDate ) IN ( 1, 7 )

        --IF @nwdCount = 0 PRINT CAST (@dayOfWeek AS VARCHAR) + ' ' + DATENAME(WEEKDAY, @loopDate) + ' ' + CAST(@loopDate AS VARCHAR)
        IF @nwdCount = 0 INSERT INTO #workingDaysTemp ( dowNumber, dowName, Date ) VALUES ( @dayOfWeek, DATENAME ( WEEKDAY, @loopDate ), @loopDate )

        SET @loopDate = DATEADD(D, 1, @loopDate)
    END

    SELECT
        [Date],
        SUM ( [Count] ) AS [Count]
    FROM
    (
        SELECT
            CAST (
                    CAST ( DATEPART ( YEAR,  [Date] ) AS VARCHAR ) + '-' +
                    CAST ( DATEPART ( MONTH, [Date] ) AS VARCHAR ) + '-' +
                    '01'
                AS DATE ) AS [Date],
            COUNT ( 1 ) AS [Count]
        FROM
            #workingDaysTemp
        GROUP BY
            [Date]
    ) s
    GROUP BY
        [Date]
END