CREATE TABLE [core].[Timezone] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION     NOT NULL,
    [StatusId]                   INT            NOT NULL,
    [CreatedByUserProfileId]     INT            NOT NULL,
    [LastUpdatedByUserProfileId] INT            NOT NULL,
    [CreatedOn]                  DATETIME       NOT NULL,
    [LastUpdatedOn]              DATETIME       NOT NULL,
    [ValidFrom]                  DATETIME       NOT NULL,
    [ValidTo]                    DATETIME       NOT NULL,
    [Code]                       NVARCHAR (6)   NULL,
    [Description]                NVARCHAR (150) NULL,
    [Offset]                     TINYINT        NULL,
    [HasDaylightSavings]         BIT            NULL,
    CONSTRAINT [PK_CORE_Timezone] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Timezone_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_Timezone_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_Timezone_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

