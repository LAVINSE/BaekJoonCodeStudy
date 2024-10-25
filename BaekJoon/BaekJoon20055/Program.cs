using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Security.Principal;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 번호 N
        // 내구도가 0인 칸의 개수 제한 K

        using StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();

        int[] inputs = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
        int[] inputDurability = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

        int n = inputs[0];
        int k = inputs[1];

        ConveyorSystem conveyorSystem = new ConveyorSystem(n, k, inputDurability);
        writer.WriteLine(conveyorSystem.Run());
    }
}

public class ConveyorSystem
{
    private int k; // 내구도가 0인 칸의 개수 제한
    private int n; // 컨베이어 벨트의 크기
    private int step; // 현재 단계 수
    private List<Belt> conveyor; // 컨베이어 벨트 (Belt 리스트)
    private bool[] robots; // 로봇이 있는지 여부를 저장하는 배열

    public ConveyorSystem(int n, int k, int[] durability)
    {
        this.n = n;
        this.k = k;
        this.step = 0;
        int size = 2 * n; // 컨베이어 벨트의 총 크기 (2 * N)

        conveyor = new List<Belt>();
        robots = new bool[size];

        // 내구도 초기화
        for (int i = 0; i < size; i++)
        {
            conveyor.Add(new Belt(durability[i]));
        }
    }

    // 컨베이어 벨트의 실행
    public int Run()
    {
        while (CountDurabilityZero() < k)
        {
            MoveConveyor(); // 컨베이어 벨트 회전
            MoveRobots();   // 로봇 이동
            PlaceRobot();   // 로봇 올리기
            step++;
        }
        return step;
    }

    // 내구도가 0인 칸의 개수를 세는 메서드
    private int CountDurabilityZero()
    {
        int count = 0;
        foreach (Belt belt in conveyor)
        {
            if (belt.durability <= 0)
            {
                count++;
            }
        }
        return count;
    }

    // 컨베이어 벨트 회전
    private void MoveConveyor()
    {
        // 벨트 회전
        Belt lastBelt = conveyor[conveyor.Count - 1];
        conveyor.RemoveAt(conveyor.Count - 1);
        conveyor.Insert(0, lastBelt);

        // 로봇 회전
        bool lastRobot = robots[robots.Length - 1];
        for (int i = robots.Length - 1; i > 0; i--)
        {
            robots[i] = robots[i - 1];
        }
        robots[0] = lastRobot;

        // 내리는 위치에 로봇이 있으면 내려야 함
        if (robots[n - 1])
        {
            robots[n - 1] = false;
        }
    }

    // 로봇을 한 칸씩 이동
    private void MoveRobots()
    {
        for (int i = n - 2; i >= 0; i--) // 로봇을 내리는 위치 전부터 역순으로 이동
        {
            if (robots[i] && !robots[i + 1] && conveyor[i + 1].durability > 0)
            {
                // 로봇 이동
                robots[i] = false;
                robots[i + 1] = true;
                conveyor[i + 1].durability--;

                // 내리는 위치에 도달한 로봇은 즉시 내림
                if (i + 1 == n - 1)
                {
                    robots[i + 1] = false;
                }
            }
        }
    }

    // 로봇 올리기
    private void PlaceRobot()
    {
        if (conveyor[0].durability > 0 && !robots[0])
        {
            robots[0] = true;
            conveyor[0].durability--;
        }
    }

    // 벨트 클래스 정의
    private class Belt
    {
        public int durability; // 내구도

        public Belt(int durability)
        {
            this.durability = durability;
        }
    }
}