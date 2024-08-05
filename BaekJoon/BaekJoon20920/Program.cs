using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 자주 나오는 단어 앞에
        // 해당 단어 길이가 길면 앞에
        // 사전순으로 앞에

        StringBuilder stringBuilder = new StringBuilder();

        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int n = input[0]; // 단어 개수
        int m = input[1]; // 단어의 길이 기준

        Dictionary<string, int> wordDict = new Dictionary<string, int>();

        for(int i = 0; i < n; i++)
        {
            string word = Console.ReadLine();

            if (word.Length < m)
                continue;

            if (wordDict.ContainsKey(word))
                wordDict[word]++;
            else
                wordDict[word] = 1;
        }

        // 자주 나오는 단어, 단어 길이가 길고, 사전순으로 정렬 > string으로 리스트 추출
        List<string> wordList = wordDict.OrderByDescending(x => x.Value).ThenByDescending(x => x.Key.Length).ThenBy(x => x.Key).Select(x => x.Key).ToList();

        foreach(string word in wordList)
        {
            stringBuilder.AppendLine(word);
        }

        Console.Write(stringBuilder);
    }
}