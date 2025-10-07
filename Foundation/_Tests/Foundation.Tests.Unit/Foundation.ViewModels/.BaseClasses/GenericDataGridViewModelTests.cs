//-----------------------------------------------------------------------
// <copyright file="GenericDataGridViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

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
        //protected String ExpectedScreenTitle => String.Empty;
        //protected override String ExpectedStatusBarText => "Number of rows:";

        protected TBusinessProcess BusinessProcess { get; private set; }

        protected abstract TBusinessProcess CreateBusinessProcess();
        //protected GenericDataGridViewModelBase<TModel> GenericDataGridViewModelBase { get; private set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            BusinessProcess = CreateBusinessProcess();
            //SetBusinessProcessProperties(BusinessProcess);

            TheViewModel = CreateViewModel();
            //GenericDataGridViewModelBase = TheViewModel as GenericDataGridViewModelBase<TModel>;
        }


        protected virtual TModel CreateBlankModel()
        {
            TModel retVal = CoreInstance.IoC.Get<TModel>();

            return retVal;
        }

        protected virtual TModel CreateModel()
        {
            TModel retVal = CreateBlankModel();

            retVal.EntityStatus = EntityStatus.Active;

            retVal.CreatedOn = CreatedOnDateTime;
            retVal.CreatedByUserProfileId = new EntityId(1);

            retVal.LastUpdatedOn = LastUpdatedOnDateTime;
            retVal.LastUpdatedByUserProfileId = new EntityId(2);

            retVal.ValidFrom = ValidFromDateTime;
            retVal.ValidTo = ValidToDateTime;

            return retVal;
        }


        //protected override void CheckBaseClassProperties(IMockFoundationModelViewModel viewModel)
        //{
        //    Assert.That(viewModel.CanViewRecord, Is.EqualTo(false));
        //    Assert.That(viewModel.ViewButtonVisible, Is.EqualTo(false));
        //    Assert.That(viewModel.ViewRecordCommand, Is.Not.EqualTo(null));
        //    Assert.That(viewModel.ViewRecordCommandEnabled, Is.EqualTo(false));

        //    Assert.That(viewModel.CanAddRecord, Is.EqualTo(false));
        //    Assert.That(viewModel.AddButtonVisible, Is.EqualTo(false));
        //    Assert.That(viewModel.AddRecordCommand, Is.Not.EqualTo(null));
        //    Assert.That(viewModel.AddRecordCommandEnabled, Is.EqualTo(false));

        //    Assert.That(viewModel.CanEditRecord, Is.EqualTo(false));
        //    Assert.That(viewModel.EditButtonVisible, Is.EqualTo(false));
        //    Assert.That(viewModel.EditRecordCommand, Is.Not.EqualTo(null));
        //    Assert.That(viewModel.EditRecordCommandEnabled, Is.EqualTo(false));

        //    Assert.That(viewModel.CanDeleteRecord, Is.EqualTo(false));
        //    Assert.That(viewModel.DeleteButtonVisible, Is.EqualTo(false));
        //    Assert.That(viewModel.DeleteRecordCommand, Is.Not.EqualTo(null));
        //    Assert.That(viewModel.DeleteRecordCommandEnabled, Is.EqualTo(false));

        //    Assert.That(viewModel.ActionsVisible, Is.EqualTo(false));
        //    Assert.That(viewModel.FiltersVisible, Is.EqualTo(false));
        //}

        //protected virtual String ExpectedStatusBarText { get; } = String.Empty;

        //protected virtual Boolean ExpectedCanRefreshData { get; } = true;
        //protected virtual Boolean ExpectedRefreshButtonVisible { get; } = true;
        //protected virtual Boolean ExpectedRefreshButtonEnabled { get; } = true;
        //protected virtual Boolean ExpectedCanViewRecord { get; } = false;
        //protected virtual Boolean ExpectedViewButtonVisible { get; } = false;
        //protected virtual Boolean ExpectedViewButtonEnabled { get; } = false;
        //protected virtual Boolean ExpectedCanAddRecord { get; } = false;
        //protected virtual Boolean ExpectedAddButtonVisible { get; } = false;
        //protected virtual Boolean ExpectedAddButtonEnabled { get; } = false;
        //protected virtual Boolean ExpectedCanEditRecord { get; } = false;
        //protected virtual Boolean ExpectedEditButtonVisible { get; } = false;
        //protected virtual Boolean ExpectedEditButtonEnabled { get; } = false;
        //protected virtual Boolean ExpectedCanDeleteRecord { get; } = false;
        //protected virtual Boolean ExpectedDeleteButtonVisible { get; } = false;
        //protected virtual Boolean ExpectedDeleteButtonEnabled { get; } = false;


        //protected virtual Boolean ExpectedHasOptionalAction1 { get; } = false;
        //protected virtual Boolean ExpectedAction1Enabled { get; } = false;
        //protected virtual String ExpectedAction1Name { get; } = "Action1";
        //protected virtual Boolean ExpectedHasOptionalDropDownParameter1 { get; } = false;
        //protected virtual String ExpectedFilter1Name { get; } = "Filter1";
        //protected virtual String ExpectedFilter1DisplayMemberPath { get; } = String.Empty;
        //protected virtual String ExpectedFilter1SelectedValuePath { get; } = FDC.FoundationEntity.Id;

        //protected virtual Boolean ExpectedHasOptionalAction2 { get; } = false;
        //protected virtual Boolean ExpectedAction2Enabled { get; } = false;
        //protected virtual String ExpectedAction2Name { get; } = "Action2";
        //protected virtual Boolean ExpectedHasOptionalDropDownParameter2 { get; } = false;
        //protected virtual String ExpectedFilter2Name { get; } = "Filter2";
        //protected virtual String ExpectedFilter2DisplayMemberPath { get; } = String.Empty;
        //protected virtual String ExpectedFilter2SelectedValuePath { get; } = FDC.FoundationEntity.Id;

        //protected virtual Boolean ExpectedHasOptionalAction3 { get; } = false;
        //protected virtual Boolean ExpectedAction3Enabled { get; } = false;
        //protected virtual String ExpectedAction3Name { get; } = "Action3";
        //protected virtual Boolean ExpectedHasOptionalDropDownParameter3 { get; } = false;
        //protected virtual String ExpectedFilter3Name { get; } = "Filter3";
        //protected virtual String ExpectedFilter3DisplayMemberPath { get; } = String.Empty;
        //protected virtual String ExpectedFilter3SelectedValuePath { get; } = FDC.FoundationEntity.Id;

        //protected virtual Boolean ExpectedHasOptionalAction4 { get; } = false;
        //protected virtual Boolean ExpectedAction4Enabled { get; } = false;
        //protected virtual String ExpectedAction4Name { get; } = "Action4";
        //protected virtual Boolean ExpectedHasOptionalDropDownParameter4 { get; } = false;
        //protected virtual String ExpectedFilter4Name { get; } = "Filter4";
        //protected virtual String ExpectedFilter4DisplayMemberPath { get; } = String.Empty;
        //protected virtual String ExpectedFilter4SelectedValuePath { get; } = FDC.FoundationEntity.Id;


        //protected void SetBusinessProcessProperties(TBusinessProcess businessProcess)
        //{
        //    TBusinessProcess tempProcess = CoreInstance.IoC.Get<TBusinessProcess>();

        //    ExpectedScreenTitle = tempProcess.ScreenTitle;

        //    businessProcess.AllId.Returns(tempProcess.AllId);
        //    businessProcess.AllText.Returns(tempProcess.AllText);

        //    businessProcess.NoneId.Returns(tempProcess.NoneId);
        //    businessProcess.NoneText.Returns(tempProcess.NoneText);

        //    businessProcess.NullId.Returns(tempProcess.NoneId);

        //    businessProcess.ScreenTitle.Returns(tempProcess.ScreenTitle);
        //    businessProcess.StatusBarText.Returns(tempProcess.StatusBarText);

        //    businessProcess.ComboBoxDisplayMember.Returns(tempProcess.ComboBoxDisplayMember);
        //    businessProcess.ComboBoxValueMember.Returns(tempProcess.ComboBoxValueMember);

        //    businessProcess.HasOptionalAction1.Returns(tempProcess.HasOptionalAction1);
        //    businessProcess.Action1Name.Returns(tempProcess.Action1Name);

        //    businessProcess.HasOptionalAction2.Returns(tempProcess.HasOptionalAction2);
        //    businessProcess.Action2Name.Returns(tempProcess.Action2Name);

        //    businessProcess.HasOptionalAction3.Returns(tempProcess.HasOptionalAction3);
        //    businessProcess.Action3Name.Returns(tempProcess.Action3Name);

        //    businessProcess.HasOptionalAction4.Returns(tempProcess.HasOptionalAction4);
        //    businessProcess.Action4Name.Returns(tempProcess.Action4Name);

        //    businessProcess.HasOptionalDropDownParameter1.Returns(tempProcess.HasOptionalDropDownParameter1);
        //    businessProcess.Filter1Name.Returns(tempProcess.Filter1Name);
        //    businessProcess.Filter1DisplayMemberPath.Returns(tempProcess.Filter1DisplayMemberPath);
        //    businessProcess.Filter1SelectedValuePath.Returns(tempProcess.Filter1SelectedValuePath);

        //    businessProcess.HasOptionalDropDownParameter2.Returns(tempProcess.HasOptionalDropDownParameter2);
        //    businessProcess.Filter2Name.Returns(tempProcess.Filter2Name);
        //    businessProcess.Filter2DisplayMemberPath.Returns(tempProcess.Filter2DisplayMemberPath);
        //    businessProcess.Filter2SelectedValuePath.Returns(tempProcess.Filter2SelectedValuePath);

        //    businessProcess.HasOptionalDropDownParameter3.Returns(tempProcess.HasOptionalDropDownParameter3);
        //    businessProcess.Filter3Name.Returns(tempProcess.Filter3Name);
        //    businessProcess.Filter3DisplayMemberPath.Returns(tempProcess.Filter3DisplayMemberPath);
        //    businessProcess.Filter3SelectedValuePath.Returns(tempProcess.Filter3SelectedValuePath);

        //    businessProcess.HasOptionalDropDownParameter4.Returns(tempProcess.HasOptionalDropDownParameter4);
        //    businessProcess.Filter4Name.Returns(tempProcess.Filter4Name);
        //    businessProcess.Filter4DisplayMemberPath.Returns(tempProcess.Filter4DisplayMemberPath);
        //    businessProcess.Filter4SelectedValuePath.Returns(tempProcess.Filter4SelectedValuePath);

        //    businessProcess.CanRefreshData().Returns(tempProcess.CanRefreshData());
        //    businessProcess.CanAddRecord().Returns(tempProcess.CanAddRecord());
        //    businessProcess.CanViewRecord().Returns(tempProcess.CanViewRecord());
        //    businessProcess.CanEditRecord().Returns(tempProcess.CanEditRecord());
        //    businessProcess.CanDeleteRecord().Returns(tempProcess.CanDeleteRecord());
        //}

        //protected override void InitialiseViewModel()
        //{
        //    base.InitialiseViewModel();

        //    SetupForRefreshData();
        //}

        //protected virtual void SetupForRefreshData()
        //{
        //    List<TModel> entities = new List<TModel>();
        //    BusinessProcess.GetAll().Returns(entities);
        //}

        //protected virtual void CheckAction1Properties(TGenericDataGridViewModel viewModel)
        //{
        //    GenericDataGridViewModelBase<TModel> genericDataGridViewModelBase = viewModel as GenericDataGridViewModelBase<TModel>;

        //    Assert.That(ViewModel.HasOptionalAction1, Is.EqualTo(ExpectedHasOptionalAction1));
        //    Assert.That(ViewModel.Action1Name, Is.EqualTo(ExpectedAction1Name));
        //    Assert.That(ViewModel.Action1Command, Is.Not.Null);
        //    Assert.That(ViewModel.Action1Command, Is.InstanceOf<RelayCommand<Object>>());

        //    Assert.That(ViewModel.Action1CommandEnabled, Is.EqualTo(ExpectedAction1Enabled));
        //    Assert.That(ViewModel.Action1Command.CanExecute(null), Is.EqualTo(ExpectedAction1Enabled));

        //    genericDataGridViewModelBase.Action1CommandEnabled = false;
        //    Assert.That(ViewModel.Action1CommandEnabled, Is.EqualTo(false));
        //    Assert.That(ViewModel.Action1Command.CanExecute(null), Is.EqualTo(false));

        //    genericDataGridViewModelBase.Action1CommandEnabled = true;
        //    Assert.That(ViewModel.Action1CommandEnabled, Is.EqualTo(true));
        //    Assert.That(ViewModel.Action1Command.CanExecute(null), Is.EqualTo(true));
        //}

        //protected virtual Object SetupForAction1Command(TGenericDataGridViewModel viewModel)
        //{
        //    Object retVal = new Object();

        //    return retVal;
        //}

        //protected virtual void AssertForAction1Command(TGenericDataGridViewModel viewModel)
        //{
        //    // Does nothing
        //}

        //protected virtual void CheckAction2Properties(TGenericDataGridViewModel viewModel)
        //{
        //    GenericDataGridViewModelBase<TModel> genericDataGridViewModelBase = viewModel as GenericDataGridViewModelBase<TModel>;

        //    Assert.That(ViewModel.HasOptionalAction2, Is.EqualTo(ExpectedHasOptionalAction2));
        //    Assert.That(ViewModel.Action2Name, Is.EqualTo(ExpectedAction2Name));
        //    Assert.That(ViewModel.Action2Command, Is.Not.Null);
        //    Assert.That(ViewModel.Action2Command, Is.InstanceOf<RelayCommand<Object>>());

        //    Assert.That(ViewModel.Action2CommandEnabled, Is.EqualTo(ExpectedAction2Enabled));
        //    Assert.That(ViewModel.Action2Command.CanExecute(null), Is.EqualTo(ExpectedAction2Enabled));

        //    genericDataGridViewModelBase.Action2CommandEnabled = false;
        //    Assert.That(ViewModel.Action2CommandEnabled, Is.EqualTo(false));
        //    Assert.That(ViewModel.Action2Command.CanExecute(null), Is.EqualTo(false));

        //    genericDataGridViewModelBase.Action2CommandEnabled = true;
        //    Assert.That(ViewModel.Action2CommandEnabled, Is.EqualTo(true));
        //    Assert.That(ViewModel.Action2Command.CanExecute(null), Is.EqualTo(true));
        //}

        //protected virtual Object SetupForAction2Command(TGenericDataGridViewModel viewModel)
        //{
        //    Object retVal = new Object();

        //    return retVal;
        //}

        //protected virtual void AssertForAction2Command(TGenericDataGridViewModel viewModel)
        //{
        //    // Does nothing
        //}

        //protected virtual void CheckAction3Properties(TGenericDataGridViewModel viewModel)
        //{
        //    GenericDataGridViewModelBase<TModel> genericDataGridViewModelBase = viewModel as GenericDataGridViewModelBase<TModel>;

        //    Assert.That(ViewModel.HasOptionalAction3, Is.EqualTo(ExpectedHasOptionalAction3));
        //    Assert.That(ViewModel.Action3Name, Is.EqualTo(ExpectedAction3Name));
        //    Assert.That(ViewModel.Action3Command, Is.Not.Null);
        //    Assert.That(ViewModel.Action3Command, Is.InstanceOf<RelayCommand<Object>>());

        //    Assert.That(ViewModel.Action3CommandEnabled, Is.EqualTo(ExpectedAction3Enabled));
        //    Assert.That(ViewModel.Action3Command.CanExecute(null), Is.EqualTo(ExpectedAction3Enabled));

        //    genericDataGridViewModelBase.Action3CommandEnabled = false;
        //    Assert.That(ViewModel.Action3CommandEnabled, Is.EqualTo(false));
        //    Assert.That(ViewModel.Action3Command.CanExecute(null), Is.EqualTo(false));

        //    genericDataGridViewModelBase.Action3CommandEnabled = true;
        //    Assert.That(ViewModel.Action3CommandEnabled, Is.EqualTo(true));
        //    Assert.That(ViewModel.Action3Command.CanExecute(null), Is.EqualTo(true));
        //}

        //protected virtual Object SetupForAction3Command(TGenericDataGridViewModel viewModel)
        //{
        //    Object retVal = new Object();

        //    return retVal;
        //}

        //protected virtual void AssertForAction3Command(TGenericDataGridViewModel viewModel)
        //{
        //    // Does nothing
        //}

        //protected virtual void CheckAction4Properties(TGenericDataGridViewModel viewModel)
        //{
        //    GenericDataGridViewModelBase<TModel> genericDataGridViewModelBase = viewModel as GenericDataGridViewModelBase<TModel>;

        //    Assert.That(ViewModel.HasOptionalAction4, Is.EqualTo(ExpectedHasOptionalAction4));
        //    Assert.That(ViewModel.Action4Name, Is.EqualTo(ExpectedAction4Name));
        //    Assert.That(ViewModel.Action4Command, Is.Not.Null);
        //    Assert.That(ViewModel.Action4Command, Is.InstanceOf<RelayCommand<Object>>());

        //    Assert.That(ViewModel.Action4CommandEnabled, Is.EqualTo(ExpectedAction4Enabled));
        //    Assert.That(ViewModel.Action4Command.CanExecute(null), Is.EqualTo(ExpectedAction4Enabled));

        //    genericDataGridViewModelBase.Action4CommandEnabled = false;
        //    Assert.That(ViewModel.Action4CommandEnabled, Is.EqualTo(false));
        //    Assert.That(ViewModel.Action4Command.CanExecute(null), Is.EqualTo(false));

        //    genericDataGridViewModelBase.Action4CommandEnabled = true;
        //    Assert.That(ViewModel.Action4CommandEnabled, Is.EqualTo(true));
        //    Assert.That(ViewModel.Action4Command.CanExecute(null), Is.EqualTo(true));
        //}

        //protected virtual Object SetupForAction4Command(TGenericDataGridViewModel viewModel)
        //{
        //    Object retVal = new Object();

        //    return retVal;
        //}

        //protected virtual void AssertForAction4Command(TGenericDataGridViewModel viewModel)
        //{
        //    // Does nothing
        //}

        //protected virtual Object CreateModelForDropDown1()
        //{
        //    return new Object();
        //}

        //protected virtual List<Object> SetupForDropDown1DataSource()
        //{
        //    List<Object> retVal = new List<Object>
        //    {
        //        CreateModelForDropDown1(),
        //        CreateModelForDropDown1(),
        //        CreateModelForDropDown1(),
        //    };

        //    return retVal;
        //}

        //protected virtual void CheckDropDown1Properties(TGenericDataGridViewModel viewModel)
        //{
        //    GenericDataGridViewModelBase<TModel> genericDataGridViewModelBase = viewModel as GenericDataGridViewModelBase<TModel>;

        //    Assert.That(ViewModel.HasOptionalDropDownParameter1, Is.EqualTo(ExpectedHasOptionalDropDownParameter1));
        //    Assert.That(ViewModel.Filter1Name, Is.EqualTo(ExpectedFilter1Name));
        //    Assert.That(ViewModel.Filter1DisplayMemberPath, Is.EqualTo(ExpectedFilter1DisplayMemberPath));
        //    Assert.That(ViewModel.Filter1SelectedValuePath, Is.EqualTo(ExpectedFilter1SelectedValuePath));
        //    Assert.That(ViewModel.Filter1SelectionChangedCommand, Is.Not.Null);
        //    Assert.That(ViewModel.Filter1SelectionChangedCommand, Is.InstanceOf<RelayCommand<Object>>());
        //    Assert.That(ViewModel.Filter1DataSource, Is.Null);
        //    Assert.That(ViewModel.Filter1SelectedItem, Is.Null);

        //    List<Object> entities = SetupForDropDown1DataSource();
        //    genericDataGridViewModelBase.Filter1DataSource = entities;
        //    Assert.That(genericDataGridViewModelBase.Filter1DataSource, Is.EqualTo(entities));

        //    viewModel.Filter1SelectedItem = entities[0];
        //    Assert.That(ViewModel.Filter1SelectedItem, Is.EqualTo(entities[0]));
        //}

        //protected virtual Object CreateModelForDropDown2()
        //{
        //    return new Object();
        //}

        //protected virtual List<Object> SetupForDropDown2DataSource()
        //{
        //    List<Object> retVal = new List<Object>
        //    {
        //        CreateModelForDropDown1(),
        //        CreateModelForDropDown1(),
        //        CreateModelForDropDown1(),
        //    };

        //    return retVal;
        //}

        //protected virtual void CheckDropDown2Properties(TGenericDataGridViewModel viewModel)
        //{
        //    GenericDataGridViewModelBase<TModel> genericDataGridViewModelBase = viewModel as GenericDataGridViewModelBase<TModel>;

        //    Assert.That(ViewModel.HasOptionalDropDownParameter2, Is.EqualTo(ExpectedHasOptionalDropDownParameter2));
        //    Assert.That(ViewModel.Filter2Name, Is.EqualTo(ExpectedFilter2Name));
        //    Assert.That(ViewModel.Filter2DisplayMemberPath, Is.EqualTo(ExpectedFilter2DisplayMemberPath));
        //    Assert.That(ViewModel.Filter2SelectedValuePath, Is.EqualTo(ExpectedFilter2SelectedValuePath));
        //    Assert.That(ViewModel.Filter2SelectionChangedCommand, Is.Not.Null);
        //    Assert.That(ViewModel.Filter2SelectionChangedCommand, Is.InstanceOf<RelayCommand<Object>>());
        //    Assert.That(ViewModel.Filter2DataSource, Is.Null);
        //    Assert.That(ViewModel.Filter2SelectedItem, Is.Null);

        //    List<Object> entities = SetupForDropDown2DataSource();
        //    genericDataGridViewModelBase.Filter2DataSource = entities;
        //    Assert.That(genericDataGridViewModelBase.Filter2DataSource, Is.EqualTo(entities));

        //    viewModel.Filter2SelectedItem = entities[0];
        //    Assert.That(ViewModel.Filter2SelectedItem, Is.EqualTo(entities[0]));
        //}

        //protected virtual Object CreateModelForDropDown3()
        //{
        //    return new Object();
        //}

        //protected virtual List<Object> SetupForDropDown3DataSource()
        //{
        //    List<Object> retVal = new List<Object>
        //    {
        //        CreateModelForDropDown3(),
        //        CreateModelForDropDown3(),
        //        CreateModelForDropDown3(),
        //    };

        //    return retVal;
        //}

        //protected virtual void CheckDropDown3Properties(TGenericDataGridViewModel viewModel)
        //{
        //    GenericDataGridViewModelBase<TModel> genericDataGridViewModelBase = viewModel as GenericDataGridViewModelBase<TModel>;

        //    Assert.That(ViewModel.HasOptionalDropDownParameter3, Is.EqualTo(ExpectedHasOptionalDropDownParameter3));
        //    Assert.That(ViewModel.Filter3Name, Is.EqualTo(ExpectedFilter3Name));
        //    Assert.That(ViewModel.Filter3DisplayMemberPath, Is.EqualTo(ExpectedFilter3DisplayMemberPath));
        //    Assert.That(ViewModel.Filter3SelectedValuePath, Is.EqualTo(ExpectedFilter3SelectedValuePath));
        //    Assert.That(ViewModel.Filter3SelectionChangedCommand, Is.Not.Null);
        //    Assert.That(ViewModel.Filter3SelectionChangedCommand, Is.InstanceOf<RelayCommand<Object>>());
        //    Assert.That(ViewModel.Filter3DataSource, Is.Null);
        //    Assert.That(ViewModel.Filter3SelectedItem, Is.Null);

        //    List<Object> entities = SetupForDropDown3DataSource();
        //    genericDataGridViewModelBase.Filter3DataSource = entities;
        //    Assert.That(genericDataGridViewModelBase.Filter3DataSource, Is.EqualTo(entities));

        //    viewModel.Filter3SelectedItem = entities[0];
        //    Assert.That(ViewModel.Filter3SelectedItem, Is.EqualTo(entities[0]));
        //}

        //protected virtual Object CreateModelForDropDown4()
        //{
        //    return new Object();
        //}

        //protected virtual List<Object> SetupForDropDown4DataSource()
        //{
        //    List<Object> retVal = new List<Object>
        //    {
        //        CreateModelForDropDown4(),
        //        CreateModelForDropDown4(),
        //        CreateModelForDropDown4(),
        //    };

        //    return retVal;
        //}

        //protected virtual void CheckDropDown4Properties(TGenericDataGridViewModel viewModel)
        //{
        //    GenericDataGridViewModelBase<TModel> genericDataGridViewModelBase = viewModel as GenericDataGridViewModelBase<TModel>;

        //    Assert.That(ViewModel.HasOptionalDropDownParameter4, Is.EqualTo(ExpectedHasOptionalDropDownParameter4));
        //    Assert.That(ViewModel.Filter4Name, Is.EqualTo(ExpectedFilter4Name));
        //    Assert.That(ViewModel.Filter4DisplayMemberPath, Is.EqualTo(ExpectedFilter4DisplayMemberPath));
        //    Assert.That(ViewModel.Filter4SelectedValuePath, Is.EqualTo(ExpectedFilter4SelectedValuePath));
        //    Assert.That(ViewModel.Filter4SelectionChangedCommand, Is.Not.Null);
        //    Assert.That(ViewModel.Filter4SelectionChangedCommand, Is.InstanceOf<RelayCommand<Object>>());
        //    Assert.That(ViewModel.Filter4DataSource, Is.Null);
        //    Assert.That(ViewModel.Filter4SelectedItem, Is.Null);

        //    List<Object> entities = SetupForDropDown4DataSource();
        //    genericDataGridViewModelBase.Filter4DataSource = entities;
        //    Assert.That(genericDataGridViewModelBase.Filter4DataSource, Is.EqualTo(entities));

        //    viewModel.Filter4SelectedItem = entities[0];
        //    Assert.That(ViewModel.Filter4SelectedItem, Is.EqualTo(entities[0]));
        //}

        //[TestCase]
        //public void Test_BaseClassProperties()
        //{
        //    CheckBaseClassProperties(ViewModel);

        //    Assert.That(ViewModel.FormTitle, Is.EqualTo(ExpectedScreenTitle));
        //    Assert.That(ViewModel.StatusBarText, Is.EqualTo(ExpectedStatusBarText));

        //    Assert.That(ViewModel.CanRefreshData, Is.EqualTo(ExpectedCanRefreshData));
        //    Assert.That(ViewModel.RefreshButtonVisible, Is.EqualTo(ExpectedRefreshButtonVisible));
        //    Assert.That(ViewModel.RefreshCommand, Is.Not.Null);
        //    Assert.That(ViewModel.RefreshCommandEnabled, Is.EqualTo(ExpectedRefreshButtonEnabled));

        //    Assert.That(ViewModel.CanViewRecord, Is.EqualTo(ExpectedCanViewRecord));
        //    Assert.That(ViewModel.ViewButtonVisible, Is.EqualTo(ExpectedViewButtonVisible));
        //    Assert.That(ViewModel.ViewRecordCommand, Is.Not.Null);
        //    Assert.That(ViewModel.ViewRecordCommandEnabled, Is.EqualTo(ExpectedViewButtonEnabled));

        //    Assert.That(ViewModel.CanAddRecord, Is.EqualTo(ExpectedCanAddRecord));
        //    Assert.That(ViewModel.AddButtonVisible, Is.EqualTo(ExpectedAddButtonVisible));
        //    Assert.That(ViewModel.AddRecordCommand, Is.Not.Null);
        //    Assert.That(ViewModel.AddRecordCommandEnabled, Is.EqualTo(ExpectedAddButtonEnabled));

        //    Assert.That(ViewModel.CanEditRecord, Is.EqualTo(ExpectedCanEditRecord));
        //    Assert.That(ViewModel.EditButtonVisible, Is.EqualTo(ExpectedEditButtonVisible));
        //    Assert.That(ViewModel.EditRecordCommand, Is.Not.Null);
        //    Assert.That(ViewModel.EditRecordCommandEnabled, Is.EqualTo(ExpectedEditButtonEnabled));

        //    Assert.That(ViewModel.CanDeleteRecord, Is.EqualTo(ExpectedCanDeleteRecord));
        //    Assert.That(ViewModel.DeleteButtonVisible, Is.EqualTo(ExpectedDeleteButtonVisible));
        //    Assert.That(ViewModel.DeleteRecordCommand, Is.Not.Null);
        //    Assert.That(ViewModel.DeleteRecordCommandEnabled, Is.EqualTo(ExpectedDeleteButtonEnabled));

        //    Assert.That(ViewModel.ActionsVisible, Is.EqualTo(ExpectedHasOptionalAction1|| ExpectedHasOptionalAction2 || ExpectedHasOptionalAction3 || ExpectedHasOptionalAction4));
        //    Assert.That(ViewModel.FiltersVisible, Is.EqualTo(ExpectedHasOptionalDropDownParameter1 || ExpectedHasOptionalDropDownParameter2 || ExpectedHasOptionalDropDownParameter3 || ExpectedHasOptionalDropDownParameter4));

        //    CheckAction1Properties(ViewModel);
        //    CheckAction2Properties(ViewModel);
        //    CheckAction3Properties(ViewModel);
        //    CheckAction4Properties(ViewModel);

        //    CheckDropDown1Properties(ViewModel);
        //    CheckDropDown2Properties(ViewModel);
        //    CheckDropDown3Properties(ViewModel);
        //    CheckDropDown4Properties(ViewModel);

        //    Assert.That(ViewModel.GridDataSource, Is.Null);
        //}

        //[TestCase]
        //public void Test_SelectedItem()
        //{
        //    Assert.That(ViewModel.SelectedItem, Is.Null);

        //    TModel entity1 = CreateModel();
        //    GenericDataGridViewModelBase.SelectedItem = entity1;

        //    Assert.That(ViewModel.SelectedItem, Is.EqualTo(entity1));
        //}

        //[TestCase]
        //public void Test_ExecuteAction1_Null()
        //{
        //    SetupForAction1Command(ViewModel);
        //    ViewModel.Action1Command.Execute(null);
        //}

        //[TestCase]
        //public void Test_ExecuteAction1_Object()
        //{
        //    Object obj = SetupForAction1Command(ViewModel);
        //    ViewModel.Action1Command.Execute(obj);
        //}

        //[TestCase]
        //public void Test_ExecuteAction2_Null()
        //{
        //    SetupForAction2Command(ViewModel);
        //    ViewModel.Action2Command.Execute(null);
        //}

        //[TestCase]
        //public void Test_ExecuteAction2_Object()
        //{
        //    Object obj = SetupForAction2Command(ViewModel);
        //    ViewModel.Action2Command.Execute(obj);
        //}

        //[TestCase]
        //public void Test_ExecuteAction3_Null()
        //{
        //    SetupForAction3Command(ViewModel);
        //    ViewModel.Action3Command.Execute(null);
        //}

        //[TestCase]
        //public void Test_ExecuteAction3_Object()
        //{
        //    Object obj = SetupForAction3Command(ViewModel);
        //    ViewModel.Action3Command.Execute(obj);
        //}

        //[TestCase]
        //public void Test_ExecuteAction4_Null()
        //{
        //    SetupForAction4Command(ViewModel);
        //    ViewModel.Action4Command.Execute(null);
        //}

        //[TestCase]
        //public void Test_ExecuteAction4_Object()
        //{
        //    Object obj = SetupForAction4Command(ViewModel);
        //    ViewModel.Action4Command.Execute(obj);
        //}

        //[TestCase]
        //public void Test_Filter1SelectionChanged()
        //{
        //    ViewModel.Filter1SelectionChangedCommand.Execute(null);
        //    ViewModel.Filter1SelectionChangedCommand.Execute(new Object());
        //}

        //[TestCase]
        //public void Test_Filter2SelectionChanged()
        //{
        //    ViewModel.Filter2SelectionChangedCommand.Execute(null);
        //    ViewModel.Filter2SelectionChangedCommand.Execute(new Object());
        //}

        //[TestCase]
        //public void Test_Filter3SelectionChanged()
        //{
        //    ViewModel.Filter3SelectionChangedCommand.Execute(null);
        //    ViewModel.Filter3SelectionChangedCommand.Execute(new Object());
        //}

        //[TestCase]
        //public void Test_Filter4SelectionChanged()
        //{
        //    ViewModel.Filter4SelectionChangedCommand.Execute(null);
        //    ViewModel.Filter4SelectionChangedCommand.Execute(new Object());
        //}

        //[TestCase]
        //public void Test_SelectedGridItemChanged()
        //{
        //    ViewModel.SelectedGridItemChangedCommand.Execute(null);

        //    TModel entity = CreateModel();
        //    ViewModel.SelectedGridItemChangedCommand.Execute(entity);
        //}

        //[TestCase]
        //public void Test_ExportToExcel()
        //{
        //    List<TModel> entities = new List<TModel>();
        //    ViewModel.ExportGridToExcelCommand.Execute(entities);
        //}

        //[TestCase]
        //public void Test_ExportToCsv()
        //{
        //    const String csvOutputFile = @"D:\sample.txt";
        //    ViewModel.ExportGridToCsvCommand.Execute(null);

        //    List<TModel> entities = new List<TModel>
        //    {
        //        CreateBlankModel(),
        //        CreateBlankModel(),
        //        CreateBlankModel(),
        //    };

        //    DialogService.ShowSaveFileDialog(Arg.Any<Object>(), Arg.Any<SaveFileDialogSettings>())
        //        .Returns(DialogResult.Ok)
        //        .AndDoes(x =>
        //        {
        //            ISaveFileDialogSettings saveFileDialogSettings = (ISaveFileDialogSettings)x[1];
        //            saveFileDialogSettings.FileName = csvOutputFile;
        //        });

        //    ViewModel.ExportGridToCsvCommand.Execute(entities);

        //    File.Delete(csvOutputFile);
        //}

        //[TestCase]
        //public void Test_CopyCellValue_Basic()
        //{
        //    ViewModel.CopyCellValueCommand.Execute(null);
        //    ViewModel.CopyCellValueCommand.Execute(new Object());
        //}

        //[TestCase]
        //public void Test_CopyCellValue_DataGridCell()
        //{
        //    String expectedValue1 = Guid.NewGuid().ToString();

        //    ViewModel.CopyCellValueCommand.Execute(expectedValue1);
        //    String actualValue = ClipBoardWrapper.GetText();
        //    Assert.That(Convert.ToString(actualValue), Is.EqualTo(expectedValue1));
        //}

        //[TestCase]
        //public void Test_CopyCellValue_Boolean_True()
        //{
        //    const Boolean expectedValue = true;
        //    ViewModel.CopyCellValueCommand.Execute(expectedValue);
        //    String actualValue = ClipBoardWrapper.GetText();
        //    Assert.That(Convert.ToBoolean(actualValue), Is.EqualTo(expectedValue));
        //}

        //[TestCase]
        //public void Test_CopyCellValue_Boolean_False()
        //{
        //    const Boolean expectedValue = false;
        //    ViewModel.CopyCellValueCommand.Execute(expectedValue);
        //    String actualValue = ClipBoardWrapper.GetText();
        //    Assert.That(Convert.ToBoolean(actualValue), Is.EqualTo(expectedValue));
        //}

        //[TestCase]
        //public void Test_CopyCellValue_Boolean_TimeSpan()
        //{
        //    const Int16 expected = 123;
        //    ViewModel.CopyCellValueCommand.Execute(expected);
        //    String actualValue = ClipBoardWrapper.GetText();
        //    Assert.That(Convert.ToInt16(actualValue), Is.EqualTo(expected));
        //}

        //[TestCase]
        //public void Test_CopyCellValue_DateTime()
        //{
        //    DateTime expected = new DateTime(2024, 3, 14, 20, 36, 15);
        //    ViewModel.CopyCellValueCommand.Execute(expected);
        //    String actualValue = ClipBoardWrapper.GetText();
        //    Assert.That(Convert.ToDateTime(actualValue), Is.EqualTo(expected));
        //}

        //[TestCase]
        //public void Test_CopyCellValue_Guid()
        //{
        //    Guid expected = Guid.NewGuid();
        //    ViewModel.CopyCellValueCommand.Execute(expected);
        //    String actualValue = ClipBoardWrapper.GetText();
        //    Assert.That(Guid.Parse(actualValue), Is.EqualTo(expected));
        //}

        //[TestCase]
        //public void Test_CopyCellValue_Int16()
        //{
        //    Int16 expected = Int16.MaxValue;
        //    ViewModel.CopyCellValueCommand.Execute(expected);
        //    String actualValue = ClipBoardWrapper.GetText();
        //    Assert.That(Convert.ToInt16(actualValue), Is.EqualTo(expected));
        //}

        //[TestCase]
        //public void Test_CopyCellValue_UInt16()
        //{
        //    UInt16 expected = UInt16.MaxValue;
        //    ViewModel.CopyCellValueCommand.Execute(expected);
        //    String actualValue = ClipBoardWrapper.GetText();
        //    Assert.That(Convert.ToUInt16(actualValue), Is.EqualTo(expected));
        //}

        //[TestCase]
        //public void Test_CopyCellValue_Int32()
        //{
        //    Int32 expected = Int32.MaxValue;
        //    ViewModel.CopyCellValueCommand.Execute(expected);
        //    String actualValue = ClipBoardWrapper.GetText();
        //    Assert.That(Convert.ToInt32(actualValue), Is.EqualTo(expected));
        //}

        //[TestCase]
        //public void Test_CopyCellValue_UInt32()
        //{
        //    UInt32 expected = UInt32.MaxValue;
        //    ViewModel.CopyCellValueCommand.Execute(expected);
        //    String actualValue = ClipBoardWrapper.GetText();
        //    Assert.That(Convert.ToUInt32(actualValue), Is.EqualTo(expected));
        //}

        //[TestCase]
        //public void Test_CopyCellValue_Int64()
        //{
        //    Int64 expected = Int64.MaxValue;
        //    ViewModel.CopyCellValueCommand.Execute(expected);
        //    String actualValue = ClipBoardWrapper.GetText();
        //    Assert.That(Convert.ToInt64(actualValue), Is.EqualTo(expected));
        //}

        //[TestCase]
        //public void Test_CopyCellValue_UInt64()
        //{
        //    UInt64 expected = UInt64.MaxValue;
        //    ViewModel.CopyCellValueCommand.Execute(expected);
        //    String actualValue = ClipBoardWrapper.GetText();
        //    Assert.That(Convert.ToUInt64(actualValue), Is.EqualTo(expected));
        //}

        //[TestCase]
        //public void Test_CopyCellValue_Decimal()
        //{
        //    Decimal expected = Decimal.MaxValue;
        //    ViewModel.CopyCellValueCommand.Execute(expected);
        //    String actualValue = ClipBoardWrapper.GetText();
        //    Assert.That(Convert.ToDecimal(actualValue), Is.EqualTo(expected));
        //}

        //[TestCase]
        //public void Test_CopyCellValue_Double()
        //{
        //    Double expected = 123456.798123d;
        //    ViewModel.CopyCellValueCommand.Execute(expected);
        //    String actualValue = ClipBoardWrapper.GetText();
        //    Assert.That(Convert.ToDouble(actualValue), Is.EqualTo(expected));
        //}

        //[TestCase]
        //public void Test_CopyCellValue_Single()
        //{
        //    Single expected = 123456.798123f;
        //    ViewModel.CopyCellValueCommand.Execute(expected);
        //    String actualValue = ClipBoardWrapper.GetText();
        //    Assert.That(Convert.ToSingle(actualValue), Is.EqualTo(expected));
        //}

        //[TestCase]
        //public void Test_CopyCellValue_Char()
        //{
        //    Char expected = Char.MaxValue;
        //    ViewModel.CopyCellValueCommand.Execute(expected);
        //    String actualValue = ClipBoardWrapper.GetText();
        //    Assert.That(Convert.ToChar(actualValue), Is.EqualTo(expected));
        //}

        //[TestCase]
        //public void Test_CopyCellValue_String()
        //{
        //    String expected = Guid.NewGuid().ToString();
        //    ViewModel.CopyCellValueCommand.Execute(expected);
        //    String actualValue = ClipBoardWrapper.GetText();
        //    Assert.That(Convert.ToString(actualValue), Is.EqualTo(expected));
        //}

        //[TestCase]
        //public void Test_CopyCellValue_SByte()
        //{
        //    SByte expected = SByte.MaxValue;
        //    ViewModel.CopyCellValueCommand.Execute(expected);
        //    String actualValue = ClipBoardWrapper.GetText();
        //    Assert.That(Convert.ToSByte(actualValue), Is.EqualTo(expected));
        //}

        //[TestCase]
        //public void Test_CopyGridToCsvCommand()
        //{
        //    ViewModel.CopyGridToCsvCommand.Execute(null);

        //    List<TModel> entities = new List<TModel>
        //    {
        //        CreateBlankModel(),
        //        CreateBlankModel(),
        //        CreateBlankModel(),
        //    };

        //    ViewModel.CopyGridToCsvCommand.Execute(entities);
        //}

        //[TestCase]
        //public void Test_CopyToCsv()
        //{
        //    ViewModel.CopyRowToCsvCommand.Execute(null);

        //    TModel entity = CreateModel();
        //    ViewModel.CopyRowToCsvCommand.Execute(entity);
        //}

        //[TestCase]
        //public virtual void Test_Refresh()
        //{
        //    GenericDataGridViewModelBase.RefreshCommandEnabled = true;

        //    SetupForRefreshData();

        //    ViewModel.RefreshCommand.Execute(null);
        //}

        //[TestCase]
        //public void Test_Refresh_Disabled()
        //{
        //    GenericDataGridViewModelBase.RefreshCommandEnabled = true;
        //    GenericDataGridViewModelBase.RefreshCommandEnabled = false;

        //    SetupForRefreshData();

        //    ViewModel.RefreshCommand.Execute(null);
        //}

        //[TestCase]
        //public void Test_Refresh_CanExecute()
        //{
        //    TModel entity = CreateModel();

        //    GenericDataGridViewModelBase.RefreshCommandEnabled = true;
        //    Assert.That(ViewModel.RefreshCommand.CanExecute(entity), Is.EqualTo(true));

        //    GenericDataGridViewModelBase.RefreshCommandEnabled = false;
        //    Assert.That(ViewModel.RefreshCommand.CanExecute(entity), Is.EqualTo(false));
        //}

        //[TestCase]
        //public void Test_ViewRecord_Success()
        //{
        //    GenericDataGridViewModelBase.ViewRecordCommandEnabled = true;

        //    BusinessProcess.CanViewRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(true);

        //    TModel entity = CreateModel();
        //    ViewModel.ViewRecordCommand.Execute(entity);
        //}

        //[TestCase]
        //public void Test_ViewRecord_Disabled()
        //{
        //    GenericDataGridViewModelBase.ViewRecordCommandEnabled = true;
        //    GenericDataGridViewModelBase.ViewRecordCommandEnabled = false;

        //    BusinessProcess.CanViewRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(true);

        //    TModel entity = CreateModel();
        //    ViewModel.ViewRecordCommand.Execute(entity);
        //}

        //[TestCase]
        //public void Test_ViewRecord_CanExecute()
        //{
        //    TModel entity = CreateModel();

        //    GenericDataGridViewModelBase.ViewRecordCommandEnabled = true;
        //    Assert.That(ViewModel.ViewRecordCommand.CanExecute(entity), Is.EqualTo(true));

        //    GenericDataGridViewModelBase.ViewRecordCommandEnabled = false;
        //    Assert.That(ViewModel.ViewRecordCommand.CanExecute(entity), Is.EqualTo(false));
        //}

        //[TestCase]
        //public void Test_ViewRecord_NullEntity()
        //{
        //    GenericDataGridViewModelBase.ViewRecordCommandEnabled = true;

        //    BusinessProcess.CanViewRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(true);

        //    ViewModel.ViewRecordCommand.Execute(null);
        //}

        //[TestCase]
        //public void Test_ViewRecord_NoPermissions()
        //{
        //    String typeName = ViewModel.GetType().ToString();
        //    String processName = $"{typeName}::OnViewRecordCommand_Execute";
        //    String requiredPermissions = $"{ApplicationRole.Reporter}";
        //    IFoundationModel model = CreateModel();
        //    String userCredentials = CoreInstance.CurrentLoggedOnUser.Username;
        //    String expectedErrorMessage = $"Application Id: '{TestingApplicationId}'. User: '{userCredentials}' does not have the required permissions. Required permission is: '{requiredPermissions}'";
        //    Exception actualException = null;

        //    try
        //    {
        //        GenericDataGridViewModelBase.ViewRecordCommandEnabled = true;

        //        BusinessProcess.CanViewRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(false);

        //        ViewModel.ViewRecordCommand.Execute(model);
        //    }
        //    catch (Exception exception)
        //    {
        //        actualException = exception;
        //    }

        //    Assert.That(actualException, Is.Not.Null);
        //    Assert.That(actualException, Is.InstanceOf<ApplicationPermissionsException>());

        //    ApplicationPermissionsException ape = (ApplicationPermissionsException)actualException;

        //    String actualErrorMessage = actualException.Message;
        //    Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage));
        //    Assert.That(ape.ProcessName, Is.EqualTo(processName));
        //    Assert.That(ape.RequiredPermission, Is.EqualTo(requiredPermissions));
        //    Assert.That(ape.UserCredentials, Is.EqualTo(userCredentials));
        //    Assert.That(ape.FoundationModel, Is.EqualTo(model));
        //}

        //[TestCase]
        //public void Test_AddRecord_Success()
        //{
        //    GenericDataGridViewModelBase.AddRecordCommandEnabled = true;

        //    BusinessProcess.CanAddRecord(Arg.Any<IUserProfile>()).Returns(true);

        //    TModel entity = CreateModel();
        //    ViewModel.AddRecordCommand.Execute(entity);
        //}

        //[TestCase]
        //public void Test_AddRecord_Disabled()
        //{
        //    GenericDataGridViewModelBase.AddRecordCommandEnabled = true;
        //    GenericDataGridViewModelBase.AddRecordCommandEnabled = false;

        //    BusinessProcess.CanAddRecord(Arg.Any<IUserProfile>()).Returns(true);

        //    TModel entity = CreateModel();
        //    ViewModel.AddRecordCommand.Execute(entity);
        //}

        //[TestCase]
        //public void Test_AddRecord_CanExecute()
        //{
        //    TModel entity = CreateModel();

        //    GenericDataGridViewModelBase.AddRecordCommandEnabled = true;
        //    Assert.That(ViewModel.AddRecordCommand.CanExecute(entity), Is.EqualTo(true));

        //    GenericDataGridViewModelBase.AddRecordCommandEnabled = false;
        //    Assert.That(ViewModel.AddRecordCommand.CanExecute(entity), Is.EqualTo(false));
        //}

        //[TestCase]
        //public void Test_AddRecord_NullEntity()
        //{
        //    GenericDataGridViewModelBase.AddRecordCommandEnabled = true;

        //    BusinessProcess.CanAddRecord(Arg.Any<IUserProfile>()).Returns(true);

        //    ViewModel.AddRecordCommand.Execute(null);
        //}

        //[TestCase]
        //public void Test_AddRecord_NoPermissions()
        //{
        //    String typeName = ViewModel.GetType().ToString();
        //    String processName = $"{typeName}::OnAddRecordCommand_Execute";
        //    String requiredPermissions = $"{ApplicationRole.Creator}";
        //    const IFoundationModel? model = null;
        //    String userCredentials = CoreInstance.CurrentLoggedOnUser.Username;
        //    String expectedErrorMessage = $"Application Id: '{TestingApplicationId}'. User: '{userCredentials}' does not have the required permissions. Required permission is: '{requiredPermissions}'";
        //    Exception actualException = null;

        //    try
        //    {
        //        GenericDataGridViewModelBase.AddRecordCommandEnabled = true;

        //        BusinessProcess.CanAddRecord(Arg.Any<IUserProfile>()).Returns(false);

        //        ViewModel.AddRecordCommand.Execute(model);
        //    }
        //    catch (Exception exception)
        //    {
        //        actualException = exception;
        //    }

        //    Assert.That(actualException, Is.Not.Null);
        //    Assert.That(actualException, Is.InstanceOf<ApplicationPermissionsException>());

        //    ApplicationPermissionsException ape = (ApplicationPermissionsException)actualException;

        //    String actualErrorMessage = actualException.Message;
        //    Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage));
        //    Assert.That(ape.ProcessName, Is.EqualTo(processName));
        //    Assert.That(ape.RequiredPermission, Is.EqualTo(requiredPermissions));
        //    Assert.That(ape.UserCredentials, Is.EqualTo(userCredentials));
        //    Assert.That(ape.FoundationModel, Is.EqualTo(model));
        //}

        //[TestCase]
        //public void Test_EditRecord_Success()
        //{
        //    GenericDataGridViewModelBase.EditRecordCommandEnabled = true;

        //    BusinessProcess.CanEditRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(true);

        //    TModel entity = CreateModel();
        //    ViewModel.EditRecordCommand.Execute(entity);
        //}

        //[TestCase]
        //public void Test_EditRecord_Disabled()
        //{
        //    GenericDataGridViewModelBase.EditRecordCommandEnabled = true;
        //    GenericDataGridViewModelBase.EditRecordCommandEnabled = false;

        //    BusinessProcess.CanEditRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(true);

        //    TModel entity = CreateModel();
        //    ViewModel.EditRecordCommand.Execute(entity);
        //}

        //[TestCase]
        //public void Test_EditRecord_CanExecute()
        //{
        //    TModel entity = CreateModel();

        //    GenericDataGridViewModelBase.EditRecordCommandEnabled = true;
        //    Assert.That(ViewModel.EditRecordCommand.CanExecute(entity), Is.EqualTo(true));

        //    GenericDataGridViewModelBase.EditRecordCommandEnabled = false;
        //    Assert.That(ViewModel.EditRecordCommand.CanExecute(entity), Is.EqualTo(false));
        //}

        //[TestCase]
        //public void Test_EditRecord_NullEntity()
        //{
        //    GenericDataGridViewModelBase.EditRecordCommandEnabled = true;

        //    BusinessProcess.CanEditRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(true);

        //    ViewModel.EditRecordCommand.Execute(null);
        //}

        //[TestCase]
        //public void Test_EditRecord_NoPermissions()
        //{
        //    String typeName = ViewModel.GetType().ToString();
        //    String processName = $"{typeName}::OnEditRecordCommand_Execute";
        //    String requiredPermissions = $"{ApplicationRole.OwnEditor}, {ApplicationRole.AllEditor}";
        //    IFoundationModel model = CreateModel();
        //    String userCredentials = CoreInstance.CurrentLoggedOnUser.Username;
        //    String expectedErrorMessage = $"Application Id: '{TestingApplicationId}'. User: '{userCredentials}' does not have the required permissions. Required permission is: '{requiredPermissions}'";
        //    Exception actualException = null;

        //    try
        //    {
        //        GenericDataGridViewModelBase.EditRecordCommandEnabled = true;

        //        BusinessProcess.CanEditRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(false);

        //        ViewModel.EditRecordCommand.Execute(model);
        //    }
        //    catch (Exception exception)
        //    {
        //        actualException = exception;
        //    }

        //    Assert.That(actualException, Is.Not.Null);
        //    Assert.That(actualException, Is.InstanceOf<ApplicationPermissionsException>());

        //    ApplicationPermissionsException ape = (ApplicationPermissionsException)actualException;

        //    String actualErrorMessage = actualException.Message;
        //    Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage));
        //    Assert.That(ape.ProcessName, Is.EqualTo(processName));
        //    Assert.That(ape.RequiredPermission, Is.EqualTo(requiredPermissions));
        //    Assert.That(ape.UserCredentials, Is.EqualTo(userCredentials));
        //    Assert.That(ape.FoundationModel, Is.EqualTo(model));
        //}

        //[TestCase]
        //public void Test_DeleteRecord_Success()
        //{
        //    GenericDataGridViewModelBase.DeleteRecordCommandEnabled = true;

        //    BusinessProcess.CanDeleteRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(true);

        //    TModel entity = CreateModel();
        //    ViewModel.DeleteRecordCommand.Execute(entity);
        //}

        //[TestCase]
        //public void Test_DeleteRecord_Disabled()
        //{
        //    GenericDataGridViewModelBase.DeleteRecordCommandEnabled = true;
        //    GenericDataGridViewModelBase.DeleteRecordCommandEnabled = false;

        //    BusinessProcess.CanDeleteRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(true);

        //    TModel entity = CreateModel();
        //    ViewModel.DeleteRecordCommand.Execute(entity);
        //}

        //[TestCase]
        //public void Test_DeleteRecord_CanExecute()
        //{
        //    TModel entity = CreateModel();

        //    GenericDataGridViewModelBase.DeleteRecordCommandEnabled = true;
        //    Assert.That(ViewModel.DeleteRecordCommand.CanExecute(entity), Is.EqualTo(true));

        //    GenericDataGridViewModelBase.DeleteRecordCommandEnabled = false;
        //    Assert.That(ViewModel.DeleteRecordCommand.CanExecute(entity), Is.EqualTo(false));
        //}

        //[TestCase]
        //public void Test_DeleteRecord_NullEntity()
        //{
        //    GenericDataGridViewModelBase.DeleteRecordCommandEnabled = true;

        //    BusinessProcess.CanDeleteRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(true);

        //    ViewModel.DeleteRecordCommand.Execute(null);
        //}

        //[TestCase]
        //public void Test_DeleteRecord_NoPermissions()
        //{
        //    String typeName = ViewModel.GetType().ToString();
        //    String processName = $"{typeName}::OnDeleteRecordCommand_Execute";
        //    String requiredPermissions = $"{ApplicationRole.OwnDelete}, {ApplicationRole.AllDelete}";
        //    IFoundationModel model = CreateModel();
        //    String userCredentials = CoreInstance.CurrentLoggedOnUser.Username;
        //    String expectedErrorMessage = $"Application Id: '{TestingApplicationId}'. User: '{userCredentials}' does not have the required permissions. Required permission is: '{requiredPermissions}'";
        //    Exception actualException = null;

        //    try
        //    {
        //        GenericDataGridViewModelBase.DeleteRecordCommandEnabled = true;

        //        BusinessProcess.CanDeleteRecord(Arg.Any<IUserProfile>(), Arg.Any<TModel>()).Returns(false);

        //        ViewModel.DeleteRecordCommand.Execute(model);
        //    }
        //    catch (Exception exception)
        //    {
        //        actualException = exception;
        //    }

        //    Assert.That(actualException, Is.Not.Null);
        //    Assert.That(actualException, Is.InstanceOf<ApplicationPermissionsException>());

        //    ApplicationPermissionsException ape = (ApplicationPermissionsException)actualException;

        //    String actualErrorMessage = actualException.Message;
        //    Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage));
        //    Assert.That(ape.ProcessName, Is.EqualTo(processName));
        //    Assert.That(ape.RequiredPermission, Is.EqualTo(requiredPermissions));
        //    Assert.That(ape.UserCredentials, Is.EqualTo(userCredentials));
        //    Assert.That(ape.FoundationModel, Is.EqualTo(model));
        //}

        //[TestCase]
        //public void Test_DataGridColumns()
        //{
        //    List<IGridColumnDefinition> expectedGridColumnDefinitions = new List<IGridColumnDefinition>
        //    {
        //        new GridColumnDefinition(),
        //    };
        //    BusinessProcess.GetColumnDefinitions().Returns(expectedGridColumnDefinitions);

        //    ObservableCollection<IGridColumnDefinition> gridColumnDefinitions = ViewModel.DataGridColumns;

        //    Assert.That(gridColumnDefinitions.Count, Is.EqualTo(expectedGridColumnDefinitions.Count));
        //    Assert.That(gridColumnDefinitions[0], Is.EqualTo(expectedGridColumnDefinitions[0]));
        //}

        //[TestCase]
        //public void Test_GridExportColumns()
        //{
        //    List<IGridColumnDefinition> expectedGridColumnDefinitions = new List<IGridColumnDefinition>
        //    {
        //        CoreInstance.IoC.Get<IGridColumnDefinition>(),
        //    };
        //    BusinessProcess.GetColumnDefinitions().Returns(expectedGridColumnDefinitions);

        //    List<IGridColumnDefinition> gridColumnDefinitions = ViewModel.GridExportColumns.ToList();

        //    Assert.That(gridColumnDefinitions.Count, Is.EqualTo(expectedGridColumnDefinitions.Count));
        //    Assert.That(gridColumnDefinitions[0], Is.EqualTo(expectedGridColumnDefinitions[0]));
        //}

        //[TestCase]
        //public void Test_InitialiseGenericDataGridViewModel()
        //{
        //    SetupForRefreshData();

        //    const IWindow targetWindow = null;
        //    const IViewModel parentViewModel = null;
        //    String formTitle = String.Empty;

        //    ViewModel.Initialise(targetWindow, parentViewModel, formTitle);
        //}

    }
}
