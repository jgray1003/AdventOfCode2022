using System;

namespace AdventOfCode2022
{
    internal static class Day2
    {
        private const string ClassName = "Day2";

        public static void Run()
        {
            Output.Out(OutType.Header, ClassName);
            string input = FileReader.Read($"{ResourceStrings.SolutionPath}/Day2/Input.txt");

            string[] kvp = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            // Part 1
            /*
            A = Rock, B = Paper, C = Scissors
            X = Rock, Y = Paper, Z = Scissors
            1 = Rock, 2 = Paper, 3 = Scissors (points hand chosen)
            0 lost, 3 draw, 6 win (points)
            */

            int runningScore = 0;

            for(int round = 0; round < kvp.Length; round++)
            {
                char opponentHand = kvp[round].ToCharArray()[0];
                char myHand = kvp[round].ToCharArray()[2];

                runningScore += GetHandScore(myHand) + GetResultScore(opponentHand, myHand);
            }
            Console.WriteLine(runningScore);

            // Part 2
            /*
            A = Rock, B = Paper, C = Scissors
            X = Lose, Y = Draw, Z = Win
            1 = Rock, 2 = Paper, 3 = Scissors (points hand chosen)
            0 lost, 3 draw, 6 win (points)
            */
            runningScore = 0;

            for (int round = 0; round < kvp.Length; round++)
            {
                char opponentHand = kvp[round].ToCharArray()[0];
                char desiredResult = kvp[round].ToCharArray()[2];
                char myHand = GetHandForResult(opponentHand, desiredResult);

                runningScore += GetHandScore(myHand) + GetResultScore(opponentHand, myHand);
            }
            Console.WriteLine(runningScore);

            Output.Out(OutType.Footer, ClassName);

        }

        private static int GetHandScore(char hand)
        {
            switch (hand)
            {
                case 'X':
                    return 1;
                case 'Y':
                    return 2;
                case 'Z':
                    return 3;
                default:
                    return 0;
            }
        }

        private static int GetResultScore(char opponentHand, char myHand)
        {
            int points = 6;
            char myRealHand = DecodeHand(myHand);

            if (opponentHand == myRealHand)
            {
                points = 3;
            }
            else if((opponentHand == 'A' && myRealHand == 'C')
                || (opponentHand == 'B' && myRealHand == 'A')
                || (opponentHand == 'C' && myRealHand == 'B'))
            {
                points = 0;
            }

            return points;
        }

        private static char DecodeHand(char myHand)
        {
            switch (myHand)
            {
                case 'X':
                    return 'A';
                case 'Y':
                    return 'B';
                case 'Z':
                    return 'C';
                default:
                    return myHand;
            }
        }

        private static char GetHandForResult(char opponentHand, char desiredResult)
        {
            char returnHand = 'Z';

            if((opponentHand == 'A' && desiredResult == 'Y')
                || (opponentHand == 'B' && desiredResult == 'X')
                || (opponentHand == 'C' && desiredResult == 'Z'))
            {
                returnHand = 'X';
            }
            else if ((opponentHand == 'B' && desiredResult == 'Y')
                || (opponentHand == 'C' && desiredResult == 'X')
                || (opponentHand == 'A' && desiredResult == 'Z'))
            {
                returnHand = 'Y';
            }
            /*
            else if((opponentHand == 'A' && desiredResult == 'X')
                || (opponentHand == 'B' && desiredResult == 'Z')
                || (opponentHand == 'C' && desiredResult == 'Y'))
            {
                returnHand = 'Z';
            }
            */

            return returnHand;

        }
    }
}
