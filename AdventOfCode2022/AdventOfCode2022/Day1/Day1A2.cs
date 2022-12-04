using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022
{
    internal static class Day1A2
    {
        private const string ClassName = "Day1A2";

        public static void Run()
        {
            Output.Out(OutType.Header, ClassName);

            string input = FileReader.Read($"{ResourceStrings.SolutionPath}/Day1/Input.txt");

            string[] calories = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            // Part 1
            GetTopNCalorieSummation(calories, 1);

            // Part 2
            GetTopNCalorieSummation(calories, 3);

            Output.Out(OutType.Footer, ClassName);
        }

        private static void GetTopNCalorieSummation(string[] calories, int n)
        {
            if (n == 0)
            {
                throw new Exception("n must be a positive integer");
            }

            int elfCalorieSum = 0;
            List<int> maxNElfCalorieSums = new List<int>();

            for (int i = 0; i < calories.Length; i++)
            {
                if (!String.IsNullOrEmpty(calories[i]))
                {
                    elfCalorieSum += Convert.ToInt32(calories[i]);
                }
                else
                {
                    maxNElfCalorieSums.Add(elfCalorieSum);
                    elfCalorieSum = 0;
                }
            }

            Console.WriteLine(maxNElfCalorieSums.OrderByDescending(x => x).Take(n).Sum());
        }
    }
}
