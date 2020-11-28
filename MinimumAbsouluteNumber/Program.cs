using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinimumAbsouluteNumber
{
    class Program
    {

        static int minimumAbsoluteDifference(int[] arr)
        {
            int[] NewArr = arr.OrderBy(item => item).ToArray();

            int diff = 0;
            for (int i = 0; i < (NewArr.Length -1); i++)
            {
                if (i==0)
                {
                    diff = Math.Abs( NewArr[i]-NewArr[i+1]);
                }

                if (diff > Math.Abs(NewArr[i] - NewArr[i + 1]))
                {
                    diff = Math.Abs(NewArr[i] - NewArr[i + 1]); 
                }
            }

            return diff;
        }   
        static void Main(string[] args)
        {
            int[] arr = new int[] { -59 ,- 36, - 13, 1, - 53, - 92, - 2 ,- 96, - 54, 75 };

            Console.WriteLine(minimumAbsoluteDifference(arr));
            Console.ReadLine();
            /*
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
            ;
            int result = minimumAbsoluteDifference(arr);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
            */
        }
    }
}
