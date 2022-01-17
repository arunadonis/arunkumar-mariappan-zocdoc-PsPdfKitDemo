//
//  Copyright © 2020-2021 PSPDFKit GmbH. All rights reserved.
//
//  The PSPDFKit Sample applications are licensed with a modified BSD license.
//  Please see License for details. This notice may not be removed from this file.
//

using Catalog.Examples.Helper;
using Newtonsoft.Json.Linq;
using PSPDFKit;
using PSPDFKit.Providers;
using System;
using System.IO;

namespace Catalog.Examples
{
    /// <summary>
    /// Import form field values as a JSON key to value mapping. Values can be `null`, a `String`, or a `JSONArray` of
    /// `String`s. Finally we save the document to apply the data to the document.
    /// </summary>
    public class MyExample : IExample
    {
        public void ExampleOperation(Options options)
        {
            // Open a copy of the form document.
            var tempPath = Path.Combine(Path.GetTempPath(), "formDocument.pdf");
            File.Copy(DocumentHelper.GetAssetPath("formDocument.pdf"), tempPath, true);
            var document = new Document(new FileDataProvider(tempPath));

            // Construct the key value form fields and set on the document.
            var valuesToSet = new JObject { 
                { "Name_First", "John" }, 
                { "Name_Last", "Smith" }, 
                { "Name_Middle", "Doe" },
                { "Name_Suffix", "M.B.B.S"},
                { "Name_Prefix", "Dr."},
                { "Telephone_Home", "+351 912 868 018"},
                { "Telephone_Work", "+351 912 868 018"},
                { "Sex", "MALE"},
                //{ "Singature", "Test"}
            };
            document.GetFormProvider().SetFormFieldValuesJson(valuesToSet);
            // Save the document with the form fields applied.
            document.Save(new DocumentSaveOptions
            {
                flattenAnnotations = true
            });
            Console.WriteLine("Note the first name and last name of the form have been filled. \"" + tempPath + "\"");
        }
    }
}
