/*
--DECLARE @LoggedOnUserApplicationId INT = 100
*/

SELECT 
    lou.*, 
    up.[DisplayName],
    up.[Username],
    r.[Id] AS RoleId, 
    r.[Description] AS RoleDescription, 
    r.[SystemSupportOnly] AS IsSystemSupport
FROM 
    [sec].[LoggedOnUser] lou 
        INNER JOIN [sec].[UserProfile] up ON
        (
             up.[Id] = lou.[UserProfileId] 
        )
        INNER JOIN [sec].[Application] a ON
        (
             a.[Id] = lou.[ApplicationId] 
        )
        INNER JOIN [sec].[ApplicationUserRole] aur ON
        (
             aur.[ApplicationId] = lou.[ApplicationId] AND
             aur.[UserProfileId] = lou.[CreatedByUserProfileId] 
        )
        INNER JOIN [sec].[Role] r ON
        (
             r.[Id] = aur.[RoleId] 
        )
WHERE 
    lou.[StatusId] IN ( SELECT [las].[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) [las] ) AND 
    up.[StatusId] IN ( SELECT [las].[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) [las] ) AND 
    a.[StatusId] IN ( SELECT [las].[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) [las] ) AND 
    aur.[StatusId] IN ( SELECT [las].[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) [las] ) AND 
    r.[StatusId] IN ( SELECT [las].[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) [las] ) AND 
    GETDATE() BETWEEN up.[ValidFrom] AND up.[ValidTo] AND 
    GETDATE() BETWEEN a.[ValidFrom] AND a.[ValidTo] AND 
    GETDATE() BETWEEN aur.[ValidFrom] AND aur.[ValidTo] AND 
    GETDATE() BETWEEN r.[ValidFrom] AND r.[ValidTo] AND
    DATEDIFF(MI, lou.[LastUpdatedOn], GETDATE()) <= 1 AND
    lou.[ApplicationId] = @LoggedOnUserApplicationId
ORDER BY
    aur.[Id] DESC, lou.[LoggedOn] ASC
