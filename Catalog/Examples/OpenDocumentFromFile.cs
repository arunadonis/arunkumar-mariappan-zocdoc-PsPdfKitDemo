//
//  Copyright © 2019-2021 PSPDFKit GmbH. All rights reserved.
//
//  The PSPDFKit Sample applications are licensed with a modified BSD license.
//  Please see License for details. This notice may not be removed from this file.
//

using Catalog.Examples.Helper;
using PSPDFKit.Providers;

namespace Catalog.Examples
{
    /// <summary>
    /// An example to show how to open a document.
    /// </summary>
    public class OpenDocumentFromFile : IExample
    {
        /// <inheritdoc/>
        public void ExampleOperation(Options options)
        {
            var document = new PSPDFKit.Document(new FileDataProvider(DocumentHelper.GetAssetPath("default.pdf")));
        }
    }
}
