using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 플레이어의 수 P
        // 방의 정원 M
        // 두 번째 줄부터 P개의 레벨 I, 닉네임 N

        StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();

        string[] input = reader.ReadLine().Split(); // 입력
        int p = int.Parse(input[0]);   // 플레이어 수
        int m = int.Parse(input[1]);   // 방 정원

        Player[] players = new Player[p];

        // 플레이어 정보 등록
        for (int i = 0; i < p; i++)
        {
            string[] inputPlayer = reader.ReadLine().Split();
            int level = int.Parse(inputPlayer[0]);
            string name = inputPlayer[1];
            players[i] = new Player(level, name);
        }

        for (int i = 0; i < p; i++)
        {
            List<Player> roomList = new List<Player>();
            if (!players[i].Check)
            {
                for (int j = i; j < p; j++)
                {
                    // 방이 가득찼으면 종료
                    if (roomList.Count == m)
                        break;

                    int level = players[j].Level;
                    string name = players[j].Nick;

                    // 플레이어가 방에 안들어갔고 처음 들어온 플레이어의 레벨 +- 10 범위에 있을 경우
                    if (!players[j].Check && players[i].Level - 10 <= level && players[i].Level + 10 >= level)
                    {
                        players[j].Check = true;
                        roomList.Add(new Player(level, name));
                    }
                }

                // 정렬
                roomList.Sort();

                if (roomList.Count == m)
                    stringBuilder.AppendLine("Started!");
                else
                    stringBuilder.AppendLine("Waiting!");

                foreach (Player player in roomList)
                    stringBuilder.AppendLine($"{player.Level} {player.Nick}");
            }
        }

        writer.Write(stringBuilder.ToString());

        reader.Close();
        writer.Close();
    }

    public class Player : IComparable<Player>
    {
        public int Level { get; set; }
        public string Nick { get; set; }
        public bool Check { get; set; } // 방에 들어갔는지 확인하는 변수

        public Player(int level, string nick)
        {
            this.Level = level;
            this.Nick = nick;
            Check = false; 
        }

        public int CompareTo(Player other)
        {
            return Nick.CompareTo(other.Nick);
        }
    }
}