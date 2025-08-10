//-----------------------------------------------------------------------
// <copyright file="StoredProcedures.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Stored Procedure Names
    /// </summary>
    public abstract class StoredProcedures
    {
        /// <summary>
        /// [core].[usp_IdGenerator_GetNextSequence]
        /// </summary>
        public static class GetNextSequence
        {
            public static String ProcedureName => "[core].[usp_IdGenerator_GetNextSequence]";

            public static String ApplicationId => "ApplicationId";
            public static String UserProfileId => "UserProfileId";
            public static String SequenceName => "SequenceName";
        }

        /// <summary>
        /// [core].[usp_NonWorkingDays_GetWorkingDays]
        /// </summary>
        public static class GetWorkingDays
        {
            public static String ProcedureName => "[core].[usp_NonWorkingDays_GetWorkingDays]";

            public static String StartDate => "StartDate";
            public static String EndDate => "EndDate";
        }

        /// <summary>
        /// [core].[usp_NonWorkingDays_GetWorkingDaysByMonth]
        /// </summary>
        public static class GetWorkingDaysByMonth
        {
            public static String ProcedureName => "[core].[usp_NonWorkingDays_GetWorkingDaysByMonth]";

            public static String StartDate => "StartDate";
            public static String EndDate => "EndDate";
        }

        /// <summary>
        /// [sec].[usp_UserProfile_LoadFromActiveDirectoryUsersFromStaging]
        /// </summary>
        public static class LoadFromActiveDirectoryUsersFromStaging
        {
            public static String ProcedureName => "[sec].[usp_UserProfile_LoadFromActiveDirectoryUsersFromStaging]";

            public static String LoggedOnUserProfileId => "LoggedOnUserProfileId";
        }
    }
}
