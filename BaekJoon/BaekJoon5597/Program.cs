using System;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 학생 수 
        int[] student = new int[31];

        // 제출자
        for(int i = 0; i < 28; i++)
        {
            int n = int.Parse(Console.ReadLine());
            // 제출한 학생들 값 지정
            student[n] = 5;
        }

        // 출력
        for(int i = 1; i < 31; i++)
        {
            // 지정된 값이 아닐 경우
            if (student[i] != 5)
            {
                Console.WriteLine(i);
            }
        }
    }
}