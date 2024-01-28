using System;
using System.Collections;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 문제 참고 자료 https://www.youtube.com/watch?v=dTnuHZYgpaI&list=PLlf776vnQs4iyN3dtwKzZwLIpf7JXt9Ev
        // 시간초과 해결해야됨
        int m = int.Parse(Console.ReadLine());
        int all = (1 << 21) - 1;
        int answer = 0;

        for (int i = 0; i < m; i++)
        {
            string[] input = Console.ReadLine().Split();
            int x = int.Parse(input[1]);

            if (input[0] == "all")
            {
                answer = all;
            }
            else if (input[0] == "Empty")
            {
                answer = 0;
            }
            else if (input[0] == "add")
            {
                answer |= (1 << x);
            }
            else if (input[0] == "remove")
            {
                answer &= ~(1 << x);
            }
            else if (input[0] == "check")
            {
                Console.WriteLine(answer = (answer & (1 << x)) != 0 ? 1 : 0);
            }
            else if (input[0] == "toggle")
            {
                answer ^= (1 << x);
            }
        }
    }
}