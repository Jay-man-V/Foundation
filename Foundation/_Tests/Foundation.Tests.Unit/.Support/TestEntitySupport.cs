////-----------------------------------------------------------------------
//// <copyright file="TestEntitySupport.cs" company="JDV Software Ltd">
////     Copyright (c) JDV Software Ltd. All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------

//using System;

//using NUnit.Framework;

//using Foundation.Interfaces;

//using Foundation.Tests.Unit.Mocks;

//namespace Foundation.Tests.Unit.Support
//{
//    /// <summary>
//    /// Test Entity Support functions
//    /// </summary>
//    internal static class TestEntitySupport
//    {
//        public static IMockFoundationModel CreateTestEntity(ICore core, Int32 index)
//        {
//            IMockFoundationModel retVal = Substitute.For<IMockFoundationModel>();

//            retVal.Name = $"Name: {index}";
//            retVal.Code = $"Code: {index}";
//            retVal.Description = $"Description: {index}";

//            retVal.ValidFrom = new DateTime(2018, 1, 1);
//            retVal.ValidTo = new DateTime(2100, 12, 31);

//            retVal.CreatedByUserProfileId = new EntityId(1);
//            retVal.LastUpdatedByUserProfileId = new EntityId(1);

//            return retVal;
//        }

//        public static void AssertTestLoadedEntity(IMockFoundationModel testEntity, Int32 actionCount, Int32 index)
//        {
//            DateTime comparisonDateTime = DateTime.UtcNow;

//            Assert.That(testEntity, Is.Not.Null);
//            Assert.That(testEntity.Id.ToInteger(), Is.EqualTo(index));
//            Assert.That(testEntity.EntityLife, Is.EqualTo(EntityLife.Loaded));
//            Assert.That(testEntity.EntityState, Is.EqualTo(EntityState.Saved));
//            Assert.That(testEntity.Timestamp, Is.Not.Null);

//            Assert.That(testEntity.CreatedByUserProfileId.ToInteger(), Is.EqualTo(1));
//            Assert.That(testEntity.LastUpdatedByUserProfileId.ToInteger(), Is.EqualTo(1));

//            Assert.That((comparisonDateTime - testEntity.CreatedOn).Days, Is.EqualTo(0));
//            Assert.That((comparisonDateTime - testEntity.LastUpdatedOn).Days, Is.EqualTo(0));

//            Assert.That(testEntity.ValidFrom, Is.EqualTo(new DateTime(2018, 1, 1, 0, 0, 0)));
//            Assert.That(testEntity.ValidTo, Is.EqualTo(new DateTime(2100, 12, 31, 0, 0, 0)));

//            Assert.That(testEntity.Name, Is.EqualTo($"Updated {actionCount} "));
//            Assert.That(testEntity.Code, Is.EqualTo($"Updated {actionCount} "));
//            Assert.That(testEntity.Description, Is.EqualTo($"Updated {actionCount} Description: {index}"));
//        }

//        public static void AssertTestSavedEntity(IMockFoundationModel testEntity, Int32 index)
//        {
//            DateTime comparisonDateTime = DateTime.UtcNow;

//            Assert.That(testEntity, Is.Not.Null);
//            Assert.That(testEntity.Id.ToInteger(), Is.EqualTo(index));
//            Assert.That(testEntity.EntityState, Is.EqualTo(EntityState.Saved));
//            Assert.That(testEntity.EntityLife, Is.EqualTo(EntityLife.Loaded));
//            Assert.That(testEntity.Timestamp, Is.Not.Null);

//            Assert.That(testEntity.CreatedByUserProfileId.ToInteger(), Is.EqualTo(1));
//            Assert.That(testEntity.LastUpdatedByUserProfileId.ToInteger(), Is.EqualTo(1));

//            Assert.That((comparisonDateTime - testEntity.CreatedOn).Days, Is.EqualTo(0));
//            Assert.That((comparisonDateTime - testEntity.LastUpdatedOn).Days, Is.EqualTo(0));

//            Assert.That(testEntity.ValidFrom, Is.EqualTo(new DateTime(2018, 1, 1, 0, 0, 0)));
//            Assert.That(testEntity.ValidTo, Is.EqualTo(new DateTime(2100, 12, 31, 0, 0, 0)));

//            Assert.That(testEntity.Name, Is.EqualTo($"Name: {index}"));
//            Assert.That(testEntity.Code, Is.EqualTo($"Code: {index}"));
//            Assert.That(testEntity.Description, Is.EqualTo($"Description: {index}"));
//        }

//        public static void AssertTestEntity_1(IMockFoundationModel testEntity, Int32 index)
//        {
//            Assert.That(testEntity, Is.Not.Null);
//            Assert.That(testEntity.Id.ToInteger(), Is.EqualTo(index));
//            Assert.That(testEntity.EntityState, Is.EqualTo(EntityState.Saved));
//            Assert.That(testEntity.EntityLife, Is.EqualTo(EntityLife.Loaded));
//            Assert.That(testEntity.Timestamp, Is.Not.Null);

//            Assert.That(testEntity.CreatedByUserProfileId.ToInteger(), Is.EqualTo(1));
//            Assert.That(testEntity.LastUpdatedByUserProfileId.ToInteger(), Is.EqualTo(2));

//            Assert.That(testEntity.CreatedOn, Is.EqualTo(new DateTime(2017, 1, 1, 21, 26, 0)));
//            Assert.That(testEntity.LastUpdatedOn, Is.EqualTo(new DateTime(2018, 5, 27, 5, 0, 0)));
//            Assert.That(testEntity.ValidFrom, Is.EqualTo(new DateTime(2018, 1, 1, 0, 0, 0)));
//            Assert.That(testEntity.ValidTo, Is.EqualTo(new DateTime(2018, 1, 31, 0, 0, 0)));

//            Assert.That(testEntity.Name, Is.EqualTo($"Name: {index}"));
//            Assert.That(testEntity.Code, Is.EqualTo($"Code: {index}"));
//            Assert.That(testEntity.Description, Is.EqualTo($"Description: {index}"));
//        }

//        public static void AssertTestEntity_2(IMockFoundationModel testEntity, Int32 index)
//        {
//            Assert.That(testEntity, Is.Not.Null);
//            Assert.That(testEntity.Id.ToInteger(), Is.EqualTo(index));
//            Assert.That(testEntity.EntityState, Is.EqualTo(EntityState.Saved));
//            Assert.That(testEntity.EntityLife, Is.EqualTo(EntityLife.Loaded));
//            Assert.That(testEntity.Timestamp, Is.Not.Null);

//            Assert.That(testEntity.CreatedByUserProfileId.ToInteger(), Is.EqualTo(1));
//            Assert.That(testEntity.LastUpdatedByUserProfileId.ToInteger(), Is.EqualTo(2));

//            Assert.That(testEntity.CreatedOn, Is.EqualTo(new DateTime(2017, 2, 1, 21, 26, 0)));
//            Assert.That(testEntity.LastUpdatedOn, Is.EqualTo(new DateTime(2018, 2, 27, 5, 0, 0)));
//            Assert.That(testEntity.ValidFrom, Is.EqualTo(new DateTime(2018, 1, 1, 0, 0, 0)));
//            Assert.That(testEntity.ValidTo, Is.EqualTo(new DateTime(2100, 1, 31, 0, 0, 0)));

//            Assert.That(testEntity.Name, Is.EqualTo($"Name: {index}"));
//            Assert.That(testEntity.Code, Is.EqualTo($"Code: {index}"));
//            Assert.That(testEntity.Description, Is.EqualTo($"Description: {index}"));
//        }
//    }
//}
