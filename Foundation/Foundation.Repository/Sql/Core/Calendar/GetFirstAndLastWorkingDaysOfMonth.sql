/*
-- DECLARE @countryIsoCode NVARCHAR(10) = 'GB'
== DECLARE @startDate DATE = '2024-01-01'
-- DECLARE @endDate DATE = '2024-12-31'
*/

SELECT
    MIN(wd.[Date]) AS FirstWorkingDayOfMonth,
    MAX(wd.[Date]) AS LastWorkingDayOfMonth
FROM
    [dbo].[ufn_GetListOfWorkingDates] ( @countryIsoCode, @startDate, @endDate ) wd
        INNER JOIN [core].[Country] c ON
        (
            c.[IsoCode] = @countryIsoCode
        )
        INNER JOIN [core].[CountryNonWorkingDay] cnwd ON
        (
            cnwd.[CountryId] = c.[Id] AND
            cnwd.[DayOfWeekIndex] <> wd.[DayOfWeekIndex]
        )
