using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pairs
{
    class Program
    {
        static int pairs(int k, int[] arr)
        {
            int cnt = 0;
            Dictionary<int, int> dicDiff = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                dicDiff.Add(arr[i], 1);
                arr[i] = arr[i] - k;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if(dicDiff.ContainsKey(arr[i]))
                {
                    dicDiff[arr[i]] = dicDiff[arr[i]] - 1;
                }
                else
                {
                    //아무것도 하지않음
                }
            }

            foreach (var item in dicDiff)
            {
                if(item.Value==0)
                {
                    cnt++;
                }
            }
            return cnt;

        }

        static void Main(string[] args)
        {
            int[] arr = new int[] {1,5,3,4,2 };
            int dif = 2;
            Console.WriteLine(pairs(dif, arr));
            Console.ReadLine();
        }
    }
}
