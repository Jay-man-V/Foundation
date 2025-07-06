//-----------------------------------------------------------------------
// <copyright file="FunctionNames.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Common.DataColumns
{
    /// <summary>
    /// Function Names
    /// </summary>
    public abstract class FunctionNames
    {
        /// <summary>
        /// [dbo].[ufn_CheckIsWorkingDayOrGetNextWorkingDay]
        /// </summary>
        public static String CheckIsWorkingDayOrGetNextWorkingDay => "[dbo].[ufn_CheckIsWorkingDayOrGetNextWorkingDay]";

        /// <summary>
        /// [dbo].[ufn_GetNextWorkingDay]
        /// </summary>
        public static String GetNextWorkingDay => "[dbo].[ufn_GetNextWorkingDay]";

        /// <summary>
        /// [dbo].[ufn_IsNonWorkingDay]
        /// </summary>
        public static String IsNonWorkingDay => "[dbo].[ufn_IsNonWorkingDay]";

        /// <summary>
        /// [dbo].[ufn_GetListOfActiveStatuses]
        /// </summary>
        public static String GetListOfActiveStatuses => "[dbo].[ufn_GetListOfActiveStatuses]";

        /// <summary>
        /// [dbo].[ufn_GetListOfCalendarDates]
        /// </summary>
        public static String GetListOfCalendarDates => "[dbo].[ufn_GetListOfCalendarDates]";

        /// <summary>
        /// [dbo].[ufn_GetListOfWorkingDates]
        /// </summary>
        public static String GetListOfWorkingDates => "[dbo].[ufn_GetListOfWorkingDates]";
    }
}
