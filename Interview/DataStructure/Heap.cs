using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Interview.DataStructure
{
    class HeapTest
    {
        public static void EntryPoint()
        {
            MinHeap<char> heap = new MinHeap<char>();

            heap.Add('A', 15);
            Console.WriteLine(heap.PeekKey());

            heap.Add('B', 11);
            Console.WriteLine(heap.PeekKey());

            heap.Add('C', 8);
            Console.WriteLine(heap.PeekKey());

            heap.Add('D', 5);
            Console.WriteLine(heap.PeekKey());

            heap.Add('E', 16);
            Console.WriteLine(heap.PeekKey());

            heap.Add('F', 2);
            Console.WriteLine(heap.PeekKey());

            heap.Add('G', 4);
            Console.WriteLine(heap.PeekKey());

            //Console.WriteLine(heap.ExtractKey());
            //Console.WriteLine(heap.PeekKey());

            //Console.WriteLine(heap.ExtractKey());
            //Console.WriteLine(heap.PeekKey());

            //Console.WriteLine(heap.ExtractKey());
            //Console.WriteLine(heap.PeekKey());

            heap.Increase('F', 10);
            Console.WriteLine(heap.PeekKey());
        }
    }

    // TODO: modify the queue. Then use the queue to finish question 1102.
    // https://www.hackerearth.com/practice/notes/heaps-and-priority-queues/
    class MaxHeap
    {
        private List<int> _data { get; set; }

        public MaxHeap(int[] input)
        {
            _data = new List<int>(input);

            BuildMaxHeap(_data, _data.Count - 1);
        }

        public int Extract()
        {
            int max = _data[0];

            _data[0] = _data[_data.Count - 1];
            _data.RemoveAt(_data.Count - 1);
            BuildMaxHeap(_data, _data.Count - 1);

            return max;
        }

        public void SortByASC()
        {
            for (int i = _data.Count - 1; i > 0; i--)
            {
                int temp = _data[i];
                _data[i] = _data[0];
                _data[0] = temp;

                BuildMaxHeap(_data, i - 1);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            foreach (var item in _data)
                output.Append(item.ToString() + " ");

            return output.ToString();
        }

        private void BuildMaxHeap(List<int> input, int end)
        {
            for (int i = (input.Count - 2) / 2; i >= 0; i--)
                MaxHeapify(input, i, end);
        }

        private void MaxHeapify(List<int> input, int currentPosition, int end)
        {
            int largestPosition = 0,
                leftPosition = 2 * currentPosition + 1,
                rightPosition = 2 * currentPosition + 2;

            if (leftPosition <= end && input[currentPosition] < input[leftPosition])
                largestPosition = leftPosition;
            else
                largestPosition = currentPosition;

            if (rightPosition <= end && input[largestPosition] < input[rightPosition])
                largestPosition = rightPosition;

            if (largestPosition != currentPosition)
            {
                int temp = input[largestPosition];
                input[largestPosition] = input[currentPosition];
                input[currentPosition] = temp;

                MaxHeapify(input, largestPosition, end);
            }
        }
    }

    // This is a MIN heap with the nature of hashtable. What is hash map + heap? Refer the following GitHub repository.
    // https://github.com/mission-peace/interview/blob/259077bacabdbb5b6a0e918cd8dfe5eabca3300f/src/com/interview/graph/BinaryMinHeap.java
    class MinHeap<T>
    {
        private List<HeapNode<T>> _data = new List<HeapNode<T>>();
        private Hashtable _hash = new Hashtable();

        public int Count
        {
            get
            {
                return _data.Count;
            }
        }

        public HeapNode<T> this[T item]
        {
            get
            {
                if (!_hash.ContainsKey(item))
                    return null;

                return _data[(int)_hash[item]];
            }
        }

        public bool Contains(T item)
        {
            return _hash.ContainsKey(item);
        }

        public void Add(T item, int weight)
        {
            _data.Add(new HeapNode<T>(item, weight));
            _hash.Add(item, _data.Count - 1);

            MinHeapify(_data.Count - 1);
        }

        public void Decrease(T item, int weight)
        {
            if (!_hash.ContainsKey(item))
                return;

            _data[(int)_hash[item]].Weight = weight;

            MinHeapify((int)_hash[item]);
        }

        public void Increase(T item, int weight)
        {
            if (!_hash.ContainsKey(item))
                return;

            _data[(int)_hash[item]].Weight = weight;

            MinHeapify((int)_hash[item], _data.Count - 1);
        }

        public HeapNode<T> PeekHeapNode()
        {
            return _data.Count != 0 ? _data[0] : null;
        }

        public T PeekKey()
        {
            return PeekHeapNode().Key;
        }

        public int PeekWeight()
        {
            return PeekHeapNode().Weight;
        }

        public HeapNode<T> ExtractHeapNode()
        {
            if (_data.Count == 0)
                return null;

            HeapNode<T> min = _data[0];
            _data[0] = _data[_data.Count - 1];
            _data.RemoveAt(_data.Count - 1);

            _hash.Remove(min.Key);

            MinHeapify(0, _data.Count - 1);

            return min;
        }

        public T ExtractKey()
        {
            return ExtractHeapNode().Key;
        }

        public int ExtractWeight()
        {
            return ExtractHeapNode().Weight;
        }

        // Heapify the data collection from current index to top.
        private void MinHeapify(int index)
        {
            while (index >= 0 && _data[(index - 1) / 2].Weight > _data[index].Weight)
            {
                Swap((index - 1) / 2, index);

                index = (index - 1) / 2;
            }
        }

        // Heapify the data collection from current index to bottom.
        private void MinHeapify(int index, int end)
        {
            int smallestIndex,
                leftIndex = 2 * index + 1,
                rightIndex = 2 * index + 2;

            if (leftIndex <= end && _data[index].Weight > _data[leftIndex].Weight)
                smallestIndex = leftIndex;
            else
                smallestIndex = index;

            if (rightIndex <= end && _data[smallestIndex].Weight > _data[rightIndex].Weight)
                smallestIndex = rightIndex;

            if (smallestIndex != index)
            {
                Swap(smallestIndex, index);

                MinHeapify(smallestIndex, end);
            }
            else
                for (int i = index; i <= end; i++)
                    _hash[_data[i].Key] = i;
        }

        private void Swap(int index1, int index2)
        {
            HeapNode<T> temp = _data[index1];
            _data[index1] = _data[index2];
            _data[index2] = temp;

            if (!_hash.ContainsKey(_data[index1].Key))
                _hash.Add(_data[index1].Key, index1);
            else
                _hash[_data[index1].Key] = index1;

            if (!_hash.ContainsKey(_data[index2].Key))
                _hash.Add(_data[index2].Key, index2);
            else
                _hash[_data[index2].Key] = index2;
        }
    }

    public class HeapNode<T>
    {
        public T Key;
        public int Weight;

        public HeapNode(T key, int weight)
        {
            this.Key = key;
            this.Weight = weight;
        }
    }
}
