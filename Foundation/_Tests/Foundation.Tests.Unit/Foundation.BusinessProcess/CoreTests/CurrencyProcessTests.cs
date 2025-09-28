//-----------------------------------------------------------------------
// <copyright file="CurrencyProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Core;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;
using FModels = Foundation.Models.Core;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.CoreTests
{
    /// <summary>
    /// Summary description for CurrencyProcessTests
    /// </summary>
    [TestFixture]
    public class CurrencyProcessTests : CommonBusinessProcessTests<ICurrency, ICurrencyProcess, ICurrencyRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 13;
        protected override String ExpectedScreenTitle => "Currencies";
        protected override String ExpectedStatusBarText => "Number of Currencies:";

        protected override string ExpectedComboBoxDisplayMember => FDC.Currency.IsoCode;

        protected override ICurrencyRepository CreateRepository()
        {
            ICurrencyRepository dataAccess = Substitute.For<ICurrencyRepository>();

            return dataAccess;
        }

        protected override ICurrencyProcess CreateBusinessProcess()
        {
            ICurrencyProcess process = CreateBusinessProcess(DateTimeService);

            return process;
        }

        protected override ICurrencyProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            ICurrencyProcess process = new CurrencyProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!);

            return process;
        }

        protected override ICurrency CreateBlankEntity(ICurrencyProcess process, Int32 entityId)
        {
            ICurrency retVal = new FModels.Currency();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override ICurrency CreateEntity(ICurrencyProcess process, Int32 entityId)
        {
            ICurrency retVal = CreateBlankEntity(process, entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;
            retVal.LastUpdatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Name = Guid.NewGuid().ToString();
            retVal.IsoCode = $"IsoCode{entityId:D3}";
            retVal.IsoNumber = $"Prefix{entityId:D4}";
            retVal.Symbol = $"Sym{entityId:D2}";
            retVal.NumberToBasic = 10;
            retVal.PrefixSymbol = true;

            return retVal;
        }

        protected override void CheckBlankEntry(ICurrency entity)
        {
            Assert.That(entity.IsoCode, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(ICurrency entity)
        {
            Assert.That(entity.IsoCode, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(ICurrency entity)
        {
            Assert.That(entity.IsoCode, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(ICurrency entity1, ICurrency entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.Name, Is.EqualTo(entity1.Name));
            Assert.That(entity2.IsoCode, Is.EqualTo(entity1.IsoCode));
            Assert.That(entity2.IsoNumber, Is.EqualTo(entity1.IsoNumber));
            Assert.That(entity2.Symbol, Is.EqualTo(entity1.Symbol));
            Assert.That(entity2.NumberToBasic, Is.EqualTo(entity1.NumberToBasic));
            Assert.That(entity2.PrefixSymbol, Is.EqualTo(entity1.PrefixSymbol));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,ISO Code,ISO Number,Symbol,Prefix Symbol,Name,Number to Basic" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,IsoCode001,Prefix0001,Sym01,True,ab3db463-78e3-4b8c-84c1-f11ffb8b407a,10" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,IsoCode002,Prefix0002,Sym02,True,60fbd628-fa34-4940-a9a5-bbf089cd7700,10" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,IsoCode003,Prefix0003,Sym03,True,5777a553-eb62-410e-b55e-64b5db10b34b,10" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,IsoCode004,Prefix0004,Sym04,True,ec91a3b7-a4ca-4a0b-ad1c-57f43c5e2709,10" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,IsoCode005,Prefix0005,Sym05,True,3bb01220-a655-4b39-bcb9-1ec221eeb22d,10" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,IsoCode006,Prefix0006,Sym06,True,39231e77-d53c-4c39-a1c5-b09a5cfdcbfc,10" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,IsoCode007,Prefix0007,Sym07,True,492ff974-db62-4624-b2d5-dbdbb217e5e9,10" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,IsoCode008,Prefix0008,Sym08,True,92ee383a-6105-4b5a-bcc0-1b8802dd1649,10" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,IsoCode009,Prefix0009,Sym09,True,7e226507-9a5b-4feb-9a7e-db44dfebe78d,10" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,IsoCode010,Prefix0010,Sym10,True,f455c023-5384-45aa-8174-110b696532eb,10" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(ICurrency entity)
        {
            entity.Name += "Updated";
            entity.IsoCode += "Updated";
        }
    }
}
