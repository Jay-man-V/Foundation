//-----------------------------------------------------------------------
// <copyright file="ContactDetailProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Interfaces.Helpers;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.BusinessProcess.Core
{
    /// <summary>
    /// The Contact Detail Business Process 
    /// </summary>
    [DependencyInjectionTransient]
    public class ContactDetailProcess : CommonBusinessProcess<IContactDetail, IContactDetailRepository>, IContactDetailProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ContactDetailProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="loggingService">The logging service</param>
        /// <param name="repository">The data access</param>
        /// <param name="statusRepository">The status data access</param>
        /// <param name="userProfileRepository">The user profile data access</param>
        /// <param name="reportGenerator">The report generator service</param>
        /// <param name="contractProcess">The contract process</param>
        /// <param name="contactTypeProcess">The contact type process</param>
        /// <param name="nationalRegionProcess">The national region process</param>
        /// <param name="countryProcess">The country process</param>
        public ContactDetailProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ILoggingService loggingService,
            IContactDetailRepository repository,
            IStatusRepository statusRepository,
            IUserProfileRepository userProfileRepository,
            IReportGenerator reportGenerator,
            IContractProcess contractProcess,
            IContactTypeProcess contactTypeProcess,
            INationalRegionProcess nationalRegionProcess,
            ICountryProcess countryProcess
        )
            : base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                loggingService,
                repository,
                statusRepository,
                userProfileRepository,
                reportGenerator
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, loggingService, repository, statusRepository, userProfileRepository, reportGenerator, contractProcess, contactTypeProcess, nationalRegionProcess, countryProcess);

            ContractProcess = contractProcess;
            ContactTypeProcess = contactTypeProcess;
            NationalRegionProcess = nationalRegionProcess;
            CountryProcess = countryProcess;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the contract process.
        /// </summary>
        /// <value>
        /// The contract process.
        /// </value>
        private IContractProcess ContractProcess { get; }

        /// <summary>
        /// Gets the contact type process.
        /// </summary>
        /// <value>
        /// The contact type process.
        /// </value>
        private IContactTypeProcess ContactTypeProcess { get; }

        /// <summary>
        /// Gets the national region process.
        /// </summary>
        /// <value>
        /// The national region process.
        /// </value>
        private INationalRegionProcess NationalRegionProcess { get; }

        /// <summary>
        /// Gets the country process.
        /// </summary>
        /// <value>
        /// The country process.
        /// </value>
        private ICountryProcess CountryProcess { get; }


        /// <inheritdoc cref="ICommonBusinessProcess.HasOptionalDropDownParameter1"/>
        public override Boolean HasOptionalDropDownParameter1 => true;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter1Name"/>
        public override String Filter1Name => "Contact Type:";

        /// <inheritdoc cref="ICommonBusinessProcess.Filter1DisplayMemberPath"/>
        public override String Filter1DisplayMemberPath => ContactTypeProcess.ComboBoxDisplayMember;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter1SelectedValuePath"/>
        public override String Filter1SelectedValuePath => ContactTypeProcess.ComboBoxValueMember;


        /// <inheritdoc cref="ICommonBusinessProcess.HasOptionalDropDownParameter2"/>
        public override Boolean HasOptionalDropDownParameter2 => true;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter2Name"/>
        public override String Filter2Name => "Parent Contact:";

        /// <inheritdoc cref="ICommonBusinessProcess.Filter2DisplayMemberPath"/>
        public override String Filter2DisplayMemberPath => ComboBoxDisplayMember;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter2SelectedValuePath"/>
        public override String Filter2SelectedValuePath => ComboBoxValueMember;


        /// <inheritdoc cref="ICommonBusinessProcess.ScreenTitle"/>
        public override String ScreenTitle => "Contacts";

        /// <inheritdoc cref="ICommonBusinessProcess.StatusBarText"/>
        public override String StatusBarText => "Number of Contacts:";

        /// <inheritdoc cref="ICommonBusinessProcess.ComboBoxDisplayMember" />
        public override String ComboBoxDisplayMember => FDC.ContactDetail.DisplayName;

        /// <inheritdoc cref="ICommonBusinessProcess.GetColumnDefinitions()" />
        public override List<IGridColumnDefinition> GetColumnDefinitions()
        {

            LoggingHelpers.TraceCallEnter();

            List<IGridColumnDefinition> retVal = GetStandardEntityColumnDefinitions();
            IGridColumnDefinition gridColumnDefinition;

            gridColumnDefinition = new GridColumnDefinition(300, FDC.ContactDetail.ParentContactId, "Parent Contact", typeof(String))
            {
                DataSource = this.GetAll(excludeDeleted: false),
                ValueMember = this.ComboBoxValueMember,
                DisplayMember = this.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(300, FDC.ContactDetail.ContractId, "Contract", typeof(String))
            {
                DataSource = ContractProcess.GetAll(excludeDeleted: false),
                ValueMember = ContractProcess.ComboBoxValueMember,
                DisplayMember = ContractProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(300, FDC.ContactDetail.ContactTypeId, "Contact Type", typeof(String))
            {
                DataSource = ContactTypeProcess.GetAll(excludeDeleted: false),
                ValueMember = ContactTypeProcess.ComboBoxValueMember,
                DisplayMember = ContactTypeProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(250, FDC.ContactDetail.ShortName, "Short Name", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(250, FDC.ContactDetail.DisplayName, "Display Name", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(250, FDC.ContactDetail.LegalName, "Legal Name", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.ContactDetail.Telephone1, "Telephone 1", typeof(TelephoneNumber));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.ContactDetail.Telephone2, "Telephone 2", typeof(TelephoneNumber));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(300, FDC.ContactDetail.EmailAddress, "Email Address", typeof(EmailAddress));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(300, FDC.ContactDetail.BuildingName, "Building Name", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(300, FDC.ContactDetail.Street1, "Street 1", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(300, FDC.ContactDetail.Street2, "Street 2", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(300, FDC.ContactDetail.Town, "Town", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(300, FDC.ContactDetail.County, "County", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(100, FDC.ContactDetail.PostCode, "Post Code", typeof(PostCode));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.ContactDetail.NationalRegionId, "National Region", typeof(String))
            {
                DataSource = NationalRegionProcess.GetAll(excludeDeleted: false),
                ValueMember = NationalRegionProcess.ComboBoxValueMember,
                DisplayMember = NationalRegionProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.ContactDetail.CountryId, "Country", typeof(String))
            {
                DataSource = CountryProcess.GetAll(excludeDeleted: false),
                ValueMember = CountryProcess.ComboBoxValueMember,
                DisplayMember = CountryProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IContactDetailProcess.ApplyFilter(List{IContactDetail}, IContactType?, IContactDetail?)"/>
        public List<IContactDetail> ApplyFilter(List<IContactDetail> contactDetails, IContactType? contactType, IContactDetail? parentContactDetail)
        {
            LoggingHelpers.TraceCallEnter(contactDetails, contactType, parentContactDetail);

            List<IContactDetail> retVal = contactDetails;

            if (contactType != null)
            {
                retVal = retVal.Where(c => (c.ContactTypeId == contactType.Id) ||                           // Matching Contact Type
                                           (contactType.Id == ContactTypeProcess.AllId) ||                  // All records
                                           (contactType.Id == ContactTypeProcess.NoneId &&
                                            c.ContactTypeId == ContactTypeProcess.NullId)                   // No Contact Type
                                      ).ToList();
            }

            if (parentContactDetail != null)
            {
                retVal = retVal.Where(c => c.ParentContactId == parentContactDetail.Id ||                   // Matching Parent Contact
                                           parentContactDetail.Id == this.AllId ||                          // All records
                                           (parentContactDetail.Id == this.NoneId &&
                                            c.ParentContactId == this.NullId)                               // No Parent Contact
                                      ).ToList();
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IContactDetailProcess.MakeListOfParentContacts(List{IContactDetail})"/>
        public List<IContactDetail> MakeListOfParentContacts(List<IContactDetail> contactDetails)
        {
            LoggingHelpers.TraceCallEnter(contactDetails);

            List<IContactDetail> retVal;

            IEnumerable<IContactDetail> contactsWithParents = contactDetails.Where(c => c.ParentContactId.ToInteger() > -1);
            IEnumerable<IContactDetail> localParentContactsWithDuplicates = contactDetails.Where(c => contactsWithParents.Any(cwp => cwp.ParentContactId == c.Id));
            HashSet<IContactDetail> parentContactsWithoutDuplicates = new HashSet<IContactDetail>(localParentContactsWithDuplicates);
            retVal = parentContactsWithoutDuplicates.OrderBy(c => c.DisplayName).ToList();

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
