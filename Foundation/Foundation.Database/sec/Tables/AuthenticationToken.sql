CREATE TABLE [sec].[AuthenticationToken] (
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
    [UserProfileId]              INT            NULL,
    [Token]                      NVARCHAR (200) NULL,
    [Acquired]                   DATETIME       NULL,
    [LastRefreshed]              DATETIME       NULL,
    CONSTRAINT [PK_SEC_AuthenticationToken] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AuthenticationToken_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_AuthenticationToken_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_AuthenticationToken_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id]),
    CONSTRAINT [FK_AuthenticationToken_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [sec].[UserProfile] ([Id])
);

