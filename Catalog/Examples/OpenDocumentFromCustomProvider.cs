//
//  Copyright © 2019-2021 PSPDFKit GmbH. All rights reserved.
//
//  The PSPDFKit Sample applications are licensed with a modified BSD license.
//  Please see License for details. This notice may not be removed from this file.
//

using System.Collections.Generic;
using System.IO;
using Catalog.Examples.Helper;
using PSPDFKit;
using PSPDFKit.Providers;

namespace Catalog.Examples
{
    /// <summary>
    /// An example to show how to open a document from a customer data provider.
    /// </summary>
    public class OpenDocumentFromCustomProvider : IExample
    {
        /// <inheritdoc/>
        public void ExampleOperation(Options options)
        {
            var document = new Document(new BufferDataProvider(GetPdfDataFromFile()));
        }

        /// <summary>
        /// Returns a byte[] buffer to show how a CustomProvider can work.
        /// </summary>
        /// <returns>Pdf data.</returns>
        private static byte[] GetPdfDataFromFile()
        {
            using var sourceStream = File.Open(
                DocumentHelper.GetAssetPath("default.pdf"),
                FileMode.Open,
                FileAccess.ReadWrite,
                FileShare.ReadWrite);

            var buffer = new byte[sourceStream.Length];
            sourceStream.Read(buffer, 0, (int) sourceStream.Length);
            return buffer;
        }
    }

    internal class BufferDataProvider : IDataProvider
    {
        private readonly byte[] _pdfData;

        public BufferDataProvider(byte[] pdfData)
        {
            _pdfData = pdfData;
        }

        public IEnumerable<byte> Read(long size, long offset)
        {
            var buffer = new byte[size];
            _pdfData.CopyTo(buffer, offset);
            return buffer;
        }

        public long GetSize()
        {
            return _pdfData.Length;
        }

        public string GetUid()
        {
            return _pdfData.GetHashCode().ToString();
        }
    }
}
