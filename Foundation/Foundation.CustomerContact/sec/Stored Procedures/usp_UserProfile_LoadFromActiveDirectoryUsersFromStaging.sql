
/****** Object:  StoredProcedure [sec].[usp_UserProfile_LoadFromActiveDirectoryUsersFromStaging]    Script Date: 15/05/2021 17:43:10 ******/
CREATE PROCEDURE [sec].[usp_UserProfile_LoadFromActiveDirectoryUsersFromStaging]
(
    @loggedOnUserProfileId INT
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    CREATE TABLE #temp_User
    (
        userProfileId INT,
        userProfileUsername NVARCHAR(100),
        userProfileDisplayName NVARCHAR(250),
        userProfileExternalKeyId NVARCHAR(100),
        activeDirectoryUserObjectSId NVARCHAR(100),
        activeDirectoryUsername NVARCHAR(250),
        activeDirectoryUserFullName NVARCHAR(250)
    )

    INSERT INTO #temp_User
    SELECT
        up.Id,              -- userProfileId
        up.Username,        -- userProfileUsername
        up.DisplayName,     -- userProfileDisplayName
        up.ExternalKeyId,   -- userProfileExternalKeyId
        adu.ObjectSId,      -- activeDirectoryUserObjectSId
        adu.Name,           -- activeDirectoryUsername
        adu.FullName        -- activeDirectoryUserFullName
    FROM
        sec.UserProfile up
            FULL OUTER JOIN stg.ActiveDirectoryUser adu ON
                up.ExternalKeyId = adu.ObjectSId

    -- Update users
    UPDATE
        sec.UserProfile
    SET
        StatusId = 0,
        Username = activeDirectoryUsername,
        DisplayName = activeDirectoryUserFullName,
        LastUpdatedByUserProfileId = @loggedOnUserProfileId,
        LastUpdatedOn = GETDATE(),
        ValidTo = '2100-12-31 23:59:59'
    FROM
        #temp_User sourceTable
    WHERE
        sec.UserProfile.ExternalKeyId = sourceTable.activeDirectoryUserObjectSId

    -- Insert users
    INSERT INTO
        sec.UserProfile
    (
        StatusId,
        CreatedByUserProfileId,
        LastUpdatedByUserProfileId,
        CreatedOn,
        LastUpdatedOn,
        ValidFrom,
        ValidTo,
        ExternalKeyId,
        Username,
        DisplayName,
        IsSystemSupport,
        ContactDetailId
    )
    SELECT
        0,                              -- StatusId
        @loggedOnUserProfileId,         -- CreatedByUserProfileId,
        @loggedOnUserProfileId,         -- LastUpdatedByUserProfileId
        GETDATE(),                      -- CreatedOn
        GETDATE(),                      -- LastUpdatedOn
        GETDATE(),                      -- ValidFrom
        '2100-12-31 23:59:59',          -- ValidTo
        activeDirectoryUserObjectSId,   -- ExternalKeyId
        activeDirectoryUsername,        -- Username
        activeDirectoryUserFullName,    -- DisplayName
        0,                              -- IsSystemSupport
        NULL                            -- ContactDetailId
    FROM
        #temp_User sourceTable
    WHERE
        userProfileId IS NULL AND
        userProfileExternalKeyId IS NULL AND
        activeDirectoryUserObjectSId IS NOT NULL

    -- Delete Users
    UPDATE
        sec.UserProfile
    SET
        StatusId = -1,
        LastUpdatedByUserProfileId = @loggedOnUserProfileId,
        LastUpdatedOn = GETDATE(),
        ValidTo = GETDATE()
    FROM
        sec.UserProfile
            INNER JOIN #temp_User ON
            (
                userProfileId = sec.UserProfile.Id
            )
    WHERE
        userProfileId IS NOT NULL AND
        userProfileExternalKeyId IS NOT NULL AND
        activeDirectoryUserObjectSId IS NULL

    COMMIT
END