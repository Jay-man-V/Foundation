CREATE TABLE [core].[EntityStatus] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION     NOT NULL,
    [StatusId]                   INT            NOT NULL,
    [CreatedByUserProfileId]     INT            NOT NULL,
    [LastUpdatedByUserProfileId] INT            NOT NULL,
    [CreatedOn]                  DATETIME       NOT NULL,
    [LastUpdatedOn]              DATETIME       NOT NULL,
    [ValidFrom]                  DATETIME       NOT NULL,
    [ValidTo]                    DATETIME       NOT NULL,
    [Name]                       NVARCHAR (25)  NULL,
    [Description]                NVARCHAR (150) NULL,
    CONSTRAINT [PK_CORE_EntityStatus] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EntityStatus_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_EntityStatus_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_EntityStatus_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

