using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question842
    {
        public static void EntryPoint()
        {
            (new Question842()).SplitIntoFibonacci("11235813");
        }

        public IList<int> SplitIntoFibonacci(string S)
        {
            for (int i = 0; i < Math.Min(10, S.Length); ++i)
            {
                if (S[0] == '0' && i > 0)
                    break;

                long a = Convert.ToInt64(S.Substring(0, i + 1));
                if (a >= int.MaxValue)
                    break;

                for (int j = i + 1; j < Math.Min(i + 10, S.Length); ++j)
                {
                    if (S[i + 1] == '0' && j > i + 1)
                        break;

                    long b = Convert.ToInt64(S.Substring(i + 1, j - i));
                    if (b >= int.MaxValue)
                        break;

                    List<int> fib = new List<int>();
                    fib.Add((int)a);
                    fib.Add((int)b);

                    int k = j + 1;
                    while (k < S.Length)
                    {
                        long nxt = fib[fib.Count - 2] + fib[fib.Count - 1];
                        String nxtS = nxt.ToString();

                        if (nxt <= int.MaxValue && S.Substring(k).StartsWith(nxtS))
                        {
                            k += nxtS.Length;
                            fib.Add((int)nxt);
                        }
                        else
                            break;
                    }

                    if (k != S.Length)
                        continue;

                    if (fib.Count >= 3)
                        return fib;
                }
            }

            return new List<int>();
        }
    }
}
