using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsProcessor
{
    public interface IWordsSanitizer
    {
        List<string> Sanitize(string input);
    }
}
