using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 지구 > 달로 가는 경우 우주선이 움직일 수 있는 방향 (왼쪽 대각, 아래, 오른쪽 대각)
        // 전에 움직인 방향으로 움직일 수 없다.

        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int n = input[0]; // 열
        int m = input[1]; // 행

        int[,] maps = new int[n,m];

        int result = int.MaxValue;
        int before = 2; // 방향 정보 없음 2 (-1, 0, 1)

        for(int i = 0; i < n; i++)
        {
            int[] inputCosts = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            for(int j = 0; j < m; j++)
            {
                maps[i,j] = inputCosts[j];
            }
        }

        for(int i = 0; i < m; i++)
        {
            result = Math.Min(result, Test(maps, 0, i, 2, n, m));
        }

        Console.WriteLine(result);
    }

    private static int Test(int[,] maps, int row, int col, int before, int n, int m)
    {
        if (row == n)
            return 0;

        int currentCost = maps[row, col]; // 현재 위치 가격
        int minCost = int.MaxValue; // 현재 위치에서 다음 위치로 이동할때 가장 작은 값을 저장할 변수

        for(int i = col - 1; i <= col + 1; i++)
        {
            // 이전에 이동한 방향이랑 같은지 확인
            if (i - col == before)
                continue;

            // 열이 배열 범위 안에 있는지 확인
            if (0 <= i && i < m)
            {
                // 다음 행, 새로운 열, 이동한 방향
                int nextCost = Test(maps, row + 1, i, i - col, n, m);
                minCost = Math.Min(minCost, currentCost + nextCost);
            }
        }

        return minCost;
    }
}