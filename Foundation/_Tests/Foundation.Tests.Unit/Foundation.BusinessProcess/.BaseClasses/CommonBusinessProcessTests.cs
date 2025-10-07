//-----------------------------------------------------------------------
// <copyright file="CommonBusinessProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

using NSubstitute;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Interfaces.Helpers;
using Foundation.Resources;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses
{
    public abstract class CommonBusinessProcessTests<TEntity, TCommonBusinessProcess, TRepository> : CommonProcessTests<TCommonBusinessProcess>
        where TEntity : IFoundationModel
        where TCommonBusinessProcess : ICommonBusinessProcess<TEntity>
        where TRepository : IFoundationModelRepository<TEntity>
    {
        public class MyErrorMessages
        {
            /// <summary>
            /// Empty {0} passed to {0}.SetFilterItemProperties (Parameter '{0}')
            /// <code>
            /// 0 = paramName
            /// 1 = process.GetType()
            /// 2 = paramName
            /// </code>
            /// </summary>
            public static String GetNoneEntryTemplate => "Empty {0} passed to {1}.SetFilterItemProperties (Parameter '{0}')";
        }

        protected TRepository? TheRepository { get; set; }
        protected IEventLogProcess? EventLogProcess { get; set; }


        protected abstract TRepository CreateRepository();
        protected abstract TEntity CreateBlankEntity(TCommonBusinessProcess process, Int32 entityId);
        protected abstract TEntity CreateEntity(TCommonBusinessProcess process, Int32 entityId);
        protected abstract void UpdateEntityProperties(TEntity entity);
        protected abstract void CheckBlankEntry(TEntity entity);
        protected abstract void CheckAllEntry(TEntity entity);
        protected abstract void CheckNoneEntry(TEntity entity);
        protected abstract void CompareEntityProperties(TEntity entity1, TEntity entity2);
        protected abstract String GetCsvSampleData();

        protected abstract Int32 ColumnDefinitionsCount { get; }
        protected abstract String ExpectedScreenTitle { get; }
        protected abstract String ExpectedStatusBarText { get; }

        protected virtual EntityId ExpectedNullId => new EntityId(-1);
        protected virtual EntityId ExpectedAllId => new EntityId(-1);
        protected virtual EntityId ExpectedNoneId => new EntityId(-2);
        protected virtual String ExpectedNullText => String.Empty;
        protected virtual String ExpectedAllText => "<All>";
        protected virtual String ExpectedNoneText => "<None>";

        protected virtual Boolean ExpectedHasOptionalDropDownParameter1 => false;
        protected virtual String ExpectedFilter1Name => "Filter1";
        protected virtual String ExpectedFilter1DisplayMemberPath => String.Empty;
        protected virtual String ExpectedFilter1ValueMemberPath => FDC.FoundationEntity.Id;
        protected virtual Boolean ExpectedHasOptionalAction1 => false;
        protected virtual String ExpectedAction1Name => "Action1";

        protected virtual Boolean ExpectedHasOptionalDropDownParameter2 => false;
        protected virtual String ExpectedFilter2Name => "Filter2";
        protected virtual String ExpectedFilter2DisplayMemberPath => String.Empty;
        protected virtual String ExpectedFilter2ValueMemberPath => FDC.FoundationEntity.Id;
        protected virtual Boolean ExpectedHasOptionalAction2 => false;
        protected virtual String ExpectedAction2Name => "Action2";

        protected virtual Boolean ExpectedHasOptionalDropDownParameter3 => false;
        protected virtual String ExpectedFilter3Name => "Filter3";
        protected virtual String ExpectedFilter3DisplayMemberPath => String.Empty;
        protected virtual String ExpectedFilter3ValueMemberPath => FDC.FoundationEntity.Id;
        protected virtual Boolean ExpectedHasOptionalAction3 => false;
        protected virtual String ExpectedAction3Name => "Action3";

        protected virtual Boolean ExpectedHasOptionalDropDownParameter4 => false;
        protected virtual String ExpectedFilter4Name => "Filter4";
        protected virtual String ExpectedFilter4DisplayMemberPath => String.Empty;
        protected virtual String ExpectedFilter4ValueMemberPath => FDC.FoundationEntity.Id;
        protected virtual Boolean ExpectedHasOptionalAction4 => false;
        protected virtual String ExpectedAction4Name => "Action4";

        protected virtual String ExpectedComboBoxDisplayMember => String.Empty;

        protected virtual Boolean ExpectedCanRefreshData => true;
        protected virtual Boolean ExpectedCanViewData => false;
        protected virtual Boolean ExpectedCanAddData => false;
        protected virtual Boolean ExpectedCanEditData => false;
        protected virtual Boolean ExpectedCanDeleteData => false;

        protected Int32 StandardColumnDefinitionsCount => TheRepository!.HasValidityPeriodColumns ? 8 : 7;

        public override void TestInitialise()
        {
            base.TestInitialise();

            EventLogProcess = Substitute.For<IEventLogProcess>();

            TheRepository = CreateRepository();

            TheProcess = CreateBusinessProcess();

            SetRepositoryProperties();
        }

        public override void TestCleanup()
        {
            TheRepository!.Dispose();
            TheRepository = default;

            EventLogProcess = null;

            base.TestCleanup();
        }

        protected void CopyProperties(ICommonBusinessProcess substitute, ICommonBusinessProcess concrete)
        {
            substitute.NullId.Returns(concrete.NullId);
            substitute.AllId.Returns(concrete.AllId);
            substitute.NoneId.Returns(concrete.NoneId);
            substitute.ComboBoxDisplayMember.Returns(concrete.ComboBoxDisplayMember);
            substitute.ComboBoxValueMember.Returns(concrete.ComboBoxValueMember);
        }

        [TestCase]
        public void Test_CommonBusinessProcess_Properties()
        {
            //CommonBusinessProcess<TEntity, TRepository> commonProcess = TheService!;
            //Assert.That(commonProcess!.Core, Is.Not.EqualTo(null));
            //Assert.That(commonProcess!.RunTimeEnvironmentSettings, Is.Not.EqualTo(null));
            //Assert.That(commonProcess!.DateTimeService, Is.Not.EqualTo(null));
        }

        protected virtual void CheckBaseClassProperties(TCommonBusinessProcess process)
        {
            // Does nothing
        }

        protected virtual void CompareEntityBaseProperties_Id(TEntity expectedEntity, TEntity actualEntity)
        {
            Assert.That(actualEntity.Id, Is.EqualTo(expectedEntity.Id));
        }

        private void CompareEntityBaseProperties(TRepository repository, TEntity expectedEntity, TEntity actualEntity)
        {
            CompareEntityBaseProperties_Id(expectedEntity, actualEntity);
            Assert.That(actualEntity.CreatedByUserProfileId, Is.EqualTo(expectedEntity.CreatedByUserProfileId));
            Assert.That(actualEntity.LastUpdatedByUserProfileId, Is.EqualTo(expectedEntity.LastUpdatedByUserProfileId));
            Assert.That(actualEntity.CreatedOn, Is.EqualTo(expectedEntity.CreatedOn));
            Assert.That(actualEntity.LastUpdatedOn, Is.EqualTo(expectedEntity.LastUpdatedOn));
            Assert.That(actualEntity.EntityState, Is.EqualTo(expectedEntity.EntityState));
            Assert.That(actualEntity.EntityLife, Is.EqualTo(expectedEntity.EntityLife));
            Assert.That(actualEntity.EntityStatus, Is.EqualTo(expectedEntity.EntityStatus));
            Assert.That(actualEntity.StatusId, Is.EqualTo(expectedEntity.StatusId));
            Assert.That(actualEntity.Timestamp, Is.EquivalentTo(expectedEntity.Timestamp!));

            if (TheRepository!.HasValidityPeriodColumns)
            {
                Assert.That(actualEntity.ValidFrom, Is.EqualTo(expectedEntity.ValidFrom));
                Assert.That(actualEntity.ValidTo, Is.EqualTo(expectedEntity.ValidTo));
            }
        }

        protected void SetRepositoryProperties()
        {
            TRepository tempRepository = CoreInstance.IoC.Get<TRepository>();

            TheRepository!.HasValidityPeriodColumns.Returns(tempRepository.HasValidityPeriodColumns);
        }

        protected virtual void Test_NullId(TCommonBusinessProcess process)
        {
            Assert.That(process.NullId, Is.EqualTo(new EntityId(ExpectedNullId)));
        }

        protected virtual void Test_AllId(TCommonBusinessProcess process)
        {
            Assert.That(process.AllId, Is.EqualTo(new EntityId(ExpectedAllId)));
        }

        protected virtual void Test_NoneId(TCommonBusinessProcess process)
        {
            Assert.That(process.NoneId, Is.EqualTo(new EntityId(ExpectedNoneId)));
        }

        [TestCase]
        public void Test_BaseClassProperties()
        {
            Test_NullId(TheProcess!);
            Assert.That(TheProcess!.NullId.TheEntityId, Is.EqualTo(ExpectedNullId.TheEntityId));

            Test_AllId(TheProcess!);
            Assert.That(TheProcess!.AllId.TheEntityId, Is.EqualTo(ExpectedAllId.TheEntityId));
            Assert.That(TheProcess!.AllText, Is.EqualTo(ExpectedAllText));

            Test_NoneId(TheProcess!);
            Assert.That(TheProcess!.NoneId.TheEntityId, Is.EqualTo(ExpectedNoneId.TheEntityId));
            Assert.That(TheProcess!.NoneText, Is.EqualTo(ExpectedNoneText));

            Assert.That(TheProcess!.HasOptionalDropDownParameter1, Is.EqualTo(ExpectedHasOptionalDropDownParameter1));
            Assert.That(TheProcess!.Filter1Name, Is.EqualTo(ExpectedFilter1Name));
            Assert.That(TheProcess!.Filter1DisplayMemberPath, Is.EqualTo(ExpectedFilter1DisplayMemberPath));
            Assert.That(TheProcess!.Filter1SelectedValuePath, Is.EqualTo(ExpectedFilter1ValueMemberPath));
            Assert.That(TheProcess!.HasOptionalAction1, Is.EqualTo(ExpectedHasOptionalAction1));
            Assert.That(TheProcess!.Action1Name, Is.EqualTo(ExpectedAction1Name));

            Assert.That(TheProcess!.HasOptionalDropDownParameter2, Is.EqualTo(ExpectedHasOptionalDropDownParameter2));
            Assert.That(TheProcess!.Filter2Name, Is.EqualTo(ExpectedFilter2Name));
            Assert.That(TheProcess!.Filter2DisplayMemberPath, Is.EqualTo(ExpectedFilter2DisplayMemberPath));
            Assert.That(TheProcess!.Filter2SelectedValuePath, Is.EqualTo(ExpectedFilter2ValueMemberPath));
            Assert.That(TheProcess!.HasOptionalAction2, Is.EqualTo(ExpectedHasOptionalAction2));
            Assert.That(TheProcess!.Action2Name, Is.EqualTo(ExpectedAction2Name));

            Assert.That(TheProcess!.HasOptionalDropDownParameter3, Is.EqualTo(ExpectedHasOptionalDropDownParameter3));
            Assert.That(TheProcess!.Filter3Name, Is.EqualTo(ExpectedFilter3Name));
            Assert.That(TheProcess!.Filter3DisplayMemberPath, Is.EqualTo(ExpectedFilter3DisplayMemberPath));
            Assert.That(TheProcess!.Filter3SelectedValuePath, Is.EqualTo(ExpectedFilter3ValueMemberPath));
            Assert.That(TheProcess!.HasOptionalAction3, Is.EqualTo(ExpectedHasOptionalAction3));
            Assert.That(TheProcess!.Action3Name, Is.EqualTo(ExpectedAction3Name));

            Assert.That(TheProcess!.HasOptionalDropDownParameter4, Is.EqualTo(ExpectedHasOptionalDropDownParameter4));
            Assert.That(TheProcess!.Filter4Name, Is.EqualTo(ExpectedFilter4Name));
            Assert.That(TheProcess!.Filter4DisplayMemberPath, Is.EqualTo(ExpectedFilter4DisplayMemberPath));
            Assert.That(TheProcess!.Filter4SelectedValuePath, Is.EqualTo(ExpectedFilter4ValueMemberPath));
            Assert.That(TheProcess!.HasOptionalAction4, Is.EqualTo(ExpectedHasOptionalAction4));
            Assert.That(TheProcess!.Action4Name, Is.EqualTo(ExpectedAction4Name));

            Assert.That(TheProcess!.ScreenTitle, Is.EqualTo(ExpectedScreenTitle));
            Assert.That(TheProcess!.StatusBarText, Is.EqualTo(ExpectedStatusBarText));

            Assert.That(TheProcess!.DefaultValidFromDateTime, Is.EqualTo(SystemDateTimeMs));
            Assert.That(TheProcess!.DefaultValidToDateTime, Is.EqualTo(ApplicationDefaultValues.DefaultValidToDateTime));

            Assert.That(TheProcess!.ComboBoxDisplayMember, Is.EqualTo(ExpectedComboBoxDisplayMember));
            Assert.That(TheProcess!.ComboBoxValueMember, Is.EqualTo(FDC.FoundationEntity.Id));

            CheckBaseClassProperties(TheProcess!);
        }

        [TestCase]
        public void Test_GetColumnDefinitions()
        {
            List<IGridColumnDefinition> gridColumnDefinitions = TheProcess!.GetColumnDefinitions();

            Int32 columnDefinitionsCount = ColumnDefinitionsCount;
            Int32 actualColumnDefinitionsCount = gridColumnDefinitions.Count;

            Assert.That(actualColumnDefinitionsCount, Is.EqualTo(columnDefinitionsCount));
        }

        [TestCase]
        public void Test_AddFilterOptionAll_Entity()
        {
            if (String.IsNullOrEmpty(TheProcess!.ComboBoxDisplayMember))
            {
                String parameterName = nameof(ICommonBusinessProcess.ComboBoxDisplayMember);
                Type actualType = TheProcess!.GetType();
                String errorMessage = String.Format(MyErrorMessages.GetNoneEntryTemplate, parameterName, actualType, parameterName);

                ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
                {
                    List<TEntity> listItems = [];
                    TheProcess!.AddFilterOptionsAdditional(listItems);
                });

                Assert.That(actualException.Message, Is.EqualTo(errorMessage));
                Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
            }
            else if (TheProcess!.ComboBoxDisplayMember == "Made up property name")
            {
                Type actualType = CreateEntity(TheProcess!, 1).GetType();
                String errorMessage = $"Member '{actualType}.{TheProcess!.ComboBoxDisplayMember}' not found.";

                MissingMemberException actualException = Assert.Throws<MissingMemberException>(() =>
                {
                    List<TEntity> listItems = [];
                    TheProcess!.AddFilterOptionsAdditional(listItems);
                });

                Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            }
            else
            {
                List<TEntity> listItems = [];
                TheProcess!.AddFilterOptionAll(listItems);

                Assert.That(listItems.Count, Is.EqualTo(1));

                Assert.That(listItems[0].Id, Is.EqualTo(ExpectedAllId));
                CheckAllEntry(listItems[0]);
            }
        }

        [TestCase]
        public void Test_AddFilterOptionNone_Entity()
        {
            if (String.IsNullOrEmpty(TheProcess!.ComboBoxDisplayMember))
            {
                String parameterName = nameof(ICommonBusinessProcess.ComboBoxDisplayMember);
                Type actualType = TheProcess!.GetType();
                String errorMessage = String.Format(MyErrorMessages.GetNoneEntryTemplate, parameterName, actualType, parameterName);

                ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
                {
                    List<TEntity> listItems = [];
                    TheProcess!.AddFilterOptionsAdditional(listItems);
                });

                Assert.That(actualException.Message, Is.EqualTo(errorMessage));
                Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
            }
            else if (TheProcess!.ComboBoxDisplayMember == "Made up property name")
            {
                Type actualType = CreateEntity(TheProcess!, 1).GetType();
                String errorMessage = $"Member '{actualType}.{TheProcess!.ComboBoxDisplayMember}' not found.";

                MissingMemberException actualException = Assert.Throws<MissingMemberException>(() =>
                {
                    List<TEntity> listItems = [];
                    TheProcess!.AddFilterOptionsAdditional(listItems);
                });

                Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            }
            else
            {
                List<TEntity> listItems = [];
                TheProcess!.AddFilterOptionNone(listItems);

                Assert.That(listItems.Count, Is.EqualTo(1));

                Assert.That(listItems[0].Id, Is.EqualTo(ExpectedNoneId));
                CheckNoneEntry(listItems[0]);
            }
        }

        [TestCase]
        public void Test_AddFilterOptionsAdditional_Entity()
        {
            if (String.IsNullOrEmpty(TheProcess!.ComboBoxDisplayMember))
            {
                String parameterName = nameof(ICommonBusinessProcess.ComboBoxDisplayMember);
                Type actualType = TheProcess!.GetType();
                String errorMessage = String.Format(MyErrorMessages.GetNoneEntryTemplate, parameterName, actualType, parameterName);

                ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
                {
                    List<TEntity> listItems = [];
                    TheProcess!.AddFilterOptionsAdditional(listItems);
                });

                Assert.That(actualException.Message, Is.EqualTo(errorMessage));
                Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
            }
            else if (TheProcess!.ComboBoxDisplayMember == "Made up property name")
            {
                Type actualType = CreateEntity(TheProcess!, 1).GetType();
                String errorMessage = $"Member '{actualType}.{TheProcess!.ComboBoxDisplayMember}' not found.";

                MissingMemberException actualException = Assert.Throws<MissingMemberException>(() =>
                {
                    List<TEntity> listItems = [];
                    TheProcess!.AddFilterOptionsAdditional(listItems);
                });

                Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            }
            else
            {
                List<TEntity> listItems = [];
                TheProcess!.AddFilterOptionsAdditional(listItems);

                Assert.That(listItems.Count, Is.EqualTo(2));

                Assert.That(listItems[0].Id, Is.EqualTo(ExpectedAllId));
                CheckAllEntry(listItems[0]);

                Assert.That(listItems[1].Id, Is.EqualTo(ExpectedNoneId));
                CheckNoneEntry(listItems[1]);
            }
        }

        [TestCase]
        public void Test_AddFilterOptionAll_String()
        {
            List<String> listItems =[];
            TheProcess!.AddFilterOptionAll(listItems);

            Assert.That(listItems.Count, Is.EqualTo(1));

            Assert.That(listItems[0], Is.EqualTo(ExpectedAllText));
        }

        [TestCase]
        public void Test_AddFilterOptionNone_String()
        {
            List<String> listItems = [];
            TheProcess!.AddFilterOptionNone(listItems);

            Assert.That(listItems.Count, Is.EqualTo(1));

            Assert.That(listItems[0], Is.EqualTo(ExpectedNoneText));
        }

        [TestCase]
        public void Test_AddFilterOptionsAdditional_String()
        {
            List<String> listItems = [];
            TheProcess!.AddFilterOptionsAdditional(listItems);

            Assert.That(listItems.Count, Is.EqualTo(2));

            Assert.That(listItems[0], Is.EqualTo(ExpectedAllText));
            Assert.That(listItems[1], Is.EqualTo(ExpectedNoneText));
        }

        [TestCase]
        public void Test_GetBlankEntry()
        {
            TEntity entity = TheProcess!.GetBlankEntry();

            Assert.That(entity.Id, Is.EqualTo(ExpectedNullId));
            CheckBlankEntry(entity);
        }

        [TestCase]
        public virtual void Test_GetAllEntry()
        {
            if (String.IsNullOrEmpty(TheProcess!.ComboBoxDisplayMember))
            {
                String parameterName = nameof(ICommonBusinessProcess.ComboBoxDisplayMember);
                Type actualType = TheProcess!.GetType();
                String errorMessage = String.Format(MyErrorMessages.GetNoneEntryTemplate, parameterName, actualType, parameterName);

                ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
                {
                    List<TEntity> listItems = [];
                    TheProcess!.AddFilterOptionsAdditional(listItems);
                });

                Assert.That(actualException.Message, Is.EqualTo(errorMessage));
                Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
            }
            else if (TheProcess!.ComboBoxDisplayMember == "Made up property name")
            {
                Type actualType = CreateEntity(TheProcess!, 1).GetType();
                String errorMessage = $"Member '{actualType}.{TheProcess!.ComboBoxDisplayMember}' not found.";

                MissingMemberException actualException = Assert.Throws<MissingMemberException>(() =>
                {
                    List<TEntity> listItems = [];
                    TheProcess!.AddFilterOptionsAdditional(listItems);
                });

                Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            }
            else
            {
                TEntity entity = TheProcess!.GetAllEntry();

                Assert.That(entity.Id, Is.EqualTo(ExpectedAllId));
                CheckAllEntry(entity);
            }
        }

        [TestCase]
        public virtual void Test_GetNoneEntry()
        {
            if (String.IsNullOrEmpty(TheProcess!.ComboBoxDisplayMember))
            {
                String parameterName = nameof(ICommonBusinessProcess.ComboBoxDisplayMember);
                Type actualType = TheProcess!.GetType();
                String errorMessage = String.Format(MyErrorMessages.GetNoneEntryTemplate, parameterName, actualType, parameterName);

                ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
                {
                    List<TEntity> listItems = [];
                    TheProcess!.AddFilterOptionsAdditional(listItems);
                });

                Assert.That(actualException.Message, Is.EqualTo(errorMessage));
                Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
            }
            else if (TheProcess!.ComboBoxDisplayMember == "Made up property name")
            {
                Type actualType = CreateEntity(TheProcess!, 1).GetType();
                String errorMessage = $"Member '{actualType}.{TheProcess!.ComboBoxDisplayMember}' not found.";

                MissingMemberException actualException = Assert.Throws<MissingMemberException>(() =>
                {
                    List<TEntity> listItems = [];
                    TheProcess!.AddFilterOptionsAdditional(listItems);
                });

                Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            }
            else
            {
                TEntity entity = TheProcess!.GetNoneEntry();

                Assert.That(entity.Id, Is.EqualTo(ExpectedNoneId));
                CheckNoneEntry(entity);
            }
        }

        [TestCase]
        public void Test_Validate_Success()
        {
            TEntity entity1 = CreateEntity(TheProcess!, 1);

            TheProcess!.ValidateEntity(entity1);
        }

        [TestCase]
        public void Test_Validate_Exception()
        {
            AggregateException actualException = Assert.Throws<AggregateException>(() =>
            {
                TEntity entity1 = CreateBlankEntity(TheProcess!, 1);
                TheProcess!.ValidateEntity(entity1);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.InnerExceptions.Count > 0);

            foreach (Exception ex in actualException.InnerExceptions)
            {
                Assert.That(ex, Is.InstanceOf<ValidationException>());
                ValidationException vException = (ValidationException)ex;

                Assert.That(vException, Is.Not.Null);
                Assert.That(vException.Message, Is.Not.Null);
            }
        }

        [TestCase]
        public void Test_IsValidEntity()
        {
            TEntity entity1 = CreateBlankEntity(TheProcess!, 1);
            List<ValidationException> validationExceptions = TheProcess!.IsValidEntity(entity1);

            foreach (ValidationException validationException in validationExceptions)
            {
                Assert.That(validationException, Is.Not.Null);
                Assert.That(validationException.Message, Is.Not.Null);
            }
        }

        [TestCase]
        public void Test_CanRefreshData()
        {
            Boolean actual = TheProcess!.CanRefreshData();

            Assert.That(actual, Is.EqualTo(ExpectedCanRefreshData));
        }

        [TestCase]
        public void Test_CanViewRecord_Default()
        {
            TCommonBusinessProcess process = CreateBusinessProcess();

            Boolean actual = process.CanViewRecord();

            Assert.That(actual, Is.EqualTo(ExpectedCanViewData));
        }

        [TestCase(true, true, true, ApplicationRole.None)]
        [TestCase(true, false, true, ApplicationRole.None)]
        [TestCase(true, true, true, ApplicationRole.Reporter)]
        [TestCase(true, false, true, ApplicationRole.Reporter)]
        [TestCase(true, true, false, ApplicationRole.SystemAdministrator)]
        [TestCase(true, false, false, ApplicationRole.SystemAdministrator)]
        public void Test_CanViewRecord(Boolean expectedResult, Boolean createEntity, Boolean isSystemSupport, ApplicationRole applicationRoleToRemove)
        {
            lock (SyncLock)
            {
                ResetLoggedOnUserProfile(CoreInstance.CurrentLoggedOnUser.UserProfile);

                TEntity? entity = createEntity ? CreateEntity(TheProcess!, 1) : default;

                CoreInstance.CurrentLoggedOnUser.UserProfile.IsSystemSupport = isSystemSupport;
                if (!isSystemSupport)
                {
                    RemoveRoleFromLoggedOnUser(ApplicationRole.SystemAdministrator);
                }

                if (applicationRoleToRemove != ApplicationRole.None)
                {
                    RemoveRoleFromLoggedOnUser(applicationRoleToRemove);
                }

                Boolean actual = TheProcess!.CanViewRecord(CoreInstance.CurrentLoggedOnUser.UserProfile, entity);

                Assert.That(actual, Is.EqualTo(expectedResult));
            }
        }

        [TestCase]
        public void Test_CanAddRecord_Default()
        {
            Boolean actual = TheProcess!.CanAddRecord();

            Assert.That(actual, Is.EqualTo(ExpectedCanAddData));
        }

        [TestCase(true, true, ApplicationRole.None)]
        [TestCase(true, false, ApplicationRole.None)]
        [TestCase(true, true, ApplicationRole.Creator)]
        [TestCase(false, false, ApplicationRole.Creator)]
        [TestCase(true, true, ApplicationRole.SystemAdministrator)]
        [TestCase(true, false, ApplicationRole.SystemAdministrator)]
        public void Test_CanAddRecord(Boolean expectedResult, Boolean isSystemSupport, ApplicationRole applicationRoleToRemove)
        {
            lock (SyncLock)
            {
                ResetLoggedOnUserProfile(CoreInstance.CurrentLoggedOnUser.UserProfile);

                CoreInstance.CurrentLoggedOnUser.UserProfile.IsSystemSupport = isSystemSupport;
                if (!isSystemSupport)
                {
                    RemoveRoleFromLoggedOnUser(ApplicationRole.SystemAdministrator);
                }

                if (applicationRoleToRemove != ApplicationRole.None)
                {
                    RemoveRoleFromLoggedOnUser(applicationRoleToRemove);
                }

                Boolean actual = TheProcess!.CanAddRecord(CoreInstance.CurrentLoggedOnUser.UserProfile);

                Assert.That(actual, Is.EqualTo(expectedResult));
            }
        }

        [TestCase]
        public void Test_CanEditRecord_Default()
        {
            Boolean actual = TheProcess!.CanEditRecord();

            Assert.That(actual, Is.EqualTo(ExpectedCanEditData));
        }

        [TestCase(true, true, true, ApplicationRole.None)]
        [TestCase(true, false, true, ApplicationRole.None)]
        [TestCase(false, true, false, ApplicationRole.OwnEditor)]
        [TestCase(false, false, false, ApplicationRole.OwnEditor)]
        [TestCase(false, true, false, ApplicationRole.AllEditor)]
        [TestCase(false, false, false, ApplicationRole.AllEditor)]
        [TestCase(false, true, false, ApplicationRole.SystemAdministrator)]
        [TestCase(false, false, false, ApplicationRole.SystemAdministrator)]
        public void Test_CanEditRecord(Boolean expectedResult, Boolean createEntity, Boolean isSystemSupport, ApplicationRole applicationRoleToRemove)
        {
            TEntity? entity = createEntity ? CreateEntity(TheProcess!, 1) : default;

            CoreInstance.CurrentLoggedOnUser.UserProfile.IsSystemSupport = isSystemSupport;
            if (!isSystemSupport)
            {
                RemoveRoleFromLoggedOnUser(ApplicationRole.SystemAdministrator);
            }

            if (applicationRoleToRemove != ApplicationRole.None)
            {
                RemoveRoleFromLoggedOnUser(applicationRoleToRemove);
            }

            Boolean actual = TheProcess!.CanEditRecord(CoreInstance.CurrentLoggedOnUser.UserProfile, entity);

            Assert.That(actual, Is.EqualTo(expectedResult));
        }

        [TestCase]
        public void Test_CanDeleteRecord_Default()
        {
            Boolean actual = TheProcess!.CanDeleteRecord();

            Assert.That(actual, Is.EqualTo(ExpectedCanDeleteData));
        }

        [TestCase(true, true, true, ApplicationRole.None)]
        [TestCase(true, false, true, ApplicationRole.None)]
        [TestCase(false, true, false, ApplicationRole.OwnDelete)]
        [TestCase(false, false, false, ApplicationRole.OwnDelete)]
        [TestCase(false, true, false, ApplicationRole.AllDelete)]
        [TestCase(false, false, false, ApplicationRole.AllDelete)]
        [TestCase(false, true, false, ApplicationRole.SystemAdministrator)]
        [TestCase(false, false, false, ApplicationRole.SystemAdministrator)]
        public void Test_CanDeleteRecord(Boolean expectedResult, Boolean createEntity, Boolean isSystemSupport, ApplicationRole applicationRoleToRemove)
        {
            TEntity? entity = createEntity ? CreateEntity(TheProcess!, 1) : default;

            CoreInstance.CurrentLoggedOnUser.UserProfile.IsSystemSupport = isSystemSupport;
            if (!isSystemSupport)
            {
                RemoveRoleFromLoggedOnUser(ApplicationRole.SystemAdministrator);
            }

            if (applicationRoleToRemove != ApplicationRole.None)
            {
                RemoveRoleFromLoggedOnUser(applicationRoleToRemove);
            }

            Boolean actual = TheProcess!.CanDeleteRecord(CoreInstance.CurrentLoggedOnUser.UserProfile, entity);

            Assert.That(actual, Is.EqualTo(expectedResult));
        }

        [TestCase]
        public void Test_Save_Entity()
        {
            TheRepository!.Save(Arg.Any<TEntity>()).Returns(args =>
            {
                TEntity retVal = (TEntity)args[0];
                retVal.Id = new EntityId(1);
                return retVal;
            });

            TEntity entity1 = CreateEntity(TheProcess!, 1);
            TEntity savedEntity1 = TheProcess!.Save(entity1);

            Assert.That(savedEntity1, Is.Not.Null);
            Assert.That(savedEntity1.Id.ToInteger(), Is.GreaterThan(0));

            CompareEntityProperties(entity1, savedEntity1);
        }

        [TestCase]
        public virtual void Test_Update_Entity()
        {
            TheRepository!.Save(Arg.Any<TEntity>()).Returns(args =>
            {
                TEntity retVal = (TEntity)args[0];
                retVal.Id = new EntityId(1);

                return retVal;
            });

            TEntity entity1 = CreateEntity(TheProcess!, 1);
            TEntity savedEntity1 = TheProcess!.Save(entity1);

            UpdateEntityProperties(entity1);

            TEntity savedEntity2 = TheProcess!.Save(savedEntity1);

            Assert.That(savedEntity1, Is.Not.Null);
            Assert.That(savedEntity2.Id.ToInteger() > 0);

            CompareEntityProperties(savedEntity1, savedEntity2);
        }

        [TestCase]
        public void Test_Save_MultipleEntities()
        {
            TheRepository!.Save(Arg.Any<List<TEntity>>()).Returns(args =>
            {
                Int32 idCounter = 1;
                List<TEntity> retVal = (List<TEntity>)args[0];
                retVal.ForEach(fe => fe.Id = new EntityId(idCounter++));
                return retVal;
            });

            TEntity entity1 = CreateEntity(TheProcess!, 1);
            TEntity entity2 = CreateEntity(TheProcess!, 2);
            TEntity entity3 = CreateEntity(TheProcess!, 3);

            List<TEntity> entitiesToSave = [entity1, entity2, entity3];
            List<TEntity> savedEntities = TheProcess!.Save(entitiesToSave);

            Assert.That(savedEntities, Is.Not.Null);
            Assert.That(savedEntities.Count, Is.EqualTo(entitiesToSave.Count));
            Assert.That(savedEntities[0].Id.ToInteger() > 0);
            Assert.That(savedEntities[1].Id.ToInteger() > 0);
            Assert.That(savedEntities[2].Id.ToInteger() > 0);

            CompareEntityProperties(entitiesToSave[0], savedEntities[0]);
            CompareEntityProperties(entitiesToSave[1], savedEntities[1]);
            CompareEntityProperties(entitiesToSave[2], savedEntities[2]);
        }

        [TestCase]
        public virtual void Test_Delete_Entity_Id()
        {
            TEntity entity1 = CreateEntity(TheProcess!, 1);

            TheRepository!.Save(Arg.Is(entity1)).Returns(args =>
            {
                TEntity retVal = (TEntity)args[0];
                retVal.Id = new EntityId(1);
                retVal.EntityState = EntityState.Saved;
                return retVal;
            });

            TEntity savedEntity = TheProcess!.Save(entity1);

            TheRepository!.Get(Arg.Is(savedEntity.Id)).Returns(_ =>
            {
                TEntity retVal = (TEntity)savedEntity.Clone();
                retVal.Id = new EntityId(1);
                retVal.EntityLife = EntityLife.Deleted;
                retVal.EntityState = EntityState.Saved;
                retVal.EntityStatus = EntityStatus.Inactive;
                return retVal;
            });

            TEntity loadedEntity1 = TheProcess!.Get(savedEntity.Id);
            TheProcess!.Delete(loadedEntity1.Id);

            TEntity loadedEntity2 = TheProcess!.Get(entity1.Id);

            Assert.That(loadedEntity2.EntityLife, Is.EqualTo(EntityLife.Deleted));
            Assert.That(loadedEntity2.EntityState, Is.EqualTo(EntityState.Saved));
            Assert.That(loadedEntity2.EntityStatus, Is.EqualTo(EntityStatus.Inactive));
            Assert.That((Object)savedEntity == (Object)loadedEntity2, Is.EqualTo(false));
        }

        [TestCase]
        public virtual void Test_Delete_Entity_Object()
        {
            TEntity entity1 = CreateEntity(TheProcess!, 1);

            TheRepository!.Save(Arg.Is(entity1)).Returns(args =>
            {
                TEntity retVal = (TEntity)args[0];
                retVal.Id = new EntityId(1);
                retVal.EntityState = EntityState.Saved;
                return retVal;
            });

            TEntity savedEntity = TheProcess!.Save(entity1);

            TheRepository!.Get(Arg.Is(savedEntity.Id)).Returns(_ =>
            {
                TEntity retVal = (TEntity)savedEntity.Clone();
                retVal.Id = new EntityId(1);
                retVal.EntityLife = EntityLife.Deleted;
                retVal.EntityState = EntityState.Saved;
                retVal.EntityStatus = EntityStatus.Inactive;
                return retVal;
            });

            TEntity loadedEntity1 = TheProcess!.Get(savedEntity.Id);
            TheProcess!.Delete(loadedEntity1);

            TEntity loadedEntity2 = TheProcess!.Get(entity1.Id);

            Assert.That(loadedEntity2.EntityLife, Is.EqualTo(EntityLife.Deleted));
            Assert.That(loadedEntity2.EntityState, Is.EqualTo(EntityState.Saved));
            Assert.That(loadedEntity2.EntityStatus, Is.EqualTo(EntityStatus.Inactive));
            Assert.That((Object)savedEntity == (Object)loadedEntity2, Is.EqualTo(false));
        }

        [TestCase]
        public virtual void Test_Delete_MultipleEntities()
        {
            TEntity entity1 = CreateEntity(TheProcess!, 1);
            TEntity entity2 = CreateEntity(TheProcess!, 2);
            TEntity entity3 = CreateEntity(TheProcess!, 3);

            List<TEntity> entitiesToDelete = [entity1, entity2, entity3];

            TheRepository!.Delete(Arg.Any<List<TEntity>>()).Returns(args =>
            {
                List<TEntity> entities = (List<TEntity>)args[0];

                entities.ForEach(fe =>
                {
                    fe.EntityStatus = EntityStatus.Inactive;
                });

                return entities;
            });

            List<TEntity> deletedEntities = TheProcess!.Delete(entitiesToDelete);

            Assert.That(deletedEntities[0].EntityStatus, Is.EqualTo(EntityStatus.Inactive));
            Assert.That(deletedEntities[1].EntityStatus, Is.EqualTo(EntityStatus.Inactive));
            Assert.That(deletedEntities[2].EntityStatus, Is.EqualTo(EntityStatus.Inactive));
            Assert.That(deletedEntities, Is.EquivalentTo(entitiesToDelete));
        }

        [TestCase]
        public void Test_Get()
        {
            TEntity newEntity = CreateEntity(TheProcess!, 1);

            TEntity savedEntity = TheProcess!.Save(newEntity);
            EntityId savedEntityId = savedEntity.Id;

            Thread.Sleep(500);

            TEntity loadedEntity = TheProcess!.Get(savedEntityId);

            CompareEntityBaseProperties(TheRepository!, savedEntity, loadedEntity);
        }

        [TestCase]
        public void Test_Get_Multiple()
        {
            TEntity newEntity1 = CreateEntity(TheProcess!, 1);
            TEntity newEntity2 = CreateEntity(TheProcess!, 2);
            TEntity newEntity3 = CreateEntity(TheProcess!, 3);

            Int32 entityCounter = 0;
            TheRepository!.Save(Arg.Any<TEntity>()).Returns(args =>
            {
                TEntity retVal = (TEntity)((TEntity)args[0]).Clone();

                retVal.Id = new EntityId(entityCounter++);

                return retVal;
            });

            TEntity savedEntity1 = TheProcess!.Save(newEntity1);
            TEntity savedEntity2 = TheProcess!.Save(newEntity2);
            TEntity savedEntity3 = TheProcess!.Save(newEntity3);

            List<EntityId> savedEntityIds = [savedEntity1.Id, savedEntity2.Id, savedEntity3.Id];

            TheRepository!.Get(Arg.Any<List<EntityId>>()).Returns(_ =>
            {
                List<TEntity> retVal =
                [
                    (TEntity)savedEntity1.Clone(),
                    (TEntity)savedEntity2.Clone(),
                    (TEntity)savedEntity3.Clone(),
                ];

                return retVal;
            });

            List<TEntity> loadedEntities = TheProcess!.Get(savedEntityIds).ToList();

            Assert.That(loadedEntities.Count, Is.EqualTo(savedEntityIds.Count));
            CompareEntityBaseProperties(TheRepository!, savedEntity1, loadedEntities[0]);
            CompareEntityBaseProperties(TheRepository!, savedEntity2, loadedEntities[1]);
            CompareEntityBaseProperties(TheRepository!, savedEntity3, loadedEntities[2]);
        }

        [TestCase]
        public virtual void Test_GetAll()
        {
            TEntity newEntity1 = CreateEntity(TheProcess!, 1);
            TEntity newEntity2 = CreateEntity(TheProcess!, 2);
            TEntity newEntity3 = CreateEntity(TheProcess!, 3);

            Int32 entityCounter = 0;
            TheRepository!.Save(Arg.Any<TEntity>()).Returns(args =>
            {
                TEntity retVal = (TEntity)((TEntity)args[0]).Clone();

                retVal.Id = new EntityId(entityCounter++);

                return retVal;
            });

            TEntity savedEntity1 = TheProcess!.Save(newEntity1);
            TEntity savedEntity2 = TheProcess!.Save(newEntity2);
            TEntity savedEntity3 = TheProcess!.Save(newEntity3);

            List<EntityId> savedEntityIds = [savedEntity1.Id, savedEntity2.Id, savedEntity3.Id];

            TheRepository!.GetAllActive().Returns(_ =>
            {
                List<TEntity> retVal =
                [
                    (TEntity)savedEntity1.Clone(),
                    (TEntity)savedEntity2.Clone(),
                    (TEntity)savedEntity3.Clone(),
                ];

                return retVal;
            });

            List<TEntity> loadedEntities = TheProcess!.GetAll();

            Assert.That(loadedEntities.Count, Is.EqualTo(savedEntityIds.Count));
            CompareEntityBaseProperties(TheRepository!, savedEntity1, loadedEntities[0]);
            CompareEntityBaseProperties(TheRepository!, savedEntity2, loadedEntities[1]);
            CompareEntityBaseProperties(TheRepository!, savedEntity3, loadedEntities[2]);
        }

        [TestCase]
        public virtual void Test_GetAll_ExcludeDeleted_True()
        {
            const Boolean excludeDeleted = true;
            const Boolean activeOnly = false;

            TEntity entity1 = CreateEntity(TheProcess!, 1);
            TEntity entity2 = CreateEntity(TheProcess!, 2);
            TEntity entity3 = CreateEntity(TheProcess!, 3);
            TEntity entity4 = CreateEntity(TheProcess!, 4);

            entity1.EntityStatus = EntityStatus.Inactive;

            List<TEntity> entities = [entity2, entity3, entity4];

            TheRepository!.GetAll(Arg.Is(excludeDeleted), Arg.Is(activeOnly)).Returns(entities);

            List<TEntity> loadedEntities = TheProcess!.GetAll(excludeDeleted);

            Assert.That(loadedEntities.Count, Is.EqualTo(entities.Count));
            CompareEntityBaseProperties(TheRepository!, entity2, loadedEntities[0]);
            CompareEntityBaseProperties(TheRepository!, entity3, loadedEntities[1]);
            CompareEntityBaseProperties(TheRepository!, entity4, loadedEntities[2]);
        }

        [TestCase]
        public virtual void Test_GetAll_ExcludeDeleted_False()
        {
            const Boolean excludeDeleted = false;
            const Boolean activeOnly = false;

            TEntity entity1 = CreateEntity(TheProcess!, 1);
            TEntity entity2 = CreateEntity(TheProcess!, 2);
            TEntity entity3 = CreateEntity(TheProcess!, 3);
            TEntity entity4 = CreateEntity(TheProcess!, 4);

            entity1.EntityStatus = EntityStatus.Inactive;

            List<TEntity> entities = [entity1, entity2, entity3, entity4];

            TheRepository!.GetAll(Arg.Is(excludeDeleted), Arg.Is(activeOnly)).Returns(entities);

            List<TEntity> loadedEntities = TheProcess!.GetAll(excludeDeleted);

            Assert.That(loadedEntities.Count, Is.EqualTo(entities.Count));
            CompareEntityBaseProperties(TheRepository!, entity1, loadedEntities[0]);
            CompareEntityBaseProperties(TheRepository!, entity2, loadedEntities[1]);
            CompareEntityBaseProperties(TheRepository!, entity3, loadedEntities[2]);
            CompareEntityBaseProperties(TheRepository!, entity4, loadedEntities[3]);
        }

        [TestCase]
        public void Test_ExportToCsv()
        {
            List<TEntity> sourceData =
            [
                CreateEntity(TheProcess!, 01),
                CreateEntity(TheProcess!, 02),
                CreateEntity(TheProcess!, 03),
                CreateEntity(TheProcess!, 04),
                CreateEntity(TheProcess!, 05),
                CreateEntity(TheProcess!, 06),
                CreateEntity(TheProcess!, 07),
                CreateEntity(TheProcess!, 08),
                CreateEntity(TheProcess!, 09),
                CreateEntity(TheProcess!, 10),
            ];

            List<IGridColumnDefinition> gridColumnDefinitions = TheProcess!.GetColumnDefinitions();
            String actualCsvData = TheProcess!.ExportToCsv(gridColumnDefinitions, sourceData);
            actualCsvData = FixUpStringWithReplacements(actualCsvData);

            String sampleCsvData = GetCsvSampleData();
            sampleCsvData = FixUpStringWithReplacements(sampleCsvData);

            Assert.That(actualCsvData, Is.EqualTo(sampleCsvData));
        }

        [TestCase]
        public void Test_ExportToCsv_NullProperty()
        {
            String paramName = "MadeUpPropertyName";
            String entityType = CreateBlankEntity(TheProcess!, 1).GetType().ToString();
            String errorMessage = $"Cannot find property called '{paramName}' in type {entityType}. {TheProcess!.GetType()}.ExportToExcel. (Parameter '{paramName}')";

            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                List<IGridColumnDefinition> gridColumnDefinitions = TheProcess!.GetColumnDefinitions();
                List<TEntity> sourceData = [CreateEntity(TheProcess!, 1)];

                if (gridColumnDefinitions[0] is GridColumnDefinition gcd)
                {
                    gcd.SetDataMemberName(paramName);
                }
                else
                {
                    Assert.Fail($"GridColumnDefinition is not of expected type: {gridColumnDefinitions[0]}");
                }

                _ = TheProcess!.ExportToCsv(gridColumnDefinitions, sourceData);
            });

            Assert.That(actualException, Is.Not.Null);

            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(paramName));
        }

        [TestCase]
        public void Test_ExportToCsv_Exception_NullGridColumnDefinitions()
        {
            String paramName = "gridColumnDefinitions";
            String errorMessage = $"Null {paramName} passed to {TheProcess!.GetType()}.ExportToCsv (Parameter '{paramName}')";

            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                const List<IGridColumnDefinition>? gridColumnDefinitions = null;
                List<TEntity> sourceData = [CreateEntity(TheProcess!, 1)];

                _ = TheProcess!.ExportToCsv(gridColumnDefinitions, sourceData);
            });

            Assert.That(actualException, Is.Not.Null);

            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(paramName));
        }

        [TestCase]
        public void Test_ExportToCsv_Exception_NullSourceData()
        {
            String paramName = "sourceData";
            String errorMessage = $"Empty {paramName} passed to {TheProcess!.GetType()}.ExportToCsv (Parameter '{paramName}')";

            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                List<IGridColumnDefinition> gridColumnDefinitions = TheProcess!.GetColumnDefinitions();
                const List<TEntity>? sourceData = null;

                _ = TheProcess!.ExportToCsv(gridColumnDefinitions, sourceData);
            });

            Assert.That(actualException, Is.Not.Null);

            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(paramName));
        }
    }
}