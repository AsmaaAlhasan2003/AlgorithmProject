using System;
using System.Collections.Generic;

public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; set; }
    public bool IsEndOfWord { get; set; }
    public string Value { get; set; }

    public TrieNode()
    {
        Children = new Dictionary<char, TrieNode>();
        IsEndOfWord = false;
    }
}

public class Trie
{
    private TrieNode _root;

    public Trie()
    {
        _root = new TrieNode();
    }

    // إدخال كلمة في الـ Trie
    public void Insert(string word)
    {
        var currentNode = _root;

        foreach (var ch in word)
        {
            if (!currentNode.Children.ContainsKey(ch))
            {
                currentNode.Children[ch] = new TrieNode();
            }
            currentNode = currentNode.Children[ch];
        }

        currentNode.IsEndOfWord = true;
        currentNode.Value = word;
    }

    // البحث عن كلمة في الـ Trie
    public bool Search(string word)
    {
        var currentNode = _root;

        foreach (var ch in word)
        {
            if (!currentNode.Children.ContainsKey(ch))
            {
                return false;
            }
            currentNode = currentNode.Children[ch];
        }

        return currentNode.IsEndOfWord;
    }

    // حذف كلمة من الـ Trie
    public bool Delete(string word)
    {
        return Delete(_root, word, 0);
    }

    private bool Delete(TrieNode node, string word, int index)
    {
        if (index == word.Length)
        {
            if (!node.IsEndOfWord)
                return false;

            node.IsEndOfWord = false;
            return node.Children.Count == 0;
        }

        var ch = word[index];
        if (!node.Children.ContainsKey(ch))
            return false;

        var childNode = node.Children[ch];
        bool shouldDeleteCurrentNode = Delete(childNode, word, index + 1);

        if (shouldDeleteCurrentNode)
        {
            node.Children.Remove(ch);
            return node.Children.Count == 0 && !node.IsEndOfWord;
        }

        return false;
    }

    // تحديث كلمة في الـ Trie
    public bool Update(string oldWord, string newWord)
    {
        if (!Delete(oldWord))
            return false;

        Insert(newWord);
        return true;
    }

    // إرجاع جميع الكلمات في الـ Trie
    public List<string> GetAllWords()
    {
        var words = new List<string>();
        GetAllWordsHelper(_root, words);
        return words;
    }

    private void GetAllWordsHelper(TrieNode node, List<string> words)
    {
        if (node.IsEndOfWord)
        {
            words.Add(node.Value);
        }

        foreach (var child in node.Children.Values)
        {
            GetAllWordsHelper(child, words);
        }
    }

    // إرجاع الجذر (لاستعماله في التمثيل الهيكلي)
    public TrieNode GetRoot()
    {
        return _root;
    }
}
