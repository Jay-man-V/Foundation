//-----------------------------------------------------------------------
// <copyright file="FoundationPropertyChangingEventArgsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Common;

namespace Foundation.Tests.Unit.Foundation.Common
{
    /// <summary>
    /// Unit Tests for the Foundation Property Changing Event Args class
    /// </summary>
    [TestFixture]
    public class FoundationPropertyChangingEventArgsTests
    {
        [TestCase]
        public void Test_Constructor()
        {
            FoundationPropertyChangingEventArgs foundationPropertyChangingEventArgs = new FoundationPropertyChangingEventArgs("propertyName", "oldValue", "newValue");

            Assert.That(foundationPropertyChangingEventArgs, Is.InstanceOf<FoundationPropertyEventArgs>());
            Assert.That(foundationPropertyChangingEventArgs, Is.InstanceOf<FoundationPropertyChangingEventArgs>());

            Assert.That(foundationPropertyChangingEventArgs.PropertyName, Is.EqualTo("propertyName"));
            Assert.That(foundationPropertyChangingEventArgs.OldValue, Is.EqualTo("oldValue"));
            Assert.That(foundationPropertyChangingEventArgs.NewValue, Is.EqualTo("newValue"));
            Assert.That(foundationPropertyChangingEventArgs.Cancel, Is.EqualTo(false));

            foundationPropertyChangingEventArgs.Cancel = true;
            Assert.That(foundationPropertyChangingEventArgs.Cancel, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_CountMembers()
        {
            // This test exists to ensure all the Properties are tested/checked in the next test
            Type theType = typeof(FoundationPropertyChangingEventArgs);
            PropertyInfo[] propertyInfos = theType.GetProperties();

            Assert.That(propertyInfos.Length, Is.EqualTo(4));
            Assert.That(propertyInfos[0].Name, Is.EqualTo("Cancel"));
            Assert.That(propertyInfos[1].Name, Is.EqualTo("PropertyName"));
            Assert.That(propertyInfos[2].Name, Is.EqualTo("OldValue"));
            Assert.That(propertyInfos[3].Name, Is.EqualTo("NewValue"));
        }
    }
}
