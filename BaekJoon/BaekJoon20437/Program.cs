using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {

        using StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();

        int gameCount = int.Parse(reader.ReadLine());

        for(int i = 0; i < gameCount; i++)
        {
            string text = reader.ReadLine();
            int k = int.Parse(reader.ReadLine());

            var dict = Dict(text);
            int[] value = Length(dict, k);

            writer.WriteLine(string.Join(" ", value));
        }
    }

    private static Dictionary<char, List<int>> Dict(string word)
    {
        Dictionary<char, List<int>> dict = new Dictionary<char, List<int>>();

        for(int i = 0; i < word.Length; i++)
        {
            if (dict.ContainsKey(word[i]) == false)
            {
                dict[word[i]] = new List<int>();
            }

            dict[word[i]].Add(i);
        }

        return dict;
    }

    private static int[] Length(Dictionary<char, List<int>> dict, int k)
    {
        // 초기값 최소, 최대간격 설정 [int.MaxValue, 0]
        int[] value = { int.MaxValue, 0 };

        foreach(var arr in dict.Values)
        {
            int length = arr.Count;

            if (length < k)
                continue;

            for(int i = 0; i <= length - k; i++)
            {
                int gap = arr[i + k - 1] - arr[i] + 1;
                if (value[0] > gap)
                    value[0] = gap;

                if (value[1] < gap)
                    value[1] = gap;
            }
        }

        return (value[0] == int.MaxValue && value[1] == 0) ? new int[] { -1 } : value;
    }
}