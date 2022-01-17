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
    /// An example to show how to save a document.
    /// </summary>
    public class SaveDocument : IExample
    {
        /// <inheritdoc/>
        public void ExampleOperation(Options options)
        {
            var tempPath = Path.Combine(Path.GetTempPath(), "default.pdf");
            var document = new Document(new FileDataProvider(DocumentHelper.GetAssetPath("default.pdf")));

            // Save to a new location.
            document.SaveAs(new FileDataProvider(tempPath), new DocumentSaveOptions());

            var temporaryDocument = new Document(new FileDataProvider(tempPath));

            // Save back to the same DataProvider.
            temporaryDocument.Save(new DocumentSaveOptions());
        }
    }
}
