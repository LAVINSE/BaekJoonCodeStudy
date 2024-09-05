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
        // 지도의 크기 N 과 M (N은 세로, M은 가로) => (2 <= n,m <= 1000)
        // n개의 줄에 m개의 숫자 => 0은 갈 수 없는 땅, 1은 갈 수 있는 땅, 2는 목표지점 (2는 단 한개)
        // 출력 : 각 지점에서 목표지점까지의 거리, 갈 수 없는 땅인 위치는 0, 도달할 수 없는 위치 -1

        StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();

        int[] inputs = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
        int n = inputs[0]; // 행 
        int m = inputs[1]; // 열
        int[,] maps = new int[n, m]; // 맵 정보를 저장할 배열
        int[,] distance = new int[n, m]; // 거리 저장을 위한 배열
        int[] directX = { -1, 1, 0, 0 }; // X축 방향 탐색을 위한 배열
        int[] directY = { 0, 0, -1, 1 }; // Y축 방향 탐색을 위한 배열
        int targetX = -1; // 목표지점 X 위치
        int targetY = -1; // 목표지점 Y 위치

        for (int i = 0; i < n; i++)
        {
            int[] grounds = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
            for (int j = 0; j < m; j++)
            {
                maps[i, j] = grounds[j];
                distance[i, j] = -1; // 초기에는 모든 거리를 -1로 설정 (도달 불가 상태)
                if (grounds[j] == 2)
                {
                    targetX = i;
                    targetY = j;
                    distance[i, j] = 0; // 목표 지점에서의 거리는 0
                }
            }
        }

        BFS(maps, distance, n, m, targetX, targetY, directX, directY);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                // 갈 수 없는 땅은 0으로 출력
                if (maps[i, j] == 0)
                    stringBuilder.Append(0).Append(' ');
                else
                    stringBuilder.Append(distance[i, j]).Append(' ');
            }
            stringBuilder.Append("\n");
        }

        writer.Write(stringBuilder.ToString());
        reader.Close();
        writer.Close();
    }

    private static void BFS(int[,] maps, int[,] distance, int n, int m, int targetX, int targetY, int[] directX, int[] directY)
    {
        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((targetX, targetY));

        while (queue.Count > 0)
        {
            var (currentX, currentY) = queue.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                int nX = currentX + directX[i];
                int nY = currentY + directY[i];

                if (nX < 0 && nY < 0 && nX >= n && nY >= m)
                    continue;
                if (maps[nX, nY] == 0 && distance[nX, nY] != -1)
                    continue;

                distance[nX, nY] = distance[currentX, currentY] + 1; // 거리 업데이트
                queue.Enqueue((nX, nY));
            }
        }
    }
}