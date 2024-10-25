using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;

public class Program
{
    private static int answer = 0;

    private static void Main(string[] args)
    {

        // 주사위 1 ~ 6
        // 게임 크기 10 * 10 = 100
        // 1 ~ 100 까지 순서대로
        // i + 주사위 숫자 이동 <= 100 
        // 사다리의 수 N, 뱀의 수 M
        // N개의 줄에는 x번칸에 도착 > y번 칸으로 이동
        // M개의 줄에는 U번칸에 도착 > V번 칸으로 이동

        using StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();

        int[] inputs = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

        int n = inputs[0];
        int m = inputs[1];

        List<Ladder> ladderList = new List<Ladder>();
        List<Snake> SnakeList = new List<Snake>();

        for (int i = 0; i < n; i++)
        {
            int[] pos = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
            ladderList.Add(new Ladder(pos[0], pos[1]));
        }

        for (int i = 0; i < n; i++)
        {
            int[] pos = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
            SnakeList.Add(new Snake(pos[0], pos[1]));
        }
    }
}

public class Ladder
{
    public int x;
    public int y;

    public Ladder(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

public class Snake
{
    public int u;
    public int v;

    public Snake(int u, int v)
    {
        this.u = u;
        this.v = v;
    }
}