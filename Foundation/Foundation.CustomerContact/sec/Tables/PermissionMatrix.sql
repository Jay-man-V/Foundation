CREATE TABLE [sec].[PermissionMatrix] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION     NOT NULL,
    [StatusId]                   INT            NOT NULL,
    [CreatedByUserProfileId]     INT            NOT NULL,
    [LastUpdatedByUserProfileId] INT            NOT NULL,
    [CreatedOn]                  DATETIME       NOT NULL,
    [LastUpdatedOn]              DATETIME       NOT NULL,
    [ValidFrom]                  DATETIME       NOT NULL,
    [ValidTo]                    DATETIME       NOT NULL,
    [AppId]                      INT            NULL,
    [RoleId]                     INT            NULL,
    [UserProfileId]              INT            NULL,
    [FunctionKey]                NVARCHAR (500) NULL,
    [Permission]                 NVARCHAR (200) NULL,
    CONSTRAINT [PK_SEC_PermissionMatrix] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PermissionMatrix_ApplicationId] FOREIGN KEY ([AppId]) REFERENCES [sec].[Application] ([Id]),
    CONSTRAINT [FK_PermissionMatrix_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_PermissionMatrix_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_PermissionMatrix_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [sec].[Role] ([Id]),
    CONSTRAINT [FK_PermissionMatrix_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id]),
    CONSTRAINT [FK_PermissionMatrix_UserProfileId] FOREIGN KEY ([UserProfileId]) REFERENCES [sec].[UserProfile] ([Id])
);

