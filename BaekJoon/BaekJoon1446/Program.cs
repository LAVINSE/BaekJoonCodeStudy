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
        // 지름길의 개수 N과 고속도로의 길이 D
        // N개의 줄에 지름길의 시작 위치, 도착 위치, 지름길의 길이

        StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        //StringBuilder stringBuilder = new StringBuilder();

        int[] inputs = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
        int n = inputs[0];
        int d = inputs[1];
        Node[] nodes = new Node[n];
        int[] minDistances = new int[d + 1];

        for(int i = 0; i < n; i++)
        {
            int[] info = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
            nodes[i] = new Node(info[0], info[1], info[2]);
        }

        Array.Sort(nodes, (x, y) => x.startPos.CompareTo(y.startPos));

        for(int i = 0; i <= d; i++)
        {
            minDistances[i] = i;
        }

        foreach(Node node in nodes)
        {
            if (node.endPos <= d && node.endPos - node.startPos > node.distance)
            {
                minDistances[node.endPos] = Math.Min(minDistances[node.endPos], minDistances[node.startPos] + node.distance);
            }

            for (int i = node.startPos + 1; i <= d; i++)
            {
                minDistances[i] = Math.Min(minDistances[i], minDistances[i - 1] + 1);
            }
        }

        writer.Write(minDistances[d]);

        reader.Close();
        writer.Close();
    }

    public class Node 
    {
        public int startPos;
        public int endPos;
        public int distance;

        public Node(int startPos, int endPos, int distance)
        {
            this.startPos = startPos;
            this.endPos = endPos;
            this.distance = distance;
        }
    }
}