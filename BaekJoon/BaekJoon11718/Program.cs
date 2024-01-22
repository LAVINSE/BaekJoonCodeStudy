using System;
using System.Collections;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            string input = Console.ReadLine();
            Console.WriteLine(input);

            // null 인지 공백인지 확인
            if (string.IsNullOrEmpty(input)) return;
        }
    }
}