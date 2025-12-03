CREATE TABLE [dbo].[CatalogueItem] (
    [Id]                         INT             NOT NULL,
    [Timestamp]                  ROWVERSION      NOT NULL,
    [StatusId]                   INT             NOT NULL,
    [CreatedByUserProfileId]     INT             NOT NULL,
    [LastUpdatedByUserProfileId] INT             NOT NULL,
    [CreatedOn]                  DATETIME        NOT NULL,
    [LastUpdatedOn]              DATETIME        NOT NULL,
    [ValidFrom]                  DATETIME        NOT NULL,
    [ValidTo]                    DATETIME        NOT NULL,
    [Name]                       NVARCHAR (200)  NULL,
    [Description]                NVARCHAR (MAX)  NULL,
    [Image]                      VARBINARY (MAX) NULL,
    [BuyCost]                    DECIMAL (18, 6) NULL,
    [VATRateId]                  INT             NULL,
    [MarkUpRateId]               INT             NULL
);

