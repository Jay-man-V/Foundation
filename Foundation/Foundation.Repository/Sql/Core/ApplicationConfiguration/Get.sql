/*
--DECLARE @ApplicationConfigurationKey NVARCHAR = ''
--DECLARE @ApplicationConfigurationApplicationId INT = 1
--DECLARE @ApplicationConfigurationCreatedByUserProfileId INT = 1
*/

SELECT
    *
FROM
    (
        SELECT
            ac.*,
            RANK() OVER (PARTITION BY ac.[Key] ORDER BY ac.[ApplicationId] DESC, cs.[UsageSequence] ASC) AS Rnk
        FROM
            [core].[ApplicationConfiguration] ac
                INNER JOIN [core].[ConfigurationScope] cs ON
                (
                    cs.[Id] = ac.[ConfigurationScopeId]
                )
        WHERE
            ac.[StatusId] IN ( SELECT [Id] FROM [dbo].[ufn_GetListOfActiveStatuses](0) ) AND
            GETDATE() BETWEEN ac.[ValidFrom] AND ac.[ValidTo] AND
            ac.[Key] = @ApplicationConfigurationKey AND
            COALESCE ( ac.[ApplicationId], ( SELECT [dbo].[ufn_Default_CoreSystemApplicationId] () ) ) IN ( ( SELECT [dbo].[ufn_Default_CoreSystemApplicationId] () ), /* Core System Application */ @ApplicationConfigurationApplicationId ) AND
            ac.[CreatedByUserProfileId] IN ( ( SELECT [dbo].[ufn_Default_CoreSystemUserProfileId] () ), /* System User */ @ApplicationConfigurationCreatedByUserProfileId )
    ) s
WHERE
    Rnk = 1
ORDER BY
    [Key] ASC
