using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    class Question146
    {
        public static void EntryPoint()
        {
            //[[2],[1,1],[2,2],[1],[3,3],[2],[4,4],[1],[3],[4]]

            //LRUCache cache = new LRUCache(2);
            //cache.Get(2);
            //cache.Put(1, 1);
            //cache.Put(2, 2);
            //cache.Get(1);
            //cache.Put(3, 3);
            //cache.Get(2);


            // [[1],[2,1],[2],[3,2],[2],[3]]
            LRUCache cache = new LRUCache(1);
            cache.Put(2, 1);
            cache.Get(2);
            cache.Put(3, 2);
            cache.Get(2);
        }
    }

    public class LRUCache
    {
        private int _capacity = 0;
        private LinkedList<int[]> _recentlyUsed = new LinkedList<int[]>();
        private LinkedListNode<int[]> head = new LinkedListNode<int[]>(new int[] { -1, -1 }), tail = new LinkedListNode<int[]>(new int[] { -1, -1 });
        private Hashtable _cache = null;

        public LRUCache(int capacity)
        {
            this._capacity = capacity;
            this._cache = new Hashtable();
            _recentlyUsed.AddFirst(head);
            _recentlyUsed.AddAfter(head, tail);
        }

        public int Get(int key)
        {
            if (!_cache.ContainsKey(key))
                return -1;

            ReorderRecentlyUsed((LinkedListNode<int[]>)_cache[key]);
            return ((LinkedListNode<int[]>)_cache[key]).Value[1];
        }

        public void Put(int key, int value)
        {
            LinkedListNode<int[]> currentNode = null;

            if (_cache.Contains(key))
            {
                currentNode = (LinkedListNode<int[]>)_cache[key];
                currentNode.Value[1] = value;
            }
            else
            {
                currentNode = new LinkedListNode<int[]>(new int[] { key, value });

                if (_cache.Count == _capacity)
                {
                    _cache.Remove(tail.Previous.Value[0]);
                    RemoveLRNode(tail.Previous);
                }                    

                _cache.Add(key, currentNode);
            }

            ReorderRecentlyUsed(currentNode);
        }

        private void ReorderRecentlyUsed(LinkedListNode<int[]> node)
        {
            if (node.Previous != null && node.Next != null)
                _recentlyUsed.Remove(node);

            _recentlyUsed.AddAfter(head, node);
        }

        private void RemoveLRNode(LinkedListNode<int[]> node)
        {
            _recentlyUsed.Remove(node);
        }
    }
}