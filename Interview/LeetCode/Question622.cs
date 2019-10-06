using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question622
    {

    }

    public class MyCircularQueue
    {
        private int _capacity = 0;
        private Stack<int> _front = new Stack<int>(),
                           _rear = new Stack<int>();

        public MyCircularQueue(int k)
        {
            this._capacity = k;
        }

        public bool EnQueue(int value)
        {
            if (this._front.Count == this._capacity || this._rear.Count == this._capacity)
                return false;

            while (this._front.Count != 0)
                this._rear.Push(this._front.Pop());

            this._rear.Push(value);

            return true;
        }

        public bool DeQueue()
        {
            if (this._front.Count == 0 && this._rear.Count == 0)
                return false;

            while (this._rear.Count != 0)
                this._front.Push(this._rear.Pop());

            this._front.Pop();

            return true;
        }

        public int Front()
        {
            if (this._front.Count == 0 && this._rear.Count == 0)
                return -1;

            while (this._rear.Count != 0)
                this._front.Push(this._rear.Pop());

            return this._front.Peek();
        }

        public int Rear()
        {
            if (this._front.Count == 0 && this._rear.Count == 0)
                return -1;

            while (this._front.Count != 0)
                this._rear.Push(this._front.Pop());

            return this._rear.Peek();
        }

        public bool IsEmpty()
        {
            return this._front.Count == 0 && this._rear.Count == 0;
        }

        public bool IsFull()
        {
            return this._front.Count == this._capacity || this._rear.Count == this._capacity;
        }
    }
}
