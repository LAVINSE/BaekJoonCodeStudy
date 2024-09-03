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
        // 정점의 개수 N, 간선의 개수 M, 탐색을 시작할 정점의 번호 V
        // M개의 줄에 간선이 연결하는 두 정점의 번호

        StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();

        int[] inputs = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

        int n = inputs[0];
        int m = inputs[1];
        int v = inputs[2]; // 탐색을 시작할 정점 V

        int[,] maps = new int[n + 1, n + 1];
        bool[] visit = new bool[n + 1];

        for (int i = 0; i < m; i++)
        {
            int[] edge = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            maps[edge[0], edge[1]] = 1;
            maps[edge[1], edge[0]] = 1;
        }

        DFS(n, v, visit, maps, stringBuilder);
        visit = new bool[n + 1];
        stringBuilder.Append('\n');
        BFS(n, v, visit, maps, stringBuilder);

        writer.Write(stringBuilder);

        reader.Close();
        writer.Close();
    }

    private static void DFS(int n, int v, bool[] visit, int[,] maps, StringBuilder stringBuilder)
    {
        stringBuilder.Append(v.ToString());
        visit[v] = true;

        for(int y = 1; y <= n; y++) 
        {
            if (maps[v, y] == 0)
                continue;
            if (visit[y])
                continue;

            stringBuilder.Append(' ');
            DFS(n, y, visit, maps, stringBuilder);
        }
    }

    private static void BFS(int n, int v, bool[] visit, int[,] maps, StringBuilder stringBuilder)
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(v);

        while(queue.Count > 0)
        {
            int x = queue.Dequeue();

            if (visit[x] == false)
            {
                stringBuilder.Append(x);
                stringBuilder.Append(' ');
                visit[x] = true;
            }

            for(int y = 1;  y <= n; y++)
                if (maps[x, y] == 1 && visit[y] == false)
                    queue.Enqueue(y);
        }
    }
}