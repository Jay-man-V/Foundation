/*
--DECLARE @ApplicationId INT = 100
--DECLARE @UserProfileId INT = 100
*/

UPDATE
    [sec].[LoggedOnUser]
SET
    [LastUpdatedOn] = GETDATE(),
    [LastActive] = GETDATE()
WHERE
    [ApplicationId] = @LoggedOnUserApplicationId AND
    [UserProfileId] = @LoggedOnUserUserProfileId
