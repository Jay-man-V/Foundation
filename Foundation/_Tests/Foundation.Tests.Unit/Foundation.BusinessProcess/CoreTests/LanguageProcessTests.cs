//-----------------------------------------------------------------------
// <copyright file="LanguageProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Core;
using Foundation.Interfaces;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;

using FDC = Foundation.Resources.Constants.DataColumns;
using FModels = Foundation.Models.Core;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.CoreTests
{
    /// <summary>
    /// Summary description for LanguageProcessTests
    /// </summary>
    [TestFixture]
    public class LanguageProcessTests : CommonBusinessProcessTests<ILanguage, ILanguageProcess, ILanguageRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 11;
        protected override String ExpectedScreenTitle => "Languages";
        protected override String ExpectedStatusBarText => "Number of Languages:";

        protected override String ExpectedComboBoxDisplayMember => FDC.Language.EnglishName;

        protected override ILanguageRepository CreateRepository()
        {
            ILanguageRepository retVal = Substitute.For<ILanguageRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override ILanguageProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            ILanguageProcess process = new LanguageProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!);

            return process;
        }

        protected override ILanguage CreateBlankEntity(Int32 entityId)
        {
            ILanguage retVal = new FModels.Language();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override ILanguage CreateEntity(ILanguageProcess process, Int32 entityId)
        {
            ILanguage retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;
            retVal.LastUpdatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.EnglishName = Guid.NewGuid().ToString();
            retVal.NativeName = Guid.NewGuid().ToString();
            retVal.CultureCode = $"Culture{entityId:D3}";
            retVal.UiCultureCode = $"UiCode{entityId:D4}";

            return retVal;
        }

        protected override void CheckBlankEntry(ILanguage entity)
        {
            Assert.That(entity.EnglishName, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(ILanguage entity)
        {
            Assert.That(entity.EnglishName, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(ILanguage entity)
        {
            Assert.That(entity.EnglishName, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(ILanguage entity1, ILanguage entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.EnglishName, Is.EqualTo(entity1.EnglishName));
            Assert.That(entity2.NativeName, Is.EqualTo(entity1.NativeName));
            Assert.That(entity2.CultureCode, Is.EqualTo(entity1.CultureCode));
            Assert.That(entity2.UiCultureCode, Is.EqualTo(entity1.UiCultureCode));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,English Name,Native Name,Culture Code,UI Culture Code" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,fec599db-b4a0-4c10-aca2-160faf117e05,843f6ac9-29cd-4933-a4b2-ebb9b1b42006,Culture001,UiCode0001" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,65c9518e-003a-4a87-8d04-beaa7bcf770c,06ae4abe-632f-4e96-9902-4559a0d0e2ce,Culture002,UiCode0002" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,f5ac08c8-de7e-44c6-a61f-9006f8cfb264,e5c38f27-84b8-44b6-bce8-6a480b73aecc,Culture003,UiCode0003" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,6ca68be4-378e-4bda-88c3-944c126af419,cd0bd0ca-6911-450b-9eb6-1d35eafaa760,Culture004,UiCode0004" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,d48c508d-d57f-4080-b4de-b4bdc0fee6b4,63ccd89f-e6e8-429d-97a5-443e933ec712,Culture005,UiCode0005" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,e4f5d0d7-b145-43e2-9dad-25a49d73cbc0,112bafe2-7244-4c28-b329-89443360931a,Culture006,UiCode0006" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1fe29880-1126-4682-b28d-3bc2151c121f,c764cdbe-d62d-49f0-bd6d-760240e95349,Culture007,UiCode0007" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,49b820c0-1e4b-4779-b864-29bfb00860a3,bde05553-3186-431a-b025-ac773e6ecbd7,Culture008,UiCode0008" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,6d45237a-30d7-4b26-b334-7e1a1f9dfc6a,fba2e0ee-e6c5-4fec-96f6-dcdd983b30ae,Culture009,UiCode0009" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,406e0fd6-a751-4223-98e5-44a1cc5c0105,f6bc60f4-5996-496f-9d07-6f75dde4cdb1,Culture010,UiCode0010" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(ILanguage entity)
        {
            entity.EnglishName += "Updated";
            entity.NativeName += "Updated";
            entity.CultureCode = "Updated";
            entity.UiCultureCode = "Updated";
        }
    }
}
