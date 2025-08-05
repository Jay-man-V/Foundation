//-----------------------------------------------------------------------
// <copyright file="SpreadsheetGenerator.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Drawing;
using System.Globalization;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

using Foundation.Interfaces;
using Foundation.Common;

namespace Foundation.DocumentGenerator
{
    /// <summary>
    /// The Document Generator
    /// https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk
    /// </summary>
    [DependencyInjectionTransient]
    public class SpreadsheetGenerator : ISpreadsheetGenerator
    {
        private NumberingFormats NumberingFormats { get; } = new();
        private CellFormats CellFormats { get; } = new();
        private SheetData? SheetData { get; set; }
        private Fonts Fonts { get; } = new();
        private Fills Fills { get; } = new();
        private Borders Borders { get; } = new();
        private CellStyleFormats CellStyleFormats { get; } = new();

        /// <summary>
        /// Exports the data.
        /// </summary>
        /// <param name="sourceData">The source data.</param>
        /// <param name="gridColumnDefinitions">The grid column definitions.</param>
        /// <param name="outputFile">The output file.</param>
        public void ExportData
        (
            IList<IFoundationModel> sourceData,
            List<IGridColumnDefinition> gridColumnDefinitions,
            String outputFile
        )
        {
            using (SpreadsheetDocument excel = CreateSpreadsheetWorkbook(outputFile))
            {
                // Add a WorkbookPart to the document.
                WorkbookPart workbookPart = AddWorkbookPart(excel);
                WorksheetPart worksheetPart = AddWorksheet(workbookPart, "Sheet 1");
                
                SheetData = new SheetData();
                AddBasicStylesheet(workbookPart);
                AddSheetHeader(SheetData, gridColumnDefinitions);
                AddSheetData(SheetData, gridColumnDefinitions, sourceData);
                Columns columns = AutoSizeCells(SheetData);
                worksheetPart.Worksheet.Append(columns);
                worksheetPart.Worksheet.Append(SheetData);

                // Save & close
                workbookPart.Workbook.Save();
                //excel.Close();
            }
        }

        private SpreadsheetDocument CreateSpreadsheetWorkbook(String filepath)
        {
            // Create a spreadsheet document by supplying the filepath.
            // By default, AutoSave = true, Editable = true, and Type = xlsx.
            SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(filepath, SpreadsheetDocumentType.Workbook);

            return spreadsheetDocument;
        }

        private WorkbookPart AddWorkbookPart(SpreadsheetDocument spreadsheetDocument)
        {
            // Add a WorkbookPart to the document.
            WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();

            return workbookPart;
        }

        private WorksheetPart AddWorksheet(WorkbookPart workbookPart, String sheetName)
        {
            // Add a WorksheetPart to the WorkbookPart.
            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet();

            // Add Sheets to the Workbook.
            Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

            //// Append a new worksheet and associate it with the workbook.
            Sheet sheet = new Sheet
            {
                Id = workbookPart.GetIdOfPart(worksheetPart),
                SheetId = (UInt32)sheets.ChildElements.Count + 1,
                Name = sheetName
            };
            sheets.Append(sheet);

            return worksheetPart;
        }

        private void AddBasicStylesheet(WorkbookPart workbookPart)
        {
            WorkbookStylesPart stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
            Stylesheet stylesheet = new Stylesheet();
            stylesPart.Stylesheet = stylesheet;
            stylesPart.Stylesheet.Save();

            Fonts.Append(new DocumentFormat.OpenXml.Spreadsheet.Font() // Font index 0 - default
            {
                FontName = new FontName { Val = StringValue.FromString("Calibri") },
                FontSize = new FontSize { Val = DoubleValue.FromDouble(11) }
            });

            Fills.Append(new Fill() // Fill index 0
            {
                PatternFill = new PatternFill { PatternType = PatternValues.None }
            });
            Fills.Append(new Fill() // Fill index 1
            {
                PatternFill = new PatternFill { PatternType = PatternValues.Gray125 }
            });

            Borders.Append(new Border // Border index 0: no border
            {
                LeftBorder = new LeftBorder(),
                RightBorder = new RightBorder(),
                TopBorder = new TopBorder(),
                BottomBorder = new BottomBorder(),
                DiagonalBorder = new DiagonalBorder()
            });
            Borders.Append(new Border //Boarder Index 1: All
            {
                LeftBorder = new LeftBorder { Style = BorderStyleValues.Thin },
                RightBorder = new RightBorder { Style = BorderStyleValues.Thin },
                TopBorder = new TopBorder { Style = BorderStyleValues.Thin },
                BottomBorder = new BottomBorder { Style = BorderStyleValues.Thin },
                DiagonalBorder = new DiagonalBorder()
            });

            CellStyleFormats.Append(new CellFormat // Cell style format index 0: no format
            {
                NumberFormatId = 0,
                FontId = 0,
                FillId = 0,
                BorderId = 0,
                FormatId = 0
            });
            CellStyleFormats.Count = UInt32Value.FromUInt32((UInt32)CellStyleFormats.ChildElements.Count);

            CellFormats.Append(new CellFormat()); // Cell format index 0

            stylesheet.Append(NumberingFormats);
            stylesheet.Append(Fonts);
            stylesheet.Append(Fills);
            stylesheet.Append(Borders);
            stylesheet.Append(CellStyleFormats);
            stylesheet.Append(CellFormats);

            CellStyles css = new CellStyles();
            css.Append(new CellStyle
            {
                Name = StringValue.FromString("Normal"),
                FormatId = 0,
                BuiltinId = 0
            });
            css.Count = UInt32Value.FromUInt32((uint)css.ChildElements.Count);
            stylesheet.Append(css);

            DifferentialFormats dfs = new DifferentialFormats { Count = 0 };
            stylesheet.Append(dfs);

            TableStyles tss = new TableStyles
            {
                Count = 0,
                DefaultTableStyle = StringValue.FromString("TableStyleMedium9"),
                DefaultPivotStyle = StringValue.FromString("PivotStyleLight16")
            };
            stylesheet.Append(tss);
        }

        Columns AutoSizeCells(SheetData sheetData)
        {
            Dictionary<Int32, Int32> maxColWidths = GetMaxCharacterWidth(sheetData);

            Columns columns = new Columns();
            // This is the width of my font - yours may be different
            Double maxWidth = 7;
            foreach (var item in maxColWidths)
            {
                // Width = Truncate([{Number of Characters} * {Maximum Digit Width} + {5 pixel padding}]/{Maximum Digit Width}*256)/256
                Double width = Math.Truncate((item.Value * maxWidth + 5) / maxWidth * 256) / 256;
                Column col = new Column()
                {
                    BestFit = true,
                    Min = (UInt32)(item.Key + 1),
                    Max = (UInt32)(item.Key + 1),
                    CustomWidth = true,
                    Width = width
                };
                columns.Append(col);
            }

            return columns;
        }

        Dictionary<Int32, Int32> GetMaxCharacterWidth(SheetData sheetData)
        {
            // Iterate over all cells getting a max char value for each column
            Dictionary<Int32, int> maxColWidth = new Dictionary<Int32, Int32>();
            List<Row> rows = sheetData.Elements<Row>().ToList();
            UInt32[] numberStyles = [5, 6, 7, 8]; // Styles that will add extra chars
            UInt32[] boldStyles = [1, 2, 3, 4, 6, 7, 8]; // Styles that will bold
            foreach (Row row in rows)
            {
                Cell[] cells = row.Elements<Cell>().ToArray();

                // Using cell index as my column
                for (Int32 i = 0; i < cells.Length; i++)
                {
                    Cell cell = cells[i];
                    String cellValue = cell.CellValue == null ? cell.InnerText : cell.CellValue.InnerText;
                    Int32 cellTextLength = cellValue.Length;

                    if (cell.StyleIndex != null &&
                        numberStyles.Contains(cell.StyleIndex))
                    {
                        Int32 thousandCount = (Int32)Math.Truncate((Double)cellTextLength / 4);

                        // Add 3 for '.00' 
                        cellTextLength += (3 + thousandCount);
                    }

                    if (cell.StyleIndex != null &&
                        boldStyles.Contains(cell.StyleIndex))
                    {
                        // Add an extra char for bold - not 100% accurate but good enough for what I need.
                        cellTextLength += 1;
                    }

                    if (!maxColWidth.TryAdd(i, cellTextLength))
                    {
                        Int32 current = maxColWidth[i];
                        if (cellTextLength > current)
                        {
                            maxColWidth[i] = cellTextLength;
                        }
                    }
                }
            }

            return maxColWidth;
        }

        ForegroundColor TranslateForeground(System.Drawing.Color fillColor)
        {
            return new ForegroundColor()
            {
                Rgb = new HexBinaryValue()
                {
                    Value =
                        ColorTranslator.ToHtml(
                            System.Drawing.Color.FromArgb(
                                fillColor.A,
                                fillColor.R,
                                fillColor.G,
                                fillColor.B)).Replace("#", "")
                }
            };
        }

        private UInt32Value GetStyleIndexForColumn(IGridColumnDefinition gridColumnDefinition)
        {
            // First check if we find an existing NumberingFormat with the desired settings
            DocGenNumberingFormat? numberingFormat = NumberingFormats.OfType<DocGenNumberingFormat>().FirstOrDefault(format => format.GetHashCode() == gridColumnDefinition.GetHashCode());

            if (numberingFormat == null)
            {
                // Built-in number formats are numbered 0 - 163. Custom formats must start at 164.
                UInt32 numberFormatId = Convert.ToUInt32(164 + NumberingFormats.Count());
                numberingFormat = new DocGenNumberingFormat(gridColumnDefinition)
                {
                    NumberFormatId = UInt32Value.FromUInt32(numberFormatId),
                };
                NumberingFormats.Append(numberingFormat);

                // We have to increase the count attribute manually ?!?
                NumberingFormats.Count = Convert.ToUInt32(NumberingFormats.Count());
            }

            CellFormat? cellFormat = CellFormats.OfType<CellFormat>().FirstOrDefault(format => format.NumberFormatId == numberingFormat.NumberFormatId);

            if (cellFormat == null)
            {
                cellFormat = new CellFormat
                {
                    NumberFormatId = numberingFormat.NumberFormatId,
                    FontId = 0,
                    FillId = 0,
                    BorderId = 0,
                    FormatId = 0,
                    Alignment = new Alignment { Horizontal = numberingFormat.HorizontalAlignment },
                    ApplyNumberFormat = BooleanValue.FromBoolean(true)
                };
                CellFormats.Append(cellFormat);
                CellFormats.Count = Convert.ToUInt32((UInt32)CellFormats.ChildElements.Count);
            }

            UInt32Value retVal = UInt32Value.ToUInt32((UInt32)CellFormats.ToList().IndexOf(cellFormat));

            return retVal;
        }

        private Cell ConvertDotNetValueToSpreadsheetValue(Object? propertyValue, IGridColumnDefinition gridColumnDefinition)
        {
            UInt32Value styleIndex = GetStyleIndexForColumn(gridColumnDefinition);
            CellValue? cellValue = null;
            InlineString? inlineString = null;
            EnumValue<CellValues>? dataType = null;

            if (propertyValue != null)
            {
                if (gridColumnDefinition.DataType == typeof(Boolean))
                {
                    Boolean booleanValue = (Boolean)propertyValue;
                    String outputText = booleanValue ? gridColumnDefinition.TrueValue : gridColumnDefinition.FalseValue;

                    dataType = new EnumValue<CellValues>(CellValues.InlineString);
                    inlineString = new InlineString { Text = new Text(outputText) };
                }
                else if (gridColumnDefinition.DataType.IsNumericType())
                {
                    dataType = new EnumValue<CellValues>(CellValues.Number);
                    cellValue = new CellValue(propertyValue.ToString() ?? String.Empty);
                }
                else if (gridColumnDefinition.DataType == typeof(AppId))
                {
                    AppId appIdValue = (AppId)propertyValue;
                    dataType = new EnumValue<CellValues>(CellValues.Number);
                    cellValue = new CellValue(appIdValue.ToInteger().ToString());
                }
                else if (gridColumnDefinition.DataType == typeof(EntityId))
                {
                    EntityId entityIdValue = (EntityId)propertyValue;
                    dataType = new EnumValue<CellValues>(CellValues.Number);
                    cellValue = new CellValue(entityIdValue.ToInteger().ToString());
                }
                else if (gridColumnDefinition.DataType == typeof(TimeSpan))
                {
                    TimeSpan timeSpanValue = (TimeSpan)propertyValue;
                    dataType = new EnumValue<CellValues>(CellValues.String);
                    cellValue = new CellValue(timeSpanValue.ToString());
                }
                else if (gridColumnDefinition.DataType == typeof(DateTime))
                {
                    DateTime dateTimeValue = (DateTime)propertyValue;
                    dataType = new EnumValue<CellValues>(CellValues.Number);
                    cellValue = new CellValue(dateTimeValue.ToOADate().ToString(CultureInfo.InvariantCulture));
                }
                else
                {
                    // Default to String value

                    // Check to see if there is a lookup list value
                    if (gridColumnDefinition.DataSource == null)
                    {
                        dataType = new EnumValue<CellValues>(CellValues.InlineString);
                        inlineString = new InlineString { Text = new Text(propertyValue.ToString() ?? String.Empty) };
                    }
                    else
                    {
                        IList aList = (IList)gridColumnDefinition.DataSource;
                        List<IFoundationModel> foundationModels = aList.Cast<IFoundationModel>().ToList();
                        IFoundationModel? foundationModel = foundationModels.FirstOrDefault(fm => fm.Id == propertyValue);

                        Object outputValue = foundationModel?.GetPropertyValue(gridColumnDefinition.DisplayMember) ?? String.Empty;

                        dataType = new EnumValue<CellValues>(CellValues.InlineString);
                        inlineString = new InlineString { Text = new Text(outputValue.ToString() ?? String.Empty) };
                    }
                }
            }

            Cell retVal = new Cell
            {
                StyleIndex = styleIndex,
                DataType = dataType,
            };

            if (cellValue == null)
            {
                retVal.InlineString = inlineString;
            }
            else
            {
                retVal.CellValue = cellValue;
            }

            return retVal;
        }

        private void AddSheetHeader(SheetData sheetData, List<IGridColumnDefinition> gridColumnDefinitions)
        {
            Fonts.Append(new DocumentFormat.OpenXml.Spreadsheet.Font
            {
                FontName = new FontName { Val = StringValue.FromString("Arial") },
                FontSize = new FontSize { Val = DoubleValue.FromDouble(11) },
                Bold = new Bold()
            });
            Fonts.Count = UInt32Value.FromUInt32((UInt32)Fonts.ChildElements.Count);

            Fills.Append(new Fill() // Fill index 3
            {
                PatternFill = new PatternFill
                {
                    PatternType = PatternValues.Solid,
                    ForegroundColor = TranslateForeground(System.Drawing.Color.LightSkyBlue),
                    BackgroundColor = new BackgroundColor { Rgb = TranslateForeground(System.Drawing.Color.LightBlue).Rgb }
                }
            });
            Fills.Count = UInt32Value.FromUInt32((UInt32)Fills.ChildElements.Count);

            Borders.Append(new Border
            {
                LeftBorder = new LeftBorder(),
                RightBorder = new RightBorder(),
                TopBorder = new TopBorder { Style = BorderStyleValues.Thin },
                BottomBorder = new BottomBorder { Style = BorderStyleValues.Thin },
                DiagonalBorder = new DiagonalBorder()
            });
            Borders.Count = UInt32Value.FromUInt32((UInt32)Borders.ChildElements.Count);

            CellFormats.Append(new CellFormat
            {
                NumberFormatId = 49,
                FontId = UInt32Value.FromUInt32((UInt32)Fonts.ChildElements.Count - 1),
                FillId = UInt32Value.FromUInt32((UInt32)Fills.ChildElements.Count - 1),
                BorderId = UInt32Value.FromUInt32((UInt32)Borders.ChildElements.Count - 1),
                FormatId = 0,
                ApplyNumberFormat = BooleanValue.FromBoolean(true),
                Alignment = new Alignment { Horizontal = HorizontalAlignmentValues.Center }
            });
            CellFormats.Count = UInt32Value.FromUInt32((UInt32)CellFormats.ChildElements.Count);

            Row headerRow = new Row();

            foreach (IGridColumnDefinition gridColumnDefinition in gridColumnDefinitions)
            {
                Cell cell = new Cell
                {
                    DataType = CellValues.InlineString,
                    InlineString = new InlineString { Text = new Text(gridColumnDefinition.ColumnHeaderName) },
                    StyleIndex = UInt32Value.ToUInt32((UInt32)CellFormats.ChildElements.Count - 1),
                };

                headerRow.Append(cell);
            }
            sheetData.InsertAt(headerRow, 0);
        }

        private void AddSheetData(SheetData sheetData, List<IGridColumnDefinition> gridColumnDefinitions, IList<IFoundationModel> sourceData)
        {
            if (sourceData.HasItems())
            {
                foreach (IFoundationModel foundationModel in sourceData)
                {
                    Row row = new Row();

                    foreach (IGridColumnDefinition gridColumnDefinition in gridColumnDefinitions)
                    {
                        Object propertyValue = foundationModel.GetPropertyValue(gridColumnDefinition.DataMemberName) ?? String.Empty;
                        Cell cell = ConvertDotNetValueToSpreadsheetValue(propertyValue, gridColumnDefinition);
                        row.Append(cell);
                    }

                    sheetData.Append(row);
                }
            }
        }
    }
}