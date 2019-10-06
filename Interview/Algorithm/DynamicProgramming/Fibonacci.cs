using System;

namespace Interview.Algorithm.DynamicProgramming
{
    class Fibonacci
    {
        public static void EntryPoint()
        {
            Console.WriteLine((new Fibonacci()).FibonacciByDP(5));
        }

        // Dynamic Programming
        // Climb steps question
        public int FibonacciByDP(int n)
        {
            if (n == 0 || n == 1 || n == 2)
                return n;

            int[] sequence = new int[n + 1];

            sequence[1] = 1;
            sequence[2] = 2;

            for (int i = 3; i <= n; i++)
                sequence[i] = sequence[i - 1] + sequence[i - 2];

            return sequence[n];
        }

        public int FibonacciByRecursion(int index, int depth)
        {
            int result = 0;
            int curentDepth = depth++;

            if (index == 1)
                result = 1;
            else if (index == 2)
                result = 2;
            else
                result = FibonacciByRecursion(index - 1, depth) + FibonacciByRecursion(index - 2, depth);

            Console.WriteLine("Level: " + curentDepth + ". Current result: " + result);

            return result;
        }
    }
}