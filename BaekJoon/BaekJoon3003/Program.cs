using System;
using System.Collections;
using System.ComponentModel;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int[] needPiece = { 1, 1, 2, 2, 2, 8 };
        int[] piece = Array.ConvertAll(input, int.Parse);
        int[] sum = new int[piece.Length];

        for(int i = 0; i < piece.Length; i++)
        {
            // 계산
            sum[i] = needPiece[i] - piece[i];

            // 출력
            Console.Write(sum[i] + " ");
        }
    }
}