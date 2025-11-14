DECLARE @applicationId INT = -1;
DECLARE @excludeDeleted INT = -1;
DECLARE @useValidityPeriod INT = -1;

WITH MenuItemsCTE AS
(
    SELECT
        m.Id,
        m.Timestamp,
        m.StatusId,
        m.CreatedByUserProfileId,
        m.LastUpdatedByUserProfileId,
        m.CreatedOn,
        m.LastUpdatedOn,
        m.ValidFrom,
        m.ValidTo,
        m.ApplicationId,
        m.ParentMenuItemId,
        m.Name,
        m.Caption,
        m.ControllerAssembly,
        m.ControllerType,
        m.ViewAssembly,
        m.ViewType,
        m.HelpText,
        m.MultiInstance,
        m.ShowInTab,
        m.Icon,
        m.DisplayOrder,
        1 AS Depth
    FROM
        [app].[MenuItem] m
    WHERE
        m.ParentMenuItemId IS NULL
    UNION ALL
    SELECT
        s.Id,
        s.Timestamp,
        s.StatusId,
        s.CreatedByUserProfileId,
        s.LastUpdatedByUserProfileId,
        s.CreatedOn,
        s.LastUpdatedOn,
        s.ValidFrom,
        s.ValidTo,
        s.ApplicationId,
        s.ParentMenuItemId,
        s.Name,
        s.Caption,
        s.ControllerAssembly,
        s.ControllerType,
        s.ViewAssembly,
        s.ViewType,
        s.HelpText,
        s.MultiInstance,
        s.ShowInTab,
        s.Icon,
        s.DisplayOrder,
        Depth + 1 AS Depth
    FROM
        [app].[MenuItem] s
            INNER JOIN MenuItemsCTE r ON
            (
                r.Id = s.ParentMenuItemId
            )
)
SELECT
    *
FROM
    MenuItemsCTE m
WHERE
    StatusId IN (SELECT Id FROM ufn_GetListOfActiveStatuses(DEFAULT)) AND
    (
        m.ApplicationId = @applicationId OR
        @applicationId = -1
    ) AND
    (
        @useValidityPeriod = -1 OR
        (
            @useValidityPeriod = 1 AND
            GETDATE() BETWEEN m.ValidFrom and m.ValidTo
        )
    ) AND
    (
        @excludeDeleted = -1 OR
        (
            @excludeDeleted = 1 AND
            m.StatusId = -1
        )
    )
ORDER BY
    m.ParentMenuItemId, m.DisplayOrder
