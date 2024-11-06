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

        int index = 0;
        int answer = 0;

        NodeInfo temp = null;

        for (int i = 0; i < n + 1; i++)
        {
            nodeList.Add(new List<NodeInfo>());
        }

        for(int i = 0; i < m; i++)
        {
            int[] inputs = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            nodeList[inputs[0]].Add(new NodeInfo(inputs[1], inputs[2], false));
        }

        while (index == n)
        {
            if (nodeList[index].Count == 0)
                continue;

            for (int j = 0; j < nodeList[index].Count; j++)
            {
                if (temp is null)
                {
                    temp = nodeList[index][j];
                }
                else if (temp != null)
                {
                    if (temp.isVisited == false)
                    {
                        NodeInfo node = nodeList[index][j].cowCount < temp.cowCount ? temp : nodeList[index][j];
                        temp = node;
                    }
                }
            }

            temp.isVisited = true;
            index = temp.endNode;
            answer += temp.cowCount;
        }

        writer.Write(answer);
    }

    private class NodeInfo
    {
        public int endNode = 0;
        public int cowCount = 0;
        public bool isVisited = false;

        public NodeInfo(int endNode, int cowCount, bool isVisited)
        {
            this.endNode = endNode;
            this.cowCount = cowCount;
            this.isVisited = isVisited;
        }
    }
}