-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [core].[usp_IdGenerator_GetNextId]
    @applicationId INT,
    @userProfileId INT,
	@idName NVARCHAR(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    IF @applicationId IS NULL
        RAISERROR('@applicationId must be specified and cannot be null', 15, 1)

    -- If required, reset action first
    DECLARE @runDate DATETIME = GETDATE()

    UPDATE
        core.IdGenerator
    SET
        LastId = 0
    WHERE
        IdName = @idName AND
        ResetOnNewDate = 1 AND
        DATEDIFF(DAY, LastUpdatedOn, GETDATE()) >= 1

    -- 
    MERGE INTO
        core.IdGenerator AS target
    USING
        (
            SELECT
                Id,
                CreatedByUserProfileId,
                LastUpdatedByUserProfileId,
                CreatedOn,
                LastUpdatedOn,
                ApplicationId,
                ConfigurationScopeId,

                IdName,
                NextId
            FROM
            (
                SELECT
                    Id,
                    CreatedByUserProfileId,
                    LastUpdatedByUserProfileId,
                    CreatedOn,
                    LastUpdatedOn,
                    ApplicationId,
                    ConfigurationScopeId,

                    IdName,
                    NextId,
                    RANK() OVER (ORDER BY Id DESC) AS Rnk
                FROM
                (
                    SELECT
                        sg.Id,
                        sg.CreatedByUserProfileId,
                        sg.LastUpdatedByUserProfileId,
                        sg.CreatedOn,
                        GETDATE() AS LastUpdatedOn,
                        ApplicationId,
                        ConfigurationScopeId,

                        sg.IdName,
                        sg.LastId + 1 AS NextId
                    FROM
                        core.IdGenerator sg
                            INNER JOIN core.ConfigurationScope cs ON
                            (
                                cs.Id = sg.ConfigurationScopeId
                            )
                    WHERE
                        sg.StatusId IN ( 0, 1 ) AND
                        sg.IdName = @idName AND
                        COALESCE ( sg.ApplicationId, 0 ) IN ( 0, /* Core System Application */ @applicationId ) AND
                        sg.CreatedByUserProfileId IN ( 1, /* System User */ @userProfileId )
                    UNION ALL
                    SELECT
                        NULL Id,
                        1 AS CreatedByUserProfileId, /* System User */
                        1 AS LastUpdatedByUserProfileId, /* System User */
                        GETDATE() AS CreatedOn,
                        GETDATE() AS LastUpdatedOn,
                        0 AS ApplicationId, /* Core System Application */
                        1 AS ConfigurationScopeId, /* System */

                        @idName AS IdName,
                        1 AS NextSequence
                ) s
            ) s
            WHERE
                Rnk = 1
        ) AS source
    ON
    (
        target.Id = source.Id AND
        target.StatusId = 0
    )
    WHEN MATCHED THEN UPDATE SET
        target.LastUpdatedByUserProfileId = source.LastUpdatedByUserProfileId,
        target.LastUpdatedOn = source.LastUpdatedOn,
        target.LastId = source.NextId
    WHEN NOT MATCHED THEN INSERT
        (
            StatusId,
            CreatedByUserProfileId,
            LastUpdatedByUserProfileId,
            CreatedOn,
            LastUpdatedOn,

            ApplicationId,
            ConfigurationScopeId,
            IdName,
            LastId
        )
        VALUES
        (
            0,
            source.CreatedByUserProfileId,
            source.LastUpdatedByUserProfileId,
            source.CreatedOn,
            source.LastUpdatedOn,

            source.ApplicationId,
            source.ConfigurationScopeId,
            source.IdName,
            source.NextId
        );

    -- Return the correct sequence
    SELECT
        sg.LastId
    FROM
        core.IdGenerator sg
    WHERE
        sg.StatusId IN ( 0, 1 ) AND
        sg.IdName = @idName AND
        COALESCE ( sg.ApplicationId, 0 ) IN ( 0, /* Core System Application */ @applicationId ) AND
        sg.CreatedByUserProfileId IN ( 1, /* System User */ @userProfileId )
END
