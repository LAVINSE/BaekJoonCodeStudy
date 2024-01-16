using System;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 과목의 개수
        int n = int.Parse(Console.ReadLine());
        // 성적
        string[] inputGrade = Console.ReadLine().Split();

        float[] grade = Array.ConvertAll(inputGrade, float.Parse);
        float maxGrade = float.MinValue;
        float sum = 0;
        float average = 0;

        // 최대값 찾기
        for (int i = 0; i < n; i++)
        {
            if (maxGrade < grade[i])
            {
                maxGrade = grade[i];
            }
        }

        // 계산
        for (int i = 0; i < n; i++)
        {
            sum += (grade[i] / maxGrade) * 100;
        }

        // 평균
        average = sum / n;

        // 출력
        Console.WriteLine(average);
    }
}