//-----------------------------------------------------------------------
// <copyright file="BulkDataLoadSettingsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.DataAccess.Database;

using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.DataAccess.Database
{
    /// <summary>
    /// BulkDataLoadSettingsTests
    /// </summary>
    /// <see cref="UnitTestBase" />
    [TestFixture]
    public class BulkDataLoadSettingsTests : UnitTestBase
    {
        /// <summary>
        /// Tests the properties of the BulkDataLoadSettings class.
        /// </summary>
        [TestCase]
        public void Test_Properties()
        {
            String expectedDestinationTable = Guid.NewGuid().ToString();
            String expectedProcedureName = Guid.NewGuid().ToString();
            String expectedSourceFilePath = Guid.NewGuid().ToString();

            IBulkDataLoadSettings bulkDataLoadSettings = new BulkDataLoadSettings
            {
                DestinationTable = expectedDestinationTable,
                ProcedureName = expectedProcedureName,
                SourceFilePath = expectedSourceFilePath
            };

            Assert.That(bulkDataLoadSettings.DataLoadParameters, Is.Empty);
            Assert.That(bulkDataLoadSettings.DataLoadParameters, Is.Not.Null);

            Assert.That(bulkDataLoadSettings.SourceFilePath, Is.EqualTo(expectedSourceFilePath));
            Assert.That(bulkDataLoadSettings.ProcedureName, Is.EqualTo(expectedProcedureName));
        }

        [TestCase]
        public void Test_Clone()
        {
            String expectedDestinationTable = Guid.NewGuid().ToString();
            String expectedProcedureName = Guid.NewGuid().ToString();
            String expectedSourceFilePath = Guid.NewGuid().ToString();

            BulkDataLoadSettings bulkDataLoadSettings = new BulkDataLoadSettings
            {
                DestinationTable = expectedDestinationTable,
                ProcedureName = expectedProcedureName,
                SourceFilePath = expectedSourceFilePath
            };

            BulkDataLoadSettings cloned = (BulkDataLoadSettings)bulkDataLoadSettings.Clone();

            Assert.That(cloned.DataLoadParameters, Is.Empty);
            Assert.That(cloned.DataLoadParameters, Is.Not.Null);

            Assert.That(cloned.DestinationTable, Is.EqualTo(expectedDestinationTable));
            Assert.That(cloned.ProcedureName, Is.EqualTo(expectedProcedureName));
            Assert.That(cloned.SourceFilePath, Is.EqualTo(expectedSourceFilePath));

            bulkDataLoadSettings.DestinationTable = Guid.NewGuid().ToString();
            bulkDataLoadSettings.ProcedureName = Guid.NewGuid().ToString();
            bulkDataLoadSettings.SourceFilePath = Guid.NewGuid().ToString();

            Assert.That(cloned.DestinationTable, Is.Not.EqualTo(bulkDataLoadSettings.DestinationTable));
            Assert.That(cloned.ProcedureName, Is.Not.EqualTo(bulkDataLoadSettings.ProcedureName));
            Assert.That(cloned.SourceFilePath, Is.Not.EqualTo(bulkDataLoadSettings.SourceFilePath));
        }
    }
}
