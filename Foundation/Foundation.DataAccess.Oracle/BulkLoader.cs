//-----------------------------------------------------------------------
// <copyright file="BulkLoader.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.DataAccess.Oracle
{
    /// <summary>
    /// 
    /// </summary>
    public class BulkLoader : IFoundationBulkLoader
    {
        public BulkLoader
        (
            IFoundationDataAccess dataAccess
        )
        {
            LoggingHelpers.TraceCallEnter(dataAccess);

            DataAccess = dataAccess;

            LoggingHelpers.TraceCallReturn();
        }

        private IFoundationDataAccess DataAccess { get; }

        /// <inheritdoc cref="IFoundationBulkLoader.BulkDataLoad"/>
        public void BulkDataLoad(IBulkDataLoadSettings bulkDataLoadSettings)
        {
            LoggingHelpers.TraceCallEnter(bulkDataLoadSettings);

            throw new NotImplementedException();

            LoggingHelpers.TraceCallReturn();
        }
    }
}
