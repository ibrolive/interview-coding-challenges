﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question836
    {
        public bool IsRectangleOverlap(int[] rec1, int[] rec2)
        {
            return !(rec1[2] <= rec2[0] ||
                     rec1[3] <= rec2[1] ||
                     rec1[0] >= rec2[2] ||
                     rec1[1] >= rec2[3]);
        }
    }
}
