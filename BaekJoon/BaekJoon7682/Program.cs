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

        using StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();


        string failed = "invalid";
        string success = "valid";
        string completed = "end";

        char[,] map = new char[3, 3];

        int oCount = 0;
        int xCount = 0;

        while (true)
        {
            string input = reader.ReadLine();

            if(input == completed)
            {
                break;
            }

            int index = 0;

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    map[i, j] = input[index];
                    index++;

                    if (map[i, j] == 'O')
                    {
                        oCount++;
                    }
                    else if (map[i, j] == 'X')
                    {
                        xCount++;
                    }
                }

                if(xCount == oCount + 1)
                {
                    if(xCount + oCount == 9 && Success(map, 'O'))
                    {

                    }
                }
            }
        }
    }

    private static bool Success(char[,] map, char type)
    {
        for(int i = 0; i < 3; i++)
        {
            if (map[0, i] == type && map[i, 1] == type && map[i, 2] == type)
            {
                return true;
            }
        }

        for(int i = 0; i < 3; i++)
        {
            if (map[i, 0] == type && map[i, 1] == type && map[i, 2] == type)
            {
                return true;
            }
        }

        return false;
    }
}