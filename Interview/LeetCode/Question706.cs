using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question706
    {
    }

    public class MyHashMap
    {
        private List<int[]> data = null;

        public MyHashMap()
        {
            data = new List<int[]>();
        }

        public void Put(int key, int value)
        {
            foreach (var item in data)
                if (item[0] == key)
                {
                    item[1] = value;
                    return;
                }

            data.Add(new int[] { key, value });
        }

        public int Get(int key)
        {
            foreach (var item in data)
                if (item[0] == key)
                    return item[1];

            return -1;
        }

        public void Remove(int key)
        {
            for (int i = 0; i < data.Count; i++)
                if (data[i][0] == key)
                {
                    data.RemoveAt(i);
                    return;
                }
        }
    }
}
