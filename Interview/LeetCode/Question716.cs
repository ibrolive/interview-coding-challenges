using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question716
    {
        public static void EntryPoint()
        {
            MaxStack obj = new MaxStack();

            obj.Push(5);
            obj.Push(1);
            obj.Push(5);
            obj.Top();
            obj.PopMax();
            obj.Top();
            obj.PeekMax();
            obj.Pop();
            obj.Top();

            //obj.Push(-44);
            //obj.Top();
            //obj.Pop();
            //obj.Push(63);
            //obj.Push(-44);
            //obj.PopMax();
            //obj.PopMax();
            //obj.Push(-35);
            //obj.PopMax();
            //obj.Push(57);
            //obj.Push(-88);
            //obj.Pop();
            //obj.Pop();
            //obj.Push(-45);
            //obj.PopMax();
            //obj.Push(-34);
            //obj.PeekMax();
        }
    }

    public class MaxStack
    {
        private SortedList<int, List<ListNode>> _sortedList = new SortedList<int, List<ListNode>>();
        private DoubleLinkedList _list = new DoubleLinkedList();

        public MaxStack()
        {

        }

        public void Push(int x)
        {
            ListNode tempNode = _list.AddNode(x);

            if (!_sortedList.Keys.Contains(x))
                _sortedList.Add(x, new List<ListNode>());

            _sortedList[x].Add(tempNode);
        }

        public int Pop()
        {
            ListNode result = _list.LastNode;

            _list.RemoveNode(result);
            _sortedList[result.Value].RemoveAt(_sortedList[result.Value].Count - 1);

            if (_sortedList[result.Value].Count == 0)
                _sortedList.Remove(result.Value);

            return result.Value;
        }

        public int Top()
        {
            return _list.LastNode.Value;
        }

        public int PeekMax()
        {
            return _sortedList.Keys.Max();
        }

        public int PopMax()
        {
            ListNode result = _sortedList[_sortedList.Keys.Max()][_sortedList[_sortedList.Keys.Max()].Count - 1];

            _list.RemoveNode(result);
            _sortedList[result.Value].RemoveAt(_sortedList[result.Value].Count - 1);

            if (_sortedList[result.Value].Count == 0)
                _sortedList.Remove(result.Value);

            return result.Value;
        }

        public class ListNode
        {
            public ListNode Prev { get; set; }
            public ListNode Next { get; set; }
            public int Value { get; set; }
        }

        public class DoubleLinkedList
        {
            private ListNode _dummyNode = new ListNode();

            public int Count { get; set; }
            public ListNode LastNode { get; set; }

            public DoubleLinkedList()
            {
                this.LastNode = _dummyNode;
            }

            public ListNode AddNode(int value)
            {
                ListNode tempNode = new ListNode();

                tempNode.Value = value;
                LastNode.Next = tempNode;
                tempNode.Prev = LastNode;

                this.LastNode = tempNode;

                Count++;

                return tempNode;
            }

            public void RemoveNode(ListNode node)
            {
                ListNode prev = node.Prev,
                         next = node.Next;

                prev.Next = next;

                if (next != null)
                    next.Prev = prev;

                if (next == null)
                    this.LastNode = prev;

                Count--;
            }
        }
    }
}
