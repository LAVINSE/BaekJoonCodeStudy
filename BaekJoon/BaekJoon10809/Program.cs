using System;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine();

        for(char i = 'a'; i <= 'z'; i++)
        {
            // 같은지 확인
            if (input.Contains(i))
            {
                // 몇번째 위치에 있는지 출력
                Console.Write(input.IndexOf(Convert.ToChar(i)));
                Console.Write(" ");
            }
            else
            {
                // 포함되어 있지 않다면 출력
                Console.Write("-1 ");
            }
        }
    }
}