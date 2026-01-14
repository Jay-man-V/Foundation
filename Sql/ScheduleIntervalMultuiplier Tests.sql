use [CustomerContact]

--4 Days
--5 Weeks
--6 Months
--7 Years

-- select * from core.ScheduleInterval
-- select * from core.ScheduleIntervalMultiplierMatrix 

-- SELECT CAST((CAST(1 AS DECIMAL(20,18))/7) * 14 AS DECIMAL(10,6))

select
	simm.Description,
	simm.Multiplier,
	CAST(1 * simm.Multiplier AS DECIMAL(10,6)) [Day],
	CAST(7 * CAST(simm.Multiplier  AS DECIMAL(10,6)) AS DECIMAL(10,6)) [Week],
	CAST(30 * simm.Multiplier AS DECIMAL(10,6)) [Month],
	CAST(365 * simm.Multiplier AS DECIMAL(10,6)) [Year]
from
	[core].[ScheduleIntervalMultiplierMatrix] simm


declare @interval int = 1
declare @intervalType int = 4

SELECT [dbo].[ufn_GetNextWorkingDay] ('GB', '2026-01-10', @intervalType, 1)



--SELECT
--    @interval * Multiplier
--FROM
--    [core].[ScheduleIntervalMultiplierMatrix] simm
--WHERE
--    simm.FromScheduleIntervalId = @intervalType AND
--    simm.ToScheduleIntervalId = 4 AND
--    simm.StatusId = 0
