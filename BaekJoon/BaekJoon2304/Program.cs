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
        // 기둥의 개수 정수 N
        // N개의 줄에 각 기둥의 왼쪽면의 위치를 나타내는 정수 L, 높이를 나타내는 H가 한개의 빈칸을 사이에 두고 주어진다
        StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        //StringBuilder stringBuilder = new StringBuilder();

        int n = int.Parse(reader.ReadLine());
        int maxHeight = 0;
        int maxIndex = 0;
        int area = 0;
        int currentHeight = 0;
        Pillars[] pillars = new Pillars[n];

        for(int i = 0; i < n; i++)
        {
            int[] datas = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
            int posL = datas[0];
            int height = datas[1];
            pillars[i] = new Pillars(posL, height);
        }

        // 기둥 위치를 기준으로 오름차순 정렬
        Array.Sort(pillars, (a, b) => a.PosL.CompareTo(b.PosL));

        // 가장 높은 기둥의 정보를 저장
        for (int i = 0; i < n; i++)
        {
            if (pillars[i].Height > maxHeight)
            {
                // 가장 높은 기둥의 높이와 인덱스를 저장
                maxHeight = pillars[i].Height;
                maxIndex = i;
            }
        } 

        // 가장 높은 기둥을 중심으로 왼쪽 계산
        for(int i = 0; i < maxIndex; i++)
        {
            // 현재 기둥의 높이가 지금까지의 currentHeight 보다 높은지 확인
            // 더 높은 기둥을 만날 때마다 높이를 갱신해 면적 계산
            if (pillars[i].Height > currentHeight)
                currentHeight = pillars[i].Height;

            // 한줄씩 면적 계산
            area += currentHeight * (pillars[i + 1].PosL - pillars[i].PosL);
        }

        // 높이 초기화
        currentHeight = 0;

        // 가장 높은 기둥을 중심으로 오른쪽 계산
        for(int i = n - 1; i > maxIndex; i--)
        {
            if (pillars[i].Height > currentHeight)
                currentHeight = pillars[i].Height;

            area += currentHeight * (pillars[i].PosL - pillars[i - 1].PosL);
        }

        // 가장 높은 기둥의 면적 추가
        area += maxHeight;

        writer.Write(area);

        reader.Close();
        writer.Close();
    }

    private class Pillars
    {
        public int PosL { get; }
        public int Height { get; }

        public Pillars(int posL, int height)
        {
            PosL = posL;
            Height = height;
        }
    }
}