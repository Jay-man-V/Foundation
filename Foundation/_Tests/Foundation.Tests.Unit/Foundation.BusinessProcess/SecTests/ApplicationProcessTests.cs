//-----------------------------------------------------------------------
// <copyright file="ApplicationProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Sec;
using Foundation.Interfaces;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;

using FDC = Foundation.Resources.Constants.DataColumns;
using FModels = Foundation.Models.Sec;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.SecTests
{
    /// <summary>
    /// Summary description for ApplicationProcessTests
    /// </summary>
    [TestFixture]
    public class ApplicationProcessTests : CommonBusinessProcessTests<IApplication, IApplicationProcess, IApplicationDataAccess>
    {
        protected override Int32 ColumnDefinitionsCount => 9;
        protected override String ExpectedScreenTitle => "Applications";
        protected override String ExpectedStatusBarText => "Number of Applications:";

        protected override String ExpectedComboBoxDisplayMember => FDC.Application.Name;

        protected override IApplicationDataAccess CreateRepository()
        {
            IApplicationDataAccess retVal = Substitute.For<IApplicationDataAccess>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override IApplicationProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IApplicationProcess process = new ApplicationProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!);

            return process;
        }

        protected override IApplication CreateBlankEntity(Int32 entityId)
        {
            IApplication retVal = new FModels.Application();

            retVal.Id = new AppId(entityId);

            return retVal;
        }

        protected override IApplication CreateEntity(IApplicationProcess process, Int32 entityId)
        {
            IApplication retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IApplication entity)
        {
            Assert.That(entity.Name, Is.EqualTo(String.Empty));
            Assert.That(entity.Description, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IApplication entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IApplication entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityBaseProperties_Id(IApplication expectedEntity, IApplication actualEntity)
        {
            Assert.That(actualEntity.Id, Is.EqualTo(expectedEntity.Id));
        }

        protected override void Test_NullId(IApplicationProcess process)
        {
            Assert.That(process.NullId, Is.EqualTo(new AppId(ExpectedNullId.TheEntityId)));
        }

        protected override void Test_AllId(IApplicationProcess process)
        {
            Assert.That(process.AllId, Is.EqualTo(new AppId(ExpectedAllId.TheEntityId)));
        }

        protected override void Test_NoneId(IApplicationProcess process)
        {
            Assert.That(process.NoneId, Is.EqualTo(new AppId(ExpectedNoneId.TheEntityId)));
        }

        protected override void CompareEntityProperties(IApplication entity1, IApplication entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.Name, Is.EqualTo(entity1.Name));
            Assert.That(entity2.Description, Is.EqualTo(entity1.Description));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Name,Description" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,f58b2ffc-0427-4216-a58f-a1906c87df2f,6729563a-f7f9-46df-b63e-6263ab37a84b" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,b00e031b-3483-41e0-95d6-af098e93a5df,d03b600e-b3e9-4c66-bb70-e32f042efb78" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,7d7ac469-b694-4ffb-9494-aaef4ed6c4ed,d8dea494-298a-4bd7-a5d8-06243ce472ea" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,c72efec7-a08d-4ea0-9753-4ec581964156,9f2ebb28-6da4-45d9-8454-bd96ee41839a" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,578f43e7-bb56-42d3-8158-b506f7c98df4,08c8b376-2577-48eb-87a9-c92061229b02" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,60f86d5c-ba9f-443e-8689-8ffcfd2d12bc,ba9b8bc2-ad58-4128-aeeb-4e16afa0a4a2" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,e70cf9c3-0e56-4df4-8fd7-0206005e9591,77877bc4-55e7-46a8-bf38-b1987dfd2c4f" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,81e35bbd-98b9-49ec-b604-55177815c9f3,c2848fd5-f4e8-4811-8944-5885c4e76724" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,39acef10-300c-405e-b33e-e94957e0f18d,00cd1b3e-bed4-4602-ac54-194d9974044a" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,80ed4250-1252-40ee-a028-5df652b8f89f,d49ecced-cd48-48bc-b453-bad8938cd3f7" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IApplication entity)
        {
            entity.Name += "Updated";
            entity.Description += "Updated";
        }

        [TestCase]
        public override void Test_Delete_Entity_Id()
        {
            IApplication entity1 = CreateEntity(TheProcess!, 1);

            TheRepository!.Save(Arg.Is(entity1)).Returns(args =>
            {
                IApplication retVal = (IApplication)args[0];
                retVal.Id = new AppId(1);
                retVal.EntityState = EntityState.Saved;
                return retVal;
            });

            IApplication savedEntity = TheProcess!.Save(entity1);

            TheRepository!.Get(Arg.Is(savedEntity.Id)).Returns(_ =>
            {
                IApplication retVal = (IApplication)savedEntity.Clone();
                retVal.Id = new AppId(1);
                retVal.EntityLife = EntityLife.Deleted;
                retVal.EntityState = EntityState.Saved;
                retVal.EntityStatus = EntityStatus.Inactive;
                return retVal;
            });

            IApplication loadedEntity1 = TheProcess!.Get(savedEntity.Id)!;
            TheProcess!.Delete(loadedEntity1.Id);

            IApplication loadedEntity2 = TheProcess!.Get(entity1.Id)!;

            Assert.That(loadedEntity2.EntityLife, Is.EqualTo(EntityLife.Deleted));
            Assert.That(loadedEntity2.EntityState, Is.EqualTo(EntityState.Saved));
            Assert.That(loadedEntity2.EntityStatus, Is.EqualTo(EntityStatus.Inactive));
            Assert.That(savedEntity == (Object)loadedEntity2, Is.EqualTo(false));
        }

        [TestCase]
        public override void Test_Delete_Entity_Object()
        {
            IApplication entity1 = CreateEntity(TheProcess!, 1);

            TheRepository!.Save(Arg.Is(entity1)).Returns(args =>
            {
                IApplication retVal = (IApplication)args[0];
                retVal.Id = new AppId(1);
                retVal.EntityState = EntityState.Saved;
                return retVal;
            });

            IApplication savedEntity = TheProcess!.Save(entity1);

            TheRepository!.Get(Arg.Is(savedEntity.Id)).Returns(_ =>
            {
                IApplication retVal = (IApplication)savedEntity.Clone();
                retVal.Id = new AppId(1);
                retVal.EntityLife = EntityLife.Deleted;
                retVal.EntityState = EntityState.Saved;
                retVal.EntityStatus = EntityStatus.Inactive;
                return retVal;
            });

            IApplication loadedEntity1 = TheProcess!.Get(savedEntity.Id)!;
            TheProcess!.Delete(loadedEntity1);

            IApplication loadedEntity2 = TheProcess!.Get(entity1.Id)!;

            Assert.That(loadedEntity2.EntityLife, Is.EqualTo(EntityLife.Deleted));
            Assert.That(loadedEntity2.EntityState, Is.EqualTo(EntityState.Saved));
            Assert.That(loadedEntity2.EntityStatus, Is.EqualTo(EntityStatus.Inactive));
            Assert.That(savedEntity == (Object)loadedEntity2, Is.EqualTo(false));
        }
    }
}
