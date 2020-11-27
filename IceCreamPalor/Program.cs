using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
namespace IceCreamPalor
{
    class Program
    {
        public class Flavor
        {
            public int ID;
            public int Cost;           
        }

        public class Checker : IComparer<Flavor>
        {
            public int Compare(Flavor x, Flavor y)
            {
                if (x.Cost < y.Cost)
                {
                    return -1;
                }
                else if (x.Cost == y.Cost)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        } 

        // Complete the whatFlavors function below.
        static void whatFlavorsByBinarySearch(int[] cost, int money)
        {
            
            List<Flavor> costList = new List<Flavor>();

            for (int i = 0; i< cost.Length; i++)
            {
                costList.Add(new Flavor() {
                    Cost = cost[i],
                    ID =i+1,
                    });
            }

            costList.Sort(new Checker().Compare);

            int firstindex, secondIndex;
            int firstCost, secondCost;
            int findCost;

            //int midle = (int)Math.Truncate( (double)(costList.Count/ 2));
            int midle = costList.Count / 2  ;


            int tempFind = -1;

            while(tempFind < 0  && midle >= 0 )
            {
                //정렬후 이진탐색.
                while (costList[midle].Cost > money)
                {
                    midle--;
                }
                firstCost = costList[midle].Cost ;
                findCost = money - firstCost;

                if (findCost - firstCost <= 0)
                {
                    //왼쪽 부분 탐색
                    tempFind = BinaryFind(findCost, 0, midle - 1, costList);
                }
                else
                {
                    //오른쪽 부분탐색
                    tempFind = BinaryFind(findCost, midle + 1, cost.Length - 1, costList);
                }

                if(tempFind == -1)
                    midle--;
            }
            firstindex = midle; firstCost  = costList[firstindex].Cost ;
            secondIndex = tempFind; secondCost = costList[secondIndex].Cost;


            Console.WriteLine($"first flavorCost : {costList[firstindex].ID }:{firstCost}");
            Console.WriteLine($"second flavorCost : {costList[secondIndex].ID  }:{secondCost}");
            Console.ReadLine();

        }

        static void whatFlavorsMap(int[] cost, int money)
        {
            //Cost로 HashTable 생성
            Dictionary<int, List<int>> CostTables = new Dictionary<int, List<int>>();

            List<int> IDX = new List<int>();

            for (int i = 0; i < cost.Length; i++)
            {
                if (CostTables.ContainsKey(cost[i]))
                {
                    //값있음
                    CostTables[cost[i]].Add(i+1);
                }
                else
                {
                    //값없음
                    List<int> idList = new List<int>();
                    idList.Add(i+1);
                    CostTables.Add(cost[i], idList);
                }
            }

            for(int i =0; i < cost.Length; i++)
            {
                int first = -1; 
                int second = -1;
                int findcost = money - cost[i];

                if (CostTables.ContainsKey(findcost))
                {
                    first = popIDX(cost[i], CostTables);                    

                    if (CostTables.ContainsKey(findcost))
                    {
                        second = popIDX(findcost, CostTables);
                    }
                }                    

                if (first > 0 && second > 0)
                {
                    IDX.Add(first);
                    IDX.Add(second);
                    IDX.Sort();
                    break;
                }
            }

            Console.WriteLine($"{IDX[0]} {IDX[1]}");

        }

        static void whatFlavors(int[] cost, int money)
        {
            //Cost로 HashTable 생성
            Dictionary<int,int> CostTables = new Dictionary<int,int>();

            for (int i = 0; i < cost.Length; i++)
            {                
                
                int findCost = money - cost[i];

                if (CostTables.ContainsKey(findCost) && ( (i + 1) != CostTables[findCost] ) )
                {                    
                   
                    if ( (i+1) < CostTables[findCost] )
                    {
                        Console.Write($"{i + 1} {CostTables[findCost]}\n");
                    }
                    else
                    {
                        Console.Write($"{CostTables[findCost]} {i + 1}\n");
                    }

                    break;
                }

                if (CostTables.ContainsKey(cost[i]))
                {
                    CostTables[cost[i]] = i + 1;
                }
                else
                {
                    CostTables.Add(cost[i], i + 1);
                }
            }

            Console.ReadLine();
        }

        private static int popIDX(int cost , Dictionary<int, List<int>> hashmap)
        {
            int returnID = -1;
            if( hashmap.ContainsKey(cost))
            {
                //ID 뽑아냄.
                returnID = hashmap[cost].FirstOrDefault();
                hashmap[cost].Remove(returnID);
                if(hashmap[cost].Count == 0)
                {
                    hashmap.Remove(cost);
                }
            }

            return returnID;
        }

        static int BinaryFind(int findVal , int start, int last, List<Flavor> arr)
        {
            if ( last < start)
            {
                //못찾은경우..
                return -1;
            }

            //int midle = (int)Math.Truncate((double)( (start + last) / 2));
            int midle = (start + last) / 2;

            if ( findVal < arr[midle].Cost)
            {                
                return BinaryFind(findVal, start, midle - 1, arr);
            }
            else if (findVal > arr[midle].Cost)
            {
                return BinaryFind(findVal, midle+1, last, arr);
            }
            else
            {
                //같은경우 값찾음.
                return midle;
            }
        }

        static void Main(string[] args)
        {
            int money = 8;
            int[] cost = new int[] { 4, 3, 2, 5, 7 };
            whatFlavors(cost, money);
        }
    }
}
