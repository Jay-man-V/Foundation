CREATE TABLE [log].[EventLogApplication] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION     NOT NULL,
    [StatusId]                   INT            NOT NULL,
    [CreatedByUserProfileId]     INT            NOT NULL,
    [LastUpdatedByUserProfileId] INT            NOT NULL,
    [CreatedOn]                  DATETIME       NOT NULL,
    [LastUpdatedOn]              DATETIME       NOT NULL,
    [ValidFrom]                  DATETIME       NOT NULL,
    [ValidTo]                    DATETIME       NOT NULL,
    [ApplicationId]              INT            NULL,
    [ShortName]                  NVARCHAR (250) NULL,
    [ProcessName]                NVARCHAR (250) NULL,
    CONSTRAINT [PK_LOG_EventLogApplication] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EventLogApplication_Application] FOREIGN KEY ([ApplicationId]) REFERENCES [sec].[Application] ([Id]),
    CONSTRAINT [FK_EventLogApplication_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_EventLogApplication_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_EventLogApplication_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

