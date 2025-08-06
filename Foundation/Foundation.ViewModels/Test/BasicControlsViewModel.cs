//-----------------------------------------------------------------------
// <copyright file="BasicControlsViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Threading;

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels
{
    /// <summary>
    /// The User Interface interaction logic for Basic Controls
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IApplication}" />
    [DependencyInjectionTransient]
    public class BasicControlsViewModel : EntityViewModelBase<IApplication>, IBasicControlsViewModel
    {
        ///// <summary>
        ///// Initialises a new instance of the <see cref="BasicControlsViewModel"/> class.
        ///// </summary>
        ///// <param name="core">The Foundation Core service.</param>
        ///// <param name="runTimeEnvironmentSettings">The runtime environment settings</param>
        ///// <param name="dateTimeService">The date time service.</param>
        ///// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        //public BasicControlsViewModel
        //(
        //    ICore core,
        //    IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
        //    IDateTimeService dateTimeService,
        //    IWpfApplicationObjects wpfApplicationObjects
        //) :
        //    this
        //    (
        //        core,
        //        runTimeEnvironmentSettings,
        //        dateTimeService,
        //        wpfApplicationObjects,
        //        new FModels.Application()
        //    ) 
        //{
        //    LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects);

        //    ButtonStatus = true;

        //    LoggingHelpers.TraceCallReturn();
        //}

        /// <summary>
        /// Initialises a new instance of the <see cref="BasicControlsViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="application">The application.</param>

        public BasicControlsViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IApplication application
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                "Basic Controls Test Form"
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, application);

            SomeStringProperty = "String property binding";

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="Initialise()"/>
        public override void Initialise()
        {
            LoggingHelpers.TraceCallEnter();

            // Nothing to do

            LoggingHelpers.TraceCallReturn();
        }

        //public ICommand ButtonActionCommand { get; private set; }

        /// <summary>
        /// Gets the button action command.
        /// </summary>
        /// <value>
        /// The button action command.
        /// </value>
        public ICommand ButtonActionCommand { get { return RelayCommandFactory.New<Object>(ButtonAction, () => ButtonStatus); } }

        /// <summary>
        /// The status
        /// </summary>
        private Boolean _status;

        /// <summary>
        /// Gets or sets a value indicating whether [button status].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [button status]; otherwise, <c>false</c>.
        /// </value>
        public Boolean ButtonStatus
        { 
            get => _status;
            set => SetPropertyValue(ref _status, value);
        }

        /// <summary>
        /// Buttons the action.
        /// </summary>
        /// <param name="o">The o.</param>
        private void ButtonAction(Object? o)
        {
            LoggingHelpers.TraceCallEnter(o);

            //base.Data.Name = "Started";

            //BackgroundWorker bgw = new BackgroundWorker();
            //bgw.WorkerReportsProgress = true;
            //bgw.DoWork += Bgw_DoWork;
            //bgw.ProgressChanged += Bgw_ProgressChanged;
            //bgw.RunWorkerCompleted += Bgw_RunWorkerCompleted;

            //bgw.RunWorkerAsync();

            //ProgressBarViewModel viewModel = new ProgressBarViewModel();
            //viewModel.ParentViewModel = this.ParentViewModel;
            //viewModel.Initialise();

            //DialogService.Show<ProgressBarForm>(this.ParentViewModel, viewModel);

            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(3),
            };

            timer.Tick += Timer_Tick;
            timer.Start();

            // LongTask();
            // base.Data.Name = "Finished";
            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Handles the Tick event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Timer_Tick(Object? sender, EventArgs e)
        {
            LoggingHelpers.TraceCallEnter(sender, e);

            ButtonStatus = !ButtonStatus;
            Debug.Print(_status.ToString());

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the Bgw control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void Bgw_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e)
        {
            LoggingHelpers.TraceCallEnter();

            //base.Data.Name = "Finished";

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Handles the ProgressChanged event of the Bgw control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void Bgw_ProgressChanged(Object sender, ProgressChangedEventArgs e)
        {
            LoggingHelpers.TraceCallEnter();

            //base.Data.Name = e.ProgressPercentage.ToString();

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Handles the DoWork event of the Bgw control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void Bgw_DoWork(Object sender, DoWorkEventArgs e)
        {
            LoggingHelpers.TraceCallEnter();

            if (sender is BackgroundWorker bgw)
            {
                for (Byte x = 0; x < Byte.MaxValue; x++)
                {
                    Decimal progress = ((Decimal)x / Byte.MaxValue) * 100;
                    bgw.ReportProgress((Int32)progress);
                    Thread.Sleep(10);
                }

                bgw.ReportProgress(100);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets or sets some string property.
        /// </summary>
        /// <value>
        /// Some string property.
        /// </value>
        public String SomeStringProperty { get; set; }
    }
}
