using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kakao02
{
    class Program
    {

        public static int requestsServed(List<int> timestamp, List<int> top)
        {
            //끝부분 타임스탬프 추가.
            timestamp.Add(61);

            List<int> orderTimeStamp = timestamp.OrderBy(item => item).ToList();

            List<int> orderTop = top.OrderBy(item => item).ToList();

            Stack<int> rcvStack = new Stack<int>();
            int totServed = 0;
            int topSecond = 0;
            int memoIdx = 0;

            while (orderTop.Count() > 0)
            {
                topSecond = orderTop.First();
                orderTop.RemoveAt(0);

                if (topSecond >= 0)
                {

                    for (int i = memoIdx ; i < orderTimeStamp.Count; i++)
                    {

                        //if(timestamp[i] > topSecond || i == (timestamp.Count-1))
                        if (orderTimeStamp[i] > topSecond)
                        {
                            //선점을 가졌으므로 팝한다. (5개) 
                            for(int j=1; j<=5;j++)
                            {
                                if(rcvStack.Count > 0)
                                {
                                    rcvStack.Pop();
                                    totServed++;
                                }                                    
                            }
                            memoIdx = i;
                            break;
                        }else if (orderTimeStamp[i] <= topSecond)
                        {
                            rcvStack.Push(orderTimeStamp[i]);
                        }
                    }
                
                }
            }

            return totServed;          

        }

        static void Main(string[] args)
        {
            List<int> timestamp = new List<int>() {
              0,0,0,0,0,0,0,0,0
            };

            List<int> top = new List<int>()
            {
               0
            }; 


            Console.WriteLine(requestsServed(timestamp,top));
            Console.ReadLine();
        }
    }
}
