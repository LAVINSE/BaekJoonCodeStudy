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
        // 볼의 총 개수 N
        // 볼의 색깔을 나타내는 문자 R,B를 공백 없이
        // 한 종류의 색깔일 경우 0

        StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        //StringBuilder stringBuilder = new StringBuilder();

        int n = int.Parse(reader.ReadLine());
        string input = reader.ReadLine();
        char[] balls = input.ToCharArray();

        char red = 'R';
        char blue = 'B';

        int redCount = 0;
        int blueCount = 0;

        int minCount = 0;
        int count = 0;

        foreach(char ball in balls)
        {
            if (ball == red)
                redCount++;
            else
                blueCount++;
        }

        minCount = Math.Min(redCount, blueCount);

        for(int i = 0; i < n; i++)
        {
            if (balls[i] != balls[0])
                break;

            count++;
        }

        minCount = balls[0] == red ? Math.Min(minCount, redCount - count) : Math.Min(minCount, blueCount - count);
        count = 0;

        for(int i = n - 1; i >= 0; i--)
        {
            if (balls[i] != balls[n - 1])
                break;

            count++;
        }

        minCount = balls[n - 1] == red ? Math.Min(minCount, redCount - count) : Math.Min(minCount, blueCount - count);

        writer.Write(minCount);

        reader.Close();
        writer.Close();
    }
}