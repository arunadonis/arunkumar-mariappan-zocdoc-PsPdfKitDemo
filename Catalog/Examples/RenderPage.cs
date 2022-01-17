//
//  Copyright © 2019-2021 PSPDFKit GmbH. All rights reserved.
//
//  The PSPDFKit Sample applications are licensed with a modified BSD license.
//  Please see License for details. This notice may not be removed from this file.
//

using Catalog.Examples.Helper;

namespace Catalog.Examples
{
    /// <summary>
    /// An example to show how to render a page from a document.
    /// </summary>
    public class RenderPage : IExample
    {
        /// <inheritdoc/>
        public void ExampleOperation(Options options)
        {
            var page = DocumentHelper.GetPage();
            var boundingBox = page.GetPageInfo().GetBoundingBox();
            var render = page.RenderPage((int) boundingBox.Width, (int) boundingBox.Height);
        }
    }
}
