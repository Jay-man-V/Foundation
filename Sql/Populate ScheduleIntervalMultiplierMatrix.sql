USE [CustomerContact]
GO


--4 Days
--5 Weeks
--6 Months
--7 Years

delete from [core].[ScheduleIntervalMultiplierMatrix]

SET IDENTITY_INSERT [core].[ScheduleIntervalMultiplierMatrix] ON 
GO
INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (1, 0, 1, 1, '2000-01-01', '2000-01-01', 5, 5, CAST(1.000000 AS Decimal(30, 20)), 'Day -> Day')
--INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (2, 0, 1, 1, '2000-01-01', '2000-01-01', 5, 6, CAST(CAST(1 AS DECIMAL(20, 17))/7 AS Decimal(30, 20)), 'Day -> Week')
--INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (3, 0, 1, 1, '2000-01-01', '2000-01-01', 5, 7, CAST(1 AS DECIMAL(20, 17))/30, 'Day -> Month')
--INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (4, 0, 1, 1, '2000-01-01', '2000-01-01', 5, 8, CAST(CAST(1 AS DECIMAL(20, 17))/365.000000 AS Decimal(30, 20)), 'Day -> Year')

INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (5, 0, 1, 1, '2000-01-01', '2000-01-01', 6, 5, CAST(7.000000 AS Decimal(30, 20)), 'Week -> Day')
--INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (6, 0, 1, 1, '2000-01-01', '2000-01-01', 6, 6, CAST(1 AS Decimal(30, 20)), 'Week -> Week')
--INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (7, 0, 1, 1, '2000-01-01', '2000-01-01', 6, 7, CAST(4 AS DECIMAL(20, 17))/28, 'Week -> Month')
--INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (8, 0, 1, 1, '2000-01-01', '2000-01-01', 6, 8, CAST(CAST(1 AS DECIMAL(20, 17))/52.000000 AS Decimal(30, 20)), 'Week -> Year')

INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (9,  0, 1, 1, '2000-01-01', '2000-01-01', 7, 5, CAST(28.000000 AS Decimal(30, 20)), 'Month -> Day')
--INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (10, 0, 1, 1, '2000-01-01', '2000-01-01', 7, 6, CAST(CAST(1 AS DECIMAL(20, 17))/28 AS Decimal(30, 20)), 'Month -> Week')
--INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (11, 0, 1, 1, '2000-01-01', '2000-01-01', 7, 7, CAST(1 AS Decimal(30, 20)), 'Month -> Month')
--INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (12, 0, 1, 1, '2000-01-01', '2000-01-01', 7, 8, CAST(CAST(1 AS DECIMAL(20, 17))/365.000000 AS Decimal(30, 20)), 'Month -> Year')

INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (13, 0, 1, 1, '2000-01-01', '2000-01-01', 8, 5, CAST(365.000000 AS Decimal(30, 20)), 'Year -> Day')
--INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (14, 0, 1, 1, '2000-01-01', '2000-01-01', 8, 6, CAST(CAST(1 AS DECIMAL(20, 17))/52.000000 AS Decimal(30, 20)), 'Year -> Week')
--INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (15, 0, 1, 1, '2000-01-01', '2000-01-01', 8, 7, CAST(CAST(1 AS DECIMAL(20, 17))/12.000000 AS Decimal(30, 20)), 'Year -> Month')
--INSERT [core].[ScheduleIntervalMultiplierMatrix] ([Id], [StatusId], [CreatedByUserProfileId], [LastUpdatedByUserProfileId], [CreatedOn], [LastUpdatedOn], [FromScheduleIntervalId], [ToScheduleIntervalId], [Multiplier], [Description]) VALUES (16, 0, 1, 1, '2000-01-01', '2000-01-01', 8, 8, CAST(1 AS Decimal(30, 20)), 'Year -> Year')

SET IDENTITY_INSERT [core].[ScheduleIntervalMultiplierMatrix] OFF
GO
