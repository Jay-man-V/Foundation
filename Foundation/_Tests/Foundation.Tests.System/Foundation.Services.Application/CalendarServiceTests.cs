//-----------------------------------------------------------------------
// <copyright file="CalendarServiceTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Services.Application;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.System.Foundation.Services.Application
{
    /// <summary>
    /// System Tests for CalendarServiceTests
    /// </summary>
    [TestFixture]
    public class CalendarServiceTests : BusinessProcessUnitTestsBase
    {
        private ICalendarService? TheService { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            //TheService = ;
        }
    }
}
