using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 단어의 개수 N
        // 개수만큼 단어 입력

        int n = int.Parse(Console.ReadLine());
        List<char> target = new List<char>(Console.ReadLine());
        int answer = 0;

        for (int i = 0; i < n - 1; i++)
        {
            List<char> compare = new List<char>(target);
            string word = Console.ReadLine();
            int cnt = 0;

            foreach (char w in word)
            {
                if (compare.Contains(w))
                {
                    compare.Remove(w);
                }
                else
                {
                    cnt++;
                }
            }

            if (cnt < 2 && compare.Count < 2)
            {
                answer++;
            }
        }

        Console.WriteLine(answer);
    }
}