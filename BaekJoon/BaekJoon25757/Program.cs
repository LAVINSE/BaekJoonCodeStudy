using System;
using System.Collections;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        string gameType = input[1];

        int me = 1;
        int count = 0;

        // 중복 요소 없는 자료구조
        HashSet<string> nameHashList = new HashSet<string>(); 

        // 참가자 >> HashSet 추가
        for(int i = 0; i < n; i++)
        {
            string inputName = Console.ReadLine();
            nameHashList.Add(inputName);
        }

        // 게임 타입
        switch (gameType)
        {
            // 윷놀이 2명이서 플레이 >> 참가하는 모든 인원 수
            case "Y":
                count = nameHashList.Count;
                break;   

            // 같은 그림 찾기 3명이서 플레이 >> 참가하는 모든 인원 수 / 3 - 자신 , 인원 부족하면 게임 시작 X
            case "F":
                count = (nameHashList.Count / (3 - me));
                break;

            // 원카드 4명이서 플레이 >> 참가하는 모든 인원 수 / 4 - 자신, 인원 부족하면 게임 시작 X
            case "O":
                count = (nameHashList.Count / (4 - me));
                break;
        }

        // 출력
        Console.WriteLine(count);
    }
}