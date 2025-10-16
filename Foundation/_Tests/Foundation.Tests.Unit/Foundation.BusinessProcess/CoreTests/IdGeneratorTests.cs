//-----------------------------------------------------------------------
// <copyright file="IdGeneratorTests.cs" company="JDV Software Ltd">
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
    public class IdGeneratorTests : CommonBusinessProcessTests<IIdGenerator, IIdGeneratorProcess, IIdGeneratorRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 10;
        protected override String ExpectedScreenTitle => "Id Generator";
        protected override String ExpectedStatusBarText => "Number of Ids:";

        protected override string ExpectedComboBoxDisplayMember => FDC.IdGenerator.IdName;

        protected override IIdGeneratorRepository CreateRepository()
        {
            IIdGeneratorRepository retVal = Substitute.For<IIdGeneratorRepository>();

            retVal.HasValidityPeriodColumns.Returns(false);

            return retVal;
        }

        protected override IIdGeneratorProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IIdGeneratorProcess process = new IdGeneratorProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!);

            return process;
        }

        protected override IIdGenerator CreateBlankEntity(Int32 entityId)
        {
            IIdGenerator retVal = new FModels.IdGenerator();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IIdGenerator CreateEntity(IIdGeneratorProcess process, Int32 entityId)
        {
            IIdGenerator retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;
            retVal.LastUpdatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.ApplicationId = new AppId(1);
            retVal.ConfigurationScopeId = new EntityId(1);
            retVal.IdName = Guid.NewGuid().ToString();
            retVal.LastId = entityId * entityId;
            retVal.ResetOnNewDate = true;

            return retVal;
        }

        protected override void CheckBlankEntry(IIdGenerator entity)
        {
            Assert.That(entity.IdName, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IIdGenerator entity)
        {
            Assert.That(entity.IdName, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IIdGenerator entity)
        {
            Assert.That(entity.IdName, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IIdGenerator entity1, IIdGenerator entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.ApplicationId, Is.EqualTo(entity1.ApplicationId));
            Assert.That(entity2.ConfigurationScopeId, Is.EqualTo(entity1.ConfigurationScopeId));
            Assert.That(entity2.IdName, Is.EqualTo(entity1.IdName));
            Assert.That(entity2.LastId, Is.EqualTo(entity1.LastId));
            Assert.That(entity2.ResetOnNewDate, Is.EqualTo(entity1.ResetOnNewDate));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Application Id,Configuration Scope,Id Name,Last Id,Reset On New Date" + Environment.NewLine;
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

        protected override void UpdateEntityProperties(IIdGenerator entity)
        {
            entity.IdName += "Updated";
            entity.LastId += entity.LastId;
        }
    }
}
