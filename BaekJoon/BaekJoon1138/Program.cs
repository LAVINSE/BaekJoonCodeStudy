using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 사람의 수 N
        // 왼쪽에 자신보다 키가 큰 사람의 수

        StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        //StringBuilder stringBuilder = new StringBuilder();

        int n = int.Parse(reader.ReadLine());
        int[] inputs = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

        int[] answers = new int[n];

        for(int i = 0; i < n; i++)
        {
            int count = inputs[i]; // 자신 앞에 키 큰 사람 수

            for(int j = 0; j < n; j++)
            {
                // 자신 앞에 키 큰 사람이 없고 해당 위치에 사람이 없을 경우
                if (count == 0 && answers[j] == 0)
                {
                    answers[j] = i + 1;
                    break;
                }
                else if (answers[j] == 0) // 자신 앞에 키 큰 사람이 존재하고 해당 위치에 사람이 없을 경우
                    count--;
            }
        }

        for (int i = 0; i < n; i++)
        {
            writer.Write($"{answers[i]} ");
        }

        reader.Close();
        writer.Close();
    }
}