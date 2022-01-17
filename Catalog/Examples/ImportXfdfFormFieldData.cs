//
//  Copyright © 2020-2021 PSPDFKit GmbH. All rights reserved.
//
//  The PSPDFKit Sample applications are licensed with a modified BSD license.
//  Please see License for details. This notice may not be removed from this file.
//

using System;
using System.IO;
using System.Xml.Linq;
using Catalog.Examples.Helper;
using PSPDFKit;
using PSPDFKit.Providers;

namespace Catalog.Examples
{
    /// <summary>
    /// Import form field values as XFDF and apply the values to a PDF. The form field names and values could be data
    /// driven from some other data source. We output the XML document to a stream and use a
    /// <see cref="StreamDataProvider"/> to provide the data to PSPDFKit. Finally we save the document to apply the data
    /// to the document.
    /// </summary>
    public class ImportXfdfFormFieldData : IExample
    {
        public void ExampleOperation(Options options)
        {
            // Create the structure of the XML document with first and last name fields.
            XNamespace xfdfNamespace = "http://ns.adobe.com/xfdf/";
            var xml = new XElement(xfdfNamespace + "xfdf",
                new XElement("fields",
                    new XElement("field", new XAttribute("name", "Name_First"), new XElement("value", "John")),
                    new XElement("field", new XAttribute("name", "Name_Last"), new XElement("value", "Smith"))
                )
            );

            // Write out the XML document to a stream ready for importing.
            using var memStream = new MemoryStream();
            xml.Save(memStream);

            // Open a copy of the form document.
            var tempPath = Path.Combine(Path.GetTempPath(), "formDocument.pdf");
            File.Copy(DocumentHelper.GetAssetPath("formDocument.pdf"), tempPath, true);
            var document = new Document(new FileDataProvider(tempPath));
            document.ImportXfdf(new StreamDataProvider(memStream));

            // Save the document with the form fields applied.
            document.Save(new DocumentSaveOptions());

            Console.Write("Note the first name and last name of the form have been filled. \"" + tempPath + "\"");
        }
    }
}
