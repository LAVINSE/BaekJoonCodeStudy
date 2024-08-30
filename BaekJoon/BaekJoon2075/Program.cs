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
        // N번째 큰 수
        // N * N  수 입력

        StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        //StringBuilder stringBuilder = new StringBuilder();

        int n = int.Parse(reader.ReadLine());
        PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();//Comparer<int>.Create((x, y) => y.CompareTo(x)));

        // 우선순위 Queue에 추가
        for(int i = 0; i < n; i++)
        {
            int[] inputs = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            for(int j = 0; j < n; j++)
            {
                priorityQueue.Enqueue(inputs[j], inputs[j]);
            }

            if(i >= 1)
            {
                while(priorityQueue.Count > n)
                    priorityQueue.Dequeue();
            }
        }

        //// N 번째 수 전까지 제거
        //for(int i = 0; i < n - 1; i++)
        //{
        //    priorityQueue.Dequeue();
        //}

        // N 번째 수
        writer.Write(priorityQueue.Dequeue());

        reader.Close();
        writer.Close();
    }
}