//
//  Copyright © 2019-2021 PSPDFKit GmbH. All rights reserved.
//
//  The PSPDFKit Sample applications are licensed with a modified BSD license.
//  Please see License for details. This notice may not be removed from this file.
//

using System.IO;
using Catalog.Examples.Helper;
using PSPDFKit.Providers;

namespace Catalog.Examples
{
    /// <summary>
    /// An example to show how to export JSON.
    /// </summary>
    public class ExportJson : IExample
    {
        /// <inheritdoc/>
        public void ExampleOperation(Options options)
        {
            var document = DocumentHelper.OpenDocumentAndAnnotation();
            var filename = Path.GetTempPath() + "instantOutput.json";
            File.Create(filename).Close(); // Create the file and close it to ensure it is not used by this process.
            document.ExportDocumentJson(new FileDataProvider(filename));
        }
    }
}
