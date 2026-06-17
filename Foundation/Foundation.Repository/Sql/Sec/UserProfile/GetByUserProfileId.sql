/*
--DECLARE @UserProfileId AS INT = 1
--DECLARE @ApplicationUserRoleApplicationId AS INT = 1
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
    up.Id = @UserProfileId AND
    aur.ApplicationId = @ApplicationUserRoleApplicationId AND
    GETDATE() BETWEEN up.[ValidFrom] AND up.[ValidTo] AND
    GETDATE() BETWEEN aur.[ValidFrom] AND aur.[ValidTo]
