using System;
using System.Collections;
using System.ComponentModel;
using System.Net.Mail;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        int[] inputNK = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int n = inputNK[0]; // 국가 수
        int k = inputNK[1]; // 등수를 알고싶은 국가

        // 국가, 메달 정보
        List<Nation> nationList = new List<Nation>();

        for(int i = 0; i < n; i++)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int number = input[0];
            int gold = input[1];
            int sliver = input[2];
            int bronze = input[3];

            nationList.Add(new Nation(number, gold, sliver, bronze));
        }

        // Number를 기준으로 오름차순 정렬
        var nations = nationList.OrderBy(sort => sort.Number).ToList();

        int result = Caculate(nations, n, k);
        Console.WriteLine(result);
    }

    /** 국가 */
    private class Nation
    {
        public int Number { get; }
        public int Gold { get; }
        public int Sliver { get; }
        public int Bronze { get; }

        /** 생성자 */
        public Nation(int number, int gold, int sliver, int bronze)
        {
            Number = number;
            Gold = gold;
            Sliver = sliver;
            Bronze = bronze;
        }
    }

    /** 계산한다 */
    private static int Caculate(List<Nation> nationList, int n, int k)
    {
        int answer = 1;

        for(int i = 0; i < n; i++)
        {
            if(nationList[i].Gold > nationList[k -1].Gold)
            {
                answer++;
            }
            else if(nationList[i].Gold == nationList[k -1].Gold)
            {
                if (nationList[i].Sliver > nationList[k - 1].Sliver)
                {
                    answer++;
                }
                else if (nationList[i].Sliver == nationList[k - 1].Sliver)
                {
                    if (nationList[i].Bronze > nationList[k - 1].Bronze)
                    {
                        answer++;
                    }
                }
            }
        }
        return answer;
    }
}