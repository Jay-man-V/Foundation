//-----------------------------------------------------------------------
// <copyright file="TimeZonesTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Resources;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Resources.ConstantsTests
{
    /// <summary>
    /// Unit Tests for the Time Zones Tests class
    /// </summary>
    [TestFixture]
    public class TimeZonesTests : UnitTestBase
    {
        /// <summary>
        /// This test exists to force developers to come to this class if there are any changes to the <see cref="TimeZones"/>
        /// </summary>
        [TestCase]
        public void Test_AllMembers()
        {
            // This test exists to ensure all the class members are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(TimeZones));
            Int32 index = 0;

            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(TimeZones.EasternStandardTime)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(TimeZones.Utc)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(TimeZones.GmtStandardTime)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(TimeZones.GreenwichStandardTime)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(TimeZones.CentralEuropeStandardTime)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(TimeZones.CentralEuropeanStandardTime)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_Keys()
        {
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(TimeZones));
            Int32 index = 0;

            index++; Assert.That(TimeZones.EasternStandardTime, Is.EqualTo("Eastern Standard Time"));
            index++; Assert.That(TimeZones.Utc, Is.EqualTo("UTC"));
            index++; Assert.That(TimeZones.GmtStandardTime, Is.EqualTo("GMT Standard Time"));
            index++; Assert.That(TimeZones.GreenwichStandardTime, Is.EqualTo("Greenwich Standard Time"));
            index++; Assert.That(TimeZones.CentralEuropeStandardTime, Is.EqualTo("Central Europe Standard Time"));
            index++; Assert.That(TimeZones.CentralEuropeanStandardTime, Is.EqualTo("Central European Standard Time"));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }
    }
}
