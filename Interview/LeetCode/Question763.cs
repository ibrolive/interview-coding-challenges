using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question763
    {
        public IList<int> PartitionLabels(string S)
        {
            Hashtable hashtable = new Hashtable();
            int leftIndex = 0,
                rightIndex = -1;
            List<int> result = new List<int>(),
                      tempList = null;

            for (int i = 0; i < S.Length; i++)
            {
                if (!hashtable.ContainsKey(S[i]))
                    hashtable.Add(S[i], new List<int>());

                ((List<int>)hashtable[S[i]]).Add(i);
            }

            do
            {
                leftIndex = ++rightIndex;
                tempList = (List<int>)hashtable[S[leftIndex]];
                rightIndex = tempList[tempList.Count - 1];

                for (int i = 0; i < hashtable.Count; i++)
                    foreach (var key in hashtable.Keys)
                        if ((char)key != S[leftIndex] &&
                            (char)key != S[rightIndex])
                        {
                            tempList = (List<int>)hashtable[key];

                            if (leftIndex < tempList[0] &&
                                rightIndex > tempList[0] &&
                                rightIndex < tempList[tempList.Count - 1])
                            {
                                rightIndex = tempList[tempList.Count - 1];
                                break;
                            }
                        }

                result.Add(rightIndex - leftIndex + 1);
            }
            while (rightIndex + 1 < S.Length);

            return result;
        }
    }
}
