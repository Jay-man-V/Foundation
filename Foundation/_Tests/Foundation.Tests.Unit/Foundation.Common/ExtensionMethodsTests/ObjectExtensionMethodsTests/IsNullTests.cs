////-----------------------------------------------------------------------
//// <copyright file="ObjectExtensionMethodsTests.cs" company="JDV Software Ltd">
////     Copyright (c) JDV Software Ltd. All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------

//using System;

//using NUnit.Framework;

//using Foundation.Common;

//using Foundation.Tests.Unit.Support;

//namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests.ObjectExtensionMethodsTests
//{
//    /// <summary>
//    /// The Object Extension tests
//    /// </summary>
//    [TestFixture]
//    public class ObjectExtensionMethodsTests : UnitTestBase
//    {
//        [TestCase]
//        public void TestIsNull_Null_True()
//        {
//            const Object anObject = null;

//            Boolean actualResult = anObject.IsNull();

//            Assert.That(actualResult, Is.EqualTo(true));
//        }

//        [TestCase]
//        public void TestIsNull_DbNull_True()
//        {
//            Object anObject = DBNull.Value;

//            Boolean actualResult = anObject.IsNull();

//            Assert.That(actualResult, Is.EqualTo(true));
//        }

//        [TestCase]
//        public void TestIsNull_False()
//        {
//            Object anObject = new Object();

//            Boolean actualResult = anObject.IsNull();

//            Assert.That(actualResult, Is.EqualTo(false));
//        }

//        /// <summary>
//        /// Tests the is null.
//        /// </summary>
//        [TestCase]
//        public void TestIsNull()
//        {
//            const Object nullObject = null;
//            Object dbNullObject = DBNull.Value;

//            Assert.That(nullObject.IsNull());
//            Assert.That(dbNullObject.IsNull());

//            Object valueObject = new Object();

//            Assert.That(valueObject.IsNull(), Is.EqualTo(false));
//        }

//        /// <summary>
//        /// Tests the is null.
//        /// </summary>
//        [TestCase]
//        public void TestIsNotNull()
//        {
//            const Object nullObject = null;
//            Object dbNullObject = DBNull.Value;

//            Assert.That(nullObject.IsNotNull(), Is.EqualTo(false));
//            Assert.That(dbNullObject.IsNotNull(), Is.EqualTo(false));

//            Object valueObject = new Object();

//            Assert.That(valueObject.IsNotNull());
//        }
//    }
//}
