-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[ufn_IsNonWorkingDay]
(
    @countryIsoCode VARCHAR ( 10 ) = 'GB',
    @date DATE
)
RETURNS BIT
AS
BEGIN
	-- Declare the return variable here
    DECLARE @returnValue AS BIT

	-- Add the T-SQL statements to compute the return value here
    DECLARE @rowCountNonWorkingDays AS INTEGER
    DECLARE @rowCountCountryNonWorkingDays AS INTEGER

    SELECT
        @rowCountNonWorkingDays = COUNT ( 1 )
    FROM
        [core].[NonWorkingDay] nwd
            INNER JOIN [core].[Country] c ON
            (
                c.[Id] = nwd.[CountryId]
            )
    WHERE
        nwd.[StatusId] IN ( SELECT fn1.[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) fn1 ) AND
        c.[StatusId] IN ( SELECT fn2.[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) fn2 ) AND
        c.[IsoCode] = @countryIsoCode AND
        DATEDIFF ( DAY, nwd.[Date], @date ) = 0

    SELECT
        @rowCountCountryNonWorkingDays = COUNT ( 1 )
    FROM
        [core].[Country] c
            LEFT OUTER JOIN [core].[CountryNonWorkingDay] cnwd ON
            (
                cnwd.[CountryId] = c.[Id] AND
                cnwd.DayOfWeekIndex = DATEPART ( DW, @date )
            )
    WHERE
        cnwd.[StatusId] IN ( SELECT fn1.[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) fn1 ) AND
        c.[StatusId] IN ( SELECT fn2.[Id] FROM [dbo].[ufn_GetListOfActiveStatuses] ( DEFAULT ) fn2 ) AND
        c.[IsoCode] = @countryIsoCode

    SELECT
        @returnValue = CASE
                            WHEN @rowCountNonWorkingDays > 0 OR @rowCountCountryNonWorkingDays > 0 THEN 1
                            ELSE 0
                        END

	-- Return the result of the function
    RETURN @returnValue
END