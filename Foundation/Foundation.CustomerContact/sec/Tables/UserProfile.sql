CREATE TABLE [sec].[UserProfile] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION     NOT NULL,
    [StatusId]                   INT            NOT NULL,
    [CreatedByUserProfileId]     INT            NOT NULL,
    [LastUpdatedByUserProfileId] INT            NOT NULL,
    [CreatedOn]                  DATETIME       NOT NULL,
    [LastUpdatedOn]              DATETIME       NOT NULL,
    [ValidFrom]                  DATETIME       NULL,
    [ValidTo]                    DATETIME       NULL,
    [ExternalKeyId]              NVARCHAR (100) NULL,
    [Username]                   NVARCHAR (100) NULL,
    [DisplayName]                NVARCHAR (250) NULL,
    [IsSystemSupport]            BIT            NULL,
    [ContactDetailId]            INT            NULL,
    CONSTRAINT [PK_SEC_UserProfile] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserProfile_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_UserProfile_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_UserProfile_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

