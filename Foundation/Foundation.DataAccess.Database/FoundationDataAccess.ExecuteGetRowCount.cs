//-----------------------------------------------------------------------
// <copyright file="FoundationDataAccess.ExecuteGetRowCount.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.DataAccess.Database
{
    /// <summary>
    /// Defines the FoundationDataAccess class
    /// </summary>
    public partial class FoundationDataAccess
    {
        /// <inheritdoc cref="IFoundationDataAccess.ExecuteGetRowCount(String, CommandType, IDatabaseParameters)"/>
        public Int32 ExecuteGetRowCount(String sql, CommandType commandType = CommandType.Text, IDatabaseParameters? databaseParameters = null)
        {
            LoggingHelpers.TraceCallEnter();

            Object result = ExecuteNonQuery(sql, commandType, databaseParameters);

            Int32 retVal = DataHelpers.GetValue(result, -1);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
