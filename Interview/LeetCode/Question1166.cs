using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1166
    {
        public static void EntryPoint()
        {
            FileSystem obj = new FileSystem();
            obj.Create("/a", 1);
        }
    }

    public class FileSystem
    {
        public class Node
        {
            public string Path { get; set; }

            public int Value { get; set; } = Int32.MinValue;

            public Dictionary<string, Node> NextLevel { get; set; } = new Dictionary<string, Node>();

            public Node(string path)
            {
                this.Path = path;
            }
        }

        Dictionary<string, Node> _dict = new Dictionary<string, Node>();

        public FileSystem()
        {

        }

        public bool Create(string path, int value)
        {
            return CreateHelper(_dict, path.Split('/'), 1, value);
        }

        private bool CreateHelper(Dictionary<string, Node> dict, string[] paths, int i, int value)
        {
            if (i == paths.Length - 1)
                if (dict.ContainsKey(paths[i]) && dict[paths[i]].Value != Int32.MinValue)
                    return false;
                else
                {
                    if (!dict.ContainsKey(paths[i]))
                        dict.Add(paths[i], new Node(paths[i]));

                    dict[paths[i]].Value = value;
                    return true;
                }

            if (!dict.ContainsKey(paths[i]))
                return false;

            return CreateHelper(dict[paths[i]].NextLevel, paths, i + 1, value);
        }

        public int Get(string path)
        {
            return GetHelper(_dict, path.Split('/'), 1);
        }

        private int GetHelper(Dictionary<string, Node> dict, string[] paths, int i)
        {
            if (i == paths.Length - 1)
                if (dict.ContainsKey(paths[i]))
                    return dict[paths[i]].Value;
                else
                    return -1;

            if (!dict.ContainsKey(paths[i]))
                return -1;

            return GetHelper(dict[paths[i]].NextLevel, paths, i + 1);
        }
    }
}
