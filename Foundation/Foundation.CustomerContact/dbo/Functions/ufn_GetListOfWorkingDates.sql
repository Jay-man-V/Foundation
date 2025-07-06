
CREATE   FUNCTION [dbo].[ufn_GetListOfWorkingDates]
(
    @startDate DATE,
    @endDate DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT
        dates.[Date],
        dates.DayOfWeekIndex,
        dates.[DayOfWeek]
    FROM
        dbo.ufn_GetListOfCalendarDates ( @startDate, @endDate ) dates
            LEFT OUTER JOIN core.NonWorkingDay nwd on
            (
                nwd.[Date] = dates.[Date]
            )
    WHERE
        nwd.Id IS NULL AND
        dates.DayOfWeekIndex NOT IN ( 1, 7 )
)