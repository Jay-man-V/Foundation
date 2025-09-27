//-----------------------------------------------------------------------
// <copyright file="FoundationPropertyChangedEventArgsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common
{
    /// <summary>
    /// Unit Tests for the Foundation Property Changed Event Args class
    /// </summary>
    [TestFixture]
    public class FoundationPropertyChangedEventArgsTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructor()
        {
            FoundationPropertyChangedEventArgs foundationPropertyChangedEventArgs = new FoundationPropertyChangedEventArgs("propertyName", "oldValue", "newValue");

            Assert.That(foundationPropertyChangedEventArgs, Is.InstanceOf<FoundationPropertyEventArgs>());
            Assert.That(foundationPropertyChangedEventArgs, Is.InstanceOf<FoundationPropertyChangedEventArgs>());

            Assert.That(foundationPropertyChangedEventArgs.PropertyName, Is.EqualTo("propertyName"));
            Assert.That(foundationPropertyChangedEventArgs.OldValue, Is.EqualTo("oldValue"));
            Assert.That(foundationPropertyChangedEventArgs.NewValue, Is.EqualTo("newValue"));
        }

        [TestCase]
        public void Test_CountMembers()
        {
            // This test exists to ensure all the Properties are tested/checked in the next test
            Type theType = typeof(FoundationPropertyChangedEventArgs);
            PropertyInfo[] propertyInfos = theType.GetProperties();

            Assert.That(propertyInfos.Length, Is.EqualTo(3));
            Assert.That(propertyInfos[0].Name, Is.EqualTo("PropertyName"));
            Assert.That(propertyInfos[1].Name, Is.EqualTo("OldValue"));
            Assert.That(propertyInfos[2].Name, Is.EqualTo("NewValue"));
        }
    }
}
