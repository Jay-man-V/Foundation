/*
--DECLARE @countryIsoCode VARCHAR(5) = 'GB'
--DECLARE @NonWorkingDayDate DATE = '28-Mar-2026'
*/

SELECT
    [dbo].[ufn_IsNonWorkingDay] ( @CountryIsoCode, @NonWorkingDayDate )
