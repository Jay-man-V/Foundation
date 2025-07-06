CREATE TABLE [core].[ApplicationConfiguration] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION     NOT NULL,
    [StatusId]                   INT            NOT NULL,
    [CreatedByUserProfileId]     INT            NOT NULL,
    [LastUpdatedByUserProfileId] INT            NOT NULL,
    [CreatedOn]                  DATETIME       NOT NULL,
    [LastUpdatedOn]              DATETIME       NOT NULL,
    [ValidFrom]                  DATETIME       NOT NULL,
    [ValidTo]                    DATETIME       NOT NULL,
    [ApplicationId]              INT            NULL,
    [ConfigurationScopeId]       INT            NULL,
    [Key]                        NVARCHAR (250) NULL,
    [Value]                      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_CORE_ApplicationConfiguration] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ApplicationConfiguration_Application] FOREIGN KEY ([ApplicationId]) REFERENCES [sec].[Application] ([Id]),
    CONSTRAINT [FK_ApplicationConfiguration_ConfigurationScopeId] FOREIGN KEY ([ConfigurationScopeId]) REFERENCES [core].[ConfigurationScope] ([Id]),
    CONSTRAINT [FK_ApplicationConfiguration_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_ApplicationConfiguration_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_ApplicationConfiguration_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

