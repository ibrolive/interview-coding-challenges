using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1116
    {

    }

    public class ZeroEvenOdd
    {
        private int n;
        private System.Threading.Semaphore signalZero,
                                           signalEven,
                                           signalOdd;

        public ZeroEvenOdd(int n)
        {
            this.n = n;
            this.signalZero = new System.Threading.Semaphore(1, 1);
            this.signalEven = new System.Threading.Semaphore(0, 1);
            this.signalOdd = new System.Threading.Semaphore(0, 1);
        }

        // printNumber(x) outputs "x", where x is an integer.
        public void Zero(Action<int> printNumber)
        {
            for (int i = 1; i <= n; i++)
            {
                signalZero.WaitOne();

                printNumber(0);

                if (i % 2 == 1)
                    signalOdd.Release();
                else
                    signalEven.Release();
            }
        }

        public void Even(Action<int> printNumber)
        {
            for (int i = 2; i <= n; i += 2)
            {
                signalEven.WaitOne();

                printNumber(i);

                signalZero.Release();
            }
        }

        public void Odd(Action<int> printNumber)
        {
            for (int i = 1; i <= n; i += 2)
            {
                signalOdd.WaitOne();

                printNumber(i);

                signalZero.Release();
            }
        }
    }
}
