
CREATE FUNCTION [dbo].[ufn_GetListOfWorkingDates]
(
    @countryIsoCode NVARCHAR(10) = 'GB',
    @startDate DATE,
    @endDate DATE
)
RETURNS TABLE
AS
RETURN
(
    WITH
	    vw_NonWorkingDaysForCountry AS
	    (
		    SELECT
			    nwd.*
		    FROM
			    [core].[NonWorkingDay] nwd
				    INNER JOIN [core].[Country] c ON
				    (
					    c.Id = nwd.[CountryId]
				    )
		    WHERE
                nwd.StatusId IN ( SELECT Id FROM ufn_GetListOfActiveStatuses ( DEFAULT ) ) AND
                c.StatusId IN ( SELECT Id FROM ufn_GetListOfActiveStatuses ( DEFAULT ) ) AND
			    c.[IsoCode] = @countryIsoCode
	    ),

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
                c.StatusId IN ( SELECT Id FROM ufn_GetListOfActiveStatuses ( DEFAULT ) ) AND
                cnwd.StatusId IN ( SELECT Id FROM ufn_GetListOfActiveStatuses ( DEFAULT ) ) AND
			    c.[IsoCode] = @countryIsoCode
        )

    SELECT
        dates.[Date],
        dates.[DayOfWeekIndex],
        dates.[DayOfWeek]
    FROM
        dbo.ufn_GetListOfCalendarDates ( @startDate, @endDate ) dates
            LEFT OUTER JOIN vw_NonWorkingDaysForCountry nwdfc on
            (
                nwdfc.[Date] = dates.[Date]
            )
            LEFT OUTER JOIN vw_WeekendDaysForCountry wdfc ON
            (
                wdfc.[DayOfWeekIndex] = dates.[DayOfWeekIndex]
            )
    WHERE
        nwdfc.[Id] IS NULL AND
        wdfc.[Id] IS NULL
)