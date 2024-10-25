using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;

public class Program
{
    private static int answer = 0;

    private static void Main(string[] args)
    {
        // 첫째 줄에 S
        // 둘째 줄에 T

        // 문자열의 뒤에 A를 추가한다
        // 문자열의 뒤에 B를 추가하고 문자열을 뒤집는다

        using StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();

        string inputS = reader.ReadLine();
        string inputT = reader.ReadLine();

        Solve(inputS, inputT);

        writer.Write(answer);
    }

    private static void Solve(string s, string t)
    {
        if (s.Length == t.Length)
        {
            if (s.Equals(t))
            {
                answer = 1;
            }
            return;
        }

        // T의 첫 글자가 'B'이면 첫 글자를 제거하고 뒤집음
        if (t[0] == 'B')
        {
            Solve(s, new string(t.Substring(1).Reverse().ToArray()));
        }

        // T의 마지막 글자가 'A'이면 마지막 글자를 제거함
        if (t[t.Length - 1] == 'A')
        {
            Solve(s, t.Substring(0, t.Length - 1));
        }
    }
}