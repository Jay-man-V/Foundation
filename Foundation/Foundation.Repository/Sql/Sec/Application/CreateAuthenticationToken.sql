/*
--DECLARE @ApplicationId INT = 100
--DECLARE @UserProfileId INT = 100
*/

INSERT INTO
    [sec].[AuthenticationToken]
(
    [StatusId],
    [CreatedByUserProfileId],
    [LastUpdatedByUserProfileId],
    [CreatedOn],
    [LastUpdatedOn],
    [ApplicationId],
    [UserProfileId],
    [Token],
    [Acquired],
    [LastRefreshed]
)
VALUES
(
    @AuthenticationTokenStatusId,
    @AuthenticationTokenCreatedByUserProfileId,
    @AuthenticationTokenLastUpdatedByUserProfileId,
    GETDATE(),
    GETDATE(),
    @AuthenticationTokenApplicationId,
    @AuthenticationTokenUserProfileId,
    @AuthenticationTokenToken,
    GETDATE(),
    GETDATE()
)
;
SELECT
    *
FROM
    [sec].[AuthenticationToken]
WHERE
    [Id] = (SELECT SCOPE_IDENTITY())
