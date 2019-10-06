using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Interview.DataStructure
{
    public class PriorityQueueTest
    {
        public static void EntryPoint()
        {
            PQNode node1 = new PQNode(2),
                   node2 = new PQNode(9),
                   node3 = new PQNode(1);

            PriorityQueue<PQNode> pq = new PriorityQueue<PQNode>();

            pq.Enqueue(node1);
            Console.WriteLine(pq.Peek().value);

            pq.Enqueue(node2);
            Console.WriteLine(pq.Peek().value);

            pq.Enqueue(node3);
            Console.WriteLine(pq.Peek().value);

            pq.Dequeue();
            Console.WriteLine(pq.Peek().value);

            pq.Dequeue();
            Console.WriteLine(pq.Peek().value);
        }
    }

    // This is a Min priority queue. The element with lowest rank / weight is the first one to be dequeued.
    // The general concept of priority queue is as below.
    // https://visualstudiomagazine.com/articles/2012/11/01/priority-queues-with-c.aspx
    // https://www.hackerearth.com/practice/notes/heaps-and-priority-queues/
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> data = null;

        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        public T this[int index]
        {
            get
            {
                return data[index];
            }
        }

        public PriorityQueue()
        {
            data = new List<T>();
        }

        public void Enqueue(T item)
        {
            data.Add(item);

            int i = data.Count - 1;

            while (i > 0)
            {
                int m = (i - 1) / 2;

                if (data[i].CompareTo(data[m]) >= 0)
                    break;

                var temp = data[i];
                data[i] = data[m];
                data[m] = temp;

                i = m;
            }
        }

        public T Dequeue()
        {
            int last = data.Count - 1;
            T item = data[0];
            data[0] = data[last];
            data.RemoveAt(last);
            last--;

            int m = 0,
                i = 0;

            while ((i = m * 2 + 1) <= last)
            {
                int r = i + 1;

                if (r <= last && data[r].CompareTo(data[i]) < 0)
                    i = r;

                if (data[m].CompareTo(data[i]) <= 0)
                    break;

                var temp = data[i];
                data[i] = data[m];
                data[m] = temp;

                m = i;
            }

            return item;
        }

        public T Peek()
        {
            return data[0];
        }
    }

    class PQNode : IComparable<PQNode>
    {
        public int value = 0;

        public PQNode(int val)
        {
            this.value = val;
        }

        public int CompareTo(PQNode other)
        {
            return value.CompareTo(other.value);
        }
    }
}