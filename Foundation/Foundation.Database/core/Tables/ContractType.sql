CREATE TABLE [core].[ContractType] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION     NOT NULL,
    [StatusId]                   INT            NOT NULL,
    [CreatedByUserProfileId]     INT            NOT NULL,
    [LastUpdatedByUserProfileId] INT            NOT NULL,
    [CreatedOn]                  DATETIME       NOT NULL,
    [LastUpdatedOn]              DATETIME       NOT NULL,
    [ValidFrom]                  DATETIME       NOT NULL,
    [ValidTo]                    DATETIME       NOT NULL,
    [Name]                       NVARCHAR (1)   NULL,
    [Description]                NVARCHAR (250) NULL,
    CONSTRAINT [PK_CORE_ContractType] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ContractType_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_ContractType_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_ContractType_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

