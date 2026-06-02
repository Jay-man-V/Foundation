/*
--DECLARE @AuthenticationTokenId1 INT = 100
--DECLARE @AuthenticationTokenId2 INT = 100
*/

UPDATE
    [sec].[AuthenticationToken]
SET
    [LastUpdatedOn] = GETDATE(),
    [LastRefreshed] = GETDATE()
WHERE
    [StatusId] IN ( SELECT [las].[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) [las] ) AND
    [Id] = @AuthenticationTokenId1

SELECT
    [LastRefreshed]
FROM
    [sec].[AuthenticationToken]
WHERE
    [Id] = @AuthenticationTokenId2
