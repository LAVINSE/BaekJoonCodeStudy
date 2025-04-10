using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        using StreamReader reader = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter writer = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        StringBuilder stringBuilder = new StringBuilder();

        int[] inputs = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

        int n = inputs[0]; // n층
        int k = inputs[1]; // k 자리수
        int p = inputs[2]; // p 반전 개수
        int x = inputs[3]; // x층에 멈춤

        int answer = 0;

        Dictionary<int, int[]> segmentDict = new()
        {
            { 0, new int[] {1, 1, 1, 0, 1, 1, 1} },
            { 1, new int[] {0, 0, 1, 0, 0, 0, 1} },
            { 2, new int[] {0, 1, 1, 1, 1, 1, 0} },
            { 3, new int[] {0, 1, 1, 1, 0, 1, 1} },
            { 4, new int[] {1, 0, 1, 1, 0, 0, 1} },
            { 5, new int[] {1, 1, 0, 1, 0, 1, 1} },
            { 6, new int[] {1, 1, 0, 1, 1, 1, 1} },
            { 7, new int[] {0, 1, 1, 0, 0, 0, 1} },
            { 8, new int[] {1, 1, 1, 1, 1, 1, 1} },
            { 9, new int[] {1, 1, 1, 1, 0, 1, 1} },
        };


        int[] baseSegment = x.ToString().PadLeft(k, '0').Select(c => c - '0').ToArray();

        for (int i = 1; i <= n; i++)
        {
            if (i == x)
                continue;

            int[] selectedNumbers = i.ToString().PadLeft(k, '0').Select(c => c - '0').ToArray();
            int count = 0;
            for (int j = 0; j < baseSegment.Length; j++)
            {
                if (j >= selectedNumbers.Length)
                    break;

                int[] baseSegemntValue = segmentDict[baseSegment[j]];
                int[] selectedSegmentValue = segmentDict[selectedNumbers[j]];

                for (int y = 0; y < baseSegemntValue.Length; y++)
                {
                    if (baseSegemntValue[y] != selectedSegmentValue[y])
                        count++;

                    if (count > p)
                        break;
                }
            }
            if (count <= p)
                answer++;
        }

        writer.Write(answer);
    }
}