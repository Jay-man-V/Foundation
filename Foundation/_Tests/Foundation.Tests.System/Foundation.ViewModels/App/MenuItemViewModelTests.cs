//-----------------------------------------------------------------------
// <copyright file="MenuItemViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels.App;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Tests.Unit.Foundation.ViewModels.App
{
    /// <summary>
    /// Summary description for MenuItemViewModelTests
    /// </summary>
    [TestFixture]
    public class MenuItemViewModelTests : GenericDataGridViewModelTests<IMenuItem, IMenuItemViewModel, IMenuItemProcess>
    {
        protected override String ExpectedFormTitle => "Menu Items";

        protected override String ExpectedStatusBarText => "Number of Menu Items:";

        protected override Boolean ExpectedHasOptionalDropDownParameter1 => true;
        protected override String ExpectedFilter1Name => "Application:";
        protected override String ExpectedFilter1DisplayMemberPath => FDC.Application.Name;

        protected override Boolean ExpectedHasOptionalDropDownParameter2 => true;
        protected override String ExpectedFilter2Name => "Parent:";
        protected override String ExpectedFilter2DisplayMemberPath => FDC.MenuItem.Caption;

        private IApplicationProcess? ApplicationProcess { get; set; }

        protected override IMenuItemProcess CreateBusinessProcess()
        {
            IMenuItemProcess retVal = Substitute.For<IMenuItemProcess>();

            List<IMenuItem> parentMenuItems =
            [
                Substitute.For<IMenuItem>(),
                Substitute.For<IMenuItem>(),
            ];

            retVal.MakeListOfParentMenuItems(Arg.Any<List<IMenuItem>>()).Returns(parentMenuItems);

            return retVal;
        }

        protected override IMenuItem CreateBlankModel(Int32 entityId)
        {
            IMenuItem retVal = Substitute.For<IMenuItem>();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IMenuItem CreateModel(Int32 entityId)
        {
            IMenuItem retVal = base.CreateModel(entityId);

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

        protected override IMenuItemViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            ApplicationProcess = Substitute.For<IApplicationProcess>();

            SetupForRefreshData();

            IMenuItemViewModel viewModel = new MenuItemViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess, ApplicationProcess);

            return viewModel;
        }

        protected override void SetupFilterOptionsForReferencedBusinessProcess()
        {
            List<IApplication> allItems = [];
            ApplicationProcess!.GetAll().Returns(allItems);

            ApplicationProcess
                .When(ap => ap.AddFilterOptionsAdditional(Arg.Any<List<IApplication>>()))
                .Do((args) =>
                {
                    List<IApplication> aList = (List<IApplication>)args[0];
                    aList.Add(Substitute.For<IApplication>());
                    aList.Add(Substitute.For<IApplication>());
                });
        }

        protected override void SetupForRefreshData()
        {
            base.SetupForRefreshData();

            List<IMenuItem> menuItems =
            [
                Substitute.For<IMenuItem>(),
                Substitute.For<IMenuItem>(),
            ];
            BusinessProcess.GetAll().Returns(menuItems);

            List<IMenuItem> parentMenuItems =
            [
                CreateModel(1),
                CreateModel(2)
            ];
            BusinessProcess.MakeListOfParentMenuItems(Arg.Any<List<IMenuItem>>()).Returns(parentMenuItems);

            List<IMenuItem> filteredData = [];
            BusinessProcess.ApplyFilter(Arg.Any<List<IMenuItem>>(), Arg.Any<IApplication>(), Arg.Any<IMenuItem>()).Returns(filteredData);
        }

        protected override Object CreateModelForDropDown1()
        {
            IApplication retVal = Substitute.For<IApplication>();

            return retVal;
        }

        protected override Object CreateModelForDropDown2()
        {
            IMenuItem retVal = Substitute.For<IMenuItem>();

            return retVal;
        }
    }
}
