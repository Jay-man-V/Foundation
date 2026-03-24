MERGE
    core.ApplicationConfiguration target
USING
    (
        SELECT
            (SELECT [dbo].[ufn_EntityStatus_Active]()) AS [StatusId],
            @ApplicationConfigurationCreatedByUserProfileId AS [CreatedByUserProfileId],
            @ApplicationConfigurationLastUpdatedByUserProfileId AS [LastUpdatedByUserProfileId],
            GETDATE() AS [CreatedOn],
            GETDATE() AS [LastUpdatedOn],
            GETDATE() AS [ValidFrom],
            ( SELECT [dbo].[ufn_Default_ValidToDateTime] () ) AS [ValidTo],

            @ApplicationConfigurationApplicationId AS [ApplicationId],
            @ApplicationConfigurationConfigurationScopeId AS [ConfigurationScopeId],
            @ApplicationConfigurationKey AS [Key],
            @ApplicationConfigurationValue AS [Value]
    ) AS source
ON
    (
        target.[StatusId] = source.[StatusId] AND
        target.[ApplicationId] = source.[ApplicationId] AND
        target.[ConfigurationScopeId] = source.[ConfigurationScopeId] AND
        target.[Key] = source.[Key]
    )
WHEN MATCHED THEN UPDATE SET
        target.[LastUpdatedByUserProfileId] = source.[LastUpdatedByUserProfileId],
        target.[LastUpdatedOn] = source.[LastUpdatedOn],
        target.[Value] = source.[Value]
WHEN NOT MATCHED THEN INSERT
    (
        StatusId,
        CreatedByUserProfileId,
        LastUpdatedByUserProfileId,
        CreatedOn,
        LastUpdatedOn,
        ValidFrom,
        ValidTo,

        ApplicationId,
        ConfigurationScopeId,
        [Key],
        Value
    )
VALUES
    (
        source.StatusId,
        source.CreatedByUserProfileId,
        source.LastUpdatedByUserProfileId,
        source.CreatedOn,
        source.LastUpdatedOn,
        source.ValidFrom,
        source.ValidTo,

        source.ApplicationId,
        source.ConfigurationScopeId,
        source.[Key],
        source.Value
    );
