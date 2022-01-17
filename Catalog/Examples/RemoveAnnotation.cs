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
    /// An example to show how to remove an annotation.
    /// </summary>
    public class RemoveAnnotation : IExample
    {
        /// <inheritdoc/>
        public void ExampleOperation(Options options)
        {
            var document = DocumentHelper.GetDefaultDocument();
            // Remove blue diagonal line annotation on page index 2 with ID 51.
            document.GetAnnotationProvider().RemoveAnnotation(2, 51);
        }
    }
}
