using System;
using Xunit;
using DataStructures;

namespace DataStructures.Tests
{
    public class TrieTest
    {
        private Trie _trie;

        public TrieTest()
        {
            _trie = new Trie();
            _trie.AddWord("Bob");
            _trie.AddWord("Bobson");
            _trie.AddWord("Beth");
            _trie.AddWord("Alice");
            _trie.AddWord("Albert");
            _trie.AddWord("John");
            _trie.AddWord("Jane");
            _trie.AddWord("James");
            _trie.AddWord("Janice");
        }

        [Theory]
        [InlineData("Bob", 2)]
        [InlineData("Bobs", 1)]
        [InlineData("Bobson", 1)]
        [InlineData("J", 4)]
        [InlineData("Jan", 2)]
        [InlineData("X", 0)]
        [InlineData("", 0)]
        public void TestCountingWords(string word, int count)
        {
            var countTrie = _trie.GetCount(word);
            Assert.True(countTrie == count, $"{word} should have {count} occurences but is having {countTrie}");
        }

        [Fact]
        public void TestAddWord() 
        {
            Assert.True(_trie.GetCount("x1") == 0, "Trie should not contain any word that matches 'x1'");
            _trie.AddWord("x1");
            Assert.True(_trie.GetCount("x1") == 1, "Trie should not contain any word that matches 'x1'");
        }
    }
}
