//-----------------------------------------------------------------------
// <copyright file="PostCodeTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Interfaces.CustomTypesTests.PostCodeTests
{
    /// <summary>
    /// Post Code tests
    /// </summary>
    [TestFixture]
    public class PostCodeTests : UnitTestBase
    {
        [TestCase]
        public void TestConstructor_Default()
        {
            String? expectedToString = null;

            PostCode o = new PostCode();

            Assert.That(o.IsParsed, Is.EqualTo(false));
            Assert.That(String.IsNullOrEmpty(o.Value));
            Assert.That(o.ToString(), Is.EqualTo(expectedToString));
        }
    }
}
