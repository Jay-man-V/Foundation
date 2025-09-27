//-----------------------------------------------------------------------
// <copyright file="UkPostCodeTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Text.RegularExpressions;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Interfaces.CustomTypesTests.PostCodeTests
{
    /// <summary>
    /// Post Code tests for the UK
    /// </summary>
    [TestFixture]
    public class UkPostCodeTests : UnitTestBase
    {
        [TestCase]
        public void TestPostCodes_IndividualPatterns()
        {
            RunBasicTest(PostCodeValues.PostCode1, PostCodeValues.Pattern1);
            RunBasicTest(PostCodeValues.PostCode2, PostCodeValues.Pattern2);
            RunBasicTest(PostCodeValues.PostCode3, PostCodeValues.Pattern3);
            RunBasicTest(PostCodeValues.PostCode4, PostCodeValues.Pattern4);
            RunBasicTest(PostCodeValues.PostCode5, PostCodeValues.Pattern5);
            RunBasicTest(PostCodeValues.PostCode6, PostCodeValues.Pattern6);
        }

        [TestCase]
        public void TestPostCodes_CombinedPatterns()
        {
            RunBasicTest(PostCodeValues.PostCode1, PostCodeValues.AllPatterns);
            RunBasicTest(PostCodeValues.PostCode2, PostCodeValues.AllPatterns);
            RunBasicTest(PostCodeValues.PostCode3, PostCodeValues.AllPatterns);
            RunBasicTest(PostCodeValues.PostCode4, PostCodeValues.AllPatterns);
            RunBasicTest(PostCodeValues.PostCode5, PostCodeValues.AllPatterns);
            RunBasicTest(PostCodeValues.PostCode6, PostCodeValues.AllPatterns);
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
            String p3 = input.ToUpper().Replace(" ", String.Empty);
            TestAndAssertRegEx(p3, pattern);

            // Pass 4 - lower case, no space
            String p4 = input.ToLower().Replace(" ", String.Empty);
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
