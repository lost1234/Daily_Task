using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 
 * reference link: https://leetcode-cn.com/problems/edit-distance/solution/edit-distance-by-ikaruga/
 */
namespace MinEditDistance
{
    class Program
    {
        public static int minDistace(string word1, string word2)
        {
            int len1 = word1.Length;
            int len2 = word2.Length;

            int[][] dp = new int [len1 + 1][];
            for(int i = 0;i < len1+1;i++)
            {
                dp[i] = new int[len2 + 1];
            }
            for(int i = 1;i < len2;i++)
            {
                dp[0][i] = dp[0][i - 1] + 1;
            }
            for(int i = 1;i < len1;i++)
            {
                dp[i][0] = dp[i - 1][0] + 1;
            }
            for (int i = 1; i <= len1; i++)
            {
                for (int j = 1; j <= len2; j++)
                {
                    if (word1[i - 1] == word2[j - 1]) dp[i][j] = dp[i - 1][j - 1];
                    else dp[i][j] = Math.Min(Math.Min(dp[i - 1][j - 1], dp[i][j - 1]), dp[i - 1][j]) + 1;
                }
            }

            return dp[len1][len2];
        }
        static void Main(string[] args)
        {
            string s1 = "xyzab";
            string s2 = "axyzc";

            Console.WriteLine("The distance is: " + minDistace(s1, s2));
            Console.ReadKey();
        }
    }
}
