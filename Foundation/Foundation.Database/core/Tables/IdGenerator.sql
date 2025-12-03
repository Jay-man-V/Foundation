CREATE TABLE [core].[IdGenerator] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION     NOT NULL,
    [StatusId]                   INT            NOT NULL,
    [CreatedByUserProfileId]     INT            NOT NULL,
    [LastUpdatedByUserProfileId] INT            NOT NULL,
    [CreatedOn]                  DATETIME       NOT NULL,
    [LastUpdatedOn]              DATETIME       NOT NULL,
    [ApplicationId]              INT            NULL,
    [ConfigurationScopeId]       INT            NULL,
    [IdName]                     NVARCHAR (200) NULL,
    [LastId]                     INT            NULL,
    [ResetOnNewDate]             BIT            NULL,
    CONSTRAINT [PK_CORE_IdGenerator] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_IdGenerator_Application] FOREIGN KEY ([ApplicationId]) REFERENCES [sec].[Application] ([Id]),
    CONSTRAINT [FK_IdGenerator_ConfigurationScopeId] FOREIGN KEY ([ConfigurationScopeId]) REFERENCES [core].[ConfigurationScope] ([Id]),
    CONSTRAINT [FK_IdGenerator_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_IdGenerator_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_IdGenerator_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

