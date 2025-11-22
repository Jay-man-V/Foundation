//-----------------------------------------------------------------------
// <copyright file="ReportRunRequestTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ReportsTests
{
    /// <summary>
    /// The Report Run Request Tests class
    /// </summary>
    [TestFixture]
    public class ReportRunRequestTests : UnitTestBase
    {
        /// <summary>
        /// This test exists to force developers to come to this class if there are any changes to the <see cref="ReportRunRequest"/>
        /// </summary>
        [TestCase]
        public void Test_CountMembers()
        {
            // This test exists to ensure all the class are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetInstancePropertyInfosForType(typeof(ReportRunRequest));
            Int32 index = 0;

            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ReportRunRequest.ReportName)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ReportRunRequest.ParameterValues)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        /// Tests the Constructor.
        /// </summary>
        [TestCase]
        public void Test_Constructor()
        {
            String reportName = Guid.NewGuid().ToString();
            ReportRunRequest obj = new ReportRunRequest(reportName);

            Assert.That(obj.ReportName, Is.EqualTo(reportName));
            Assert.That(obj.ParameterValues.Count, Is.EqualTo(0));
        }

        /// <summary>
        /// Tests the Properties.
        /// </summary>
        [TestCase]
        public void Test_Properties()
        {
            String reportName = Guid.NewGuid().ToString();

            ReportRunRequest obj = new ReportRunRequest(reportName);

            Assert.That(obj.ReportName, Is.EqualTo(reportName));
            Assert.That(obj.ParameterValues.Count, Is.EqualTo(0));

            obj.AddParameterValue("P1", 1);
            obj.AddParameterValue("P2", 2);
            obj.AddParameterValue("P3", 3);

            Assert.That(obj.ParameterValues.Count, Is.EqualTo(3));

            Assert.That(obj.ParameterValues["P1"], Is.EqualTo(1));
            Assert.That(obj.ParameterValues["P2"], Is.EqualTo(2));
            Assert.That(obj.ParameterValues["P3"], Is.EqualTo(3));
        }
    }
}
