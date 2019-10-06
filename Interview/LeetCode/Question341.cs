using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question341
    {
    }

    public class NestedIterator
    {
        Queue<int> queue = new Queue<int>();

        public NestedIterator(IList<NestedInteger> nestedList)
        {
            foreach (var item in nestedList)
                Helper(item, queue);
        }

        public bool HasNext()
        {
            return queue.Count != 0;
        }

        public int Next()
        {
            if (queue.Count != 0)
                return queue.Dequeue();

            return Int32.MinValue;
        }

        private void Helper(NestedInteger integer, Queue<int> previous)
        {
            if (integer.IsInteger())
                previous.Enqueue(integer.GetInteger());
            else
                foreach (var item in integer.GetList())
                    Helper(item, previous);
        }

        public interface NestedInteger
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
}
