//-----------------------------------------------------------------------
// <copyright file="UnableToReadNewIdentityExceptionTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;
using Foundation.Tests.Unit.Mocks;

namespace Foundation.Tests.Unit.Foundation.Common.ExceptionsTests
{
    /// <summary>
    /// The UnableToReadNewIdentityException Tests
    /// </summary>
    [TestFixture]
    public class UnableToReadNewIdentityExceptionTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructor_1()
        {
            String entityName = "Unit Testing Entity Name";
            String tableName = "Unit testing table name";
            IFoundationModel unitTestEntity = new MockFoundationModel();
            unitTestEntity.LastUpdatedOn = new DateTime(2019, 11, 23, 21, 5, 0);

            String errorMessage = $"Unable to read the details of the newly created record. Record Name: '{entityName}', Table: '{tableName}'";

            UnableToReadNewIdentityException exception = new UnableToReadNewIdentityException(entityName, tableName, unitTestEntity);

            Assert.That(exception.EntityName, Is.EqualTo(entityName));
            Assert.That(exception.TableName, Is.EqualTo(tableName));
            Assert.That(exception.FoundationModel, Is.EqualTo(unitTestEntity));

            Assert.That(exception.Message, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_Constructor_2()
        {
            String entityName = "Unit Testing Entity Name";
            String tableName = "Unit testing table name";

            String errorMessage = $@"Unable to read the details of the newly created record. Record Name: '{entityName}', Table: '{tableName}'";

            UnableToReadNewIdentityException exception = new UnableToReadNewIdentityException(entityName, tableName);

            Assert.That(exception.EntityName, Is.EqualTo(entityName));
            Assert.That(exception.TableName, Is.EqualTo(tableName));

            Assert.That(exception.Message, Is.EqualTo(errorMessage));
        }
    }
}
