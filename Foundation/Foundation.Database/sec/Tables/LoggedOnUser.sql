CREATE TABLE [sec].[LoggedOnUser] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION     NOT NULL,
    [StatusId]                   INT            NOT NULL,
    [CreatedByUserProfileId]     INT            NOT NULL,
    [LastUpdatedByUserProfileId] INT            NOT NULL,
    [CreatedOn]                  DATETIME       NOT NULL,
    [LastUpdatedOn]              DATETIME       NOT NULL,
    [ApplicationId]              INT            NULL,
    [UserProfileId]              INT            NULL,
    [LoggedOn]                   DATETIME       NULL,
    [LastActive]                 DATETIME       NULL,
    [Command]                    NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_SEC_LoggedOnUser] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LoggedOnUser_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_LoggedOnUser_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_LoggedOnUser_LoggedOnUser] FOREIGN KEY ([Id]) REFERENCES [sec].[LoggedOnUser] ([Id]),
    CONSTRAINT [FK_LoggedOnUser_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id]),
    CONSTRAINT [FK_LoggedOnUser_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [sec].[UserProfile] ([Id])
);

