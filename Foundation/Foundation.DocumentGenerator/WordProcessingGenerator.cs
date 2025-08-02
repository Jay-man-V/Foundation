//-----------------------------------------------------------------------
// <copyright file="WordProcessingDocumentGenerator.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;

using Word = DocumentFormat.OpenXml.Wordprocessing;

using Foundation.Interfaces;

namespace Foundation.DocumentGenerator
{
    /// <summary>
    /// The Document Generator
    /// https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk
    /// </summary>
    [DependencyInjectionTransient]
    public class WordProcessingGenerator
    {
        /// <summary>
        /// Tests this instance.
        /// </summary>
        public void Test_WordDocument()
        {
            String filePath = @"D:\sample.docx";

            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainDocumentPart = wordDocument.AddMainDocumentPart();

                Word.Text text = new Word.Text("Create text in body - Create Word processing Document");
                Word.Run run = new Word.Run(text);
                Paragraph paragraph = new Paragraph(run);
                Word.Body body = new Word.Body(paragraph);
                Word.Document document = new Word.Document(body);
                mainDocumentPart.Document = document;
            }
        }
    }
}