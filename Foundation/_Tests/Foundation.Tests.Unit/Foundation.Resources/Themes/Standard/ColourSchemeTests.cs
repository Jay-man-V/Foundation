//-----------------------------------------------------------------------
// <copyright file="ColourSchemeTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Resources;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Resources.Themes.Standard
{
    /// <summary>
    /// Unit Tests for the Colour Scheme class
    /// </summary>
    [TestFixture]
    public class ColourSchemeTests : UnitTestBase
    {
        [TestCase]
        public void Test_CountMembers()
        {
            IEnumerable<MethodInfo> testMethods = GetListOfTestMethods();
            Int32 testMethodCount = testMethods.Count();

            // This test exists to ensure all the Properties are tested/checked in the next test
            Type theType = typeof(ColourScheme);
            PropertyInfo[] propertyInfos = theType.GetProperties();

            Assert.That(propertyInfos.Length, Is.EqualTo(testMethodCount - 1));

            Int32 index = 0;
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.DefaultBackgroundColour)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.DefaultForegroundColour)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.DataGridMainBackgroundColour)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.DataGridAlternateBackgroundColour)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.DataGridRowSelectedBackground)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.DataGridRowSelectedForeground)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.SystemAdministratorBackgroundColour)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.SystemAdministratorForegroundColour)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.SystemSupervisorBackgroundColour)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.SystemSupervisorForegroundColour)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.DefaultWindowTitleBrushColour1)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.DefaultWindowTitleBrushColour2)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.ErrorWindowTitleBrushColour1)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.ErrorWindowTitleBrushColour2)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.QuestionWindowTitleBrushColour1)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.QuestionWindowTitleBrushColour2)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.WarningWindowTitleBrushColour1)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.WarningWindowTitleBrushColour2)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.NotificationNotSetBackgroundColour1)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.NotificationNotSetBackgroundColour2)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.NotificationInformationBackgroundColour1)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.NotificationInformationBackgroundColour2)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.NotificationSuccessBackgroundColour1)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.NotificationSuccessBackgroundColour2)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.NotificationWarningBackgroundColour1)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.NotificationWarningBackgroundColour2)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.NotificationSeriousWarningBackgroundColour1)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.NotificationSeriousWarningBackgroundColour2)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.NotificationErrorBackgroundColour1)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.NotificationErrorBackgroundColour2)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.NotificationFatalErrorBackgroundColour1)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.NotificationFatalErrorBackgroundColour2)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.NotificationCommonForegroundColour)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ColourScheme.DataGridMainForegroundColour)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DefaultBackgroundColour()
        {
            Assert.That(ColourScheme.DefaultBackgroundColour.ToArgb(), Is.EqualTo(-6751336));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DefaultForegroundColour()
        {
            Assert.That(ColourScheme.DefaultForegroundColour.ToArgb(), Is.EqualTo(-256));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DataGridMainBackgroundColour()
        {
            Assert.That(ColourScheme.DataGridMainBackgroundColour.ToArgb(), Is.EqualTo(-6751336));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DataGridAlternateBackgroundColour()
        {
            Assert.That(ColourScheme.DataGridAlternateBackgroundColour.ToArgb(), Is.EqualTo(-5383962));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DataGridRowSelectedBackground()
        {
            Assert.That(ColourScheme.DataGridRowSelectedBackground.ToArgb(), Is.EqualTo(-16746281));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DataGridRowSelectedForeground()
        {
            Assert.That(ColourScheme.DataGridRowSelectedForeground.ToArgb(), Is.EqualTo(-1));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_SystemAdministratorBackgroundColour()
        {
            Assert.That(ColourScheme.SystemAdministratorBackgroundColour.ToArgb(), Is.EqualTo(-16777216));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_SystemAdministratorForegroundColour()
        {
            Assert.That(ColourScheme.SystemAdministratorForegroundColour.ToArgb(), Is.EqualTo(-1));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_SystemSupervisorBackgroundColour()
        {
            Assert.That(ColourScheme.SystemSupervisorBackgroundColour.ToArgb(), Is.EqualTo(-16777216));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_SystemSupervisorForegroundColour()
        {
            Assert.That(ColourScheme.SystemSupervisorForegroundColour.ToArgb(), Is.EqualTo(-256));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DefaultWindowTitleBrush_Colour_1()
        {
            Assert.That(ColourScheme.DefaultWindowTitleBrushColour1.ToArgb(), Is.EqualTo(-10185235));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DefaultWindowTitleBrush_Colour_2()
        {
            Assert.That(ColourScheme.DefaultWindowTitleBrushColour2.ToArgb(), Is.EqualTo(-2031617));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_ErrorWindowTitleBrush_Colour_1()
        {
            Assert.That(ColourScheme.ErrorWindowTitleBrushColour1.ToArgb(), Is.EqualTo(-2396013));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_ErrorWindowTitleBrush_Colour_2()
        {
            Assert.That(ColourScheme.ErrorWindowTitleBrushColour2.ToArgb(), Is.EqualTo(-18751));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_QuestionWindowTitleBrush_Colour_1()
        {
            Assert.That(ColourScheme.QuestionWindowTitleBrushColour1.ToArgb(), Is.EqualTo(-13447886));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_QuestionWindowTitleBrush_Colour_2()
        {
            Assert.That(ColourScheme.QuestionWindowTitleBrushColour2.ToArgb(), Is.EqualTo(-7278960));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_WarningWindowTitleBrush_Colour_1()
        {
            Assert.That(ColourScheme.WarningWindowTitleBrushColour1.ToArgb(), Is.EqualTo(-5374161));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_WarningWindowTitleBrush_Colour_2()
        {
            Assert.That(ColourScheme.WarningWindowTitleBrushColour2.ToArgb(), Is.EqualTo(-256));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_NotificationNotSetBackground_Colour_1()
        {
            Assert.That(ColourScheme.NotificationNotSetBackgroundColour1.ToArgb(), Is.EqualTo(-1));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_NotificationNotSetBackground_Colour_2()
        {
            Assert.That(ColourScheme.NotificationNotSetBackgroundColour2.ToArgb(), Is.EqualTo(-16777216));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_NotificationInformationBackground_Colour_1()
        {
            Assert.That(ColourScheme.NotificationInformationBackgroundColour1.ToArgb(), Is.EqualTo(-983041));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_NotificationInformationBackground_Colour_2()
        {
            Assert.That(ColourScheme.NotificationInformationBackgroundColour2.ToArgb(), Is.EqualTo(-5383962));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_NotificationSuccessBackground_Colour_1()
        {
            Assert.That(ColourScheme.NotificationSuccessBackgroundColour1.ToArgb(), Is.EqualTo(-6751336));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_NotificationSuccessBackground_Colour_2()
        {
            Assert.That(ColourScheme.NotificationSuccessBackgroundColour2.ToArgb(), Is.EqualTo(-16744448));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_NotificationWarningBackground_Colour_1()
        {
            Assert.That(ColourScheme.NotificationWarningBackgroundColour1.ToArgb(), Is.EqualTo(-32));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_NotificationWarningBackground_Colour_2()
        {
            Assert.That(ColourScheme.NotificationWarningBackgroundColour2.ToArgb(), Is.EqualTo(-256));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_NotificationSeriousWarningBackground_Colour_1()
        {
            Assert.That(ColourScheme.NotificationSeriousWarningBackgroundColour1.ToArgb(), Is.EqualTo(-256));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_NotificationSeriousWarningBackground_Colour_2()
        {
            Assert.That(ColourScheme.NotificationSeriousWarningBackgroundColour2.ToArgb(), Is.EqualTo(-256));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_NotificationErrorBackground_Colour_1()
        {
            Assert.That(ColourScheme.NotificationErrorBackgroundColour1.ToArgb(), Is.EqualTo(-3318692));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_NotificationErrorBackground_Colour_2()
        {
            Assert.That(ColourScheme.NotificationErrorBackgroundColour2.ToArgb(), Is.EqualTo(-65536));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_NotificationFatalErrorBackground_Colour_1()
        {
            Assert.That(ColourScheme.NotificationFatalErrorBackgroundColour1.ToArgb(), Is.EqualTo(-65536));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_NotificationFatalErrorBackground_Colour_2()
        {
            Assert.That(ColourScheme.NotificationFatalErrorBackgroundColour2.ToArgb(), Is.EqualTo(-7667712));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_NotificationCommonForegroundColour()
        {
            Assert.That(ColourScheme.NotificationCommonForegroundColour.ToArgb(), Is.EqualTo(-16777216));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DataGridMainForegroundColour()
        {
            Assert.That(ColourScheme.DataGridMainForegroundColour.ToArgb(), Is.EqualTo(-16777216));
        }
    }
}
