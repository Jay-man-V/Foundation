//-----------------------------------------------------------------------
// <copyright file="MenuItemProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

using NSubstitute;

using Foundation.BusinessProcess.App;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.AppTests
{
    [TestFixture]
    public class MenuItemProcessTests : CommonBusinessProcessTests<IMenuItem, IMenuItemProcess, IMenuItemRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 20;
        protected override String ExpectedScreenTitle => "Menu Items";
        protected override String ExpectedStatusBarText => "Number of Menu Items:";

        protected override Boolean ExpectedHasOptionalDropDownParameter1 => true;
        protected override String ExpectedFilter1Name => "Application:";
        protected override String ExpectedFilter1DisplayMemberPath => FDC.Application.Name;

        protected override Boolean ExpectedHasOptionalDropDownParameter2 => true;
        protected override String ExpectedFilter2Name => "Parent:";
        protected override string ExpectedFilter2DisplayMemberPath => FDC.MenuItem.Caption;

        protected override string ExpectedComboBoxDisplayMember => FDC.MenuItem.Caption;

        protected override IMenuItemProcess CreateBusinessProcess()
        {
            IMenuItemProcess retVal = CreateBusinessProcess(DateTimeService);

            return retVal;
        }

        protected override IMenuItemProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IApplicationProcess applicationProcess = Substitute.For<IApplicationProcess>();

            CopyProperties(applicationProcess, CoreInstance.IoC.Get<IApplicationProcess>());

            IMenuItemProcess retVal = new MenuItemProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService!, TheRepository!, StatusRepository!, UserProfileRepository!, applicationProcess);

            return retVal;
        }

        protected override IMenuItemRepository CreateRepository()
        {
            IMenuItemRepository retVal = Substitute.For<IMenuItemRepository>();

            return retVal;
        }

        protected override IMenuItem CreateBlankEntity(IMenuItemProcess process, Int32 entityId)
        {
            IMenuItem retVal = CoreInstance.IoC.Get<IMenuItem>();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IMenuItem CreateEntity(IMenuItemProcess process, Int32 entityId)
        {
            IMenuItem retVal = CreateBlankEntity(process, entityId);

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.ApplicationId = new AppId(1);
            retVal.ParentMenuItemId = new EntityId(1);
            retVal.Name = Guid.NewGuid().ToString();
            retVal.Caption = Guid.NewGuid().ToString();
            retVal.ControllerAssembly = Guid.NewGuid().ToString();
            retVal.ControllerType = Guid.NewGuid().ToString();
            retVal.ViewAssembly = Guid.NewGuid().ToString();
            retVal.ViewType = Guid.NewGuid().ToString();
            retVal.HelpText = Guid.NewGuid().ToString();
            retVal.MultiInstance = true;
            retVal.ShowInTab = true;
            retVal.Icon = [1, 2, 3, 4, 5, 6, 7, 8, 10];

            return retVal;
        }

        protected override void UpdateEntityProperties(IMenuItem entity)
        {
            entity.Name += "Updated";
            entity.Caption += "Updated";
            entity.ControllerAssembly += "Updated";
            entity.ControllerType += "Updated";
            entity.ViewAssembly += "Updated";
            entity.ViewType += "Updated";
            entity.HelpText += "Updated";
            entity.MultiInstance = false;
            entity.ShowInTab = false;
            entity.Icon = [11, 12, 13, 14, 15, 16, 17, 18, 19, 20];
        }

        protected override void CheckBlankEntry(IMenuItem entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedNullText));
        }

        protected override void CheckAllEntry(IMenuItem entity)
        {
            Assert.That(entity.Caption, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IMenuItem entity)
        {
            Assert.That(entity.Caption, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IMenuItem entity1, IMenuItem entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.ApplicationId, Is.EqualTo(entity1.ApplicationId));
            Assert.That(entity2.ParentMenuItemId, Is.EqualTo(entity1.ParentMenuItemId));
            Assert.That(entity2.Name, Is.EqualTo(entity1.Name));
            Assert.That(entity2.Caption, Is.EqualTo(entity1.Caption));
            Assert.That(entity2.ControllerAssembly, Is.EqualTo(entity1.ControllerAssembly));
            Assert.That(entity2.ControllerType, Is.EqualTo(entity1.ControllerType));
            Assert.That(entity2.ViewAssembly, Is.EqualTo(entity1.ViewAssembly));
            Assert.That(entity2.ViewType, Is.EqualTo(entity1.ViewType));
            Assert.That(entity2.HelpText, Is.EqualTo(entity1.HelpText));
            Assert.That(entity2.MultiInstance, Is.EqualTo(entity1.MultiInstance));
            Assert.That(entity2.ShowInTab, Is.EqualTo(entity1.ShowInTab));
            Assert.That(entity2.Icon, Is.EqualTo(entity1.Icon));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Icon,Multi Instance,Show in Tab,Depth,Application,Parent Menu Item,Name,Caption,Help text,Controller Assembly,Controller Type,View Assembly,View Type" + Environment.NewLine;
            retVal += "1,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Byte[],True,True,0,1,1,1f01f379-9120-4161-9469-4bd6450edd54,c7cdf976-1ea5-44bf-958e-67cecce6b9f9,23f16645-5f1d-4934-ba52-96fddda34385,2cb4755f-cc28-4aaa-b16b-c8b3ce6479cc,eb7d926c-c7b3-49c3-9045-c61e02328e86,360a4652-b42d-49cb-81f4-910edb8a813c,58eee806-87da-48e3-a4e0-dbc85d1cecaa" + Environment.NewLine;
            retVal += "2,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Byte[],True,True,0,1,1,94c1be91-3ec7-4bda-921f-8d6ec97f50e1,a1ff08c0-502d-41b9-8103-e0a839fcf9fa,bedbde03-98f7-407a-8dd4-6a5db72a6cf1,446e9e31-d34f-4be8-9e9b-d5bd39208fdf,a91008f9-e118-4c70-a98f-069fc2640dc1,735032f3-6a10-4c05-b42e-d988fdf085c2,c0789845-f0a6-4946-89a9-63f9ba1b07f3" + Environment.NewLine;
            retVal += "3,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Byte[],True,True,0,1,1,afd6ee38-da63-42e3-8567-fa8311474a56,a60cb90d-5719-4050-a7ea-6d3812abd06e,4f52f085-c715-4780-a7f8-7bea5dae8a48,7e6cbcce-5bb9-4e73-965c-1959a276a8ff,f246456b-4c61-408d-9af2-0edd06712fb7,47096d51-1b17-4ddb-aa11-0a10a2516ff6,9fa092f2-10fe-4a82-9e31-200799e5a9a3" + Environment.NewLine;
            retVal += "4,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Byte[],True,True,0,1,1,9284ba67-fbd2-4358-9b07-387120eba6e0,5749dcaa-6d6a-4b34-819d-9bfd4b63ffd5,d9ae2576-991c-48e4-80ba-942de58e27f4,07faeade-19c0-42dc-a1dc-f3991fa3a6fc,409c208e-2e32-4fdc-abb7-fd7f59a2d993,589f90da-9d69-4271-ae2d-fdd070e502e7,05f6ab39-bee1-4b82-b6f9-f6c716cb28f1" + Environment.NewLine;
            retVal += "5,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Byte[],True,True,0,1,1,64c5149b-8cbe-4646-91ca-6d34b676db6a,a5653381-a732-41a4-a338-d5ccc8eacc72,140ca672-861f-42aa-a96e-7c42c86e76e9,1dc513a4-ddb9-482b-b1a1-5d16727dc87d,d78fcd6d-51e4-4e25-8410-87a8579dbdfc,4d36cfc0-74d1-4b40-ac89-d08035f0f7f0,936b10b2-a187-47ce-9bf4-fa3f562d28e9" + Environment.NewLine;
            retVal += "6,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Byte[],True,True,0,1,1,984e0324-55fb-40a5-816c-25157e2e8377,36024f25-b4ef-4bbe-a3f9-c0448483bedc,381f26bd-5f43-40f7-8a79-c304943663cf,44e89bbc-8d97-416f-a3e4-d496109a5f6f,be34da43-31ab-4b95-8128-c9b18e6679e9,b31cec9e-2271-4234-b5d4-0c24e78550c6,747933cd-f380-44ba-b5ec-ad02d348e364" + Environment.NewLine;
            retVal += "7,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Byte[],True,True,0,1,1,0585e53f-ecd9-4c5b-8a88-36287784500e,39a02bdc-7ab4-4a75-8291-73e8799468e5,b8cd3a55-e605-491a-9a55-fd339952f9f3,e574a835-6cc1-4de6-80f7-063b8432a84f,c832b37b-c353-4028-8325-578129bde69b,e6297ce8-437a-4818-95ca-e227a3469b44,8c249a1e-19a0-4d26-a1ed-d7236ac22b22" + Environment.NewLine;
            retVal += "8,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Byte[],True,True,0,1,1,2cf03c58-aa7f-4c92-b894-dfa9e711ac9b,da3db4f9-db83-45e9-b718-6f44f2584c00,362faf20-ff20-4545-b338-93b8ab4ae0ed,4160589e-3633-4796-ba92-f0da5b94df47,24711681-af2c-4c82-972c-07c06ffd43aa,a6b5dac9-e595-4e5f-83fc-b82955971cb0,6c613f57-4a10-4f4d-b124-7065a0a3979e" + Environment.NewLine;
            retVal += "9,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Byte[],True,True,0,1,1,e0f86fd6-0a09-4c18-bf4d-0af18b165775,0b3f561e-f570-48b1-8877-3f0efec48fdd,286c1489-4dfe-4da4-98f2-dfa093583daa,9d3b8928-6204-4a16-b5e9-2cc1627ad029,ac25326f-a19d-46e4-97ca-2ff8f73ef86a,5dc32f58-4a08-4509-830f-e093cefb8b1a,5ce68c9f-7caf-4897-96b6-6b4979d2a69f" + Environment.NewLine;
            retVal += "10,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Byte[],True,True,0,1,1,460fc8cd-bea2-4ff0-8598-3df678b8cc59,fd1e2caa-f0e5-41fa-a0de-d585b04c5180,992547c8-4781-42d9-a357-c3b1368fd077,966cfcfd-be40-4d18-8e54-02bc80439b0a,ccb15171-6c50-4753-8596-1013b5eac43f,b1791d6a-20cb-48b8-b51b-82313ec66d67,c8171da7-7d6c-4fc2-92ee-71b501e83738" + Environment.NewLine;

            return retVal;
        }

        [TestCase]
        public void Test_MakeListOfParentContacts()
        {
            IMenuItemProcess process = CreateBusinessProcess();

            IMenuItem parentMenuItem1 = CreateBlankEntity(process, 1);
            IMenuItem parentMenuItem2 = CreateBlankEntity(process, 2);

            List<IMenuItem> menuItems =
            [
                CreateEntity(process, 1),
                CreateEntity(process, 2),
                CreateEntity(process, 3),
                CreateEntity(process, 4),
                CreateEntity(process, 5),
            ];

            menuItems[0].ParentMenuItemId = parentMenuItem1.Id;
            menuItems[1].ParentMenuItemId = parentMenuItem2.Id;
            menuItems[2].ParentMenuItemId = parentMenuItem1.Id;
            menuItems[3].ParentMenuItemId = parentMenuItem2.Id;
            menuItems[4].ParentMenuItemId = parentMenuItem1.Id;

            // Caption needs to be set sorting
            menuItems[0].Caption = "A";
            menuItems[1].Caption = "B";
            menuItems[2].Caption = "C";
            menuItems[3].Caption = "D";
            menuItems[4].Caption = "E";

            List<IMenuItem> parentMenuItems = process.MakeListOfParentMenuItems(menuItems);

            Assert.That(parentMenuItems.Count, Is.EqualTo(2));
            Assert.That(parentMenuItems[0].ParentMenuItemId, Is.EqualTo(parentMenuItem1.Id));
            Assert.That(parentMenuItems[1].ParentMenuItemId, Is.EqualTo(parentMenuItem2.Id));
        }

        [TestCase]
        public void Test_ApplyFilter_Application()
        {
            IMenuItemProcess process = CreateBusinessProcess();

            IApplication application1 = Substitute.For<IApplication>();
            application1.Id = new AppId(1);

            IApplication application2 = Substitute.For<IApplication>();
            application2.Id = new AppId(2);

            const IMenuItem? parentMenuItem = null;

            List<IMenuItem> menuItems =
            [
                CreateEntity(process, 1),
                CreateEntity(process, 2),
                CreateEntity(process, 3),
                CreateEntity(process, 4),
                CreateEntity(process, 5),
            ];

            menuItems[0].ParentMenuItemId = new EntityId(0);
            menuItems[1].ParentMenuItemId = new EntityId(0);
            menuItems[2].ParentMenuItemId = new EntityId(0);
            menuItems[3].ParentMenuItemId = new EntityId(0);
            menuItems[4].ParentMenuItemId = new EntityId(0);

            menuItems[0].Id = new EntityId(0);
            menuItems[0].ApplicationId = application1.Id;
            menuItems[0].ParentMenuItemId = new EntityId(1);

            menuItems[1].Id = new EntityId(1);
            menuItems[1].ApplicationId = application2.Id;
            menuItems[1].ParentMenuItemId = new EntityId(2);

            menuItems[2].Id = new EntityId(2);
            menuItems[2].ApplicationId = application1.Id;
            menuItems[2].ParentMenuItemId = new EntityId(3);

            menuItems[3].Id = new EntityId(3);
            menuItems[3].ApplicationId = application2.Id;
            menuItems[3].ParentMenuItemId = new EntityId(4);

            menuItems[4].Id = new EntityId(4);
            menuItems[4].ApplicationId = application1.Id;
            menuItems[4].ParentMenuItemId = new EntityId(5);

            List<IMenuItem> filteredMenuItems1 = process.ApplyFilter(menuItems, application1, parentMenuItem);
            Assert.That(filteredMenuItems1.Count, Is.EqualTo(3));

            List<IMenuItem> filteredMenuItems2 = process.ApplyFilter(menuItems, application2, parentMenuItem);
            Assert.That(filteredMenuItems2.Count, Is.EqualTo(2));
        }

        [TestCase]
        public void Test_ApplyFilter_ParentMenuItem()
        {
            IMenuItemProcess process = CreateBusinessProcess();

            const IApplication? application = null;

            IMenuItem parentMenuItem1 = CreateEntity(process, 1);
            parentMenuItem1.Id = new EntityId(1);

            IMenuItem parentMenuItem2 = CreateEntity(process, 2);
            parentMenuItem2.Id = new EntityId(2);

            List<IMenuItem> menuItems =
            [
                CreateEntity(process, 1),
                CreateEntity(process, 2),
                CreateEntity(process, 3),
                CreateEntity(process, 4),
                CreateEntity(process, 5),
            ];

            menuItems[0].ParentMenuItemId = new EntityId(0);
            menuItems[1].ParentMenuItemId = new EntityId(0);
            menuItems[2].ParentMenuItemId = new EntityId(0);
            menuItems[3].ParentMenuItemId = new EntityId(0);
            menuItems[4].ParentMenuItemId = new EntityId(0);

            menuItems[0].Id = new EntityId(0);
            menuItems[0].ApplicationId = new AppId(1);
            menuItems[0].ParentMenuItemId = parentMenuItem1.Id;

            menuItems[1].Id = new EntityId(1);
            menuItems[1].ApplicationId = new AppId(2);
            menuItems[1].ParentMenuItemId = parentMenuItem2.Id;

            menuItems[2].Id = new EntityId(2);
            menuItems[2].ApplicationId = new AppId(1);
            menuItems[2].ParentMenuItemId = parentMenuItem1.Id;

            menuItems[3].Id = new EntityId(3);
            menuItems[3].ApplicationId = new AppId(2);
            menuItems[3].ParentMenuItemId = parentMenuItem2.Id;

            menuItems[4].Id = new EntityId(4);
            menuItems[4].ApplicationId = new AppId(1);
            menuItems[4].ParentMenuItemId = parentMenuItem1.Id;

            List<IMenuItem> filteredContacts1 = process.ApplyFilter(menuItems, application, parentMenuItem1);
            Assert.That(filteredContacts1.Count, Is.EqualTo(3));

            List<IMenuItem> filteredContacts2 = process.ApplyFilter(menuItems, application, parentMenuItem2);
            Assert.That(filteredContacts2.Count, Is.EqualTo(2));
        }
    }
}