//
//  Copyright © 2019-2021 PSPDFKit GmbH. All rights reserved.
//
//  The PSPDFKit Sample applications are licensed with a modified BSD license.
//  Please see License for details. This notice may not be removed from this file.
//

using System;
using System.Collections.Generic;
using System.IO;
using Catalog.Examples.Helper;
using PSPDFKit;
using PSPDFKit.Providers;
using PSPDFKit.Redaction;
using PSPDFKit.Redaction.Description;

namespace Catalog.Examples
{
    /// <summary>
    /// Apply the same redaction across multiple documents. This is useful if you have multiple copies of the same
    /// document but with different content. e.g The redaction of social security numbers.
    /// </summary>
    public class RedactMultipleDocuments : IExample
    {
        /// <inheritdoc/>
        public void ExampleOperation(Options options)
        {
            const string redactionPattern = "e-book";
            var filesToRedact = CreateMultipleCopies("default.pdf", 2);

            var processor = RedactionProcessor.Create()
                .AddRedactionTemplates(new[] {new RedactionRegEx {Pattern = redactionPattern}});

            // Open each file and apply redactions using a single redaction processor.
            foreach (var fileToRedact in filesToRedact)
            {
                var document = new Document(new FileDataProvider(fileToRedact));
                processor.Redact(document);
                Console.WriteLine("Note that on the first page of " + fileToRedact + " \"" + redactionPattern +
                                  "\" has been redacted.");
            }
        }

        /// <summary>
        /// Takes a file and create multiple temporary copies.
        /// </summary>
        /// <param name="filename">The file to be copied, which is located in Assets.</param>
        /// <param name="numberOfCopies">Number of copies to create.</param>
        /// <returns>An collection of temporary files.</returns>
        private static IEnumerable<string> CreateMultipleCopies(string filename, int numberOfCopies)
        {
            var files = new List<string>();
            for (var i = 0; i < numberOfCopies; i++)
            {
                var tempPath = Path.GetTempFileName() + "-" + filename;
                File.Copy(DocumentHelper.GetAssetPath(filename), tempPath, true);
                files.Add(tempPath);
            }

            return files;
        }
    }
}
