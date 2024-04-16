using System;
using System.Security.Cryptography;

public class Program
{
    private static void Main(string[] args)
    {
        // 테스트 케이스 개수
        int testCount = int.Parse(Console.ReadLine()); 

        for (int i = 0; i < testCount; i++)
        { 
            // 선수 수 입력
            int n = int.Parse(Console.ReadLine());

            // 선수들의 팀 번호 배열
            int[] rank = new int[n];

            // 각 팀의 선수가 몇명 참가했는지 확인하는 딕셔너리
            Dictionary<int, int> resultDict = new Dictionary<int, int>();

            // 선수 입력
            string[] input = Console.ReadLine().Split();

            for (int j = 0; j < n; j++)
            {
                // 팀 번호를 가져온다
                int teamNumber = int.Parse(input[j]);

                // 딕셔너리에 해당 팀이 있을 경우
                if (resultDict.ContainsKey(teamNumber))
                    // 해당 팀 인원 증가
                    resultDict[teamNumber]++; 
                else
                    // 존재하지 않는다면 해당 팀 인원 1
                    resultDict[teamNumber] = 1; 

                // 순위 별로 팀 번호를 저장
                rank[j] = teamNumber;
            }

            // 5번째 참가자 점수 저장 배열
            int[] fifthGoalIdx = new int[resultDict.Count + 1];

            // 각 팀의 최종 점수를 저장할 딕셔너리
            Dictionary<int, int> scoreDict = new Dictionary<int, int>();

            // 각 팀이 몇 번째 득점을 달성했는지 저장할 딕셔너리
            Dictionary<int, int> tempDict = new Dictionary<int, int>();

            // 팀의 최종 점수를 계산하기 위한 변수
            int score = 1;

            // 각 선수의 팀에 대해 반복하며 특정 조건에 따라 점수를 계산
            foreach (int element in rank)
            {
                // 해당 팀의 득점이 6 이상일 경우 (6명 참가)
                if (resultDict[element] >= 6)
                { 
                    // 딕셔너리에 해당 팀이 있을 경우
                    if (tempDict.ContainsKey(element))
                    {
                        // 해당 팀 인원 증가
                        tempDict[element]++;
                    }
                    // 팀이 없을 경우
                    else
                    {
                        // 해당 팀 인원 1
                        tempDict[element] = 1;
                    }  

                    // 4번째 참가자까지 들어왔을 경우
                    if (tempDict[element] <= 4)
                    {
                        // 점수 딕셔너리에 해당 팀이 있을 경우
                        if (scoreDict.ContainsKey(element))
                        {
                            // 해당 팀의 점수를 증가 시킨다
                            scoreDict[element] += score;
                        }
                        // 팀이 없을 경우
                        else
                        {
                            // 해당 팀의 점수를 저장한다
                            scoreDict[element] = score;
                        }    
                    }

                    // 5번째 참가자가 들어온 경우
                    if (tempDict[element] == 5)
                    {
                        // 해당팀의 5번째 참가자 점수를 저장한다
                        fifthGoalIdx[element] = score;
                    }

                    // 등수에 따라 점수가 증가한다
                    score++;
                }
            }

            // scoreDict에 저장된 모든 팀의 키를 가져와 저장
            List<int> keyData = new List<int>(scoreDict.Keys);

            // 두 개의 팀 번호를 받아와서 비교하고 정렬
            keyData.Sort((x, y) => 
            {
                // 두 개의 팀 점수가 같을 경우
                if (scoreDict[x] == scoreDict[y])
                { 
                    // 첫 번째 요소가 두 번째 요소보다 작으면 음수, 같으면 0, 크면 양수 반환
                    // 5번째 참가자가 먼저 들어온쪽으로 정렬
                    return fifthGoalIdx[x] - fifthGoalIdx[y]; 
                }
                // 두 개의 팀 점수가 다를 경우
                else
                {
                    // 점수가 더 낮은쪽으로 정렬
                    return scoreDict[x] - scoreDict[y];
                }
            });

            // 정렬된 리스트에서 가장 첫 번째 팀 번호 출력
            Console.WriteLine(keyData[0]);
        }
    }
}