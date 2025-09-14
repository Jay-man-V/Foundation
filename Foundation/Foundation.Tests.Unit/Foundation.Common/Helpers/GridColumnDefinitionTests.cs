//-----------------------------------------------------------------------
// <copyright file="GridColumnDefinitionTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using DocumentFormat.OpenXml.Presentation;

using Foundation.Interfaces;
using Foundation.Interfaces.Helpers;
using Foundation.Models.Specialised;
using Foundation.Resources;
using Foundation.Tests.Unit.Support;

using System.Data;
using System.Drawing;

namespace Foundation.Tests.Unit.Foundation.Common.Helpers
{
    /// <summary>
    /// The Grid Column Definition Tests class
    /// </summary>
    [TestFixture]
    public class GridColumnDefinitionTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructor_Default()
        {
            const int width = 0;
            string dataMemberName = string.Empty;
            string columnHeaderName = string.Empty;
            Type dataType = typeof(string);
            const TextAlignment textAlignment = TextAlignment.NotSet;
            const int maxInputLength = 0;
            string dotNetFormat = string.Empty;
            string excelFormat = string.Empty;
            const object? maximumValue = null;
            const object? minimumValue = null;
            string trueValue = string.Empty;
            string falseValue = string.Empty;
            const object? dataSource = null;
            const string valueMember = "ValueMember";
            const string displayMember = "DisplayMember";
            const bool visible = false;
            const bool readOnly = false;
            string templateName = GridColumnTemplateNames.DefaultColumnTemplate;

            IGridColumnDefinition obj = new GridColumnDefinition();

            Assert.That(obj.Width, Is.EqualTo(width));
            Assert.That(obj.DataMemberName, Is.EqualTo(dataMemberName));
            Assert.That(obj.ColumnHeaderName, Is.EqualTo(columnHeaderName));
            Assert.That(obj.DataType, Is.EqualTo(dataType));
            Assert.That(obj.TextAlignment, Is.EqualTo(textAlignment));
            Assert.That(obj.MaxInputLength, Is.EqualTo(maxInputLength));
            Assert.That(obj.DotNetFormat, Is.EqualTo(dotNetFormat));
            Assert.That(obj.ExcelFormat, Is.EqualTo(excelFormat));
            Assert.That(obj.MaximumValue, Is.EqualTo(maximumValue));
            Assert.That(obj.MinimumValue, Is.EqualTo(minimumValue));
            Assert.That(obj.TrueValue, Is.EqualTo(trueValue));
            Assert.That(obj.FalseValue, Is.EqualTo(falseValue));
            Assert.That(obj.DataSource, Is.EqualTo(dataSource));
            Assert.That(obj.ValueMember, Is.EqualTo(valueMember));
            Assert.That(obj.DisplayMember, Is.EqualTo(displayMember));
            Assert.That(obj.Visible, Is.EqualTo(visible));
            Assert.That(obj.ReadOnly, Is.EqualTo(readOnly));
            Assert.That(obj.TemplateName, Is.EqualTo(templateName));
        }

        [TestCase(typeof(EntityId), 0, long.MaxValue, nameof(GridColumnTemplateNames.DefaultColumnTemplate), "0", "###0")]
        [TestCase(typeof(AppId), 0, long.MaxValue, nameof(GridColumnTemplateNames.DefaultColumnTemplate), "0", "###0")]
        [TestCase(typeof(LogId), 0, long.MaxValue, nameof(GridColumnTemplateNames.DefaultColumnTemplate), "0", "###0")]
        [TestCase(typeof(Image), null, null, nameof(GridColumnTemplateNames.ImageColumnTemplate), "", "")]
        [TestCase(typeof(string), null, null, nameof(GridColumnTemplateNames.DefaultColumnTemplate), "", "")]
        [TestCase(typeof(short), short.MinValue, short.MaxValue, nameof(GridColumnTemplateNames.NumericColumnTemplate), "N0", "#,##0")]
        [TestCase(typeof(int), int.MinValue, int.MaxValue, nameof(GridColumnTemplateNames.NumericColumnTemplate), "N0", "#,##0")]
        [TestCase(typeof(long), long.MinValue, long.MaxValue, nameof(GridColumnTemplateNames.NumericColumnTemplate), "N0", "#,##0")]
        public void Test_Constructor_Generic(Type dataType, object? minimumValue, object? maximumValue, string templateName, string dotNetFormat, string excelFormat)
        {
            Test_Constructor(dataType, minimumValue, maximumValue, templateName, dotNetFormat, excelFormat);
        }

        [TestCase]
        public void Test_Constructor_Decimal()
        {
            Type dataType = typeof(decimal);
            decimal minimumValue = decimal.MinValue;
            decimal maximumValue = decimal.MaxValue;
            string templateName = GridColumnTemplateNames.NumericColumnTemplate;
            string dotNetFormat = Formats.DotNet.Decimal2dp;
            string excelFormat = Formats.Excel.Decimal2dp;

            Test_Constructor(dataType, minimumValue, maximumValue, templateName, dotNetFormat, excelFormat);
        }

        [TestCase]
        public void Test_Constructor_Double()
        {
            Type dataType = typeof(double);
            double minimumValue = double.MinValue;
            double maximumValue = double.MaxValue;
            string templateName = GridColumnTemplateNames.NumericColumnTemplate;
            string dotNetFormat = Formats.DotNet.Decimal2dp;
            string excelFormat = Formats.Excel.Decimal2dp;

            Test_Constructor(dataType, minimumValue, maximumValue, templateName, dotNetFormat, excelFormat);
        }

        [TestCase]
        public void Test_Constructor_TimeSpan()
        {
            Type dataType = typeof(TimeSpan);
            TimeSpan minimumValue = TimeSpan.MinValue;
            TimeSpan maximumValue = TimeSpan.MaxValue;
            string templateName = GridColumnTemplateNames.DateTimeColumnTemplate;
            string dotNetFormat = Formats.DotNet.TimeOnly;
            string excelFormat = Formats.Excel.TimeOnly;

            Test_Constructor(dataType, minimumValue, maximumValue, templateName, dotNetFormat, excelFormat);
        }

        [TestCase]
        public void Test_Constructor_DateTime()
        {
            Type dataType = typeof(DateTime);
            DateTime minimumValue = DateTime.MinValue;
            DateTime maximumValue = DateTime.MaxValue;
            string templateName = GridColumnTemplateNames.DateTimeColumnTemplate;
            string dotNetFormat = Formats.DotNet.DateTime;
            string excelFormat = Formats.Excel.DateTime;

            Test_Constructor(dataType, minimumValue, maximumValue, templateName, dotNetFormat, excelFormat);
        }

        [TestCase]
        public void Test_Constructor_Boolean()
        {
            Type dataType = typeof(bool);
            const object? minimumValue = null;
            const object? maximumValue = null;
            string templateName = GridColumnTemplateNames.YesNoColumnTemplate;

            int width = 100;
            string dataMemberName = "dataMemberName";
            string columnHeaderName = "columnHeaderName";

            string valueMember = "ValueMember";
            string displayMember = "DisplayMember";
            string trueValue = "Y";
            string falseValue = "N";

            GridColumnDefinition obj = new GridColumnDefinition(width, dataMemberName, columnHeaderName, dataType);

            Assert.That(obj.Width, Is.EqualTo(width));
            Assert.That(obj.DataMemberName, Is.EqualTo(dataMemberName));
            Assert.That(obj.ColumnHeaderName, Is.EqualTo(columnHeaderName));
            Assert.That(obj.DataType, Is.EqualTo(dataType));
            Assert.That(obj.TemplateName, Is.EqualTo(templateName));

            Assert.That(obj.ValueMember, Is.EqualTo(valueMember));
            Assert.That(obj.DisplayMember, Is.EqualTo(displayMember));

            Assert.That(obj.MinimumValue, Is.EqualTo(minimumValue));
            Assert.That(obj.MaximumValue, Is.EqualTo(maximumValue));

            Assert.That(obj.TrueValue, Is.EqualTo(trueValue));
            Assert.That(obj.FalseValue, Is.EqualTo(falseValue));
        }
        [TestCase]
        public void Test_Constructor_ImageDropDown()
        {
            Type dataType = typeof(Image);
            const string? minimumValue = null;
            const string? maximumValue = null;
            string templateName = GridColumnTemplateNames.ImageColumnTemplate;

            IGridColumnDefinition gridColumnDefinition = Test_Constructor(dataType, minimumValue, maximumValue, templateName, string.Empty, string.Empty);
            gridColumnDefinition.DataSource = new object();

            Assert.That(gridColumnDefinition.TemplateName, Is.EqualTo(GridColumnTemplateNames.ImageDropDownBoxColumnTemplate));
        }

        [TestCase]
        public void Test_Constructor_StringDropDown()
        {
            Type dataType = typeof(string);
            const string? minimumValue = null;
            const string? maximumValue = null;
            string templateName = GridColumnTemplateNames.DefaultColumnTemplate;

            IGridColumnDefinition gridColumnDefinition = Test_Constructor(dataType, minimumValue, maximumValue, templateName, string.Empty, string.Empty);
            gridColumnDefinition.DataSource = new object();

            Assert.That(gridColumnDefinition.TemplateName, Is.EqualTo(GridColumnTemplateNames.DropDownBoxColumnTemplate));
        }

        private GridColumnDefinition Test_Constructor(Type dataType, object? minimumValue, object? maximumValue, string templateName, string dotNetFormat, string excelFormat)
        {
            int width = 100;
            string dataMemberName = "dataMemberName";
            string columnHeaderName = "columnHeaderName";

            string valueMember = "ValueMember";
            string displayMember = "DisplayMember";

            GridColumnDefinition obj = new GridColumnDefinition(width, dataMemberName, columnHeaderName, dataType);

            Assert.That(obj.Width, Is.EqualTo(width));
            Assert.That(obj.DataMemberName, Is.EqualTo(dataMemberName));
            Assert.That(obj.ColumnHeaderName, Is.EqualTo(columnHeaderName));
            Assert.That(obj.DataType, Is.EqualTo(dataType));
            Assert.That(obj.TemplateName, Is.EqualTo(templateName));

            Assert.That(obj.ValueMember, Is.EqualTo(valueMember));
            Assert.That(obj.DisplayMember, Is.EqualTo(displayMember));

            Assert.That(obj.MinimumValue, Is.EqualTo(minimumValue));
            Assert.That(obj.MaximumValue, Is.EqualTo(maximumValue));

            Assert.That(obj.DotNetFormat, Is.EqualTo(dotNetFormat));
            Assert.That(obj.ExcelFormat, Is.EqualTo(excelFormat));

            return obj;
        }

        [TestCase]
        public void Test_Clone()
        {
            GridColumnDefinition obj = new GridColumnDefinition(123456, "supplied dataMemberName", "supplied columnHeaderName", typeof(string))
            {
                TextAlignment = TextAlignment.Left,
                MaxInputLength = 123,
                DotNetFormat = "DotNetFormat dd-MMM-yyyy HH:mm:ss",
                ExcelFormat = "ExcelFormat dd-MMM-yyyy HH:mm:ss",
                MinimumValue = 100,
                MaximumValue = 365,
                TrueValue = "Up",
                FalseValue = "Down",
                DataSource = new DataTable(),
                ValueMember = "new ValueMember",
                DisplayMember = "new displayMember",
                Visible = false,
                ReadOnly = false
            };

            GridColumnDefinition cloned = (GridColumnDefinition)obj.Clone();

            Assert.That(cloned, Is.EqualTo(obj));

            int hashCodeOriginal = obj.GetHashCode();
            int hashCodeCopy = cloned.GetHashCode();
            Assert.That(hashCodeOriginal, Is.EqualTo(hashCodeCopy));

            Assert.That(cloned.Equals(obj), Is.EqualTo(true));
            Assert.That(cloned.Equals(null), Is.EqualTo(false));
            Assert.That(obj.Equals(null), Is.EqualTo(false));

            cloned.MaxInputLength = 456;
            Assert.That(cloned.Equals(obj), Is.EqualTo(false));
        }
    }
}
