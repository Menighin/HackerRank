using System;
using System.Collections.Generic;

namespace DataStructures
{
    /// <summary>
    /// Class that represents a Trie
    /// </summary>
    public class Trie
    {
        private TrieNode head;

        public Trie ()
        {
            head = new TrieNode();
        }

        /// <summary>
        /// Adds a word to the Trie
        /// </summary>
        /// <param name="word">Word to be added</param>
        public void AddWord(string word)
        {
            TrieNode curr = head;

            curr = curr.GetChild(word[0], true);

            for (int i = 1; i < word.Length; i++)
            {
                curr.Count++;
                curr = curr.GetChild(word[i], true);
            }
            
            curr.Count++;
            
        }

        /// <summary>
        /// Gets the number of words that has the prefix, including if prefix is already an word
        /// </summary>
        /// <param name="prefix">prefix to be searched</param>
        /// <returns>Number of words that has the prefix</returns>
        public int GetCount(string prefix)
        {
            TrieNode curr = head;

            foreach (char c in prefix)
            {
                curr = curr.GetChild(c);

                if (curr == null)
                {
                    return 0;
                }
            }

            return curr.Count;
        }

        /// <summary>
        /// Class that represents a TrieNode
        /// </summary>
        internal class TrieNode 
        {
            private Dictionary<char, TrieNode> _children;

            public int Count { get; set; }
            public char Data { get; private set;}

            public TrieNode(char data = ' ') 
            {
                this.Data = data;
                this.Count = 0;
                this._children = new Dictionary<char, TrieNode>();
            }

            /// <summary>
            /// Get a child of the node with the given char <paramref name="c" />. 
            /// If the node doesn't exist and <paramref name="createIfNotExist" /> is set to true, creates the node
            /// </summary>
            /// <param name="c"></param>
            /// <param name="createIfNotExist"></param>
            /// <returns></returns>
            public TrieNode GetChild(char c, bool createIfNotExist = false)
            {
                if (_children.ContainsKey(c))
                    return _children[c];

                if (createIfNotExist)
                {
                    return CreateChild(c);
                }

                return null;
            }
                
            /// <summary>
            /// Creates a TrieNode child and returns it
            /// </summary>
            /// <param name="c">Char to be created in the node</param>
            /// <returns>TrieNode</returns>
            public TrieNode CreateChild(char c)
            {
                var child = new TrieNode(c);
                _children[c] = child;

                return child;
            }

        }
    }
}