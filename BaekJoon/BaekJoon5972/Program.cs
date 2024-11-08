using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        // N개의 헛간
        // 소들의 길인 M개의 양방향 길
        // 연결된 노드 사이에 있는 I 마리 소
        
        using StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();

        int[] countInputs = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

        int n = countInputs[0];
        int m = countInputs[1];

        List<List<NodeInfo>> nodeList = new List<List<NodeInfo>>();

        Queue<int> queue = new Queue<int>();
        int[] cowCounts = new int[n + 1];

        for (int i = 0; i < n + 1; i++)
        {
            nodeList.Add(new List<NodeInfo>());
            cowCounts[i] = -1;
        }

        for(int i = 0; i < m; i++)
        {
            int[] inputs = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            int start = inputs[0];
            int end = inputs[1];
            int cowCount = inputs[2];

            nodeList[start].Add(new NodeInfo(end, cowCount));
            nodeList[end].Add(new NodeInfo(start, cowCount));
        }

        queue.Enqueue(1);
        cowCounts[1] = 0;

        while(queue.Count > 0)
        {
            int currentIndex = queue.Dequeue();

            foreach (var currentNode in nodeList[currentIndex])
            {
                int newCowCount = cowCounts[currentIndex] + currentNode.cowCount;

                if (cowCounts[currentNode.endNode] == -1 || newCowCount < cowCounts[currentNode.endNode])
                {
                    cowCounts[currentNode.endNode] = newCowCount;
                    queue.Enqueue(currentNode.endNode);
                }
            }
        }

        writer.Write(cowCounts[n]);
    }

    private class NodeInfo
    {
        public int endNode = 0;
        public int cowCount = 0;

        public NodeInfo(int endNode, int cowCount)
        {
            this.endNode = endNode;
            this.cowCount = cowCount;
        }
    }
}