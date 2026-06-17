/*
--DECLARE @UserProfileExternalKeyId VARCHAR(256) = 'user1'
--DECLARE @ApplicationUserRoleApplicationId INT = 100
*/

SELECT
    up.*,
    aur.RoleId
FROM
    [sec].[UserProfile] up
        INNER JOIN [sec].[ApplicationUserRole] aur ON
        (
             up.[Id] = aur.[UserProfileId]
        )
WHERE
    up.[ExternalKeyId] = @UserProfileExternalKeyId AND
    aur.[ApplicationId] = @ApplicationUserRoleApplicationId AND
    GETDATE() BETWEEN up.[ValidFrom] AND up.[ValidTo] AND
    GETDATE() BETWEEN aur.[ValidFrom] AND aur.[ValidTo]
