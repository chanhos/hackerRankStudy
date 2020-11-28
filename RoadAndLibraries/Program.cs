using System;
using System.Collections.Generic;
using System.Linq;
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


namespace RoadAndLibraries
{
    class Program
    {

        // Complete the roadsAndLibraries function below.
        static long roadsAndLibraries(int n, int c_lib, int c_road, int[][] cities)
        {
            long totCost = 0;

            long minAllLibCost;

            minAllLibCost = n * c_lib;


            List<int> vertex = new List<int>();

            Dictionary<int, List<int>> DicConCities = new Dictionary<int, List<int>>();


            for (int i = 0; i < cities.GetLength(0); i++)
            {
                if (DicConCities.ContainsKey(cities[i][0]))
                {
                    //있는경우추가
                    DicConCities[cities[i][0]].Add(cities[i][1]);
                }
                else
                {
                    //없는경우
                    DicConCities.Add(cities[i][0], new List<int>(){
                        { cities[i][1]}
                    });
                }
            }

            //BuildMinimunSpaningTree

            foreach (var city in DicConCities)
            {
              
                List<int> conCity = city.Value;
                for (int i = 0; i < conCity.Count; i++)
                {
                    if( intoVertex(city.Key, conCity[i],vertex) )
                    {
                        totCost += c_road;
                    }
                    
                }

                if (vertex.Count == n)
                    break;
            }
            //마지막 도서관 비용
            //totCost +=

            return totCost;
        }

       

      

        public static bool intoVertex(int a, int b , List<int> v)
        {
            for (int i = 0; i < v.Count ; i++)
            {
                if (v[i] == a)
                    a = -1;
                if (v[i] == a)
                    b = -1;
            }

            if (a == -1 && b == -1)
                return false;

            if( a != -1)
            {
                v.Add(a);
            }
            if(b != -1)
            {
                v.Add(b);
            }

            return true;
        }
        static void Main(string[] args)
        {
            int n, c_lib, c_road;
            int[][] cities;
            n = 6;
            c_lib = 2;
            c_road = 5;
            cities = new int[n][];
            //{ { 1,3 } , {3,4 } , {2,4 }, {1,2 } , {2,3 }, { 5,6} };
         
            cities[0] = new int[] { 1,3 };
            cities[1] = new int[] { 3,4 };
            cities[2] = new int[] { 2,4 };
            cities[3] = new int[] { 1,2 };
            cities[4] = new int[] { 2,3 };
            cities[5] = new int[] { 5,6 };



            long result = roadsAndLibraries(n, c_lib, c_road, cities);

            Console.WriteLine(result);
            /*
            string myPath = Environment.CurrentDirectory;
            TextReader textReader = new StreamReader(Path.Combine(myPath, "input.txt"));
            
            int q = Convert.ToInt32(textReader.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string[] nmC_libC_road = textReader.ReadLine().Split(' ');

                int n = Convert.ToInt32(nmC_libC_road[0]);

                int m = Convert.ToInt32(nmC_libC_road[1]);

                int c_lib = Convert.ToInt32(nmC_libC_road[2]);

                int c_road = Convert.ToInt32(nmC_libC_road[3]);

                int[][] cities = new int[m][];

                for (int i = 0; i < m; i++)
                {
                    cities[i] = Array.ConvertAll(textReader.ReadLine().Split(' '), citiesTemp => Convert.ToInt32(citiesTemp));
                }

                long result = roadsAndLibraries(n, c_lib, c_road, cities);

                Console.WriteLine(result);
            }
            textReader.Close();
            */

        }
    }
}
