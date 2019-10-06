using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question524
    {
        public string FindLongestWord(string s, IList<string> d)
        {
            ((List<string>)d).Sort(new myComparer());

            foreach (string str in d)
                if (isSubsequence(str, s))
                    return str;

            return "";
        }

        public bool isSubsequence(String x, String y)
        {
            int j = 0;

            for (int i = 0; i < y.Length && j < x.Length; i++)
                if (x[j] == y[i])
                    j++;

            return j == x.Length;
        }

        public class myComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return y.Length != x.Length ? y.Length - x.Length : x.CompareTo(y);
            }
        }
    }
}
