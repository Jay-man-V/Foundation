//-----------------------------------------------------------------------
// <copyright file="SaveFileDialogSettingsTests.cs" company="JDV Software Ltd">
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
    /// The Save File Dialog Settings Tests class
    /// </summary>
    [TestFixture]
    public class SaveFileDialogSettingsTests : UnitTestBase
    {
        /// <summary>
        /// This test exists to force developers to come to this class if there are any changes to the <see cref="SaveFileDialogSettings"/>
        /// </summary>
        [TestCase]
        public void Test_CountMembers()
        {
            // This test exists to ensure all the classes are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetInstancePropertyInfosForType(typeof(SaveFileDialogSettings));
            Int32 index = 0;

            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(SaveFileDialogSettings.CheckPathExists)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(SaveFileDialogSettings.CreatePrompt)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(SaveFileDialogSettings.DefaultExtension)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(SaveFileDialogSettings.Filter)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(SaveFileDialogSettings.FilterIndex)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(SaveFileDialogSettings.OverwritePrompt)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(SaveFileDialogSettings.FileName)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(SaveFileDialogSettings.DialogResult)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestCase]
        public void Test_Constructor()
        {
            ISaveFileDialogSettings obj = new SaveFileDialogSettings();

            Assert.That(obj.CheckPathExists, Is.EqualTo(false));
            Assert.That(obj.CreatePrompt, Is.EqualTo(false));
            Assert.That(obj.DefaultExtension, Is.EqualTo(String.Empty));
            Assert.That(obj.Filter, Is.EqualTo(String.Empty));
            Assert.That(obj.FilterIndex, Is.EqualTo(0));
            Assert.That(obj.OverwritePrompt, Is.EqualTo(false));
            Assert.That(obj.FileName, Is.EqualTo(String.Empty));
            Assert.That(obj.DialogResult, Is.EqualTo(DialogResult.None));
        }

        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestCase]
        public void Test_Properties()
        {
            ISaveFileDialogSettings obj = new SaveFileDialogSettings
            {
                CheckPathExists = true,
                CreatePrompt = true,
                DefaultExtension = "DefaultExtension",
                Filter = "Filter",
                FilterIndex = 1,
                OverwritePrompt = true,
                FileName = "Filename",
                DialogResult = DialogResult.Ok,
            };

            Assert.That(obj.CheckPathExists, Is.EqualTo(true));
            Assert.That(obj.CreatePrompt, Is.EqualTo(true));
            Assert.That(obj.DefaultExtension, Is.EqualTo("DefaultExtension"));
            Assert.That(obj.Filter, Is.EqualTo("Filter"));
            Assert.That(obj.FilterIndex, Is.EqualTo(1));
            Assert.That(obj.OverwritePrompt, Is.EqualTo(true));
            Assert.That(obj.FileName, Is.EqualTo("Filename"));
            Assert.That(obj.DialogResult, Is.EqualTo(DialogResult.Ok));
        }
    }
}
