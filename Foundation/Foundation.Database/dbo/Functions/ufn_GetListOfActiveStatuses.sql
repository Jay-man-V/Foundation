CREATE FUNCTION [dbo].[ufn_GetListOfActiveStatuses]
(
    @includePending BIT = 0
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT
        [Id],
        [Code]
    FROM
        [core].[Status]
    WHERE
        [Id] IN ( 0, 1 ) OR
        (
            @includePending = 1 AND
            [Id] IN ( 2 )
        )

)