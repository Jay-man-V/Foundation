/*
--DECLARE @ApplicationId INT = 100
--DECLARE @UserProfileId INT = 100
*/

SELECT
    *
FROM
    [sec].[Application] a
        INNER JOIN [sec].[ApplicationUserRole] aur ON
         (
              aur.[ApplicationId] = a.[Id]
         )
        INNER JOIN [sec].[UserProfile] up ON
         (
              up.[Id] = aur.[UserProfileId]
         )
WHERE
    a.[StatusId] IN ( SELECT [las].[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) [las] ) AND
    GETDATE() BETWEEN a.[ValidFrom] AND a.[ValidTo] AND
    aur.[StatusId] IN ( SELECT [las].[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) [las] ) AND
    GETDATE() BETWEEN aur.[ValidFrom] AND aur.[ValidTo] AND
    up.[StatusId] IN ( SELECT [las].[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) [las] ) AND
    GETDATE() BETWEEN up.[ValidFrom] AND up.[ValidTo] AND
    a.[Id] = @ApplicationId AND
    up.[Id] = @UserProfileId
