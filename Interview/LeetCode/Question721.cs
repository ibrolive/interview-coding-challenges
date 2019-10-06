using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question721
    {
        // https://leetcode.com/problems/accounts-merge/solution/
        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            DisjointSet set = new DisjointSet();
            Dictionary<String, String> emailToName = new Dictionary<string, string>();
            Dictionary<String, int> emailToID = new Dictionary<string, int>();
            int id = 0;

            foreach (var account in accounts)
            {
                String name = "";

                foreach (var email in account)
                {
                    if (name == "")
                    {
                        name = email;
                        continue;
                    }

                    if (!emailToName.Keys.Contains(email))
                        emailToName.Add(email, name);

                    if (!emailToID.Keys.Contains(email))
                        emailToID.Add(email, id++);

                    set.union(emailToID[account[1]], emailToID[email]);
                }
            }

            Dictionary<int, List<String>> ans = new Dictionary<int, List<string>>();

            foreach (var email in emailToName.Keys)
            {
                int index = set.find(emailToID[email]);

                if (!ans.Keys.Contains(index))
                    ans.Add(index, new List<string>());

                ans[index].Add(email);
            }

            foreach (var component in ans.Values)
            {
                component.Sort(string.CompareOrdinal);

                component.Insert(0, emailToName[component[0]]);
            }

            return ans.Values.ToList<IList<string>>();
        }

        public class DisjointSet
        {
            private int[] parent;

            public DisjointSet()
            {
                parent = new int[10001];

                for (int i = 0; i <= 10000; ++i)
                    parent[i] = i;
            }
            public int find(int x)
            {
                if (parent[x] != x)
                    parent[x] = find(parent[x]);

                return parent[x];
            }

            public void union(int x, int y)
            {
                parent[find(x)] = find(y);
            }
        }
    }
}
