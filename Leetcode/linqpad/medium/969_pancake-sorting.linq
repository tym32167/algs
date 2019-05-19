<Query Kind="Program" />

void Main()
{
	new Solution().PancakeSort(new[] {3,2,4,1}).Dump();
}



public class Solution
{
	public IList<int> PancakeSort(int[] A)
	{
		var ret = new List<int>();
		
		for(int i=A.Length-1; i>0; i--)
		{
			SetMaxToEnd(A, i, ret);
		}	
		
		return ret;
	}

	private void SetMaxToEnd(int[] A, int end, List<int> ret)
	{
		int maxInd = 0;

		for (int i = 0; i <= end; i++)
			if (A[i] > A[maxInd])
				maxInd = i;

		if (maxInd == end) return;
		if (maxInd > 0)
		{
			ret.Add(maxInd+1);
			Flip(A, maxInd);
		}

		ret.Add(end+1);
		Flip(A, end);
	}

	private void Flip(int[] A, int k)
	{
		int start = 0;
		int end = k;
		while (start < end)
		{
			Swap(A, start, end);
			start++;
			end--;
		}
	}

	private void Swap(int[] A, int i, int j)
	{
		var tmp = A[i];
		A[i] = A[j];
		A[j] = tmp;
	}
}



/*

Given an array A, we can perform a pancake flip: We choose some positive integer k <= A.length, then reverse the order of the first k elements of A.  We want to perform zero or more pancake flips (doing them one after another in succession) to sort the array A.

Return the k-values corresponding to a sequence of pancake flips that sort A.  Any valid answer that sorts the array within 10 * A.length flips will be judged as correct.

 

Example 1:

Input: [3,2,4,1]
Output: [4,2,4,3]
Explanation: 
We perform 4 pancake flips, with k values 4, 2, 4, and 3.
Starting state: A = [3, 2, 4, 1]
After 1st flip (k=4): A = [1, 4, 2, 3]
After 2nd flip (k=2): A = [4, 1, 2, 3]
After 3rd flip (k=4): A = [3, 2, 1, 4]
After 4th flip (k=3): A = [1, 2, 3, 4], which is sorted. 
Example 2:

Input: [1,2,3]
Output: []
Explanation: The input is already sorted, so there is no need to flip anything.
Note that other answers, such as [3, 3], would also be accepted.
 

Note:

1 <= A.length <= 100
A[i] is a permutation of [1, 2, ..., A.length]

*/
