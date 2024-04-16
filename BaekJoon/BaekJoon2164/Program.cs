using System;
using System.Collections.Generic;

public class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        Queue<int> queue = new Queue<int>();

        for(int i = 1; i<= n; i++)
        {
            queue.Enqueue(i);
        }

        while(queue.Count > 1)
        {
            queue.Dequeue();
            int temp = queue.Peek();
            queue.Dequeue();
            queue.Enqueue(temp);
        }

        Console.WriteLine(queue.Peek());
    }
}