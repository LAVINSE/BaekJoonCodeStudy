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

        int n = inputs[0]; // 정점의 개수
        int m = inputs[1]; // 간선의 개수
        int v = inputs[2]; // 탐색을 시작할 정점 >> 1부터 시작

        int[,] maps = new int[n + 1, n + 1];
        bool[] visit = new bool[n + 1]; // 정점을 방문했는지 확인할 배열

        // M개의 간선을 입력받아 행렬에 저장
        for (int i = 0; i < m; i++)
        {
            int[] edge = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            // 양방향 연결
            // 값이 1로 설정되면 연결 되어있다는것을 나타낸다
            maps[edge[0], edge[1]] = 1;
            maps[edge[1], edge[0]] = 1;
        }

        DFS(n, v, visit, maps, stringBuilder);

        // 방문 배열 초기화
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
        visit[v] = true; // 현재 정점을 방문으로 표시

        for(int y = 1; y <= n; y++) 
        {
            if (maps[v, y] == 0) // 간선이 없으면 건너뜀
                continue;
            if (visit[y]) // 이미 방문한 정점이면 건너뜀
                continue;

            stringBuilder.Append(' ');
            DFS(n, y, visit, maps, stringBuilder);
        }
    }

    private static void BFS(int n, int v, bool[] visit, int[,] maps, StringBuilder stringBuilder)
    {
        Queue<int> queue = new Queue<int>(); // 탐색할 정점을 저장할 큐
        queue.Enqueue(v); // 시작 정점을 큐에 추가

        // 큐에 요소가 없을때까지 반보
        while(queue.Count > 0)
        {
            int x = queue.Dequeue(); // 큐에서 정점을 꺼냄

            if (visit[x] == false) // 해당 정점을 아직 방문하지 않았다면
            {
                stringBuilder.Append(x);
                stringBuilder.Append(' ');
                visit[x] = true; // 해당 정점을 방문으로 표시
            }

            // 연결된 정점들을 큐에 추가
            for(int y = 1;  y <= n; y++)
                if (maps[x, y] == 1 && visit[y] == false)
                    queue.Enqueue(y); // 큐에 아직 방문하지 않은 정점을 추가
        }
    }
}