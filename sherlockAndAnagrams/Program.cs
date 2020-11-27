using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sherlockAndAnagrams
{
    class Program
    {

        // Complete the sherlockAndAnagrams function below.
        static int sherlockAndAnagrams(string s)
        {
            int constPair = 2;
            double anagramPairCount = 0;

            //1. 1~n 까지 돌면서 근접값으로 해쉬값 비교하여 같은셋 구하기 .
            char[] stringArr = s.ToCharArray();
            for (int i = 1; i < s.Length; i++)
            {
                int strLength = i;               
                //해쉬값을 Dictionary에저장. 
                Dictionary<string, int> anagramCounter = new Dictionary<string, int>();

                for (int j = 0; j <= ( stringArr.Length - strLength); j++)
                {

                    string strHashVal = anagramHashFunc(s.Substring(j, strLength).ToCharArray());

                    if (  anagramCounter.ContainsKey(strHashVal) )
                    {
                        //있는경우
                        anagramCounter[strHashVal]++;
                    }
                    else
                    {
                        //없는경우
                        anagramCounter.Add(strHashVal, 1);
                    }
                }

                foreach(var item in anagramCounter)
                {
                    //아나그램으로 쌍(2이상) 지정되는 것만계산.
                    if (item.Value  >= 2)
                    {
                        //2. 2개를 고르는  조합수 가져오기 
                        anagramPairCount += combinationReturn(item.Value, constPair);
                    }
                }
            }
            
            return Convert.ToInt32(anagramPairCount);
        }

        private static string anagramHashFunc(char[] charset)
        {             
            List<char> hashList = new List<char>();
            for (int i = 0; i < charset.Length; i++)
            {
                hashList.Add(charset[i]);
            }
            hashList.Sort();          
            return string.Concat(hashList.ToArray()); ;
        }
        private static double combinationReturn(int set, int select)
        {
            //콤비네이션 setCselct   ex->  4C2         4!/2!*2!
            return  factorial(set) /  ( factorial(set - select) * factorial(select) ) ;
        }

        private static double  factorial(int number)
        {
            double returnVal = 1;
            for (int i = number ; i > 1; i--)
            {
                returnVal *= i;
            }
            return returnVal;
        }

        static void Main(string[] args)
        {
            string input =
            "ifailuhkqqhucpoltgtyovarjsnrbfpvmupwjjjfiwwhrlkpekxxnebfrwibylcvkfealgonjkzwlyfhhkefuvgndgdnbelgruel";
            Console.WriteLine(sherlockAndAnagrams(input));
            Console.ReadLine();
        }
    }
}
