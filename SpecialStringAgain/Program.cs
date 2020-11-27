using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialStringAgain
{
    class Program
    {
        static void Main(string[] args)
        {
        }


        static long substrCount(int n, string s)
        {
            

        }

        static bool isSpacialString(string str)
        {
            int first, last;
            char[] strArr = str.ToCharArray();

            first = 0;
            last = strArr.Length - 1;
            
            while( first < last)
            {
                first++;
                last--;
            }


        }
    }
}
