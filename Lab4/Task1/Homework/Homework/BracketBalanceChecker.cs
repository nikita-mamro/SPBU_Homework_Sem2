using System;
using System.Collections.Generic;

namespace BracketBalanceChecker
{
    public class BracketBalanceChecker : IBracketBalanceChecker
    {
        public bool IsBalanced(string expression)
        {
            Stack<char> stack = new Stack<char>();

            foreach (var symbol in expression)
            {
                if (symbol == '(')
                {
                    stack.Push(symbol);
                }
                
                if (symbol == ')')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    stack.Pop();
                }
            }

            return stack.Count == 0;
        }
    }
}
