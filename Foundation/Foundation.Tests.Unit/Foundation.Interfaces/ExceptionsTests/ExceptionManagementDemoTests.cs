//-----------------------------------------------------------------------
// <copyright file="ExceptionManagementDemoTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Interfaces.ExceptionsTests
{
    /// <summary>
    /// The ExceptionManagementDemoTests Tests
    /// </summary>
    [TestFixture]
    public class ExceptionManagementDemoTests : UnitTestBase
    {
        [TestCase]
        public void Test_Method1_True_False()
        {
            try
            {
                ExceptionManagementDemo demo = new ExceptionManagementDemo();
                demo.Method1(true, false);
            }
            catch(Exception exception)
            {
                if (exception.InnerException != null)
                {
                }
            }
        }

        [TestCase]
        public void Test_Method1_True_True()
        {
            try
            {
                ExceptionManagementDemo demo = new ExceptionManagementDemo();
                demo.Method1(true, true);
            }
            catch (Exception exception)
            {
                if (exception.InnerException != null)
                {
                }
            }
        }

        [TestCase]
        public void Test_Method1_False_False()
        {
            try
            {
                ExceptionManagementDemo demo = new ExceptionManagementDemo();
                demo.Method1(false, false);
            }
            catch (Exception exception)
            {
                if (exception.InnerException != null)
                {
                }
            }
        }

        [TestCase]
        public void Test_Method1_False_True()
        {
            try
            {
                ExceptionManagementDemo demo = new ExceptionManagementDemo();
                demo.Method1(false, true);
            }
            catch (Exception exception)
            {
                if (exception.InnerException != null)
                {
                }
            }
        }
    }
}
