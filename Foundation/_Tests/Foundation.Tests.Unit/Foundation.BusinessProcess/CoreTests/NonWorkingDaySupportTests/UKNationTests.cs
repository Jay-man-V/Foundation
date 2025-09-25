//-----------------------------------------------------------------------
// <copyright file="UkNationTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.BusinessProcess.Core.NonWorkingDaySupport;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.CoreTests.NonWorkingDaySupportTests
{
    /// <summary>
    /// Summary description for UKNationTests
    /// </summary>
    [TestFixture]
    public class UkNationTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructor()
        {
            UkNation englandAndWales = new UkNation();

            Assert.That(englandAndWales.Division, Is.EqualTo(String.Empty));
            Assert.That(englandAndWales.Events, Is.Not.EqualTo(null));
            Assert.That(englandAndWales.Events.Count, Is.EqualTo(0));
        }

        [TestCase]
        public void Test_Properties()
        {
            String expectedDivision = Guid.NewGuid().ToString();
            BankHolidayEvent expectedEvent = new BankHolidayEvent();

            UkNation ukNation = new UkNation
            {
                Division = expectedDivision,
            };

            ukNation.Events.Add(expectedEvent);

            Assert.That(ukNation.Division, Is.EqualTo(expectedDivision));
            Assert.That(ukNation.Events.Count, Is.EqualTo(1));
            Assert.That(ukNation.Events[0], Is.EqualTo(expectedEvent));
        }
    }
}
