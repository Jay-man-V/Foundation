
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[ufn_CheckIsWorkingDayOrGetNextWorkingDay]
(
    @countryIsoCode NVARCHAR(10) = 'GB',
	@startDate DATE
)
RETURNS DATE
AS
BEGIN
	-- Declare the return variable here
    DECLARE @returnValue AS DATE

	-- Add the T-SQL statements to compute the return value here

    DECLARE @workingDate AS DATE = @startDate
	DECLARE @windowStartDate AS DATE
    DECLARE @windowEndDate AS DATE

    -- Adjust the given start date based on known non working days
    -- Also take an educated guess
    SELECT
        @windowStartDate = StartDate,
        @windowEndDate = NextEndDate
    FROM
    (
        SELECT
            @workingDate x,
            [Date] StartDate,
            GREATEST ( LEAD ([Date], 1, [Date] ) OVER ( ORDER BY [Date] ),
            LEAD ( [Date], 2, [Date] ) OVER ( ORDER BY [Date] ) ) AS NextEndDate
        FROM
            core.NonWorkingDay
        WHERE
            DATEPART ( YEAR, [Date]) >= DATEPART ( YEAR, @startDate )
    ) TargetRange
    WHERE
        @workingDate BETWEEN [StartDate] AND [NextEndDate];

    SELECT @windowStartDate = COALESCE ( @windowStartDate, @startDate );
    SELECT @windowEndDate   = COALESCE ( @windowEndDate,   @workingDate );

    WITH
        vw_WeekendDaysForCountry AS
        (
            SELECT
                cnwd.[Id],
                cnwd.[DayOfWeekIndex]
            FROM
                [core].[Country] c
                    INNER JOIN [core].[CountryNonWorkingDay] cnwd ON
                    (
					    cnwd.[CountryId] = c.[Id]
                    )
		    WHERE
			    c.[IsoCode] = @countryIsoCode
        )

    SELECT
        @returnValue = MIN ( dates.[Date] )
    FROM
        dbo.ufn_GetListOfCalendarDates ( @windowStartDate, @windowEndDate ) dates
            LEFT OUTER JOIN core.NonWorkingDay nwd on
            (
                nwd.[Date] = dates.[Date]
            )
            LEFT OUTER JOIN vw_WeekendDaysForCountry wdfc ON
            (
                wdfc.[DayOfWeekIndex] = dates.[DayOfWeekIndex]
            )
    WHERE
        nwd.[Id] IS NULL AND
        wdfc.[Id] IS NULL AND
        dates.[Date] >= @startDate
    OPTION ( MAXRECURSION 2000 )

	-- Return the result of the function
	RETURN @returnValue

END
