<Query Kind="Program" />

void Main()
{
	new Solution().ReplaceWords(new List<string>() {"cat", "bat", "rat"}, "the cattle was rattled by the battery").Dump();
}



public class Solution
{
	public string ReplaceWords(IList<string> dict, string sentence)
	{
		var root = new TrieNode();
		foreach (var s in dict) root.Add(s, 0);
		return string.Join(" ", sentence.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(w=>root.Get(w, 0)));
	}

	public class TrieNode
	{
		public string Value { get; private set; }
		private Dictionary<char, TrieNode> _inner = new Dictionary<char, TrieNode>();

		public void Add(string str, int index)
		{
			if (str.Length == index)
			{
				Value = str;
				return;
			}

			var c = str[index];
			TrieNode child;
			if (_inner.ContainsKey(c)) child = _inner[c];
			else
			{
				child = new TrieNode();
				_inner.Add(c, child);
			}

			child.Add(str, index + 1);
		}
		
		public string Get(string inp, int ind)
		{
			if (Value != null) return Value;
			if (ind >= inp.Length) return inp;
			var c = inp[ind];
			if (!_inner.ContainsKey(c)) return inp;
			return _inner[c].Get(inp, ind+1);
		}
	}
}



/*

In English, we have a concept called root, which can be followed by some other words to form another longer word - let's call this word successor. For example, the root an, followed by other, which can form another word another.

Now, given a dictionary consisting of many roots and a sentence. You need to replace all the successor in the sentence with the root forming it. If a successor has many roots can form it, replace it with the root with the shortest length.

You need to output the sentence after the replacement.

Example 1:

Input: dict = ["cat", "bat", "rat"]
sentence = "the cattle was rattled by the battery"
Output: "the cat was rat by the bat"
 

Note:

The input will only have lower-case letters.
1 <= dict words number <= 1000
1 <= sentence words number <= 1000
1 <= root length <= 100
1 <= sentence words length <= 1000


*/
