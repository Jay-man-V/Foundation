//-----------------------------------------------------------------------
// <copyright file="EventTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.BusinessProcess.Core.NonWorkingDaySupport;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.CoreTests.NonWorkingDaySupportTests
{
    /// <summary>
    /// Summary description for BankHolidayEvent
    /// </summary>
    [TestFixture]
    public class BankHolidayEventTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructor()
        {
            BankHolidayEvent bakBankHolidayEvent = new BankHolidayEvent();

            Assert.That(bakBankHolidayEvent.Title, Is.EqualTo(String.Empty));
            Assert.That(bakBankHolidayEvent.DateAsString, Is.EqualTo(DateTime.MinValue.ToString("yyyy-MM-dd")));
            Assert.That(bakBankHolidayEvent.BankHolidayDate, Is.EqualTo(DateTime.MinValue));
            Assert.That(bakBankHolidayEvent.Notes, Is.EqualTo(String.Empty));
            Assert.That(bakBankHolidayEvent.Bunting, Is.EqualTo(false));
        }

        [TestCase]
        public void Test_Properties()
        {
            String expectedTitle = Guid.NewGuid().ToString();
            DateTime expectedDateTime = new DateTime(2023, 01, 14);
            String expectedDateAsString = expectedDateTime.ToString("yyyy-MM-dd");
            String expectedNotes = Guid.NewGuid().ToString();
            const Boolean expectedBunting = true;

            BankHolidayEvent bakBankHolidayEvent = new BankHolidayEvent()
            {
                Title = expectedTitle,
                DateAsString = expectedDateAsString,
                Notes = expectedNotes,
                Bunting = expectedBunting,
            };

            Assert.That(bakBankHolidayEvent.Title, Is.EqualTo(expectedTitle));
            Assert.That(bakBankHolidayEvent.DateAsString, Is.EqualTo(expectedDateAsString));
            Assert.That(bakBankHolidayEvent.BankHolidayDate, Is.EqualTo(expectedDateTime));
            Assert.That(bakBankHolidayEvent.Notes, Is.EqualTo(expectedNotes));
            Assert.That(bakBankHolidayEvent.Bunting, Is.EqualTo(expectedBunting));
        }
    }
}
