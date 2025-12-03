CREATE TABLE [log].[LogSeverity] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION     NOT NULL,
    [StatusId]                   INT            NOT NULL,
    [CreatedByUserProfileId]     INT            NOT NULL,
    [LastUpdatedByUserProfileId] INT            NOT NULL,
    [CreatedOn]                  DATETIME       NOT NULL,
    [LastUpdatedOn]              DATETIME       NOT NULL,
    [ValidFrom]                  DATETIME       NULL,
    [ValidTo]                    DATETIME       NULL,
    [Code]                       NCHAR (10)     NULL,
    [Description]                NVARCHAR (250) NULL,
    CONSTRAINT [PK_LOG_LogSeverity] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LogSeverity_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_LogSeverity_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_LogSeverity_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Severity_Code]
    ON [log].[LogSeverity]([Code] ASC);

