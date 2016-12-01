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
            Console.WriteLine("------ Day 1 Tests------");

            Console.WriteLine("Tests...");
            Tester.TestDay1Part1();
            Tester.TestDay1Part2();

            Console.WriteLine("Actual Run...");
            int? intDay1Part2 = null;
            var intDay1Part1 = Day01Solution.GetDistanceFromStartingPoint(File.ReadAllLines(@"RiddleSources\DAY01.txt")[0], out intDay1Part2);

            Console.WriteLine("Day1 part1 - Distance from start: {0}", intDay1Part1);
            Console.WriteLine("Day1 part2 - Distance from first location visited TWICE: {0}", intDay1Part2);
            Console.ReadKey();
        }

        private static void ConsoleWriteLineTimed(string p_strTitle, Func<string> p_actionToRun)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string strResult = p_actionToRun();
            sw.Stop();
            Console.WriteLine(p_strTitle + strResult + "\t (" + sw.Elapsed.ToString() + ")");
        }
    }
}