//
//  Copyright © 2019-2021 PSPDFKit GmbH. All rights reserved.
//
//  The PSPDFKit Sample applications are licensed with a modified BSD license.
//  Please see License for details. This notice may not be removed from this file.
//

using System.IO;
using Catalog.Examples.Helper;
using PSPDFKit;
using PSPDFKit.Providers;

namespace Catalog.Examples
{
    /// <summary>
    /// How to apply a watermark to all pages in a document.
    /// </summary>
    public class AddingACoverPage : IExample
    {
        public void ExampleOperation(Options options)
        {
            // Open a document to append a cover page to and create a document editor from this.
            var document = DocumentHelper.GetDefaultDocument();
            var documentEditor = document.CreateDocumentEditor();

            // Prepend the document with the cover page.
            documentEditor.ImportDocument(0, DocumentEditor.IndexPosition.BeforeIndex,
                new FileDataProvider(DocumentHelper.GetAssetPath("coverPage.pdf")));

            // Save the document to an output file.
            const string filename = "documentWithCoverPage.pdf";
            File.Create(filename).Close(); // Create the file and close it to ensure it is not used by this process.
            documentEditor.SaveDocument(new FileDataProvider(filename));
        }
    }
}
