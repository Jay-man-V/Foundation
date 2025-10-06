//-----------------------------------------------------------------------
// <copyright file="DataStatusViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using NUnit.Framework;

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;
using Foundation.ViewModels.Core.EnumViewModels;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for DataStatusViewModelTests
    /// </summary>
    [TestFixture]
    public class DataStatusViewModelTests : GenericDataGridViewModelTestBaseClass<IDataStatus, IDataStatusViewModel, IDataStatusProcess>
    {
        protected override String ExpectedScreenTitle => "Data Statuses";
        protected override String ExpectedStatusBarText => "Number of Data Statuses:";

        protected override IDataStatusViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IDataStatusViewModel viewModel = new DataStatusViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IDataStatusProcess CreateBusinessProcess()
        {
            IDataStatusProcess process = Substitute.For<IDataStatusProcess>();

            return process;
        }

        protected override IDataStatus CreateModel()
        {
            IDataStatus retVal = base.CreateModel();

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }
    }
}
