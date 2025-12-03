CREATE TABLE [core].[WorldRegion] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION     NOT NULL,
    [StatusId]                   INT            NOT NULL,
    [CreatedByUserProfileId]     INT            NOT NULL,
    [LastUpdatedByUserProfileId] INT            NOT NULL,
    [CreatedOn]                  DATETIME       NOT NULL,
    [LastUpdatedOn]              DATETIME       NOT NULL,
    [ValidFrom]                  DATETIME       NOT NULL,
    [ValidTo]                    DATETIME       NOT NULL,
    [Name]                       NVARCHAR (150) NULL,
    CONSTRAINT [PK_CORE_WorldRegion] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_WorldRegion_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_WorldRegion_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_WorldRegion_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

