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

        string input = reader.ReadLine();
        char a = 'a';
        char b = 'b';

        int countA = 0;
        int countB = 0;
        int min = int.MaxValue;


        // A의 개수 확인
        for(int i = 0; i < input.Length; i++)
        {
            if (input[i] == a)
                countA++;
        }

        // 연속된 countA개의 문자 중에서 B가 몇개인지 확인
        for(int i = 0; i < countA; i++)
        {
            if (input[i] == b)
                countB++;
        }

        // a 또는 b가 없다면 옮길 필요 없음
        if(countA == 0 || countB == 0)
        {
            writer.Write(0);
            reader.Close();
            writer.Close();
            return;
        }

        for(int i = 1; i < input.Length; i++)
        {
            // 왼쪽 끝 요소를 제거 할때 b 이면 감소
            if (input[(i - 1) % input.Length] == b)
                countB--;

            // 새롭게 포함되는 요소가 b이면 증가
            if (input[(i + countA - 1) % input.Length] == b)
                countB++;

            min = Math.Min(min, countB);
        }

        writer.Write(min);

        reader.Close();
        writer.Close();
    }
}