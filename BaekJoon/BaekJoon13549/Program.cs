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
        // N과 K는 정수

        using StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();

        int[] inputs = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
        int n = inputs[0]; // 수빈이 위치
        int k = inputs[1]; // 동생 위치

        if (n == k)
        {
            writer.Write(0);
            return;
        }

        Queue<(int, int)> queue = new Queue<(int, int)>();
        bool[] visited = new bool[100001];

        queue.Enqueue((n, 0)); // 시작 위치와 0초에서 시작
        visited[n] = true;

        while (queue.Count > 0)
        {
            var (current, time) = queue.Dequeue();

            // 동생 위치에 도착하면 시간 출력 후 종료
            if (current == k)
            {
                writer.Write(time);
                return;
            }

            // *2 순간이동 처리
            if (current * 2 <= 100000 && !visited[current * 2])
            {
                visited[current * 2] = true;
                queue.Enqueue((current * 2, time)); // 시간 증가 없이 큐에 추가
            }

            // -1로 이동
            if (current - 1 >= 0 && !visited[current - 1])
            {
                visited[current - 1] = true;
                queue.Enqueue((current - 1, time + 1)); // 1초 추가
            }

            // +1로 이동
            if (current + 1 <= 100000 && !visited[current + 1])
            {
                visited[current + 1] = true;
                queue.Enqueue((current + 1, time + 1)); // 1초 추가
            }
        }
    }
}