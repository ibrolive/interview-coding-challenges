using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question251
    {
        public class Vector2D
        {
            Queue<int> queue = new Queue<int>();

            public Vector2D(IList<IList<int>> vec2d)
            {
                if (vec2d != null)
                    for (int i = 0; i < vec2d.Count; i++)
                        if (vec2d[i] != null)
                            foreach (var item in vec2d[i])
                                queue.Enqueue(item);
            }

            public bool HasNext()
            {
                if (queue.Count == 0)
                    return false;

                return true;
            }

            public int Next()
            {
                return queue.Dequeue();
            }
        }
    }
}
