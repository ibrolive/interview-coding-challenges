using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.DataStructure
{
    class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }

        public Node(int value)
        {
            this.Value = value;
        }
    }

    class LinkedList
    {
        private Node _headerNode = null;
        public Node Header
        {
            get
            {
                return _headerNode;
            }
            private set
            {
                _headerNode = value;
            }
        }

        public LinkedList()
        { }

        public LinkedList(int headerValue)
        {
            this.Header = new Node(headerValue);
        }

        public void Add(int value)
        {            
            Add(new Node(value));
        }

        public void Add(Node node)
        {
            Node _lastNode = GetLastNode();
            _lastNode.NextNode = node;
        }

        public Node GetLastNode()
        {
            Node _lastNode = Header;

            while (_lastNode.NextNode != null)
            {
                _lastNode = _lastNode.NextNode;
            }

            return _lastNode;
        }
    }
}