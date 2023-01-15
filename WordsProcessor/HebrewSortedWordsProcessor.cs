using System.Collections.Generic;
using System.Linq;

namespace WordsProcessor
{
    public class HebrewSortedWordsProcessor : IWordsProcessor
    {
        public string Process(List<string> words)
        {
            if(words == null || words.Count == 0)
                return string.Empty;

            words.Sort(new HebrewSortedComparer());

            return string.Join(" ", words.ToArray());
        }
    }
}