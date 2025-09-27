//-----------------------------------------------------------------------
// <copyright file="GridColumnDefinitionTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Drawing;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Interfaces.Helpers;
using Foundation.Resources;

using Foundation.Tests.Unit.BaseClasses;

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
            const Int32 width = 0;
            String dataMemberName = String.Empty;
            String columnHeaderName = String.Empty;
            Type dataType = typeof(String);
            const TextAlignment textAlignment = TextAlignment.NotSet;
            const Int32 maxInputLength = 0;
            String dotNetFormat = String.Empty;
            String excelFormat = String.Empty;
            const Object? maximumValue = null;
            const Object? minimumValue = null;
            String trueValue = String.Empty;
            String falseValue = String.Empty;
            const Object? dataSource = null;
            const String valueMember = "ValueMember";
            const String displayMember = "DisplayMember";
            const Boolean visible = false;
            const Boolean readOnly = false;
            String templateName = GridColumnTemplateNames.DefaultColumnTemplate;

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

        [TestCase(typeof(EntityId), 0, Int64.MaxValue, nameof(GridColumnTemplateNames.DefaultColumnTemplate), "0", "###0")]
        [TestCase(typeof(AppId), 0, Int64.MaxValue, nameof(GridColumnTemplateNames.DefaultColumnTemplate), "0", "###0")]
        [TestCase(typeof(LogId), 0, Int64.MaxValue, nameof(GridColumnTemplateNames.DefaultColumnTemplate), "0", "###0")]
        [TestCase(typeof(Image), null, null, nameof(GridColumnTemplateNames.ImageColumnTemplate), "", "")]
        [TestCase(typeof(String), null, null, nameof(GridColumnTemplateNames.DefaultColumnTemplate), "", "")]
        [TestCase(typeof(short), short.MinValue, short.MaxValue, nameof(GridColumnTemplateNames.NumericColumnTemplate), "N0", "#,##0")]
        [TestCase(typeof(int), int.MinValue, int.MaxValue, nameof(GridColumnTemplateNames.NumericColumnTemplate), "N0", "#,##0")]
        [TestCase(typeof(Int64), Int64.MinValue, Int64.MaxValue, nameof(GridColumnTemplateNames.NumericColumnTemplate), "N0", "#,##0")]
        public void Test_Constructor_Generic(Type dataType, Object? minimumValue, Object? maximumValue, String templateName, String dotNetFormat, String excelFormat)
        {
            Test_Constructor(dataType, minimumValue, maximumValue, templateName, dotNetFormat, excelFormat);
        }

        [TestCase]
        public void Test_Constructor_Decimal()
        {
            Type dataType = typeof(Decimal);
            Decimal minimumValue = Decimal.MinValue;
            Decimal maximumValue = Decimal.MaxValue;
            String templateName = GridColumnTemplateNames.NumericColumnTemplate;
            String dotNetFormat = Formats.DotNet.Decimal2dp;
            String excelFormat = Formats.Excel.Decimal2dp;

            Test_Constructor(dataType, minimumValue, maximumValue, templateName, dotNetFormat, excelFormat);
        }

        [TestCase]
        public void Test_Constructor_Double()
        {
            Type dataType = typeof(Double);
            Double minimumValue = Double.MinValue;
            Double maximumValue = Double.MaxValue;
            String templateName = GridColumnTemplateNames.NumericColumnTemplate;
            String dotNetFormat = Formats.DotNet.Decimal2dp;
            String excelFormat = Formats.Excel.Decimal2dp;

            Test_Constructor(dataType, minimumValue, maximumValue, templateName, dotNetFormat, excelFormat);
        }

        [TestCase]
        public void Test_Constructor_TimeSpan()
        {
            Type dataType = typeof(TimeSpan);
            TimeSpan minimumValue = TimeSpan.MinValue;
            TimeSpan maximumValue = TimeSpan.MaxValue;
            String templateName = GridColumnTemplateNames.DateTimeColumnTemplate;
            String dotNetFormat = Formats.DotNet.TimeOnly;
            String excelFormat = Formats.Excel.TimeOnly;

            Test_Constructor(dataType, minimumValue, maximumValue, templateName, dotNetFormat, excelFormat);
        }

        [TestCase]
        public void Test_Constructor_DateTime()
        {
            Type dataType = typeof(DateTime);
            DateTime minimumValue = DateTime.MinValue;
            DateTime maximumValue = DateTime.MaxValue;
            String templateName = GridColumnTemplateNames.DateTimeColumnTemplate;
            String dotNetFormat = Formats.DotNet.DateTime;
            String excelFormat = Formats.Excel.DateTime;

            Test_Constructor(dataType, minimumValue, maximumValue, templateName, dotNetFormat, excelFormat);
        }

        [TestCase]
        public void Test_Constructor_Boolean()
        {
            Type dataType = typeof(Boolean);
            const Object? minimumValue = null;
            const Object? maximumValue = null;
            String templateName = GridColumnTemplateNames.YesNoColumnTemplate;

            Int32 width = 100;
            String dataMemberName = "dataMemberName";
            String columnHeaderName = "columnHeaderName";

            String valueMember = "ValueMember";
            String displayMember = "DisplayMember";
            String trueValue = "Y";
            String falseValue = "N";

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
            const String? minimumValue = null;
            const String? maximumValue = null;
            String templateName = GridColumnTemplateNames.ImageColumnTemplate;

            IGridColumnDefinition gridColumnDefinition = Test_Constructor(dataType, minimumValue, maximumValue, templateName, String.Empty, String.Empty);
            gridColumnDefinition.DataSource = new Object();

            Assert.That(gridColumnDefinition.TemplateName, Is.EqualTo(GridColumnTemplateNames.ImageDropDownBoxColumnTemplate));
        }

        [TestCase]
        public void Test_Constructor_StringDropDown()
        {
            Type dataType = typeof(String);
            const String? minimumValue = null;
            const String? maximumValue = null;
            String templateName = GridColumnTemplateNames.DefaultColumnTemplate;

            IGridColumnDefinition gridColumnDefinition = Test_Constructor(dataType, minimumValue, maximumValue, templateName, String.Empty, String.Empty);
            gridColumnDefinition.DataSource = new Object();

            Assert.That(gridColumnDefinition.TemplateName, Is.EqualTo(GridColumnTemplateNames.DropDownBoxColumnTemplate));
        }

        private GridColumnDefinition Test_Constructor(Type dataType, Object? minimumValue, Object? maximumValue, String templateName, String dotNetFormat, String excelFormat)
        {
            Int32 width = 100;
            String dataMemberName = "dataMemberName";
            String columnHeaderName = "columnHeaderName";

            String valueMember = "ValueMember";
            String displayMember = "DisplayMember";

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
            GridColumnDefinition obj = new GridColumnDefinition(123456, "supplied dataMemberName", "supplied columnHeaderName", typeof(String))
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

            Int32 hashCodeOriginal = obj.GetHashCode();
            Int32 hashCodeCopy = cloned.GetHashCode();
            Assert.That(hashCodeOriginal, Is.EqualTo(hashCodeCopy));

            Assert.That(cloned.Equals(obj), Is.EqualTo(true));
            Assert.That(cloned.Equals(null), Is.EqualTo(false));
            Assert.That(obj.Equals(null), Is.EqualTo(false));

            cloned.MaxInputLength = 456;
            Assert.That(cloned.Equals(obj), Is.EqualTo(false));
        }
    }
}
