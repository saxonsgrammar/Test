using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        public static int CalculateMedian(List<int> list)
        {
            int[] arr = list.OrderBy(n => n).ToArray();

            if (arr.Length % 2 == 1)
            {
                return arr[((arr.Length - 1) / 2) + 1];
            }
            else
            {
                int midValue = arr.Length / 2;
                return (arr[midValue] + arr[midValue + 1]) / 2;
            }
        }

        public static int ArMean(List<int> list)
        {
            int sumOfList = 0;
            int[] arr = list.ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                sumOfList += arr[i];
            }

            return sumOfList / 2;
        }

        static void Main(string[] args)
        {
            string path = $"..\\Debug\\10m.txt";

            try
            {
                List<int> numbersList = new List<int>();

                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (int.TryParse(line, out int number))
                        {
                            numbersList.Add(number);
                        }
                    }

                    Console.WriteLine($"Max: {numbersList.Max()}");
                    Console.WriteLine($"Min: {numbersList.Min()}");
                    Console.WriteLine($"Median: {CalculateMedian(numbersList)}");
                    Console.WriteLine($"Arithmetic mean: {ArMean(numbersList)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}