## The General Flow To Solve a Coding Problem
Ask yourself the following questions:
1. What kind of data structure is leveraged in this problem?
2. What is the basic technique for this data structure? (Generally the complex problem description is hiding the very basic technique associating to the data structure.)
3. If you can't answer the question 1 & 2, read the problem description again and start from the most straightforward and naive case. Implement it and then extend it to meet the problem description.
4. At all the time, if you have the brute-force solution, write it down. It is always better than keeping the whiteboard blank at all.

## Data Structures
### Array
* Pattern & Technique
  Whenever getting a problem that related to array, ask yourself the following questions:  
  1. Is the array sorted? If not, does sorting the array help to simplfy the problem?
  2. Can I use two and / or multiple pointers? The two pointers could be composed as a sliding window. Or, the two pointers could be put at the beginning and end of the array. Both sliding window and beginning-end pointers could help to reduce the time / space complexity.

### Linked-list
* Pattern & Technique
* Typical Interview Questions
1. Reverse a linked-list
2. Merge sorted linked-list
3. How to sort linked-list in Onlog(n) [time complexity]?
4. Find the middle of the list
5. Find cycle
6. Find cross

### Stack

### Queue

### Binary Tree
* Pattern & Technique
1. All of the tree problems could be resolved by either DFS or BFS.
2. Get familiar the characteristic of standard trees (full tree / complete tree), like n, 2n, 2n + 1.
3. Use AnnotationNode for trees.
This is a typical method to compare the tree with a completed / full binary tree.
https://leetcode.com/problems/cousins-in-binary-tree/description/  
https://leetcode.com/problems/check-completeness-of-a-binary-tree/description/

* Typical Interview Questions:
1. LCA
2. Sum in a path
3. Rebuild binary tree from in-order / pre-order or pre-order / post-order

### Binary Search Tree
* Pattern & Technique  
In BST, each value in left sub-tree should less than the root node and each value in right sub-tree should greater than the root node.

* Typical Interview Questions:  
1. How to generate a BST from a list?

### Segment Tree
* Pattern & Technique

### Binary Indexed Tree
* Pattern & Technique

### Heap

### Priority Queue

### Graph
* Pattern & Technique
1. DFS:  
Normally, DFS can be usded to detect whether two points in the matrix is connected or not.  
Use recursion to implement the algorithm.  
The spread process of DFS is random, which means it's not possible to determine which one will be picked up in the next round.
2. BFS:  
Normally, BFS is usded to detect the shortest path between start point and the destination. BFS can navigate from the start point layer by layer.  
Use queue to implement the algorithm.
3. Common:  
Both DFS and BFS needs an additional array (boolean[,] or boolean[][]) to store whether current point is visited or not. It could prevent the the algorithm gets stuck in cycle.
4. Path related issue: Use a dictionary or hashtable to store the detected / known path.
5. Topology sort
6. Detect cycle  
    a. black-white-gray  
    https://leetcode.com/problems/find-eventual-safe-states/description/  
    https://www.geeksforgeeks.org/detect-cycle-direct-graph-using-colors/  
    b. Union-Find  
    https://www.geeksforgeeks.org/union-find/

7. Color the nodes of a graph

Matrix General Description:
	1. maze: find a path from start point to the destination.
	2. shortest path: find the shortest path between two known points.

Data Structure:
2D array like int[,] or int[][]


### Disjoint Set  
* Implementation  
Use rank to accelerate the search process, while a simpler approach is to ignore the rank.
https://github.com/IAMRogerXi/Coding_Practice/blob/master/Interview/DataStructure/DisjointSet.cs

* Pattern & Technique  
1. Detect whether the graph contains cycle.
2. Detect whetehr elements are in the same group.  
https://leetcode.com/problems/sentence-similarity-ii/description/
3. Detect the connected components.  
https://leetcode.com/articles/redundant-connection/  
https://leetcode.com/problems/accounts-merge/solution/  
https://leetcode.com/problems/regions-cut-by-slashes/solution/

### Trie  
* Pattern & Technique  
1. Use Trie to solve the string prefix problems.
2. Trie also can be used to compose a dictionary.

## Algorithm
### Sorting

### Searching

### Recursion

### Divide and Conquer

### Backtrack  
1. Make sure you can describe the code runtime behavior correctly.  
2. Backtrack is not DFS. Each round in the backtrack, the status will be changed and the new status will be passed to the next round. After that, the status will be reset. While, normally DFS won't have the process to set the status / reset status.  
https://leetcode.com/problems/generalized-abbreviation/description/
3. If the problem description includes 'ALL', consider to use 'backtrack'.

### Sliding Window
* two pointers
* Use sliding window to calculate the max sum of a window in a range. For instance, there is an array A and a sliding window S. Calculate the max sum of elements that S will cover in A.   
https://leetcode.com/problems/grumpy-bookstore-owner/description/


### Bitwise

### Greedy

### Dynamic Programming
* Pattern & Technique
* Typical Interview Questions
* Variant of knapsacks  
https://leetcode.com/problems/last-stone-weight-ii/description/

### KMP

### Permutation
Use backtrack to calculate permutation.  
https://github.com/IAMRogerXi/Coding_Practice/blob/master/Interview/Algorithm/Other/Permutation.cs

## Edge Testing Cases
* Test whether the inputs parameters are pointed to the same instance?
* The edge cases for Maths problem
1. Overflow: -2147483648 ~ 2147483648, Math.Abs(-2147483648), etc...

## Special Topics & Practice
* Sum
  When the problem is related to 'SUM', the sum 'prefix' will be a basic strategy to resolve the problem.
  Leetcode question: https://leetcode.com/problems/continuous-subarray-sum/description/
* Random Value
Leetcode question: https://leetcode.com/problems/implement-rand10-using-rand7/
* How to find a target group and the position in the group?
1. Use / to find which group the taget will drop into.
2. Use % to find the position in the group.
3. Single element in array.
4. Marjority in array.
5. Permutation: DFS, Leetcode 60

* The list of must-do alogrithm problems:
https://www.geeksforgeeks.org/must-do-coding-questions-for-companies-like-amazon-microsoft-adobe/

* Problem Catalogs
1. Calendar overlap problems:  
Use De Morgan's laws to simplfy the conditions. Or, use TreeMap / SortedDictionary to store the data.  
https://leetcode.com/problems/my-calendar-i/description/  https://leetcode.com/problems/my-calendar-ii/description/   

* Factor
Use (int i = 1; i * i < num; i++) as the condition of factor related problems.

* Use '#' to compose a completed tree. So that the tree will become unique.  
https://leetcode.com/problems/find-duplicate-subtrees/description/

* For tree / graph problems:
The first step is to analyze how to traverse the data structure. DFS (For tree, pre-order / in-order / post-order?) OR BFS.

* Problems to detect unique: use hash table or directionary.

* The difference between lower case and upper case. (For instance, 'a' & 'A')

* bit problems
https://leetcode.com/problems/hamming-distance/description/

* Use stack to store the MAX value in a range.  
https://leetcode.com/problems/next-greater-node-in-linked-list/description/

* Consider to refresh the index after the list structure is changed.

* List<T> can't delete elements according to the reference. Normally, it is necessary to build up a customized type to handle such scenario.

* Track the count of 26 characters.
int[] count = new int[26];
++count[c - 'a']; // if c is 'a', increase count[0].

* Use two arrays to determine four directions while travese a graph.
int[] rowChange = new int[] { -1, 1, 0, 0};
int[] colChange = new int[] { 0, 0, -1, 1};