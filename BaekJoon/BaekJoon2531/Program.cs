using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 회전 초밥 벨트에 놓인 접시의 수 N, 초밥의 가짓 수 D, 연속해서 먹는 접시의 수 K, 쿠폰 번호 C
        // 두 번째 줄부터 N개의 줄에 초밥의 종류

        StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        //StringBuilder stringBuilder = new StringBuilder();

        int[] inputs = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
        int n = inputs[0];
        int d = inputs[1];
        int k = inputs[2];
        int c = inputs[3];

        int[] sushis = new int[n];
        int[] eatSushis = new int[d + 1];
        int count = 0;
        int max = 0;

        // 초밥의 종류를 입력받아 저장
        for(int i = 0; i < n; i++)
        {
            sushis[i] = int.Parse(reader.ReadLine());
        }

        // k개의 접시를 연속해서 먹을경우 초기 먹은 횟수 기록
        for(int i = 0; i < k; i++)
        {
            // 해당 종류의 초밥을 안 먹었을 경우 개수 증가
            if (eatSushis[sushis[i]] == 0)
                count++;

            // 먹은 횟수 증가
            eatSushis[sushis[i]]++;
        }

        // 쿠폰 초밥이 현재 먹는 종류에 포함되지 않으면 +1
        max = eatSushis[c] == 0 ? count + 1 : count;

        for (int i = 1; i < n; i++)
        {
            // 이전 접시 제거
            int removeIndex = (i - 1) % n;
            eatSushis[sushis[removeIndex]]--;
            if (eatSushis[sushis[removeIndex]] == 0)
                count--;

            // 새로운 접시 추가
            int addIndex = (i + k - 1) % n;
            if (eatSushis[sushis[addIndex]] == 0)
                count++;
            eatSushis[sushis[addIndex]]++;

            // 쿠폰 초밥 고려하여 최대값 업데이트
            int currentMax = eatSushis[c] == 0 ? count + 1 : count;
            if (currentMax > max)
                max = currentMax;
        }

        writer.Write(max);

        reader.Close();
        writer.Close();
    }
}