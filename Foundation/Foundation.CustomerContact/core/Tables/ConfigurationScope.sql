CREATE TABLE [core].[ConfigurationScope] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION     NOT NULL,
    [StatusId]                   INT            NOT NULL,
    [CreatedByUserProfileId]     INT            NOT NULL,
    [LastUpdatedByUserProfileId] INT            NOT NULL,
    [CreatedOn]                  DATETIME       NOT NULL,
    [LastUpdatedOn]              DATETIME       NOT NULL,
    [Name]                       NVARCHAR (25)  NULL,
    [Description]                NVARCHAR (150) NULL,
    [UsageSequence]              INT            NULL,
    CONSTRAINT [PK_CORE_ConfigurationScope] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ConfigurationScope_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_ConfigurationScope_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_ConfigurationScope_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

