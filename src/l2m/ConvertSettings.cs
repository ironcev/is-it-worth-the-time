using System;

namespace LanguageToMemrise
{
    class ConvertSettings
    {
        public string LanguageFileName { get; }
        public string StartingDate { get; }

        public ConvertSettings(string languageFileName, string startingDate)
        {
            if (!IsValidLanguageFileName(languageFileName))
                throw new ArgumentException($"The language file name '{languageFileName}' does not represent a valid file name.", nameof(languageFileName));
            if (!IsValidStartingDate(startingDate))
                throw new ArgumentException($"The starting date '{startingDate}' is not a valid starting date. The starting date must be in the format 'yyyy.MM.dd'.", nameof(startingDate));

            LanguageFileName = languageFileName;
            StartingDate = startingDate;
        }

        public static bool IsValidStartingDate(string startingDate)
        {
            return StartingDateHelper.IsValidStartingDate(startingDate);
        }

        public static bool IsValidLanguageFileName(string languageFileName)
        {
            // There is no real support in .NET for validating if e.g. "My folder\Some file name.txt" is a valid relative file name.
            // So let's do it in a simplest way possible.
            return !string.IsNullOrWhiteSpace(languageFileName);
        }
    }
}