using System.Text;

namespace FlexLabs.Phonetics
{
    public static class PhoneticsConverter
    {
        private static readonly Dictionary<char, string> _phoneticDictionary = new()
        {
            ['a'] = "Alpha",
            ['b'] = "Bravo",
            ['c'] = "Charlie",
            ['d'] = "Delta",
            ['e'] = "Echo",
            ['f'] = "Foxtrot",
            ['g'] = "Golf",
            ['h'] = "Hotel",
            ['i'] = "India",
            ['j'] = "Juliett",
            ['k'] = "Kilo",
            ['l'] = "Lima",
            ['m'] = "Mike",
            ['n'] = "November",
            ['o'] = "Oscar",
            ['p'] = "Papa",
            ['q'] = "Quebec",
            ['r'] = "Romeo",
            ['s'] = "Sierra",
            ['t'] = "Tango",
            ['u'] = "Uniform",
            ['v'] = "Victor",
            ['w'] = "Whiskey",
            ['x'] = "X-ray",
            ['y'] = "Yankee",
            ['z'] = "Zulu",
            ['0'] = "Zero",
            ['1'] = "One",
            ['2'] = "Two",
            ['3'] = "Three",
            ['4'] = "Four",
            ['5'] = "Five",
            ['6'] = "Six",
            ['7'] = "Seven",
            ['8'] = "Eight",
            ['9'] = "Nine",
            ['-'] = "Hyphen",
            ['.'] = "Full stop",
            [','] = "Comma",
        };

        public static string? Convert(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return default;
            }


            StringBuilder letters = new(), words = new();
            foreach (var letter in input.ToLower())
            {
                if (letters.Length != 0)
                {
                    letters.Append(' ');
                    words.Append(' ');
                }

                words.Append(_phoneticDictionary.TryGetValue(letter, out var word)
                    ? word.AsSpan()
                    : ['[', letter, ']']);
                var wordLength = word?.Length ?? 3;
                letters.Append(letter.ToString().PadLeft((int)Math.Ceiling((float)wordLength  / 2)).PadRight(wordLength));
            }

            return letters + "\n" + words.ToString();
        }
    }
}
