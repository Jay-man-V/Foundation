CREATE TABLE [core].[SchedulerExecutionLog] (
    [Id]                         INT             IDENTITY (1, 1) NOT NULL,
    [Timestamp]                  ROWVERSION      NOT NULL,
    [StatusId]                   INT             NOT NULL,
    [CreatedByUserProfileId]     INT             NOT NULL,
    [LastUpdatedByUserProfileId] INT             NOT NULL,
    [CreatedOn]                  DATETIME        NOT NULL,
    [LastUpdatedOn]              DATETIME        NOT NULL,
    [ScheduledTaskId]            INT             NULL,
    [TaskStatusId]               INT             NULL,
    [Started]                    DATETIME        NULL,
    [Ended]                      DATETIME        NULL,
    [NextRun]                    DATETIME        NULL,
    [TaskImplementationType]     NVARCHAR (500)  NULL,
    [TaskParameters]             NVARCHAR (1000) NULL,
    CONSTRAINT [PK_CORE_SchedulerExecutionLog] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SchedulerExecutionLog_CreatedByUserProfile] FOREIGN KEY ([CreatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_SchedulerExecutionLog_LastUpdatedByUserProfile] FOREIGN KEY ([LastUpdatedByUserProfileId]) REFERENCES [sec].[UserProfile] ([Id]),
    CONSTRAINT [FK_SchedulerExecutionLog_ScheduledTask] FOREIGN KEY ([ScheduledTaskId]) REFERENCES [core].[ScheduledJob] ([Id]),
    CONSTRAINT [FK_SchedulerExecutionLog_Status] FOREIGN KEY ([StatusId]) REFERENCES [core].[Status] ([Id]),
    CONSTRAINT [FK_SchedulerExecutionLog_TaskStatus] FOREIGN KEY ([TaskStatusId]) REFERENCES [core].[TaskStatus] ([Id])
);

