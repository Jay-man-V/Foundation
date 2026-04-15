//-----------------------------------------------------------------------
// <copyright file="UkPostCodeTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Text.RegularExpressions;

using Foundation.Interfaces;

namespace Foundation.Tests.Unit.Foundation.Interfaces.CustomTypesTests.PostCodeTests
{
    /// <summary>
    /// Post Code tests for the UK
    /// </summary>
    [TestFixture]
    public class UkPostCodeTests
    {
        [TestCase]
        public void TestConstructor_PostCode()
        {
            PostCode o = new PostCode(UkPostCodeValues.PostCode1);

            Assert.That(o.IsParsed, Is.EqualTo(false));
            Assert.That(String.IsNullOrEmpty(o.Value), Is.EqualTo(false));
            Assert.That(o.ToString(), Is.EqualTo(UkPostCodeValues.PostCode1));
        }

        [TestCase]
        public void TestConstructor_PostCode_RegEx()
        {
            foreach (String postCode in UkPostCodeValues.AllPostCodes)
            {
                RunObjectTests(postCode);
            }
        }

        [TestCase]
        public void TestPostCodes_IndividualPatterns()
        {
            RunBasicTest(UkPostCodeValues.PostCode1, UkPostCodeValues.Pattern1);
            RunBasicTest(UkPostCodeValues.PostCode2, UkPostCodeValues.Pattern2);
            RunBasicTest(UkPostCodeValues.PostCode3, UkPostCodeValues.Pattern3);
            RunBasicTest(UkPostCodeValues.PostCode4, UkPostCodeValues.Pattern4);
            RunBasicTest(UkPostCodeValues.PostCode5, UkPostCodeValues.Pattern5);
            RunBasicTest(UkPostCodeValues.PostCode6, UkPostCodeValues.Pattern6);
        }

        [TestCase]
        public void TestPostCodes_CombinedPatterns()
        {
            RunBasicTest(UkPostCodeValues.PostCode1, UkPostCodeValues.AllPatterns);
            RunBasicTest(UkPostCodeValues.PostCode2, UkPostCodeValues.AllPatterns);
            RunBasicTest(UkPostCodeValues.PostCode3, UkPostCodeValues.AllPatterns);
            RunBasicTest(UkPostCodeValues.PostCode4, UkPostCodeValues.AllPatterns);
            RunBasicTest(UkPostCodeValues.PostCode5, UkPostCodeValues.AllPatterns);
            RunBasicTest(UkPostCodeValues.PostCode6, UkPostCodeValues.AllPatterns);
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
            String v3 = input.ToLower().Replace(" ", String.Empty, StringComparison.InvariantCulture);
            TestAndAssertPostCodeObject(v3);

            // Pass 4 - lower case, no space
            String v4 = input.ToLower().Replace(" ", String.Empty, StringComparison.InvariantCulture);
            TestAndAssertPostCodeObject(v4);
        }

        private void TestAndAssertPostCodeObject(String input)
        {
            PostCode postCode = new PostCode(input, UkPostCodeValues.AllPatterns);

            Assert.That(postCode.IsParsed, Is.EqualTo(true));
            Assert.That(String.IsNullOrEmpty(postCode.Value), Is.EqualTo(false));
            Assert.That(postCode.ToString(), Is.EqualTo(input));
        }

        private void RunBasicTest(String input, String pattern)
        {
            // Pass 1 - as supplied - upper case, with space
            String p1 = input.ToUpper();
            TestAndAssertRegEx(p1, pattern);

            // Pass 2 - lower case, with space
            String p2 = input.ToLower();
            TestAndAssertRegEx(p2, pattern);

            // Pass 3 - upper case, no space
            String p3 = input.ToUpper().Replace(" ", String.Empty, StringComparison.InvariantCulture);
            TestAndAssertRegEx(p3, pattern);

            // Pass 4 - lower case, no space
            String p4 = input.ToLower().Replace(" ", String.Empty, StringComparison.InvariantCulture);
            TestAndAssertRegEx(p4, pattern);
        }

        private void TestAndAssertRegEx(String input, String pattern)
        {
            Regex regex = new Regex(pattern);

            Match match = regex.Match(input);

            Assert.That(match.Success, Is.EqualTo(true));
            Assert.That(match.Value, Is.EqualTo(input));
        }
    }
}
