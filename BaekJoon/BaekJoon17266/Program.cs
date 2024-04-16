using System;

public class Program
{
    private static void Main(string[] args)
    {
        // 높이와 빛의 밝기는 똑같다

        int n = int.Parse(Console.ReadLine()); // 굴다리의 길이
        int m = int.Parse(Console.ReadLine()); // 가로등의 개수
        int[] xPosArray = Array.ConvertAll(Console.ReadLine().Split(), int.Parse); // 가로등의 위치

        // 높이 (int 형식의 변수가 가질 수 있는 가장 작은 값)
        int height = int.MinValue;

        height = Math.Max(height, xPosArray[0]); // 첫 번째 가로등까지의 거리
        height = Math.Max(height, n - xPosArray[m - 1]); // 마지막 가로등까지의 거리

        // 가로등이 1개 이상일 경우
        if (m > 1)
        {
            for (int i = 0; i < m - 1; ++i)
            {
                // 현재 가로등과 다음 가로등 사이의 거리
                int diff = xPosArray[i + 1] - xPosArray[i];

                // 거리의 중간 지점에 설치 했을때 필요한 밝기
                // diff을 2.0으로 나눠 정수로 올림하여 변환
                diff = (int)Math.Ceiling(diff / 2.0); 

                // 현재 까지의 높이와 diff의 높이를 비교하여 더 큰값 선택
                height = Math.Max(height, diff);
            }
        }

        // 높이 출력
        Console.WriteLine(height);
    }
}