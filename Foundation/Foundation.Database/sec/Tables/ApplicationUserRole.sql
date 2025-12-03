CREATE TABLE [sec].[ApplicationUserRole] (
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
    [UserProfileId]              INT        NOT NULL,
    [RoleId]                     INT        NOT NULL,
    CONSTRAINT [PK_SEC_ApplicationUserRole] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ApplicationUserRole_Application] FOREIGN KEY ([ApplicationId]) REFERENCES [sec].[Application] ([Id]),
    CONSTRAINT [FK_ApplicationUserRole_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_ApplicationUserRole_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_ApplicationUserRole_Role] FOREIGN KEY ([RoleId]) REFERENCES [sec].[Role] ([Id]),
    CONSTRAINT [FK_ApplicationUserRole_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id]),
    CONSTRAINT [FK_ApplicationUserRole_User] FOREIGN KEY ([UserProfileId]) REFERENCES [sec].[UserProfile] ([Id])
);

