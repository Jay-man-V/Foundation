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
    /// Post Code tests for the UK
    /// </summary>
    [TestFixture]
    public class PostCodeTests : UnitTestBase
    {
        [TestCase]
        public void TestConstructor_Default()
        {
            String expectedToString = typeof(PostCode).ToString();

            PostCode o = new PostCode();

            Assert.That(o.Parsed, Is.EqualTo(false));
            Assert.That(String.IsNullOrEmpty(o.Value));
            Assert.That(o.ToString(), Is.EqualTo(expectedToString));
        }

        [TestCase]
        public void TestConstructor_PostCode()
        {
            PostCode o = new PostCode(PostCodeValues.PostCode1);

            Assert.That(o.Parsed, Is.EqualTo(false));
            Assert.That(String.IsNullOrEmpty(o.Value), Is.EqualTo(false));
            Assert.That(o.ToString(), Is.EqualTo(PostCodeValues.PostCode1));
        }

        [TestCase]
        public void TestConstructor_PostCode_RegEx()
        {
            RunObjectTests(PostCodeValues.PostCode1);
            RunObjectTests(PostCodeValues.PostCode2);
            RunObjectTests(PostCodeValues.PostCode3);
            RunObjectTests(PostCodeValues.PostCode4);
            RunObjectTests(PostCodeValues.PostCode5);
            RunObjectTests(PostCodeValues.PostCode6);
        }

        private void RunObjectTests(String input)
        {
            // Pass 1 - as supplied - upper case, with space
            String v1 = input.ToUpper();
            TestAndAssertPostCodeObject(v1);

            // Pass 2 - lower case, with space
            String v2 = input.ToLower();
            TestAndAssertPostCodeObject(v2);

            // Pass 3 - lower case, no space
            String v3 = input.ToLower().Replace(" ", String.Empty);
            TestAndAssertPostCodeObject(v3);

            // Pass 4 - lower case, no space
            String v4 = input.ToLower().Replace(" ", String.Empty);
            TestAndAssertPostCodeObject(v4);
        }

        private void TestAndAssertPostCodeObject(String input)
        {
            PostCode postCode = new PostCode(input, PostCodeValues.AllPatterns);

            Assert.That(postCode.Parsed, Is.EqualTo(true));
            Assert.That(String.IsNullOrEmpty(postCode.Value), Is.EqualTo(false));
            Assert.That(postCode.ToString(), Is.EqualTo(input));
        }
    }
}
