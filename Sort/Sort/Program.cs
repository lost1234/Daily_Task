using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        /*
         * 
         * 比较相邻的元素，如果第一个比第二个大，就交换两个元素。
         * 对每一对相邻元素做同样的工作，从开始第一对到结尾的最后一对。这个步骤完成后，最后的元素会是最大的数。
         * 针对所有的元素重复以上的步骤，除了最后一个。
         * 持续每次对越来越少的元素重复上面的步骤，知道没有任何一对数字需要比较。
         * 竖着看一组数，冒泡排序，重的会沉底，轻的会上浮；
         * {50，     4. 10比50 轻所以要上浮；
         *  10，     3. 20比10 重所以不动；
         *  30，     2. 20比30 轻所以要上浮动；
         *  20，     1. 40比20 重所以先不动；
         *  40}
         */
        public static List<int> BubbleSort(List<int> list)
        {
            int temp;
            //first loop, declare compare times
            for(int i = 0;i < list.Count - 1;i++)
            {
                //second loop, j > i, from end to start, the index should greater than the start.
                for(int j = list.Count-1;j > i; j--)
                {
                    if(list[j - 1] > list[j])
                    {
                        temp = list[j - 1];
                        list[j - 1] = list[j];
                        list[j] = temp;
                    }
                }
            }
            return list;
        }
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(50);
            list.Add(30);
            list.Add(40);
            list.Add(10);
            list.Add(20);
            Console.Write("Before sort: ");
            foreach (var val in list)
            {
                Console.Write(val + " ");
            }
            BubbleSort(list);
            Console.WriteLine("\n");
            Console.Write("After sort: ");
            foreach (var val in list)
            {
                Console.Write(val + " ");
            }
            
            Console.ReadKey();
        }
    }
}
