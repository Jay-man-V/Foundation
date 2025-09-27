//-----------------------------------------------------------------------
// <copyright file="ApplicationSupportTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ApplicationSupportTests
{
    /// <summary>
    /// ApplicationSupport Tests
    /// </summary>
    [TestFixture]
    public class ApplicationSupportTests : UnitTestBase
    {
        private Boolean AdditionalHandlerCalled { get; set; }

        private void AdditionalExceptionHandler(Exception exception)
        {
            AdditionalHandlerCalled = true;
        }

        public override void TestInitialise()
        {
            base.TestInitialise();

            AdditionalHandlerCalled = false;
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_ApplicationStart()
        {
            ApplicationControl.ApplicationStart(AdditionalExceptionHandler);

            Assert.That(AdditionalHandlerCalled, Is.EqualTo(false));

            ApplicationControl.ApplicationClose(AdditionalExceptionHandler);
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_ApplicationStart_Null()
        {
            ApplicationControl.ApplicationStart(null);

            ApplicationControl.ApplicationClose(null);
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_LogExceptionMessage()
        {
            try
            {
                ApplicationControl.ApplicationStart(AdditionalExceptionHandler);

                throw new Exception(LocationUtils.GetFunctionName());
            }
            catch (Exception exception)
            {
                ApplicationControl.LogExceptionMessage(exception);
            }

            Assert.That(AdditionalHandlerCalled, Is.EqualTo(false));

            ApplicationControl.ApplicationClose(AdditionalExceptionHandler);
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_TaskSchedulerException()
        {
            ApplicationControl.ApplicationStart(AdditionalExceptionHandler);

            Task.Run(() =>
            {
                try
                {
                    throw new Exception(LocationUtils.GetFunctionName());
                }
                finally
                {
                    Assert.That(AdditionalHandlerCalled, Is.EqualTo(true));
                }
            });

            ApplicationControl.ApplicationClose(AdditionalExceptionHandler);
            Assert.That(AdditionalHandlerCalled, Is.EqualTo(true));
        }
    }
}
