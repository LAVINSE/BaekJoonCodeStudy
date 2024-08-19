using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        string input = Console.ReadLine();
        char[] inputs = input.ToCharArray();

        int countZero = 0;
        int countOne = 0;

        StringBuilder stringBuilder = new StringBuilder();

        for(int i = 0; i < inputs.Length; i++)
        {
            if (inputs[i] == '0')
                countZero++;
            else
                countOne++;
        }

        countZero /= 2;
        countOne /= 2;

        for(int i = 0;i < inputs.Length && countOne != 0; i++)
        {
            if (inputs[i] == '1')
            {
                countOne--;
                inputs[i] = '!';
            }
        }

        for(int i = inputs.Length - 1; i >= 0 && countZero != 0; i--)
        {
            if (inputs[i] == '0')
            {
                countZero--;
                inputs[i] = '!';
            }
        }

        for(int i = 0; i < inputs.Length; i++)
        {
            if (inputs[i] != '!')
            {
                stringBuilder.Append(inputs[i]);
            }
        }

        Console.WriteLine(stringBuilder.ToString());
    }
}