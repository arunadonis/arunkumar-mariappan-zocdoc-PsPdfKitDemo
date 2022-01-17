using System.Drawing.Imaging;
using Catalog.Examples.Helper;
using PSPDFKit;
using PSPDFKit.Providers;

namespace Catalog.Examples
{
    /// <summary>
    /// Loop through all the pages in a document and save a thumbnail render of each to a PNG.
    /// </summary>
    public class ThumbnailRender : IExample
    {
        public void ExampleOperation(Options options)
        {
            // Open a document to append a cover page to and create a document editor from this.
            var document = DocumentHelper.GetDefaultDocument();

            for (uint i = 0; i < document.GetPageCount(); i++) {
                // Render a thumbnail for each page.
                var page = document.GetPage(i);
                var bitmap = page.RenderPage(120, 170);

                // Write the render out to a PNG.
                bitmap.Save("page" + i + ".pdf", ImageFormat.Png);
            }
        }
    }
}
