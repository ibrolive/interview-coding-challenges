using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question890
    {
        public static void EntryPoint()
        {
            (new Question890()).FindAndReplacePattern(new string[] { "abc", "deq", "mee", "aqq", "dkd", "ccc" }, "abb");
        }

        public IList<string> FindAndReplacePattern(string[] words, string pattern)
        {
            Hashtable tempHashPattern = null,
                      tempHashSource = null;
            IList<string> result = new List<string>();
            int indexSource = 0,
                indexPattern = 0;
            bool failed = false;

            foreach (var item in words)
            {
                tempHashPattern = new Hashtable();
                foreach (var character in pattern)
                    if (!tempHashPattern.Contains(character))
                        tempHashPattern.Add(character, null);

                tempHashSource = new Hashtable();
                foreach (var character in item)
                    if (!tempHashSource.Contains(character))
                        tempHashSource.Add(character, null);

                for (indexSource = 0, indexPattern = 0; indexPattern < pattern.Length && indexSource < item.Length; indexPattern++, indexSource++)
                    if ((tempHashPattern[pattern[indexPattern]] != null && (char)tempHashPattern[pattern[indexPattern]] != item[indexSource]) ||
                        (tempHashSource[item[indexSource]] != null && (char)tempHashSource[item[indexSource]] != pattern[indexPattern]))
                    {
                        failed = true;
                        break;
                    }
                    else
                    {
                        tempHashPattern[pattern[indexPattern]] = item[indexSource];
                        tempHashSource[item[indexSource]] = pattern[indexPattern];
                    }

                if (!failed)
                    result.Add(item);

                failed = false;
            }

            return result;
        }
    }
}
