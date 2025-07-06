CREATE TABLE [sec].[ApplicationApplicationType] (
    [Id]                         INT        IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION NOT NULL,
    [StatusId]                   INT        NOT NULL,
    [CreatedByUserProfileId]     INT        NOT NULL,
    [LastUpdatedByUserProfileId] INT        NOT NULL,
    [CreatedOn]                  DATETIME   NOT NULL,
    [LastUpdatedOn]              DATETIME   NOT NULL,
    [ValidFrom]                  DATETIME   NOT NULL,
    [ValidTo]                    DATETIME   NOT NULL,
    [ApplicationId]              INT        NOT NULL,
    [ApplicationTypeId]          INT        NOT NULL,
    CONSTRAINT [PK_SEC_ApplicationApplicationType] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ApplicationApplicationType_Application] FOREIGN KEY ([ApplicationId]) REFERENCES [sec].[Application] ([Id]),
    CONSTRAINT [FK_ApplicationApplicationType_ApplicationType] FOREIGN KEY ([ApplicationTypeId]) REFERENCES [sec].[ApplicationType] ([Id]),
    CONSTRAINT [FK_ApplicationApplicationType_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_ApplicationApplicationType_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_ApplicationApplicationType_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

