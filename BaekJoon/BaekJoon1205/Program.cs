using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;

public class Program
{
    private static void Main(string[] args)
    {
        // 입력값
        string[] input = Console.ReadLine().Split();

        int n = 0;
        int myScore = 0;
        int p = 0;

        n = int.Parse(input[0]); // 입력 개수
        myScore = int.Parse(input[1]); // 내 점수
        p = int.Parse(input[2]); // 랭킹에 등록될 수 있는 점수의 개수

        List<int> rankList = new List<int>(); // 현재 기록된 점수 리스트

        int rankCount = 0;
        int myRank = 1;

        // 점수 입력
        string[] rankInput = Console.ReadLine().Split();

        // 리스트에 저장
        for(int i = 0; i< n; i++)
        {
            rankList.Add(int.Parse(rankInput[i]));
        }

        foreach(int rank in rankList)
        {
            // 내 점수가 저장된 점수보다 낮을 경우
            if(myScore < rank)
            {
                // 등수 하락
                myRank += 1;
            }
            // 내 점수가 저장된 점수랑 같을 경우
            else if(myScore == rank)
            {
                // 등수 같음
                myRank = myRank;
            }
            // 내 점수가 저장된 점수보다 높을 경우
            else
            {
                // 종료
                break;
            }

            // 등수 카운트 증가
            rankCount++;
        }

        // 등수 카운트가 랭킹에 등록될 점수 개수랑 같을 경우
        if(rankCount == p)
        {
            // 랭킹 리스트에 올라갈 수 없음 -1
            myRank = -1;
        }

        if(n == 0)
        {
            // 입력 개수가 없다면 1
            myRank = 1;
        }

        Console.WriteLine(myRank);
    }
}