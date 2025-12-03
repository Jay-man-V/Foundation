CREATE TABLE [core].[ImageType] (
    [Id]                         INT           IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION    NOT NULL,
    [StatusId]                   INT           NOT NULL,
    [CreatedByUserProfileId]     INT           NOT NULL,
    [LastUpdatedByUserProfileId] INT           NOT NULL,
    [CreatedOn]                  DATETIME      NOT NULL,
    [LastUpdatedOn]              DATETIME      NOT NULL,
    [ValidFrom]                  DATETIME      NOT NULL,
    [ValidTo]                    DATETIME      NOT NULL,
    [Name]                       NVARCHAR (50) NULL,
    [FileExtension]              NVARCHAR (50) NULL,
    CONSTRAINT [PK_CORE_ImageType] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ImageType_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_ImageType_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_ImageType_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

