using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 플레이어의 수 P
        // 방의 정원 M
        // 두 번째 줄부터 P개의 레벨 I, 닉네임 N

        StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();

        int[] inputs = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
        int p = inputs[0];
        int m = inputs[1];

        int count = 0;

        string start = "Started!";
        string wait = "Waiting!";

        Dictionary<int, string> playerDataDict = new Dictionary<int, string>();

        for(int i = 0; i < p; i++)
        {
            string[] playerDatas = reader.ReadLine().Split();
            int level = int.Parse(playerDatas[0]);
            string nick = playerDatas[1];

            playerDataDict.Add(level, nick);
        }

        for (int i = 0; i < playerDataDict.Count; i++)
        {
            if(playerDataDict.Count >= m)
            {
                var playerLevel = playerDataDict.ToList()[i].Key;
                //playerDataDict.or
                if (count == 0)
                    stringBuilder.AppendLine(start);

                stringBuilder.AppendLine(playerDataDict.ToList()[i].Key.ToString() + playerDataDict.ToList()[i].Value);
                
                count++;
            }
            else
            {
                stringBuilder.AppendLine(wait);
            }

            if (count == m)
                count = 0;
        }

        writer.Write(stringBuilder);

        reader.Close();
        writer.Close();
    }
}