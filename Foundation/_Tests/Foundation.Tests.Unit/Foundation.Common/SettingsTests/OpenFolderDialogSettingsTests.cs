//-----------------------------------------------------------------------
// <copyright file="OpenFolderDialogSettingsTests.cs" company="JDV Software Ltd">
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
    public class OpenFolderDialogSettingsTests : UnitTestBase
    {
        /// <summary>
        /// This test exists to force developers to come to this class if there are any changes to the <see cref="OpenFolderDialogSettings"/>
        /// </summary>
        [TestCase]
        public void Test_CountMembers()
        {
            // This test exists to ensure all the classes are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetInstancePropertyInfosForType(typeof(OpenFolderDialogSettings));
            Int32 index = 0;

            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(OpenFolderDialogSettings.CheckPathExists)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(OpenFolderDialogSettings.CreatePrompt)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(OpenFolderDialogSettings.FolderName)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(OpenFolderDialogSettings.DialogResult)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestCase]
        public void Test_Constructor()
        {
            IOpenFolderDialogSettings obj = new OpenFolderDialogSettings();

            Assert.That(obj.CheckPathExists, Is.EqualTo(false));
            Assert.That(obj.CreatePrompt, Is.EqualTo(false));
            Assert.That(obj.FolderName, Is.EqualTo(String.Empty));
            Assert.That(obj.DialogResult, Is.EqualTo(DialogResult.NotSet));
        }

        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestCase]
        public void Test_Properties()
        {
            IOpenFolderDialogSettings obj = new OpenFolderDialogSettings
            {
                CheckPathExists = true,
                CreatePrompt = true,
                FolderName = @"D:\",
                DialogResult = DialogResult.Ok,
            };

            Assert.That(obj.CheckPathExists, Is.EqualTo(true));
            Assert.That(obj.CreatePrompt, Is.EqualTo(true));
            Assert.That(obj.FolderName, Is.EqualTo(@"D:\"));
            Assert.That(obj.DialogResult, Is.EqualTo(DialogResult.Ok));
        }
    }
}
