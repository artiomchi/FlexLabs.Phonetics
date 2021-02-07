using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexLabs.Phonetics
{
    public class PhoneticsMiddleware
    {
        private readonly RequestDelegate _next;

        public PhoneticsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

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
            ['.'] = "Decimal point",
            ['-'] = "Hyphen",
            ['.'] = "Full stop",
        };

        public async Task Invoke(HttpContext context)
        {
            string query = context.Request.Query["q"];
            if (string.IsNullOrWhiteSpace(query))
            {
                await _next.Invoke(context);
                return;
            }

            context.Response.ContentType = "text/plain";
            var lettersSets = query.ToLower().Select(c => _phoneticDictionary.TryGetValue(c, out var word) ? (c,  word) : (c, word: $"[{c}]"));
            var letters = string.Join(" ", lettersSets.Select(x => x.c.ToString().PadLeft((int)Math.Ceiling((float)x.word.Length / 2)).PadRight(x.word.Length).ToUpper()));
            var words = string.Join(" ", lettersSets.Select(x => x.word));
            await context.Response.WriteAsync(letters + "\n");
            await context.Response.WriteAsync(words);
        }
    }
}
