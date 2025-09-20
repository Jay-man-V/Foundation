//-----------------------------------------------------------------------
// <copyright file="FoundationModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.Drawing;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Models;

using Foundation.Tests.Unit.Mocks;
using Foundation.Tests.Unit.Support;

using FDC = Foundation.Resources.Constants.DataColumns;
using FEnums = Foundation.Interfaces;

namespace Foundation.Tests.Unit.Foundation.Models
{
    /// <summary>
    /// Summary description for foundationModelTests
    /// </summary>
    [TestFixture]
    public class FoundationModelTests : UnitTestBase
    {
        private String InitialEntityNameValue => "Initial entity name";
        private String UpdatedEntityNameValue => "Updated entity name";
        private String UpdatedEntityDescriptionValue => "Updated entity description";

        [TestCase]
        public void Test_Constructor_1()
        {
            IMockFoundationModel foundationModel = CoreInstance.IoC.Get<IMockFoundationModel>();

            Assert.That(foundationModel, Is.Not.EqualTo(null));

            Type[] allInterfaces = foundationModel.GetType().GetInterfaces();

            Int32 index = 0;
            Assert.That(foundationModel, Is.InstanceOf<ICloneable>()); index++;
            Assert.That(foundationModel, Is.InstanceOf<INotifyPropertyChanged>()); index++;
            Assert.That(foundationModel, Is.InstanceOf<INotifyPropertyChanging>()); index++;
            Assert.That(foundationModel, Is.InstanceOf<IFoundationModel>()); index++;
            Assert.That(foundationModel, Is.InstanceOf<IFoundationObjectId>()); index++;
            Assert.That(foundationModel, Is.InstanceOf<IFoundationModelTracking>()); index++;
            Assert.That(foundationModel, Is.InstanceOf<IChangeTracking>()); index++;
            Assert.That(foundationModel, Is.InstanceOf<IMockFoundationModel>()); index++;

            Assert.That(index, Is.EqualTo(allInterfaces.Length));
        }

        [TestCase]
        public void Test_Constructor_2()
        {
            EntityId expectedEntityId = new EntityId(123);
            Object foundationModel = new MockFoundationModel(123);

            Assert.That(foundationModel, Is.Not.EqualTo(null));
            Assert.That(((IFoundationModel)foundationModel).Id, Is.EqualTo(expectedEntityId));

            Type[] allInterfaces = foundationModel.GetType().GetInterfaces();

            Int32 index = 0;
            Assert.That(foundationModel, Is.InstanceOf<ICloneable>()); index++;
            Assert.That(foundationModel, Is.InstanceOf<INotifyPropertyChanged>()); index++;
            Assert.That(foundationModel, Is.InstanceOf<INotifyPropertyChanging>()); index++;
            Assert.That(foundationModel, Is.InstanceOf<IFoundationModel>()); index++;
            Assert.That(foundationModel, Is.InstanceOf<IFoundationObjectId>()); index++;
            Assert.That(foundationModel, Is.InstanceOf<IFoundationModelTracking>()); index++;
            Assert.That(foundationModel, Is.InstanceOf<IChangeTracking>()); index++;
            Assert.That(foundationModel, Is.InstanceOf<IMockFoundationModel>()); index++;

            Assert.That(index, Is.EqualTo(allInterfaces.Length));
        }

        [TestCase]
        public void Test_InitialState()
        {
            IMockFoundationModel foundationModel = CoreInstance.IoC.Get<IMockFoundationModel>();

            EntityId statusId = foundationModel.StatusId;
            Assert.That(statusId, Is.EqualTo(new EntityId(0)));

            FEnums.EntityStatus entityStatus = foundationModel.EntityStatus;
            Assert.That(entityStatus, Is.EqualTo(FEnums.EntityStatus.Active));

            EntityLife entityLife = foundationModel.EntityLife;
            Assert.That(entityLife, Is.EqualTo(EntityLife.Created));

            EntityState entityState = foundationModel.EntityState;
            Assert.That(entityState, Is.EqualTo(EntityState.Dirty));
        }

        [TestCase]
        public void Test_SetProperties()
        {
            IMockFoundationModel foundationModel = CoreInstance.IoC.Get<IMockFoundationModel>();
            MockFoundationModel mockFoundationModel = (MockFoundationModel)foundationModel;

            mockFoundationModel.FoundationPropertyChanged += (_, _) => { Assert.Fail("Method should not be called"); };
            mockFoundationModel.FoundationPropertyChanging += (_, _) => { Assert.Fail("Method should not be called"); };
            foundationModel.PropertyChanged += (_, _) => { Assert.Fail("Method should not be called"); };
            foundationModel.PropertyChanging += (_, _) => { Assert.Fail("Method should not be called"); };

            foundationModel.Initialising = true;
            Assert.That(foundationModel.Initialising, Is.EqualTo(true));

            foundationModel.Code = "New Code";
            foundationModel.Code = "Code second set";
            foundationModel.Description = "New Description";
            foundationModel.Name = "New Name";
            foundationModel.Initialising = false;
            Assert.That(foundationModel.Initialising, Is.EqualTo(false));

            Assert.That(foundationModel.Code, Is.EqualTo("Code second set".Substring(0, MockFoundationModel.Lengths.Code)));
            Assert.That(foundationModel.Description, Is.EqualTo("New Description"));
            Assert.That(foundationModel.Name, Is.EqualTo("New Name"));
        }

        [TestCase]
        public void Test_Properties()
        {
            IMockFoundationModel foundationModel = CoreInstance.IoC.Get<IMockFoundationModel>();

            foundationModel.Initialising = true;
            foundationModel.Code = "New Code";
            foundationModel.Description = "New Description";
            foundationModel.Name = "New Name";
            foundationModel.ImagePicture = new Bitmap(1, 1);
            foundationModel.Initialising = false;

            Assert.That(foundationModel.Code, Is.EqualTo("New Code"));
            Assert.That(foundationModel.Description, Is.EqualTo("New Description"));
            Assert.That(foundationModel.Name, Is.EqualTo("New Name"));
        }

        [TestCase]
        public void Test_GetPropertyValue()
        {
            IMockFoundationModel foundationModel = CoreInstance.IoC.Get<IMockFoundationModel>();
            FoundationModel fModel = (FoundationModel)foundationModel;

            EntityId entityId = new EntityId(123);
            EntityId statusId = new EntityId(456);
            EntityId createdByUserProfileId = new EntityId(789);
            DateTime createdOn = new DateTime(2023, 11, 04, 18, 05, 12);
            EntityId lastUpdatedByUserProfileId = new EntityId(147);
            DateTime lastUpdatedOn = new DateTime(2023, 11, 04, 18, 05, 34);
            DateTime validFrom = new DateTime(2023, 11, 04, 18, 05, 56);
            DateTime validTo = new DateTime(2023, 11, 04, 18, 05, 14);

            foundationModel.Id = entityId;
            fModel.StatusId = statusId;
            foundationModel.CreatedByUserProfileId = createdByUserProfileId;
            foundationModel.CreatedOn = createdOn;
            foundationModel.LastUpdatedByUserProfileId = lastUpdatedByUserProfileId;
            foundationModel.LastUpdatedOn = lastUpdatedOn;
            foundationModel.ValidFrom = validFrom;
            foundationModel.ValidTo = validTo;

            Assert.That(foundationModel.GetPropertyValue(nameof(FDC.FoundationEntity.Id)), Is.EqualTo(entityId));
            Assert.That(foundationModel.GetPropertyValue(nameof(FDC.FoundationEntity.StatusId)), Is.EqualTo(statusId));
            Assert.That(foundationModel.GetPropertyValue(nameof(FDC.FoundationEntity.CreatedByUserProfileId)), Is.EqualTo(createdByUserProfileId));
            Assert.That(foundationModel.GetPropertyValue(nameof(FDC.FoundationEntity.CreatedOn)), Is.EqualTo(createdOn));
            Assert.That(foundationModel.GetPropertyValue(nameof(FDC.FoundationEntity.LastUpdatedByUserProfileId)), Is.EqualTo(lastUpdatedByUserProfileId));
            Assert.That(foundationModel.GetPropertyValue(nameof(FDC.FoundationEntity.LastUpdatedOn)), Is.EqualTo(lastUpdatedOn));
            Assert.That(foundationModel.GetPropertyValue(nameof(FDC.FoundationEntity.ValidFrom)), Is.EqualTo(validFrom));
            Assert.That(foundationModel.GetPropertyValue(nameof(FDC.FoundationEntity.ValidTo)), Is.EqualTo(validTo));
        }

        [TestCase]
        public void Test_Clone()
        {
            IMockFoundationModel foundationModel = CoreInstance.IoC.Get<IMockFoundationModel>();

            foundationModel.Initialising = true;
            foundationModel.Code = "New Code";
            foundationModel.Description = "New Description";
            foundationModel.Name = "New Name";
            foundationModel.ImagePicture = new Bitmap(1, 1);
            foundationModel.Initialising = false;

            MockFoundationModel clonedFoundationModel = (MockFoundationModel)foundationModel.Clone();

            Assert.That(clonedFoundationModel, Is.Not.EqualTo(foundationModel));
            Assert.That(clonedFoundationModel.Code, Is.EqualTo(foundationModel.Code));
            Assert.That(clonedFoundationModel.Description, Is.EqualTo(foundationModel.Description));
            Assert.That(clonedFoundationModel.Name, Is.EqualTo(foundationModel.Name));
            Assert.That(clonedFoundationModel.ImagePicture, Is.Not.EqualTo(foundationModel.ImagePicture));
            //Assert.That(foundationModel.ImagePicture.CompareAsByteArray(cloakedfoundationModel.ImagePicture));
        }

        [TestCase]
        public void Test_ChangedPropertiesDictionary()
        {
            IMockFoundationModel foundationModel = CoreInstance.IoC.Get<IMockFoundationModel>();
            MockFoundationModel mockFoundationModel = (MockFoundationModel)foundationModel;

            String[] changedProperties = [nameof(IMockFoundationModel.Code), nameof(IMockFoundationModel.Description), nameof(IMockFoundationModel.Name)];
            String[] changedValues1 = ["Code1", "Description1", "Name1"];
            String[] changedValues2 = ["Code2", "Description1", "Name2"];

            foundationModel.Code = "Code1";
            foundationModel.Description = "Description1";
            foundationModel.Name = "Name1";

            IReadOnlyList<FoundationProperty> changedProperties1 = mockFoundationModel.ChangedProperties;
            Assert.That(changedProperties1.Count, Is.EqualTo(3));

            for (Int32 counter = 0; counter < changedProperties.Length; counter++)
            {
                Assert.That(changedProperties1[counter].PropertyName, Is.EqualTo(changedProperties[counter]));
                Assert.That(changedProperties1[counter].NewValue, Is.EqualTo(changedValues1[counter]));
                Assert.That(changedProperties1[counter].OldValue, Is.EqualTo(String.Empty));
            }

            foundationModel.Code = "Code2";
            foundationModel.Name = "Name2";

            IReadOnlyList<FoundationProperty> changedProperties2 = mockFoundationModel.ChangedProperties;
            Assert.That(changedProperties2.Count, Is.EqualTo(changedProperties.Length));

            for (Int32 counter = 0; counter < changedProperties.Length; counter++)
            {
                Assert.That(changedProperties2[counter].PropertyName, Is.EqualTo(changedProperties[counter]));
                Assert.That(changedProperties2[counter].NewValue, Is.EqualTo(changedValues2[counter]));
                Assert.That(changedProperties1[counter].OldValue, Is.EqualTo(String.Empty));
            }
        }

        [TestCase]
        public void Test_ChangedPropertiesDictionaryWithOldValues()
        {
            IMockFoundationModel foundationModel = CoreInstance.IoC.Get<IMockFoundationModel>();
            MockFoundationModel mockFoundationModel = (MockFoundationModel)foundationModel;

            String[] changedProperties = [nameof(IMockFoundationModel.Code), nameof(IMockFoundationModel.Name)];
            String[] changedValues1 = ["Code2", "Name2"];

            foundationModel.Initialising = true;
            foundationModel.Code = "Code1";
            foundationModel.Description = "Description1";
            foundationModel.Name = "Name1";
            foundationModel.Initialising = false;

            foundationModel.Code = "Code2";
            foundationModel.Name = "Name2";

            IReadOnlyList<FoundationProperty> changedProperties1 = mockFoundationModel.ChangedProperties;
            Assert.That(changedProperties1.Count, Is.EqualTo(changedProperties.Length));

            for (Int32 counter = 0; counter < changedProperties.Length; counter++)
            {
                Assert.That(changedProperties1[counter].PropertyName, Is.EqualTo(changedProperties[counter]));
                Assert.That(changedProperties1[counter].NewValue, Is.EqualTo(changedValues1[counter]));
            }
        }

        [TestCase]
        public void Test_PropertyUpdating_1()
        {
            IMockFoundationModel foundationModel = CoreInstance.IoC.Get<IMockFoundationModel>();

            Assert.That(foundationModel.Name, Is.EqualTo(String.Empty));
            Assert.That(foundationModel.EntityState, Is.EqualTo(EntityState.Dirty));
            Assert.That(foundationModel.EntityLife, Is.EqualTo(EntityLife.Created));

            foundationModel.Name = InitialEntityNameValue;
            Assert.That(foundationModel.Name, Is.EqualTo(InitialEntityNameValue.Substring(0, MockFoundationModel.Lengths.Name)));

            foundationModel.Name = UpdatedEntityNameValue;
            Assert.That(foundationModel.Name, Is.EqualTo(UpdatedEntityNameValue.Substring(0, MockFoundationModel.Lengths.Name)));

            Assert.That(foundationModel.EntityState, Is.EqualTo(EntityState.Dirty));
            Assert.That(foundationModel.EntityLife, Is.EqualTo(EntityLife.Created));
        }

        [TestCase]
        public void Test_PropertyUpdating_2()
        {
            IMockFoundationModel foundationModel = CoreInstance.IoC.Get<IMockFoundationModel>();
            foundationModel.EntityState = EntityState.Saved;
            foundationModel.EntityLife = EntityLife.Loaded;

            Assert.That(foundationModel.Name, Is.EqualTo(String.Empty));
            Assert.That(foundationModel.EntityState, Is.EqualTo(EntityState.Saved));
            Assert.That(foundationModel.EntityLife, Is.EqualTo(EntityLife.Loaded));

            foundationModel.Name = InitialEntityNameValue;
            Assert.That(foundationModel.Name, Is.EqualTo(InitialEntityNameValue.Substring(0, MockFoundationModel.Lengths.Name)));

            foundationModel.Name = UpdatedEntityNameValue;
            Assert.That(foundationModel.Name, Is.EqualTo(UpdatedEntityNameValue.Substring(0, MockFoundationModel.Lengths.Name)));

            Assert.That(foundationModel.EntityState, Is.EqualTo(EntityState.Dirty));
            Assert.That(foundationModel.EntityLife, Is.EqualTo(EntityLife.Updated));
        }

        [TestCase]
        public void Test_PropertyUpdating_3()
        {
            IMockFoundationModel foundationModel = CoreInstance.IoC.Get<IMockFoundationModel>();
            foundationModel.EntityState = EntityState.Saved;
            foundationModel.EntityLife = EntityLife.Loaded;
            foundationModel.Initialising = true;
            
            Assert.That(foundationModel.Name, Is.EqualTo(String.Empty));
            Assert.That(foundationModel.EntityState, Is.EqualTo(EntityState.Saved));
            Assert.That(foundationModel.EntityLife, Is.EqualTo(EntityLife.Loaded));

            foundationModel.Name = InitialEntityNameValue;
            Assert.That(foundationModel.Name, Is.EqualTo(InitialEntityNameValue.Substring(0, MockFoundationModel.Lengths.Name)));

            foundationModel.Description = UpdatedEntityDescriptionValue;
            Assert.That(foundationModel.Description, Is.EqualTo(UpdatedEntityDescriptionValue));

            Assert.That(foundationModel.EntityState, Is.EqualTo(EntityState.Saved));
            Assert.That(foundationModel.EntityLife, Is.EqualTo(EntityLife.Loaded));
        }

        [TestCase]
        public void Test_PropertyEventHandling_Success()
        {
            IMockFoundationModel foundationModel = CoreInstance.IoC.Get<IMockFoundationModel>();
            MockFoundationModel mockFoundationModel = (MockFoundationModel)foundationModel;

            Assert.That(foundationModel.Name, Is.EqualTo(String.Empty));

            foundationModel.Name = InitialEntityNameValue;
            Assert.That(foundationModel.Name, Is.EqualTo(InitialEntityNameValue.Substring(0, MockFoundationModel.Lengths.Name)));

            mockFoundationModel.FoundationPropertyChanging += (sender, args) =>
            {
                Assert.That(sender, Is.Not.EqualTo(null));
                Assert.That(args.PropertyName, Is.EqualTo(nameof(IMockFoundationModel.Name)));
                Assert.That(args.OldValue!.ToString(), Is.EqualTo(InitialEntityNameValue.Substring(0, MockFoundationModel.Lengths.Name)));
                Assert.That(args.NewValue!.ToString(), Is.EqualTo(UpdatedEntityNameValue));
            };

            mockFoundationModel.FoundationPropertyChanged += (sender, args) =>
            {
                Assert.That(sender, Is.Not.EqualTo(null));
                Assert.That(args.PropertyName, Is.EqualTo(nameof(IMockFoundationModel.Name)));

                Assert.That(InitialEntityNameValue.Substring(0, MockFoundationModel.Lengths.Name), Is.EqualTo(args.OldValue!.ToString()));
                Assert.That(UpdatedEntityNameValue, Is.EqualTo(args.NewValue!.ToString()));
            };

            foundationModel.PropertyChanged += (_, e) => { Assert.That(e.PropertyName, Is.EqualTo(nameof(IMockFoundationModel.Name))); };
            foundationModel.PropertyChanging += (_, e) => { Assert.That(e.PropertyName, Is.EqualTo(nameof(IMockFoundationModel.Name))); };

            foundationModel.Name = UpdatedEntityNameValue;
            Assert.That(foundationModel.Name, Is.EqualTo(UpdatedEntityNameValue.Substring(0, MockFoundationModel.Lengths.Name)));
        }

        [TestCase]
        public void Test_PropertyEventHandling_Cancel()
        {
            IMockFoundationModel foundationModel = CoreInstance.IoC.Get<IMockFoundationModel>();
            MockFoundationModel mockFoundationModel = (MockFoundationModel)foundationModel;

            Assert.That(foundationModel.Name, Is.EqualTo(String.Empty));

            foundationModel.Name = InitialEntityNameValue;
            Assert.That(foundationModel.Name, Is.EqualTo(InitialEntityNameValue.Substring(0, MockFoundationModel.Lengths.Name)));

            mockFoundationModel.FoundationPropertyChanging += (sender, args) =>
            {
                Assert.That(sender, Is.Not.EqualTo(null));
                Assert.That(args.OldValue!.ToString(), Is.EqualTo(InitialEntityNameValue.Substring(0, MockFoundationModel.Lengths.Name)));
                Assert.That(args.NewValue!.ToString(), Is.EqualTo(UpdatedEntityNameValue));

                args.Cancel = true;
            };

            mockFoundationModel.FoundationPropertyChanged += (_, _) => { Assert.Fail("foundationModel2_FoundationPropertyChanged should not have been called"); };

            foundationModel.Name = UpdatedEntityNameValue;
            Assert.That(foundationModel.Name, Is.EqualTo(InitialEntityNameValue.Substring(0, MockFoundationModel.Lengths.Name)));
        }

        [TestCase]
        public void Test_Entity_AcceptChanges()
        {
            IMockFoundationModel foundationModel = CoreInstance.IoC.Get<IMockFoundationModel>();

            Assert.That(foundationModel.IsChanged, Is.EqualTo(false));

            foundationModel.Name = "Test Name";
            Assert.That(foundationModel.IsChanged, Is.EqualTo(true));

            foundationModel.AcceptChanges();
            Assert.That(foundationModel.IsChanged, Is.EqualTo(false));
            Assert.That(foundationModel.EntityLife, Is.EqualTo(EntityLife.Loaded));
            Assert.That(foundationModel.EntityState, Is.EqualTo(EntityState.Saved));
        }
    }
}
