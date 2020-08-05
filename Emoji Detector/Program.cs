using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(::[A-Z][a-z]{2,}::)|(\*\*[A-Z][a-z]{2,}\*\*)";
            string text = Console.ReadLine();
            MatchCollection words = Regex.Matches(text, pattern);
            List<string> emojies = new List<string>();
            List<string> bested = new List<string>();
            int bestEmoji = words.Count;
            int cool = 1;
            foreach (Match matches in words)
            {
                emojies.Add(matches.Value);
            }
            var chars = text.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (Char.IsDigit(chars[i]))
                {
                    cool *= int.Parse(chars[i].ToString());
                }
            }
            foreach (var item in emojies)
            {
                var best = item.ToCharArray();
                int bestTreshold = 0;
                for (int i = 0; i < best.Length; i++)
                {

                    if (Char.IsLetter(best[i]))
                    {
                        bestTreshold += (int)best[i];
                    }
                }
                if (cool < bestTreshold)
                {
                    bested.Add(item);
                }
                bestTreshold = 0;
            }
            Console.WriteLine($"Cool threshold: {cool}");
            Console.WriteLine($"{bestEmoji} emojis found in the text. The cool ones are:");
            Console.WriteLine(string.Join(Environment.NewLine, bested));
        }
    }
}
