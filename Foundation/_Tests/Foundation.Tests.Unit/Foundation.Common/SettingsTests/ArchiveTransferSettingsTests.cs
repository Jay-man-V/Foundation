//-----------------------------------------------------------------------
// <copyright file="ArchiveTransferSettingsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Net;
using System.Reflection;

using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;
using Newtonsoft.Json;

namespace Foundation.Tests.Unit.Foundation.Common.SettingsTests
{
    /// <summary>
    /// The File Transfer Settings Tests class
    /// </summary>
    [TestFixture]
    public class ArchiveTransferSettingsTests : UnitTestBase
    {
        /// <summary>
        /// This test exists to force developers to come to this class if there are any changes to the <see cref="ArchiveTransferSettings"/>
        /// </summary>
        [TestCase]
        public void Test_CountBaseMembers()
        {
            // This test exists to ensure all the classes are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetInstancePropertyInfosForType(typeof(ArchiveTransferSettings));
            Int32 index = 0;

            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ArchiveTransferSettings.FileTransferArchiveAction)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ArchiveTransferSettings.DeleteSourceFile)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ArchiveTransferSettings.FileTransferMethod)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ArchiveTransferSettings.Location)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ArchiveTransferSettings.Credentials)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        /// Tests the Constructor.
        /// </summary>
        [TestCase]
        public void Test_Constructor()
        {
            IArchiveTransferSettings obj = new ArchiveTransferSettings();

            Assert.That(obj.FileTransferMethod, Is.EqualTo(FileTransferMethod.NotSet));
            Assert.That(obj.Location, Is.EqualTo(String.Empty));
            Assert.That(obj.Credentials, Is.EqualTo(null));
            Assert.That(obj.FileTransferArchiveAction, Is.EqualTo(FileTransferArchiveAction.NotSet));
            Assert.That(obj.DeleteSourceFile, Is.EqualTo(false));
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
            FileTransferArchiveAction fileTransferArchiveAction = FileTransferArchiveAction.Move;

            IArchiveTransferSettings obj = new ArchiveTransferSettings
            {
                FileTransferMethod = fileTransferType,
                Location = location,
                Credentials = credentials,
                FileTransferArchiveAction = FileTransferArchiveAction.Move,
                DeleteSourceFile = true,
            };

            String toString = JsonConvert.SerializeObject(obj);
            Assert.That(obj.ToString(), Is.EqualTo(toString));

            Assert.That(obj.FileTransferMethod, Is.EqualTo(fileTransferType));
            Assert.That(obj.Location, Is.EqualTo(location));
            Assert.That(obj.Credentials, Is.EqualTo(credentials));
            Assert.That(obj.FileTransferArchiveAction, Is.EqualTo(fileTransferArchiveAction));
            Assert.That(obj.DeleteSourceFile, Is.EqualTo(true));
        }
    }
}
