//-----------------------------------------------------------------------
// <copyright file="ValueNotInLookupListExceptionTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;
using Foundation.Tests.Unit.Mocks;

namespace Foundation.Tests.Unit.Foundation.Interfaces.ExceptionsTests
{
    /// <summary>
    /// The ValueNotInLookupListException Tests
    /// </summary>
    [TestFixture]
    public class ValueNotInLookupListExceptionTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructor_1()
        {
            String sourceField = LocationUtils.GetFunctionName();
            String lookUpListName = LocationUtils.GetClassName();
            EntityId requestedId = new EntityId(1234);
            IFoundationModel sourceModel = new MockFoundationModel(); ;

            String errorMessage = $"Unable to locate '{sourceField}' in the list '{lookUpListName}' with Id '{requestedId}' for the Entity '{sourceModel.GetType()}':'{sourceModel.Id}'";

            ValueNotInLookupListException exception = new ValueNotInLookupListException(sourceField, lookUpListName, requestedId, sourceModel);

            Assert.That(exception.SourceField, Is.EqualTo(sourceField));
            Assert.That(exception.LookUpListName, Is.EqualTo(lookUpListName));
            Assert.That(exception.RequestedId, Is.EqualTo(requestedId));
            Assert.That(exception.SourceModel.GetType(), Is.EqualTo(sourceModel.GetType()));
            Assert.That(exception.SourceModel.Id, Is.EqualTo(sourceModel.Id));

            Assert.That(exception.Message, Is.EqualTo(errorMessage));
        }
    }
}
