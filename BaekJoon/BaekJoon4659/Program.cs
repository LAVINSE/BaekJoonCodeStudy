using System;
using System.Collections;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();

        char[] needArray = { 'a', 'e', 'i', 'o', 'u' };
        bool isCheck = true;
        
        while (true)
        {
            string input = Console.ReadLine();

            // true : 모음, false : 자음 
            bool[] checkArray = new bool[input.Length]; 

            isCheck = true;

            if (input == "end") { break; }

            // 모음 하나를 반드시 포함 (확인하기)
            for (int i = 0; i < input.Length; i++)
            {
                for (int v = 0; v < needArray.Length; v++)
                {
                    if (input[i] == needArray[v])
                    {
                        checkArray[i] = true;
                    }
                }
            }

            for (int i = 0; i < checkArray.Length; i++)
            {
                //같은 글자가 연속적으로 두번 오면 안되나, ee 와 oo는 허용
                if (input.Length >= 2 && i < input.Length - 1)
                {
                    if (input[i] == input[i + 1])
                    {
                        if (input[i] == 'e' || input[i] == 'o') continue;

                        isCheck = false;
                    }
                }

                //모음이 3개 혹은 자음이 3개 연속으로 X
                if (input.Length >= 3 && i < input.Length - 2)
                {
                    if (checkArray[i] == checkArray[i + 1] && checkArray[i + 1] == checkArray[i + 2])
                    {
                        isCheck = false;
                    }
                }
            }

            // 전부 자음인 경우
            if (checkArray.All(x => x == false))
            {
                isCheck = false;
            }

            sb.AppendLine(isCheck ? $"<{input}> is acceptable." : $"<{input}> is not acceptable.");
        }

        Console.Write(sb);
    }
}