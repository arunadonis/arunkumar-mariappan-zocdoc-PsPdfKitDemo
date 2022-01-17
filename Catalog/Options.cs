//
//  Copyright © 2019-2021 PSPDFKit GmbH. All rights reserved.
//
//  The PSPDFKit Sample applications are licensed with a modified BSD license.
//  Please see License for details. This notice may not be removed from this file.
//

using System;
using Catalog.Examples;
using CommandLine;

namespace Catalog
{
    public class Options
    {
        private string _exampleToRun;

        [Option('e', "example", Required = false,
            HelpText = "Name of example to run.")]
        public string ExampleToRun
        {
            get => _exampleToRun;
            set
            {
                if (!ExampleMapping.StringToClass.ContainsKey(value))
                    throw new ArgumentException($"Unable to find example \"{value}\"");

                _exampleToRun = value;
            }
        }
    }
}
