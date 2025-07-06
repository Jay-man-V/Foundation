CREATE TABLE [core].[NonWorkingDay] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION     NOT NULL,
    [StatusId]                   INT            NOT NULL,
    [CreatedByUserProfileId]     INT            NOT NULL,
    [LastUpdatedByUserProfileId] INT            NOT NULL,
    [CreatedOn]                  DATETIME       NOT NULL,
    [LastUpdatedOn]              DATETIME       NOT NULL,
    [ValidFrom]                  DATETIME       NOT NULL,
    [ValidTo]                    DATETIME       NOT NULL,
    [Date]                       DATETIME       NULL,
    [CountryId]                  INT            NULL,
    [Description]                NVARCHAR (150) NULL,
    [Notes]                      NVARCHAR (150) NULL,
    CONSTRAINT [PK_CORE_NonWorkingDay] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_NonWorkingDay_Country] FOREIGN KEY ([CountryId]) REFERENCES [core].[Country] ([Id]),
    CONSTRAINT [FK_NonWorkingDay_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_NonWorkingDay_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_NonWorkingDay_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

