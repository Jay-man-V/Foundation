CREATE TABLE [log].[ImportExportControl] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION     NOT NULL,
    [StatusId]                   INT            NOT NULL,
    [CreatedByUserProfileId]     INT            NOT NULL,
    [LastUpdatedByUserProfileId] INT            NOT NULL,
    [CreatedOn]                  DATETIME       NOT NULL,
    [LastUpdatedOn]              DATETIME       NOT NULL,
    [ProcessedOn]                DATETIME       NULL,
    [Name]                       NVARCHAR (150) NULL,
    CONSTRAINT [PK_CORE_ImportExportControl] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ImportExportControl_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_ImportExportControl_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_ImportExportControl_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

