//-----------------------------------------------------------------------
// <copyright file="ReportDefinitionTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Reflection;

using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ReportsTests
{
    /// <summary>
    /// The Report Definition Tests class
    /// </summary>
    [TestFixture]
    public class ReportDefinitionTests : UnitTestBase
    {
        /// <summary>
        /// This test exists to force developers to come to this class if there are any changes to the <see cref="ReportDefinition"/>
        /// </summary>
        [TestCase]
        public void Test_CountMembers()
        {
            // This test exists to ensure all the class are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetInstancePropertyInfosForType(typeof(ReportDefinition));
            Int32 index = 0;

            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ReportDefinition.Title)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ReportDefinition.SubTitle)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ReportDefinition.PageHeader)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ReportDefinition.PageFooter)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ReportDefinition.GeneratedOn)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ReportDefinition.RequestedBy)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ReportDefinition.Columns)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ReportDefinition.DataSource)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestCase]
        public void Test_Constructor()
        {
            IReportDefinition obj = new ReportDefinition(DateTimeService);

            Assert.That(obj.Title, Is.EqualTo(String.Empty));
            Assert.That(obj.SubTitle, Is.EqualTo(String.Empty));
            Assert.That(obj.PageHeader, Is.EqualTo(String.Empty));
            Assert.That(obj.PageFooter, Is.EqualTo(String.Empty));
            Assert.That(obj.RequestedBy, Is.EqualTo(String.Empty));
            Assert.That(obj.Columns, Is.Not.EqualTo(null));
            Assert.That(obj.DataSource, Is.EqualTo(null));
        }

        /// <summary>
        /// Tests the method1.
        /// </summary>
        [TestCase]
        public void Test_Properties()
        {
            DateTime generatedOn = new DateTime(2022, 08, 07, 23, 33, 12, 345);
            DataTable dataSource = new DataTable();

            IReportDefinition obj = new ReportDefinition(DateTimeService)
            {
                Title = "Title",
                SubTitle = "SubTitle",
                PageHeader = "PageHeader",
                PageFooter = "PageFooter",
                RequestedBy = "RequestedBy",
                GeneratedOn = generatedOn,
                DataSource = dataSource,
            };

            Assert.That(obj.Title, Is.EqualTo("Title"));
            Assert.That(obj.SubTitle, Is.EqualTo("SubTitle"));
            Assert.That(obj.PageHeader, Is.EqualTo("PageHeader"));
            Assert.That(obj.PageFooter, Is.EqualTo("PageFooter"));
            Assert.That(obj.RequestedBy, Is.EqualTo("RequestedBy"));
            Assert.That(obj.GeneratedOn, Is.EqualTo(generatedOn));
            Assert.That(obj.DataSource, Is.EqualTo(dataSource));
        }
    }
}
