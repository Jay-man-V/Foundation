CREATE TABLE [log].[EventLogAttachment] (
    [Id]                         INT             IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION      NOT NULL,
    [StatusId]                   INT             NOT NULL,
    [CreatedByUserProfileId]     INT             NOT NULL,
    [LastUpdatedByUserProfileId] INT             NOT NULL,
    [CreatedOn]                  DATETIME        NOT NULL,
    [LastUpdatedOn]              DATETIME        NOT NULL,
    [EventLogId]                 INT             NULL,
    [AttachmentFileName]         NVARCHAR (300)  NULL,
    [Attachment]                 VARBINARY (MAX) NULL,
    CONSTRAINT [PK_LOG_EventLogAttachment] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EventLogAttachment_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_EventLogAttachment_EventLog] FOREIGN KEY ([EventLogId]) REFERENCES [log].[EventLog] ([Id]),
    CONSTRAINT [FK_EventLogAttachment_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_EventLogAttachment_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

