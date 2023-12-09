using System;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        /*
         * Ex) i =1, j =2, k =3
         * - 3 3 0 0 0
         * >> i =3, j =4, k =4 
         * - 3 3 4 4 0
         * >> i =1, j =4, k =1
         * - 1 1 1 1 0
         * >> i =2 , j =2, k =2
         * - 1 2 1 1 0
         */

        // 바구니 N개, M번 공 넣는 횟수
        string[] NM = Console.ReadLine().Split();

        int N = int.Parse(NM[0]);

        int[] NArray = new int[N + 1];

        int M = int.Parse(NM[1]);

        
        for (int q = 0; q < M; q++)
        {
            // IJK 입력 받기
            string[] input = Console.ReadLine().Split();

            int i;
            int j = int.Parse(input[1]);

            int k = int.Parse(input[2]);

            for (i = int.Parse(input[0]); i <= j; i++)
            {
                NArray[i] = k;
            }
        }

        for (int q = 1; q <= N; q++)
        {
            Console.Write(NArray[q] + " ");
        }
    }
}