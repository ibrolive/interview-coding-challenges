using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question735
    {
        public static void EntryPoint()
        {
            (new Question735()).AsteroidCollision(new int[] { 1, -1, -2, -2 });
        }

        public int[] AsteroidCollision(int[] asteroids)
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < asteroids.Length; i++)
                if (stack.Count == 0)
                    stack.Push(asteroids[i]);
                else
                    while (stack.Count > 0)
                        if (asteroids[i] < 0 && stack.Peek() > 0 && Math.Abs(stack.Peek()) == Math.Abs(asteroids[i]))
                        {
                            stack.Pop();
                            break;
                        }
                        else if (asteroids[i] < 0 && stack.Peek() > 0 && Math.Abs(stack.Peek()) < Math.Abs(asteroids[i]))
                        {
                            stack.Pop();

                            if (stack.Count == 0)
                            {
                                stack.Push(asteroids[i]);
                                break;
                            }
                        }
                        else if (asteroids[i] < 0 && stack.Peek() > 0 && Math.Abs(stack.Peek()) > Math.Abs(asteroids[i]))
                            break;
                        else
                        {
                            stack.Push(asteroids[i]);
                            break;
                        }

            return stack.ToArray().Reverse().ToArray();
        }
    }
}
