//-----------------------------------------------------------------------
// <copyright file="ModelDataColumns.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Tests.Unit.BaseClasses;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Tests.Unit.Foundation.Resources.ConstantsTests
{
    /// <summary>
    /// Unit Tests for all Data Columns
    /// </summary>
    [TestFixture]
    public class ModelDataColumns : UnitTestBase
    {
        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_AllMembers()
        {
            IEnumerable<MethodInfo> testMethods = GetListOfTestMethods();
            Int32 testMethodCount = testMethods.Count();

            Type type = typeof(FDC.ActiveDirectoryUser);
            String targetNamespace = type.Namespace!;
            Assembly modelAssembly = type.Assembly;
            Type[] allModelTypes = modelAssembly.GetTypes();

            // Get a list of all types
            List<Type> allTypes = allModelTypes.Where(t => !String.IsNullOrEmpty(t.FullName) && 
                                                           !String.IsNullOrEmpty(t.Namespace) &&
                                                           t.Namespace.StartsWith(targetNamespace) &&
                                                           !t.Name.EndsWith("Lengths")
                                                           ).OrderBy(t2 => t2.Name).ToList();

            Int32 index = 0;

            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Stg  */ nameof(FDC.ActiveDirectoryUser)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Sec  */ nameof(FDC.Application)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Sec  */ nameof(FDC.ApplicationApplicationType)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.ApplicationConfiguration)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Sec  */ nameof(FDC.ApplicationRole)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Sec  */ nameof(FDC.ApplicationType)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Sec  */ nameof(FDC.ApplicationUserRole)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.ApprovalStatus)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Sec  */ nameof(FDC.AuthenticationToken)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* dbo  */ nameof(FDC.Catalogue)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* dbo  */ nameof(FDC.CatalogueItem)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.ConfigurationScope)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.ContactDetail)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.ContactType)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.Contract)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.ContractType)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.Country)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.Currency)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.Specialised.DatabaseSchemaColumn)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.Specialised.DatabaseSchemaTable)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.DataStatus)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.Department)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Log  */ nameof(FDC.EntityStatus)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Log  */ nameof(FDC.EventLog)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Log  */ nameof(FDC.EventLogApplication)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Log  */ nameof(FDC.EventLogAttachment)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Base */ nameof(FDC.FoundationEntity)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.IdGenerator)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.ImageType)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.ImportExportControl)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.Language)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Sec  */ nameof(FDC.LoggedOnUser)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Log  */ nameof(FDC.LogSeverity)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* App  */ nameof(FDC.MenuItem)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.NationalRegion)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.NonWorkingDay)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.Office)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.OfficeWeekCalendar)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.PermissionMatrix)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Sec  */ nameof(FDC.Role)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.ScheduledDataStatus)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.ScheduledJob)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.ScheduleInterval)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.Specialised)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.Status)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Base */ nameof(FDC.TableNames)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.TaskStatus)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.TimeZone)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Stg  */ nameof(FDC.ActiveDirectoryUser.User)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Sec  */ nameof(FDC.UserProfile)));
            Assert.That(allTypes[index++].Name, Is.EqualTo( /* Core */ nameof(FDC.WorldRegion)));

            Assert.That(allTypes.Count, Is.EqualTo(index));
            Assert.That(allTypes.Count, Is.EqualTo(testMethodCount - 1)); // -1 to remove the method Test_AllMembers

            foreach (Type enumType in allTypes)
            {
                //CheckAttributesOfEnumType(enumType);

                //TestEnumIdsAndValues(enumType);
            }
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_ActiveDirectoryUser()
        {
            // This test exists to ensure all the Active Directory User are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.ActiveDirectoryUser));
            Int32 index = 0;

            index++; Assert.That(FDC.ActiveDirectoryUser.EntityName, Is.EqualTo(nameof(FDC.ActiveDirectoryUser)));
            index++; Assert.That(FDC.ActiveDirectoryUser.ObjectSId, Is.EqualTo(nameof(FDC.ActiveDirectoryUser.ObjectSId)));
            index++; Assert.That(FDC.ActiveDirectoryUser.Name, Is.EqualTo(nameof(FDC.ActiveDirectoryUser.Name)));
            index++; Assert.That(FDC.ActiveDirectoryUser.FullName, Is.EqualTo(nameof(FDC.ActiveDirectoryUser.FullName)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_Application()
        {
            // This test exists to ensure all the Application are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.Application));
            Int32 index = 0;

            index++; Assert.That(FDC.Application.EntityName, Is.EqualTo(nameof(FDC.Application)));
            index++; Assert.That(FDC.Application.Name, Is.EqualTo(nameof(FDC.Application.Name)));
            index++; Assert.That(FDC.Application.Description, Is.EqualTo(nameof(FDC.Application.Description)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_ApplicationApplicationType()
        {
            // This test exists to ensure all the Application/Application Type are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.ApplicationApplicationType));
            Int32 index = 0;

            index++; Assert.That(FDC.ApplicationApplicationType.EntityName, Is.EqualTo(nameof(FDC.ApplicationApplicationType)));
            index++; Assert.That(FDC.ApplicationApplicationType.ApplicationId, Is.EqualTo(nameof(FDC.ApplicationApplicationType.ApplicationId)));
            index++; Assert.That(FDC.ApplicationApplicationType.ApplicationTypeId, Is.EqualTo(nameof(FDC.ApplicationApplicationType.ApplicationTypeId)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_ApplicationConfiguration()
        {
            // This test exists to ensure all the Application Configuration are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.ApplicationConfiguration));
            Int32 index = 0;

            index++; Assert.That(FDC.ApplicationConfiguration.EntityName, Is.EqualTo(nameof(FDC.ApplicationConfiguration)));
            index++; Assert.That(FDC.ApplicationConfiguration.ApplicationId, Is.EqualTo(nameof(FDC.ApplicationConfiguration.ApplicationId)));
            index++; Assert.That(FDC.ApplicationConfiguration.ConfigurationScopeId, Is.EqualTo(nameof(FDC.ApplicationConfiguration.ConfigurationScopeId)));
            index++; Assert.That(FDC.ApplicationConfiguration.Key, Is.EqualTo(nameof(FDC.ApplicationConfiguration.Key)));
            index++; Assert.That(FDC.ApplicationConfiguration.Value, Is.EqualTo(nameof(FDC.ApplicationConfiguration.Value)));
            index++; Assert.That(FDC.ApplicationConfiguration.IsEncrypted, Is.EqualTo(nameof(FDC.ApplicationConfiguration.IsEncrypted)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_ApplicationRole()
        {
            // This test exists to ensure all the Application Role are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.ApplicationRole));
            Int32 index = 0;

            index++; Assert.That(FDC.ApplicationRole.EntityName, Is.EqualTo(nameof(FDC.ApplicationRole)));
            index++; Assert.That(FDC.ApplicationRole.ApplicationId, Is.EqualTo(nameof(FDC.ApplicationRole.ApplicationId)));
            index++; Assert.That(FDC.ApplicationRole.RoleId, Is.EqualTo(nameof(FDC.ApplicationRole.RoleId)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_ApplicationType()
        {
            // This test exists to ensure all the Application Type are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.ApplicationType));
            Int32 index = 0;

            index++; Assert.That(FDC.ApplicationType.EntityName, Is.EqualTo(nameof(FDC.ApplicationType)));
            index++; Assert.That(FDC.ApplicationType.Name, Is.EqualTo(nameof(FDC.ApplicationType.Name)));
            index++; Assert.That(FDC.ApplicationType.Description, Is.EqualTo(nameof(FDC.ApplicationType.Description)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_ApplicationUserRole()
        {
            // This test exists to ensure all the Application User Role are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.ApplicationUserRole));
            Int32 index = 0;

            index++; Assert.That(FDC.ApplicationUserRole.EntityName, Is.EqualTo(nameof(FDC.ApplicationUserRole)));
            index++; Assert.That(FDC.ApplicationUserRole.ApplicationId, Is.EqualTo(nameof(FDC.ApplicationUserRole.ApplicationId)));
            index++; Assert.That(FDC.ApplicationUserRole.UserProfileId, Is.EqualTo(nameof(FDC.ApplicationUserRole.UserProfileId)));
            index++; Assert.That(FDC.ApplicationUserRole.RoleId, Is.EqualTo(nameof(FDC.ApplicationUserRole.RoleId)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_ApprovalStatus()
        {
            // This test exists to ensure all the Approval Status are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.ApprovalStatus));
            Int32 index = 0;

            index++; Assert.That(FDC.ApprovalStatus.EntityName, Is.EqualTo(nameof(FDC.ApprovalStatus)));
            index++; Assert.That(FDC.ApprovalStatus.Name, Is.EqualTo(nameof(FDC.ApprovalStatus.Name)));
            index++; Assert.That(FDC.ApprovalStatus.Description, Is.EqualTo(nameof(FDC.ApprovalStatus.Description)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_AuthenticationToken()
        {
            // This test exists to ensure all the Authentication Token are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.AuthenticationToken));
            Int32 index = 0;

            index++; Assert.That(FDC.AuthenticationToken.EntityName, Is.EqualTo(nameof(FDC.AuthenticationToken)));
            index++; Assert.That(FDC.AuthenticationToken.ApplicationId, Is.EqualTo(nameof(FDC.AuthenticationToken.ApplicationId)));
            index++; Assert.That(FDC.AuthenticationToken.UserProfileId, Is.EqualTo(nameof(FDC.AuthenticationToken.UserProfileId)));
            index++; Assert.That(FDC.AuthenticationToken.Token, Is.EqualTo(nameof(FDC.AuthenticationToken.Token)));
            index++; Assert.That(FDC.AuthenticationToken.Acquired, Is.EqualTo(nameof(FDC.AuthenticationToken.Acquired)));
            index++; Assert.That(FDC.AuthenticationToken.LastRefreshed, Is.EqualTo(nameof(FDC.AuthenticationToken.LastRefreshed)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_Catalogue()
        {
            // This test exists to ensure all the Catalogue are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.Catalogue));
            Int32 index = 0;

            index++; Assert.That(FDC.Catalogue.EntityName, Is.EqualTo(nameof(FDC.Catalogue)));
            index++; Assert.That(FDC.Catalogue.Name, Is.EqualTo(nameof(FDC.Catalogue.Name)));
            index++; Assert.That(FDC.Catalogue.Description, Is.EqualTo(nameof(FDC.Catalogue.Description)));
            index++; Assert.That(FDC.Catalogue.FrontCover, Is.EqualTo(nameof(FDC.Catalogue.FrontCover)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_CatalogueItem()
        {
            // This test exists to ensure all the Catalogue Item are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.CatalogueItem));
            Int32 index = 0;

            index++; Assert.That(FDC.CatalogueItem.EntityName, Is.EqualTo(nameof(FDC.CatalogueItem)));
            index++; Assert.That(FDC.CatalogueItem.Name, Is.EqualTo(nameof(FDC.CatalogueItem.Name)));
            index++; Assert.That(FDC.CatalogueItem.Description, Is.EqualTo(nameof(FDC.CatalogueItem.Description)));
            index++; Assert.That(FDC.CatalogueItem.Image, Is.EqualTo(nameof(FDC.CatalogueItem.Image)));
            index++; Assert.That(FDC.CatalogueItem.BuyCost, Is.EqualTo(nameof(FDC.CatalogueItem.BuyCost)));
            index++; Assert.That(FDC.CatalogueItem.VatRateId, Is.EqualTo(nameof(FDC.CatalogueItem.VatRateId)));
            index++; Assert.That(FDC.CatalogueItem.MarkUpRateId, Is.EqualTo(nameof(FDC.CatalogueItem.MarkUpRateId)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_ConfigurationScope()
        {
            // This test exists to ensure all the Application Configuration are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.ConfigurationScope));
            Int32 index = 0;

            index++; Assert.That(FDC.ConfigurationScope.EntityName, Is.EqualTo(nameof(FDC.ConfigurationScope)));
            index++; Assert.That(FDC.ConfigurationScope.Name, Is.EqualTo(nameof(FDC.ConfigurationScope.Name)));
            index++; Assert.That(FDC.ConfigurationScope.Description, Is.EqualTo(nameof(FDC.ConfigurationScope.Description)));
            index++; Assert.That(FDC.ConfigurationScope.UsageSequence, Is.EqualTo(nameof(FDC.ConfigurationScope.UsageSequence)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_ContactDetail()
        {
            // This test exists to ensure all the Contact Detail are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.ContactDetail));
            Int32 index = 0;

            index++; Assert.That(FDC.ContactDetail.EntityName, Is.EqualTo(nameof(FDC.ContactDetail)));
            index++; Assert.That(FDC.ContactDetail.ParentContactId, Is.EqualTo(nameof(FDC.ContactDetail.ParentContactId)));
            index++; Assert.That(FDC.ContactDetail.ContractId, Is.EqualTo(nameof(FDC.ContactDetail.ContractId)));
            index++; Assert.That(FDC.ContactDetail.ContactTypeId, Is.EqualTo(nameof(FDC.ContactDetail.ContactTypeId)));
            index++; Assert.That(FDC.ContactDetail.ShortName, Is.EqualTo(nameof(FDC.ContactDetail.ShortName)));
            index++; Assert.That(FDC.ContactDetail.DisplayName, Is.EqualTo(nameof(FDC.ContactDetail.DisplayName)));
            index++; Assert.That(FDC.ContactDetail.LegalName, Is.EqualTo(nameof(FDC.ContactDetail.LegalName)));
            index++; Assert.That(FDC.ContactDetail.Telephone1, Is.EqualTo(nameof(FDC.ContactDetail.Telephone1)));
            index++; Assert.That(FDC.ContactDetail.Telephone2, Is.EqualTo(nameof(FDC.ContactDetail.Telephone2)));
            index++; Assert.That(FDC.ContactDetail.EmailAddress, Is.EqualTo(nameof(FDC.ContactDetail.EmailAddress)));
            index++; Assert.That(FDC.ContactDetail.BuildingName, Is.EqualTo(nameof(FDC.ContactDetail.BuildingName)));
            index++; Assert.That(FDC.ContactDetail.Street1, Is.EqualTo(nameof(FDC.ContactDetail.Street1)));
            index++; Assert.That(FDC.ContactDetail.Street2, Is.EqualTo(nameof(FDC.ContactDetail.Street2)));
            index++; Assert.That(FDC.ContactDetail.Town, Is.EqualTo(nameof(FDC.ContactDetail.Town)));
            index++; Assert.That(FDC.ContactDetail.County, Is.EqualTo(nameof(FDC.ContactDetail.County)));
            index++; Assert.That(FDC.ContactDetail.PostCode, Is.EqualTo(nameof(FDC.ContactDetail.PostCode)));
            index++; Assert.That(FDC.ContactDetail.NationalRegionId, Is.EqualTo(nameof(FDC.ContactDetail.NationalRegionId)));
            index++; Assert.That(FDC.ContactDetail.CountryId, Is.EqualTo(nameof(FDC.ContactDetail.CountryId)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_ContactType()
        {
            // This test exists to ensure all the Contact Type are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.ContactType));
            Int32 index = 0;

            index++; Assert.That(FDC.ContactType.EntityName, Is.EqualTo(nameof(FDC.ContactType)));
            index++; Assert.That(FDC.ContactType.Name, Is.EqualTo(nameof(FDC.ContactType.Name)));
            index++; Assert.That(FDC.ContactType.Description, Is.EqualTo(nameof(FDC.ContactType.Description)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_Contract()
        {
            // This test exists to ensure all the Contract are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.Contract));
            Int32 index = 0;

            index++; Assert.That(FDC.Contract.EntityName, Is.EqualTo(nameof(FDC.Contract)));
            index++; Assert.That(FDC.Contract.ContractTypeId, Is.EqualTo(nameof(FDC.Contract.ContractTypeId)));
            index++; Assert.That(FDC.Contract.ContractReference, Is.EqualTo(nameof(FDC.Contract.ContractReference)));
            index++; Assert.That(FDC.Contract.ShortName, Is.EqualTo(nameof(FDC.Contract.ShortName)));
            index++; Assert.That(FDC.Contract.FullName, Is.EqualTo(nameof(FDC.Contract.FullName)));
            index++; Assert.That(FDC.Contract.StartDate, Is.EqualTo(nameof(FDC.Contract.StartDate)));
            index++; Assert.That(FDC.Contract.EndDate, Is.EqualTo(nameof(FDC.Contract.EndDate)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_ContractType()
        {
            // This test exists to ensure all the Contract Type are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.ContractType));
            Int32 index = 0;

            index++; Assert.That(FDC.ContractType.EntityName, Is.EqualTo(nameof(FDC.ContractType)));
            index++; Assert.That(FDC.ContractType.Name, Is.EqualTo(nameof(FDC.ContractType.Name)));
            index++; Assert.That(FDC.ContractType.Description, Is.EqualTo(nameof(FDC.ContractType.Description)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_Country()
        {
            // This test exists to ensure all the Country are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.Country));
            Int32 index = 0;

            index++; Assert.That(FDC.Country.EntityName, Is.EqualTo(nameof(FDC.Country)));
            index++; Assert.That(FDC.Country.IsoCode, Is.EqualTo(nameof(FDC.Country.IsoCode)));
            index++; Assert.That(FDC.Country.AbbreviatedName, Is.EqualTo(nameof(FDC.Country.AbbreviatedName)));
            index++; Assert.That(FDC.Country.FullName, Is.EqualTo(nameof(FDC.Country.FullName)));
            index++; Assert.That(FDC.Country.NativeName, Is.EqualTo(nameof(FDC.Country.NativeName)));
            index++; Assert.That(FDC.Country.DialingCode, Is.EqualTo(nameof(FDC.Country.DialingCode)));
            index++; Assert.That(FDC.Country.PostCodeFormat, Is.EqualTo(nameof(FDC.Country.PostCodeFormat)));
            index++; Assert.That(FDC.Country.CurrencyId, Is.EqualTo(nameof(FDC.Country.CurrencyId)));
            index++; Assert.That(FDC.Country.LanguageId, Is.EqualTo(nameof(FDC.Country.LanguageId)));
            index++; Assert.That(FDC.Country.TimeZoneId, Is.EqualTo(nameof(FDC.Country.TimeZoneId)));
            index++; Assert.That(FDC.Country.WorldRegionId, Is.EqualTo(nameof(FDC.Country.WorldRegionId)));
            index++; Assert.That(FDC.Country.CountryFlag, Is.EqualTo(nameof(FDC.Country.CountryFlag)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_Currency()
        {
            // This test exists to ensure all the Currency are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.Currency));
            Int32 index = 0;

            index++; Assert.That(FDC.Currency.EntityName, Is.EqualTo(nameof(FDC.Currency)));
            index++; Assert.That(FDC.Currency.PrefixSymbol, Is.EqualTo(nameof(FDC.Currency.PrefixSymbol)));
            index++; Assert.That(FDC.Currency.Symbol, Is.EqualTo(nameof(FDC.Currency.Symbol)));
            index++; Assert.That(FDC.Currency.IsoCode, Is.EqualTo(nameof(FDC.Currency.IsoCode)));
            index++; Assert.That(FDC.Currency.IsoNumber, Is.EqualTo(nameof(FDC.Currency.IsoNumber)));
            index++; Assert.That(FDC.Currency.Name, Is.EqualTo(nameof(FDC.Currency.Name)));
            index++; Assert.That(FDC.Currency.NumberToBasic, Is.EqualTo(nameof(FDC.Currency.NumberToBasic)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DataStatus()
        {
            // This test exists to ensure all the DataStatus are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.DataStatus));
            Int32 index = 0;

            index++; Assert.That(FDC.DataStatus.EntityName, Is.EqualTo(nameof(FDC.DataStatus)));
            index++; Assert.That(FDC.DataStatus.Name, Is.EqualTo(nameof(FDC.DataStatus.Name)));
            index++; Assert.That(FDC.DataStatus.Description, Is.EqualTo(nameof(FDC.DataStatus.Description)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_Departments()
        {
            // This test exists to ensure all the Department are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.Department));
            Int32 index = 0;

            index++; Assert.That(FDC.Department.EntityName, Is.EqualTo(nameof(FDC.Department)));
            index++; Assert.That(FDC.Department.Code, Is.EqualTo(nameof(FDC.Department.Code)));
            index++; Assert.That(FDC.Department.ShortName, Is.EqualTo(nameof(FDC.Department.ShortName)));
            index++; Assert.That(FDC.Department.Description, Is.EqualTo(nameof(FDC.Department.Description)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DatabaseSchemaColumn()
        {
            // This test exists to ensure all the DbSchemaColumn are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.Specialised.DatabaseSchemaColumn));
            Int32 index = 0;

            index++; Assert.That(FDC.Specialised.DatabaseSchemaColumn.EntityName, Is.EqualTo(nameof(FDC.Specialised.DatabaseSchemaColumn)));
            index++; Assert.That(FDC.Specialised.DatabaseSchemaColumn.TableCatalog, Is.EqualTo("TABLE_CATALOG"));
            index++; Assert.That(FDC.Specialised.DatabaseSchemaColumn.TableSchema, Is.EqualTo("TABLE_SCHEMA"));
            index++; Assert.That(FDC.Specialised.DatabaseSchemaColumn.TableName, Is.EqualTo("TABLE_NAME"));
            index++; Assert.That(FDC.Specialised.DatabaseSchemaColumn.ColumnName, Is.EqualTo("COLUMN_NAME"));
            index++; Assert.That(FDC.Specialised.DatabaseSchemaColumn.DataType, Is.EqualTo("DATA_TYPE"));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DbSchemaTable()
        {
            // This test exists to ensure all the DbSchemaTable are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.Specialised.DatabaseSchemaTable));
            Int32 index = 0;

            index++; Assert.That(FDC.Specialised.DatabaseSchemaTable.EntityName, Is.EqualTo(nameof(FDC.Specialised.DatabaseSchemaTable)));
            index++; Assert.That(FDC.Specialised.DatabaseSchemaTable.TableCatalog, Is.EqualTo("TABLE_CATALOG"));
            index++; Assert.That(FDC.Specialised.DatabaseSchemaTable.TableSchema, Is.EqualTo("TABLE_SCHEMA"));
            index++; Assert.That(FDC.Specialised.DatabaseSchemaTable.TableName, Is.EqualTo("TABLE_NAME"));
            index++; Assert.That(FDC.Specialised.DatabaseSchemaTable.TableType, Is.EqualTo("TABLE_TYPE"));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_Entity()
        {
            // This test exists to ensure all the Approval Status are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.FoundationEntity));
            Int32 index = 0;

            index++; Assert.That(FDC.FoundationEntity.Id, Is.EqualTo(nameof(FDC.FoundationEntity.Id)));
            index++; Assert.That(FDC.FoundationEntity.Timestamp, Is.EqualTo(nameof(FDC.FoundationEntity.Timestamp)));
            index++; Assert.That(FDC.FoundationEntity.StatusId, Is.EqualTo(nameof(FDC.FoundationEntity.StatusId)));
            index++; Assert.That(FDC.FoundationEntity.CreatedByUserProfileId, Is.EqualTo(nameof(FDC.FoundationEntity.CreatedByUserProfileId)));
            index++; Assert.That(FDC.FoundationEntity.LastUpdatedByUserProfileId, Is.EqualTo(nameof(FDC.FoundationEntity.LastUpdatedByUserProfileId)));
            index++; Assert.That(FDC.FoundationEntity.CreatedOn, Is.EqualTo(nameof(FDC.FoundationEntity.CreatedOn)));
            index++; Assert.That(FDC.FoundationEntity.LastUpdatedOn, Is.EqualTo(nameof(FDC.FoundationEntity.LastUpdatedOn)));
            index++; Assert.That(FDC.FoundationEntity.ValidFrom, Is.EqualTo(nameof(FDC.FoundationEntity.ValidFrom)));
            index++; Assert.That(FDC.FoundationEntity.ValidTo, Is.EqualTo(nameof(FDC.FoundationEntity.ValidTo)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_EntityStatus()
        {
            // This test exists to ensure all the Entity Status are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.EntityStatus));
            Int32 index = 0;

            index++; Assert.That(FDC.EntityStatus.EntityName, Is.EqualTo(nameof(FDC.EntityStatus)));
            index++; Assert.That(FDC.EntityStatus.Name, Is.EqualTo(nameof(FDC.EntityStatus.Name)));
            index++; Assert.That(FDC.EntityStatus.Description, Is.EqualTo(nameof(FDC.EntityStatus.Description)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_EventLog()
        {
            // This test exists to ensure all the Event Log are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.EventLog));
            Int32 index = 0;

            index++; Assert.That(FDC.EventLog.EntityName, Is.EqualTo(nameof(FDC.EventLog)));
            index++; Assert.That(FDC.EventLog.ApplicationId, Is.EqualTo(nameof(FDC.EventLog.ApplicationId)));
            index++; Assert.That(FDC.EventLog.ParentId, Is.EqualTo(nameof(FDC.EventLog.ParentId)));
            index++; Assert.That(FDC.EventLog.LogSeverityId, Is.EqualTo(nameof(FDC.EventLog.LogSeverityId)));
            index++; Assert.That(FDC.EventLog.ScheduledTaskId, Is.EqualTo(nameof(FDC.EventLog.ScheduledTaskId)));
            index++; Assert.That(FDC.EventLog.BatchName, Is.EqualTo(nameof(FDC.EventLog.BatchName)));
            index++; Assert.That(FDC.EventLog.ProcessName, Is.EqualTo(nameof(FDC.EventLog.ProcessName)));
            index++; Assert.That(FDC.EventLog.TaskName, Is.EqualTo(nameof(FDC.EventLog.TaskName)));
            index++; Assert.That(FDC.EventLog.TaskStatusId, Is.EqualTo(nameof(FDC.EventLog.TaskStatusId)));
            index++; Assert.That(FDC.EventLog.StartedOn, Is.EqualTo(nameof(FDC.EventLog.StartedOn)));
            index++; Assert.That(FDC.EventLog.FinishedOn, Is.EqualTo(nameof(FDC.EventLog.FinishedOn)));
            index++; Assert.That(FDC.EventLog.Information, Is.EqualTo(nameof(FDC.EventLog.Information)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_EventLogApplication()
        {
            // This test exists to ensure all the Event Log Application are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.EventLogApplication));
            Int32 index = 0;

            index++; Assert.That(FDC.EventLogApplication.EntityName, Is.EqualTo(nameof(FDC.EventLogApplication)));
            index++; Assert.That(FDC.EventLogApplication.ApplicationId, Is.EqualTo(nameof(FDC.EventLogApplication.ApplicationId)));
            index++; Assert.That(FDC.EventLogApplication.ShortName, Is.EqualTo(nameof(FDC.EventLogApplication.ShortName)));
            index++; Assert.That(FDC.EventLogApplication.ProcessName, Is.EqualTo(nameof(FDC.EventLogApplication.ProcessName)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_EventLogAttachment()
        {
            // This test exists to ensure all the Event Log Attachment are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.EventLogAttachment));
            Int32 index = 0;

            index++; Assert.That(FDC.EventLogAttachment.EntityName, Is.EqualTo(nameof(FDC.EventLogAttachment)));
            index++; Assert.That(FDC.EventLogAttachment.EventLogId, Is.EqualTo(nameof(FDC.EventLogAttachment.EventLogId)));
            index++; Assert.That(FDC.EventLogAttachment.AttachmentFileName, Is.EqualTo(nameof(FDC.EventLogAttachment.AttachmentFileName)));
            index++; Assert.That(FDC.EventLogAttachment.Attachment, Is.EqualTo(nameof(FDC.EventLogAttachment.Attachment)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        ///// <summary>
        /////
        ///// </summary>
        //[TestCase]
        //public void Test_FunctionNames()
        //{
        //    // This test exists to ensure all the Image Type are tested/checked in the next test
        //    PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.FunctionNames));
        //    Int32 index = 0;

        //    index++; Assert.That(FDC.FunctionNames.CheckIsWorkingDayOrGetNextWorkingDay, Is.EqualTo("[dbo].[ufn_CheckIsWorkingDayOrGetNextWorkingDay]"));
        //    index++; Assert.That(FDC.FunctionNames.GetNextWorkingDay, Is.EqualTo("[dbo].[ufn_GetNextWorkingDay]"));
        //    index++; Assert.That(FDC.FunctionNames.IsNonWorkingDay, Is.EqualTo("[dbo].[ufn_IsNonWorkingDay]"));
        //    index++; Assert.That(FDC.FunctionNames.GetListOfActiveStatuses, Is.EqualTo("[dbo].[ufn_GetListOfActiveStatuses]"));
        //    index++; Assert.That(FDC.FunctionNames.GetListOfCalendarDates, Is.EqualTo("[dbo].[ufn_GetListOfCalendarDates]"));
        //    index++; Assert.That(FDC.FunctionNames.GetListOfWorkingDates, Is.EqualTo("[dbo].[ufn_GetListOfWorkingDates]"));

        //    Assert.That(propertyInfos.Length, Is.EqualTo(index));
        //}

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_IdGenerator()
        {
            // This test exists to ensure all the Image Type are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.IdGenerator));
            Int32 index = 0;

            index++; Assert.That(FDC.IdGenerator.EntityName, Is.EqualTo(nameof(FDC.IdGenerator)));
            index++; Assert.That(FDC.IdGenerator.ApplicationId, Is.EqualTo(nameof(FDC.IdGenerator.ApplicationId)));
            index++; Assert.That(FDC.IdGenerator.ConfigurationScopeId, Is.EqualTo(nameof(FDC.IdGenerator.ConfigurationScopeId)));
            index++; Assert.That(FDC.IdGenerator.IdName, Is.EqualTo(nameof(FDC.IdGenerator.IdName)));
            index++; Assert.That(FDC.IdGenerator.LastId, Is.EqualTo(nameof(FDC.IdGenerator.LastId)));
            index++; Assert.That(FDC.IdGenerator.ResetOnNewDate, Is.EqualTo(nameof(FDC.IdGenerator.ResetOnNewDate)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_ImageType()
        {
            // This test exists to ensure all the Image Type are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.ImageType));
            Int32 index = 0;

            index++; Assert.That(FDC.ImageType.EntityName, Is.EqualTo(nameof(FDC.ImageType)));
            index++; Assert.That(FDC.ImageType.Name, Is.EqualTo(nameof(FDC.ImageType.Name)));
            index++; Assert.That(FDC.ImageType.FileExtension, Is.EqualTo(nameof(FDC.ImageType.FileExtension)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_ImportExportControl()
        {
            // This test exists to ensure all the Import Export Control are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.ImportExportControl));
            Int32 index = 0;

            index++; Assert.That(FDC.ImportExportControl.EntityName, Is.EqualTo(nameof(FDC.ImportExportControl)));
            index++; Assert.That(FDC.ImportExportControl.Name, Is.EqualTo(nameof(FDC.ImportExportControl.Name)));
            index++; Assert.That(FDC.ImportExportControl.ProcessedOn, Is.EqualTo(nameof(FDC.ImportExportControl.ProcessedOn)));
            index++; Assert.That(FDC.ImportExportControl.InProgress, Is.EqualTo(nameof(FDC.ImportExportControl.InProgress)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_Language()
        {
            // This test exists to ensure all the Language are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.Language));
            Int32 index = 0;

            index++; Assert.That(FDC.Language.EntityName, Is.EqualTo(nameof(FDC.Language)));
            index++; Assert.That(FDC.Language.EnglishName, Is.EqualTo(nameof(FDC.Language.EnglishName)));
            index++; Assert.That(FDC.Language.NativeName, Is.EqualTo(nameof(FDC.Language.NativeName)));
            index++; Assert.That(FDC.Language.CultureCode, Is.EqualTo(nameof(FDC.Language.CultureCode)));
            index++; Assert.That(FDC.Language.UiCultureCode, Is.EqualTo(nameof(FDC.Language.UiCultureCode)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_LoggedOnUser()
        {
            // This test exists to ensure all the Approval Status are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.LoggedOnUser));
            Int32 index = 0;

            index++; Assert.That(FDC.LoggedOnUser.EntityName, Is.EqualTo(nameof(FDC.LoggedOnUser)));
            index++; Assert.That(FDC.LoggedOnUser.ApplicationId, Is.EqualTo(nameof(FDC.LoggedOnUser.ApplicationId)));
            index++; Assert.That(FDC.LoggedOnUser.UserProfileId, Is.EqualTo(nameof(FDC.LoggedOnUser.UserProfileId)));
            index++; Assert.That(FDC.LoggedOnUser.LoggedOn, Is.EqualTo(nameof(FDC.LoggedOnUser.LoggedOn)));
            index++; Assert.That(FDC.LoggedOnUser.LastActive, Is.EqualTo(nameof(FDC.LoggedOnUser.LastActive)));
            index++; Assert.That(FDC.LoggedOnUser.Command, Is.EqualTo(nameof(FDC.LoggedOnUser.Command)));
            index++; Assert.That(FDC.LoggedOnUser.DisplayName, Is.EqualTo(nameof(FDC.LoggedOnUser.DisplayName)));
            index++; Assert.That(FDC.LoggedOnUser.Username, Is.EqualTo(nameof(FDC.LoggedOnUser.Username)));
            index++; Assert.That(FDC.LoggedOnUser.RoleId, Is.EqualTo(nameof(FDC.LoggedOnUser.RoleId)));
            index++; Assert.That(FDC.LoggedOnUser.RoleDescription, Is.EqualTo(nameof(FDC.LoggedOnUser.RoleDescription)));
            index++; Assert.That(FDC.LoggedOnUser.IsSystemSupport, Is.EqualTo(nameof(FDC.LoggedOnUser.IsSystemSupport)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_LogSeverity()
        {
            // This test exists to ensure all the Log Severity are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.LogSeverity));
            Int32 index = 0;

            index++; Assert.That(FDC.LogSeverity.EntityName, Is.EqualTo(nameof(FDC.LogSeverity)));
            index++; Assert.That(FDC.LogSeverity.Code, Is.EqualTo(nameof(FDC.LogSeverity.Code)));
            index++; Assert.That(FDC.LogSeverity.Description, Is.EqualTo(nameof(FDC.LogSeverity.Description)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_MenuItem()
        {
            // This test exists to ensure all the Menu Item are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.MenuItem));
            Int32 index = 0;

            index++; Assert.That(FDC.MenuItem.EntityName, Is.EqualTo(nameof(FDC.MenuItem)));
            index++; Assert.That(FDC.MenuItem.ApplicationId, Is.EqualTo(nameof(FDC.MenuItem.ApplicationId)));
            index++; Assert.That(FDC.MenuItem.ParentMenuItemId, Is.EqualTo(nameof(FDC.MenuItem.ParentMenuItemId)));
            index++; Assert.That(FDC.MenuItem.Name, Is.EqualTo(nameof(FDC.MenuItem.Name)));
            index++; Assert.That(FDC.MenuItem.Caption, Is.EqualTo(nameof(FDC.MenuItem.Caption)));
            index++; Assert.That(FDC.MenuItem.ControllerAssembly, Is.EqualTo(nameof(FDC.MenuItem.ControllerAssembly)));
            index++; Assert.That(FDC.MenuItem.ControllerType, Is.EqualTo(nameof(FDC.MenuItem.ControllerType)));
            index++; Assert.That(FDC.MenuItem.ViewAssembly, Is.EqualTo(nameof(FDC.MenuItem.ViewAssembly)));
            index++; Assert.That(FDC.MenuItem.ViewType, Is.EqualTo(nameof(FDC.MenuItem.ViewType)));
            index++; Assert.That(FDC.MenuItem.HelpText, Is.EqualTo(nameof(FDC.MenuItem.HelpText)));
            index++; Assert.That(FDC.MenuItem.MultiInstance, Is.EqualTo(nameof(FDC.MenuItem.MultiInstance)));
            index++; Assert.That(FDC.MenuItem.ShowInTab, Is.EqualTo(nameof(FDC.MenuItem.ShowInTab)));
            index++; Assert.That(FDC.MenuItem.Icon, Is.EqualTo(nameof(FDC.MenuItem.Icon)));
            index++; Assert.That(FDC.MenuItem.Depth, Is.EqualTo(nameof(FDC.MenuItem.Depth)));
            index++; Assert.That(FDC.MenuItem.DisplayOrder, Is.EqualTo(nameof(FDC.MenuItem.DisplayOrder)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_NationalRegion()
        {
            // This test exists to ensure all the National Region are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.NationalRegion));
            Int32 index = 0;

            index++; Assert.That(FDC.NationalRegion.EntityName, Is.EqualTo(nameof(FDC.NationalRegion)));
            index++; Assert.That(FDC.NationalRegion.CountryId, Is.EqualTo(nameof(FDC.NationalRegion.CountryId)));
            index++; Assert.That(FDC.NationalRegion.Abbreviation, Is.EqualTo(nameof(FDC.NationalRegion.Abbreviation)));
            index++; Assert.That(FDC.NationalRegion.ShortName, Is.EqualTo(nameof(FDC.NationalRegion.ShortName)));
            index++; Assert.That(FDC.NationalRegion.FullName, Is.EqualTo(nameof(FDC.NationalRegion.FullName)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_NonWorkingDay()
        {
            // This test exists to ensure all the Non-Working Day are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.NonWorkingDay));
            Int32 index = 0;

            index++; Assert.That(FDC.NonWorkingDay.EntityName, Is.EqualTo(nameof(FDC.NonWorkingDay)));
            index++; Assert.That(FDC.NonWorkingDay.Date, Is.EqualTo(nameof(FDC.NonWorkingDay.Date)));
            index++; Assert.That(FDC.NonWorkingDay.Description, Is.EqualTo(nameof(FDC.NonWorkingDay.Description)));
            index++; Assert.That(FDC.NonWorkingDay.Notes, Is.EqualTo(nameof(FDC.NonWorkingDay.Notes)));
            index++; Assert.That(FDC.NonWorkingDay.CountryId, Is.EqualTo(nameof(FDC.NonWorkingDay.CountryId)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_Office()
        {
            // This test exists to ensure all the Office are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.Office));
            Int32 index = 0;

            index++; Assert.That(FDC.Office.EntityName, Is.EqualTo(nameof(FDC.Office)));
            index++; Assert.That(FDC.Office.Code, Is.EqualTo(nameof(FDC.Office.Code)));
            index++; Assert.That(FDC.Office.ShortName, Is.EqualTo(nameof(FDC.Office.ShortName)));
            index++; Assert.That(FDC.Office.ContactDetailId, Is.EqualTo(nameof(FDC.Office.ContactDetailId)));
            index++; Assert.That(FDC.Office.OfficeWeekCalendarId, Is.EqualTo(nameof(FDC.Office.OfficeWeekCalendarId)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_OfficeWeekCalendar()
        {
            // This test exists to ensure all the Office Week Calendar are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.OfficeWeekCalendar));
            Int32 index = 0;

            index++; Assert.That(FDC.OfficeWeekCalendar.EntityName, Is.EqualTo(nameof(FDC.OfficeWeekCalendar)));
            index++; Assert.That(FDC.OfficeWeekCalendar.Code, Is.EqualTo(nameof(FDC.OfficeWeekCalendar.Code)));
            index++; Assert.That(FDC.OfficeWeekCalendar.ShortName, Is.EqualTo(nameof(FDC.OfficeWeekCalendar.ShortName)));
            index++; Assert.That(FDC.OfficeWeekCalendar.Mon, Is.EqualTo(nameof(FDC.OfficeWeekCalendar.Mon)));
            index++; Assert.That(FDC.OfficeWeekCalendar.Tue, Is.EqualTo(nameof(FDC.OfficeWeekCalendar.Tue)));
            index++; Assert.That(FDC.OfficeWeekCalendar.Wed, Is.EqualTo(nameof(FDC.OfficeWeekCalendar.Wed)));
            index++; Assert.That(FDC.OfficeWeekCalendar.Thu, Is.EqualTo(nameof(FDC.OfficeWeekCalendar.Thu)));
            index++; Assert.That(FDC.OfficeWeekCalendar.Fri, Is.EqualTo(nameof(FDC.OfficeWeekCalendar.Fri)));
            index++; Assert.That(FDC.OfficeWeekCalendar.Sat, Is.EqualTo(nameof(FDC.OfficeWeekCalendar.Sat)));
            index++; Assert.That(FDC.OfficeWeekCalendar.Sun, Is.EqualTo(nameof(FDC.OfficeWeekCalendar.Sun)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_PermissionMatrix()
        {
            // This test exists to ensure all the PermissionMatrix are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.PermissionMatrix));
            Int32 index = 0;

            index++; Assert.That(FDC.PermissionMatrix.EntityName, Is.EqualTo(nameof(FDC.PermissionMatrix)));
            index++; Assert.That(FDC.PermissionMatrix.ApplicationId, Is.EqualTo(nameof(FDC.PermissionMatrix.ApplicationId)));
            index++; Assert.That(FDC.PermissionMatrix.RoleId, Is.EqualTo(nameof(FDC.PermissionMatrix.RoleId)));
            index++; Assert.That(FDC.PermissionMatrix.UserProfileId, Is.EqualTo(nameof(FDC.PermissionMatrix.UserProfileId)));
            index++; Assert.That(FDC.PermissionMatrix.FunctionKey, Is.EqualTo(nameof(FDC.PermissionMatrix.FunctionKey)));
            index++; Assert.That(FDC.PermissionMatrix.Permission, Is.EqualTo(nameof(FDC.PermissionMatrix.Permission)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_Role()
        {
            // This test exists to ensure all the Role are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.Role));
            Int32 index = 0;

            index++; Assert.That(FDC.Role.EntityName, Is.EqualTo(nameof(FDC.Role)));
            index++; Assert.That(FDC.Role.Name, Is.EqualTo(nameof(FDC.Role.Name)));
            index++; Assert.That(FDC.Role.Description, Is.EqualTo(nameof(FDC.Role.Description)));
            index++; Assert.That(FDC.Role.SystemSupportOnly, Is.EqualTo(nameof(FDC.Role.SystemSupportOnly)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_ScheduledJob()
        {
            // This test exists to ensure all the Scheduled Task are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.ScheduledJob));
            Int32 index = 0;

            index++; Assert.That(FDC.ScheduledJob.EntityName, Is.EqualTo(nameof(FDC.ScheduledJob)));
            index++; Assert.That(FDC.ScheduledJob.Name, Is.EqualTo(nameof(FDC.ScheduledJob.Name)));
            index++; Assert.That(FDC.ScheduledJob.ScheduleIntervalId, Is.EqualTo(nameof(FDC.ScheduledJob.ScheduleIntervalId)));
            index++; Assert.That(FDC.ScheduledJob.LastRunDateTime, Is.EqualTo(nameof(FDC.ScheduledJob.LastRunDateTime)));
            index++; Assert.That(FDC.ScheduledJob.NextRunDateTime, Is.EqualTo(nameof(FDC.ScheduledJob.NextRunDateTime)));
            index++; Assert.That(FDC.ScheduledJob.RunImmediately, Is.EqualTo(nameof(FDC.ScheduledJob.RunImmediately)));
            index++; Assert.That(FDC.ScheduledJob.StartTime, Is.EqualTo(nameof(FDC.ScheduledJob.StartTime)));
            index++; Assert.That(FDC.ScheduledJob.EndTime, Is.EqualTo(nameof(FDC.ScheduledJob.EndTime)));
            index++; Assert.That(FDC.ScheduledJob.Interval, Is.EqualTo(nameof(FDC.ScheduledJob.Interval)));
            index++; Assert.That(FDC.ScheduledJob.IsEnabled, Is.EqualTo(nameof(FDC.ScheduledJob.IsEnabled)));
            index++; Assert.That(FDC.ScheduledJob.TaskImplementationType, Is.EqualTo(nameof(FDC.ScheduledJob.TaskImplementationType)));
            index++; Assert.That(FDC.ScheduledJob.TaskParameters, Is.EqualTo(nameof(FDC.ScheduledJob.TaskParameters)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_ScheduledDataStatus()
        {
            // This test exists to ensure all the Scheduled Data Status are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.ScheduledDataStatus));
            Int32 index = 0;

            index++; Assert.That(FDC.ScheduledDataStatus.EntityName, Is.EqualTo(nameof(FDC.ScheduledDataStatus)));
            index++; Assert.That(FDC.ScheduledDataStatus.DataDate, Is.EqualTo(nameof(FDC.ScheduledDataStatus.DataDate)));
            index++; Assert.That(FDC.ScheduledDataStatus.Name, Is.EqualTo(nameof(FDC.ScheduledDataStatus.Name)));
            index++; Assert.That(FDC.ScheduledDataStatus.DataStatusId, Is.EqualTo(nameof(FDC.ScheduledDataStatus.DataStatusId)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_ScheduleInterval()
        {
            // This test exists to ensure all the Schedule Interval are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.ScheduleInterval));
            Int32 index = 0;

            index++; Assert.That(FDC.ScheduleInterval.EntityName, Is.EqualTo(nameof(FDC.ScheduleInterval)));
            index++; Assert.That(FDC.ScheduleInterval.Name, Is.EqualTo(nameof(FDC.ScheduleInterval.Name)));
            index++; Assert.That(FDC.ScheduleInterval.Description, Is.EqualTo(nameof(FDC.ScheduleInterval.Description)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_Status()
        {
            // This test exists to ensure all the Status are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.Status));
            Int32 index = 0;

            index++; Assert.That(FDC.Status.EntityName, Is.EqualTo(nameof(FDC.Status)));
            index++; Assert.That(FDC.Status.Name, Is.EqualTo(nameof(FDC.Status.Name)));
            index++; Assert.That(FDC.Status.Description, Is.EqualTo(nameof(FDC.Status.Description)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        ///// <summary>
        /////
        ///// </summary>
        //[TestCase]
        //public void Test_StoredProcedureNames()
        //{
        //    // This test exists to ensure all the Status are tested/checked in the next test
        //    PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.StoredProcedureNames));
        //    Int32 index = 0;

        //    index++; Assert.That(FDC.StoredProcedureNames.NonWorkingDaysGetWorkingDays, Is.EqualTo("[core].[usp_NonWorkingDays_GetWorkingDays]"));
        //    index++; Assert.That(FDC.StoredProcedureNames.NonWorkingDaysGetWorkingDaysByMonth, Is.EqualTo("[core].[usp_NonWorkingDays_GetWorkingDaysByMonth]"));
        //    index++; Assert.That(FDC.StoredProcedureNames.UserProfileLoadFromActiveDirectoryUsersFromStaging, Is.EqualTo("[sec].[usp_UserProfile_LoadFromActiveDirectoryUsersFromStaging]"));

        //    Assert.That(propertyInfos.Length, Is.EqualTo(index));
        //}

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_TableNames()
        {
            // This test exists to ensure all the Approval Status are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.TableNames));
            Int32 index = 0;

            index++; Assert.That(FDC.TableNames.Catalogue, Is.EqualTo($"[dbo].[{nameof(FDC.TableNames.Catalogue)}]"));
            index++; Assert.That(FDC.TableNames.CatalogueItem, Is.EqualTo($"[dbo].[{nameof(FDC.TableNames.CatalogueItem)}]"));

            index++; Assert.That(FDC.TableNames.MenuItem, Is.EqualTo($"[app].[{nameof(FDC.TableNames.MenuItem)}]"));

            index++; Assert.That(FDC.TableNames.ApplicationConfiguration, Is.EqualTo($"[core].[{nameof(FDC.TableNames.ApplicationConfiguration)}]"));
            index++; Assert.That(FDC.TableNames.ApprovalStatus, Is.EqualTo($"[core].[{nameof(FDC.TableNames.ApprovalStatus)}]"));
            index++; Assert.That(FDC.TableNames.ConfigurationScope, Is.EqualTo($"[core].[{nameof(FDC.TableNames.ConfigurationScope)}]"));
            index++; Assert.That(FDC.TableNames.ContactDetail, Is.EqualTo($"[core].[{nameof(FDC.TableNames.ContactDetail)}]"));
            index++; Assert.That(FDC.TableNames.ContactType, Is.EqualTo($"[core].[{nameof(FDC.TableNames.ContactType)}]"));
            index++; Assert.That(FDC.TableNames.Contract, Is.EqualTo($"[core].[{nameof(FDC.TableNames.Contract)}]"));
            index++; Assert.That(FDC.TableNames.ContractType, Is.EqualTo($"[core].[{nameof(FDC.TableNames.ContractType)}]"));
            index++; Assert.That(FDC.TableNames.Country, Is.EqualTo($"[core].[{nameof(FDC.TableNames.Country)}]"));
            index++; Assert.That(FDC.TableNames.Currency, Is.EqualTo($"[core].[{nameof(FDC.TableNames.Currency)}]"));
            index++; Assert.That(FDC.TableNames.DataStatus, Is.EqualTo($"[core].[{nameof(FDC.TableNames.DataStatus)}]"));
            index++; Assert.That(FDC.TableNames.Department, Is.EqualTo($"[core].[{nameof(FDC.TableNames.Department)}]"));
            index++; Assert.That(FDC.TableNames.EntityStatus, Is.EqualTo($"[core].[{nameof(FDC.TableNames.EntityStatus)}]"));
            index++; Assert.That(FDC.TableNames.IdGenerator, Is.EqualTo($"[core].[{nameof(FDC.TableNames.IdGenerator)}]"));
            index++; Assert.That(FDC.TableNames.ImageType, Is.EqualTo($"[core].[{nameof(FDC.TableNames.ImageType)}]"));
            index++; Assert.That(FDC.TableNames.Language, Is.EqualTo($"[core].[{nameof(FDC.TableNames.Language)}]"));
            index++; Assert.That(FDC.TableNames.NationalRegion, Is.EqualTo($"[core].[{nameof(FDC.TableNames.NationalRegion)}]"));
            index++; Assert.That(FDC.TableNames.NonWorkingDay, Is.EqualTo($"[core].[{nameof(FDC.TableNames.NonWorkingDay)}]"));
            index++; Assert.That(FDC.TableNames.Office, Is.EqualTo($"[core].[{nameof(FDC.TableNames.Office)}]"));
            index++; Assert.That(FDC.TableNames.OfficeWeekCalendar, Is.EqualTo($"[core].[{nameof(FDC.TableNames.OfficeWeekCalendar)}]"));
            index++; Assert.That(FDC.TableNames.ScheduledJob, Is.EqualTo($"[core].[{nameof(FDC.TableNames.ScheduledJob)}]"));
            index++; Assert.That(FDC.TableNames.ScheduleInterval, Is.EqualTo($"[core].[{nameof(FDC.TableNames.ScheduleInterval)}]"));
            index++; Assert.That(FDC.TableNames.Status, Is.EqualTo($"[core].[{nameof(FDC.TableNames.Status)}]"));
            index++; Assert.That(FDC.TableNames.TaskStatus, Is.EqualTo($"[core].[{nameof(FDC.TableNames.TaskStatus)}]"));
            index++; Assert.That(FDC.TableNames.TimeZone, Is.EqualTo($"[core].[{nameof(FDC.TableNames.TimeZone)}]"));
            index++; Assert.That(FDC.TableNames.WorldRegion, Is.EqualTo($"[core].[{nameof(FDC.TableNames.WorldRegion)}]"));

            index++; Assert.That(FDC.TableNames.EventLog, Is.EqualTo($"[log].[{nameof(FDC.TableNames.EventLog)}]"));
            index++; Assert.That(FDC.TableNames.EventLogApplication, Is.EqualTo($"[log].[{nameof(FDC.TableNames.EventLogApplication)}]"));
            index++; Assert.That(FDC.TableNames.EventLogAttachment, Is.EqualTo($"[log].[{nameof(FDC.TableNames.EventLogAttachment)}]"));
            index++; Assert.That(FDC.TableNames.ImportExportControl, Is.EqualTo($"[log].[{nameof(FDC.TableNames.ImportExportControl)}]"));
            index++; Assert.That(FDC.TableNames.LogSeverity, Is.EqualTo($"[log].[{nameof(FDC.TableNames.LogSeverity)}]"));
            index++; Assert.That(FDC.TableNames.ScheduledDataStatus, Is.EqualTo($"[log].[{nameof(FDC.TableNames.ScheduledDataStatus)}]"));

            index++; Assert.That(FDC.TableNames.Application, Is.EqualTo($"[sec].[{nameof(FDC.TableNames.Application)}]"));
            index++; Assert.That(FDC.TableNames.ApplicationApplicationType, Is.EqualTo($"[sec].[{nameof(FDC.TableNames.ApplicationApplicationType)}]"));
            index++; Assert.That(FDC.TableNames.ApplicationRole, Is.EqualTo($"[sec].[{nameof(FDC.TableNames.ApplicationRole)}]"));
            index++; Assert.That(FDC.TableNames.ApplicationType, Is.EqualTo($"[sec].[{nameof(FDC.TableNames.ApplicationType)}]"));
            index++; Assert.That(FDC.TableNames.ApplicationUserRole, Is.EqualTo($"[sec].[{nameof(FDC.TableNames.ApplicationUserRole)}]"));
            index++; Assert.That(FDC.TableNames.AuthenticationToken, Is.EqualTo($"[sec].[{nameof(FDC.TableNames.AuthenticationToken)}]"));
            index++; Assert.That(FDC.TableNames.LoggedOnUser, Is.EqualTo($"[sec].[{nameof(FDC.TableNames.LoggedOnUser)}]"));
            index++; Assert.That(FDC.TableNames.PermissionMatrix, Is.EqualTo($"[sec].[{nameof(FDC.TableNames.PermissionMatrix)}]"));
            index++; Assert.That(FDC.TableNames.Role, Is.EqualTo($"[sec].[{nameof(FDC.TableNames.Role)}]"));
            index++; Assert.That(FDC.TableNames.UserProfile, Is.EqualTo($"[sec].[{nameof(FDC.TableNames.UserProfile)}]"));

            index++; Assert.That(FDC.TableNames.ActiveDirectoryUser, Is.EqualTo($"[stg].[{nameof(FDC.TableNames.ActiveDirectoryUser)}]"));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_TableNames_Specialised()
        {
            // This test exists to ensure all the Table Names are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.TableNames.Specialised));
            Int32 index = 0;

            index++; Assert.That(FDC.TableNames.Specialised.DbSchemaColumn, Is.EqualTo("[INFORMATION_SCHEMA].[COLUMNS]"));
            index++; Assert.That(FDC.TableNames.Specialised.DbSchemaTable, Is.EqualTo("[INFORMATION_SCHEMA].[TABLES]"));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_TaskStatus()
        {
            // This test exists to ensure all the Status are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.TaskStatus));
            Int32 index = 0;

            index++; Assert.That(FDC.TaskStatus.EntityName, Is.EqualTo(nameof(FDC.TaskStatus)));
            index++; Assert.That(FDC.TaskStatus.Name, Is.EqualTo(nameof(FDC.TaskStatus.Name)));
            index++; Assert.That(FDC.TaskStatus.Description, Is.EqualTo(nameof(FDC.TaskStatus.Description)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_TimeZone()
        {
            // This test exists to ensure all the Time Zone are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.TimeZone));
            Int32 index = 0;

            index++; Assert.That(FDC.TimeZone.EntityName, Is.EqualTo(nameof(FDC.TimeZone)));
            index++; Assert.That(FDC.TimeZone.Code, Is.EqualTo(nameof(FDC.TimeZone.Code)));
            index++; Assert.That(FDC.TimeZone.Description, Is.EqualTo(nameof(FDC.TimeZone.Description)));
            index++; Assert.That(FDC.TimeZone.Offset, Is.EqualTo(nameof(FDC.TimeZone.Offset)));
            index++; Assert.That(FDC.TimeZone.HasDaylightSavings, Is.EqualTo(nameof(FDC.TimeZone.HasDaylightSavings)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_ActiveDirectoryUser_User()
        {
            // This test exists to ensure all the Active Directory User are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.ActiveDirectoryUser.User));
            Int32 index = 0;

            index++; Assert.That(FDC.ActiveDirectoryUser.User.SchemaClass_User, Is.EqualTo(nameof(FDC.ActiveDirectoryUser.User)));
            index++; Assert.That(FDC.ActiveDirectoryUser.User.UserFlags, Is.EqualTo(nameof(FDC.ActiveDirectoryUser.User.UserFlags)));
            index++; Assert.That(FDC.ActiveDirectoryUser.User.objectSid, Is.EqualTo(nameof(FDC.ActiveDirectoryUser.User.objectSid)));
            index++; Assert.That(FDC.ActiveDirectoryUser.User.Name, Is.EqualTo(nameof(FDC.ActiveDirectoryUser.User.Name)));
            index++; Assert.That(FDC.ActiveDirectoryUser.User.FullName, Is.EqualTo(nameof(FDC.ActiveDirectoryUser.User.FullName)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_UserProfile()
        {
            // This test exists to ensure all the User Profile are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.UserProfile));
            Int32 index = 0;

            index++; Assert.That(FDC.UserProfile.EntityName, Is.EqualTo(nameof(FDC.UserProfile)));
            index++; Assert.That(FDC.UserProfile.ExternalKeyId, Is.EqualTo(nameof(FDC.UserProfile.ExternalKeyId)));
            index++; Assert.That(FDC.UserProfile.DomainName, Is.EqualTo(nameof(FDC.UserProfile.DomainName)));
            index++; Assert.That(FDC.UserProfile.Username, Is.EqualTo(nameof(FDC.UserProfile.Username)));
            index++; Assert.That(FDC.UserProfile.DisplayName, Is.EqualTo(nameof(FDC.UserProfile.DisplayName)));
            index++; Assert.That(FDC.UserProfile.IsSystemSupport, Is.EqualTo(nameof(FDC.UserProfile.IsSystemSupport)));
            index++; Assert.That(FDC.UserProfile.ContactDetailId, Is.EqualTo(nameof(FDC.UserProfile.ContactDetailId)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_WorldRegion()
        {
            // This test exists to ensure all the World Region are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(FDC.WorldRegion));
            Int32 index = 0;

            index++; Assert.That(FDC.WorldRegion.EntityName, Is.EqualTo(nameof(FDC.WorldRegion)));
            index++; Assert.That(FDC.WorldRegion.Name, Is.EqualTo(nameof(FDC.WorldRegion.Name)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }
    }
}
