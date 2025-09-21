//-----------------------------------------------------------------------
// <copyright file="ReportTemplatesTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Resources;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Resources
{
    /// <summary>
    /// Unit Tests for the Report Templates class
    /// </summary>
    [TestFixture]
    public class ReportTemplatesTests : UnitTestBase
    {
        [TestCase]
        public void Test_CountMembers()
        {
            IEnumerable<MethodInfo> testMethods = GetListOfTestMethods();
            Int32 testMethodCount = testMethods.Count();

            // This test exists to ensure all the Properties are tested/checked in the next test
            List<PropertyInfo> allPropertyInfos = [];

            Type parentType = typeof(ResourceNames);
            Type[] nestedTypes = parentType.GetNestedTypes();

            foreach (Type nestedType in nestedTypes)
            {
                PropertyInfo[] propertyInfos = nestedType.GetProperties();
                allPropertyInfos.AddRange(propertyInfos);
            }

            Assert.That(allPropertyInfos.Count, Is.EqualTo(testMethodCount - 1));

            Int32 index = 0;
            Assert.That(allPropertyInfos[index++].Name, Is.EqualTo(nameof(ResourceNames.EMailTemplates.FormalEmailTemplate)));
            Assert.That(allPropertyInfos[index++].Name, Is.EqualTo(nameof(ResourceNames.ReportTemplates.ExcelSimpleReportTemplateLandscape)));
            Assert.That(allPropertyInfos[index++].Name, Is.EqualTo(nameof(ResourceNames.ReportTemplates.ExcelSimpleReportTemplatePortrait)));
            Assert.That(allPropertyInfos[index++].Name, Is.EqualTo(nameof(ResourceNames.Logos.CompanyLogo)));

            Assert.That(allPropertyInfos.Count, Is.EqualTo(index));
        }

        [TestCase]
        public void Test_EmailTemplate_FormalEmail()
        {
            String expected = "Foundation.Resources.EmailTemplates.Formal Template.html";

            String actual = ResourceNames.EMailTemplates.FormalEmailTemplate;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_ReportTemplate_ExcelSimpleReportLandscape()
        {
            String expected = @"ReportTemplates\Excel Simple Report Template - Landscape.xltx";

            String actual = ResourceNames.ReportTemplates.ExcelSimpleReportTemplateLandscape;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_ReportTemplate_ExcelSimpleReportPortrait()
        {
            String expected = @"ReportTemplates\Excel Simple Report Template - Portrait.xltx";

            String actual = ResourceNames.ReportTemplates.ExcelSimpleReportTemplatePortrait;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Logos_CompanyLogo()
        {
            String expected = @"Foundation.Resources.Images.Logos.JDV Software Logo.png";

            String actual = ResourceNames.Logos.CompanyLogo;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
