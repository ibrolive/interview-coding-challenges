using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question841
    {
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            int[] visited = new int[rooms.Count];

            if (DFS(rooms, 0, visited) == rooms.Count)
                return true;

            return false;
        }

        private int DFS(IList<IList<int>> rooms, int currentRoom, int[] visited)
        {
            int visitedCount = 1;

            visited[currentRoom] = 1;

            if (rooms[currentRoom].Count != 0)
                foreach (var item in rooms[currentRoom])
                    if (visited[item] != 1)
                        visitedCount += DFS(rooms, item, visited);

            return visitedCount;
        }
    }
}
