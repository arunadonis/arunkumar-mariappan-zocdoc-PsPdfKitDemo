//
//  Copyright © 2020-2021 PSPDFKit GmbH. All rights reserved.
//
//  The PSPDFKit Sample applications are licensed with a modified BSD license.
//  Please see License for details. This notice may not be removed from this file.
//

using System;
using System.IO;
using Catalog.Examples.Helper;
using PSPDFKit;
using PSPDFKit.Providers;
using PSPDFKit.Redaction;
using PSPDFKit.Redaction.Description;

namespace Catalog.Examples
{
    /// <summary>
    /// Takes a document and redacts every instances of "e-book" from a document.
    /// </summary>
    public class RedactStringFromDocument : IExample
    {
        /// <inheritdoc/>
        public void ExampleOperation(Options options)
        {
            const string redactionPattern = "e-book";

            // Create a copy of a document to work on.
            var documentPath = Path.Combine(Path.GetTempPath(), "default.pdf");
            File.Copy(DocumentHelper.GetAssetPath("default.pdf"), documentPath, true);
            var document = new Document(new FileDataProvider(documentPath));

            // Create a redaction processor, search and redact for all instances of "e-book".
            RedactionProcessor.Create()
                .AddRedactionTemplates(new[] {new RedactionRegEx {Pattern = redactionPattern}})
                .Redact(document);

            Console.WriteLine("Note that all instances of \"" + redactionPattern + "\" in " + documentPath + " are " +
                              "covered with a black box and have been irreversible removed from the document.");
        }
    }
}
