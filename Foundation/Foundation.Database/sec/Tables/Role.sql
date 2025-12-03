CREATE TABLE [sec].[Role] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION     NOT NULL,
    [StatusId]                   INT            NOT NULL,
    [CreatedByUserProfileId]     INT            NOT NULL,
    [LastUpdatedByUserProfileId] INT            NOT NULL,
    [CreatedOn]                  DATETIME       NOT NULL,
    [LastUpdatedOn]              DATETIME       NOT NULL,
    [ValidFrom]                  DATETIME       NOT NULL,
    [ValidTo]                    DATETIME       NOT NULL,
    [Name]                       NVARCHAR (50)  NULL,
    [Description]                NVARCHAR (150) NULL,
    [SystemSupportOnly]          BIT            NULL,
    CONSTRAINT [PK_SEC_Role] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Role_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_Role_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_Role_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Role_Name]
    ON [sec].[Role]([Name] ASC);

