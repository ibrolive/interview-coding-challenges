using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question901
    {
    }

    public class StockSpanner
    {
        private Stack<int> _stack = new Stack<int>(),
                           _weight = new Stack<int>();

        public StockSpanner()
        {

        }

        public int Next(int price)
        {
            int weight = 1;

            while (_stack.Count > 0 && _stack.Peek() <= price)
            {
                _stack.Pop();
                weight += _weight.Pop();
            }

            _stack.Push(price);
            _weight.Push(weight);

            return weight;
        }
    }
}
