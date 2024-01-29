using System;
using System.Collections;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        // 상근이부터 턴 시작
        // 홀수, 짝수 판별
        if(n % 2 == 1)
        {
            // 홀수 승리
            Console.WriteLine("SK");
        }
        else
        {
            // 짝수 승리
            Console.WriteLine("CY");
        }
    }
}