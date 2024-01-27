using System;
using System.Collections;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        do
        {
            string[] input = Console.ReadLine().Split();
            int[] triangle = Array.ConvertAll(input, int.Parse);

            // 000 입력 종료
            if (triangle.Contains(0)) return;

            // 오름차순 정렬
            Array.Sort(triangle);

            // Invalid 조건 확인
            if (triangle[2] < triangle[0] + triangle[1])
            {
                if (triangle[0] == triangle[1] && triangle[1] == triangle[2])
                {
                    Console.WriteLine("Equilateral");
                }
                else if (triangle[0] == triangle[1] || triangle[1] == triangle[2] || triangle[2] == triangle[0])
                {
                    Console.WriteLine("Isosceles");
                }
                else if (triangle[0] != triangle[1] && triangle[1] != triangle[2])
                {
                    Console.WriteLine("Scalene");
                }
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        } while (true);
    }
}