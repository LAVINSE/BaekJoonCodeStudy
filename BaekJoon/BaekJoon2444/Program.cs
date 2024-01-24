using System;
using System.Collections;
using System.ComponentModel;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        // N 만큼 반복
        for(int i = 0; i < n; i++)
        {
            for(int j =0; j < n - i - 1 ; j++)
            {
                // 빈 공간 출력
                Console.Write(" ");
            }

            for(int j = 0; j < i * 2 + 1; j++)
            {
                // 별 출력
                Console.Write("*");
            }

            Console.WriteLine();
        }

        // 거꾸로
        for(int  i = n - 1  ; i >= 1; i--)
        {
            for(int j = 0; j < n - i; j++)
            {
                // 빈 공간 출력
                Console.Write(" ");
            }

            for (int j = 0; j < i * 2 - 1 ; j++)
            {
                // 별 출력
                Console.Write("*");
            }

            Console.WriteLine();
        }

    }
}