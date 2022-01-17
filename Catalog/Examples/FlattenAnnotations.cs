using System;
using System.IO;
using Catalog.Examples.Helper;
using PSPDFKit;
using PSPDFKit.Providers;

namespace Catalog.Examples
{
    /// <summary>
    /// Flatten all the annotations in the document so they are no longer editable.
    /// </summary>
    public class FlattenAnnotations : IExample
    {
        public void ExampleOperation(Options options)
        {
            var tempPath = Path.Combine(Path.GetTempPath(), "formDocument.pdf");
            File.Copy(DocumentHelper.GetAssetPath("formDocument.pdf"), tempPath, true);

            // Open the document.
            var document = new Document(new FileDataProvider(tempPath));

            // Save and flatten the annotations in the document.
            document.Save(new DocumentSaveOptions
            {
                flattenAnnotations = true
            });

            Console.Write("Note that all the annotations on page 3 of " + tempPath + " are flattened.\n");
        }
    }
}
