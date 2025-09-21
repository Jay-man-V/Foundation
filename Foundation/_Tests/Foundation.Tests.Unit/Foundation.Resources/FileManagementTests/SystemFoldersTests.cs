//-----------------------------------------------------------------------
// <copyright file="SystemFoldersTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Resources;
using Foundation.Tests.Unit.Support;

using System.Reflection;

namespace Foundation.Tests.Unit.Foundation.Resources.FileManagementTests
{
    /// <summary>
    /// Unit Tests for the System Folders class
    /// </summary>
    [TestFixture]
    public class SystemFoldersTests : UnitTestBase
    {
        /// <summary>
        /// This test exists to force developers to come to this class if there are any changes to the <see cref="SystemFolders"/>
        /// </summary>
        [TestCase]
        public void Test_CountMembers()
        {
            IEnumerable<MethodInfo> testMethods = GetListOfTestMethods();
            Int32 testMethodCount = testMethods.Count() - 1;

            // This test exists to ensure all the Properties are tested/checked in the next test
            Type theType = typeof(SystemFolders);
            PropertyInfo[] propertyInfos = theType.GetProperties();

            Assert.That(propertyInfos.Length, Is.EqualTo(testMethodCount));

            Int32 index = 0;
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(SystemFolders.TempDirectory)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        /// Tests the MyDocuments
        /// </summary>
        [TestCase]
        public void Test_TempDirectory()
        {
            String expected = @"C:\WINDOWS\TEMP";
            String actual = SystemFolders.TempDirectory;

            expected = ReplaceUserNameWithConstant(expected);
            actual = ReplaceUserNameWithConstant(actual);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
