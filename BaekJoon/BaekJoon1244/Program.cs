using System;
using System.Security.Cryptography;

public class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); // 스위치의 개수 입력 받기
        int[] switchArray = Array.ConvertAll(Console.ReadLine().Split(), int.Parse); // 스위치의 상태 입력 받기
        int studentCount = int.Parse(Console.ReadLine()); // 학생 수 입력 받기

        for (int k = 0; k < studentCount; k++)
        {
            string[] input = Console.ReadLine().Split(); // 학생의 성별, 번호 입력
            int gender = int.Parse(input[0]);
            int number = int.Parse(input[1]);

            // 남학생 일 경우
            if (gender == 1)
            {
                // 부여 받은 번호 배수 EX) 3, 6
                for (int i = number; i <= n; i += number)
                {
                    // 스위치의 상태를 바꾼다
                    switchArray[i - 1] = (switchArray[i - 1] == 0) ? 1 : 0;
                }      
            }
            // 여학생 일 경우
            else
            {
                // 부여 받은 위치의 상태를 먼저 바꾼다
                switchArray[number - 1] = (switchArray[number - 1] == 0) ? 1 : 0;

                // 왼쪽에 있는 스위치와, 오른쪽에 있는 스위치가 배열 범위에 있고, 왼쪽 스위치와 오른쪽 스위치 상태가 같을 때까지 반복
                for (int i = 1; number - i >= 1 && number + i <= n &&
                    switchArray[number - i - 1] == switchArray[number + i - 1]; i++) 
                {
                    // 양옆 스위치 상태 변경
                    switchArray[number - i - 1] = (switchArray[number - i - 1] == 0) ? 1 : 0;
                    switchArray[number + i - 1] = (switchArray[number + i - 1] == 0) ? 1 : 0; 
                }
            }
        }

        // 출력
        for (int i = 0; i < n; i++)
        {
            // 스위치 상태 출력
            Console.Write(switchArray[i] + " ");

            // 20개의 숫자를 출력했다면 줄바꾸기
            if ((i + 1) % 20 == 0)
            {
                Console.WriteLine();
            }  
        }
    }
}