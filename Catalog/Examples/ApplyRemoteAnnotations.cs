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
    /// Applying a json file which may have been send from a remote client.
    /// For more information on Instant Document JSON see,
    /// https://pspdfkit.com/guides/web/current/importing-exporting/instant-json/
    /// </summary>
    public class ApplyRemoteAnnotations : IExample
    {
        public void ExampleOperation(Options options)
        {
            // Open the document to apply the Instant Document JSON to.
            var document = DocumentHelper.GetDefaultDocument();

            // Open the Instant document JSON and apply to the document.
            document.ImportDocumentJson(new FileDataProvider(DocumentHelper.GetAssetPath("instant.json")));
        }
    }
}
