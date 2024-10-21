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
        // 첫째 줄에 S
        // 둘째 줄에 T

        // 문자열의 뒤에 A를 추가한다
        // 문자열의 뒤에 B를 추가하고 문자열을 뒤집는다

        using StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();

        string inputS = Console.ReadLine();
        string inputT = Console.ReadLine();
    }
}