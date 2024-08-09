using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 공백 없이 숫자 입력
        // 다음 숫자가 연속된 수가 아닐 때 최솟값

        string input = Console.ReadLine();
        int inputLength = input.Length;
        int currentNumber = 1;
        int index = 0;

        while (index < inputLength)
        {
            string currentString = currentNumber.ToString();

            foreach (char c in currentString)
            {
                if (c == input[index])
                {
                    index++;
                    if (index == inputLength)
                    {
                        break;
                    }
                }
            }

            currentNumber++;
        }

        Console.WriteLine(currentNumber - 1);
    }
}