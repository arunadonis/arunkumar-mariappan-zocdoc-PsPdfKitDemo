//
//  Copyright © 2020-2021 PSPDFKit GmbH. All rights reserved.
//
//  The PSPDFKit Sample applications are licensed with a modified BSD license.
//  Please see License for details. This notice may not be removed from this file.
//

using System;
using System.Collections.Generic;
using System.IO;
using Catalog.Examples.Helper;
using PSPDFKit;
using PSPDFKit.Basic;
using PSPDFKit.Ocr;
using PSPDFKit.Providers;

namespace Catalog.Examples
{
    /// <summary>
    /// An example to show how to perform OCR on a document with text inside an image.
    /// </summary>
    public class PerformOcr : IExample
    {
        /// <inheritdoc/>
        public void ExampleOperation(Options options)
        {
            // Fetch the OCR example document containing an image with readable text.
            var document = new Document(new FileDataProvider(DocumentHelper.GetAssetPath("ocrExample.pdf")));
            // Generate a path for the output document.
            var outputDocumentPath = Path.Combine(Path.GetTempPath(), "ocrExample.pdf");

            // Create a OCR processor using the source document, specify the language and pages,
            // and perform OCR providing an output document using the generated path.
            // NB: `Pages` can be left out to perform OCR on all pages.
            var ocrProcessor = new OcrProcessor(document)
            {
                Language = OcrLanguage.English,
                Pages = new List<int> {0}
            };
            var outputDataProvider = new FileDataProvider(outputDocumentPath);
            ocrProcessor.PerformOcr(outputDataProvider);

            Console.WriteLine("See the image from the source document has had OCR performed on it producing a document " +
                              "where text can be searched and have markup annotations applied: " + outputDocumentPath);

            // We can now get the text from the page.
            // First we need to reload the document.
            document = new Document(outputDataProvider);
            var textLines = document.GetPage(0).GetTextLines();
            // And print out some information:
            Console.WriteLine("There are " + textLines.Count + " lines of text on the page.\n" +
                              "The first line reads: \"" + textLines[0].GetText() + "\".");
        }
    }
}
