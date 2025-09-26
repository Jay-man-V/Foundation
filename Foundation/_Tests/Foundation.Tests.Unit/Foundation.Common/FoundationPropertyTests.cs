//-----------------------------------------------------------------------
// <copyright file="FoundationPropertyTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Common;

namespace Foundation.Tests.Unit.Foundation.Common
{
    /// <summary>
    /// Unit Tests for the Foundation Property class
    /// </summary>
    [TestFixture]
    public class FoundationPropertyTests
    {
        [TestCase]
        public void Test_Constructor()
        {
            FoundationProperty foundationProperty = new FoundationProperty("propertyName", "oldValue", "newValue");

            Assert.That(foundationProperty, Is.InstanceOf<FoundationProperty>());

            Assert.That(foundationProperty.PropertyName, Is.EqualTo("propertyName"));
            Assert.That(foundationProperty.OldValue, Is.EqualTo("oldValue"));
            Assert.That(foundationProperty.NewValue, Is.EqualTo("newValue"));
        }

        [TestCase]
        public void Test_CountMembers()
        {
            // This test exists to ensure all the Properties are tested/checked in the next test
            Type theType = typeof(FoundationProperty);
            PropertyInfo[] propertyInfos = theType.GetProperties();

            Assert.That(propertyInfos.Length, Is.EqualTo(3));
            Assert.That(propertyInfos[0].Name, Is.EqualTo("PropertyName"));
            Assert.That(propertyInfos[1].Name, Is.EqualTo("OldValue"));
            Assert.That(propertyInfos[2].Name, Is.EqualTo("NewValue"));
        }

        [TestCase]
        public void Test_Clone()
        {
            FoundationProperty foundationPropertyObject = new FoundationProperty("propertyName", "oldValue", "newValue");
            FoundationProperty foundationPropertyClone = (FoundationProperty)foundationPropertyObject.Clone();

            Assert.That(foundationPropertyObject, Is.Not.EqualTo(foundationPropertyClone));

            Assert.That(foundationPropertyObject.PropertyName, Is.EqualTo(foundationPropertyClone.PropertyName));
            Assert.That(foundationPropertyObject.OldValue, Is.EqualTo(foundationPropertyClone.OldValue));
            Assert.That(foundationPropertyObject.NewValue, Is.EqualTo(foundationPropertyClone.NewValue));
        }
    }
}
