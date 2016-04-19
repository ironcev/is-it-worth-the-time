using System.Runtime.CompilerServices;

namespace LanguageToMemrise
{
    static class StartingDateHelper
    {
        public static readonly int StartingDateStringLength = "yyyy.MM.dd".Length;

        public static bool TextStartsWithValidStartingDate(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;
            if (text.Length < StartingDateStringLength) return false;

            // No Regex. Let's pretend we have to do it super fast :-)
            // No complications so far. E.g. 1234.56.78 will be considered a valid starting date.
            return
                char.IsDigit(text[0]) &&
                char.IsDigit(text[1]) &&
                char.IsDigit(text[2]) &&
                char.IsDigit(text[3]) &&
                text[4] == '.' &&
                char.IsDigit(text[5]) &&
                char.IsDigit(text[6]) &&
                text[7] == '.' &&
                char.IsDigit(text[8]) &&
                char.IsDigit(text[9]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsValidStartingDate(string startingDate)
        {
            return TextStartsWithValidStartingDate(startingDate) && startingDate.Length == StartingDateStringLength;
        }
    }
}
