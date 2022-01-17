//
//  Copyright © 2019-2021 PSPDFKit GmbH. All rights reserved.
//
//  The PSPDFKit Sample applications are licensed with a modified BSD license.
//  Please see License for details. This notice may not be removed from this file.
//

using System.Collections.Generic;
using System.IO;
using Catalog.Examples.Helper;
using PSPDFKit.Providers;

namespace Catalog.Examples
{
    /// <summary>
    /// An example to show how to export XFDF.
    /// </summary>
    public class ExportXfdf : IExample
    {
        /// <inheritdoc/>
        public void ExampleOperation(Options options)
        {
            var document = DocumentHelper.OpenDocumentAndAnnotation();
            const string filename = "xfdfOutput.xfdf";
            File.Create(filename).Close(); // Create the file and close it to ensure it is not used by this process.
            document.ExportXfdf(new FileDataProvider(filename), new List<int>(), new List<string>());
        }
    }
}
