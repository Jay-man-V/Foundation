//-----------------------------------------------------------------------
// <copyright file="ContactViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels
{
    /// <summary>
    /// The User Interface interaction logic for Contact Detail maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IContactDetail}" />
    [DependencyInjectionTransient]
    public class ContactDetailViewModel : GenericDataGridViewModelBase<IContactDetail>, IContactDetailViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ContactDetailViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="contactDetailProcess">The contact detail process.</param>
        /// <param name="contactTypeProcess">The contact type process.</param>
        public ContactDetailViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IContactDetailProcess contactDetailProcess,
            IContactTypeProcess contactTypeProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                contactDetailProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, contactDetailProcess, contactTypeProcess);

            ContactDetailProcess = contactDetailProcess;
            ContactTypeProcess = contactTypeProcess;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the contact detail process.
        /// </summary>
        /// <value>
        /// The contact detail process.
        /// </value>
        private IContactDetailProcess ContactDetailProcess { get; }

        /// <summary>
        /// Gets the contact type process.
        /// </summary>
        /// <value>
        /// The contact type process.
        /// </value>
        private IContactTypeProcess ContactTypeProcess { get; }

        /// <summary>
        /// Gets or sets all contacts.
        /// </summary>
        /// <value>
        /// All contacts.
        /// </value>
        private List<IContactDetail> AllContacts { get; set; }

        /// <inheritdoc cref="Initialise()"/>
        public override void Initialise()
        {
            LoggingHelpers.TraceCallEnter();

            List<IContactType> contactTypes = ContactTypeProcess.GetAll();
            ContactTypeProcess.AddFilterOptionsAdditional(contactTypes);

            Filter1DataSource = contactTypes;
            Filter1SelectedItem = contactTypes[0];

            base.Initialise();

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="RefreshData()"/>
        protected override List<IContactDetail> RefreshData()
        {
            LoggingHelpers.TraceCallEnter();

            AllContacts = base.RefreshData();

            OnFilter1SelectionChangedCommand_Execute(Filter1SelectedItem);

            List<IContactDetail> parentContacts = ContactDetailProcess.MakeListOfParentContacts(AllContacts);

            ContactDetailProcess.AddFilterOptionsAdditional(parentContacts);

            Filter2DataSource = parentContacts;
            Filter2SelectedItem = parentContacts[0];
            ApplyFilter2(Filter2SelectedItem);

            LoggingHelpers.TraceCallReturn(AllContacts);

            return AllContacts;
        }

        /// <inheritdoc cref="ApplyFilter1"/>
        protected override void ApplyFilter1(Object selectedFilter)
        {
            LoggingHelpers.TraceCallEnter(selectedFilter);

            IContactType contactType = selectedFilter as IContactType;
            IContactDetail parentContactDetail = Filter2SelectedItem as IContactDetail;

            List<IContactDetail> filteredData = ContactDetailProcess.ApplyFilter(AllContacts, contactType, parentContactDetail);

            GridDataSource = filteredData;

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ApplyFilter2"/>
        protected override void ApplyFilter2(Object selectedFilter)
        {
            LoggingHelpers.TraceCallEnter(selectedFilter);

            IContactType contactType = Filter1SelectedItem as IContactType;
            IContactDetail parentContactDetail = selectedFilter as IContactDetail;

            List<IContactDetail> filteredData = ContactDetailProcess.ApplyFilter(AllContacts, contactType, parentContactDetail);

            GridDataSource = filteredData;

            LoggingHelpers.TraceCallReturn();
        }
    }
}
