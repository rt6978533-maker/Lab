using System;
using System.Collections.Generic;

public class TrieManager
{
    private readonly TrieNode _root = new();

    public void Insert(string command) {
        if (string.IsNullOrEmpty(command)) return;

        TrieNode current = _root;
        current.Commands.Add(command);

        foreach (char ch in command) {
            current.Children ??= new Dictionary<char, TrieNode>();

            if (!current.Children.TryGetValue(ch, out TrieNode nextNode))
            {
                nextNode = new TrieNode();
                current.Children[ch] = nextNode;
            }

            current = nextNode;
            current.Commands.Add(command);
        }
    }

    public List<string> FindSuggestions(ReadOnlySpan<char> prefix)
    {
        TrieNode current = _root;

        foreach (char ch in prefix)
        {
            if (current.Children == null || !current.Children.TryGetValue(ch, out current))
            {
                return new List<string>();
            }
        }

        return current.Commands;
    }
}
