//-----------------------------------------------------------------------
// <copyright file="StoredProcedureNames.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Common.DataColumns
{
    /// <summary>
    /// Stored Procedure Names
    /// </summary>
    public abstract class StoredProcedureNames
    {
        /// <summary>
        /// [core].[usp_NonWorkingDays_GetWorkingDays]
        /// </summary>
        public static String NonWorkingDaysGetWorkingDays => "[core].[usp_NonWorkingDays_GetWorkingDays]";

        /// <summary>
        /// [core].[usp_NonWorkingDays_GetWorkingDaysByMonth]
        /// </summary>
        public static String NonWorkingDaysGetWorkingDaysByMonth => "[core].[usp_NonWorkingDays_GetWorkingDaysByMonth]";

        /// <summary>
        /// [sec].[usp_UserProfile_LoadFromActiveDirectoryUsersFromStaging]
        /// </summary>
        public static String UserProfileLoadFromActiveDirectoryUsersFromStaging => "[sec].[usp_UserProfile_LoadFromActiveDirectoryUsersFromStaging]";
    }
}
