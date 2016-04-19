using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using static System.Console;

namespace LanguageToMemrise
{    
    class Program
    {
        [STAThread] // Because of the System.Windows.Forms.Clipboard.
        static void Main(string[] args)
        {
            var commandLineParser = new CommandLineParser(args);

            // Parse command line.
            ConvertSettings commandLineArguments;
            string errorMessage;
            if (!commandLineParser.TryParse(out commandLineArguments, out errorMessage))
            {
                PrintUsageMessage(errorMessage);
                return;
            }

            // Get the entries that has to be converted.
            IEnumerable<string> entriesToConvert;
            try
            {
                entriesToConvert = new LanguageFileReader(commandLineArguments).GetEntriesToConvert();
            }
            catch(Exception e)
            {
                PrintErrorMessage("En error occured while reading the language file:");
                PrintErrorMessage(e.Message);
                return;
            }

            if (entriesToConvert.Count() <= 0)
            {
                PrintWarningMessage("The language file is either empty or does not contain entries for the provided starting date.");
                PrintWarningMessage("Nothing is copied to the clipboard.");
                return;
            }

            // Convert them.
            ConversionResult conversionResult = new Converter(entriesToConvert).Convert();

            if (conversionResult.HasInvalidEntries)
            {
                PrintWarningMessage($"The language file contains the following invalid entries:{Environment.NewLine}");
                PrintWarningMessage(string.Join(Environment.NewLine, conversionResult.InvalidEntries));
                PrintWarningMessage($"{Environment.NewLine}Fix the invalid entries and start the converter again.");
                PrintWarningMessage("Nothing is copied to the clipboard.");
                return;
            }

            Clipboard.SetText(string.Join(Environment.NewLine, conversionResult.ConvertedEntries));
            WriteLine($"{conversionResult.ConvertedEntries.Count()} entries successfully converted and copied to clipboard.");
        }

        static void PrintUsageMessage(string errorMessage)
        {
            if (errorMessage == null)
                throw new ArgumentNullException(nameof(errorMessage));

            var assembly = Assembly.GetExecutingAssembly();
            var executableFileName = Path.GetFileNameWithoutExtension(assembly.Location);

            WriteLine(@"                   _   .-')    ");
            WriteLine(@"                  ( '.( OO )_  ");
            WriteLine(@" ,--.      .-----. ,--.   ,--.)");
            WriteLine(@" |  |.-') / ,-.   \|   `.'   | ");
            WriteLine(@" |  | OO )'-'  |  ||         | ");
            WriteLine(@" |  |`-' |   .'  / |  |'.'|  | ");
            WriteLine(@"(|  '---.' .'  /__ |  |   |  | ");
            WriteLine(@" |      | |       ||  |   |  | ");
            WriteLine(@" `------' `-------'`--'   `--' ");

            WriteLine();
            WriteLine(assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title);
            WriteLine(assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description);            

            if (errorMessage != string.Empty)
            {
                WriteLine();
                PrintErrorMessage(errorMessage);
            }

            WriteLine();
            WriteLine("Usage:");
            WriteLine($"    {executableFileName} <language file name> [<starting date>]");
            WriteLine();
            WriteLine("Example usage:");
            WriteLine($"    {executableFileName} English.txt 2016.04.17");
            WriteLine($"    {executableFileName} English.txt");
            WriteLine($@"    {executableFileName} ""C:\My Languages\English.txt"" 2016.04.17");
        }

        static void PrintErrorMessage(string errorMessage)
        {
            PrintMessage(errorMessage, ConsoleColor.Red);
        }

        static void PrintWarningMessage(string warningMessage)
        {
            PrintMessage(warningMessage, ConsoleColor.Yellow);
        }

        static void PrintMessage(string errorMessage, ConsoleColor consoleColor)
        {
            var currentForegroundColor = ForegroundColor;
            ForegroundColor = consoleColor;
            WriteLine(errorMessage);
            ForegroundColor = currentForegroundColor;
        }
    }
}