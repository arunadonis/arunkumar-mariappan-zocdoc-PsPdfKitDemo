//
//  Copyright © 2019-2021 PSPDFKit GmbH. All rights reserved.
//
//  The PSPDFKit Sample applications are licensed with a modified BSD license.
//  Please see License for details. This notice may not be removed from this file.
//

using Catalog.Examples.Helper;
using Newtonsoft.Json.Linq;

namespace Catalog.Examples
{
    /// <summary>
    /// An example to show how to add an annotation.
    /// </summary>
    public class AddAnnotation : IExample
    {
        /// <inheritdoc/>
        public void ExampleOperation(Options options)
        {
            var document = DocumentHelper.GetDefaultDocument();
            var annotationJson = new JObject
            {
                {"backgroundColor", "#FF0000"},
                {"bbox", new JArray(10, 10, 400, 400)},
                {"creatorName", "Me"},
                {"createdAt", "2018-08-21T14:35:51Z"},
                {"font", "Helvetica"},
                {"fontColor", "#000000"},
                {"fontSize", 72},
                {"fontStyle", new JArray("bold", "italic")},
                {"horizontalAlign", "right"},
                {"id", "01CNEEM7FQCYTBG209AVEMAPKG"},
                {"isFitting", true},
                {"name", "01CNEEKKS2JVPPAEDPKVBYBF65"},
                {"opacity", 1},
                {"pageIndex", 0},
                {"text", "A new text annotation"},
                {"type", "pspdfkit/text"},
                {"updatedAt", "2018-08-21T14:35:51Z"},
                {"v", 1},
                {"verticalAlign", "bottom"}
            };
            document.GetAnnotationProvider().AddAnnotationJson(annotationJson);
        }
    }
}
