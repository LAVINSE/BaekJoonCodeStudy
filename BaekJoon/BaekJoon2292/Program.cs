using System;
using System.Collections;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        int inputN = int.Parse(Console.ReadLine());
        int countLine = 1;
        int currentRoom = 1;

        
        while (inputN > currentRoom)
        {
            // 1, 7, 19 ...
            currentRoom += 6 * (countLine - 1);

            // 최소 거리
            countLine++;
        }

        // 입력 값이 1일 경우
        if(inputN == 1)
        {
            Console.WriteLine(countLine);
        }
        else
        {
            // 1부터 시작이여서 -1 해주기
            Console.WriteLine(countLine - 1);
        }
    }
}