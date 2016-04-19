using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LanguageToMemrise
{
    class LanguageFileReader
    {
        private readonly ConvertSettings _convertSettings;

        public LanguageFileReader(ConvertSettings convertSettings)
        {
            if (convertSettings == null)
                throw new ArgumentNullException(nameof(convertSettings));

            _convertSettings = convertSettings;
        }

        // Materialized enumerable. Ah, would be so nice to have it...
        public IEnumerable<string> GetEntriesToConvert()
        {
            var result = new List<string>();

            var allEntries = File.ReadAllLines(_convertSettings.LanguageFileName, Encoding.UTF8);
            // We assume that the entries in the file are properly sorted.
            // So let's just pick the last ones.
            for (int i = allEntries.Length - 1; i >= 0; i--)
            {
                if (string.CompareOrdinal(allEntries[i], _convertSettings.StartingDate) < 0) break;
                result.Add(allEntries[i]);
            }

            // In normal usage there will be just a handful of them e.g. ~10.
            // Reverting the array costs nothing.
            result.Reverse();

            return result;
        }
    }
}