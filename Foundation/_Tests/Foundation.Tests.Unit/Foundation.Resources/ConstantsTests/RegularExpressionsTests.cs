//-----------------------------------------------------------------------
// <copyright file="RegularExpressionsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;
using System.Text.RegularExpressions;

using Foundation.Resources;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Resources.ConstantsTests
{
    /// <summary>
    /// Unit Tests for the Regular Expressions class
    /// </summary>
    [TestFixture]
    public class RegularExpressionsTests : UnitTestBase
    {
        /// <summary>
        /// This test exists to force developers to come to this class if there are any changes to the <see cref="RegularExpressions"/>
        /// </summary>
        [TestCase]
        public void Test_AllMembers()
        {
            // This test exists to ensure all the class members are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(RegularExpressions));
            Int32 index = 0;

            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(RegularExpressions.AlphaUpperCaseOnly)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(RegularExpressions.LowerUpperCaseOnly)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(RegularExpressions.NonAlphaChars)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(RegularExpressions.IntegerMultipleDigits)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(RegularExpressions.IntegerSingleDigit)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(RegularExpressions.PositiveDecimalNumber)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(RegularExpressions.AllCharacters)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_AlphaUpperCaseOnly_Match()
        {
            String inputString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            Regex regex = new Regex(RegularExpressions.AlphaUpperCaseOnly);
            Match match = regex.Match(inputString);
            Boolean isMatched = match.Success;

            Assert.That(isMatched, Is.EqualTo(true));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_AlphaUpperCaseOnly_NoMatch_1()
        {
            String inputString = "abcdefghijklmnopqrstuvwxyz";

            Regex regex = new Regex(RegularExpressions.AlphaUpperCaseOnly);
            Match match = regex.Match(inputString);
            Boolean isMatched = match.Success;

            Assert.That(isMatched, Is.EqualTo(false));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_AlphaUpperCaseOnly_NoMatch_2()
        {
            String inputString = @"`¬!""£$%^&*()-_=+[]{}#~;:'@<>?,./\|";

            Regex regex = new Regex(RegularExpressions.AlphaUpperCaseOnly);
            Match match = regex.Match(inputString);
            Boolean isMatched = match.Success;

            Assert.That(isMatched, Is.EqualTo(false));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_LowerUpperCaseOnly_Match()
        {
            String inputString = "abcdefghijklmnopqrstuvwxyz";

            Regex regex = new Regex(RegularExpressions.LowerUpperCaseOnly);
            Match match = regex.Match(inputString);
            Boolean isMatched = match.Success;

            Assert.That(isMatched, Is.EqualTo(true));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_LowerUpperCaseOnly_NoMatch_1()
        {
            String inputString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            Regex regex = new Regex(RegularExpressions.LowerUpperCaseOnly);
            Match match = regex.Match(inputString);
            Boolean isMatched = match.Success;

            Assert.That(isMatched, Is.EqualTo(false));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_LowerUpperCaseOnly_NoMatch_2()
        {
            String inputString = @"`¬!""£$%^&*()-_=+[]{}#~;:'@<>?,./\|";

            Regex regex = new Regex(RegularExpressions.LowerUpperCaseOnly);
            Match match = regex.Match(inputString);
            Boolean isMatched = match.Success;

            Assert.That(isMatched, Is.EqualTo(false));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_NonAlphaChars_Match()
        {
            String inputString = @"`¬!""£$%^&*()-_=+[]{}#~;:'@<>?,./\|";

            Regex regex = new Regex(RegularExpressions.NonAlphaChars);
            Match match = regex.Match(inputString);
            Boolean isMatched = match.Success;

            Assert.That(isMatched, Is.EqualTo(true));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_NonAlphaChars_NoMatch_1()
        {
            String inputString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            Regex regex = new Regex(RegularExpressions.NonAlphaChars);
            Match match = regex.Match(inputString);
            Boolean isMatched = match.Success;

            Assert.That(isMatched, Is.EqualTo(false));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_NonAlphaChars_NoMatch_2()
        {
            String inputString = "abcdefghijklmnopqrstuvwxyz";

            Regex regex = new Regex(RegularExpressions.NonAlphaChars);
            Match match = regex.Match(inputString);
            Boolean isMatched = match.Success;

            Assert.That(isMatched, Is.EqualTo(false));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_IntegerMultipleDigits_Match()
        {
            String inputString = "1234567890";

            Regex regex = new Regex(RegularExpressions.IntegerMultipleDigits);
            Match match = regex.Match(inputString);
            Boolean isMatched = match.Success;

            Assert.That(isMatched, Is.EqualTo(true));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_IntegerMultipleDigits_NoMatch_1()
        {
            String inputString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            Regex regex = new Regex(RegularExpressions.IntegerMultipleDigits);
            Match match = regex.Match(inputString);
            Boolean isMatched = match.Success;

            Assert.That(isMatched, Is.EqualTo(false));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_IntegerMultipleDigits_NoMatch_2()
        {
            String inputString = "abcdefghijklmnopqrstuvwxyz";

            Regex regex = new Regex(RegularExpressions.IntegerMultipleDigits);
            Match match = regex.Match(inputString);
            Boolean isMatched = match.Success;

            Assert.That(isMatched, Is.EqualTo(false));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_IntegerMultipleDigits_NoMatch_3()
        {
            String inputString = @"`¬!""£$%^&*()-_=+[]{}#~;:'@<>?,./\|";

            Regex regex = new Regex(RegularExpressions.IntegerMultipleDigits);
            Match match = regex.Match(inputString);
            Boolean isMatched = match.Success;

            Assert.That(isMatched, Is.EqualTo(false));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_IntegerSingleDigits_Match()
        {
            String inputString = "1234567890";

            foreach (Char inputSingle in inputString)
            {
                Regex regex = new Regex(RegularExpressions.IntegerSingleDigit);
                Match match = regex.Match(inputSingle.ToString());
                Boolean isMatched = match.Success;

                Assert.That(isMatched, $"Test string is {inputSingle}");
            }
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_IntegerSingleDigit_NoMatch_1()
        {
            String inputString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            Regex regex = new Regex(RegularExpressions.IntegerSingleDigit);
            Match match = regex.Match(inputString);
            Boolean isMatched = match.Success;

            Assert.That(isMatched, Is.EqualTo(false));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_IntegerSingleDigit_NoMatch_2()
        {
            String inputString = "abcdefghijklmnopqrstuvwxyz";

            Regex regex = new Regex(RegularExpressions.IntegerSingleDigit);
            Match match = regex.Match(inputString);
            Boolean isMatched = match.Success;

            Assert.That(isMatched, Is.EqualTo(false));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_IntegerSingleDigit_NoMatch_3()
        {
            String inputString = @"`¬!""£$%^&*()-_=+[]{}#~;:'@<>?,./\|";

            Regex regex = new Regex(RegularExpressions.IntegerSingleDigit);
            Match match = regex.Match(inputString);
            Boolean isMatched = match.Success;

            Assert.That(isMatched, Is.EqualTo(false));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_PositiveDecimalNumber_Match()
        {
            String[] inputStrings =
            {
                "0",
                "0.0",
                "1.0",
                "123.123",
                "1",
                "10",
                "1130123",
            };

            foreach (String inputString in inputStrings)
            {
                Regex regex = new Regex(RegularExpressions.AllCharacters);
                Match match = regex.Match(inputString);
                Boolean isMatched = match.Success;

                Assert.That(isMatched, $"Test string is {inputString}");
            }
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_PositiveDecimalNumber_NoMatch()
        {
            String[] inputStrings =
            {
                "a",
                "B",
                @"!£""",
                "QAWS123.122add",
            };

            foreach (String inputString in inputStrings)
            {
                Regex regex = new Regex(RegularExpressions.PositiveDecimalNumber);
                Match match = regex.Match(inputString);
                Boolean isMatched = match.Success;

                Assert.That(isMatched, Is.EqualTo(false), $"Test string is {inputString}");
            }
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_AllCharacters_Match()
        {
            String[] inputStrings =
            {
                "1234567890",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "abcdefghijklmnopqrstuvwxyz",
                @"`¬!""£$%^&*()-_=+[]{}#~;:'@<>?,./\|",
            };

            foreach (String inputString in inputStrings)
            {
                Regex regex = new Regex(RegularExpressions.AllCharacters);
                Match match = regex.Match(inputString);
                Boolean isMatched = match.Success;

                Assert.That(isMatched, $"Test string is {inputString}");
            }
        }
    }
}
