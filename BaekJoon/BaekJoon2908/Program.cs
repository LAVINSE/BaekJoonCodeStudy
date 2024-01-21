using System;
using System.Collections;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        char[] aArray = input[0].ToCharArray();
        char[] bArray = input[1].ToCharArray();
        int a;
        int b;

        // 뒤집기
        Array.Reverse(aArray);
        Array.Reverse(bArray);

        // 정수로 변환
        a = int.Parse(aArray);
        b = int.Parse(bArray);

        // 출력
        if(a > b)
        {
            Console.WriteLine(a);
        }
        else
        {
            Console.WriteLine(b);
        }
    }
}