using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leftArr
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr= new int[]{  1,2,3,4,5};

            int[] newArr = rotLeft(arr, 4);

            foreach (var item in newArr)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        static int[] rotLeft(int[] a, int d)
        {
            int arrSize = a.Length;
            int lastIdx = a.Length - 1;
            int[] answer = new int[arrSize];

            for (int i = lastIdx; i >= 0; i--)
            {
                if (i - d >= 0)
                {
                    answer[i - d] = a[i];
                }
                else
                {
                    answer[arrSize + (i - d)] = a[i];
                }
            }

            return answer;
        }
    }
}
