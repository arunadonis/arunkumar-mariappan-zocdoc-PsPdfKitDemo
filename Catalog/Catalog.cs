//
//  Copyright © 2019-2021 PSPDFKit GmbH. All rights reserved.
//
//  The PSPDFKit Sample applications are licensed with a modified BSD license.
//  Please see License for details. This notice may not be removed from this file.
//

using System;
using System.Collections.Generic;
using System.Configuration;
using Catalog.Examples;
using CommandLine;
using PSPDFKit;

namespace Catalog
{
    /// <summary>
    /// A CLI application with various examples of how to use PSPDFKit for .NET.
    /// </summary>
    internal static class Catalog
    {
        /// <summary>
        /// Main to be run on execution.
        /// </summary>
        /// <param name="args">Arguments passed in for the command line.</param>
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(RunWithOptions)
                .WithNotParsed(PrintError);
        }

        /// <summary>
        /// When argument parsing succeeds, this method will execute the requested examples.
        /// </summary>
        /// <param name="options">Parsed arguments.</param>
        private static void RunWithOptions(Options options)
        {
            var examplesToExecute = new List<IExample>();
            if (options.ExampleToRun == null)
            {
                // If no example was requested, we run them all.
                examplesToExecute.AddRange(ExampleMapping.StringToClass.Values);
            }
            else if (ExampleMapping.StringToClass.TryGetValue(options.ExampleToRun, out var exampleToExecute))
            {
                // A specific example was requested, only run that one.
                examplesToExecute.Add(exampleToExecute);
            }
            else
            {
                // The example requested was not recognised.
                Console.Write($"Could not find {options.ExampleToRun} example");
                return;
            }

            // Initialize the SDK and run all examples queued.
            Sdk.Initialize(GetSdkLicenseKey());
            foreach (var example in examplesToExecute)
            {
                Console.Write($"=== Started Running {example} example ====\n");
                example.ExampleOperation(options);
                Console.Write($"=== Finished Running {example} example ===\n");
            }
        }

        /// <summary>
        /// Reads PSPDFKitLicense from `app.config` to retrieve the license key to use.
        /// </summary>
        /// <returns>The license key as a string.</returns>
        /// <exception cref="InvalidOperationException">If the value is not found in `app.config` or a key has not been
        /// set.</exception>
        private static string GetSdkLicenseKey()
        {
            var licenseKey = ConfigurationManager.AppSettings["PSPDFKitLicense"];

            if (!licenseKey.Contains("YOUR_LICENSE_KEY_GOES_HERE")) return licenseKey;

            const string errorMessage =
                "License key has not been set. Please set `PSPDFKitLicense` in `app.config`";
            Console.Error.WriteLine(errorMessage);
            throw new ConfigurationErrorsException(errorMessage);
        }

        /// <summary>
        /// When argument parsing fails, this method will print the error.
        /// </summary>
        /// <param name="errors">Errors when parsing.</param>
        private static void PrintError(IEnumerable<Error> errors)
        {
            foreach (var error in errors) Console.Write(error);
        }
    }
}
