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


namespace BalancedBracket
{
    class Program
    {
        static string isBalanced(string s)
        {
            bool blanced = true;
            Stack<char> bracketStack = new Stack<char>();
            char[] sArr = s.ToCharArray();

            try
            {
                for (int i = 0; i < sArr.Length; i++)
                {
                    if (sArr[i] == '{' || sArr[i] == '[' || sArr[i] == '(')
                    {
                        bracketStack.Push(sArr[i]);
                        
                    }
                    else
                    {
                        if(matchBracket(bracketStack.Peek(),sArr[i]))
                        {
                            bracketStack.Pop();
                        }
                        else
                        {
                            break;
                        }
                        
                    }
                }

                if( bracketStack.Count ==0)
                    blanced = true;
                else
                    blanced = false;

            }
            catch(Exception e)
            {
                blanced = false;
            }            

            return (blanced) ? "YES" : "NO";
        }

        public static bool matchBracket(char open , char close)
        {
            bool retVal = false;
            switch (open)
            {
                case '{':
                    if (close == '}')
                        retVal = true;
                    break;
                case '[':
                    if (close == ']')
                        retVal = true;
                    break;
                case '(':
                    if (close == ')')
                        retVal = true;
                    break;
            }
            return retVal;
        }

        static void Main(string[] args)
        {
            string s = "{(([])[])[]]}";
            Console.WriteLine(isBalanced(s));
            /*
            string myPath = Environment.CurrentDirectory;
            TextReader textReader = new StreamReader(Path.Combine(myPath, "input.txt"));

            
            int t = Convert.ToInt32(textReader.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                string s = textReader.ReadLine();

                string result = isBalanced(s);

                Console.WriteLine(result);
            }

            textReader.Close();
            */
            Console.ReadLine();
        }
    }
}
