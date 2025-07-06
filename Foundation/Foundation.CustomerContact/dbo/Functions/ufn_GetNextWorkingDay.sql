


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[ufn_GetNextWorkingDay]
(
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
        @windowStartDate = StartDate,
        @windowEndDate = NextEndDate
    FROM
    (
        SELECT
            @workingDate x,
            [Date] StartDate,
            GREATEST ( LEAD ([Date], 1, [Date] ) OVER ( ORDER BY [Date] ),
            LEAD ( [Date], 2, [Date] ) OVER ( ORDER BY [Date] ) ) AS NextEndDate
        FROM
            core.NonWorkingDay
        WHERE
            DATEPART(YEAR, [Date]) >= DATEPART ( YEAR, @startDate )
    ) TargetRange
    WHERE
        @workingDate BETWEEN StartDate AND NextEndDate;

    SELECT @windowStartDate = COALESCE ( @windowStartDate, @startDate )
    SELECT @windowEndDate = COALESCE ( @windowEndDate, @workingDate )

    SELECT
        @returnValue = MIN(dates.[Date])
    FROM
        dbo.ufn_GetListOfCalendarDates ( @windowStartDate, @windowEndDate ) dates
            LEFT OUTER JOIN core.NonWorkingDay nwd on
            (
                nwd.[Date] = dates.[Date]
            )
    WHERE
        dates.[Date] >= DATEADD ( DAY, @interval, @startDate ) AND
        DayOfWeekIndex NOT IN ( 1, 7 ) AND
        nwd.Id IS NULL
    OPTION (MAXRECURSION 2000)

	-- Return the result of the function
	RETURN @returnValue

END