//
//  Copyright © 2019-2021 PSPDFKit GmbH. All rights reserved.
//
//  The PSPDFKit Sample applications are licensed with a modified BSD license.
//  Please see License for details. This notice may not be removed from this file.
//

using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Catalog.Examples.Helper;
using PSPDFKit;
using PSPDFKit.Basic;
using PSPDFKit.Providers;
using PSPDFKitFoundation;

namespace Catalog.Examples
{
    public class DocumentEditorExample : IExample
    {
        public void ExampleOperation(Options options)
        {
            var document = DocumentHelper.GetDefaultDocument();
            var documentEditor = document.CreateDocumentEditor();

            // Add a new page.
            documentEditor.AddPage(0, DocumentEditor.IndexPosition.BeforeIndex, 200, 200,
                Rotation.Degrees90, Color.Black, new Insets(0, 0, 0, 0));

            // Duplicate the added page.
            documentEditor.DuplicatePages(new List<int> {0});

            // Rotate a page.
            documentEditor.RotatePages(new List<int> {4}, Rotation.Degrees270);

            // Export the document to a file path.
            const string filename = "documentEditorOutput.pdf";
            File.Create(filename).Close(); // Create the file and close it to ensure it is not used by this process.
            documentEditor.SaveDocument(new FileDataProvider(filename));
        }
    }
}
