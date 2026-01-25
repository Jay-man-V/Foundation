CREATE TABLE [core].[ScheduleIntervalMultiplierMatrix] (
    [Id]                         INT              IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION       NOT NULL,
    [StatusId]                   INT              NOT NULL,
    [CreatedByUserProfileId]     INT              NOT NULL,
    [LastUpdatedByUserProfileId] INT              NOT NULL,
    [CreatedOn]                  DATETIME         NOT NULL,
    [LastUpdatedOn]              DATETIME         NOT NULL,
    [FromScheduleIntervalId]     INT              NULL,
    [ToScheduleIntervalId]       INT              NULL,
    [Multiplier]                 DECIMAL (30, 20) NULL,
    [Description]                NVARCHAR (500)   NULL,
    CONSTRAINT [PK_CORE_ScheduleIntervalMultiplierMatrix] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ScheduleIntervalMultiplierMatrix_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_ScheduleIntervalMultiplierMatrix_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_ScheduleIntervalMultiplierMatrix_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

