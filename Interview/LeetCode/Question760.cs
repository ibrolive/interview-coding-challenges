using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    class Question760
    {
        public static void EntryPoint()
        {
            (new Question760()).AnagramMappings(new int[] { 84, 46 }, new int[] { 84, 46 });
        }

        public int[] AnagramMappings(int[] A, int[] B)
        {
            if (A == null || B == null || A.Length == 0 || B.Length == 0)
                return null;

            Hashtable hash = new Hashtable();
            List<int> tempList = null;
            int[] result = new int[A.Length];

            for (int i = 0; i < B.Length; i++)
                if (hash.Contains(B[i]))
                    ((List<int>)hash[B[i]]).Add(i);
                else
                {
                    tempList = new List<int>();
                    tempList.Add(i);
                    hash.Add(B[i], tempList);
                }

            for (int i = 0; i < A.Length; i++)
            {
                result[i] = ((List<int>)hash[A[i]])[0];
                ((List<int>)hash[A[i]]).Remove(0);
            }

            return result;
        }
    }
}