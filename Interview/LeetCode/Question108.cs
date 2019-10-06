using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question108
    {
        public BinaryTree.Node SortedArrayToBST(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;

            return BuildBST(nums, 0, nums.Length - 1);
        }

        private BinaryTree.Node BuildBST(int[] nums, int startIndex, int endIndex)
        {
            BinaryTree.Node currentRoot = null;
            int currentRootIndex = endIndex + (startIndex - endIndex) / 2;

            if (startIndex <= endIndex)
            {
                currentRoot = new BinaryTree.Node(nums[currentRootIndex]);
                currentRoot.LeftNode = BuildBST(nums, startIndex, currentRootIndex - 1);
                currentRoot.RightNode = BuildBST(nums, currentRootIndex + 1, endIndex);
            }

            return currentRoot;
        }
    }
}