//-----------------------------------------------------------------------
// <copyright file="TestFormViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.Windows.Input;

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Test
{
    /// <summary>
    /// 
    /// </summary>
    [DependencyInjectionTransient]
    public class TestFormViewModel : ViewModelBase, ITestFormViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="TestFormViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="testSupportService"></param>
        public TestFormViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            ITestSupportService testSupportService
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                "Test Form"
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects);

            TestSupportService = testSupportService;

            LoggingHelpers.TraceCallReturn();
        }

        private ITestSupportService TestSupportService { get; }

        /// <summary>
        /// 
        /// </summary>
        public ICommand DemoCommand => RelayCommandFactory.New(DemoCommand_Click);

        private void DemoCommand_Click()
        {
            using (MouseCursor)
            {
                Debug.WriteLine($"{DateTimeService.SystemUtcDateTimeNow}");
                TestSupportService.SimulateLongTask();
                Debug.WriteLine($"{DateTimeService.SystemUtcDateTimeNow}");
            }
        }

        private void DeleteCommand(Object obj)
        {
            LoggingHelpers.TraceCallEnter(obj);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="Initialise()"/>
        public override void Initialise()
        {
            LoggingHelpers.TraceCallEnter();

            LoggingHelpers.TraceCallReturn();
        }
    }
}
