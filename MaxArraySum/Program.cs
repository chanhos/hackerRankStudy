using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaxArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rod = new int[] {  1,2,3 };

          //  hopSum(rod.Length / 2 - 1, 2,rod);
            Console.ReadLine();
        }
        /*
        static int partMax(int n , int[] arr)
        {
            if ( n < 3)
            {
                return 0;
            }
            else
            {
                return Math.Max( hopMax()  ,partMax(n-1) ) );
            }


        }


        static int hopMax(int idx , int[] arr)
        {
            int maxVal = 0;
            int i = 2;

            int idxVal = arr[idx]; 
            
            while( idx - i >= 0)
            {
                if (i == 2)
                    maxVal = arr[idx - i];

                if (maxVal < hopMax(idx - i, arr))
                    maxVal = hopMax(idx - i, arr);


            }

            return idxVal + maxVal;
        }


        


        static int maxSubsetSum(int[] arr)
        {
            
            return 0; 
        }
        */
    }
}
