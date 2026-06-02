//-----------------------------------------------------------------------
// <copyright file="ResultColumns.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Repository.Sql
{
    /// <summary>
    /// Function Names
    /// </summary>
    public abstract class ResultColumns
    {
        /// <summary>
        /// GetFirstAndLastWorkingDaysOfMonth.sql
        /// </summary>
        public static class GetFirstAndLastWorkingDaysOfMonth
        {
            public static String Filename => "GetFirstAndLastWorkingDaysOfMonth.sql";

            public class Columns
            {
                /// <summary>
                /// FirstWorkingDayOfMonth
                /// </summary>
                public static String FirstWorkingDayOfMonth => "FirstWorkingDayOfMonth";

                /// <summary>
                /// LastWorkingDayOfMonth
                /// </summary>
                public static String LastWorkingDayOfMonth => "LastWorkingDayOfMonth";
            }
        }
    }
}
