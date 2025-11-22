//-----------------------------------------------------------------------
// <copyright file="HeartbeatResultTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ReportsTests
{
    /// <summary>
    /// The Heartbeat Results Tests class
    /// </summary>
    [TestFixture]
    public class HeartbeatResultTests : UnitTestBase
    {
        /// <summary>
        /// This test exists to force developers to come to this class if there are any changes to the <see cref="ReportDefinition"/>
        /// </summary>
        [TestCase]
        public void Test_CountMembers()
        {
            // This test exists to ensure all the class are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetInstancePropertyInfosForType(typeof(HeartbeatResult));
            Int32 index = 0;

            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(HeartbeatResult.DateRun)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(HeartbeatResult.Version)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(HeartbeatResult.Success)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(HeartbeatResult.Logs)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestCase]
        public void Test_Constructor()
        {
            IHeartbeatResult obj = new HeartbeatResult(DateTimeService);

            Assert.That(obj.DateRun, Is.EqualTo(SystemDateTimeMs));
            Assert.That(obj.Version, Is.EqualTo(String.Empty));
            Assert.That(obj.Success, Is.EqualTo(false));
            Assert.That(obj.Logs.Count, Is.EqualTo(0));
        }

        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestCase]
        public void Test_Properties()
        {
            IHeartbeatResult obj = new HeartbeatResult(DateTimeService);
            obj.Version = "1.2.3.4.5.6";
            obj.Success = true;
            obj.Logs.Add("Entry 1");

            Assert.That(obj.DateRun, Is.EqualTo(SystemDateTimeMs));
            Assert.That(obj.Version, Is.EqualTo("1.2.3.4.5.6"));
            Assert.That(obj.Success, Is.EqualTo(true));
            Assert.That(obj.Logs.Count, Is.EqualTo(1));
            Assert.That(obj.Logs[0], Is.EqualTo("Entry 1"));
        }

        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestCase]
        public void Test_ToString()
        {
            IHeartbeatResult obj = new HeartbeatResult(DateTimeService);
            DateTime dateRun = DateTimeService.SystemUtcDateTimeNow;
            String version = "1.2.3.4.5.6";
            const Boolean success = true;
            String[] logEntries = ["Entry 1"];

            obj.Version = version;
            obj.Success = success;
            obj.Logs.Add(logEntries[0]);

            String expected = $"{dateRun:yyyy-MM-ddTHH:mm:ss.fff}. {version}. {success}. {String.Join(", ", logEntries)}";

            Assert.That(obj.ToString(), Is.EqualTo(expected));
        }
    }
}
