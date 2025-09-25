//-----------------------------------------------------------------------
// <copyright file="RootObjectTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;

using Newtonsoft.Json;

using Foundation.BusinessProcess.Core.NonWorkingDaySupport;
using Foundation.Resources;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.CoreTests.NonWorkingDaySupportTests
{
    /// <summary>
    /// Summary description for RootObjectTests
    /// </summary>
    [TestFixture]
    public class RootObjectTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructor()
        {
            RootObject rootObject = new RootObject();

            Assert.That(rootObject.EnglandAndWales, Is.EqualTo(null));
            Assert.That(rootObject.Scotland, Is.EqualTo(null));
            Assert.That(rootObject.NorthernIreland, Is.EqualTo(null));
        }

        [TestCase]
        public void Test_Properties()
        {
            UkNation englandAndWales = new UkNation { Division = "Division01", Events = { new BankHolidayEvent { Bunting = true, DateAsString = "2025-01-01", Notes = "Notes-01", Title = "Title-01" } } };
            UkNation scotland = new UkNation { Division = "Division02", Events = { new BankHolidayEvent { Bunting = true, DateAsString = "2025-02-02", Notes = "Notes-02", Title = "Title-02" } } };
            UkNation northernIreland = new UkNation { Division = "Division03", Events = { new BankHolidayEvent { Bunting = true, DateAsString = "2025-03-03", Notes = "Notes-03", Title = "Title-03" } } };

            RootObject rootObject = new RootObject
            {
                EnglandAndWales = englandAndWales,
                Scotland = scotland,
                NorthernIreland = northernIreland,
            };

            Assert.That(rootObject.EnglandAndWales, Is.EqualTo(englandAndWales));
            Test_Assert_UkNation(rootObject.EnglandAndWales, 1);

            Assert.That(rootObject.Scotland, Is.EqualTo(scotland));
            Test_Assert_UkNation(rootObject.Scotland, 2);

            Assert.That(rootObject.NorthernIreland, Is.EqualTo(northernIreland));
            Test_Assert_UkNation(rootObject.NorthernIreland, 3);
        }

        private void Test_Assert_UkNation(UkNation ukNation, Int32 index)
        {
            Assert.That(ukNation.Events.Count, Is.EqualTo(1));

            Assert.That(ukNation.Division, Is.EqualTo($"Division{index:D2}"));
            Assert.That(ukNation.Events[0].Bunting, Is.EqualTo(true));
            Assert.That(ukNation.Events[0].DateAsString, Is.EqualTo($"2025-{index:D2}-{index:D2}"));
            Assert.That(ukNation.Events[0].Notes, Is.EqualTo($"Notes-{index:D2}"));
            Assert.That(ukNation.Events[0].Title, Is.EqualTo($"Title-{index:D2}"));
        }

        [TestCase]
        [DeploymentItem(@".Support\SampleDocuments\bank-holidays.json", @".Support\SampleDocuments\")]
        public void Test_ParseBankHolidayData()
        {
            String sourceFile = @".Support\SampleDocuments\bank-holidays.json";
            String sourceData = File.ReadAllText(sourceFile);

            RootObject? rootObject = JsonConvert.DeserializeObject<RootObject>(sourceData);

            Assert.That(rootObject, Is.Not.Null);
            Assert.That(rootObject.EnglandAndWales, Is.Not.Null);
            Assert.That(rootObject.Scotland, Is.Not.Null);
            Assert.That(rootObject.NorthernIreland, Is.Not.Null);

            Debug.WriteLine("England and Wales");
            foreach (BankHolidayEvent holidayEvent in rootObject.EnglandAndWales.Events)
            {
                Debug.WriteLine($"{holidayEvent.BankHolidayDate.ToString(Formats.DotNet.DateOnly)} - {holidayEvent.DateAsString} - {holidayEvent.Title} - {holidayEvent.Notes}");
            }

            Debug.WriteLine("Scotland");
            foreach (BankHolidayEvent holidayEvent in rootObject.Scotland.Events)
            {
                Debug.WriteLine($"{holidayEvent.BankHolidayDate.ToString(Formats.DotNet.DateOnly)} - {holidayEvent.DateAsString} - {holidayEvent.Title} - {holidayEvent.Notes}");
            }

            Debug.WriteLine("Northern Ireland");
            foreach (BankHolidayEvent holidayEvent in rootObject.NorthernIreland.Events)
            {
                Debug.WriteLine($"{holidayEvent.BankHolidayDate.ToString(Formats.DotNet.DateOnly)} - {holidayEvent.DateAsString} - {holidayEvent.Title} - {holidayEvent.Notes}");
            }
        }
    }
}
