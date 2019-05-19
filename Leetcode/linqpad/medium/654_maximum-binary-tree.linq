<Query Kind="Program" />

void Main()
{
	new Solution().ConstructMaximumBinaryTree(new[] {3,2,1,6,0,5}).Dump();
}



public class Solution
{
	public TreeNode ConstructMaximumBinaryTree(int[] nums)
	{
		return ConstructMaximumBinaryTree(nums, 0, nums.Length - 1);
	}

	private TreeNode ConstructMaximumBinaryTree(int[] nums, int start, int end)
	{
		if (start > end) return null;

		int maxInd = start;
		for (int i = start; i <= end; i++)
		{
			if (nums[i] > nums[maxInd])
				maxInd = i;
		}
		var node = new TreeNode(nums[maxInd]);
		node.left = ConstructMaximumBinaryTree(nums, start, maxInd - 1);
		node.right = ConstructMaximumBinaryTree(nums, maxInd + 1, end);
		return node;
	}
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

/*

Given an integer array with no duplicates. A maximum tree building on this array is defined as follow:

The root is the maximum number in the array.
The left subtree is the maximum tree constructed from left part subarray divided by the maximum number.
The right subtree is the maximum tree constructed from right part subarray divided by the maximum number.
Construct the maximum tree by the given array and output the root node of this tree.

Example 1:
Input: [3,2,1,6,0,5]
Output: return the tree root node representing the following tree:

      6
    /   \
   3     5
    \    / 
     2  0   
       \
        1
Note:
The size of the given array will be in the range [1,1000].

*/
