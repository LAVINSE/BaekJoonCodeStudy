using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 탑의 수를 나타내는 정수 N
        // N개의 탑들의 높이

        using StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();

        int n = int.Parse(reader.ReadLine());
        int[] topArray = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

        Stack<(int index, int height)> stack = new Stack<(int, int)>(); // 인덱스와 높이를 함께 저장

        for (int i = 0; i < n; i++)
        {
            int currentHeight = topArray[i];

            // 스택이 비어 있지 않고 현재 탑이 스택의 탑보다 높을 때까지 pop
            while (stack.Count > 0 && stack.Peek().height < currentHeight)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                stringBuilder.Append("0 ");
            }
            else
            {
                stringBuilder.Append($"{stack.Peek().index + 1} ");
            }

            // 현재 탑의 인덱스와 높이를 스택에 push
            stack.Push((i, currentHeight));
        }

        writer.Write(stringBuilder.ToString().TrimEnd());
    }
}