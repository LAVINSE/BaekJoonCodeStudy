using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    public class Team
    {
        public int id;
        public int totalScore;
        public int submitCount;
        public int lastSubmitTime;
        public int[] problemScore;

        public Team(int id, int problemCount)
        {
            this.id = id;
            this.problemScore = new int[problemCount + 1];
        }
    }

    private static void Main(string[] args)
    {
        // 테스트 데이터 수 T
        // 팀의 개수 N
        // 문제의 개수 K
        // 내 팀 ID myId
        // 로그 엔트리의 개수 M

        // M개의 줄에는 각 풀이에 대한 정보 >> ID teanId, 문제번호 problemNumber, 획득한 점수 getScore

        int t = int.Parse(Console.ReadLine());

        while(t > 0)
        {
            int[] inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int n = inputs[0];
            int k = inputs[1];
            int myId = inputs[2];
            int m = inputs[3];

            Team[] teamList = new Team[n];

            for(int i = 0; i < n; i++)
            {
                teamList[i] = new Team(i + 1, k);
            }

            for(int i = 0; i < m; i++)
            {
                int[] teamDataInputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int teamId = teamDataInputs[0];
                int problemNumber = teamDataInputs[1];
                int getScore = teamDataInputs[2];

                Team currentTeam = teamList[teamId - 1];

                // 해당 문제번호에서 얻는 점수중 가장 큰값 적용, 제출 횟수 증가, 제출 시간 저장
                currentTeam.problemScore[problemNumber] = Math.Max(getScore, teamList[teamId - 1].problemScore[problemNumber]);
                currentTeam.submitCount++;
                currentTeam.lastSubmitTime = i;
            }

            // 점수 합
            for(int i = 0; i < n; i++)
            {
                int sum = 0;
                for(int j = 1; j <= k; j++)
                {
                    // 0번째 문제는 없으니까 1부터 시작
                    sum += teamList[i].problemScore[j];
                }
                teamList[i].totalScore = sum;
            }

            Array.Sort(teamList, (a, b) =>
            {
                if (a.totalScore == b.totalScore)
                {
                    if (a.submitCount == b.submitCount)
                    {
                        return a.lastSubmitTime - b.lastSubmitTime;
                    }
                    return a.submitCount - b.submitCount;
                }
                return b.totalScore - a.totalScore;
            });

            for(int i = 0; i < n; i++)
            {
                if (teamList[i].id == myId)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }

            t--;
        }
    }
}