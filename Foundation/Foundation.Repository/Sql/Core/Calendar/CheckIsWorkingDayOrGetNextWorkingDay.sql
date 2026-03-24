/*
--DECLARE @countryIsoCode VARCHAR(5) = 'GB'
--DECLARE @@startDate DATE = '28-Mar-2026'
*/

SELECT
    [dbo].[ufn_CheckIsWorkingDayOrGetNextWorkingDay] ( @countryIsoCode,  @startDate ) OPTION ( MaxRecursion 2000 )
