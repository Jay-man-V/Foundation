


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
                        [c].[IsoCode] = @countryIsoCode AND
                        [c].[Id] = nwd.CountryId
                    )
            WHERE
                [nwd].[StatusId] IN ( SELECT [las].[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) [las] ) AND
                [c].StatusId IN ( SELECT [las].[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) [las] ) AND
                [nwd].[Date] BETWEEN @windowStartDate AND @windowEndDate
        )

    SELECT
        @returnValue = MIN([dates].[Date])
    FROM
        [dbo].[ufn_GetListOfCalendarDates] ( @windowStartDate, @windowEndDate ) [dates]
            LEFT OUTER JOIN
            (
                SELECT
                    [nwd].[Id],
                    [nwd].[Date]
                FROM
                    [core].[NonWorkingDay] [nwd]
                WHERE
                    [nwd].[StatusId] IN ( SELECT [las].[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) [las] )
            ) nwd ON
            (
                [nwd].[Date] = [dates].[Date]
            )
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
        [nwd].[Id] IS NULL AND
        [wdfc].[Id] IS NULL AND
        [nwdfc].[Id] IS NULL
    OPTION (MAXRECURSION 2000)

    -- Return the result of the function
    RETURN @returnValue

END