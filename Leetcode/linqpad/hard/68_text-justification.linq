<Query Kind="Program" />

void Main()
{
	
}


public class Solution
{
	public IList<string> FullJustify(string[] words, int maxWidth)
	{
		var rows = new List<WordsLine>();

		var cur = new WordsLine();

		for (var i = 0; i < words.Length; i++)
		{
			cur.Add(words[i]);
			if (cur.Length > maxWidth)
			{
				cur.RemoveLast();
				rows.Add(cur);
				cur = new WordsLine();
				cur.Add(words[i]);
			}
		}
		rows.Add(cur);

		var ret = new List<string>();

		for (var i = 0; i < rows.Count; i++)
		{
			if (i == rows.Count - 1) ret.Add(rows[i].FormatLast(maxWidth));
			else ret.Add(rows[i].Format(maxWidth));
		}

		return ret;
	}

	public class WordsLine
	{
		public List<string> _words = new List<string>();

		public void Add(string word)
		{
			_words.Add(word);
			wordsLength += word.Length;
		}

		public void RemoveLast()
		{
			var word = _words.Last();
			_words.RemoveAt(_words.Count - 1);
			wordsLength -= word.Length;
		}

		private int wordsLength = 0;
		public int Length => wordsLength + _words.Count - 1;

		public string FormatLast(int n)
		{
			var extra = n - Length;
			var sb = new StringBuilder();

			sb.Append(string.Join(" ", _words));
			for (var j = 0; j < extra; j++) sb.Append(' ');

			return sb.ToString();
		}

		public string Format(int n)
		{
			var extra = n - Length;
			var spaces = _words.Count - 1;

			if (spaces > 0)
			{
				var average = extra / spaces;
				var overhead = extra % spaces;

				var sb = new StringBuilder();

				sb.Append(_words[0]);

				for (var i = 1; i < _words.Count; i++)
				{
					var toadd = average + 1;
					if (overhead > 0)
					{
						toadd++;
						overhead--;
					}

					for (var j = 0; j < toadd; j++) sb.Append(' ');
					sb.Append(_words[i]);
				}

				return sb.ToString();
			}
			else
			{
				var sb = new StringBuilder();

				sb.Append(_words[0]);

				for (var j = 0; j < extra; j++) sb.Append(' ');

				return sb.ToString();
			}
		}
	}
}


/*

Given an array of words and a width maxWidth, format the text such that each line has exactly maxWidth characters and is fully (left and right) justified.

You should pack your words in a greedy approach; that is, pack as many words as you can in each line. Pad extra spaces ' ' when necessary so that each line has exactly maxWidth characters.

Extra spaces between words should be distributed as evenly as possible. If the number of spaces on a line do not divide evenly between words, the empty slots on the left will be assigned more spaces than the slots on the right.

For the last line of text, it should be left justified and no extra space is inserted between words.

Note:

A word is defined as a character sequence consisting of non-space characters only.
Each word's length is guaranteed to be greater than 0 and not exceed maxWidth.
The input array words contains at least one word.
Example 1:

Input:
words = ["This", "is", "an", "example", "of", "text", "justification."]
maxWidth = 16
Output:
[
   "This    is    an",
   "example  of text",
   "justification.  "
]
Example 2:

Input:
words = ["What","must","be","acknowledgment","shall","be"]
maxWidth = 16
Output:
[
  "What   must   be",
  "acknowledgment  ",
  "shall be        "
]
Explanation: Note that the last line is "shall be    " instead of "shall     be",
             because the last line must be left-justified instead of fully-justified.
             Note that the second line is also left-justified becase it contains only one word.
Example 3:

Input:
words = ["Science","is","what","we","understand","well","enough","to","explain",
         "to","a","computer.","Art","is","everything","else","we","do"]
maxWidth = 20
Output:
[
  "Science  is  what we",
  "understand      well",
  "enough to explain to",
  "a  computer.  Art is",
  "everything  else  we",
  "do                  "
]

*/
