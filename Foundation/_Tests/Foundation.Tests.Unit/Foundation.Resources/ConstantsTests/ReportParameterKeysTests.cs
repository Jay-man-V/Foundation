//-----------------------------------------------------------------------
// <copyright file="ReportParameterKeysTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Resources;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Resources.ConstantsTests
{
    /// <summary>
    /// Unit Tests for the Report Parameter Keys class
    /// </summary>
    [TestFixture]
    public class ReportParameterKeysTests : UnitTestBase
    {
        /// <summary>
        /// This test exists to force developers to come to this class if there are any changes to the <see cref="ReportParameterKeys"/>
        /// </summary>
        [TestCase]
        public void Test_AllMembers()
        {
            // This test exists to ensure all the class members are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(ReportParameterKeys));
            Int32 index = 0;

            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ReportParameterKeys.StartDateTime)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ReportParameterKeys.EndDateTime)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ReportParameterKeys.Parameter1)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ReportParameterKeys.Parameter2)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ReportParameterKeys.Parameter3)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ReportParameterKeys.Parameter4)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ReportParameterKeys.Parameter5)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        /// Verify that the keys contain the values expected
        /// </summary>
        [TestCase]
        public void Test_Keys()
        {
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(ReportParameterKeys));
            Int32 index = 0;

            index++; Assert.That(ReportParameterKeys.StartDateTime, Is.EqualTo(nameof(ReportParameterKeys.StartDateTime)));
            index++; Assert.That(ReportParameterKeys.EndDateTime, Is.EqualTo(nameof(ReportParameterKeys.EndDateTime)));
            index++; Assert.That(ReportParameterKeys.Parameter1, Is.EqualTo(nameof(ReportParameterKeys.Parameter1)));
            index++; Assert.That(ReportParameterKeys.Parameter2, Is.EqualTo(nameof(ReportParameterKeys.Parameter2)));
            index++; Assert.That(ReportParameterKeys.Parameter3, Is.EqualTo(nameof(ReportParameterKeys.Parameter3)));
            index++; Assert.That(ReportParameterKeys.Parameter4, Is.EqualTo(nameof(ReportParameterKeys.Parameter4)));
            index++; Assert.That(ReportParameterKeys.Parameter5, Is.EqualTo(nameof(ReportParameterKeys.Parameter5)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }
    }
}
