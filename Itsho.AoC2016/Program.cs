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
            Tester.TestDay01Part1();
            Tester.TestDay01Part2();

            Console.WriteLine("Actual Run...");
            var strInputDay01 = File.ReadAllLines(@"RiddleSources\DAY01.txt")[0];
            ConsoleWriteLineTimed("Day1 part1 - Distance from start", () => Day01Solution.GetPart1DistanceFromStartingPoint(strInputDay01).ToString());
            ConsoleWriteLineTimed("Day1 part2 - Distance from first location visited TWICE", () => Day01Solution.GetPart2DistanceFromAlreadyVisit(strInputDay01).ToString());

            #endregion Day 01

            #region Day 02

            Console.WriteLine("------ Day 2 ------");
            Console.WriteLine("Tests...");
            Tester.TestDay02Part1();
            Tester.TestDay02Part2();

            Console.WriteLine("Actual Run...");

            var strInputDay02 = File.ReadAllLines(@"RiddleSources\DAY02.txt");
            ConsoleWriteLineTimed("Day2 part1 ", () => Day02Solution.GetPart1(strInputDay02));
            ConsoleWriteLineTimed("Day2 part2 ", () => Day02Solution.GetPart2(strInputDay02));

            #endregion Day 02

            #region Day 03

            Console.WriteLine("------ Day 3 ------");
            Console.WriteLine("Tests...");
            Tester.TestDay03Part1();
            Tester.TestDay03Part2();

            Console.WriteLine("Actual Run...");

            var strInputDay03 = File.ReadAllLines(@"RiddleSources\DAY03.txt");
            ConsoleWriteLineTimed("Day3 part1 ", () => Day03Solution.GetPart1TotalPossibleTriangles(strInputDay03).ToString());
            ConsoleWriteLineTimed("Day3 part2 ", () => Day03Solution.GetPart2TotalPossibleTrianglesVertically(strInputDay03).ToString());

            #endregion Day 03

            #region Day 04

            Console.WriteLine("------ Day 4 ------");
            Console.WriteLine("Tests...");
            Tester.TestDay04Part1();
            Tester.TestDay04Part2();

            Console.WriteLine("Actual Run...");

            var strInputDay04 = File.ReadAllLines(@"RiddleSources\DAY04.txt");
            ConsoleWriteLineTimed("Day4 part1 ", () => Day04Solution.GetPart1SumOfSectorIDsOfTheRealRooms(strInputDay04).ToString());
            ConsoleWriteLineTimed("Day4 part2 ", () => Day04Solution.GetPart2GetSectorID(strInputDay04).ToString());

            #endregion Day 04

            #region Day 05

            Console.WriteLine("------ Day 5 ------");
            Console.WriteLine("Tests...");
            Tester.TestDay05Part1();
            Tester.TestDay05Part2();

            Console.WriteLine("Actual Run...");

            var strInputDay05 = File.ReadAllLines(@"RiddleSources\DAY05.txt")[0];
            ConsoleWriteLineTimed("Day5 part1 ", () => Day05Solution.GetPart1(strInputDay05));
            ConsoleWriteLineTimed("Day5 part2 ", () => Day05Solution.GetPart2(strInputDay05));
            Console.WriteLine("We can't use Multithread since password generator got to be sequintal... :-(");

            #endregion Day 05

            #region Day 06

            Console.WriteLine("------ Day 6 ------");
            Console.WriteLine("Tests...");
            Tester.TestDay06Part1();
            Tester.TestDay06Part2();

            Console.WriteLine("Actual Run...");

            var strInputDay06 = File.ReadAllLines(@"RiddleSources\DAY06.txt");
            ConsoleWriteLineTimed("Day6 part1 ", () => Day06Solution.GetPart1(strInputDay06));
            ConsoleWriteLineTimed("Day6 part2 ", () => Day06Solution.GetPart2(strInputDay06));

            #endregion Day 06

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