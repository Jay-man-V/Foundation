//-----------------------------------------------------------------------
// <copyright file="FileTransferSettingsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Net;
using System.Reflection;

using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.SettingsTests
{
    /// <summary>
    /// The File Transfer Settings Tests class
    /// </summary>
    [TestFixture]
    public class FileTransferSettingsTests : UnitTestBase
    {
        /// <summary>
        /// This test exists to force developers to come to this class if there are any changes to the <see cref="FileTransferSettings"/>
        /// </summary>
        [TestCase]
        public void Test_CountBaseMembers()
        {
            // This test exists to ensure all the classes are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetInstancePropertyInfosForType(typeof(FileTransferSettings));
            Int32 index = 0;

            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(FileTransferSettings.FileTransferMethod)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(FileTransferSettings.Location)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(FileTransferSettings.Credentials)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        /// Tests the Constructor.
        /// </summary>
        [TestCase]
        public void Test_Constructor()
        {
            IFileTransferSettings obj = new FileTransferSettings();

            Assert.That(obj.FileTransferMethod, Is.EqualTo(FileTransferMethod.NotSet));
            Assert.That(obj.Location, Is.EqualTo(String.Empty));
            Assert.That(obj.Credentials, Is.EqualTo(null));
        }

        /// <summary>
        /// Tests the Properties.
        /// </summary>
        [TestCase]
        public void Test_Properties()
        {
            FileTransferMethod fileTransferType = FileTransferMethod.Rest;
            String location = Guid.NewGuid().ToString();
            ICredentials credentials = new NetworkCredential(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

            IFileTransferSettings obj = new FileTransferSettings
            {
                FileTransferMethod = fileTransferType,
                Location = location,
                Credentials = credentials,
            };

            Assert.That(obj.FileTransferMethod, Is.EqualTo(fileTransferType));
            Assert.That(obj.Location, Is.EqualTo(location));
            Assert.That(obj.Credentials, Is.EqualTo(credentials));
        }
    }
}
