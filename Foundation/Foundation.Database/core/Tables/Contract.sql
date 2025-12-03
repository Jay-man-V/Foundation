CREATE TABLE [core].[Contract] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION     NOT NULL,
    [StatusId]                   INT            NOT NULL,
    [CreatedByUserProfileId]     INT            NOT NULL,
    [LastUpdatedByUserProfileId] INT            NOT NULL,
    [CreatedOn]                  DATETIME       NOT NULL,
    [LastUpdatedOn]              DATETIME       NOT NULL,
    [ValidFrom]                  DATETIME       NOT NULL,
    [ValidTo]                    DATETIME       NOT NULL,
    [StartDate]                  DATETIME       NULL,
    [EndDate]                    DATETIME       NULL,
    [ContractTypeId]             INT            NULL,
    [ContractReference]          NVARCHAR (100) NULL,
    [ShortName]                  NVARCHAR (50)  NULL,
    [FullName]                   NVARCHAR (250) NULL,
    CONSTRAINT [PK_CORE_Contract] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Contract_ContractType] FOREIGN KEY ([ContractTypeId]) REFERENCES [core].[ContractType] ([Id]),
    CONSTRAINT [FK_Contract_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_Contract_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_Contract_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Contract_ContractReference]
    ON [core].[Contract]([ContractReference] ASC);

