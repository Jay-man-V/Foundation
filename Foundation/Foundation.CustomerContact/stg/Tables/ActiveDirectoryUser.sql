CREATE TABLE [stg].[ActiveDirectoryUser] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION     NOT NULL,
    [StatusId]                   INT            NOT NULL,
    [CreatedByUserProfileId]     INT            NOT NULL,
    [LastUpdatedByUserProfileId] INT            NOT NULL,
    [CreatedOn]                  DATETIME       NOT NULL,
    [LastUpdatedOn]              DATETIME       NOT NULL,
    [ObjectSId]                  NVARCHAR (100) NULL,
    [Name]                       NVARCHAR (100) NULL,
    [FullName]                   NVARCHAR (250) NULL,
    CONSTRAINT [PK_STG_ActiveDirectoryUser] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ActiveDirectoryUser_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_ActiveDirectoryUser_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_ActiveDirectoryUser_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

