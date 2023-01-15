using System;
using System.Collections.Generic;
using System.Linq;

namespace WordsProcessor
{
    class HebrewSortedComparer : IComparer<string>
    {
        private char[] _hebrewOrder = new char[] { 'A', 'B', 'G', 'D', 'H', 'V', 'Z', 'J', 'T', 'Y', 'K', 'L', 'M', 'N', 'S', 'I', 'P', 'X', 'Q', 'R', 'W', 'U', 'C', 'E', 'F', 'O' };

        public int Compare(string x, string y)
        {
            char first = Char.ToUpper(x[0]);
            char second = Char.ToUpper(y[0]);

            int firstIndex = Array.IndexOf(_hebrewOrder, first);
            int secondIndex = Array.IndexOf(_hebrewOrder, second);

            return
              firstIndex == secondIndex ? Next(x, y) :
              firstIndex < secondIndex ? -1 :
              1;
        }

        private int Next(string x, string y)
        {
            string nextX = x.Substring(1);
            string nextY = y.Substring(1);

            if (nextX.Length == 0 && nextY.Length == 0)
            {
                return 0;
            }
            else if (nextX.Length == 0)
            {
                return -1;
            }
            else if (nextY.Length == 0)
            {
                return 1;
            }
            else
            {
                return Compare(nextX, nextY);
            }
        }
    }
}
