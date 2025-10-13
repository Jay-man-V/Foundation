//-----------------------------------------------------------------------
// <copyright file="ContactTypeViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for ContactTypeViewModelTests
    /// </summary>
    [TestFixture]
    public class ContactTypeViewModelTests : GenericDataGridViewModelTestBaseClass<IContactType, IContactTypeViewModel, IContactTypeProcess>
    {
        protected override String ExpectedScreenTitle => "Contact Types";
        protected override String ExpectedStatusBarText => "Number of Contact Types:";

        protected override IContactTypeViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IContactTypeViewModel viewModel = new ContactTypeViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IContactTypeProcess CreateBusinessProcess()
        {
            IContactTypeProcess process = Substitute.For<IContactTypeProcess>();

            return process;
        }

        protected override IContactType CreateModel()
        {
            IContactType retVal = base.CreateModel();

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }
    }
}
