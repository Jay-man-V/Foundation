//-----------------------------------------------------------------------
// <copyright file="GenericDataGridViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using NUnit.Framework;

using NSubstitute;

using Foundation.Interfaces;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;
using Foundation.Tests.Unit.Mocks;

namespace Foundation.Tests.Unit.Foundation.ViewModels
{
    /// <summary>
    /// Summary description for GenericDataGridViewModelTests
    /// </summary>
    [TestFixture]
    public class GenericDataGridViewModelBaseTests : GenericDataGridViewModelTestBaseClass<IMockFoundationModel, IMockFoundationModelViewModel, IMockFoundationModelProcess>
    {
        protected override String ExpectedStatusBarText => "Number of rows:";

        protected override IMockFoundationModelViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IMockFoundationModelViewModel viewModel = new MockFoundationModelViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IMockFoundationModelProcess CreateBusinessProcess()
        {
            IMockFoundationModelProcess process = Substitute.For<IMockFoundationModelProcess>();

            SetBusinessProcessProperties(process);

            return process;
        }

        protected override IMockFoundationModel CreateModel()
        {
            IMockFoundationModel retVal = CreateBlankModel();

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBaseClassProperties(IMockFoundationModelViewModel viewModel)
        {
            Assert.That(viewModel.CanViewRecord, Is.EqualTo(false));
            Assert.That(viewModel.ViewButtonVisible, Is.EqualTo(false));
            Assert.That(viewModel.ViewRecordCommand, Is.Not.EqualTo(null));
            Assert.That(viewModel.ViewRecordCommandEnabled, Is.EqualTo(false));

            Assert.That(viewModel.CanAddRecord, Is.EqualTo(false));
            Assert.That(viewModel.AddButtonVisible, Is.EqualTo(false));
            Assert.That(viewModel.AddRecordCommand, Is.Not.EqualTo(null));
            Assert.That(viewModel.AddRecordCommandEnabled, Is.EqualTo(false));

            Assert.That(viewModel.CanEditRecord, Is.EqualTo(false));
            Assert.That(viewModel.EditButtonVisible, Is.EqualTo(false));
            Assert.That(viewModel.EditRecordCommand, Is.Not.EqualTo(null));
            Assert.That(viewModel.EditRecordCommandEnabled, Is.EqualTo(false));

            Assert.That(viewModel.CanDeleteRecord, Is.EqualTo(false));
            Assert.That(viewModel.DeleteButtonVisible, Is.EqualTo(false));
            Assert.That(viewModel.DeleteRecordCommand, Is.Not.EqualTo(null));
            Assert.That(viewModel.DeleteRecordCommandEnabled, Is.EqualTo(false));

            Assert.That(viewModel.ActionsVisible, Is.EqualTo(false));
            Assert.That(viewModel.FiltersVisible, Is.EqualTo(false));
        }
    }
}
