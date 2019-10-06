using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question380
    {
        public static void EntryPoint()
        {
            Question380.RandomizedSet set = new Question380.RandomizedSet();
            set.Insert(3);
            set.Insert(-2);
            set.Remove(2);
            set.Insert(1);
            set.Insert(-3);
            set.Insert(-2);
            set.Remove(-2);
            set.Remove(3);
        }

        class RandomizedSet
        {
            List<int> list = null;
            Dictionary<int, int> dictionary = null;
            Random random = null;

            /** Initialize your data structure here. */
            public RandomizedSet()
            {
                list = new List<int>();
                dictionary = new Dictionary<int, int>();
                random = new Random();
            }

            /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
            public bool Insert(int val)
            {
                if (!dictionary.ContainsKey(val))
                {
                    list.Add(val);
                    dictionary.Add(val, list.Count - 1);

                    return true;
                }

                return false;
            }

            /** Removes a value from the set. Returns true if the set contained the specified element. */
            public bool Remove(int val)
            {
                if (dictionary.ContainsKey(val))
                {
                    dictionary[list[list.Count - 1]] = dictionary[val];
                    list[dictionary[val]] = list[list.Count - 1];

                    list.RemoveAt(list.Count - 1);
                    dictionary.Remove(val);

                    return true;
                }

                return false;
            }

            /** Get a random element from the set. */
            public int GetRandom()
            {
                return list[random.Next(list.Count)];
            }
        }
    }
}
