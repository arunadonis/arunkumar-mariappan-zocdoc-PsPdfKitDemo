//
//  Copyright © 2020-2021 PSPDFKit GmbH. All rights reserved.
//
//  The PSPDFKit Sample applications are licensed with a modified BSD license.
//  Please see License for details. This notice may not be removed from this file.
//

using System;
using Catalog.Examples.Helper;
using Microsoft.VisualBasic;

namespace Catalog.Examples
{
    /// <summary>
    /// An example to show how to extract all the text on a page.
    /// </summary>
    public class ExtractPageText : IExample
    {
        /// <inheritdoc/>
        public void ExampleOperation(Options options)
        {
            var document = DocumentHelper.GetDocument(DocumentHelper.GetAssetPath("personal-letter.pdf"));
            var textLines = document.GetPage(0).GetTextLines();
            String pageText = "";
            foreach (var textLine in textLines)
            {
                pageText += textLine.GetText();
                pageText += "\r\n";
            }
            Console.WriteLine("The text on the first page reads:\n" + pageText);
        }
    }
}
