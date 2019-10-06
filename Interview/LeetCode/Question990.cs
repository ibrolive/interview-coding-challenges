using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question990
    {
        // https://leetcode.com/problems/satisfiability-of-equality-equations/discuss/234486/JavaC++Python-Easy-Union-Find
        private int[] uf = new int[26];

        public bool EquationsPossible(string[] equations)
        {
            for (int i = 0; i < 26; ++i)
                uf[i] = i;

            foreach (var e in equations)
                if (e[1] == '=')
                    uf[find(e[0] - 'a')] = find(e[3] - 'a');

            foreach (var e in equations)
                if (e[1] == '!' && find(e[0] - 'a') == find(e[3] - 'a'))
                    return false;

            return true;
        }

        public int find(int x)
        {
            if (x != uf[x])
                uf[x] = find(uf[x]);

            return uf[x];
        }
    }
}
