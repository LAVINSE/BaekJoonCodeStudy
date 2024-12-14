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
        using StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();

        int n = int.Parse(reader.ReadLine());
        int[] numbers = new int[n]; // 첫번째 줄 숫자
        bool[] visited = new bool[n + 1]; // 방문 체크

        List<int> cycleList = new(); // 사이클 확인하는 리스트

        for(int i = 1; i <= n; i++)
        {
            numbers[i] = i;
        }

        for(int i = 1; i <= n; i++)
        {
            visited[i] = true;
            //DFS(i, i);
            visited[i] = false;
        }
    }

    private static void DFS(int start, int end, int[] numbers, bool[] visited)
    {
        if (visited[numbers[start]] == false){

        }

        if (visited[numbers[end]] == false)
        {

        }
    }
}