//-----------------------------------------------------------------------
// <copyright file="GenericDataGridViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.ObjectModel;
using System.Text;

using NSubstitute;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Interfaces.Helpers;
using Foundation.ViewModels;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses
{
    /// <summary>
    /// Summary description for GenericDataGridViewModelTests
    /// </summary>
    public abstract class GenericDataGridViewModelTests<TModel, TViewModel, TBusinessProcess> : ViewModelTests<TViewModel>
        where TModel : IFoundationModel
        where TViewModel : IViewModel
        where TBusinessProcess : ICommonBusinessProcess<TModel>
    {
        public override void TestInitialise()
        {
            base.TestInitialise();

            BusinessProcess = CreateBusinessProcess();
            SetBusinessProcessProperties(BusinessProcess);

            TheViewModel = CreateViewModel();
            SetupFilterOptionsForReferencedBusinessProcess();
        }

        protected GenericDataGridViewModel<TModel>? TheGenericDataGridViewModel => TheViewModel as GenericDataGridViewModel<TModel>;
        protected TBusinessProcess BusinessProcess { get; private set; }
        protected ICommonBusinessProcess CommonBusinessProcess => BusinessProcess;

        protected abstract TBusinessProcess CreateBusinessProcess();

        protected abstract TModel CreateBlankModel(Int32 entityId);

        protected virtual TModel CreateModel(Int32 entityId)
        {
            TModel retVal = CreateBlankModel(entityId);

            retVal.EntityStatus = EntityStatus.Active;

            retVal.CreatedOn = CreatedOnDateTime;
            retVal.CreatedByUserProfileId = new EntityId(1);

            retVal.LastUpdatedOn = LastUpdatedOnDateTime;
            retVal.LastUpdatedByUserProfileId = new EntityId(2);

            retVal.ValidFrom = ValidFromDateTime;
            retVal.ValidTo = ValidToDateTime;

            return retVal;
        }

        protected virtual String ExpectedStatusBarText { get; } = String.Empty;

        protected virtual Boolean ExpectedCanRefreshData { get; } = true;
        protected virtual Boolean ExpectedRefreshButtonVisible { get; } = true;
        protected virtual Boolean ExpectedRefreshButtonEnabled { get; } = true;
        protected virtual Boolean ExpectedCanViewRecord { get; } = false;
        protected virtual Boolean ExpectedViewButtonVisible { get; } = false;
        protected virtual Boolean ExpectedViewButtonEnabled { get; } = false;
        protected virtual Boolean ExpectedCanAddRecord { get; } = false;
        protected virtual Boolean ExpectedAddButtonVisible { get; } = false;
        protected virtual Boolean ExpectedAddButtonEnabled { get; } = false;
        protected virtual Boolean ExpectedCanEditRecord { get; } = false;
        protected virtual Boolean ExpectedEditButtonVisible { get; } = false;
        protected virtual Boolean ExpectedEditButtonEnabled { get; } = false;
        protected virtual Boolean ExpectedCanDeleteRecord { get; } = false;
        protected virtual Boolean ExpectedDeleteButtonVisible { get; } = false;
        protected virtual Boolean ExpectedDeleteButtonEnabled { get; } = false;


        protected virtual Boolean ExpectedHasOptionalAction1 { get; } = false;
        protected virtual Boolean ExpectedAction1Enabled { get; } = false;
        protected virtual String ExpectedAction1Name { get; } = "Action1";
        protected virtual Boolean ExpectedHasOptionalDropDownParameter1 { get; } = false;
        protected virtual String ExpectedFilter1Name { get; } = "Filter1";
        protected virtual String ExpectedFilter1DisplayMemberPath { get; } = String.Empty;
        protected virtual String ExpectedFilter1SelectedValuePath { get; } = FDC.FoundationEntity.Id;

        protected virtual Boolean ExpectedHasOptionalAction2 { get; } = false;
        protected virtual Boolean ExpectedAction2Enabled { get; } = false;
        protected virtual String ExpectedAction2Name { get; } = "Action2";
        protected virtual Boolean ExpectedHasOptionalDropDownParameter2 { get; } = false;
        protected virtual String ExpectedFilter2Name { get; } = "Filter2";
        protected virtual String ExpectedFilter2DisplayMemberPath { get; } = String.Empty;
        protected virtual String ExpectedFilter2SelectedValuePath { get; } = FDC.FoundationEntity.Id;

        protected virtual Boolean ExpectedHasOptionalAction3 { get; } = false;
        protected virtual Boolean ExpectedAction3Enabled { get; } = false;
        protected virtual String ExpectedAction3Name { get; } = "Action3";
        protected virtual Boolean ExpectedHasOptionalDropDownParameter3 { get; } = false;
        protected virtual String ExpectedFilter3Name { get; } = "Filter3";
        protected virtual String ExpectedFilter3DisplayMemberPath { get; } = String.Empty;
        protected virtual String ExpectedFilter3SelectedValuePath { get; } = FDC.FoundationEntity.Id;

        protected virtual Boolean ExpectedHasOptionalAction4 { get; } = false;
        protected virtual Boolean ExpectedAction4Enabled { get; } = false;
        protected virtual String ExpectedAction4Name { get; } = "Action4";
        protected virtual Boolean ExpectedHasOptionalDropDownParameter4 { get; } = false;
        protected virtual String ExpectedFilter4Name { get; } = "Filter4";
        protected virtual String ExpectedFilter4DisplayMemberPath { get; } = String.Empty;
        protected virtual String ExpectedFilter4SelectedValuePath { get; } = FDC.FoundationEntity.Id;


        protected void SetBusinessProcessProperties(TBusinessProcess businessProcess)
        {
            //TBusinessProcess tempProcess = CoreInstance.IoC.Get<TBusinessProcess>();

            ExpectedFormTitle = Guid.NewGuid().ToString();
            businessProcess.ScreenTitle.Returns(ExpectedFormTitle);

            businessProcess.AllId.Returns(new EntityId(-1));
            businessProcess.AllText.Returns("<All>");

            businessProcess.NoneId.Returns(new EntityId(-2));
            businessProcess.NoneText.Returns("<None>");

            businessProcess.NullId.Returns(new EntityId(-1));

            //businessProcess.StatusBarText.Returns(tempProcess.StatusBarText);

            //businessProcess.ComboBoxDisplayMember.Returns(tempProcess.ComboBoxDisplayMember);
            //businessProcess.ComboBoxValueMember.Returns(tempProcess.ComboBoxValueMember);

            businessProcess.HasOptionalAction1.Returns(ExpectedHasOptionalAction1);
            businessProcess.Action1Name.Returns(ExpectedAction1Name);

            businessProcess.HasOptionalAction2.Returns(ExpectedHasOptionalAction2);
            businessProcess.Action2Name.Returns(ExpectedAction2Name);

            businessProcess.HasOptionalAction3.Returns(ExpectedHasOptionalAction3);
            businessProcess.Action3Name.Returns(ExpectedAction3Name);

            businessProcess.HasOptionalAction4.Returns(ExpectedHasOptionalAction4);
            businessProcess.Action4Name.Returns(ExpectedAction4Name);

            //businessProcess.HasOptionalDropDownParameter1.Returns(tempProcess.HasOptionalDropDownParameter1);
            //businessProcess.Filter1Name.Returns(tempProcess.Filter1Name);
            //businessProcess.Filter1DisplayMemberPath.Returns(tempProcess.Filter1DisplayMemberPath);
            //businessProcess.Filter1SelectedValuePath.Returns(tempProcess.Filter1SelectedValuePath);

            //businessProcess.HasOptionalDropDownParameter2.Returns(tempProcess.HasOptionalDropDownParameter2);
            //businessProcess.Filter2Name.Returns(tempProcess.Filter2Name);
            //businessProcess.Filter2DisplayMemberPath.Returns(tempProcess.Filter2DisplayMemberPath);
            //businessProcess.Filter2SelectedValuePath.Returns(tempProcess.Filter2SelectedValuePath);

            //businessProcess.HasOptionalDropDownParameter3.Returns(tempProcess.HasOptionalDropDownParameter3);
            //businessProcess.Filter3Name.Returns(tempProcess.Filter3Name);
            //businessProcess.Filter3DisplayMemberPath.Returns(tempProcess.Filter3DisplayMemberPath);
            //businessProcess.Filter3SelectedValuePath.Returns(tempProcess.Filter3SelectedValuePath);

            //businessProcess.HasOptionalDropDownParameter4.Returns(tempProcess.HasOptionalDropDownParameter4);
            //businessProcess.Filter4Name.Returns(tempProcess.Filter4Name);
            //businessProcess.Filter4DisplayMemberPath.Returns(tempProcess.Filter4DisplayMemberPath);
            //businessProcess.Filter4SelectedValuePath.Returns(tempProcess.Filter4SelectedValuePath);

            businessProcess.CanRefreshData().Returns(ExpectedCanRefreshData);
            //businessProcess.CanAddRecord().Returns(tempProcess.CanAddRecord());
            //businessProcess.CanViewRecord().Returns(tempProcess.CanViewRecord());
            //businessProcess.CanEditRecord().Returns(tempProcess.CanEditRecord());
            //businessProcess.CanDeleteRecord().Returns(tempProcess.CanDeleteRecord());
        }

        protected virtual void SetupForRefreshData()
        {
            List<TModel> entities = [];
            BusinessProcess.GetAll().Returns(entities);
        }

        protected virtual void CheckAction1Properties()
        {
            Assert.That(TheGenericDataGridViewModel!.HasOptionalAction1, Is.EqualTo(ExpectedHasOptionalAction1));
            Assert.That(TheGenericDataGridViewModel.Action1Name, Is.EqualTo(ExpectedAction1Name));
            Assert.That(TheGenericDataGridViewModel.Action1Command, Is.Not.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.Action1Command, Is.InstanceOf<RelayCommand<Object>>());

            Assert.That(TheGenericDataGridViewModel.Action1CommandEnabled, Is.EqualTo(ExpectedAction1Enabled));
            Assert.That(TheGenericDataGridViewModel.Action1Command.CanExecute(null), Is.EqualTo(ExpectedAction1Enabled));

            TheGenericDataGridViewModel.Action1CommandEnabled = false;
            Assert.That(TheGenericDataGridViewModel.Action1CommandEnabled, Is.EqualTo(false));
            Assert.That(TheGenericDataGridViewModel.Action1Command.CanExecute(null), Is.EqualTo(false));

            TheGenericDataGridViewModel.Action1CommandEnabled = true;
            Assert.That(TheGenericDataGridViewModel.Action1CommandEnabled, Is.EqualTo(true));
            Assert.That(TheGenericDataGridViewModel.Action1Command.CanExecute(null), Is.EqualTo(true));
        }

        protected virtual Object SetupForAction1Command()
        {
            Object retVal = new Object();

            return retVal;
        }

        protected virtual void AssertForAction1Command()
        {
            // Does nothing
        }

        protected virtual void CheckAction2Properties()
        {
            Assert.That(TheGenericDataGridViewModel!.HasOptionalAction2, Is.EqualTo(ExpectedHasOptionalAction2));
            Assert.That(TheGenericDataGridViewModel.Action2Name, Is.EqualTo(ExpectedAction2Name));
            Assert.That(TheGenericDataGridViewModel.Action2Command, Is.Not.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.Action2Command, Is.InstanceOf<RelayCommand<Object>>());

            Assert.That(TheGenericDataGridViewModel.Action2CommandEnabled, Is.EqualTo(ExpectedAction2Enabled));
            Assert.That(TheGenericDataGridViewModel.Action2Command.CanExecute(null), Is.EqualTo(ExpectedAction2Enabled));

            TheGenericDataGridViewModel.Action2CommandEnabled = false;
            Assert.That(TheGenericDataGridViewModel.Action2CommandEnabled, Is.EqualTo(false));
            Assert.That(TheGenericDataGridViewModel.Action2Command.CanExecute(null), Is.EqualTo(false));

            TheGenericDataGridViewModel.Action2CommandEnabled = true;
            Assert.That(TheGenericDataGridViewModel.Action2CommandEnabled, Is.EqualTo(true));
            Assert.That(TheGenericDataGridViewModel.Action2Command.CanExecute(null), Is.EqualTo(true));
        }

        protected virtual Object SetupForAction2Command()
        {
            Object retVal = new Object();

            return retVal;
        }

        protected virtual void AssertForAction2Command()
        {
            // Does nothing
        }

        protected virtual void CheckAction3Properties()
        {
            Assert.That(TheGenericDataGridViewModel!.HasOptionalAction3, Is.EqualTo(ExpectedHasOptionalAction3));
            Assert.That(TheGenericDataGridViewModel.Action3Name, Is.EqualTo(ExpectedAction3Name));
            Assert.That(TheGenericDataGridViewModel.Action3Command, Is.Not.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.Action3Command, Is.InstanceOf<RelayCommand<Object>>());

            Assert.That(TheGenericDataGridViewModel.Action3CommandEnabled, Is.EqualTo(ExpectedAction3Enabled));
            Assert.That(TheGenericDataGridViewModel.Action3Command.CanExecute(null), Is.EqualTo(ExpectedAction3Enabled));

            TheGenericDataGridViewModel.Action3CommandEnabled = false;
            Assert.That(TheGenericDataGridViewModel.Action3CommandEnabled, Is.EqualTo(false));
            Assert.That(TheGenericDataGridViewModel.Action3Command.CanExecute(null), Is.EqualTo(false));

            TheGenericDataGridViewModel.Action3CommandEnabled = true;
            Assert.That(TheGenericDataGridViewModel.Action3CommandEnabled, Is.EqualTo(true));
            Assert.That(TheGenericDataGridViewModel.Action3Command.CanExecute(null), Is.EqualTo(true));
        }

        protected virtual Object SetupForAction3Command()
        {
            Object retVal = new Object();

            return retVal;
        }

        protected virtual void AssertForAction3Command()
        {
            // Does nothing
        }

        protected virtual void CheckAction4Properties()
        {
            Assert.That(TheGenericDataGridViewModel!.HasOptionalAction4, Is.EqualTo(ExpectedHasOptionalAction4));
            Assert.That(TheGenericDataGridViewModel.Action4Name, Is.EqualTo(ExpectedAction4Name));
            Assert.That(TheGenericDataGridViewModel.Action4Command, Is.Not.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.Action4Command, Is.InstanceOf<RelayCommand<Object>>());

            Assert.That(TheGenericDataGridViewModel.Action4CommandEnabled, Is.EqualTo(ExpectedAction4Enabled));
            Assert.That(TheGenericDataGridViewModel.Action4Command.CanExecute(null), Is.EqualTo(ExpectedAction4Enabled));

            TheGenericDataGridViewModel.Action4CommandEnabled = false;
            Assert.That(TheGenericDataGridViewModel.Action4CommandEnabled, Is.EqualTo(false));
            Assert.That(TheGenericDataGridViewModel.Action4Command.CanExecute(null), Is.EqualTo(false));

            TheGenericDataGridViewModel.Action4CommandEnabled = true;
            Assert.That(TheGenericDataGridViewModel.Action4CommandEnabled, Is.EqualTo(true));
            Assert.That(TheGenericDataGridViewModel.Action4Command.CanExecute(null), Is.EqualTo(true));
        }

        protected virtual Object SetupForAction4Command()
        {
            Object retVal = new Object();

            return retVal;
        }

        protected virtual void AssertForAction4Command()
        {
            // Does nothing
        }

        protected virtual Object CreateModelForDropDown1()
        {
            return new Object();
        }

        protected virtual List<Object> SetupForDropDown1DataSource()
        {
            List<Object> retVal =
            [
                CreateModelForDropDown1(),
                CreateModelForDropDown1(),
                CreateModelForDropDown1(),
            ];

            return retVal;
        }

        protected virtual void CheckDropDown1Properties()
        {
            Assert.That(TheGenericDataGridViewModel!.HasOptionalDropDownParameter1, Is.EqualTo(ExpectedHasOptionalDropDownParameter1));
            Assert.That(TheGenericDataGridViewModel.Filter1Name, Is.EqualTo(ExpectedFilter1Name));
            Assert.That(TheGenericDataGridViewModel.Filter1DisplayMemberPath, Is.EqualTo(ExpectedFilter1DisplayMemberPath));
            Assert.That(TheGenericDataGridViewModel.Filter1SelectedValuePath, Is.EqualTo(ExpectedFilter1SelectedValuePath));
            Assert.That(TheGenericDataGridViewModel.Filter1SelectionChangedCommand, Is.Not.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.Filter1SelectionChangedCommand, Is.InstanceOf<RelayCommand<Object>>());
            Assert.That(TheGenericDataGridViewModel.Filter1DataSource, Is.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.Filter1SelectedItem, Is.EqualTo(null));

            List<Object> entities = SetupForDropDown1DataSource();
            TheGenericDataGridViewModel.Filter1DataSource = entities;
            Assert.That(TheGenericDataGridViewModel.Filter1DataSource, Is.EqualTo(entities));

            TheGenericDataGridViewModel.Filter1SelectedItem = entities[0];
            Assert.That(TheGenericDataGridViewModel.Filter1SelectedItem, Is.EqualTo(entities[0]));
        }

        protected virtual Object CreateModelForDropDown2()
        {
            return new Object();
        }

        protected virtual List<Object> SetupForDropDown2DataSource()
        {
            List<Object> retVal =
            [
                CreateModelForDropDown2(),
                CreateModelForDropDown2(),
                CreateModelForDropDown2(),
            ];

            return retVal;
        }

        protected virtual void CheckDropDown2Properties()
        {
            Assert.That(TheGenericDataGridViewModel!.HasOptionalDropDownParameter2, Is.EqualTo(ExpectedHasOptionalDropDownParameter2));
            Assert.That(TheGenericDataGridViewModel.Filter2Name, Is.EqualTo(ExpectedFilter2Name));
            Assert.That(TheGenericDataGridViewModel.Filter2DisplayMemberPath, Is.EqualTo(ExpectedFilter2DisplayMemberPath));
            Assert.That(TheGenericDataGridViewModel.Filter2SelectedValuePath, Is.EqualTo(ExpectedFilter2SelectedValuePath));
            Assert.That(TheGenericDataGridViewModel.Filter2SelectionChangedCommand, Is.Not.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.Filter2SelectionChangedCommand, Is.InstanceOf<RelayCommand<Object>>());
            Assert.That(TheGenericDataGridViewModel.Filter2DataSource, Is.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.Filter2SelectedItem, Is.EqualTo(null));

            List<Object> entities = SetupForDropDown2DataSource();
            TheGenericDataGridViewModel.Filter2DataSource = entities;
            Assert.That(TheGenericDataGridViewModel.Filter2DataSource, Is.EqualTo(entities));

            TheGenericDataGridViewModel.Filter2SelectedItem = entities[0];
            Assert.That(TheGenericDataGridViewModel.Filter2SelectedItem, Is.EqualTo(entities[0]));
        }

        protected virtual Object CreateModelForDropDown3()
        {
            return new Object();
        }

        protected virtual List<Object> SetupForDropDown3DataSource()
        {
            List<Object> retVal =
            [
                CreateModelForDropDown3(),
                CreateModelForDropDown3(),
                CreateModelForDropDown3(),
            ];

            return retVal;
        }

        protected virtual void CheckDropDown3Properties()
        {
            Assert.That(TheGenericDataGridViewModel!.HasOptionalDropDownParameter3, Is.EqualTo(ExpectedHasOptionalDropDownParameter3));
            Assert.That(TheGenericDataGridViewModel.Filter3Name, Is.EqualTo(ExpectedFilter3Name));
            Assert.That(TheGenericDataGridViewModel.Filter3DisplayMemberPath, Is.EqualTo(ExpectedFilter3DisplayMemberPath));
            Assert.That(TheGenericDataGridViewModel.Filter3SelectedValuePath, Is.EqualTo(ExpectedFilter3SelectedValuePath));
            Assert.That(TheGenericDataGridViewModel.Filter3SelectionChangedCommand, Is.Not.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.Filter3SelectionChangedCommand, Is.InstanceOf<RelayCommand<Object>>());
            Assert.That(TheGenericDataGridViewModel.Filter3DataSource, Is.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.Filter3SelectedItem, Is.EqualTo(null));

            List<Object> entities = SetupForDropDown3DataSource();
            TheGenericDataGridViewModel.Filter3DataSource = entities;
            Assert.That(TheGenericDataGridViewModel.Filter3DataSource, Is.EqualTo(entities));

            TheGenericDataGridViewModel.Filter3SelectedItem = entities[0];
            Assert.That(TheGenericDataGridViewModel.Filter3SelectedItem, Is.EqualTo(entities[0]));
        }

        protected virtual Object CreateModelForDropDown4()
        {
            return new Object();
        }

        protected virtual List<Object> SetupForDropDown4DataSource()
        {
            List<Object> retVal =
            [
                CreateModelForDropDown4(),
                CreateModelForDropDown4(),
                CreateModelForDropDown4(),
            ];

            return retVal;
        }

        protected virtual void CheckDropDown4Properties()
        {
            Assert.That(TheGenericDataGridViewModel!.HasOptionalDropDownParameter4, Is.EqualTo(ExpectedHasOptionalDropDownParameter4));
            Assert.That(TheGenericDataGridViewModel.Filter4Name, Is.EqualTo(ExpectedFilter4Name));
            Assert.That(TheGenericDataGridViewModel.Filter4DisplayMemberPath, Is.EqualTo(ExpectedFilter4DisplayMemberPath));
            Assert.That(TheGenericDataGridViewModel.Filter4SelectedValuePath, Is.EqualTo(ExpectedFilter4SelectedValuePath));
            Assert.That(TheGenericDataGridViewModel.Filter4SelectionChangedCommand, Is.Not.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.Filter4SelectionChangedCommand, Is.InstanceOf<RelayCommand<Object>>());
            Assert.That(TheGenericDataGridViewModel.Filter4DataSource, Is.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.Filter4SelectedItem, Is.EqualTo(null));

            List<Object> entities = SetupForDropDown4DataSource();
            TheGenericDataGridViewModel.Filter4DataSource = entities;
            Assert.That(TheGenericDataGridViewModel.Filter4DataSource, Is.EqualTo(entities));

            TheGenericDataGridViewModel.Filter4SelectedItem = entities[0];
            Assert.That(TheGenericDataGridViewModel.Filter4SelectedItem, Is.EqualTo(entities[0]));
        }

        [TestCase]
        public void Test_GenericDataGridViewModel_Constructor()
        {
            Assert.That(TheGenericDataGridViewModel!.Filter1DataSource, Is.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.Filter2DataSource, Is.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.Filter3DataSource, Is.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.Filter4DataSource, Is.EqualTo(null));

            Assert.That(TheGenericDataGridViewModel.Filter1SelectedItem, Is.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.Filter2SelectedItem, Is.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.Filter3SelectedItem, Is.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.Filter4SelectedItem, Is.EqualTo(null));

            Assert.That(TheGenericDataGridViewModel.GridDataSource, Is.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.SelectedItem, Is.EqualTo(null));

            Assert.That(TheGenericDataGridViewModel.RefreshCommandEnabled, Is.EqualTo(true));

            Assert.That(TheGenericDataGridViewModel.FileApi, Is.Not.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.CommonBusinessProcess, Is.Not.EqualTo(null));
        }

        [TestCase]
        public void Test_BaseClassProperties()
        {
            Assert.That(TheGenericDataGridViewModel!.CanRefreshData, Is.EqualTo(ExpectedCanRefreshData));
            Assert.That(TheGenericDataGridViewModel.RefreshButtonVisible, Is.EqualTo(ExpectedRefreshButtonVisible));
            Assert.That(TheGenericDataGridViewModel.RefreshCommand, Is.Not.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.RefreshCommandEnabled, Is.EqualTo(ExpectedRefreshButtonEnabled));

            Assert.That(TheGenericDataGridViewModel.CanViewRecord, Is.EqualTo(ExpectedCanViewRecord));
            Assert.That(TheGenericDataGridViewModel.ViewButtonVisible, Is.EqualTo(ExpectedViewButtonVisible));
            Assert.That(TheGenericDataGridViewModel.ViewRecordCommand, Is.Not.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.ViewRecordCommandEnabled, Is.EqualTo(ExpectedViewButtonEnabled));

            Assert.That(TheGenericDataGridViewModel.CanAddRecord, Is.EqualTo(ExpectedCanAddRecord));
            Assert.That(TheGenericDataGridViewModel.AddButtonVisible, Is.EqualTo(ExpectedAddButtonVisible));
            Assert.That(TheGenericDataGridViewModel.AddRecordCommand, Is.Not.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.AddRecordCommandEnabled, Is.EqualTo(ExpectedAddButtonEnabled));

            Assert.That(TheGenericDataGridViewModel.CanEditRecord, Is.EqualTo(ExpectedCanEditRecord));
            Assert.That(TheGenericDataGridViewModel.EditButtonVisible, Is.EqualTo(ExpectedEditButtonVisible));
            Assert.That(TheGenericDataGridViewModel.EditRecordCommand, Is.Not.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.EditRecordCommandEnabled, Is.EqualTo(ExpectedEditButtonEnabled));

            Assert.That(TheGenericDataGridViewModel.CanDeleteRecord, Is.EqualTo(ExpectedCanDeleteRecord));
            Assert.That(TheGenericDataGridViewModel.DeleteButtonVisible, Is.EqualTo(ExpectedDeleteButtonVisible));
            Assert.That(TheGenericDataGridViewModel.DeleteRecordCommand, Is.Not.EqualTo(null));
            Assert.That(TheGenericDataGridViewModel.DeleteRecordCommandEnabled, Is.EqualTo(ExpectedDeleteButtonEnabled));

            Assert.That(TheGenericDataGridViewModel.ActionsVisible, Is.EqualTo(ExpectedHasOptionalAction1 || ExpectedHasOptionalAction2 || ExpectedHasOptionalAction3 || ExpectedHasOptionalAction4));
            Assert.That(TheGenericDataGridViewModel.FiltersVisible, Is.EqualTo(ExpectedHasOptionalDropDownParameter1 || ExpectedHasOptionalDropDownParameter2 || ExpectedHasOptionalDropDownParameter3 || ExpectedHasOptionalDropDownParameter4));

            CheckAction1Properties();
            CheckAction2Properties();
            CheckAction3Properties();
            CheckAction4Properties();

            CheckDropDown1Properties();
            CheckDropDown2Properties();
            CheckDropDown3Properties();
            CheckDropDown4Properties();

            Assert.That(TheGenericDataGridViewModel.GridDataSource, Is.EqualTo(null));

            Assert.That(TheGenericDataGridViewModel.FormTitle, Is.EqualTo(ExpectedFormTitle));
            Assert.That(TheGenericDataGridViewModel.StatusBarText, Is.EqualTo(ExpectedStatusBarText));
        }

        [TestCase]
        public void Test_SelectedItem()
        {
            Assert.That(TheGenericDataGridViewModel!.SelectedItem, Is.EqualTo(null));

            TModel entity1 = CreateModel(1);
            TheGenericDataGridViewModel.SelectedItem = entity1;

            Assert.That(TheGenericDataGridViewModel.SelectedItem, Is.EqualTo(entity1));
        }

        [TestCase]
        public void Test_ExecuteAction1_Null()
        {
            SetupForAction1Command();
            TheGenericDataGridViewModel!.Action1Command.Execute(null);
        }

        [TestCase]
        public void Test_ExecuteAction1_Object()
        {
            Object obj = SetupForAction1Command();
            TheGenericDataGridViewModel!.Action1Command.Execute(obj);
        }

        [TestCase]
        public void Test_ExecuteAction2_Null()
        {
            SetupForAction2Command();
            TheGenericDataGridViewModel!.Action2Command.Execute(null);
        }

        [TestCase]
        public void Test_ExecuteAction2_Object()
        {
            Object obj = SetupForAction2Command();
            TheGenericDataGridViewModel!.Action2Command.Execute(obj);
        }

        [TestCase]
        public void Test_ExecuteAction3_Null()
        {
            SetupForAction3Command();
            TheGenericDataGridViewModel!.Action3Command.Execute(null);
        }

        [TestCase]
        public void Test_ExecuteAction3_Object()
        {
            Object obj = SetupForAction3Command();
            TheGenericDataGridViewModel!.Action3Command.Execute(obj);
        }

        [TestCase]
        public void Test_ExecuteAction4_Null()
        {
            SetupForAction4Command();
            TheGenericDataGridViewModel!.Action4Command.Execute(null);
        }

        [TestCase]
        public void Test_ExecuteAction4_Object()
        {
            Object obj = SetupForAction4Command();
            TheGenericDataGridViewModel!.Action4Command.Execute(obj);
        }

        [TestCase]
        public void Test_Filter1SelectionChanged_Null()
        {
            TheGenericDataGridViewModel!.Filter1SelectionChangedCommand.Execute(null);
        }

        [TestCase]
        public void Test_Filter1SelectionChanged()
        {
            Object obj1 = CreateModelForDropDown1();
            TheGenericDataGridViewModel!.Filter1SelectedItem = obj1;

            Object obj2 = CreateModelForDropDown2();
            TheGenericDataGridViewModel!.Filter2SelectedItem = obj2;

            Object obj3 = CreateModelForDropDown3();
            TheGenericDataGridViewModel!.Filter3SelectedItem = obj3;

            Object obj4 = CreateModelForDropDown4();
            TheGenericDataGridViewModel!.Filter4SelectedItem = obj4;

            TheGenericDataGridViewModel!.Filter1SelectionChangedCommand.Execute(obj1);
        }

        [TestCase]
        public void Test_Filter2SelectionChanged_Null()
        {
            TheGenericDataGridViewModel!.Filter2SelectionChangedCommand.Execute(null);
        }

        [TestCase]
        public void Test_Filter2SelectionChanged()
        {
            Object obj1 = CreateModelForDropDown1();
            TheGenericDataGridViewModel!.Filter1SelectedItem = obj1;

            Object obj2 = CreateModelForDropDown2();
            TheGenericDataGridViewModel!.Filter2SelectedItem = obj2;

            Object obj3 = CreateModelForDropDown3();
            TheGenericDataGridViewModel!.Filter3SelectedItem = obj3;

            Object obj4 = CreateModelForDropDown4();
            TheGenericDataGridViewModel!.Filter4SelectedItem = obj4;

            TheGenericDataGridViewModel!.Filter2SelectionChangedCommand.Execute(obj2);
        }

        [TestCase]
        public void Test_Filter3SelectionChanged_Null()
        {
            TheGenericDataGridViewModel!.Filter3SelectionChangedCommand.Execute(null);
        }

        [TestCase]
        public void Test_Filter3SelectionChanged()
        {
            Object obj1 = CreateModelForDropDown1();
            TheGenericDataGridViewModel!.Filter1SelectedItem = obj1;

            Object obj2 = CreateModelForDropDown2();
            TheGenericDataGridViewModel!.Filter2SelectedItem = obj2;

            Object obj3 = CreateModelForDropDown3();
            TheGenericDataGridViewModel!.Filter3SelectedItem = obj3;

            Object obj4 = CreateModelForDropDown4();
            TheGenericDataGridViewModel!.Filter4SelectedItem = obj4;

            TheGenericDataGridViewModel!.Filter3SelectionChangedCommand.Execute(obj3);
        }

        [TestCase]
        public void Test_Filter4SelectionChanged_Null()
        {
            TheGenericDataGridViewModel!.Filter4SelectionChangedCommand.Execute(null);
        }

        [TestCase]
        public void Test_Filter4SelectionChanged()
        {
            Object obj1 = CreateModelForDropDown1();
            TheGenericDataGridViewModel!.Filter1SelectedItem = obj1;

            Object obj2 = CreateModelForDropDown2();
            TheGenericDataGridViewModel!.Filter2SelectedItem = obj2;

            Object obj3 = CreateModelForDropDown3();
            TheGenericDataGridViewModel!.Filter3SelectedItem = obj3;

            Object obj4 = CreateModelForDropDown4();
            TheGenericDataGridViewModel!.Filter4SelectedItem = obj4;

            TheGenericDataGridViewModel!.Filter4SelectionChangedCommand.Execute(obj4);
        }

        [TestCase]
        public void Test_SelectedGridItemChanged()
        {
            TheGenericDataGridViewModel!.SelectedGridItemChangedCommand.Execute(null);

            TModel entity = CreateModel(1);
            TheGenericDataGridViewModel!.SelectedGridItemChangedCommand.Execute(entity);
        }

        [TestCase]
        public void Test_ExportToExcel()
        {
            List<TModel> entities = new List<TModel>();
            TheGenericDataGridViewModel!.ExportGridToExcelCommand.Execute(entities);
        }

        [TestCase]
        public void Test_ExportToCsv_NullList()
        {
            TheGenericDataGridViewModel!.ExportGridToCsvCommand.Execute(null);
        }

        [TestCase]
        public void Test_ExportToCsv()
        {
            String csvOutputFile = @"D:\sample.txt";
            Encoding encoding = Encoding.UTF8;

            List<TModel> entities =
            [
                CreateBlankModel(1),
            ];

            DialogService.ShowSaveFileDialog(Arg.Any<Object>(), Arg.Any<SaveFileDialogSettings>())
                .Returns(DialogResult.Ok)
                .AndDoes(x =>
                {
                    ISaveFileDialogSettings saveFileDialogSettings = (ISaveFileDialogSettings)x[1];
                    saveFileDialogSettings.FileName = csvOutputFile;
                });

            TheGenericDataGridViewModel!.ExportGridToCsvCommand.Execute(entities);
            DialogService.Received(1).ShowSaveFileDialog(Arg.Any<Object>(), Arg.Any<SaveFileDialogSettings>());
            FileApi.Received(1).OpenFileForWriting(csvOutputFile, encoding);

            CommonBusinessProcess.Received(1).ExportToCsv(Arg.Any<TextWriter>(), Arg.Any<List<IGridColumnDefinition>>(), entities);
        }

        [TestCase]
        public void Test_CopyCellValue_Basic()
        {
            TheGenericDataGridViewModel!.CopyCellValueCommand.Execute(null);
            TheGenericDataGridViewModel!.CopyCellValueCommand.Execute(new Object());
        }

        [TestCase]
        public void Test_CopyCellValue_DataGridCell()
        {
            String expectedValue1 = Guid.NewGuid().ToString();

            TheGenericDataGridViewModel!.CopyCellValueCommand.Execute(expectedValue1);
            String actualValue = ClipBoardWrapper.GetText();
            Assert.That(Convert.ToString(actualValue), Is.EqualTo(expectedValue1));
        }

        [TestCase]
        public void Test_CopyCellValue_Boolean_True()
        {
            const Boolean expectedValue = true;
            TheGenericDataGridViewModel!.CopyCellValueCommand.Execute(expectedValue);
            String actualValue = ClipBoardWrapper.GetText();
            Assert.That(Convert.ToBoolean(actualValue), Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void Test_CopyCellValue_Boolean_False()
        {
            const Boolean expectedValue = false;
            TheGenericDataGridViewModel!.CopyCellValueCommand.Execute(expectedValue);
            String actualValue = ClipBoardWrapper.GetText();
            Assert.That(Convert.ToBoolean(actualValue), Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void Test_CopyCellValue_Boolean_TimeSpan()
        {
            const Int16 expected = 123;
            TheGenericDataGridViewModel!.CopyCellValueCommand.Execute(expected);
            String actualValue = ClipBoardWrapper.GetText();
            Assert.That(Convert.ToInt16(actualValue), Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_CopyCellValue_DateTime()
        {
            DateTime expected = new DateTime(2024, 3, 14, 20, 36, 15);
            TheGenericDataGridViewModel!.CopyCellValueCommand.Execute(expected);
            String actualValue = ClipBoardWrapper.GetText();
            Assert.That(Convert.ToDateTime(actualValue), Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_CopyCellValue_Guid()
        {
            Guid expected = Guid.NewGuid();
            TheGenericDataGridViewModel!.CopyCellValueCommand.Execute(expected);
            String actualValue = ClipBoardWrapper.GetText();
            Assert.That(Guid.Parse(actualValue), Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_CopyCellValue_Int16()
        {
            Int16 expected = Int16.MaxValue;
            TheGenericDataGridViewModel!.CopyCellValueCommand.Execute(expected);
            String actualValue = ClipBoardWrapper.GetText();
            Assert.That(Convert.ToInt16(actualValue), Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_CopyCellValue_UInt16()
        {
            UInt16 expected = UInt16.MaxValue;
            TheGenericDataGridViewModel!.CopyCellValueCommand.Execute(expected);
            String actualValue = ClipBoardWrapper.GetText();
            Assert.That(Convert.ToUInt16(actualValue), Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_CopyCellValue_Int32()
        {
            Int32 expected = Int32.MaxValue;
            TheGenericDataGridViewModel!.CopyCellValueCommand.Execute(expected);
            String actualValue = ClipBoardWrapper.GetText();
            Assert.That(Convert.ToInt32(actualValue), Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_CopyCellValue_UInt32()
        {
            UInt32 expected = UInt32.MaxValue;
            TheGenericDataGridViewModel!.CopyCellValueCommand.Execute(expected);
            String actualValue = ClipBoardWrapper.GetText();
            Assert.That(Convert.ToUInt32(actualValue), Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_CopyCellValue_Int64()
        {
            Int64 expected = Int64.MaxValue;
            TheGenericDataGridViewModel!.CopyCellValueCommand.Execute(expected);
            String actualValue = ClipBoardWrapper.GetText();
            Assert.That(Convert.ToInt64(actualValue), Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_CopyCellValue_UInt64()
        {
            UInt64 expected = UInt64.MaxValue;
            TheGenericDataGridViewModel!.CopyCellValueCommand.Execute(expected);
            String actualValue = ClipBoardWrapper.GetText();
            Assert.That(Convert.ToUInt64(actualValue), Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_CopyCellValue_Decimal()
        {
            Decimal expected = Decimal.MaxValue;
            TheGenericDataGridViewModel!.CopyCellValueCommand.Execute(expected);
            String actualValue = ClipBoardWrapper.GetText();
            Assert.That(Convert.ToDecimal(actualValue), Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_CopyCellValue_Double()
        {
            Double expected = 123456.798123d;
            TheGenericDataGridViewModel!.CopyCellValueCommand.Execute(expected);
            String actualValue = ClipBoardWrapper.GetText();
            Assert.That(Convert.ToDouble(actualValue), Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_CopyCellValue_Single()
        {
            Single expected = 123456.798123f;
            TheGenericDataGridViewModel!.CopyCellValueCommand.Execute(expected);
            String actualValue = ClipBoardWrapper.GetText();
            Assert.That(Convert.ToSingle(actualValue), Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_CopyCellValue_Char()
        {
            Char expected = Char.MaxValue;
            TheGenericDataGridViewModel!.CopyCellValueCommand.Execute(expected);
            String actualValue = ClipBoardWrapper.GetText();
            Assert.That(Convert.ToChar(actualValue), Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_CopyCellValue_String()
        {
            String expected = Guid.NewGuid().ToString();
            TheGenericDataGridViewModel!.CopyCellValueCommand.Execute(expected);
            String actualValue = ClipBoardWrapper.GetText();
            Assert.That(Convert.ToString(actualValue), Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_CopyCellValue_SByte()
        {
            SByte expected = SByte.MaxValue;
            TheGenericDataGridViewModel!.CopyCellValueCommand.Execute(expected);
            String actualValue = ClipBoardWrapper.GetText();
            Assert.That(Convert.ToSByte(actualValue), Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_CopyGridToCsvCommand_Null()
        {
            TheGenericDataGridViewModel!.CopyGridToCsvCommand.Execute(null);
        }

        [TestCase]
        public void Test_CopyGridToCsvCommand()
        {
            String expectedCsvData = Guid.NewGuid().ToString();
            List <TModel> entities =
            [
                CreateBlankModel(1),
                CreateBlankModel(2),
                CreateBlankModel(3),
            ];

            CommonBusinessProcess.ExportToCsv(Arg.Any<List<IGridColumnDefinition>>(), entities).Returns(expectedCsvData);

            TheGenericDataGridViewModel!.CopyGridToCsvCommand.Execute(entities);

            CommonBusinessProcess.Received(1).ExportToCsv(Arg.Any<List<IGridColumnDefinition>>(), entities);
            String actual = ClipBoardWrapper.GetText();

            Assert.That(actual, Is.EqualTo(expectedCsvData));
        }

        [TestCase]
        public void Test_CopyRowToCsvCommand_Null()
        {
            TheGenericDataGridViewModel!.CopyRowToCsvCommand.Execute(null);
        }

        [TestCase]
        public void Test_CopyRowToCsvCommand()
        {
            String expectedCsvData = Guid.NewGuid().ToString();
            TModel entity = CreateModel(1);

            CommonBusinessProcess.ExportToCsv(Arg.Any<List<IGridColumnDefinition>>(), Arg.Any<List<TModel>>()).Returns(expectedCsvData);

            TheGenericDataGridViewModel!.CopyRowToCsvCommand.Execute(entity);

            CommonBusinessProcess.Received(1).ExportToCsv(Arg.Any<List<IGridColumnDefinition>>(), Arg.Any<List<TModel>>());
            String actual = ClipBoardWrapper.GetText();

            Assert.That(actual, Is.EqualTo(expectedCsvData));
        }

        [TestCase]
        public virtual void Test_Refresh()
        {
            TheGenericDataGridViewModel!.RefreshCommandEnabled = true;

            SetupForRefreshData();

            TheGenericDataGridViewModel!.RefreshCommand.Execute(null);
        }

        [TestCase]
        public void Test_Refresh_Disabled()
        {
            TheGenericDataGridViewModel!.RefreshCommandEnabled = true;
            TheGenericDataGridViewModel!.RefreshCommandEnabled = false;

            SetupForRefreshData();

            TheGenericDataGridViewModel!.RefreshCommand.Execute(null);
        }

        [TestCase]
        public void Test_Refresh_CanExecute()
        {
            TModel entity = CreateModel(1);

            TheGenericDataGridViewModel!.RefreshCommandEnabled = true;
            Assert.That(TheGenericDataGridViewModel!.RefreshCommand.CanExecute(entity), Is.EqualTo(true));

            TheGenericDataGridViewModel!.RefreshCommandEnabled = false;
            Assert.That(TheGenericDataGridViewModel!.RefreshCommand.CanExecute(entity), Is.EqualTo(false));
        }

        [TestCase]
        public void Test_ViewRecord_Success()
        {
            TheGenericDataGridViewModel!.ViewRecordCommandEnabled = true;

            BusinessProcess.CanViewRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(true);

            TModel entity = CreateModel(1);
            TheGenericDataGridViewModel!.ViewRecordCommand.Execute(entity);
        }

        [TestCase]
        public void Test_ViewRecord_Disabled()
        {
            TheGenericDataGridViewModel!.ViewRecordCommandEnabled = true;
            TheGenericDataGridViewModel!.ViewRecordCommandEnabled = false;

            BusinessProcess.CanViewRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(true);

            TModel entity = CreateModel(1);
            TheGenericDataGridViewModel!.ViewRecordCommand.Execute(entity);
        }

        [TestCase]
        public void Test_ViewRecord_CanExecute()
        {
            TModel entity = CreateModel(1);

            TheGenericDataGridViewModel!.ViewRecordCommandEnabled = true;
            Assert.That(TheGenericDataGridViewModel!.ViewRecordCommand.CanExecute(entity), Is.EqualTo(true));

            TheGenericDataGridViewModel!.ViewRecordCommandEnabled = false;
            Assert.That(TheGenericDataGridViewModel!.ViewRecordCommand.CanExecute(entity), Is.EqualTo(false));
        }

        [TestCase]
        public void Test_ViewRecord_NullEntity()
        {
            TheGenericDataGridViewModel!.ViewRecordCommandEnabled = true;

            BusinessProcess.CanViewRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(true);

            TheGenericDataGridViewModel!.ViewRecordCommand.Execute(null);
        }

        [TestCase]
        public void Test_ViewRecord_NoPermissions()
        {
            String typeName = TheGenericDataGridViewModel!.GetType().ToString();
            String processName = $"{typeName}::OnViewRecordCommand_Execute";
            String requiredPermissions = $"{ApplicationRole.Reporter}";
            IFoundationModel model = CreateModel(1);
            String userCredentials = CoreInstance.CurrentLoggedOnUser.Username;
            String expectedErrorMessage = $"Application Id: '{TestingApplicationId}'. User: '{userCredentials}' does not have the required permissions. Required permission is: '{requiredPermissions}'";

            ApplicationPermissionsException actualException = Assert.Throws<ApplicationPermissionsException>(() =>
            {
                TheGenericDataGridViewModel!.ViewRecordCommandEnabled = true;
                BusinessProcess.CanViewRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(false);
                TheGenericDataGridViewModel!.ViewRecordCommand.Execute(model);
            });

            Assert.That(actualException.Message, Is.EqualTo(expectedErrorMessage));
            Assert.That(actualException.ProcessName, Is.EqualTo(processName));
            Assert.That(actualException.RequiredPermission, Is.EqualTo(requiredPermissions));
            Assert.That(actualException.UserCredentials, Is.EqualTo(userCredentials));
            Assert.That(actualException.FoundationModel, Is.EqualTo(model));
        }

        [TestCase]
        public void Test_AddRecord_Success()
        {
            TheGenericDataGridViewModel!.AddRecordCommandEnabled = true;

            BusinessProcess.CanAddRecord(Arg.Any<IUserProfile>()).Returns(true);

            TModel entity = CreateModel(1);
            TheGenericDataGridViewModel!.AddRecordCommand.Execute(entity);
        }

        [TestCase]
        public void Test_AddRecord_Disabled()
        {
            TheGenericDataGridViewModel!.AddRecordCommandEnabled = true;
            TheGenericDataGridViewModel!.AddRecordCommandEnabled = false;

            BusinessProcess.CanAddRecord(Arg.Any<IUserProfile>()).Returns(true);

            TModel entity = CreateModel(1);
            TheGenericDataGridViewModel!.AddRecordCommand.Execute(entity);
        }

        [TestCase]
        public void Test_AddRecord_CanExecute()
        {
            TModel entity = CreateModel(1);

            TheGenericDataGridViewModel!.AddRecordCommandEnabled = true;
            Assert.That(TheGenericDataGridViewModel!.AddRecordCommand.CanExecute(entity), Is.EqualTo(true));

            TheGenericDataGridViewModel!.AddRecordCommandEnabled = false;
            Assert.That(TheGenericDataGridViewModel!.AddRecordCommand.CanExecute(entity), Is.EqualTo(false));
        }

        [TestCase]
        public void Test_AddRecord_NullEntity()
        {
            TheGenericDataGridViewModel!.AddRecordCommandEnabled = true;

            BusinessProcess.CanAddRecord(Arg.Any<IUserProfile>()).Returns(true);

            TheGenericDataGridViewModel!.AddRecordCommand.Execute(null);
        }

        [TestCase]
        public void Test_AddRecord_NoPermissions()
        {
            String typeName = TheGenericDataGridViewModel!.GetType().ToString();
            String processName = $"{typeName}::OnAddRecordCommand_Execute";
            String requiredPermissions = $"{ApplicationRole.Creator}";
            const IFoundationModel? model = null;
            String userCredentials = CoreInstance.CurrentLoggedOnUser.Username;
            String expectedErrorMessage = $"Application Id: '{TestingApplicationId}'. User: '{userCredentials}' does not have the required permissions. Required permission is: '{requiredPermissions}'";

            ApplicationPermissionsException actualException = Assert.Throws<ApplicationPermissionsException>(() =>
            {
                TheGenericDataGridViewModel!.AddRecordCommandEnabled = true;
                BusinessProcess.CanAddRecord(Arg.Any<IUserProfile>()).Returns(false);
                TheGenericDataGridViewModel!.AddRecordCommand.Execute(model);
            });

            Assert.That(actualException.Message, Is.EqualTo(expectedErrorMessage));
            Assert.That(actualException.ProcessName, Is.EqualTo(processName));
            Assert.That(actualException.RequiredPermission, Is.EqualTo(requiredPermissions));
            Assert.That(actualException.UserCredentials, Is.EqualTo(userCredentials));
            Assert.That(actualException.FoundationModel, Is.EqualTo(model));
        }

        [TestCase]
        public void Test_EditRecord_Success()
        {
            TheGenericDataGridViewModel!.EditRecordCommandEnabled = true;

            BusinessProcess.CanEditRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(true);

            TModel entity = CreateModel(1);
            TheGenericDataGridViewModel!.EditRecordCommand.Execute(entity);
        }

        [TestCase]
        public void Test_EditRecord_Disabled()
        {
            TheGenericDataGridViewModel!.EditRecordCommandEnabled = true;
            TheGenericDataGridViewModel!.EditRecordCommandEnabled = false;

            BusinessProcess.CanEditRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(true);

            TModel entity = CreateModel(1);
            TheGenericDataGridViewModel!.EditRecordCommand.Execute(entity);
        }

        [TestCase]
        public void Test_EditRecord_CanExecute()
        {
            TModel entity = CreateModel(1);

            TheGenericDataGridViewModel!.EditRecordCommandEnabled = true;
            Assert.That(TheGenericDataGridViewModel!.EditRecordCommand.CanExecute(entity), Is.EqualTo(true));

            TheGenericDataGridViewModel!.EditRecordCommandEnabled = false;
            Assert.That(TheGenericDataGridViewModel!.EditRecordCommand.CanExecute(entity), Is.EqualTo(false));
        }

        [TestCase]
        public void Test_EditRecord_NullEntity()
        {
            TheGenericDataGridViewModel!.EditRecordCommandEnabled = true;

            BusinessProcess.CanEditRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(true);

            TheGenericDataGridViewModel!.EditRecordCommand.Execute(null);
        }

        [TestCase]
        public void Test_EditRecord_NoPermissions()
        {
            String typeName = TheGenericDataGridViewModel!.GetType().ToString();
            String processName = $"{typeName}::OnEditRecordCommand_Execute";
            String requiredPermissions = $"{ApplicationRole.OwnEditor}, {ApplicationRole.AllEditor}";
            IFoundationModel model = CreateModel(1);
            String userCredentials = CoreInstance.CurrentLoggedOnUser.Username;
            String expectedErrorMessage = $"Application Id: '{TestingApplicationId}'. User: '{userCredentials}' does not have the required permissions. Required permission is: '{requiredPermissions}'";

            ApplicationPermissionsException actualException = Assert.Throws<ApplicationPermissionsException>(() =>
            {
                TheGenericDataGridViewModel!.EditRecordCommandEnabled = true;
                BusinessProcess.CanEditRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(false);
                TheGenericDataGridViewModel!.EditRecordCommand.Execute(model);
            });

            Assert.That(actualException.Message, Is.EqualTo(expectedErrorMessage));
            Assert.That(actualException.ProcessName, Is.EqualTo(processName));
            Assert.That(actualException.RequiredPermission, Is.EqualTo(requiredPermissions));
            Assert.That(actualException.UserCredentials, Is.EqualTo(userCredentials));
            Assert.That(actualException.FoundationModel, Is.EqualTo(model));
        }

        [TestCase]
        public void Test_DeleteRecord_Success()
        {
            TheGenericDataGridViewModel!.DeleteRecordCommandEnabled = true;

            BusinessProcess.CanDeleteRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(true);

            TModel entity = CreateModel(1);
            TheGenericDataGridViewModel!.DeleteRecordCommand.Execute(entity);
        }

        [TestCase]
        public void Test_DeleteRecord_Disabled()
        {
            TheGenericDataGridViewModel!.DeleteRecordCommandEnabled = true;
            TheGenericDataGridViewModel!.DeleteRecordCommandEnabled = false;

            BusinessProcess.CanDeleteRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(true);

            TModel entity = CreateModel(1);
            TheGenericDataGridViewModel!.DeleteRecordCommand.Execute(entity);
        }

        [TestCase]
        public void Test_DeleteRecord_CanExecute()
        {
            TModel entity = CreateModel(1);

            TheGenericDataGridViewModel!.DeleteRecordCommandEnabled = true;
            Assert.That(TheGenericDataGridViewModel!.DeleteRecordCommand.CanExecute(entity), Is.EqualTo(true));

            TheGenericDataGridViewModel!.DeleteRecordCommandEnabled = false;
            Assert.That(TheGenericDataGridViewModel!.DeleteRecordCommand.CanExecute(entity), Is.EqualTo(false));
        }

        [TestCase]
        public void Test_DeleteRecord_NullEntity()
        {
            TheGenericDataGridViewModel!.DeleteRecordCommandEnabled = true;

            BusinessProcess.CanDeleteRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(true);

            TheGenericDataGridViewModel!.DeleteRecordCommand.Execute(null);
        }

        [TestCase]
        public void Test_DeleteRecord_NoPermissions()
        {
            String typeName = TheGenericDataGridViewModel!.GetType().ToString();
            String processName = $"{typeName}::OnDeleteRecordCommand_Execute";
            String requiredPermissions = $"{ApplicationRole.OwnDelete}, {ApplicationRole.AllDelete}";
            IFoundationModel model = CreateModel(1);
            String userCredentials = CoreInstance.CurrentLoggedOnUser.Username;
            String expectedErrorMessage = $"Application Id: '{TestingApplicationId}'. User: '{userCredentials}' does not have the required permissions. Required permission is: '{requiredPermissions}'";

            ApplicationPermissionsException actualException = Assert.Throws<ApplicationPermissionsException>(() =>
            {
                TheGenericDataGridViewModel!.DeleteRecordCommandEnabled = true;
                BusinessProcess.CanDeleteRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(false);
                TheGenericDataGridViewModel!.DeleteRecordCommand.Execute(model);
            });

            Assert.That(actualException.Message, Is.EqualTo(expectedErrorMessage));
            Assert.That(actualException.ProcessName, Is.EqualTo(processName));
            Assert.That(actualException.RequiredPermission, Is.EqualTo(requiredPermissions));
            Assert.That(actualException.UserCredentials, Is.EqualTo(userCredentials));
            Assert.That(actualException.FoundationModel, Is.EqualTo(model));
        }

        [TestCase]
        public void Test_DataGridColumns()
        {
            List<IGridColumnDefinition> expectedGridColumnDefinitions =
            [
                new GridColumnDefinition(),
            ];
            BusinessProcess.GetColumnDefinitions().Returns(expectedGridColumnDefinitions);

            ObservableCollection<IGridColumnDefinition> gridColumnDefinitions = TheGenericDataGridViewModel!.DataGridColumns;

            Assert.That(gridColumnDefinitions.Count, Is.EqualTo(expectedGridColumnDefinitions.Count));
            Assert.That(gridColumnDefinitions[0], Is.EqualTo(expectedGridColumnDefinitions[0]));
        }

        [TestCase]
        public void Test_GridExportColumns()
        {
            List<IGridColumnDefinition> expectedGridColumnDefinitions =
            [
                Substitute.For<IGridColumnDefinition>(),
            ];
            BusinessProcess.GetColumnDefinitions().Returns(expectedGridColumnDefinitions);

            List<IGridColumnDefinition> gridColumnDefinitions = TheGenericDataGridViewModel!.GridExportColumns.ToList();

            Assert.That(gridColumnDefinitions.Count, Is.EqualTo(expectedGridColumnDefinitions.Count));
            Assert.That(gridColumnDefinitions[0], Is.EqualTo(expectedGridColumnDefinitions[0]));
        }

        [TestCase]
        public void Test_InitialiseGenericDataGridViewModel()
        {
            SetupForRefreshData();

            const IWindow? targetWindow = null;
            const IViewModel? parentViewModel = null;
            String formTitle = String.Empty;

            TheGenericDataGridViewModel!.Initialise(targetWindow!, parentViewModel, formTitle);
        }
    }
}
