using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 연산의 개수 N
        // N개의 줄에 정수 X >> X가 자연수면 배열에 추가
        // X가 0이라면 배열에서 가장 작은 값 출력 그 값을 제거

        StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(reader.ReadLine());
        PriorityQueue<int, int> inputQueue = new PriorityQueue<int, int>();

        StringBuilder stringBuilder = new StringBuilder();

        for(int i = 0; i < n; i++)
        {
            int x = int.Parse(reader.ReadLine());

            if(x > 0)
            {
                inputQueue.Enqueue(x, x);
            }
            else if(x == 0)
            {
                if(inputQueue.Count >0)
                {
                    int minValue = inputQueue.Dequeue();
                    stringBuilder.AppendLine(minValue.ToString());
                }
                else
                {
                    stringBuilder.AppendLine(0.ToString());
                }
                
            }
        }

        writer.Write(stringBuilder);

        reader.Close();
        writer.Close();
    }
}