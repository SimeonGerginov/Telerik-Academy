using System;
using System.Text;
using System.Text.RegularExpressions;

namespace PeshoCode
{
    public class Startup
    {
        private const string QuestionMark = "?";
        private const string DotMark = ".";

        private static int GetSubstringSum(string substringText)
        {
            var result = 0;

            for (int j = 0; j < substringText.Length; j++)
            {
                if (substringText[j] == ' ')
                {
                    continue;
                }

                result += Char.ToUpper(substringText[j]);
            }

            return result;
        }

        private static int SumOfSymbolsInText(string[] sentences, string word)
        {
            var result = 0;

            foreach (var sentence in sentences)
            {
                var indexOfWord = sentence.IndexOf(word);
                var indexOfQuestionMark = sentence.IndexOf(QuestionMark);
                var indexOfDotMark = sentence.IndexOf(DotMark);

                if (indexOfWord != -1)
                {
                    if (indexOfQuestionMark != -1)
                    {
                        var startIndex = indexOfWord + word.Length + 1;
                        var endIndex = indexOfQuestionMark - startIndex;

                        var substringText = sentence
                            .Substring(startIndex, endIndex);

                        result += GetSubstringSum(substringText);
                    }

                    else if (indexOfDotMark != -1)
                    {
                        var startIndex = 0;
                        var endIndex = indexOfWord;

                        var substringText = sentence
                            .Substring(startIndex, endIndex);

                        result += GetSubstringSum(substringText);
                    }
                }
            }

            return result;
        }

        public static void Main()
        {
            var word = Console.ReadLine();
            var N = int.Parse(Console.ReadLine());

            var sb = new StringBuilder();

            for (int i = 0; i < N; i++)
            {
                var line = Console.ReadLine();

                sb.Append(line);
                sb.Append(" ");
            }

            var text = sb.ToString();
            var sentences = Regex.Split(text, @"(?<=[\.!\?])\s+");

            var result = SumOfSymbolsInText(sentences, word);
            Console.WriteLine(result);
        }
    }
}
