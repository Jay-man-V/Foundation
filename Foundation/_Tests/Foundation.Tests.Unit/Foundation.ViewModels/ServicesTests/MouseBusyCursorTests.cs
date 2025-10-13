//-----------------------------------------------------------------------
// <copyright file="MouseBusyCursorTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Tests.Unit.BaseClasses;

using Foundation.ViewModels.Services;

namespace Foundation.Tests.Unit.Foundation.ViewModels.ServicesTests
{
    /// <summary>
    /// Summary description for MouseBusyCursorTests
    /// </summary>
    [TestFixture]
    public class MouseBusyCursorTests : UnitTestBase
    {
        private IMouseCursor CreateProcess()
        {
            IWpfApplicationObjects wpfApplicationObjects = Substitute.For<IWpfApplicationObjects>();
            IMouseCursor retVal = new MouseBusyCursor(wpfApplicationObjects);

            return retVal;
        }

        [TestCase]
        public void Test_Constructor()
        {
            MouseBusyCursor mouseBusyCursor = (MouseBusyCursor)CreateProcess();
            Assert.That(mouseBusyCursor.IsBusy, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_Constructor_And_Disposed()
        {
            MouseBusyCursor? mouseBusyCursor = null;
            using (mouseBusyCursor = (MouseBusyCursor)CreateProcess())
            {
                Assert.That(mouseBusyCursor.IsBusy, Is.EqualTo(true));
            }

            mouseBusyCursor.Dispose();
            Assert.That(mouseBusyCursor.IsBusy, Is.EqualTo(false));
        }

        [TestCase]
        public void Test_Constructor_And_UsingBlock()
        {
            using (MouseBusyCursor mouseBusyCursor = (MouseBusyCursor)CreateProcess())
            {
                Assert.That(mouseBusyCursor.IsBusy, Is.EqualTo(true));
            }
        }
    }
}
