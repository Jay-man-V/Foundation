//-----------------------------------------------------------------------
// <copyright file="LogIdTests.cs" company="JDV Software Ltd">
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
    public class LogIdTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructors()
        {
            Type thisType = typeof(LogId);
            ConstructorInfo[] constructorInfos = thisType.GetConstructors();
            Assert.That(constructorInfos.Length, Is.EqualTo(2));

            // Default constructor is not listed as accessible even though it is usable
            Int64 expectedLogId1 = 0;
            LogId logId1 = new LogId();
            Assert.That(logId1.ToInteger(), Is.EqualTo(expectedLogId1));

            // Constructor 1 = ctor(Int64)
            Int64 expectedLogId2 = 123456;
            LogId logId2 = new LogId(expectedLogId2);
            Assert.That(logId2.ToInteger(), Is.EqualTo(expectedLogId2));

            // Constructor 2 = ctor(LogId)
            LogId logId3 = new LogId(logId2);
            Assert.That(logId3.ToInteger(), Is.EqualTo(expectedLogId2));
            Assert.That(logId3.ToString(), Is.EqualTo(expectedLogId2.ToString()));
            Assert.That(logId3.GetHashCode(), Is.EqualTo(expectedLogId2.GetHashCode()));
        }

        [TestCase]
        public void Test_Static_Properties()
        {
            Assert.That(LogId.MinValue, Is.EqualTo(1L));
            Assert.That(LogId.MaxValue, Is.EqualTo(Int64.MaxValue));
        }

        [TestCase]
        public void Test_FromObject()
        {
            Int64 expectedId = 12345;
            Object objInt64 = expectedId;
            Object objLogId = new LogId(expectedId);
            Object objString = "12345";

            LogId logId1 = LogId.FromObject(objInt64);
            LogId logId2 = LogId.FromObject(objLogId);
            LogId logId3 = LogId.FromObject(objString);

            Assert.That(logId1.ToInteger(), Is.EqualTo(expectedId));
            Assert.That(logId2.ToInteger(), Is.EqualTo(expectedId));
            Assert.That(logId3, Is.Not.EqualTo(null));
            Assert.That(logId3.ToInteger(), Is.EqualTo(0));
        }

        [TestCase]
        public void Test_LogId()
        {
            Int64 expectedId = 12345;
            LogId expectedLogId = new LogId(expectedId);
            LogId logId1 = new LogId(expectedId);
            LogId logId2 = new LogId(789456L);
            LogId logId3 = new LogId(-1);

            Assert.That(logId1.ToInteger(), Is.EqualTo(expectedId));

            Assert.That(logId1 == expectedLogId);
            Assert.That(logId1 != expectedLogId, Is.EqualTo(false));
            Assert.That(logId1.Equals(expectedLogId));

            Assert.That(logId2 == expectedLogId, Is.EqualTo(false));
            Assert.That(logId2 != expectedLogId);
            Assert.That(logId2.Equals(expectedLogId), Is.EqualTo(false));

            Assert.That(logId3 == expectedLogId, Is.EqualTo(false));
            Assert.That(logId3 != expectedLogId);
        }

        [TestCase]
        public void Test_Object()
        {
            Int64 expectedId = 12345;
            LogId expectedLogId = new LogId(expectedId);
            Object logId1 = new LogId(expectedId);
            Object logId2 = new LogId(789456L);
            LogId logId3 = new LogId(-1);

            Assert.That(logId1 == expectedLogId);
            Assert.That(expectedLogId == logId1);
            Assert.That(logId1 != expectedLogId, Is.EqualTo(false));
            Assert.That(expectedLogId != logId1, Is.EqualTo(false));

            Assert.That(logId2 == expectedLogId, Is.EqualTo(false));
            Assert.That(expectedLogId == logId2, Is.EqualTo(false));
            Assert.That(logId2 != expectedLogId);
            Assert.That(expectedLogId != logId2);

            Assert.That(logId3 == expectedLogId, Is.EqualTo(false));
            Assert.That(expectedLogId == logId3, Is.EqualTo(false));
            Assert.That(logId3 != expectedLogId);
            Assert.That(expectedLogId != logId3);
        }

        [TestCase]
        public void Test_Int64()
        {
            Int64 expectedId = 12345;
            LogId logId1 = new LogId(expectedId);
            LogId logId2 = new LogId(789456);
            LogId logId3 = new LogId(-1);

            Assert.That(logId1, Is.Not.EqualTo(null));
            Assert.That(logId1.ToInteger(), Is.EqualTo(expectedId));
            //Assert.That(logId1.Equals(expectedId));

            Assert.That(logId1.TheLogId == expectedId);
            Assert.That(expectedId == logId1.TheLogId);
            Assert.That(logId1.TheLogId != expectedId, Is.EqualTo(false));
            Assert.That(logId1.TheLogId != expectedId, Is.EqualTo(false));
            Assert.That(expectedId != logId1.TheLogId, Is.EqualTo(false));

            Assert.That(logId2.TheLogId != expectedId);
            Assert.That(expectedId != logId2.TheLogId);
            Assert.That(logId2.TheLogId == expectedId, Is.EqualTo(false));
            Assert.That(logId2.TheLogId == expectedId, Is.EqualTo(false));
            Assert.That(expectedId == logId2.TheLogId, Is.EqualTo(false));

            Assert.That(logId3.TheLogId != expectedId);
            Assert.That(expectedId != logId3.TheLogId);
            Assert.That(logId3.TheLogId == expectedId, Is.EqualTo(false));
            Assert.That(expectedId == logId3.TheLogId, Is.EqualTo(false));
        }

        [TestCase]
        public void Test_IEquatable()
        {
            List<LogId> logIds =
            [
                new (10L),
                new (01L),
                new (08L),
                new (03L),
                new (06L),
                new (05L),
                new (04L),
                new (07L),
                new (02L),
                new (09L)
            ];

            LogId targetValueTrue = new LogId(8L);
            LogId targetValueFalse = new LogId(80L);

            Boolean containsTrue = logIds.Contains(targetValueTrue);
            Boolean containsFalse = logIds.Contains(targetValueFalse);

            Assert.That(containsTrue, Is.EqualTo(true));
            Assert.That(containsFalse, Is.EqualTo(false));
        }

        [TestCase]
        public void Test_IComparable()
        {
            List<LogId> logIds =
            [
                new (10L),
                new (01L),
                new (08L),
                new (03L),
                new (06L),
                new (05L),
                new (04L),
                new (07L),
                new (02L),
                new (09L)
            ];

            logIds.Sort();

            Assert.That(logIds[00].ToInteger(), Is.EqualTo(01));
            Assert.That(logIds[01].ToInteger(), Is.EqualTo(02));
            Assert.That(logIds[02].ToInteger(), Is.EqualTo(03));
            Assert.That(logIds[03].ToInteger(), Is.EqualTo(04));
            Assert.That(logIds[04].ToInteger(), Is.EqualTo(05));
            Assert.That(logIds[05].ToInteger(), Is.EqualTo(06));
            Assert.That(logIds[06].ToInteger(), Is.EqualTo(07));
            Assert.That(logIds[07].ToInteger(), Is.EqualTo(08));
            Assert.That(logIds[08].ToInteger(), Is.EqualTo(09));
            Assert.That(logIds[09].ToInteger(), Is.EqualTo(10));
        }
        [TestCase]
        public void Test_IComparer_SortAscending_1()
        {
            List<LogId> logIds =
            [
                new (10L),
                new (01L),
                new (08L),
                new (03L),
                new (06L),
                new (05L),
                new (04L),
                new (07L),
                new (02L),
                new (09L)
            ];

            IComparer<LogId> comparer = new LogId.SortAscending();

            logIds.Sort(comparer);

            Assert.That(logIds[00].ToInteger(), Is.EqualTo(01));
            Assert.That(logIds[01].ToInteger(), Is.EqualTo(02));
            Assert.That(logIds[02].ToInteger(), Is.EqualTo(03));
            Assert.That(logIds[03].ToInteger(), Is.EqualTo(04));
            Assert.That(logIds[04].ToInteger(), Is.EqualTo(05));
            Assert.That(logIds[05].ToInteger(), Is.EqualTo(06));
            Assert.That(logIds[06].ToInteger(), Is.EqualTo(07));
            Assert.That(logIds[07].ToInteger(), Is.EqualTo(08));
            Assert.That(logIds[08].ToInteger(), Is.EqualTo(09));
            Assert.That(logIds[09].ToInteger(), Is.EqualTo(10));
        }

        [TestCase]
        public void Test_IComparer_SortAscending_2()
        {
            LogId[] logIds =
            [
                new (10L),
                new (01L),
                new (08L),
                new (03L),
                new (06L),
                new (05L),
                new (04L),
                new (07L),
                new (02L),
                new (09L)
            ];

            IComparer comparer = new LogId.SortAscending();

            Array.Sort(logIds, comparer);

            Assert.That(logIds[00].ToInteger(), Is.EqualTo(01));
            Assert.That(logIds[01].ToInteger(), Is.EqualTo(02));
            Assert.That(logIds[02].ToInteger(), Is.EqualTo(03));
            Assert.That(logIds[03].ToInteger(), Is.EqualTo(04));
            Assert.That(logIds[04].ToInteger(), Is.EqualTo(05));
            Assert.That(logIds[05].ToInteger(), Is.EqualTo(06));
            Assert.That(logIds[06].ToInteger(), Is.EqualTo(07));
            Assert.That(logIds[07].ToInteger(), Is.EqualTo(08));
            Assert.That(logIds[08].ToInteger(), Is.EqualTo(09));
            Assert.That(logIds[09].ToInteger(), Is.EqualTo(10));
        }

        [TestCase]
        public void Test_IComparer_SortDescending_1()
        {
            List<LogId> logIds =
            [
                new (10L),
                new (01L),
                new (08L),
                new (03L),
                new (06L),
                new (05L),
                new (04L),
                new (07L),
                new (02L),
                new (09L)
            ];

            IComparer<LogId> comparer = new LogId.SortDescending();

            logIds.Sort(comparer);

            Assert.That(logIds[00].ToInteger(), Is.EqualTo(10));
            Assert.That(logIds[01].ToInteger(), Is.EqualTo(09));
            Assert.That(logIds[02].ToInteger(), Is.EqualTo(08));
            Assert.That(logIds[03].ToInteger(), Is.EqualTo(07));
            Assert.That(logIds[04].ToInteger(), Is.EqualTo(06));
            Assert.That(logIds[05].ToInteger(), Is.EqualTo(05));
            Assert.That(logIds[06].ToInteger(), Is.EqualTo(04));
            Assert.That(logIds[07].ToInteger(), Is.EqualTo(03));
            Assert.That(logIds[08].ToInteger(), Is.EqualTo(02));
            Assert.That(logIds[09].ToInteger(), Is.EqualTo(01));
        }

        [TestCase]
        public void Test_IComparer_SortDescending_2()
        {
            LogId[] logIds =
            [
                new (10L),
                new (01L),
                new (08L),
                new (03L),
                new (06L),
                new (05L),
                new (04L),
                new (07L),
                new (02L),
                new (09L)
            ];

            IComparer comparer = new LogId.SortDescending();

            Array.Sort(logIds, comparer);

            Assert.That(logIds[00].ToInteger(), Is.EqualTo(10));
            Assert.That(logIds[01].ToInteger(), Is.EqualTo(09));
            Assert.That(logIds[02].ToInteger(), Is.EqualTo(08));
            Assert.That(logIds[03].ToInteger(), Is.EqualTo(07));
            Assert.That(logIds[04].ToInteger(), Is.EqualTo(06));
            Assert.That(logIds[05].ToInteger(), Is.EqualTo(05));
            Assert.That(logIds[06].ToInteger(), Is.EqualTo(04));
            Assert.That(logIds[07].ToInteger(), Is.EqualTo(03));
            Assert.That(logIds[08].ToInteger(), Is.EqualTo(02));
            Assert.That(logIds[09].ToInteger(), Is.EqualTo(01));
        }
    }
}
