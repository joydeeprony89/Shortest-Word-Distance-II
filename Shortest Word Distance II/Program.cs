using System;
using System.Collections.Generic;

namespace Shortest_Word_Distance_II
{
  // https://www.programcreek.com/2014/07/leetcode-shortest-word-distance-ii-java/
  class Program
  {
    static void Main(string[] args)
    {
      string[] words = new string[] { "coding", "practice", "makes", "perfect", "coding", "makes" };
      Solution s = new Solution(words);
      int distance = s.ShortestWordDistance("makes", "coding");
      Console.WriteLine(distance);
    }
  }

  public class Solution
  {
    readonly Dictionary<string, List<int>> hash = new Dictionary<string, List<int>>();
    public Solution(string[] words)
    {
      for (int i = 0; i < words.Length; i++)
      {
        string word = words[i];
        if (!hash.ContainsKey(word))
        {
          hash.Add(word, new List<int>());
        }
        hash[word].Add(i);
      }
    }

    public int ShortestWordDistance(string word1, string word2)
    {
      var word1Indexes = hash[word1];
      var word2Indexes = hash[word2];
      int shortestDistance = int.MaxValue;
      /*
      int max1 = word1Indexes.Max();
      int max2 = word2Indexes.Max();
      int distance = Math.Abs(max1 - max2);
      return distance;
      */
      // better approach in O(N) time complexity.
      int i = 0, j = 0;
      while (i < word1Indexes.Count && j < word2Indexes.Count)
      {
        int word1Index = word1Indexes[i];
        int word2Index = word2Indexes[j];
        shortestDistance = Math.Min(Math.Abs(word1Index - word2Index), shortestDistance);
        if (word1Index < word2Index)
        {
          i++;
        }
        else
        {
          j++;
        }
      }
      return shortestDistance;
    }
  }
}
