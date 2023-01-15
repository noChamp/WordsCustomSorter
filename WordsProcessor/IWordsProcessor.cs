using System.Collections.Generic;

namespace WordsProcessor
{
    public interface IWordsProcessor
    {
        string Process(List<string> words);
    }
}