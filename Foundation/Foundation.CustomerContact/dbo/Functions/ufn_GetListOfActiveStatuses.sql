CREATE FUNCTION [dbo].[ufn_GetListOfActiveStatuses]
(
    @includePending BIT = 0
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	SELECT 
        Id,
        Name
    FROM
        core.Status
    WHERE
        ID IN ( 0, 1 )
    UNION ALL
	SELECT 
        Id,
        Name
    FROM
        core.Status
    WHERE
        ID IN ( 3 ) AND @includePending = 1

)