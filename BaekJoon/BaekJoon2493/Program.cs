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

        Stack<int> stack = new Stack<int>();

        for(int i = 0; i < n; i++)
        {
            int currentHeight = topArray[i];

            if(stack.Count == 0)
            {
                stack.Push(currentHeight);
            }
            else
            {
                if(stack.Count == 0)
                {
                    stringBuilder.Append(0);
                    stack.Push(currentHeight);
                }

                int height = stack.Peek();

                if (height > currentHeight)
                {
                    stringBuilder.Append(stack.Count);
                    stack.Push(height);
                }
                else
                {
                    stack.Pop();
                }
            }
        }

        writer.Write(stringBuilder.ToString());
    }
}