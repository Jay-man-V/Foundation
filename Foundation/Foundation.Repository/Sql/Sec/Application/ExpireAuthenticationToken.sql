/*
--DECLARE @AuthenticationTokenId INT = 100
*/

UPDATE
    [sec].[AuthenticationToken]
SET
    [LastUpdatedOn] = GETDATE(),
    [StatusId] = -1
WHERE
    [Id] = @AuthenticationTokenId
