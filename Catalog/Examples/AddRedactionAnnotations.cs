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
    /// Adds redaction annotations for strings found with a regular express pattern, but does not apply them. This can
    /// be useful when human auditing is needed or further processing is required.
    /// </summary>
    public class AddRedactionAnnotations : IExample
    {
        /// <inheritdoc/>
        public void ExampleOperation(Options options)
        {
            const string stringToRedact = "e-book";
            var document = DocumentHelper.GetDefaultDocument();

            // Create a redaction processor and add a regex pattern to use for adding redaction annotations.
            RedactionProcessor.Create()
                .AddRedactionTemplates(new[] {new RedactionRegEx {Pattern = stringToRedact}})
                .IdentifyAndAddRedactionAnnotations(document);

            // Save the newly created redaction annotations to a new destination without applying them.
            var documentPath = Path.Combine(Path.GetTempPath(), "default.pdf");
            document.SaveAs(new FileDataProvider(documentPath),
                new DocumentSaveOptions {applyRedactionAnnotations = false});

            Console.WriteLine("Note that all instances of \"" + stringToRedact + "\" in " + documentPath +
                              " outlined with " +
                              "a red box. This denotes a redaction annotation is staged");
        }
    }
}
