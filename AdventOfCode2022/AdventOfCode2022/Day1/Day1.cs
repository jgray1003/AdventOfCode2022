using System;

namespace AdventOfCode2022
{
    internal static class Day1
    {
        private const string ClassName = "Day1";

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
            int[] maxNElfCalorieSums = new int[n];

            for (int i = 0; i < calories.Length; i++)
            {
                if (!String.IsNullOrEmpty(calories[i]))
                {
                    elfCalorieSum += Convert.ToInt32(calories[i]);
                }
                else
                {
                    bool doUpdate = false;
                    for (int j = 0; j < maxNElfCalorieSums.Length; j++)
                    {
                        if (elfCalorieSum > maxNElfCalorieSums[j])
                        {
                            doUpdate = true;
                            break;
                        }
                    }

                    if (doUpdate)
                    {
                        maxNElfCalorieSums[FindIndex(maxNElfCalorieSums, elfCalorieSum)] = elfCalorieSum;
                    }

                    elfCalorieSum = 0;
                }
            }

            int maxNCalorieSummation = 0;
            for (int i = 0; i < maxNElfCalorieSums.Length; i++)
            {
                maxNCalorieSummation += maxNElfCalorieSums[i];
            }
            Console.WriteLine(maxNCalorieSummation);
        }

        private static int FindIndex(int[] maxs, int num)
        {
            int index = 0;
            int minCalories = maxs[0];
            for (int i = 0; i < maxs.Length; i++)
            {
                if (maxs[i] < minCalories)
                {
                    minCalories = maxs[i];
                }
            }

            for (int i = 0; i < maxs.Length; i++)
            {
                if (maxs[i] == minCalories)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}
