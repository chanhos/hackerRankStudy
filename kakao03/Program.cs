using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kakao03
{
    class Program
    {
        public static int segment2(int x, List<int> space)
        {
            int maxVal = 0;
            int segLen = x;

            int modCnt = segLen-( space.Count % segLen);
            if (modCnt > 0 )
            {
                int originLen = space.Count - 1;
                for (int i =1 ; i <= modCnt; i++)
                {
                    space.Add(space[originLen - (i)]);
                }
            }
            
            
            for (int i = 0; i <= (space.Count - x); i+= segLen)
            {
                int[] spaceArr = space.ToArray();
                int start = i;
                int last;

                if( start+segLen > space.Count - 1)
                {
                    last = space.Count - 1;
                }
                else
                {
                    last = start + segLen -1;
                }

                QuickSort(spaceArr, start, last );
                if(maxVal < spaceArr[start])
                {
                    maxVal = spaceArr[start];
                }                
            }          
           
            return maxVal;
        }


        public static int segment(int x, List<int> space)
        {
            int maxVal = 0;
            int segLen = x;

            
            

            return maxVal;
        }

        static int getMaxVal(int n,int x, List<int> space)
        {
            if (n < 1)
            {
                for (int i = 0; i < i+x ; i++)
                {
                    int[] spaceArr = space.ToArray();
                    int start = i;
                    int last;
                    
                    last = start + x - 1;
                    
                    QuickSort(spaceArr, start, last);
                   
                   return spaceArr[start];
                    
                }
            }
            else
            {
                
            }
            
        }


        static void QuickSort(int[] array, int start, int last)
        {
            if (start < last)
            {
                int pivot = Partition(array, start, last);
                QuickSort(array, start, pivot - 1);
                QuickSort(array, pivot + 1, last);
            }
        }

        static int Partition(int[] array, int start, int last)
        {
            int q = start;
            for (int j = start; j < last; j++)
            {
                if (array[j] <= array[last])
                {
                    Swap(array, q, j);
                    q++;
                }
            }
            Swap(array, q, last);
            return q;
        }

         static void Swap(int[] array, int beforeIndex, int foreIndex) {
            var tmp = array[beforeIndex];
            array[beforeIndex] = array[foreIndex];
            array[foreIndex] = tmp;
        }

       

        

        static void Main(string[] args)
        {
            int s = 3;
            List<int> space = new List<int>()
            {
                1,2,3,1,2,4,5, 7, 8,9
            };
           
            Console.WriteLine(segment(s,space));
            Console.ReadLine();

        }
    }
}
