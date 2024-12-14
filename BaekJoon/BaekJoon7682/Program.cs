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

        string failed = "invalid";
        string success = "valid";
        string completed = "end";

        char o = 'O';
        char x = 'X';

        char[,] map = new char[3, 3];

        while (true)
        {
            string input = reader.ReadLine();
            if (input == completed)
            {
                break;
            }

            int oCount = 0;
            int xCount = 0;
            int index = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    map[i, j] = input[index++];
                    if (map[i, j] == o)
                    {
                        oCount++;
                    }
                    else if (map[i, j] == x)
                    {
                        xCount++;
                    }
                }
            }

            // 틱택토의 기본 규칙 검증
            if (xCount != oCount && xCount != oCount + 1)
            {
                stringBuilder.AppendLine(failed);
                continue;
            }

            bool xWins = Success(map, x);
            bool oWins = Success(map, o);

            if (xWins && oWins)
            {
                // 둘 다 이기는 경우는 규칙 위반
                stringBuilder.AppendLine(failed);
            }
            else if (xWins && xCount == oCount + 1)
            {
                // X가 이기려면 X의 수가 O보다 정확히 1개 많아야 함
                stringBuilder.AppendLine(success);
            }
            else if (oWins && xCount == oCount)
            {
                // O가 이기려면 X와 O의 수가 같아야 함
                stringBuilder.AppendLine(success);
            }
            else if (!xWins && !oWins && xCount + oCount == 9)
            {
                // 무승부인 경우(판이 꽉 찼으나 승자가 없음)
                stringBuilder.AppendLine(success);
            }
            else
            {
                // 나머지는 모두 규칙 위반
                stringBuilder.AppendLine(failed);
            }
        }

        writer.Write(stringBuilder.ToString());
    }

    private static bool Success(char[,] map, char type)
    {
        // 가로 줄 확인
        for (int i = 0; i < 3; i++)
        {
            if (map[i, 0] == type && map[i, 1] == type && map[i, 2] == type)
            {
                return true;
            }
        }

        // 세로 줄 확인
        for (int i = 0; i < 3; i++)
        {
            if (map[0, i] == type && map[1, i] == type && map[2, i] == type)
            {
                return true;
            }
        }

        // 대각선 확인 (좌상단 -> 우하단)
        if (map[0, 0] == type && map[1, 1] == type && map[2, 2] == type)
        {
            return true;
        }

        // 대각선 확인 (우상단 -> 좌하단)
        if (map[0, 2] == type && map[1, 1] == type && map[2, 0] == type)
        {
            return true;
        }

        // 승리 조건에 해당하지 않음
        return false;
    }
}