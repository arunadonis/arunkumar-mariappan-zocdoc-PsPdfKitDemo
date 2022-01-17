//
//  Copyright © 2019-2021 PSPDFKit GmbH. All rights reserved.
//
//  The PSPDFKit Sample applications are licensed with a modified BSD license.
//  Please see License for details. This notice may not be removed from this file.
//

using System;
using System.IO;
using Catalog.Examples.Helper;
using PSPDFKit;
using PSPDFKit.Providers;

namespace Catalog.Examples
{
    /// <summary>
    /// Applying a json file containing redaction annotations and saving the result back to the same file.
    /// For more information on Instant Document JSON see,
    /// https://pspdfkit.com/guides/server/current/server-api/json-format/?search=format#pspdfkit/markup/redaction
    /// </summary>
    public class ApplyRedactionsFromInstantJson : IExample
    {
        public void ExampleOperation(Options options)
        {
            var tempPath = Path.Combine(Path.GetTempPath(), "default.pdf");
            File.Copy(DocumentHelper.GetAssetPath("default.pdf"), tempPath, true);

            // Open the document.
            var document = new Document(new FileDataProvider(tempPath));

            // Open and import the redaction annotations from the Instant Document JSON.
            document.ImportDocumentJson(new FileDataProvider(DocumentHelper.GetAssetPath("redaction.json")));

            // Save the document with the redaction annotations applied.
            document.Save(new DocumentSaveOptions
            {
                applyRedactionAnnotations = true,
            });

            Console.Write("Redacted document written to " + tempPath + "\n");
        }
    }
}
