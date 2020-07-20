using System;
using System.Collections.Generic;
using System.Text;

namespace reviseproblem
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "(()())(())";
            Solution sol = new Solution();
            Console.WriteLine(sol.RemoveOuterParentheses(str));
            Console.Read();
        }
    }

    public class Solution
    {
        public string RemoveOuterParentheses(string S)
        {
            if (String.IsNullOrEmpty(S))
                return null;

            Stack<char> st = new Stack<char>();
            List<int> points = new List<int>();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < S.ToCharArray().Length; i++)
            {
                if (st.Count == 0)
                {
                    st.Push(S[i]);
                    points.Add(i);
                    i++;
                }
                if (S[i] == '(' && st.Peek() == ')')
                {
                    st.Pop();
                    if (st.Count == 0)
                    {
                        points.Add(i);
                    }
                }
                else if (S[i] == ')' && st.Peek() == '(')
                {
                    st.Pop();
                    if (st.Count == 0)
                    {
                        points.Add(i);
                    }
                }
                else
                {
                    st.Push(S[i]);
                }
            }

            for (int l = 0; l < points.Count - 1; l += 2)
            {
                sb.Append(S.Substring(points[l] + 1, points[l + 1] - points[l] - 1));
            }

            return sb.ToString();

        }
    }
}
