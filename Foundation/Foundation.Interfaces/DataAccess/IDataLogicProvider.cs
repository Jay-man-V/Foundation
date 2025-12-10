//-----------------------------------------------------------------------
// <copyright file="IDataLogicProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Interface that should be implemented by Data Logic Providers
    /// </summary>
    public interface IDataLogicProvider
    {
        /// <summary>
        /// The name of the database provider
        /// </summary>
        String DatabaseProviderName { get; }

        /// <summary>
        /// The DefaultValidToDateTime as a String for use in the database
        /// </summary>
        String ValidToDateString { get; }

        /// <summary>
        /// The prefix used by the Database for Parameters
        /// </summary>
        String DatabaseParameterPrefix { get; }

        /// <summary>
        /// The function to retrieve the Identity of the last row
        /// </summary>
        String IdentityOfLastInsertFunction { get; }

        /// <summary>
        /// The Sql to retrieve the Identity and Timestamp of a newly added row
        /// </summary>
        String IdentityOfNewRowSql { get; }

        /// <summary>
        /// The Sql to retrieve the Timestamp of the updated row
        /// </summary>
        String TimestampOfUpdatedRowSql { get; }

        /// <summary>
        /// The Database function to get the current Date/Time
        /// </summary>
        String CurrentDateTimeFunction { get; }

        /// <summary>
        /// The Database function to generate a Unique Identifier
        /// </summary>
        String UniqueIdFunction { get; }

        /// <summary>
        /// Maps the <paramref name="dbType" /> to its equivalent Dot Net type
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        Type MapDbTypeToDotNetType(String dbType);

        /// <summary>
        /// The Sql to get the row version
        /// </summary>
        /// <returns></returns>
        Object GetRowVersionValue();

        /// <summary>
        /// The Sql to compare two Date/Time values
        /// </summary>
        /// <param name="column1">The first Date/Time column</param>
        /// <param name="column2">The second Date/Time column</param>
        /// <param name="comparisonResult">The comparison result to be looked for</param>
        /// <returns></returns>
        String GetDateComparisonSql(String column1, String column2, String comparisonResult);

        /// <summary>
        /// The Sql to compare two Time values
        /// </summary>
        /// <param name="column1">The first Date/Time column</param>
        /// <param name="column2">The second Date/Time column</param>
        /// <param name="comparisonResult">The comparison result to be looked for</param>
        /// <returns></returns>
        String GetMinuteComparisonSql(String column1, String column2, String comparisonResult);
    }
}
