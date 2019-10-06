using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1146
    {
    }

    public class SnapshotArray
    {
        private Dictionary<int, Dictionary<int, int>> indexSnaps = new Dictionary<int, Dictionary<int, int>>();
        private int currentSnapId = 0;

        public SnapshotArray(int length)
        {

        }

        public void Set(int index, int val)
        {
            Dictionary<int, int> indexSnap;

            if (indexSnaps.TryGetValue(index, out indexSnap))
                indexSnap[currentSnapId] = val;
            else
                indexSnaps[index] = new Dictionary<int, int>() { { currentSnapId, val } };
        }

        public int Snap()
        {
            return currentSnapId++;
        }

        public int Get(int index, int snap_id)
        {

            Dictionary<int, int> indexSnap;
            int val;

            if (indexSnaps.TryGetValue(index, out indexSnap))
            {
                if (indexSnap.TryGetValue(snap_id, out val))
                    return val;
                else
                {
                    int maxSnapId = 0;

                    foreach (var key in indexSnap.Keys)
                    {
                        if (key > snap_id || key < maxSnapId)
                            continue;

                        val = indexSnap[key];
                        maxSnapId = key;
                    }

                    return val;
                }
            }
            else
                return 0;
        }
    }
}
