using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 연산의 개수 N
        // N개의 줄에 정수 X >> X가 자연수면 배열에 추가
        // X가 0이라면 배열에서 가장 작은 값 출력 그 값을 제거

        StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(reader.ReadLine());
        //int[] inputs = new int[n];
        List<int> inputs = new List<int>(n);

        StringBuilder stringBuilder = new StringBuilder();

        for(int i = 0; i < n; i++)
        {
            int x = int.Parse(reader.ReadLine());

            if(x > 0)
            {
                inputs.Add(x);
            }
            else if(x == 0)
            {
                if(inputs.Count != 0)
                {
                    int removeInput = inputs.OrderBy(x => x).First();
                    stringBuilder.AppendLine(removeInput.ToString());
                    inputs.Remove(removeInput);
                }
                else
                {
                    stringBuilder.AppendLine(0.ToString());
                }
                
            }
        }

        Console.Write(stringBuilder);

        reader.Close();
        writer.Close();
    }
}