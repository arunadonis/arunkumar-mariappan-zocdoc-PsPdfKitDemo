//
//  Copyright © 2020-2021 PSPDFKit GmbH. All rights reserved.
//
//  The PSPDFKit Sample applications are licensed with a modified BSD license.
//  Please see License for details. This notice may not be removed from this file.
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Catalog.Examples.Helper;
using PSPDFKit.Providers;
using PSPDFKit.Redaction;
using PSPDFKit.Redaction.Description;

namespace Catalog.Examples
{
    /// <summary>
    /// Uses data from a CSV file to create redaction templates. The redaction processor is then used to redact a document.
    /// </summary>
    public class CsvDrivenRedaction : IExample
    {
        public void ExampleOperation(Options options)
        {
            var document = DocumentHelper.GetDocument(DocumentHelper.GetAssetPath("personal-letter.pdf"));
            var redactionData = ReadCsvData(DocumentHelper.GetAssetPath("personal-data.csv"));
            var destinationFilePath = Path.GetTempPath() + Guid.NewGuid() + ".pdf";
            var redactionTemplates = new List<RedactionTemplate>();

            // Populate the redaction templates.
            foreach (var redaction in redactionData)
            {
                redactionTemplates.Add(new RedactionRegEx {Pattern = redaction});
            }

            // Based on the templates created from the CSV file, redact the data and save out to a temporary path.
            RedactionProcessor.Create()
                .AddRedactionTemplates(redactionTemplates)
                .Redact(document, new FileDataProvider(destinationFilePath));

            Console.WriteLine("Personal data set in personal-data.csv has been redacted from " + destinationFilePath);
        }

        /// <summary>
        /// Takes a CSV file and returns each value in a <see cref="IEnumerable{T}"/> set.
        /// </summary>
        /// <param name="csvFilePath">The CSV file to parse.</param>
        /// <returns>A list of values read.</returns>
        private static IEnumerable<string> ReadCsvData(string csvFilePath)
        {
            var csvValues = new List<string>();

            foreach (var row in File.ReadAllLines(csvFilePath, Encoding.Default).ToList())
            {
                csvValues.AddRange(row.Split(','));
            }

            return csvValues;
        }
    }
}
