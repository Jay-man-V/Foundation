-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [core].[usp_SequenceGenerator_GetNextId]
    @applicationId INT,
    @userProfileId INT,
	@sequenceName NVARCHAR(200)
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
        core.SequenceGenerator
    SET
        LastId = 0
    WHERE
        SequenceName = @sequenceName AND
        ResetOnNewDate = 1 AND
        DATEDIFF(DAY, LastUpdatedOn, GETDATE()) >= 1

    -- 
    MERGE INTO
        core.SequenceGenerator AS target
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

                SequenceName,
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

                    SequenceName,
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

                        sg.SequenceName,
                        sg.LastId + 1 AS NextId
                    FROM
                        core.SequenceGenerator sg
                            INNER JOIN core.ConfigurationScope cs ON
                            (
                                cs.Id = sg.ConfigurationScopeId
                            )
                    WHERE
                        sg.StatusId IN ( 0, 1 ) AND
                        sg.SequenceName = @sequenceName AND
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

                        @sequenceName AS SequenceName,
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
            SequenceName,
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
            source.SequenceName,
            source.NextId
        );

    -- Return the correct sequence
    SELECT
        sg.LastId
    FROM
        core.SequenceGenerator sg
    WHERE
        sg.StatusId IN ( 0, 1 ) AND
        sg.SequenceName = @sequenceName AND
        COALESCE ( sg.ApplicationId, 0 ) IN ( 0, /* Core System Application */ @applicationId ) AND
        sg.CreatedByUserProfileId IN ( 1, /* System User */ @userProfileId )
END