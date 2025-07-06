CREATE TABLE [sec].[ApplicationRole] (
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
    [RoleId]                     INT        NOT NULL,
    CONSTRAINT [PK_SEC_ApplicationRole] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ApplicationRole_Application] FOREIGN KEY ([ApplicationId]) REFERENCES [sec].[Application] ([Id]),
    CONSTRAINT [FK_ApplicationRole_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_ApplicationRole_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_ApplicationRole_Role] FOREIGN KEY ([RoleId]) REFERENCES [sec].[Role] ([Id]),
    CONSTRAINT [FK_ApplicationRole_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

