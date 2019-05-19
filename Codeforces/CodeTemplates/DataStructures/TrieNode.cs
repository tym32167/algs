using System.Collections.Generic;

namespace CodeTemplates.DataStructures
{
    public class TrieNode
    {
        public string Value { get; private set; }
        private readonly Dictionary<char, TrieNode> _inner = new Dictionary<char, TrieNode>();

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
    }
}