<Query Kind="Program" />

void Main()
{
	
}

public class Solution
{
	public bool CheckPossibility(int[] nums)
	{
		if (nums.Length < 3)
			return true;

		var ni = 0;
		var i1 = 0;

		for (int i = 0; i < nums.Length - 1; i++)
		{
			ni = nums[i];
			i1 = i + 1;

			if (ni > nums[i1])
			{
				if (i == 0)
				{
					if (CheckPossibilityinternal(nums, i1)) return true;
					nums[i1] = ni;
					if (CheckPossibilityinternal(nums, i1)) return true;
				}
				else
				{
					nums[i] = nums[i - 1];
					if (CheckPossibilityinternal(nums, i)) return true;
					nums[i1] = ni;
					if (CheckPossibilityinternal(nums, i1)) return true;
				}

				return false;
			}
		}

		return true;
	}

	private bool CheckPossibilityinternal(int[] nums, int startIndex)
	{
		for (var i = startIndex; i < nums.Length - 1; i++)
		{
			if (nums[i] > nums[i + 1]) return false;
		}
		return true;
	}
}

/*

Given an array with n integers, your task is to check if it could become non-decreasing by modifying at most 1 element.

We define an array is non-decreasing if array[i] <= array[i + 1] holds for every i (1 <= i < n).

Example 1:
Input: [4,2,3]
Output: True
Explanation: You could modify the first 4 to 1 to get a non-decreasing array.
Example 2:
Input: [4,2,1]
Output: False
Explanation: You can't get a non-decreasing array by modify at most one element.
Note: The n belongs to [1, 10,000].

*/
