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
    /// An example to show how to import JSON
    /// </summary>
    public class ImportJson : IExample
    {
        /// <inheritdoc/>
        public void ExampleOperation(Options options)
        {
            var document = DocumentHelper.GetDefaultDocument();
            document.ImportDocumentJson(new FileDataProvider(DocumentHelper.GetAssetPath("instant.json")));
            //document.Save(new DocumentSaveOptions());
        }
    }
}
