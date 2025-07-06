CREATE TABLE [core].[Office] (
    [Id]                         INT           IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION    NOT NULL,
    [StatusId]                   INT           NOT NULL,
    [CreatedByUserProfileId]     INT           NOT NULL,
    [LastUpdatedByUserProfileId] INT           NOT NULL,
    [CreatedOn]                  DATETIME      NOT NULL,
    [LastUpdatedOn]              DATETIME      NOT NULL,
    [ValidFrom]                  DATETIME      NOT NULL,
    [ValidTo]                    DATETIME      NOT NULL,
    [Code]                       NVARCHAR (10) NULL,
    [ShortName]                  NVARCHAR (50) NULL,
    [ContactDetailId]            INT           NULL,
    [OfficeWeekCalendarId]       INT           NULL,
    CONSTRAINT [PK_CORE_Office] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Office_ContactDetail] FOREIGN KEY ([ContactDetailId]) REFERENCES [core].[ContactDetail] ([Id]),
    CONSTRAINT [FK_Office_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_Office_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_Office_OfficeWeekCalendar] FOREIGN KEY ([OfficeWeekCalendarId]) REFERENCES [core].[OfficeWeekCalendar] ([Id]),
    CONSTRAINT [FK_Office_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id])
);

