


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
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

    -- Need to account for the weekends, each of the numbers below just need to be estimates to extend the End Date to allow for the Weekends and Bank Holidays
    DECLARE @numberOfWeeks INTEGER = ( ( @interval / 7  ) + 0 ); -- Calculate the number of Weeks spanned by the interval
    DECLARE @numberOfYears INTEGER = ( ( @interval / 52 ) + 0 ); -- Calculate the number of Years spanned by the interval
    DECLARE @nonWorkingDays INTEGER = ( @numberOfWeeks * 2 ) + ( @numberOfYears * 8 ) -- Number of Weekend days + Number of Bank Holiday days, often 8 per year

    DECLARE @workingDate AS DATE = DATEADD ( DAY, @interval + @nonWorkingDays, @startDate )
    --DECLARE @workingDate AS DATE = DATEADD(DAY, @interval, @startDate)
	DECLARE @windowStartDate AS DATE
    DECLARE @windowEndDate AS DATE

    SELECT
        @windowStartDate = targetRange.[StartDate],
        @windowEndDate = targetRange.NextEndDate
    FROM
    (
        SELECT
            @workingDate x,
            nwd.[Date] StartDate,
            GREATEST ( LEAD (nwd.[Date], 1, nwd.[Date] ) OVER ( ORDER BY nwd.[Date] ),
            LEAD ( nwd.[Date], 2, nwd.[Date] ) OVER ( ORDER BY nwd.[Date] ) ) AS NextEndDate
        FROM
            [core].[NonWorkingDay] nwd
                INNER JOIN [core].[Country] c ON
                (
                    c.[IsoCode] = @countryIsoCode AND
                    c.[Id] = nwd.CountryId
                )
        WHERE
            DATEPART(YEAR, nwd.[Date]) >= DATEPART ( YEAR, @startDate )
    ) TargetRange
    WHERE
        @workingDate BETWEEN [StartDate] AND [NextEndDate];

    SELECT @windowStartDate = COALESCE ( @windowStartDate, @startDate );
    SELECT @windowEndDate = COALESCE ( @windowEndDate, @workingDate );

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
			    c.[IsoCode] = @countryIsoCode
        )

    SELECT
        @returnValue = MIN(dates.[Date])
    FROM
        [dbo].[ufn_GetListOfCalendarDates] ( @windowStartDate, @windowEndDate ) dates
            LEFT OUTER JOIN
            (
                SELECT
                    nwd.[Id],
                    nwd.[Date]
                FROM
                    [core].[NonWorkingDay] nwd
                        LEFT OUTER JOIN vw_WeekendDaysForCountry wdfc ON
                        (
                            wdfc.[DayOfWeekIndex] = DATEPART ( WEEKDAY, nwd.[Date] )
                        )
                WHERE
                    wdfc.[Id] IS NULL
            ) nwd ON
            (
                nwd.[Date] = dates.[Date]
            )
    WHERE
        nwd.[Id] IS NULL AND
        dates.[Date] >= DATEADD ( DAY, @interval, @startDate )
    OPTION (MAXRECURSION 2000)

	-- Return the result of the function
	RETURN @returnValue

END
