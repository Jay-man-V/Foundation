//-----------------------------------------------------------------------
// <copyright file="MessageBoxSettingsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.SettingsTests
{
    /// <summary>
    /// The Message Box Settings Tests class
    /// </summary>
    [TestFixture]
    public class MessageBoxSettingsTests : UnitTestBase
    {
        /// <summary>
        /// This test exists to force developers to come to this class if there are any changes to the <see cref="MessageBoxSettings"/>
        /// </summary>
        [TestCase]
        public void Test_CountMembers()
        {
            // This test exists to ensure all the classes are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetInstancePropertyInfosForType(typeof(MessageBoxSettings));
            Int32 index = 0;

            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(MessageBoxSettings.Button)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(MessageBoxSettings.Caption)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(MessageBoxSettings.Icon)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(MessageBoxSettings.Text)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestCase]
        public void Test_Constructor()
        {
            IMessageBoxSettings obj = new MessageBoxSettings();

            Assert.That(obj.Button, Is.EqualTo(MessageBoxButton.NotSet));
            Assert.That(obj.Caption, Is.EqualTo(String.Empty));
            Assert.That(obj.Icon, Is.EqualTo(MessageBoxImage.None));
            Assert.That(obj.Text, Is.EqualTo(String.Empty));
        }

        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestCase]
        public void Test_Properties()
        {
            IMessageBoxSettings obj = new MessageBoxSettings
            {
                Button = MessageBoxButton.Ok,
                Caption = "Caption",
                Icon = MessageBoxImage.Asterisk,
                Text = "Text",
            };

            Assert.That(obj.Button, Is.EqualTo(MessageBoxButton.Ok));
            Assert.That(obj.Caption, Is.EqualTo("Caption"));
            Assert.That(obj.Icon, Is.EqualTo(MessageBoxImage.Asterisk));
            Assert.That(obj.Text, Is.EqualTo("Text"));
        }
    }
}
