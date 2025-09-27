//-----------------------------------------------------------------------
// <copyright file="FoundationPropertyEventArgsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common
{
    /// <summary>
    /// Unit Tests for the Foundation Property Event Args class
    /// </summary>
    [TestFixture]
    public class FoundationPropertyEventArgsTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructor()
        {
            FoundationPropertyEventArgs foundationPropertyEventArgs = new FoundationPropertyEventArgs("propertyName", "oldValue", "newValue");

            Assert.That(foundationPropertyEventArgs, Is.InstanceOf<FoundationPropertyEventArgs>());

            Assert.That(foundationPropertyEventArgs.PropertyName, Is.EqualTo("propertyName"));
            Assert.That(foundationPropertyEventArgs.OldValue, Is.EqualTo("oldValue"));
            Assert.That(foundationPropertyEventArgs.NewValue, Is.EqualTo("newValue"));
        }

        [TestCase]
        public void Test_CountMembers()
        {
            // This test exists to ensure all the Properties are tested/checked in the next test
            Type theType = typeof(FoundationPropertyEventArgs);
            PropertyInfo[] propertyInfos = theType.GetProperties();

            Assert.That(propertyInfos.Length, Is.EqualTo(3));
            Assert.That(propertyInfos[0].Name, Is.EqualTo("PropertyName"));
            Assert.That(propertyInfos[1].Name, Is.EqualTo("OldValue"));
            Assert.That(propertyInfos[2].Name, Is.EqualTo("NewValue"));
        }
    }
}
