using Itsho.AoC2016.Solutions;
using Itsho.AoC2016.Tests;
using System;
using System.Diagnostics;
using System.IO;

namespace Itsho.AoC2016
{
    public class Program
    {
        private static void Main(string[] args)
        {
            #region Day 01

            Console.WriteLine("------ Day 1 ------");

            Console.WriteLine("Tests...");
            Tester.TestDay1Part1();
            Tester.TestDay1Part2();

            Console.WriteLine("Actual Run...");
            var strInputDay01 = File.ReadAllLines(@"RiddleSources\DAY01.txt")[0];
            ConsoleWriteLineTimed("Day1 part1 - Distance from start", () => Day01Solution.GetPart1DistanceFromStartingPoint(strInputDay01).ToString());
            ConsoleWriteLineTimed("Day1 part2 - Distance from first location visited TWICE", () => Day01Solution.GetPart2DistanceFromAlreadyVisit(strInputDay01).ToString());

            #endregion Day 01

            #region Day 02

            Console.WriteLine("------ Day 2 ------");
            Console.WriteLine("Tests...");
            Tester.TestDay2Part1();
            Tester.TestDay2Part2();

            Console.WriteLine("Actual Run...");

            var strInputDay02 = File.ReadAllLines(@"RiddleSources\DAY02.txt");
            ConsoleWriteLineTimed("Day2 part1 ", () => Day02Solution.GetPart1(strInputDay02));
            ConsoleWriteLineTimed("Day2 part2 ", () => Day02Solution.GetPart2(strInputDay02));

            #endregion Day 02

            #region Day 03

            Console.WriteLine("------ Day 3 ------");
            Console.WriteLine("Tests...");
            Tester.TestDay3Part1();
            Tester.TestDay3Part2();

            Console.WriteLine("Actual Run...");

            var strInputDay03 = File.ReadAllLines(@"RiddleSources\DAY03.txt");
            ConsoleWriteLineTimed("Day3 part1 ", () => Day03Solution.GetPart1TotalPossibleTriangles(strInputDay03).ToString());
            ConsoleWriteLineTimed("Day3 part2 ", () => Day03Solution.GetPart2TotalPossibleTrianglesVertically(strInputDay03).ToString());

            #endregion Day 03

            #region Day 04

            Console.WriteLine("------ Day 4 ------");
            Console.WriteLine("Tests...");
            Tester.TestDay4Part1();
            Tester.TestDay4Part2();

            Console.WriteLine("Actual Run...");

            var strInputDay04 = File.ReadAllLines(@"RiddleSources\DAY04.txt");
            ConsoleWriteLineTimed("Day4 part1 ", () => Day04Solution.GetPart1SumOfSectorIDsOfTheRealRooms(strInputDay04).ToString());
            ConsoleWriteLineTimed("Day4 part2 ", () => Day04Solution.GetPart2GetSectorID(strInputDay04).ToString());

            #endregion Day 04

            Console.ReadKey();
        }

        private static void ConsoleWriteLineTimed(string p_strTitle, Func<string> p_actionToRun)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string strResult = p_actionToRun();
            sw.Stop();
            Console.WriteLine(p_strTitle + "\t" + strResult + "\t (" + sw.Elapsed.ToString() + ")");
        }
    }
}