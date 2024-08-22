using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class Program
{
    private static void Main(string[] args)
    {
        // 키워드 개수 N
        // 블로그에 쓴 글의 개수 M
        StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] inputs = reader.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);

        HashSet<string> keyWords = new HashSet<string>(n);

        for (int i = 0; i < n; i++)
            keyWords.Add(reader.ReadLine());

        for (int i = 0; i < m; i++)
        {
            foreach (string word in reader.ReadLine().Split(','))
            {
                keyWords.Remove(word);
            }

            writer.WriteLine(keyWords.Count);
        }

        reader.Close();
        writer.Close();
    }
}