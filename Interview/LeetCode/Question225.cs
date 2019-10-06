using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question225
    {
        public static void EntryPoint()
        {
            MyStack stack = new MyStack();

            stack.Push(1);
        }

        public class MyStack
        {
            private Queue<int> _queue1 = new Queue<int>();
            private Queue<int> _queue2 = new Queue<int>();
            private Queue<int> _currentPushQueue = null;
            private Queue<int> _currentPopQueue = null;
            private Queue<int> _tempQueue = null;

            public MyStack()
            {
                _currentPushQueue = _queue1;
                _currentPopQueue = _queue2;
            }

            public void Push(int x)
            {
                if (_currentPopQueue.Count != 0)
                    _currentPushQueue.Enqueue(_currentPopQueue.Dequeue());

                _currentPopQueue.Enqueue(x);
            }

            public int Pop()
            {
                int value = 0;

                if (_currentPopQueue.Count != 0)
                {
                    value = _currentPopQueue.Dequeue();

                    while (_currentPushQueue.Count > 1)
                        _currentPopQueue.Enqueue(_currentPushQueue.Dequeue());

                    _tempQueue = _currentPopQueue;
                    _currentPopQueue = _currentPushQueue;
                    _currentPushQueue = _tempQueue;
                }

                return value;
            }

            public int Top()
            {
                int value = 0;

                if (_currentPopQueue.Count != 0)
                {
                    value = _currentPopQueue.Dequeue();
                    _currentPopQueue.Enqueue(value);
                }

                return value;
            }

            public bool Empty()
            {
                return _currentPopQueue.Count == 0 && _currentPushQueue.Count == 0;
            }
        }
    }
}