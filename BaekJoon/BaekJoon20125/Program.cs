using System;
using System.Collections;
using System.Text;

public class Program
{
    // 심장 위치를 찾는다
    private static void FindHeart(string[] array, int n, out int x, out int y)
    {
        // 초기화
        x = y = -1;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (array[i][j] == '*')
                {
                    x = i + 1;
                    y = j;
                    return;
                }
            }
        }
    }

    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[] array = new string[n];
        int x;
        int y;
        int answer = 0;
        int subX = 0;
        int subY = 0;

        // 문자 입력
        for (int i = 0; i < n; i++)
            array[i] = Console.ReadLine();

        // 심장 위치 찾기
        FindHeart(array, n, out x, out y);

        // 심장 위치 출력
        Console.WriteLine($"{x + 1} {y + 1}");

        // 왼쪽으로 이동 하면서 왼쪽 팔 길이 체크
        for (int i = 1; y - i >= 0; i++)
        {
            if (array[x][y - i] != '*')
                break;
            answer++;
        }

        // 출력, 초기화
        Console.Write($"{answer} ");
        answer = 0;

        // 오른쪽으로 이동 하면서 오른쪽 팔 길이 체크
        for (int i = 1; y + i < n; i++)
        {
            if (array[x][y + i] != '*')
                break;
            answer++;
        }

        // 출력, 초기화
        Console.Write($"{answer} ");
        answer = 0;

        // 아래로 이동하면서 허리 길이 체크
        for (int i = 1; x + i < n; i++)
        {
            // 허리가 끝나는 위치 저장
            if (array[x + i][y] != '*')
            {
                subX = x + i - 1;
                subY = y;
                break;
            }
            answer++;
        }

        // 출력, 초기화
        Console.Write($"{answer} ");
        answer = 0;

        // 왼쪽 대각선으로 내려가면서 다리 길이 체크
        for (int i = 1; subX + i < n; i++)
        {
            if (array[subX + i][subY - 1] != '*')
                break;
            answer++;
        }

        // 출력, 초기화
        Console.Write($"{answer} ");
        answer = 0;

        // 오른쪽 대각선으로 내려가면서 다리 길이 체크
        for (int i = 1; subX + i < n; i++)
        {
            if (array[subX + i][subY + 1] != '*')
                break;
            answer++;
        }

        // 출력
        Console.Write($"{answer} ");
    }
}