CREATE TABLE [core].[NationalRegion] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION     NOT NULL,
    [StatusId]                   INT            NOT NULL,
    [CreatedByUserProfileId]     INT            NOT NULL,
    [LastUpdatedByUserProfileId] INT            NOT NULL,
    [CreatedOn]                  DATETIME       NOT NULL,
    [LastUpdatedOn]              DATETIME       NOT NULL,
    [ValidFrom]                  DATETIME       NOT NULL,
    [ValidTo]                    DATETIME       NOT NULL,
    [CountryId]                  INT            NULL,
    [Abbreviation]               NVARCHAR (50)  NULL,
    [ShortName]                  NVARCHAR (50)  NULL,
    [FullName]                   NVARCHAR (150) NULL,
    CONSTRAINT [PK_CORE_NationalRegion] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_NationalRegion_Country] FOREIGN KEY ([CountryId]) REFERENCES [core].[Country] ([Id]),
    CONSTRAINT [FK_NationalRegion_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_NationalRegion_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_NationalRegion_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

