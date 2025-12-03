CREATE TABLE [core].[CountryNonWorkingDay] (
    [Id]                         INT        IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION NOT NULL,
    [StatusId]                   INT        NOT NULL,
    [CreatedByUserProfileId]     INT        NOT NULL,
    [LastUpdatedByUserProfileId] INT        NOT NULL,
    [CreatedOn]                  DATETIME   NOT NULL,
    [LastUpdatedOn]              DATETIME   NOT NULL,
    [CountryId]                  INT        NULL,
    [DayOfWeekIndex]             INT        NULL,
    CONSTRAINT [PK_CORE_CountryNonWorkingDay] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CountryNonWorkingDay_Country] FOREIGN KEY ([CountryId]) REFERENCES [core].[Country] ([Id]),
    CONSTRAINT [FK_CountryNonWorkingDay_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_CountryNonWorkingDay_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_CountryNonWorkingDay_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

