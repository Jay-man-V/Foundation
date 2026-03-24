/*
--DECLARE @countryIsoCode VARCHAR(5) = 'GB'
--DECLARE @STARTDATE DATE = '22-MAR-2026'
--DECLARE @intervalType INT = 2
--DECLARE @interval INT = 1
*/

SELECT
    [dbo].[ufn_GetNextWorkingDay] ( @countryIsoCode, @startDate, @intervalType, @interval ) OPTION ( MaxRecursion 2000 )
