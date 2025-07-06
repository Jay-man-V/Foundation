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
                CAST(DATEADD(DAY, 0, @startDate) AS DATE)
            UNION ALL
            SELECT
                CAST(DATEADD(DAY, 1, AllDates) AS DATE)
            FROM
                ListDates 
            WHERE
                AllDates <= DATEADD(DAY, -1, @endDate)
        )
    SELECT
        AllDates [Date],
        DATEPART(DW, AllDates) AS [DayOfWeekIndex],
        DATENAME(DW, AllDates) AS [DayOfWeek]
    FROM
        ListDates
)