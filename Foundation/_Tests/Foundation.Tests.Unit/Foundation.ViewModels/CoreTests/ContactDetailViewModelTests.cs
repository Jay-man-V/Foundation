//-----------------------------------------------------------------------
// <copyright file="ContactDetailViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Models.Core;
using Foundation.ViewModels.Core;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for ContactDetailViewModelTests
    /// </summary>
    [TestFixture]
    public class ContactDetailViewModelTests : GenericDataGridViewModelTests<IContactDetail, IContactDetailViewModel, IContactDetailProcess>
    {
        private IContactTypeProcess? ContactTypeProcess { get; set; }

        protected override IContactDetailProcess CreateBusinessProcess()
        {
            ContactTypeProcess = Substitute.For<IContactTypeProcess>();
            IContactDetailProcess process = Substitute.For<IContactDetailProcess>();

            return process;
        }

        protected override IContactDetail CreateBlankModel(Int32 entityId)
        {
            IContactDetail retVal = new ContactDetail();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IContactDetail CreateModel(Int32 entityId)
        {
            IContactDetail retVal = base.CreateModel(entityId);

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

        protected override IContactDetailViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IContactDetailViewModel viewModel = new ContactDetailViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess, ContactTypeProcess!);

            return viewModel;
        }


        protected override void SetupForRefreshData()
        {
            base.SetupForRefreshData();

            List<IContactType> contactTypes =
            [
                Substitute.For<IContactType>(),
                Substitute.For<IContactType>(),
            ];
            ContactTypeProcess!.GetAll().Returns(contactTypes);

            List<IContactDetail> parentContacts =
            [
                CreateModel(1),
                CreateModel(2),
            ];
            BusinessProcess.MakeListOfParentContacts(Arg.Any<List<IContactDetail>>()).Returns(parentContacts);

            List<IContactDetail> filteredData = [];
            BusinessProcess.ApplyFilter(Arg.Any<List<IContactDetail>>(), Arg.Any<IContactType>(), Arg.Any<IContactDetail>()).Returns(filteredData);
        }

        protected override Object CreateModelForDropDown1()
        {
            IContactType retVal = Substitute.For<IContactType>();

            return retVal;
        }

        protected override Object CreateModelForDropDown2()
        {
            IContactDetail retVal = Substitute.For<IContactDetail>();

            return retVal;
        }
    }
}
