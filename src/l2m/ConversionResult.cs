using System;
using System.Collections.Generic;
using System.Linq;

namespace LanguageToMemrise
{
    class ConversionResult
    {
        // Ah, again missing those materialized enumerables :-(
        public IEnumerable<string> InvalidEntries { get; }
        public IEnumerable<string> ConvertedEntries { get; }
        public bool HasInvalidEntries => InvalidEntries.Any();
        public ConversionResult(IEnumerable<string> invalidEntries, IEnumerable<string> convertedEntries)
        {
            if (invalidEntries == null)
                throw new ArgumentNullException(nameof(invalidEntries));
            if (convertedEntries == null)
                throw new ArgumentNullException(nameof(convertedEntries));

            InvalidEntries = invalidEntries;
            ConvertedEntries = convertedEntries;
        }
    }
}