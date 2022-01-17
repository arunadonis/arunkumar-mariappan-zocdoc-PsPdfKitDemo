//
//  Copyright © 2019-2021 PSPDFKit GmbH. All rights reserved.
//
//  The PSPDFKit Sample applications are licensed with a modified BSD license.
//  Please see License for details. This notice may not be removed from this file.
//

using Catalog.Examples.Helper;
using PSPDFKit;
using PSPDFKit.Providers;

namespace Catalog.Examples
{
    /// <summary>
    /// An example to show how to import XFDF.
    /// </summary>
    public class ImportXfdf : IExample
    {
        /// <inheritdoc/>
        public void ExampleOperation(Options options)
        {
            var document = DocumentHelper.GetDocument(DocumentHelper.GetAssetPath("rotatedPages.pdf"));
            document.ImportXfdf(new FileDataProvider(DocumentHelper.GetAssetPath("rotatedPage.xfdf")));
        }
    }
}
