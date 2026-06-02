/*
--DECLARE @ApplicationId INT = 100
--DECLARE @UserProfileId INT = 100
*/

MERGE INTO
    [sec].[LoggedOnUser] AS target
USING
    (
        SELECT
            0 AS LoggedOnUserStatusId,
            @LoggedOnUserCreatedByUserProfileId AS LoggedOnUserCreatedByUserProfileId,
            @LoggedOnUserLastUpdatedByUserProfileId AS LoggedOnUserLastUpdatedByUserProfileId,
            GETDATE() AS LoggedOnUserCreatedOn,
            GETDATE() AS LoggedOnUserLastUpdatedOn,

            @LoggedOnUserApplicationId AS LoggedOnUserApplicationId,
            @LoggedOnUserUserProfileId AS LoggedOnUserUserProfileId,
            GETDATE() AS LoggedOnUserLoggedOn,
            GETDATE() AS LoggedOnUserLastActive
    ) AS source
ON
    (
        target.ApplicationId = source.LoggedOnUserApplicationId AND
        target.UserProfileId = source.LoggedOnUserUserProfileId
    )
WHEN MATCHED THEN UPDATE SET
       target.LastUpdatedOn = source.LoggedOnUserLastUpdatedOn,
       target.LastActive = source.LoggedOnUserLastActive,
       target.LoggedOn = source.LoggedOnUserLoggedOn
WHEN NOT MATCHED THEN INSERT
   (
       StatusId,
       CreatedByUserProfileId,
       LastUpdatedByUserProfileId,
       CreatedOn,
       LastUpdatedOn,

       ApplicationId,
       UserProfileId,
       LoggedOn,
       LastActive
   )
   VALUES
   (
       source.LoggedOnUserStatusId,
       source.LoggedOnUserCreatedByUserProfileId,
       source.LoggedOnUserLastUpdatedByUserProfileId,
       source.LoggedOnUserCreatedOn,
       source.LoggedOnUserLastUpdatedOn,

       source.LoggedOnUserApplicationId,
       source.LoggedOnUserUserProfileId,
       source.LoggedOnUserLoggedOn,
       source.LoggedOnUserLastActive
   )
;
