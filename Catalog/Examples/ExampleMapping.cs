//
//  Copyright © 2019-2021 PSPDFKit GmbH. All rights reserved.
//
//  The PSPDFKit Sample applications are licensed with a modified BSD license.
//  Please see License for details. This notice may not be removed from this file.
//

using System.Collections.Generic;

namespace Catalog.Examples
{
    public static class ExampleMapping
    {
        /// <summary>
        /// A helper to get an instance of the example from a key string.
        /// </summary>
        public static readonly Dictionary<string, IExample> StringToClass = new Dictionary<string, IExample>
        {
            //{"OpenDocumentFromFile", new OpenDocumentFromFile()},
            //{"OpenDocumentFromCustomProvider", new OpenDocumentFromCustomProvider()},
            //{"ReadAnnotations", new ReadAnnotations()},
            //{"AddAnnotation", new AddAnnotation()},
            //{"RemoveAnnotation", new RemoveAnnotation()},
            //{"ImportJson", new ImportJson()},
            //{"ExportJson", new ExportJson()},
            //{"ImportXfdf", new ImportXfdf()},
            //{"ExportXfdf", new ExportXfdf()},
            //{"RenderPage", new RenderPage()},
            //{"SaveDocument", new SaveDocument()},
            //{"DocumentEditorExample", new DocumentEditorExample()},
            //{"RedactMultipleDocuments", new RedactMultipleDocuments()},
            //{"ApplyRemoteAnnotations", new ApplyRemoteAnnotations()},
            //{"AddingACoverPage", new AddingACoverPage()},
            //{"ApplyRedactionsFromInstantJson", new ApplyRedactionsFromInstantJson()},
            //{"ThumbnailRender", new ThumbnailRender()},
            //{"FlattenAnnotations", new FlattenAnnotations()},
            //{"AddRedactionAnnotations", new AddRedactionAnnotations()},
            //{"RedactCommonData", new RedactCommonData()},
            //{"RedactStringFromDocument", new RedactStringFromDocument()},
            //{"CsvDrivenRedaction", new CsvDrivenRedaction()},
            //{"ImportXfdfFormFieldData", new ImportXfdfFormFieldData()},
            //{"ImportJsonFormFieldData", new ImportJsonFormFieldData()},
            //{"PerformOcr", new PerformOcr()},
            //{"ExtractPageText", new ExtractPageText()},
            {"MyExample", new MyExample()}
        };
    }
}
