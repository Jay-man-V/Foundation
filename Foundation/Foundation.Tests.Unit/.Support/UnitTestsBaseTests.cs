//-----------------------------------------------------------------------
// <copyright file="UnitTestsBaseTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

namespace Foundation.Tests.Unit.Support
{
    /// <summary>
    /// The UnitTestsBaseTests class
    /// </summary>
    [TestFixture]
    public class UnitTestsBaseTests : UnitTestBase
    {
        [TestCase]
        public void Test_ByteArrayToString()
        {
            List<Int32> int32List = new List<Int32>
            {
                65, 66, 67, 68, 69, 70,
                71, 72, 73, 74, 75, 76, 77, 78, 79, 80,
                81, 82, 83, 84, 85, 86, 87, 88, 89, 90
            };

            String output = "{65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90}";

            Byte[] byteList = int32List.Select(x => (Byte)x).ToArray();

            String actualOutput = ByteArrayToStringRepresentationForCode(byteList);

            Assert.That(actualOutput, Is.EqualTo(output));
        }

        [TestCase]
        public void Test_GetListOfTestMethods()
        {
            IEnumerable<MethodInfo> methodInfos = GetListOfTestMethods();
            Assert.That(methodInfos.Count(), Is.EqualTo(12));
        }

        [TestCase]
        public void Test_GetMethodInfosForType()
        {
            IEnumerable<MethodInfo> methodInfos = GetMethodInfosForType(this.GetType());
            Assert.That(methodInfos.Count(), Is.EqualTo(0));
        }

        [TestCase]
        public void Test_ReplaceDateTimeWithConstant()
        {
            String input1 = "29-Mar-2023 21:45:30.123";
            String expected1 = "<<dd-MMM-yyyy HH:mm:ss.fff>>";
            String actual1 = ReplaceDateTimeWithConstant(input1);
            Assert.That(actual1, Is.EqualTo(expected1));

            String input2 = "29-Mar-2023 21:45:30";
            String expected2 = "<<dd-MMM-yyyy HH:mm:ss>>";
            String actual2 = ReplaceDateTimeWithConstant(input2);
            Assert.That(actual2, Is.EqualTo(expected2));

            String input3 = @"2023-03-29 21_45_30\Out";
            String expected3 = @"<<Date/Time>>\Out";
            String actual3 = ReplaceDateTimeWithConstant(input3);
            Assert.That(actual3, Is.EqualTo(expected3));

            String input4 = "2023-03-29 21_45_30";
            String expected4 = "<<Date/Time>>";
            String actual4 = ReplaceDateTimeWithConstant(input4);
            Assert.That(actual4, Is.EqualTo(expected4));
        }

        [TestCase]
        public void Test_ReplaceFilePathWithConstant()
        {
            String input1 = "Executing assembly: Foundation.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            String expected1 = "Executing assembly: Foundation.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            String actual1 = ReplaceFilePathWithConstant(input1);
            Assert.That(actual1, Is.EqualTo(expected1));

            String input2 = @"Assembly location: D:\Projects\JDVSoftware\Foundation.Net\TestResults\Deploy_jayes 2023-01-01 18_22_29\Out\Foundation.Common.dll";
            String expected2 = "Assembly location: <<Output Folder>>Foundation.Common.dll";
            String actual2 = ReplaceFilePathWithConstant(input2);
            Assert.That(actual2, Is.EqualTo(expected2));

            String input3 = @"Assembly location: D:\Projects\JDVSoftware\Foundation.Net\TestResults\Deploy_jayes 20230330T105739\Out\Foundation.Common.dll";
            String expected3 = "Assembly location: <<Output Folder>>Foundation.Common.dll";
            String actual3 = ReplaceFilePathWithConstant(input3);
            Assert.That(actual3, Is.EqualTo(expected3));

            String input4 = @"Environment.CurrentDirectory: D:\Projects\JDVSoftware\Foundation.Net\TestResults\Deploy_jayes 2023-01-01 18_22_29\Out";
            String expected4 = "Environment.CurrentDirectory: <<Output Folder>>";
            String actual4 = ReplaceFilePathWithConstant(input4);
            Assert.That(actual4, Is.EqualTo(expected4));

            String input5 = @"Environment.CurrentDirectory: D:\Projects\JDVSoftware\Foundation.Net\TestResults\Deploy_jayes 20230330T105739\Out";
            String expected5 = "Environment.CurrentDirectory: <<Output Folder>>";
            String actual5 = ReplaceFilePathWithConstant(input5);
            Assert.That(actual5, Is.EqualTo(expected5));

            String input6 = @"Directory.GetCurrentDirectory: D:\Projects\JDVSoftware\Foundation.Net\TestResults\Deploy_jayes 2023-01-01 18_22_29\Out";
            String expected6 = "Directory.GetCurrentDirectory: <<Output Folder>>";
            String actual6 = ReplaceFilePathWithConstant(input6);
            Assert.That(actual6, Is.EqualTo(expected6));

            String input7 = @"Directory.GetCurrentDirectory: D:\Projects\JDVSoftware\Foundation.Net\TestResults\Deploy_jayes 20230330T105739\Out";
            String expected7 = "Directory.GetCurrentDirectory: <<Output Folder>>";
            String actual7 = ReplaceFilePathWithConstant(input7);
            Assert.That(actual7, Is.EqualTo(expected7));
        }

        [TestCase]
        public void Test_ReplaceLineNumberWithConstant()
        {
            String input1 = ":line 123";
            String expected1 = ":line <<line number>>";
            String actual1 = ReplaceLineNumberWithConstant(input1);
            Assert.That(actual1, Is.EqualTo(expected1));
        }

        [TestCase]
        public void Test_ReplaceUserNameWithConstant()
        {
            String[] inputs =
            {
                @"User logon: MyDomain\MyUser",
                @"User logon: .\MyUser",
                @"User: 'MyDomain\MyUser'",
                @"User: MyDomain\MyUser",
                @"User: .\UnitTestUserName",
            };

            String[] expectedResults =
            {
                @"User logon: <<domain\user>>",
                @"User logon: <<domain\user>>",
                @"User: '<<domain\user>>'",
                @"User: <<domain\user>>",
                @"User: <<domain\user>>",
            };

            for (Int32 counter = 0; counter < inputs.Length; counter++)
            {
                String input = inputs[counter];
                String expectedResult = expectedResults[counter];
                String actual = ReplaceUserNameWithConstant(input);
                Assert.That(actual, Is.EqualTo(expectedResult));
            }
        }

        [TestCase]
        public void Test_ReplaceEntryAssemblyWithConstant()
        {
            String input1 = "Entry assembly: My.Assembly.Is.Here.dll";
            String expected1 = "Entry assembly: <<EntryAssembly>>";
            String actual1 = ReplaceEntryAssemblyWithConstant(input1);
            Assert.That(actual1, Is.EqualTo(expected1));
        }

        [TestCase]
        public void Test_ReplacePublicKeyTokenWithConstant()
        {
            String input1 = "PublicKeyToken=null";
            String expected1 = "PublicKeyToken=<<PublicKeyToken>>";
            String actual1 = ReplacePublicKeyTokenWithConstant(input1);
            Assert.That(actual1, Is.EqualTo(expected1));

            String input2 = "PublicKeyToken=cc7b13ffcd2ddd51";
            String expected2 = "PublicKeyToken=<<PublicKeyToken>>";
            String actual2 = ReplacePublicKeyTokenWithConstant(input2);
            Assert.That(actual2, Is.EqualTo(expected2));
        }

        [TestCase]
        public void Test_ReplaceAssemblyVersionWithConstant()
        {
            String input1 = "Version=1.0.0.0";
            String expected1 = "Version=<<Version>>";
            String actual1 = ReplaceAssemblyVersionWithConstant(input1);
            Assert.That(actual1, Is.EqualTo(expected1));

            String input2 = "Version=10000.65535.65535.65535";
            String expected2 = "Version=<<Version>>";
            String actual2 = ReplaceAssemblyVersionWithConstant(input2);
            Assert.That(actual2, Is.EqualTo(expected2));
        }

        [TestCase]
        public void Test_ReplaceAssemblyTargetFrameworkWithConstant()
        {
            String input1 = "Assembly target framework: .NET Framework 4.8 - .NETFramework,Version=v4.8";
            String expected1 = "Assembly target framework: <<Target Framework>>";
            String actual1 = ReplaceAssemblyTargetFrameworkWithConstant(input1);
            Assert.That(actual1, Is.EqualTo(expected1));
        }

        [TestCase]
        public void Test_ReplaceServerNameWithConstant()
        {
            String input1 = $"Server name: {DatabaseServer}";
            String expected1 = "Server name: <<Server name>>";
            String actual1 = ReplaceServerNameWithConstant(input1);
            Assert.That(actual1, Is.EqualTo(expected1));
        }
    }
}
