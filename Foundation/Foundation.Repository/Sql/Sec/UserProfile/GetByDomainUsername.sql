/*
--DECLARE @UserProfileDomainName AS VARCHAR(100) = 'example.com'
--DECLARE @UserProfileUsername AS VARCHAR(100) = 'john.doe'
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
    up.DomainName = @UserProfileDomainName AND
    up.Username = @UserProfileUsername AND
    aur.ApplicationId = @ApplicationUserRoleApplicationId AND
    GETDATE() BETWEEN up.[ValidFrom] AND up.[ValidTo] AND
    GETDATE() BETWEEN aur.[ValidFrom] AND aur.[ValidTo]
