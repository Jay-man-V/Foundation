//-----------------------------------------------------------------------
// <copyright file="AppIdTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Reflection;

using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Interfaces.CustomTypesTests
{
    /// <summary>
    /// Unit Tests for the App Id type
    /// </summary>
    [TestFixture]
    public class AppIdTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructors()
        {
            Type thisType = typeof(AppId);
            ConstructorInfo[] constructorInfos = thisType.GetConstructors();
            Assert.That(constructorInfos.Length, Is.EqualTo(2));

            // Default constructor is not listed as accessible even though it is usable
            Int32 expectedAppId1 = 0;
            AppId appId1 = new AppId();
            Assert.That(appId1.ToInteger(), Is.EqualTo(expectedAppId1));

            // Constructor 1 = ctor(Int32)
            Int32 expectedAppId2 = 123456;
            AppId appId2 = new AppId(expectedAppId2);
            Assert.That(appId2.ToInteger(), Is.EqualTo(expectedAppId2));

            // Constructor 2 = ctor(AppId)
            AppId appId3 = new AppId(appId2);
            Assert.That(appId3.ToInteger(), Is.EqualTo(expectedAppId2));
            Assert.That(appId3.ToString(), Is.EqualTo(expectedAppId2.ToString()));
            Assert.That(appId3.GetHashCode(), Is.EqualTo(expectedAppId2.GetHashCode()));
        }

        [TestCase]
        public void Test_Static_Properties()
        {
            Assert.That(AppId.MinValue, Is.EqualTo(0L));
            Assert.That(AppId.MaxValue, Is.EqualTo(Int64.MaxValue));
        }

        [TestCase]
        public void Test_FromObject()
        {
            Int64 expectedId = 12345;
            Object objInt32 = expectedId;
            Object objAppId = new AppId(expectedId);
            Object objString = "12345";

            AppId appId1 = AppId.FromObject(objInt32);
            AppId appId2 = AppId.FromObject(objAppId);
            AppId appId3 = AppId.FromObject(objString);

            Assert.That(appId1.ToInteger(), Is.EqualTo(expectedId));
            Assert.That(appId2.ToInteger(), Is.EqualTo(expectedId));
            Assert.That(appId3, Is.Not.EqualTo(null));
            Assert.That(appId3.ToInteger(), Is.EqualTo(0));
        }

        [TestCase]
        public void Test_ApplicationId()
        {
            Int32 expectedId = 12345;
            AppId expectedAppId = new AppId(expectedId);
            AppId appId1 = new AppId(expectedId);
            AppId appId2 = new AppId(789456);
            AppId appId3 = new AppId(-1);

            Assert.That(appId1.ToInteger(), Is.EqualTo(expectedId));

            Assert.That(appId1 == expectedAppId);
            Assert.That(appId1 != expectedAppId, Is.EqualTo(false));
            Assert.That(appId1.Equals(expectedAppId));

            Assert.That(appId2 == expectedAppId, Is.EqualTo(false));
            Assert.That(appId2 != expectedAppId);
            Assert.That(appId2.Equals(expectedAppId), Is.EqualTo(false));

            Assert.That(appId3 == expectedAppId, Is.EqualTo(false));
            Assert.That(appId3 != expectedAppId);
        }

        [TestCase]
        public void Test_Object()
        {
            Int32 expectedId = 12345;
            AppId expectedAppId = new AppId(expectedId);
            Object appId1 = new AppId(expectedId);
            Object appId2 = new AppId(789456);
            AppId appId3 = new AppId(-1);

            Assert.That(appId1 == expectedAppId);
            Assert.That(expectedAppId == appId1);
            Assert.That(appId1 != expectedAppId, Is.EqualTo(false));
            Assert.That(expectedAppId != appId1, Is.EqualTo(false));

            Assert.That(appId2 == expectedAppId, Is.EqualTo(false));
            Assert.That(expectedAppId == appId2, Is.EqualTo(false));
            Assert.That(appId2 != expectedAppId);
            Assert.That(expectedAppId != appId2);

            Assert.That(appId3 == expectedAppId, Is.EqualTo(false));
            Assert.That(expectedAppId == appId3, Is.EqualTo(false));
            Assert.That(appId3 != expectedAppId);
            Assert.That(expectedAppId != appId3);
        }

        [TestCase]
        public void Test_Int64()
        {
            Int64 expectedId = 12345;
            AppId appId1 = new AppId(expectedId);
            AppId appId2 = new AppId(789456);
            AppId appId3 = new AppId(-1);

            Assert.That(appId1, Is.Not.EqualTo(null));
            Assert.That(appId1.ToInteger(), Is.EqualTo(expectedId));
            //Assert.That(appId1.Equals(expectedId));

            Assert.That(appId1.TheAppId == expectedId);
            Assert.That(expectedId == appId1.TheAppId);
            Assert.That(appId1.TheAppId != expectedId, Is.EqualTo(false));
            Assert.That(appId1.TheAppId != expectedId, Is.EqualTo(false));
            Assert.That(expectedId != appId1.TheAppId, Is.EqualTo(false));

            Assert.That(appId2.TheAppId != expectedId);
            Assert.That(expectedId != appId2.TheAppId);
            Assert.That(appId2.TheAppId == expectedId, Is.EqualTo(false));
            Assert.That(appId2.TheAppId == expectedId, Is.EqualTo(false));
            Assert.That(expectedId == appId2.TheAppId, Is.EqualTo(false));

            Assert.That(appId3.TheAppId != expectedId);
            Assert.That(expectedId != appId3.TheAppId);
            Assert.That(appId3.TheAppId == expectedId, Is.EqualTo(false));
            Assert.That(expectedId == appId3.TheAppId, Is.EqualTo(false));
        }

        [TestCase]
        public void Test_IEquatable()
        {
            List<AppId> appIds =
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

            AppId targetValueTrue = new AppId(8);
            AppId targetValueFalse = new AppId(80);

            Boolean containsTrue = appIds.Contains(targetValueTrue);
            Boolean containsFalse = appIds.Contains(targetValueFalse);

            Assert.That(containsTrue, Is.EqualTo(true));
            Assert.That(containsFalse, Is.EqualTo(false));
        }

        [TestCase]
        public void Test_IComparable()
        {
            List<AppId> appIds =
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

            appIds.Sort();

            Assert.That(appIds[00].ToInteger(), Is.EqualTo(01));
            Assert.That(appIds[01].ToInteger(), Is.EqualTo(02));
            Assert.That(appIds[02].ToInteger(), Is.EqualTo(03));
            Assert.That(appIds[03].ToInteger(), Is.EqualTo(04));
            Assert.That(appIds[04].ToInteger(), Is.EqualTo(05));
            Assert.That(appIds[05].ToInteger(), Is.EqualTo(06));
            Assert.That(appIds[06].ToInteger(), Is.EqualTo(07));
            Assert.That(appIds[07].ToInteger(), Is.EqualTo(08));
            Assert.That(appIds[08].ToInteger(), Is.EqualTo(09));
            Assert.That(appIds[09].ToInteger(), Is.EqualTo(10));
        }
        [TestCase]
        public void Test_IComparer_SortAscending_1()
        {
            List<AppId> appIds =
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

            IComparer<AppId> comparer = new AppId.SortAscending();

            appIds.Sort(comparer);

            Assert.That(appIds[00].ToInteger(), Is.EqualTo(01));
            Assert.That(appIds[01].ToInteger(), Is.EqualTo(02));
            Assert.That(appIds[02].ToInteger(), Is.EqualTo(03));
            Assert.That(appIds[03].ToInteger(), Is.EqualTo(04));
            Assert.That(appIds[04].ToInteger(), Is.EqualTo(05));
            Assert.That(appIds[05].ToInteger(), Is.EqualTo(06));
            Assert.That(appIds[06].ToInteger(), Is.EqualTo(07));
            Assert.That(appIds[07].ToInteger(), Is.EqualTo(08));
            Assert.That(appIds[08].ToInteger(), Is.EqualTo(09));
            Assert.That(appIds[09].ToInteger(), Is.EqualTo(10));
        }

        [TestCase]
        public void Test_IComparer_SortAscending_2()
        {
            AppId[] appIds =
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

            IComparer comparer = new AppId.SortAscending();

            Array.Sort(appIds, comparer);

            Assert.That(appIds[00].ToInteger(), Is.EqualTo(01));
            Assert.That(appIds[01].ToInteger(), Is.EqualTo(02));
            Assert.That(appIds[02].ToInteger(), Is.EqualTo(03));
            Assert.That(appIds[03].ToInteger(), Is.EqualTo(04));
            Assert.That(appIds[04].ToInteger(), Is.EqualTo(05));
            Assert.That(appIds[05].ToInteger(), Is.EqualTo(06));
            Assert.That(appIds[06].ToInteger(), Is.EqualTo(07));
            Assert.That(appIds[07].ToInteger(), Is.EqualTo(08));
            Assert.That(appIds[08].ToInteger(), Is.EqualTo(09));
            Assert.That(appIds[09].ToInteger(), Is.EqualTo(10));
        }

        [TestCase]
        public void Test_IComparer_SortDescending_1()
        {
            List<AppId> appIds =
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

            IComparer<AppId> comparer = new AppId.SortDescending();

            appIds.Sort(comparer);

            Assert.That(appIds[00].ToInteger(), Is.EqualTo(10));
            Assert.That(appIds[01].ToInteger(), Is.EqualTo(09));
            Assert.That(appIds[02].ToInteger(), Is.EqualTo(08));
            Assert.That(appIds[03].ToInteger(), Is.EqualTo(07));
            Assert.That(appIds[04].ToInteger(), Is.EqualTo(06));
            Assert.That(appIds[05].ToInteger(), Is.EqualTo(05));
            Assert.That(appIds[06].ToInteger(), Is.EqualTo(04));
            Assert.That(appIds[07].ToInteger(), Is.EqualTo(03));
            Assert.That(appIds[08].ToInteger(), Is.EqualTo(02));
            Assert.That(appIds[09].ToInteger(), Is.EqualTo(01));
        }

        [TestCase]
        public void Test_IComparer_SortDescending_2()
        {
            AppId[] appIds =
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

            IComparer comparer = new AppId.SortDescending();

            Array.Sort(appIds, comparer);

            Assert.That(appIds[00].ToInteger(), Is.EqualTo(10));
            Assert.That(appIds[01].ToInteger(), Is.EqualTo(09));
            Assert.That(appIds[02].ToInteger(), Is.EqualTo(08));
            Assert.That(appIds[03].ToInteger(), Is.EqualTo(07));
            Assert.That(appIds[04].ToInteger(), Is.EqualTo(06));
            Assert.That(appIds[05].ToInteger(), Is.EqualTo(05));
            Assert.That(appIds[06].ToInteger(), Is.EqualTo(04));
            Assert.That(appIds[07].ToInteger(), Is.EqualTo(03));
            Assert.That(appIds[08].ToInteger(), Is.EqualTo(02));
            Assert.That(appIds[09].ToInteger(), Is.EqualTo(01));
        }
    }
}
