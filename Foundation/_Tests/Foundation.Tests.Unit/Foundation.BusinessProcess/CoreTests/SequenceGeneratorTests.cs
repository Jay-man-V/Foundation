//-----------------------------------------------------------------------
// <copyright file="SequenceGeneratorTests.cs" company="JDV Software Ltd">
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
    /// Summary description for DepartmentProcessTests
    /// </summary>
    [TestFixture]
    public class SequenceGeneratorTests : CommonBusinessProcessTests<ISequenceGenerator, ISequenceGeneratorProcess, ISequenceGeneratorRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 10;
        protected override String ExpectedScreenTitle => "Id Generator";
        protected override String ExpectedStatusBarText => "Number of Ids:";

        protected override string ExpectedComboBoxDisplayMember => FDC.SequenceGenerator.SequenceName;

        protected override ISequenceGeneratorRepository CreateRepository()
        {
            ISequenceGeneratorRepository retVal = Substitute.For<ISequenceGeneratorRepository>();

            retVal.HasValidityPeriodColumns.Returns(false);

            return retVal;
        }

        protected override ISequenceGeneratorProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            ISequenceGeneratorProcess process = new SequenceGeneratorProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!);

            return process;
        }

        protected override ISequenceGenerator CreateBlankEntity(Int32 entityId)
        {
            ISequenceGenerator retVal = new FModels.SequenceGenerator();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override ISequenceGenerator CreateEntity(ISequenceGeneratorProcess process, Int32 entityId)
        {
            ISequenceGenerator retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;
            retVal.LastUpdatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.ApplicationId = new AppId(1);
            retVal.ConfigurationScopeId = new EntityId(1);
            retVal.SequenceName = Guid.NewGuid().ToString();
            retVal.LastId = entityId * entityId;
            retVal.ResetOnNewDate = true;

            return retVal;
        }

        protected override void CheckBlankEntry(ISequenceGenerator entity)
        {
            Assert.That(entity.SequenceName, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(ISequenceGenerator entity)
        {
            Assert.That(entity.SequenceName, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(ISequenceGenerator entity)
        {
            Assert.That(entity.SequenceName, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(ISequenceGenerator entity1, ISequenceGenerator entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.ApplicationId, Is.EqualTo(entity1.ApplicationId));
            Assert.That(entity2.ConfigurationScopeId, Is.EqualTo(entity1.ConfigurationScopeId));
            Assert.That(entity2.SequenceName, Is.EqualTo(entity1.SequenceName));
            Assert.That(entity2.LastId, Is.EqualTo(entity1.LastId));
            Assert.That(entity2.ResetOnNewDate, Is.EqualTo(entity1.ResetOnNewDate));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Application Id,Configuration Scope,Sequence Name,Last Id,Reset On New Date" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,1,1,d664612a-057c-4c29-8604-d64b9e027927,1,True" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,1,1,be76624c-83f3-4470-9ce4-76bdcbf64106,4,True" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,1,1,e1ba7ccb-a62d-4c37-a515-cf60c311b5e7,9,True" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,1,1,e5932cf8-e08d-401e-a7ea-e722f09fc93e,16,True" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,1,1,504e949b-b2a2-4ab6-bdc3-4155d9cabe09,25,True" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,1,1,fd5d9a32-da79-405d-8848-8cd4d4f3d004,36,True" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,1,1,ca3d977b-0ee2-4c90-8d9e-d84262a531d0,49,True" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,1,1,4d8dcdb4-3a5e-4055-a252-313f2df585a1,64,True" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,1,1,35392374-d1cc-4797-ab64-30970bc91de4,81,True" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,1,1,f758fa56-3ce4-4233-9d96-b2f0064e20b1,100,True" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(ISequenceGenerator entity)
        {
            entity.SequenceName += "Updated";
            entity.LastId += entity.LastId;
        }
    }
}
