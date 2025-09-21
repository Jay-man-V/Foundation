//-----------------------------------------------------------------------
// <copyright file="GridColumnTemplateNamesTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Resources;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Resources.ConstantsTests
{
    /// <summary>
    /// Unit Tests for the Grid Column Template Names class
    /// </summary>
    [TestFixture]
    public class GridColumnTemplateNamesTests : UnitTestBase
    {
        /// <summary>
        /// This test exists to force developers to come to this class if there are any changes to the <see cref="GridColumnTemplateNames"/>
        /// </summary>
        [TestCase]
        public void Test_CountMembers()
        {
            // This test exists to ensure all the class members are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(GridColumnTemplateNames));
            Int32 index = 0;

            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(GridColumnTemplateNames.DateTimeColumnTemplate)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(GridColumnTemplateNames.DefaultColumnTemplate)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(GridColumnTemplateNames.DropDownBoxColumnTemplate)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(GridColumnTemplateNames.ImageColumnTemplate)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(GridColumnTemplateNames.ImageDropDownBoxColumnTemplate)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(GridColumnTemplateNames.NumericColumnTemplate)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(GridColumnTemplateNames.YesNoColumnTemplate)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        /// Verify that the keys contain the values expected
        /// </summary>
        [TestCase]
        public void Test_Keys()
        {
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(GridColumnTemplateNames));
            Int32 index = 0;

            index++; Assert.That(GridColumnTemplateNames.DateTimeColumnTemplate, Is.EqualTo(nameof(GridColumnTemplateNames.DateTimeColumnTemplate)));
            index++; Assert.That(GridColumnTemplateNames.DefaultColumnTemplate, Is.EqualTo(nameof(GridColumnTemplateNames.DefaultColumnTemplate)));
            index++; Assert.That(GridColumnTemplateNames.DropDownBoxColumnTemplate, Is.EqualTo(nameof(GridColumnTemplateNames.DropDownBoxColumnTemplate)));
            index++; Assert.That(GridColumnTemplateNames.ImageColumnTemplate, Is.EqualTo(nameof(GridColumnTemplateNames.ImageColumnTemplate)));
            index++; Assert.That(GridColumnTemplateNames.ImageDropDownBoxColumnTemplate, Is.EqualTo(nameof(GridColumnTemplateNames.ImageDropDownBoxColumnTemplate)));
            index++; Assert.That(GridColumnTemplateNames.NumericColumnTemplate, Is.EqualTo(nameof(GridColumnTemplateNames.NumericColumnTemplate)));
            index++; Assert.That(GridColumnTemplateNames.YesNoColumnTemplate, Is.EqualTo(nameof(GridColumnTemplateNames.YesNoColumnTemplate)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }
    }
}
