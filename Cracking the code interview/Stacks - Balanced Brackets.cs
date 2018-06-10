using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution 
{

    static void Main(string[] args) 
    {
        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++) 
        {
            var expression = Console.ReadLine();

            if (expression.Count() == 0)
                Console.WriteLine("YES");
            else {
                var stack = new Stack<char>();

                var isValid = true;
                foreach (var c in expression) {
                    if (c == '{' || c == '[' || c == '(')
                        stack.Push(c);
                    else {

                        if (stack.Count == 0) {
                            isValid = false;
                            break;
                        }

                        var top = stack.Pop();
                        if ( (top == '{' && c != '}') || (top == '(' && c != ')') || (top == '[' && c != ']') ) {
                            isValid = false;
                            break;
                        }
                    }
                }
                if (isValid && stack.Count == 0)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }

        }
    }
}
