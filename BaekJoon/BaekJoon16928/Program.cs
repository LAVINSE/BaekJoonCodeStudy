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

        // 주사위 1 ~ 6
        // 게임 크기 10 * 10 = 100
        // 1 ~ 100 까지 순서대로
        // i + 주사위 숫자 이동 <= 100 
        // 사다리의 수 N, 뱀의 수 M
        // N개의 줄에는 x번칸에 도착 > y번 칸으로 이동
        // M개의 줄에는 U번칸에 도착 > V번 칸으로 이동

        using StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();

        int[] inputs = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

        int n = inputs[0];
        int m = inputs[1];

        int[] map = new int[101];
        int[] saveData = new int[101];

        Queue<(int, int)> posDice = new Queue<(int, int)>();

        for (int i = 0; i < n + m; i++)
        {
            int[] pos = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            map[pos[0]] = pos[1];
        }

        posDice.Enqueue((1, -1));

        while(posDice.Count > 0)
        {
            var value = posDice.Dequeue();
            int checkMove = value.Item1;

            if (saveData[value.Item1] <= value.Item2 && (saveData[value.Item1] != 0))
                continue;

            saveData[value.Item1] = value.Item2 + 1;

            if (map[value.Item1] != 0)
                checkMove = map[value.Item1];

            for(int i = 0; i < 6; i++)
            {
                int next = checkMove + 1 + i;
                if (next > 100)
                    break;

                posDice.Enqueue((next, saveData[value.Item1]));
            }
        }

        writer.Write(saveData[100]);
    }
}