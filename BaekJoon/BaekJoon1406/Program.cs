using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // 초기에 편집기에 입력되어 있는 문자열 >> 문자열 길이 N
        // 입력할 명령어 개수 정수 M
        // M개의 줄에 걸쳐 입력할 명령어
        // 명령어가 수행되기전 커서는 문장의 맨 뒤에 위치

        // L, D, B, P$

        StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();

        string input = reader.ReadLine();
        int m = int.Parse(reader.ReadLine());

        LinkedList<char> linkedList = new LinkedList<char>(input); // 입력된 문자열을 LinkedList로 변환
        linkedList.AddLast(' '); // 마지막에 공백을 추가해 커서 위치
        LinkedListNode<char> cursor = linkedList.Last; // 커서를 LinkedList의 마지막 위치로 설정

        for(int i = 0; i < m; i++)
        {
            string[] commands = reader.ReadLine().Split();
            string commandType = commands[0];

            switch (commandType)
            {
                case "L":
                    // 커서 왼쪽에 값이 있을 경우
                    if (cursor.Previous != null)
                        cursor = cursor.Previous;
                    break;
                case "D":
                    // 커서 오른쪽에 값이 있을 경우
                    if(cursor.Next != null)
                        cursor = cursor.Next;
                    break;
                case "B":
                    // 커서 왼쪽에 값이 있을 경우
                    if (cursor.Previous != null)
                        linkedList.Remove(cursor.Previous);
                    break;
                case "P":
                    // 커서 왼쪽에 새로운 문자를 넣는다
                    linkedList.AddBefore(cursor, char.Parse(commands[1]));
                    break;
            }
        }

        // 마지막에 추가한 공백 제거
        linkedList.RemoveLast();

        foreach(var x in linkedList)
            stringBuilder.Append(x);

        Console.WriteLine(stringBuilder.ToString());

        reader.Close();
        writer.Close();
    }
}