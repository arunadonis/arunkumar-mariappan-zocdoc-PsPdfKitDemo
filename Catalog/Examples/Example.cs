//
//  Copyright © 2019-2021 PSPDFKit GmbH. All rights reserved.
//
//  The PSPDFKit Sample applications are licensed with a modified BSD license.
//  Please see License for details. This notice may not be removed from this file.
//

namespace Catalog.Examples
{
    /// <summary>
    /// Each example derives from IExample so they can be executed in a uniform way. 
    /// </summary>
    public interface IExample
    {
        /// <summary>
        /// Implement this method with the sequence of code to run for the example.
        /// </summary>
        /// <param name="options">The options passed to the application.</param>
        void ExampleOperation(Options options);
    }
}
