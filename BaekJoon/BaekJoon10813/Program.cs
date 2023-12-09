using System;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        string[] InputNM = Console.ReadLine().Split();

        // 바구니 N개
        int N = int.Parse(InputNM[0]);
        // M번 공 바꾸기
        int M = int.Parse(InputNM[1]);
        // 바구니 N개 배열
        int[] NArray = new int[N + 1];
        // 저장 공간
        int Temp;


        // 바구니 번호와 같은 번호 공 넣기
        NArray[0] = 0;
        for (int i = 1; i <= N; i++)
        {
            NArray[i] = i;
        }

        // M번 바꿈
        for(int w =0; w < M; w++)
        {
            string[] InputIJ = Console.ReadLine().Split();

            int i = int.Parse(InputIJ[0]);
            int j = int.Parse(InputIJ[1]);

            // 공 교환
            Temp = NArray[i];
            NArray[i] = NArray[j];
            NArray[j] = Temp;
        }

        // 출력
        for(int w =1; w <= N; w++)
        {
            Console.Write(NArray[w] + " ");
        }
    }
}