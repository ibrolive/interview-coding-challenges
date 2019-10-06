using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question339
    {
        public int DepthSum(IList<NestedInteger> nestedList)
        {
            int sum = 0;

            foreach (var item in nestedList)
                sum += GetSum(item, 1);

            return sum;
        }

        private int GetSum(NestedInteger nestedList, int weight)
        {
            int sum = 0;

            if (nestedList.IsInteger())
                sum += nestedList.GetInteger() * weight;
            else
                foreach (var item in nestedList.GetList())
                    sum += GetSum(item, weight + 1);

            return sum;
        }
    }

    public  interface NestedInteger
    {
 
      // @return true if this NestedInteger holds a single integer, rather than a nested list.
      bool IsInteger();
 
      // @return the single integer that this NestedInteger holds, if it holds a single integer
      // Return null if this NestedInteger holds a nested list
      int GetInteger();
 
      // @return the nested list that this NestedInteger holds, if it holds a nested list
      // Return null if this NestedInteger holds a single integer
      IList<NestedInteger> GetList();
  }
}