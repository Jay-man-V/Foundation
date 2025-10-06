//-----------------------------------------------------------------------
// <copyright file="EntityStatusViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for EntityStatusViewModelTests
    /// </summary>
    [TestFixture]
    public class EntityStatusViewModelTests : GenericDataGridViewModelTestBaseClass<IEntityStatus, IEntityStatusViewModel, IEntityStatusProcess>
    {
        protected override String ExpectedScreenTitle => "Entity Statuses";
        protected override String ExpectedStatusBarText => "Number of Entity Statuses:";

        protected override IEntityStatusViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IEntityStatusViewModel viewModel = new EntityStatusViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IEntityStatusProcess CreateBusinessProcess()
        {
            IEntityStatusProcess process = Substitute.For<IEntityStatusProcess>();

            return process;
        }

        protected override IEntityStatus CreateModel()
        {
            IEntityStatus retVal = base.CreateModel();

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }
    }
}
