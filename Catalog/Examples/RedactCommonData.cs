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
    /// Redacts information from a document based on a preset shape. See <see cref="RedactionPreset.Type"/> for the
    /// supported presets. (e.g. SSN, email address, Dates).
    /// </summary>
    public class RedactCommonData : IExample
    {
        /// <inheritdoc/>
        public void ExampleOperation(Options options)
        {
            // Create a copy of a document to work on.
            var documentPath = Path.Combine(Path.GetTempPath(), "playground.pdf");
            File.Copy(DocumentHelper.GetAssetPath("default.pdf"), documentPath, true);
            var document = new Document(new FileDataProvider(documentPath));

            // Create a redaction processor, search and redact for all email addresses in the document.
            RedactionProcessor.Create()
                .AddRedactionTemplates(new[] {new RedactionPreset {Preset = RedactionPreset.Type.EmailAddress}})
                .Redact(document);

            Console.WriteLine("Note on the final page of " + documentPath + " \"sales@pspdfkit.com\"" + " has been" +
                              " redacted");
        }
    }
}
