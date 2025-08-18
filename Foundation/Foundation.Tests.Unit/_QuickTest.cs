//-----------------------------------------------------------------------
// <copyright file="QuickTest.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Tests.Unit
{
    public class QuickTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase]
        public void Test1()
        {
            Guid value = new Guid("{0B368339-E43E-4AFF-9FBC-C9F0074FD068}");
            Guid expectedValue = Guid.Parse($"{value}");
        }
    }
}