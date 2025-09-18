//-----------------------------------------------------------------------
// <copyright file="TooManyRecordsUpdatedExceptionTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

using Foundation.Tests.Unit.Support;
using Foundation.Tests.Unit.Mocks;

namespace Foundation.Tests.Unit.Foundation.Interfaces.ExceptionsTests
{
    /// <summary>
    /// The TooManyRecordsUpdatedException Tests
    /// </summary>
    [TestFixture]
    public class TooManyRecordsUpdatedExceptionTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructor_1()
        {
            EntityId entityId = new(1234);
            String entityName = "Unit Testing Entity Name";
            String tableName = "Unit testing table name";
            IFoundationModel unitTestEntity = new MockFoundationModel();
            unitTestEntity.LastUpdatedOn = new DateTime(2019, 11, 23, 21, 5, 0);

            String errorMessage = $"Too many records updated. Too many records found matching this record. Record Id: '{entityId}', Name: '{entityName}', Table: '{tableName}'";

            TooManyRecordsUpdatedException exception = new TooManyRecordsUpdatedException(entityId, entityName, tableName, unitTestEntity);

            Assert.That(exception.EntityId, Is.EqualTo(entityId));
            Assert.That(exception.EntityName, Is.EqualTo(entityName));
            Assert.That(exception.TableName, Is.EqualTo(tableName));
            Assert.That(exception.FoundationModel, Is.EqualTo(unitTestEntity));

            Assert.That(exception.Message, Is.EqualTo(errorMessage));
        }
    }
}
