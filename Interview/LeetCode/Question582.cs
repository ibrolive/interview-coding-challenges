using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question582
    {
        public IList<int> KillProcess(IList<int> pid, IList<int> ppid, int kill)
        {
            IList<int> result = new List<int>();
            Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
            Queue<int> queue = new Queue<int>();
            int temp = 0;

            foreach (var item in pid)
                dictionary.Add(item, new List<int>());

            for (int i = 0; i < ppid.Count; i++)
                if (ppid[i] != 0)
                    dictionary[ppid[i]].Add(pid[i]);

            queue.Enqueue(kill);

            while (queue.Count > 0)
            {
                temp = queue.Dequeue();

                result.Add(temp);

                if (dictionary[temp].Count > 0)
                    foreach (var item in dictionary[temp])
                        queue.Enqueue(item);
            }

            return result;
        }
    }
}
