using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question937
    {
        public string[] ReorderLogFiles(string[] logs)
        {
            SortedList<string, string> letterLog = new SortedList<string, string>();
            List<string> digitLogs = new List<string>(),
                         result = new List<string>();

            foreach (var item in logs)
                if (item[item.IndexOf(' ') + 1] >= 'a' && item[item.IndexOf(' ') + 1] <= 'z')
                    letterLog.Add(item.Substring(item.IndexOf(' ') + 1), item);
                else
                    digitLogs.Add(item);

            foreach (var item in letterLog)
                result.Add(item.Value);

            foreach (var item in digitLogs)
                result.Add(item);

            return result.ToArray();
        }
    }
}
