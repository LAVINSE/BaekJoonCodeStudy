using System.Diagnostics;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        using StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();

        int n = int.Parse(reader.ReadLine());
        int[] numbers = new int[n + 1]; // 첫번째 줄 숫자

        bool[] visited = new bool[n + 1];
        
        List<int> answerList = new();

        for(int i = 1; i <= n; i++)
        {
            numbers[i] = int.Parse(reader.ReadLine());
        }

        for (int i = 1; i <= n; i++)
        {
            visited[i] = true;
            DFS(i, i, numbers, visited, answerList);
            visited[i] = false;
        }

        answerList.Sort();

        writer.WriteLine(answerList.Count);
        foreach (var num in answerList)
        {
            writer.WriteLine(num);
        }
    }

    private static void DFS(int start, int end, int[] numbers, bool[] visited, List<int> answerList)
    {
        if (visited[numbers[start]] == false)
        {
            visited[numbers[start]] = true;
            DFS(numbers[start], end, numbers, visited, answerList);
            visited[numbers[start]] = false;
        }

        if (numbers[start] == end)
            answerList.Add(end);
    }
}