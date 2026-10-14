using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Solution
    {
        public int MaxVowels(string s, int k)
        {
            int count = 0;

            for (int i = 0; i < k; i++)
            {
                if (IsVowel(s[i])) count++;
            }

            int max = count;

            for (int i = k; i < s.Length; i++)
            {
                if (IsVowel(s[i])) count++;       
                if (IsVowel(s[i - k])) count--;   

                max = Math.Max(max, count);

                if (max == k) 
                    break;              
            }

            return max;
        }

        private bool IsVowel(char c)
        {
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
        }
    }
}
