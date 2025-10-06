//-----------------------------------------------------------------------
// <copyright file="ContactDetailViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels.Core;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for ContactDetailViewModelTests
    /// </summary>
    [TestFixture]
    public class ContactDetailViewModelTests : GenericDataGridViewModelTestBaseClass<IContactDetail, IContactDetailViewModel, IContactDetailProcess>
    {
        protected override String ExpectedScreenTitle => "Contacts";
        protected override String ExpectedStatusBarText => "Number of Contacts:";

        protected override Boolean ExpectedHasOptionalDropDownParameter1 => true;
        protected override String ExpectedFilter1Name => "Contact Type:";
        protected override string ExpectedFilter1DisplayMemberPath => FDC.ContactType.Name;

        protected override Boolean ExpectedHasOptionalDropDownParameter2 => true;
        protected override String ExpectedFilter2Name => "Parent Contact:";
        protected override string ExpectedFilter2DisplayMemberPath => FDC.ContactDetail.DisplayName;

        private IContactTypeProcess ContactTypeProcess { get; set; }

        protected override IContactDetailViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IContactDetailViewModel viewModel = new ContactDetailViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess, ContactTypeProcess);

            return viewModel;
        }

        protected override IContactDetailProcess CreateBusinessProcess()
        {
            ContactTypeProcess = Substitute.For<IContactTypeProcess>();
            IContactDetailProcess process = Substitute.For<IContactDetailProcess>();

            return process;
        }

        protected override IContactDetail CreateModel()
        {
            IContactDetail retVal = base.CreateModel();

            retVal.ParentContactId = new EntityId(1);
            retVal.ContractId = new EntityId(2);
            retVal.ContactTypeId = new EntityId(3);
            retVal.NationalRegionId = new EntityId(4);
            retVal.CountryId = new EntityId(5);
            retVal.ShortName = Guid.NewGuid().ToString();
            retVal.DisplayName = Guid.NewGuid().ToString();
            retVal.LegalName = Guid.NewGuid().ToString();
            retVal.BuildingName = Guid.NewGuid().ToString();
            retVal.Street1 = Guid.NewGuid().ToString();
            retVal.Street2 = Guid.NewGuid().ToString();
            retVal.Town = Guid.NewGuid().ToString();
            retVal.County = Guid.NewGuid().ToString();
            retVal.PostCode = Guid.NewGuid().ToString();
            retVal.Telephone1 = Guid.NewGuid().ToString();
            retVal.Telephone2 = Guid.NewGuid().ToString();
            retVal.EmailAddress = new EmailAddress(Guid.NewGuid().ToString());

            return retVal;
        }

        protected override void SetupForRefreshData()
        {
            base.SetupForRefreshData();

            List<IContactType> contactTypes = new List<IContactType>
            {
                CoreInstance.IoC.Get<IContactType>(),
                CoreInstance.IoC.Get<IContactType>(),
            };
            ContactTypeProcess.GetAll().Returns(contactTypes);

            List<IContactDetail> parentContacts = new List<IContactDetail>
            {
                CreateModel(),
                CreateModel(),
            };
            BusinessProcess.MakeListOfParentContacts(Arg.Any<List<IContactDetail>>()).Returns(parentContacts);

            List<IContactDetail> filteredData = new List<IContactDetail>();
            BusinessProcess.ApplyFilter(Arg.Any<List<IContactDetail>>(), Arg.Any<IContactType>(), Arg.Any<IContactDetail>()).Returns(filteredData);
        }

        protected override Object CreateModelForDropDown1()
        {
            IContactType retVal = CoreInstance.IoC.Get<IContactType>();

            return retVal;
        }

        protected override Object CreateModelForDropDown2()
        {
            IContactDetail retVal = CoreInstance.IoC.Get<IContactDetail>();

            return retVal;
        }
    }
}
