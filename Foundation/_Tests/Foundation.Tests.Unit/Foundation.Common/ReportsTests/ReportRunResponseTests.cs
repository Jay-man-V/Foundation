//-----------------------------------------------------------------------
// <copyright file="ReportRunResponseTests.cs" company="JDV Software Ltd">
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
    /// The Report Run Response Tests class
    /// </summary>
    [TestFixture]
    public class ReportRunResponseTests : UnitTestBase
    {
        /// <summary>
        /// This test exists to force developers to come to this class if there are any changes to the <see cref="ReportRunResponse"/>
        /// </summary>
        [TestCase]
        public void Test_CountMembers()
        {
            // This test exists to ensure all the class are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetInstancePropertyInfosForType(typeof(ReportRunResponse));
            Int32 index = 0;

            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ReportRunResponse.ReportRunRequest)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ReportRunResponse.ExecutionStartedOn)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ReportRunResponse.ExecutionFinishedOn)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ReportRunResponse.ReportData)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestCase]
        public void Test_Constructor()
        {
            String reportName = Guid.NewGuid().ToString();
            IReportRunRequest reportRunRequest = new ReportRunRequest(reportName);
            DateTime startedOn = DateTimeService.SystemUtcDateTimeNow;
            DateTime finishedOn = DateTimeService.SystemUtcDateTimeNow;
            List<String> reportData = ["A", "B", "C"];
            ReportRunResponse obj = new ReportRunResponse(reportRunRequest, startedOn, finishedOn, reportData);

            Assert.That(obj.ReportRunRequest, Is.EqualTo(reportRunRequest));
            Assert.That(obj.ExecutionStartedOn, Is.EqualTo(startedOn));
            Assert.That(obj.ExecutionFinishedOn, Is.EqualTo(finishedOn));
            Assert.That((List<String>)obj.ReportData, Is.EquivalentTo(reportData));
        }

        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestCase]
        public void Test_Properties()
        {
            String reportName = Guid.NewGuid().ToString();
            IReportRunRequest reportRunRequest = new ReportRunRequest(reportName);
            DateTime startedOn = DateTimeService.SystemUtcDateTimeNow;
            DateTime finishedOn = DateTimeService.SystemUtcDateTimeNow;
            List<String> reportData = ["A", "B", "C"];
            ReportRunResponse obj = new ReportRunResponse(reportRunRequest, startedOn, finishedOn, reportData);

            Assert.That(obj.ReportRunRequest, Is.EqualTo(reportRunRequest));
            Assert.That(obj.ExecutionStartedOn, Is.EqualTo(startedOn));
            Assert.That(obj.ExecutionFinishedOn, Is.EqualTo(finishedOn));
            Assert.That((List<String>)obj.ReportData, Is.EquivalentTo(reportData));
        }
    }
}
