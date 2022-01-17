//
//  Copyright © 2019-2021 PSPDFKit GmbH. All rights reserved.
//
//  The PSPDFKit Sample applications are licensed with a modified BSD license.
//  Please see License for details. This notice may not be removed from this file.
//

using System;
using Catalog.Examples.Helper;

namespace Catalog.Examples
{
    /// <summary>
    /// An example to show how to read all the annotations from a page.
    /// </summary>
    public class ReadAnnotations : IExample
    {
        /// <inheritdoc/>
        public void ExampleOperation(Options options)
        {
            var document = DocumentHelper.GetDefaultDocument();
            var annotations = document.GetAnnotationProvider().GetAnnotationsJson(2);

            Console.Write(annotations.ToString().Substring(0, 200) + "\n...\n");
        }
    }
}
