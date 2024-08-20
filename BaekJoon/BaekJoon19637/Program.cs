using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 칭호의 개수 N
        // 캐릭터들의 개수 M

        // 칭호이름, 전투력 N개

        // M개 전투력

        StringBuilder stringBuilder = new StringBuilder();

        int[] inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int n = inputs[0];
        int m = inputs[1];

        string[] titles = new string[n];
        int[] limitPowers = new int[n];
        
        for(int i = 0; i < n; i++)
        {
            string[] inputTitle = Console.ReadLine().Split();
            string title = inputTitle[0];
            int power = int.Parse(inputTitle[1]);

            titles[i] = title;
            limitPowers[i] = power;
        }
        
        for(int i = 0; i < m; i++)
        {
            int characterPower = int.Parse(Console.ReadLine());

            int start = 0;
            int end = n - 1;

            while(start <= end)
            {
                // 중간 인덱스
                int mid = (start + end) / 2;

                // 중간값의 전투력이 캐릭터의 힘보다 작을 경우
                if (limitPowers[mid] < characterPower)
                {
                    // 중간보다 위쪽 탐색
                    start = mid + 1;
                }
                else
                {
                    // 중간보다 아래쪽 탐색
                    end = mid - 1;
                }
            }

            stringBuilder.AppendLine(titles[start]);
        }
        
        Console.WriteLine(stringBuilder.ToString());
    }
}