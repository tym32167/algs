<Query Kind="Program" />

void Main()
{
	Console.WriteLine(new Solution().MinAddToMakeValid("())"));
	Console.WriteLine(new Solution().MinAddToMakeValid("((("));
	Console.WriteLine(new Solution().MinAddToMakeValid("()"));
	Console.WriteLine(new Solution().MinAddToMakeValid("()))(("));
}


public class Solution
{
	public int MinAddToMakeValid(string S)
	{
		int cnt = 0;		
		int cng = 0;
		
		foreach(var c in S)
		{			
			if (c == ')')
			{
				if (cnt > 0)
				{
					cnt--;
					cng--;
				}
				else cng++;
			}
			else
			{
				cng++;
				cnt++;
			}
		}		
		
		return cng;
	}

	public int MinAddToMakeValid2(string S)
	{
		var st = new Stack<char>();

		foreach (var c in S)
		{
			if (c == ')')
			{
				if (st.Count > 0 && st.Peek() == '(') st.Pop();
				else st.Push(c);
			}
			else st.Push(c);
		}

		return st.Count;
	}
}


/*

Given a string S of '(' and ')' parentheses, we add the minimum number of parentheses ( '(' or ')', and in any positions ) so that the resulting parentheses string is valid.

Formally, a parentheses string is valid if and only if:

It is the empty string, or
It can be written as AB (A concatenated with B), where A and B are valid strings, or
It can be written as (A), where A is a valid string.
Given a parentheses string, return the minimum number of parentheses we must add to make the resulting string valid.

 

Example 1:

Input: "())"
Output: 1
Example 2:

Input: "((("
Output: 3
Example 3:

Input: "()"
Output: 0
Example 4:

Input: "()))(("
Output: 4
 

Note:

S.length <= 1000
S only consists of '(' and ')' characters.


*/
