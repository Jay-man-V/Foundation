/*
--DECLARE @NonWorkingDayDate DATE = '28-Mar-2026'
--DECLARE @NonWorkingDayCountryId INT = 229
*/

SELECT
    *
FROM
    [core].[NonWorkingDay] nwd
WHERE
    nwd.StatusId IN ( SELECT Id FROM [dbo].[ufn_GetListOfActiveStatuses] (1) ) AND
    DATEDIFF(D, nwd.[Date], @nonWorkingDayDate) = 0 AND
    nwd.CountryId = @NonWorkingDayCountryId
