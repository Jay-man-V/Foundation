CREATE TABLE [log].[ScheduledDataStatus] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION     NOT NULL,
    [StatusId]                   INT            NOT NULL,
    [CreatedByUserProfileId]     INT            NOT NULL,
    [LastUpdatedByUserProfileId] INT            NOT NULL,
    [CreatedOn]                  DATETIME       NOT NULL,
    [LastUpdatedOn]              DATETIME       NOT NULL,
    [DataDate]                   DATE           NULL,
    [Name]                       NVARCHAR (150) NULL,
    [DataStatusId]               INT            NULL,
    CONSTRAINT [PK_CORE_ScheduledDataStatus] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ScheduledDataStatus_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_ScheduledDataStatus_DataStatus] FOREIGN KEY ([DataStatusId]) REFERENCES [core].[DataStatus] ([Id]),
    CONSTRAINT [FK_ScheduledDataStatus_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_ScheduledDataStatus_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

