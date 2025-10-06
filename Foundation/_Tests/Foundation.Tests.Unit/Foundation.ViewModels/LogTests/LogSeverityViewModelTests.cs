//-----------------------------------------------------------------------
// <copyright file="LogSeverityViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using NUnit.Framework;

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;
using Foundation.ViewModels.Log.EnumViewModels;

namespace Foundation.Tests.Unit.Foundation.ViewModels.LogTests
{
    /// <summary>
    /// Summary description for LogSeverityViewModelTests
    /// </summary>
    [TestFixture]
    public class LogSeverityViewModelTests : GenericDataGridViewModelTestBaseClass<ILogSeverity, ILogSeverityViewModel, ILogSeverityProcess>
    {
        protected override String ExpectedScreenTitle => "Log Severities";
        protected override String ExpectedStatusBarText => "Number of Log Severities:";

        protected override ILogSeverityViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            ILogSeverityViewModel viewModel = new LogSeverityViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override ILogSeverityProcess CreateBusinessProcess()
        {
            ILogSeverityProcess process = Substitute.For<ILogSeverityProcess>();

            return process;
        }

        protected override ILogSeverity CreateModel()
        {
            ILogSeverity retVal = base.CreateModel();

            retVal.Code = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }
    }
}
