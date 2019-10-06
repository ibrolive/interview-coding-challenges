using System;

namespace Interview.Algorithm.Search
{
    class BinarySearch
    {
        public static void Entry()
        {
            int[] input = { 3, 6, 7, 8, 10, 20, 50 };
            //int[] input = { 3, 6, 7, 8, 10, 20 };
            //int[] input = { 4 };

            BinarySearch obj = new BinarySearch();            
            obj.Search(input, 3);
            //obj.Search(input, 4, 0, input.Length);
        }

        // Non-recursion
        public void Search(int[] input, int key)
        {
            if (input == null || input.Length == 0)
            {
                Console.WriteLine("Exception.");
                return;
            }

            int low = 0, high = input.Length - 1, middle = 0;

            while (low <= high)
            {
                middle = low + (high - low) / 2;

                if (key == input[middle])
                {
                    Console.WriteLine("Found. Index is {0}", middle);
                    return;
                }
                else if (key < input[middle])
                    high = middle - 1;
                else
                    low = middle + 1;
            }

            Console.WriteLine("Not Found {0}.", key);
        }

        // Recursion
        public void Search(int[] input, int key, int low, int high)
        {
            int middle = low + (high - low) / 2;

            if (low > high)
            {
                Console.WriteLine("Not Found {0}.", key);
                return;
            }

            if (key == input[middle])
            {
                Console.WriteLine("Found. Index is {0}", middle);
                return;
            }
            else if (key < input[middle])
                Search(input, key, low, middle - 1);
            else
                Search(input, key, middle + 1, high);
        }
    }
}