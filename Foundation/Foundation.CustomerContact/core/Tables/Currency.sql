CREATE TABLE [core].[Currency] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION     NOT NULL,
    [StatusId]                   INT            NOT NULL,
    [CreatedByUserProfileId]     INT            NOT NULL,
    [LastUpdatedByUserProfileId] INT            NOT NULL,
    [CreatedOn]                  DATETIME       NOT NULL,
    [LastUpdatedOn]              DATETIME       NOT NULL,
    [ValidFrom]                  DATETIME       NOT NULL,
    [ValidTo]                    DATETIME       NOT NULL,
    [PrefixSymbol]               BIT            NULL,
    [Symbol]                     NVARCHAR (5)   NULL,
    [ISOCode]                    NVARCHAR (10)  NULL,
    [ISONumber]                  NVARCHAR (10)  NULL,
    [Name]                       NVARCHAR (150) NULL,
    [NumberToBasic]              INT            NULL,
    CONSTRAINT [PK_CORE_Currency] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Currency_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_Currency_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_Currency_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

