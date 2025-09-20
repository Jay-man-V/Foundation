//-----------------------------------------------------------------------
// <copyright file="EntityIdTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Reflection;

using Foundation.Interfaces;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Interfaces.CustomTypesTests
{
    /// <summary>
    /// Unit Tests for the Entity Id type
    /// </summary>
    [TestFixture]
    public class EntityIdTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructors()
        {
            Type thisType = typeof(EntityId);
            ConstructorInfo[] constructorInfos = thisType.GetConstructors();
            Assert.That(constructorInfos.Length, Is.EqualTo(2));

            // Default constructor is not listed as accessible even though it is usable
            Int32 expectedEntityId1 = 0;
            EntityId entityId1 = new EntityId();
            Assert.That(entityId1.ToInteger(), Is.EqualTo(expectedEntityId1));

            // Constructor 1 = ctor(Int32)
            Int32 expectedEntityId2 = 123456;
            EntityId entityId2 = new EntityId(expectedEntityId2);
            Assert.That(entityId2.ToInteger(), Is.EqualTo(expectedEntityId2));

            // Constructor 2 = ctor(EntityId)
            EntityId entityId3 = new EntityId(entityId2);
            Assert.That(entityId3.ToInteger(), Is.EqualTo(expectedEntityId2));
            Assert.That(entityId3.ToString(), Is.EqualTo(expectedEntityId2.ToString()));
            Assert.That(entityId3.GetHashCode(), Is.EqualTo(expectedEntityId2.GetHashCode()));
        }

        [TestCase]
        public void Test_Static_Properties()
        {
            Assert.That(EntityId.MinValue, Is.EqualTo(1L));
            Assert.That(EntityId.MaxValue, Is.EqualTo(Int64.MaxValue));
        }

        [TestCase]
        public void Test_FromObject()
        {
            Int64 expectedId = 12345;
            Object objInt32 = expectedId;
            Object objEntityId = new EntityId(expectedId);
            Object objString = "12345";

            EntityId entityId1 = EntityId.FromObject(objInt32);
            EntityId entityId2 = EntityId.FromObject(objEntityId);
            EntityId entityId3 = EntityId.FromObject(objString);

            Assert.That(entityId1.ToInteger(), Is.EqualTo(expectedId));
            Assert.That(entityId2.ToInteger(), Is.EqualTo(expectedId));
            Assert.That(entityId3, Is.Not.EqualTo(null));
            Assert.That(entityId3.ToInteger(), Is.EqualTo(0));
        }

        [TestCase]
        public void Test_EntityId()
        {
            Int32 expectedId = 12345;
            EntityId expectedEntityId = new EntityId(expectedId);
            EntityId entityId1 = new EntityId(expectedId);
            EntityId entityId2 = new EntityId(789456);
            EntityId entityId3 = new EntityId(-1);

            Assert.That(entityId1.ToInteger(), Is.EqualTo(expectedId));

            Assert.That(entityId1 == expectedEntityId);
            Assert.That(entityId1 != expectedEntityId, Is.EqualTo(false));
            Assert.That(entityId1.Equals(expectedEntityId));

            Assert.That(entityId2 == expectedEntityId, Is.EqualTo(false));
            Assert.That(entityId2 != expectedEntityId);
            Assert.That(entityId2.Equals(expectedEntityId), Is.EqualTo(false));

            Assert.That(entityId3 == expectedEntityId, Is.EqualTo(false));
            Assert.That(entityId3 != expectedEntityId);
        }

        [TestCase]
        public void Test_Object()
        {
            Int32 expectedId = 12345;
            EntityId expectedEntityId = new EntityId(expectedId);
            Object entityId1 = new EntityId(expectedId);
            Object entityId2 = new EntityId(789456);
            EntityId entityId3 = new EntityId(-1);

            Assert.That(entityId1 == expectedEntityId);
            Assert.That(expectedEntityId == entityId1);
            Assert.That(entityId1 != expectedEntityId, Is.EqualTo(false));
            Assert.That(expectedEntityId != entityId1, Is.EqualTo(false));

            Assert.That(entityId2 == expectedEntityId, Is.EqualTo(false));
            Assert.That(expectedEntityId == entityId2, Is.EqualTo(false));
            Assert.That(entityId2 != expectedEntityId);
            Assert.That(expectedEntityId != entityId2);

            Assert.That(entityId3 == expectedEntityId, Is.EqualTo(false));
            Assert.That(expectedEntityId == entityId3, Is.EqualTo(false));
            Assert.That(entityId3 != expectedEntityId);
            Assert.That(expectedEntityId != entityId3);
        }

        [TestCase]
        public void Test_Int64()
        {
            Int64 expectedId = 12345;
            EntityId entityId1 = new EntityId(expectedId);
            EntityId entityId2 = new EntityId(789456L);
            EntityId entityId3 = new EntityId(-1L);

            Assert.That(entityId1, Is.Not.EqualTo(null));
            Assert.That(entityId1.ToInteger(), Is.EqualTo(expectedId));
            //Assert.That(entityId1.Equals(expectedId));

            Assert.That(entityId1.TheEntityId == expectedId);
            Assert.That(expectedId == entityId1.TheEntityId);
            Assert.That(entityId1.TheEntityId != expectedId, Is.EqualTo(false));
            Assert.That(entityId1.TheEntityId != expectedId, Is.EqualTo(false));
            Assert.That(expectedId != entityId1.TheEntityId, Is.EqualTo(false));

            Assert.That(entityId2.TheEntityId != expectedId);
            Assert.That(expectedId != entityId2.TheEntityId);
            Assert.That(entityId2.TheEntityId == expectedId, Is.EqualTo(false));
            Assert.That(entityId2.TheEntityId == expectedId, Is.EqualTo(false));
            Assert.That(expectedId == entityId2.TheEntityId, Is.EqualTo(false));

            Assert.That(entityId3.TheEntityId != expectedId);
            Assert.That(expectedId != entityId3.TheEntityId);
            Assert.That(entityId3.TheEntityId == expectedId, Is.EqualTo(false));
            Assert.That(expectedId == entityId3.TheEntityId, Is.EqualTo(false));
        }

        [TestCase]
        public void Test_IEquatable()
        {
            List<EntityId> entityIds =
            [
                new (10),
                new (01),
                new (08),
                new (03),
                new (06),
                new (05),
                new (04),
                new (07),
                new (02),
                new (09)
            ];

            EntityId targetValueTrue = new EntityId(8);
            EntityId targetValueFalse = new EntityId(80);

            Boolean containsTrue = entityIds.Contains(targetValueTrue);
            Boolean containsFalse = entityIds.Contains(targetValueFalse);

            Assert.That(containsTrue, Is.EqualTo(true));
            Assert.That(containsFalse, Is.EqualTo(false));
        }

        [TestCase]
        public void Test_IComparable()
        {
            List<EntityId> entityIds =
            [
                new (10),
                new (01),
                new (08),
                new (03),
                new (06),
                new (05),
                new (04),
                new (07),
                new (02),
                new (09)
            ];

            entityIds.Sort();

            Assert.That(entityIds[00].ToInteger(), Is.EqualTo(01));
            Assert.That(entityIds[01].ToInteger(), Is.EqualTo(02));
            Assert.That(entityIds[02].ToInteger(), Is.EqualTo(03));
            Assert.That(entityIds[03].ToInteger(), Is.EqualTo(04));
            Assert.That(entityIds[04].ToInteger(), Is.EqualTo(05));
            Assert.That(entityIds[05].ToInteger(), Is.EqualTo(06));
            Assert.That(entityIds[06].ToInteger(), Is.EqualTo(07));
            Assert.That(entityIds[07].ToInteger(), Is.EqualTo(08));
            Assert.That(entityIds[08].ToInteger(), Is.EqualTo(09));
            Assert.That(entityIds[09].ToInteger(), Is.EqualTo(10));
        }
        [TestCase]
        public void Test_IComparer_SortAscending_1()
        {
            List<EntityId> entityIds =
            [
                new (10),
                new (01),
                new (08),
                new (03),
                new (06),
                new (05),
                new (04),
                new (07),
                new (02),
                new (09)
            ];

            IComparer<EntityId> comparer = new EntityId.SortAscending();

            entityIds.Sort(comparer);

            Assert.That(entityIds[00].ToInteger(), Is.EqualTo(01));
            Assert.That(entityIds[01].ToInteger(), Is.EqualTo(02));
            Assert.That(entityIds[02].ToInteger(), Is.EqualTo(03));
            Assert.That(entityIds[03].ToInteger(), Is.EqualTo(04));
            Assert.That(entityIds[04].ToInteger(), Is.EqualTo(05));
            Assert.That(entityIds[05].ToInteger(), Is.EqualTo(06));
            Assert.That(entityIds[06].ToInteger(), Is.EqualTo(07));
            Assert.That(entityIds[07].ToInteger(), Is.EqualTo(08));
            Assert.That(entityIds[08].ToInteger(), Is.EqualTo(09));
            Assert.That(entityIds[09].ToInteger(), Is.EqualTo(10));
        }

        [TestCase]
        public void Test_IComparer_SortAscending_2()
        {
            EntityId[] entityIds =
            [
                new (10),
                new (01),
                new (08),
                new (03),
                new (06),
                new (05),
                new (04),
                new (07),
                new (02),
                new (09)
            ];

            IComparer comparer = new EntityId.SortAscending();

            Array.Sort(entityIds, comparer);

            Assert.That(entityIds[00].ToInteger(), Is.EqualTo(01));
            Assert.That(entityIds[01].ToInteger(), Is.EqualTo(02));
            Assert.That(entityIds[02].ToInteger(), Is.EqualTo(03));
            Assert.That(entityIds[03].ToInteger(), Is.EqualTo(04));
            Assert.That(entityIds[04].ToInteger(), Is.EqualTo(05));
            Assert.That(entityIds[05].ToInteger(), Is.EqualTo(06));
            Assert.That(entityIds[06].ToInteger(), Is.EqualTo(07));
            Assert.That(entityIds[07].ToInteger(), Is.EqualTo(08));
            Assert.That(entityIds[08].ToInteger(), Is.EqualTo(09));
            Assert.That(entityIds[09].ToInteger(), Is.EqualTo(10));
        }

        [TestCase]
        public void Test_IComparer_SortDescending_1()
        {
            List<EntityId> entityIds =
            [
                new (10),
                new (01),
                new (08),
                new (03),
                new (06),
                new (05),
                new (04),
                new (07),
                new (02),
                new (09)
            ];

            IComparer<EntityId> comparer = new EntityId.SortDescending();

            entityIds.Sort(comparer);

            Assert.That(entityIds[00].ToInteger(), Is.EqualTo(10));
            Assert.That(entityIds[01].ToInteger(), Is.EqualTo(09));
            Assert.That(entityIds[02].ToInteger(), Is.EqualTo(08));
            Assert.That(entityIds[03].ToInteger(), Is.EqualTo(07));
            Assert.That(entityIds[04].ToInteger(), Is.EqualTo(06));
            Assert.That(entityIds[05].ToInteger(), Is.EqualTo(05));
            Assert.That(entityIds[06].ToInteger(), Is.EqualTo(04));
            Assert.That(entityIds[07].ToInteger(), Is.EqualTo(03));
            Assert.That(entityIds[08].ToInteger(), Is.EqualTo(02));
            Assert.That(entityIds[09].ToInteger(), Is.EqualTo(01));
        }

        [TestCase]
        public void Test_IComparer_SortDescending_2()
        {
            EntityId[] entityIds =
            [
                new (10),
                new (01),
                new (08),
                new (03),
                new (06),
                new (05),
                new (04),
                new (07),
                new (02),
                new (09)
            ];

            IComparer comparer = new EntityId.SortDescending();

            Array.Sort(entityIds, comparer);

            Assert.That(entityIds[00].ToInteger(), Is.EqualTo(10));
            Assert.That(entityIds[01].ToInteger(), Is.EqualTo(09));
            Assert.That(entityIds[02].ToInteger(), Is.EqualTo(08));
            Assert.That(entityIds[03].ToInteger(), Is.EqualTo(07));
            Assert.That(entityIds[04].ToInteger(), Is.EqualTo(06));
            Assert.That(entityIds[05].ToInteger(), Is.EqualTo(05));
            Assert.That(entityIds[06].ToInteger(), Is.EqualTo(04));
            Assert.That(entityIds[07].ToInteger(), Is.EqualTo(03));
            Assert.That(entityIds[08].ToInteger(), Is.EqualTo(02));
            Assert.That(entityIds[09].ToInteger(), Is.EqualTo(01));
        }
    }
}
