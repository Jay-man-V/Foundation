CREATE TABLE [core].[Language] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION     NOT NULL,
    [StatusId]                   INT            NOT NULL,
    [CreatedByUserProfileId]     INT            NOT NULL,
    [LastUpdatedByUserProfileId] INT            NOT NULL,
    [CreatedOn]                  DATETIME       NOT NULL,
    [LastUpdatedOn]              DATETIME       NOT NULL,
    [ValidFrom]                  DATETIME       NOT NULL,
    [ValidTo]                    DATETIME       NOT NULL,
    [EnglishName]                NVARCHAR (150) NULL,
    [NativeName]                 NVARCHAR (150) NULL,
    [CultureCode]                NVARCHAR (10)  NULL,
    [UICultureCode]              NVARCHAR (10)  NULL,
    CONSTRAINT [PK_CORE_Language] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Language_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_Language_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_Language_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

