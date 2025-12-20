//-----------------------------------------------------------------------
// <copyright file="UnknownEntityIdExceptionTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Interfaces.ExceptionsTests
{
    /// <summary>
    /// The UnknownEntityIdException Tests
    /// </summary>
    [TestFixture]
    public class UnknownEntityIdExceptionTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructor_AppId()
        {
            Type entityType = typeof(IApplication);
            AppId entityId = new AppId(123);
            String errorMessage = String.Format(UnknownEntityIdException.ErrorMessageTemplate1, entityType, entityId);

            UnknownEntityIdException exception = new UnknownEntityIdException(entityId);

            Assert.That(exception.Message, Is.EqualTo(errorMessage));
            Assert.That(exception.GetBaseException().Message, Is.EqualTo(errorMessage));
            Assert.That(exception.InnerException, Is.EqualTo(null));
            Assert.That(exception.EntityType, Is.EqualTo(entityType));
            Assert.That(exception.EntityId, Is.EqualTo(entityId.TheAppId));
        }

        [TestCase]
        public void Test_Constructor_LogId()
        {
            Type entityType = typeof(IEventLog);
            LogId entityId = new LogId(123);
            String errorMessage = String.Format(UnknownEntityIdException.ErrorMessageTemplate1, entityType, entityId);

            UnknownEntityIdException exception = new UnknownEntityIdException(entityId);

            Assert.That(exception.Message, Is.EqualTo(errorMessage));
            Assert.That(exception.GetBaseException().Message, Is.EqualTo(errorMessage));
            Assert.That(exception.InnerException, Is.EqualTo(null));
            Assert.That(exception.EntityType, Is.EqualTo(entityType));
            Assert.That(exception.EntityId, Is.EqualTo(entityId.TheLogId));
        }

        [TestCase]
        public void Test_Constructor_Generic()
        {
            Type entityType = typeof(IApplication);
            EntityId entityId = new EntityId(123);
            String errorMessage = String.Format(UnknownEntityIdException.ErrorMessageTemplate1, entityType, entityId);

            UnknownEntityIdException exception = new UnknownEntityIdException(entityType, entityId);

            Assert.That(exception.Message, Is.EqualTo(errorMessage));
            Assert.That(exception.GetBaseException().Message, Is.EqualTo(errorMessage));
            Assert.That(exception.InnerException, Is.EqualTo(null));
            Assert.That(exception.EntityType, Is.EqualTo(entityType));
            Assert.That(exception.EntityId, Is.EqualTo(entityId.TheEntityId));
        }
    }
}
