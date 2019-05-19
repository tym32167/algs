<Query Kind="Program" />

void Main()
{
	
}



public class Solution
{
	public IList<int> FindSubstring(string s, string[] words)
	{
		var ret = new List<int>();
		if (words.Length == 0) return ret;

		var root = new Node();
		int wordsLen = 0;

		var d1 = new Dictionary<char, int>();
		var d2 = new Dictionary<char, int>();

		//var wd = new Dictionary<string, int>();

		foreach (var w in words)
		{
			root.Add(w);
			wordsLen += w.Length;

			// if (wd.ContainsKey(w)) wd[w]++; else wd[w]=1;

			foreach (var c in w)
				if (d1.ContainsKey(c)) d1[c]++;
				else
				{
					d1.Add(c, 1);
					d2.Add(c, 0);
				}
		}

		if (s.Length < wordsLen) return ret;

		int count = 0;
		for (int i = 0; i < wordsLen; i++)
		{
			var c = s[i];
			if (d2.ContainsKey(c))
			{
				var val = d2[c];
				if (val < d1[c]) count++;
				d2[c] = val + 1;
			}
		}

		//var len = words[0].Length;

		for (var i = 0; i <= s.Length - wordsLen; i++)
		{
			if (count == wordsLen)
			{
				//if (Check(s, i, len, words.Length, wd))
				//	ret.Add(i);
				if (root.CheckWord(s, i, words.Length, root))
					ret.Add(i);
			}

			if (i + wordsLen < s.Length)
			{
				var b = s[i];
				var e = s[i + wordsLen];

				if (d2.ContainsKey(b))
				{
					var val = d2[b];
					if (val <= d1[b]) count--;
					d2[b] = val - 1;
				}

				if (d2.ContainsKey(e))
				{
					var val = d2[e];
					if (val < d1[e]) count++;
					d2[e] = val + 1;
				}
			}
		}

		return ret;
	}

	private bool Check(string str, int ind, int len, int total, Dictionary<string, int> words)
	{
		if (total == 0) return true;
		if (ind + len > str.Length) return false;

		var sub = str.Substring(ind, len);
		if (!words.ContainsKey(sub)) return false;

		var val = words[sub];
		if (val == 0) return false;

		words[sub]--;
		var ret = Check(str, ind + len, len, total - 1, words);
		words[sub]++;
		return ret;
	}

	public class Node
	{
		public Dictionary<char, Node> _childrens = new Dictionary<char, Node>();
		public int count = 0;

		public Node()
		{
			count = 0;
		}

		public bool CheckWord(string word, int index, int total, Node root)
		{
			if (count > 0)
			{
				total--;
				if (total == 0)
					return true;
				count--;
				var ret = root.CheckWord(word, index, total, root);
				count++;
				return ret;
			}
			if (index >= word.Length) return false;
			var w = word[index];
			if (!_childrens.ContainsKey(w)) return false;
			return _childrens[w].CheckWord(word, index + 1, total, root);
		}

		public void Add(string str, int index = 0)
		{
			if (str.Length == index)
			{
				count++;
				return;
			}

			var c = str[index];

			if (_childrens.ContainsKey(c))
			{
				var node = _childrens[c];
				node.Add(str, index + 1);
			}
			else
			{
				var node = new Node();
				_childrens[c] = node;
				node.Add(str, index + 1);
			}
		}
	}
}


/*
You are given a string, s, and a list of words, words, that are all of the same length. Find all starting indices of substring(s) in s that is a concatenation of each word in words exactly once and without any intervening characters.

Example 1:

Input:
  s = "barfoothefoobarman",
  words = ["foo","bar"]
Output: [0,9]
Explanation: Substrings starting at index 0 and 9 are "barfoor" and "foobar" respectively.
The output order does not matter, returning [9,0] is fine too.
Example 2:

Input:
  s = "wordgoodgoodgoodbestword",
  words = ["word","good","best","word"]
Output: []

*/
