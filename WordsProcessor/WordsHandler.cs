using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsProcessor
{
    public class WordsHandler : IWordsHandler
    {
        private readonly IWordsSanitizer _wordsSanitizer;
        private readonly IWordsProcessor _wordsProcessor;

        public WordsHandler(IWordsSanitizer wordsSanitizer, IWordsProcessor wordsProcessor)
        {
            _wordsSanitizer = wordsSanitizer;
            _wordsProcessor = wordsProcessor;
        }
        public string Handle(string paragraph)
        {
            List<string> words = _wordsSanitizer.Sanitize(paragraph);
            string result = _wordsProcessor.Process(words);
            return result;
        }
    }
}
