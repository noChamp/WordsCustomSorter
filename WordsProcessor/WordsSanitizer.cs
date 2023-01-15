using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsProcessor
{
    public class WordsSanitizer: IWordsSanitizer
    {
        public List<string> Sanitize(string input)
        {
            if(string.IsNullOrWhiteSpace(input))
            {
                return new List<string>();
            }

            string[] words = input.Split(" ");
            List<string> sanitizedWords = new List<string>();

            foreach (string word in words)
            {
                sanitizedWords.Add(new string(word.ToCharArray().Where(c => !char.IsPunctuation(c)).ToArray()));
            }

            //in case the input was "x , y" then we are left with empty strings
            //so remove those
            sanitizedWords = sanitizedWords.Where(word => !string.IsNullOrWhiteSpace(word)).ToList();

            return sanitizedWords;
        }
    }
}
