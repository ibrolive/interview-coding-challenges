using System;

namespace Interview.Algorithm.DynamicProgramming
{
    class Factorial
    {
        public static void EntryPoint()
        {
            //(new Factorial()).FactorialByNonRecursion(6);
            //(new Factorial()).FactorialByRecursion(6);
            (new Factorial()).FactorialByDP(6);
        }

        private int FactorialByRecursion(int index)
        {
            if (index == 1)
                return 1;
            else
                return index * FactorialByRecursion(index - 1);
        }

        private int FactorialByNonRecursion(int index)
        {
            int result = 1;

            for (int i = 1; i <= index; i++)
            {
                result = result * i;
            }

            return result;
        }

        private int FactorialByDP(int n)
        {
            if (n == 0)
                return 0;

            int[] sequence = new int[n + 1];
            sequence[1] = 1;

            for (int i = 2; i <= n; i++)
                sequence[i] = sequence[i - 1] * i;

            return sequence[n];
        }
    }
}