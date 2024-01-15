using System;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        string[] nm = Console.ReadLine().Split();

        int n = int.Parse(nm[0]);
        int m = int.Parse(nm[1]);

        int[] basket = new int[n];
        int temp = 0;

        // 바구니에 값 넣기
        for(int i = 0; i < n; i++)
        {
            basket[i] = i+1;
        }

        for (int k = 0; k < m; k++)
        {
            string[] ij = Console.ReadLine().Split();
            
            // 바구니 순서
            int i = int.Parse(ij[0])-1;
            int j = int.Parse(ij[1])-1;

            // 문제 조건 1 <= i <= j <= N
            while(i < j)
            {
                // 역순
                temp = basket[i];
                basket[i++] = basket[j];
                basket[j--] = temp;
            }
        }

        // 출력
        for(int i = 0; i < basket.Length; i++)
        {
            Console.Write(basket[i] + " ");
        }
    }
}