using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TripleSum
{
    class Program
    {
      

        // Complete the triplets function below.
        static long triplets(int[] a, int[] b, int[] c)
        {
            long totCnt = 0;
            int mid = 0;
            int[] newB = b.Distinct().OrderBy(item => item).ToArray();
            int[] newA = a.Distinct().OrderBy(item => item).ToArray();
            int[] newC = c.Distinct().OrderBy(item => item).ToArray();

            for (int i = 0; i < newB.Length; i++)
            {
                if ( mid < newB[i])
                {
                    mid = newB[i];

                    long aSel = 0;
                    long cSel = 0;
                    int aVal = 0;
                    int cVal = 0;
                    for (int j = 0; j < newA.Length; j++)
                    {
                        if (mid >= newA[j] && aVal < newA[j] )
                        {
                            aVal = newA[j];
                            aSel = j + 1;
                        }
                        else
                        {
                            break;
                        }
                    }

                    for (int k = 0; k < newC.Length; k++)
                    {
                        if (mid >= newC[k] && cVal < newC[k])
                        {
                            cVal = newC[k];
                            cSel = k + 1;
                        }
                        else
                        {
                            break;
                        }
                    }

                    totCnt += (aSel * cSel);
                }                
            }
            Console.WriteLine(totCnt);
            return totCnt;
        }



        static long triplets2(int[] a, int[] b, int[] c)
        {
            long totCnt = 0;
            int mid = 0;
            int[] newB = b.Distinct().OrderBy(item => item).ToArray();
            int[] newA = a.Distinct().OrderBy(item => item).ToArray();
            int[] newC = c.Distinct().OrderBy(item => item).ToArray();

            for (int i = 0; i < newB.Length; i++)
            {
                mid = newB[i];
                long aSel = 0;
                long cSel = 0;

                aSel = Bsearch(mid, 0, newA.Length - 1, newA);
                cSel = Bsearch(mid, 0, newC.Length - 1, newC);

                totCnt += (aSel * cSel);
            }
            Console.WriteLine(totCnt);
            return totCnt;
        }

        static int Bsearch(int target ,int start, int last, int[] arr)
        {
            int mid = (start + last )  / 2;

            if (start > last)
                return start;

            if (arr[mid] < target)
            {
                return Bsearch(target, mid + 1, last, arr);
            }
            else if (arr[mid] > target)
            {
                return Bsearch(target, start, mid - 1, arr);
            }
            else
            {
                //find
                return mid + 1 ; 
            }

        }

        static void Main(string[] args)
        {
            /*
            int[] a = new int[] {1,3,5,7 };
            int[] b = new int[] { 5,7,9 };
            int[] c = new int[] { 7,9,11,13 };

            Console.WriteLine(triplets2(a, b, c));
            Console.ReadLine();
            */

            
            string myPath = Environment.CurrentDirectory;            
            TextReader textReader = new StreamReader(Path.Combine(myPath, "input3.txt"));

          
            string[] lenaLenbLenc = textReader.ReadLine().Split(' ');

            int lena = Convert.ToInt32(lenaLenbLenc[0]);

            int lenb = Convert.ToInt32(lenaLenbLenc[1]);

            int lenc = Convert.ToInt32(lenaLenbLenc[2]);

            int[] arra = Array.ConvertAll(textReader.ReadLine().Split(' '), arraTemp => Convert.ToInt32(arraTemp))
            ;

            int[] arrb = Array.ConvertAll(textReader.ReadLine().Split(' '), arrbTemp => Convert.ToInt32(arrbTemp))
            ;

            int[] arrc = Array.ConvertAll(textReader.ReadLine().Split(' '), arrcTemp => Convert.ToInt32(arrcTemp))
            ;
            //long ans = triplets(arra, arrb, arrc);
            long ans = triplets2(arra, arrb, arrc);

            //textWriter.WriteLine(ans);

            //textReader.Flush();
            textReader.Close();
            
        }
    }
}
