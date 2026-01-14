USE [CustomerContact]
GO


--4 Days
--5 Weeks
--6 Months
--7 Years

delete from [core].[ScheduleIntervalMultiplierMatrix]

SET IDENTITY_INSERT [core].[ScheduleIntervalMultiplierMatrix] ON 
GO
INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (1, 0, 1, 1, '2000-01-01', '2000-01-01', 4, 4, CAST(1 AS Decimal(20, 18)), 'Day -> Day')
INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (2, 0, 1, 1, '2000-01-01', '2000-01-01', 4, 5, CAST(CAST(1 AS DECIMAL(20,18))/7 AS Decimal(20, 18)), 'Day -> Week')
INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (3, 0, 1, 1, '2000-01-01', '2000-01-01', 4, 6, CAST(1 AS DECIMAL(20,18))/30, 'Day -> Month')
INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (4, 0, 1, 1, '2000-01-01', '2000-01-01', 4, 7, CAST(CAST(1 AS DECIMAL(20,18))/365 AS Decimal(20, 18)), 'Day -> Year')

INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (5, 0, 1, 1, '2000-01-01', '2000-01-01', 5, 4, CAST(CAST(1 AS DECIMAL(20,18))/7 AS Decimal(20, 18)), 'Week -> Day')
INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (6, 0, 1, 1, '2000-01-01', '2000-01-01', 5, 5, CAST(1 AS Decimal(20, 18)), 'Week -> Week')
INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (7, 0, 1, 1, '2000-01-01', '2000-01-01', 5, 6, CAST(4 AS DECIMAL(20,18))/30, 'Week -> Month')
INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (8, 0, 1, 1, '2000-01-01', '2000-01-01', 5, 7, CAST(CAST(1 AS DECIMAL(20,18))/365.000000 AS Decimal(20, 18)), 'Week -> Year')

SET IDENTITY_INSERT [core].[ScheduleIntervalMultiplierMatrix] OFF
GO
