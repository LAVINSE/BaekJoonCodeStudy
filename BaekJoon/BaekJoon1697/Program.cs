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
        // 수빈이가 있는 위치 N
        // 동생이 있는 위치 K

        using StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();

        int[] inputs = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
        int n = inputs[0];
        int k = inputs[1];

        if (n == k)
        {
            writer.Write(0);
            return;
        }

        int count = 0;

        Queue<int> queue = new Queue<int>();
        bool[] visited = new bool[100001];

        queue.Enqueue(n);
        visited[n] = true;

        while (true)
        {
            count++;
            int size = queue.Count;

            for (int i = 0; i < size; i++)
            {
                int x = queue.Dequeue();

                if (x - 1 == k || x + 1 == k || x * 2 == k)
                {
                    writer.Write(count);
                    return;
                }

                if (x - 1 >= 0 && visited[x - 1] == false)
                {
                    visited[x - 1] = true;
                    queue.Enqueue(x - 1);
                }

                if (x + 1 <= 100000 && visited[x + 1] == false)
                {
                    visited[x + 1] = true;
                    queue.Enqueue(x + 1);
                }

                if (x * 2 <= 100000 && visited[x * 2] == false)
                {
                    visited[x * 2] = true;
                    queue.Enqueue(x * 2);
                }
            }
        }
    }
}