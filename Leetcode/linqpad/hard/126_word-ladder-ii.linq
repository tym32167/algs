<Query Kind="Program" />

void Main()
{
	
}


public class Solution
{
	public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
	{
		var connectedTo = new Dictionary<string, HashSet<string>>();
		var comesFrom = new Dictionary<string, HashSet<string>>();

		if (!wordList.Contains(beginWord))
		{
			var begWord = new HashSet<string>();
			for (var i = 0; i < wordList.Count; i++)
			{
				connectedTo.Add(wordList[i], new HashSet<string>());
				comesFrom.Add(wordList[i], new HashSet<string>());

				if (connected(beginWord, wordList[i]))
				{
					begWord.Add(wordList[i]);
					connectedTo[wordList[i]].Add(beginWord);
				}
			}
			connectedTo.Add(beginWord, begWord);
		}
		else
		{
			for (var i = 0; i < wordList.Count; i++)
			{
				connectedTo.Add(wordList[i], new HashSet<string>());
				comesFrom.Add(wordList[i], new HashSet<string>());
			}
		}


		for (var i = 0; i < wordList.Count; i++)
		{
			for (var j = i + 1; j < wordList.Count; j++)
			{
				if (connected(wordList[i], wordList[j]))
				{
					connectedTo[wordList[i]].Add(wordList[j]);
					connectedTo[wordList[j]].Add(wordList[i]);
				}
			}
		}




		var marked = new HashSet<string>();
		var queue = new Queue<string>();


		queue.Enqueue(beginWord);
		marked.Add(beginWord);

		var inq = new HashSet<string>();

		while (queue.Count != 0)
		{
			//var from = queue.Dequeue();
			var set = new HashSet<string>();
			while (queue.Count != 0) set.Add(queue.Dequeue());

			foreach (var from in set)
			{
				foreach (var item in connectedTo[from])
				{
					if (marked.Contains(item) || set.Contains(item)) continue;
					comesFrom[item].Add(from);
					queue.Enqueue(item);
				}
				marked.Add(from);
			}
		}

		if (!comesFrom.ContainsKey(endWord)) return new List<IList<string>>();

		return GetPath(comesFrom, beginWord, endWord);
	}

	IList<IList<string>> GetPath(Dictionary<string, HashSet<string>> comesFrom, string startWord, string endWord)
	{
		if (startWord == endWord) return new List<IList<string>>() { new List<string>() { startWord } };

		var res = new List<IList<string>>();

		foreach (var item in comesFrom[endWord])
		{
			var temp = GetPath(comesFrom, startWord, item);
			foreach (var t in temp) t.Add(endWord);
			res.AddRange(temp);
		}

		return res;
	}



	bool connected(string w1, string w2)
	{
		int numres = 0;
		for (int i = 0; i < w1.Length; i++)
		{
			if (w1[i] != w2[i]) numres++;
			if (numres > 1) return false;
		}
		return true;
	}
}


/*

Given two words (beginWord and endWord), and a dictionary's word list, find all shortest transformation sequence(s) from beginWord to endWord, such that:

Only one letter can be changed at a time
Each transformed word must exist in the word list. Note that beginWord is not a transformed word.
Note:

Return an empty list if there is no such transformation sequence.
All words have the same length.
All words contain only lowercase alphabetic characters.
You may assume no duplicates in the word list.
You may assume beginWord and endWord are non-empty and are not the same.
Example 1:

Input:
beginWord = "hit",
endWord = "cog",
wordList = ["hot","dot","dog","lot","log","cog"]

Output:
[
  ["hit","hot","dot","dog","cog"],
  ["hit","hot","lot","log","cog"]
]
Example 2:

Input:
beginWord = "hit"
endWord = "cog"
wordList = ["hot","dot","dog","lot","log"]

Output: []

Explanation: The endWord "cog" is not in wordList, therefore no possible transformation.

*/
