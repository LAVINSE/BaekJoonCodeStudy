using System;
using System.Collections;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        string inputUpper = Console.ReadLine().ToUpper();
        int[] asciiInputArray = new int[(int)'Z' +1];
        char answer = '?';
        int count = 0;

        for (int i = 0; i < inputUpper.Length; i++){
            // 알파벳 수
            asciiInputArray[inputUpper[i]]++;
        }

        for(int i = 'A'; i <= 'Z'; i++)
        {
            // 사용된 알파벳 수 비교 (전보다 많을 경우)
            if (asciiInputArray[i] > count)
            {
                // 사용된 알파벳 수
                count = asciiInputArray[i];
                // 출력할 알파벳 
                answer = (char)i;
            }
            // 사용된 알파벳 수가 같을 경우
            else if (asciiInputArray[i] == count)
            {
                // 출력할 ? 
                answer = '?';
            }
        }

        Console.WriteLine(answer);
    }
}