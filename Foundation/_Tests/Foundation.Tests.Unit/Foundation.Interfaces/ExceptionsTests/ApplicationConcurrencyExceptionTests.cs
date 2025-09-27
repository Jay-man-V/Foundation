//-----------------------------------------------------------------------
// <copyright file="ApplicationConcurrencyExceptionTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;
using Foundation.Resources;

using Foundation.Tests.Unit.BaseClasses;
using Foundation.Tests.Unit.Mocks;

namespace Foundation.Tests.Unit.Foundation.Interfaces.ExceptionsTests
{
    /// <summary>
    /// The ApplicationConcurrencyException Tests
    /// </summary>
    [TestFixture]
    public class ApplicationConcurrencyExceptionTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructor_1()
        {
            EntityId entityId = new EntityId(1234);
            String entityName = "Unit Testing Entity Name";
            String tableName = "Unit testing table name";
            DateTime lastUpdatedOn = new DateTime(2019, 11, 23, 21, 5, 0);
            IFoundationModel unitTestEntity = new MockFoundationModel(DateTimeService);
            unitTestEntity.LastUpdatedOn = lastUpdatedOn;

            String errorMessage = $"Unable to update record. It may have been updated by someone else since it was loaded. Record Id: '{entityId}', Name: '{entityName}', Table: '{tableName}'";

            ApplicationConcurrencyException exception = new ApplicationConcurrencyException(entityId, entityName, tableName, unitTestEntity);

            Assert.That(exception.EntityId, Is.EqualTo(entityId));
            Assert.That(exception.EntityName, Is.EqualTo(entityName));
            Assert.That(exception.TableName, Is.EqualTo(tableName));
            Assert.That(exception.LastUpdatedBy, Is.EqualTo("<unknown>"));
            Assert.That(exception.LastUpdatedOn, Is.EqualTo(DateTime.MinValue));
            Assert.That(exception.LastSavedEntity, Is.EqualTo(unitTestEntity));

            Assert.That(exception.Message, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_Constructor_2()
        {
            EntityId entityId = new EntityId(1234);
            String entityName = "Unit Testing Entity Name";
            String tableName = "Unit testing table name";
            String lastUpdatedBy = @"GANYMEDE\Jayesh";
            DateTime lastUpdatedOn = new DateTime(2019, 11, 23, 21, 5, 0);
            IFoundationModel unitTestEntity = new MockFoundationModel(DateTimeService);
            unitTestEntity.LastUpdatedOn = lastUpdatedOn;

            String errorMessage = $"Unable to update record. It may have been updated by someone else since it was loaded. Record Id: '{entityId}', Name: '{entityName}', Table: '{tableName}', Last saved by: '{lastUpdatedBy}', Last saved time: '{unitTestEntity.LastUpdatedOn.ToString(Formats.DotNet.DateTimeSeconds)}'";

            ApplicationConcurrencyException exception = new ApplicationConcurrencyException(entityId, entityName, tableName, lastUpdatedBy, lastUpdatedOn, unitTestEntity);

            Assert.That(exception.EntityId, Is.EqualTo(entityId));
            Assert.That(exception.EntityName, Is.EqualTo(entityName));
            Assert.That(exception.TableName, Is.EqualTo(tableName));
            Assert.That(exception.LastUpdatedBy, Is.EqualTo(lastUpdatedBy));
            Assert.That(exception.LastUpdatedOn, Is.EqualTo(lastUpdatedOn));
            Assert.That(exception.LastSavedEntity, Is.EqualTo(unitTestEntity));

            Assert.That(exception.Message, Is.EqualTo(errorMessage));
        }
    }
}
