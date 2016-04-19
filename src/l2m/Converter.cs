using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanguageToMemrise
{
    class Converter
    {
        private readonly IEnumerable<string> _entriesToConvert;

        public Converter(IEnumerable<string> entriesToConvert)
        {
            if (entriesToConvert == null)
                throw new ArgumentNullException(nameof(entriesToConvert));

            _entriesToConvert = entriesToConvert;
        }

        public ConversionResult Convert()
        {
            List<string> invalidEntries = new List<string>();
            List<string> convertedEntries = new List<string>();

            // Let's avoid unnecessary creation of temporary strings and get a single
            // string builder that will be big enough to store the largest entry.
            int largestEntryLength = _entriesToConvert.Max(entry => entry.Length);
            StringBuilder sb = new StringBuilder(largestEntryLength);

            // Let's create a primitive parser here. No regex please!
            // Intentional use of goto. To reduce the amount of code and increase readability.
            // Valid entry: yyyy.MM.dd <original text without leading or trailing spaces>|<translation without leading or trailing spaces>
            int IndexOfSpaceSeparator = StartingDateHelper.StartingDateStringLength;
            foreach (string entry in _entriesToConvert)
            {
                // The entry has to contain at least the date and the space after it: "2016.04.17 "
                if (entry.Length < StartingDateHelper.StartingDateStringLength + 1)
                    goto InvalidEntryFound;

                // The entry has to start with the date.
                if (!StartingDateHelper.TextStartsWithValidStartingDate(entry))
                    goto InvalidEntryFound;

                // After the date there must be space.
                if (entry[IndexOfSpaceSeparator] != ' ')
                    goto InvalidEntryFound;

                // The entry must not contain tabs.
                if (entry.IndexOf('\t', IndexOfSpaceSeparator + 1) > 0)
                    goto InvalidEntryFound;

                // The entry has to contain exactly one separator '|'.
                int indexOfTextSeparator = entry.IndexOf('|');
                if (indexOfTextSeparator < 0 || entry.LastIndexOf('|') != indexOfTextSeparator)
                    goto InvalidEntryFound;

                // The separator must not be the last character.
                if (indexOfTextSeparator == entry.Length - 1)
                    goto InvalidEntryFound;

                // The separator must not follow the space after the date.
                if (indexOfTextSeparator == IndexOfSpaceSeparator + 1)
                    goto InvalidEntryFound;

                // So far, we have the date, the space, and the separator with something left and right of it.
                // Now we just have to check that the text and its translation do not have leading and trailing spaces.
                if (char.IsWhiteSpace(entry[IndexOfSpaceSeparator + 1]) ||
                    char.IsWhiteSpace(entry[indexOfTextSeparator - 1]) ||
                    char.IsWhiteSpace(entry[indexOfTextSeparator + 1]) ||
                    char.IsWhiteSpace(entry[entry.Length - 1]))
                    goto InvalidEntryFound;

                // The entry is valid. Let's convert the value.
                sb.Clear();
                sb.Append(entry);
                sb.Replace('|', '\t', indexOfTextSeparator, 1);
                sb.Remove(0, StartingDateHelper.StartingDateStringLength + 1); // Remove the date and the space.                

                convertedEntries.Add(sb.ToString());    

                continue; // To skip the InvaliEntryFound label.

                InvalidEntryFound:
                    invalidEntries.Add(entry);
            }

            return new ConversionResult(invalidEntries, convertedEntries);
        }
    }
}
