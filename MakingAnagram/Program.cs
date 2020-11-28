using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MakingAnagram
{
    class Program
    {
        static void Main(string[] args)
        {
            string a, b;
            a = "fcrxzwscanmligyxyvym";
            b = "jxwtrhvujlmrpdoqbisbwhmgpmeoke";
            Console.WriteLine(makeAnagram(a, b));
            Console.ReadLine();
        }

        static int makeAnagram(string a, string b)
        {
            Dictionary<char, int> DicA = new Dictionary<char, int>();
            Dictionary<char, int> DicB = new Dictionary<char, int>();

            int cnt = 0;
            char[] charArrA = a.ToCharArray();
            char[] charArrB= b.ToCharArray();
            //a문자열에 대해 해쉬맵 대응
            for (int i = 0; i < charArrA.Length;  i++)
            {
                if(DicA.ContainsKey(charArrA[i]))
                {
                    DicA[charArrA[i]] = DicA[charArrA[i]] + 1;
                }
                else
                {
                    DicA.Add(charArrA[i], 1);
                }
            }

            //b문자열을 돌면서 해쉬맵에서 확인
            for (int i = 0; i < charArrB.Length; i++)
            {
                if (DicA.ContainsKey(charArrB[i]))
                {
                    //문자열있음!
                    DicA[charArrB[i]] = DicA[charArrB[i]] -1 ;
                    if(DicA[charArrB[i]] == 0 ){
                        DicA.Remove(charArrB[i]);
                    }
                }
                else
                {                    
                    if (DicB.ContainsKey(charArrB[i]))
                    {
                        DicB[charArrB[i]] = DicB[charArrB[i]] + 1;
                    }
                    else
                    {
                        DicB.Add(charArrB[i], 1);
                    }
                }
            }

            foreach (var item in DicA)
            {
                cnt += item.Value;
            }

            foreach (var item in DicB)
            {
                cnt += item.Value;
            }


            return cnt;
        }
    }

   
}
