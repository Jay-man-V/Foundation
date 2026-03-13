CREATE TABLE [core].[Status] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION     NOT NULL,
    [StatusId]                   INT            NOT NULL,
    [CreatedByUserProfileId]     INT            NOT NULL,
    [LastUpdatedByUserProfileId] INT            NOT NULL,
    [CreatedOn]                  DATETIME       NOT NULL,
    [LastUpdatedOn]              DATETIME       NOT NULL,
    [ValidFrom]                  DATETIME       NOT NULL,
    [ValidTo]                    DATETIME       NOT NULL,
    [DisplaySequence]            SMALLINT       NULL,
    [Code]                       NVARCHAR (10)  NULL,
    [ShortDescription]           NVARCHAR (150) NULL,
    [LongDescription]            NVARCHAR (300) NULL,
    CONSTRAINT [PK_CORE_Status] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Status_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_Status_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_Status_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

