using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kakao01
{
    class Program
    {
        public static int splitIntoTwo(List<int> arr)
        {
            int totCnt = 0;
            int Sum = 0;
            for (int i = 0; i <= arr.Count-1 ; i++)
            {
                Sum += arr[i];
            }

            int increment = 0;

            for (int i = 0; i < arr.Count - 1; i++)
            {
                increment += arr[i];
                if (increment > Sum/2)
                {
                    totCnt++;
                }            
            }


            return totCnt;
        }

        static void Main(string[] args)
        {
            List<int> arr = new List<int>()
            {
               10, -5, 6
            };
            Console.WriteLine(splitIntoTwo(arr));
            Console.ReadLine();
        }
    }
}
