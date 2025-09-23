//-----------------------------------------------------------------------
// <copyright file="FunctionNames.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Repository
{
    /// <summary>
    /// Function Names
    /// </summary>
    public abstract class Functions
    {
        /// <summary>
        /// [dbo].[ufn_CheckIsWorkingDayOrGetNextWorkingDay]
        /// </summary>
        public static class CheckIsWorkingDayOrGetNextWorkingDay
        {
            public static String FunctionName => "[dbo].[ufn_CheckIsWorkingDayOrGetNextWorkingDay]";

            public class Parameters
            {
                public static String StartDate => "startDate";
            }
        }

        /// <summary>
        /// [dbo].[ufn_GetNextWorkingDay]
        /// </summary>
        public static class GetNextWorkingDay
        {
            public static String FunctionName => "[dbo].[ufn_GetNextWorkingDay]";

            public class Parameters
            {
                public static String StartDate => "startDate";
                public static String IntervalType => "intervalType";
                public static String Interval => "interval";
            }
        }


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
        public static class GetListOfWorkingDates
        {
            public static String FunctionName => "[dbo].[ufn_GetListOfWorkingDates]";

            public static class Parameters
            {
                public static String StartDate => "startDate";
                public static String EndDate => "endDate";
            }

            public static class Columns
            {
                public static String Date => "Date";
                public static String DayOfWeekIndex => "DayOfWeekIndex";
                public static String DayOfWeek => "DayOfWeek";
            }
        }
    }
}
