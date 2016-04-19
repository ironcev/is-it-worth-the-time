using System;
using System.IO;

namespace LanguageToMemrise
{
    class CommandLineParser
    {
        private readonly string[] _commandLineArguments;

        public CommandLineParser(string[] commandLineArguments)
        {
            if (commandLineArguments == null)
                throw new ArgumentNullException(nameof(commandLineArguments));

            _commandLineArguments = commandLineArguments;
        }

        // A quick and easy way to get the settings and simple error report.
        public bool TryParse(out ConvertSettings convertSettings, out string errorMessage)
        {
            if (_commandLineArguments.Length == 0)
            {
                convertSettings = null;
                errorMessage = string.Empty;
                return false;
            }

            if (_commandLineArguments.Length > 2)
            {
                convertSettings = null;
                errorMessage = "Invalid number of command line arguments.";
                return false;
            }

            string languageFileName = _commandLineArguments[0];
            if (!ConvertSettings.IsValidLanguageFileName(languageFileName))
            {
                convertSettings = null;
                errorMessage = $"The language file '{languageFileName}' is not a valid file name.";
                return false;
            }

            // Let's do this check here as well.
            if (!File.Exists(languageFileName))
            {
                convertSettings = null;
                errorMessage = $"The language file '{languageFileName}' does not exist.";
                return false;
            }

            string startingDate;
            if (_commandLineArguments.Length == 2)
            {
                startingDate = _commandLineArguments[1];
                if (!ConvertSettings.IsValidStartingDate(startingDate))
                {
                    convertSettings = null;
                    errorMessage = $"The starting date '{startingDate}' is not a valid starting date.";
                    return false;
                }
            }
            else
            {
                startingDate = DateTime.Today.ToString("yyyy.MM.dd");
            }

            convertSettings = new ConvertSettings(languageFileName, startingDate);
            errorMessage = null;
            return true;
        }
    }
}