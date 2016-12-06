using System;
using Itsho.AoC2016.Solutions;
using System.Diagnostics;

namespace Itsho.AoC2016.Tests
{
    public static class Tester
    {
        public static void TestDay01Part1()
        {
            var intPart1 = Day01Solution.GetPart1DistanceFromStartingPoint("R5, L5, R5, R3");
            NUnit.Framework.Assert.AreEqual(12, intPart1);

            intPart1 = Day01Solution.GetPart1DistanceFromStartingPoint("R5, R5, R5, R5");
            NUnit.Framework.Assert.AreEqual(0, intPart1);

            intPart1 = Day01Solution.GetPart1DistanceFromStartingPoint("R5, R5, R5, R5, R5, R5, R5, R5");
            NUnit.Framework.Assert.AreEqual(0, intPart1);

            intPart1 = Day01Solution.GetPart1DistanceFromStartingPoint("R5, R5, L5, R5, R5, L5, L5, L5");
            NUnit.Framework.Assert.AreEqual(20, intPart1);

            intPart1 = Day01Solution.GetPart1DistanceFromStartingPoint("R8, R4, R4, R8");
            NUnit.Framework.Assert.AreEqual(8, intPart1);

            intPart1 = Day01Solution.GetPart1DistanceFromStartingPoint("R1, R1, R2, R2, R3, R3, R2, R2");
            NUnit.Framework.Assert.AreEqual(0, intPart1);

            intPart1 = Day01Solution.GetPart1DistanceFromStartingPoint("R1, R2, R2, R3, R3, R2, R5");
            NUnit.Framework.Assert.AreEqual(4, intPart1);
        }

        public static void TestDay01Part2()
        {
            var intPart2 = Day01Solution.GetPart2DistanceFromAlreadyVisit("R8, R4, R4, R8");
            NUnit.Framework.Assert.AreEqual(4, intPart2);

            intPart2 = Day01Solution.GetPart2DistanceFromAlreadyVisit("R1, R1, R2, R2, R3, R3, R2, R2");
            NUnit.Framework.Assert.AreEqual(1, intPart2);

            intPart2 = Day01Solution.GetPart2DistanceFromAlreadyVisit("R1, R2, R2, R3, R3, R2, R5");
            NUnit.Framework.Assert.AreEqual(2, intPart2);
        }

        public static void TestDay02Part1()
        {
            var strPart1 = Day02Solution.GetPart1(new[]
            {
                "ULL",
                "RRDDD",
                "LURDL",
                "UUUUD"
            });

            NUnit.Framework.Assert.AreEqual("1985", strPart1);
        }

        public static void TestDay02Part2()
        {
            var strPart2 = Day02Solution.GetPart2(new[]
            {
                "ULL",
                "RRDDD",
                "LURDL",
                "UUUUD"
            });
            NUnit.Framework.Assert.AreEqual("5DB3", strPart2);
        }

        public static void TestDay03Part1()
        {
            NUnit.Framework.Assert.AreEqual(false, Day03Solution.IsValidTriangle("5 10 25"));
            NUnit.Framework.Assert.AreEqual(true, Day03Solution.IsValidTriangle("5  6  7"));
            NUnit.Framework.Assert.AreEqual(false, Day03Solution.IsValidTriangle("682  103  579"));
            NUnit.Framework.Assert.AreEqual(true, Day03Solution.IsValidTriangle("441  764  471"));
            NUnit.Framework.Assert.AreEqual(false, Day03Solution.IsValidTriangle("481  114  267"));
            NUnit.Framework.Assert.AreEqual(true, Day03Solution.IsValidTriangle("196  567  591"));
            NUnit.Framework.Assert.AreEqual(true, Day03Solution.IsValidTriangle("353  495  798"));
            NUnit.Framework.Assert.AreEqual(false, Day03Solution.IsValidTriangle("436  348   30"));
            NUnit.Framework.Assert.AreEqual(false, Day03Solution.IsValidTriangle("794   88  526"));
            NUnit.Framework.Assert.AreEqual(true, Day03Solution.IsValidTriangle("926  411  524"));
            NUnit.Framework.Assert.AreEqual(false, Day03Solution.IsValidTriangle("  1  862  754"));
            NUnit.Framework.Assert.AreEqual(true, Day03Solution.IsValidTriangle("839  440  848"));
            NUnit.Framework.Assert.AreEqual(false, Day03Solution.IsValidTriangle("839  458  109"));
            NUnit.Framework.Assert.AreEqual(true, Day03Solution.IsValidTriangle("961  799  930"));
            NUnit.Framework.Assert.AreEqual(true, Day03Solution.IsValidTriangle("944  692  853"));
            NUnit.Framework.Assert.AreEqual(false, Day03Solution.IsValidTriangle("168  520  788"));
            NUnit.Framework.Assert.AreEqual(true, Day03Solution.IsValidTriangle("579  920  687"));
        }

        public static void TestDay03Part2()
        {
            var arrToTest = new[]
            {
                "101 301 501",
                "102 302 502",
                "103 303 503",
                "201 401 601",
                "202 402 602",
                "203 403 603"
            };

            NUnit.Framework.Assert.AreEqual(6, Day03Solution.GetPart2TotalPossibleTrianglesVertically(arrToTest));
        }

        public static void TestDay04Part1()
        {
            NUnit.Framework.Assert.AreEqual(true, Day04Solution.IsRealRoom("aaaaa-bbb-z-y-x-123[abxyz]"));
            NUnit.Framework.Assert.AreEqual(true, Day04Solution.IsRealRoom("a-b-c-d-e-f-g-h-987[abcde]"));
            NUnit.Framework.Assert.AreEqual(true, Day04Solution.IsRealRoom("not-a-real-room-404[oarel]"));
            NUnit.Framework.Assert.AreEqual(false, Day04Solution.IsRealRoom("totally-real-room-200[decoy]"));
        }

        public static void TestDay04Part2()
        {
            NUnit.Framework.Assert.AreEqual("very encrypted name", Day04Solution.DecryptRoomName("qzmt-zixmtkozy-ivhz-343"));
        }

        public static void TestDay05Part1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var strPass = Day05Solution.GetPart1("abc");
            sw.Stop();
            NUnit.Framework.Assert.AreEqual("18F47A30", strPass);
        }

        public static void TestDay05Part2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var strPass = Day05Solution.GetPart2("abc");
            sw.Stop();
            NUnit.Framework.Assert.AreEqual("05ACE8E3", strPass);
        }

        public static void TestDay06Part1()
        {
            Stopwatch sw = new Stopwatch();

            var strTest =
@"eedadn
drvtee
eandsr
raavrd
atevrs
tsrnev
sdttsa
rasrtv
nssdts
ntnada
svetve
tesnvt
vntsnd
vrdear
dvrsen
enarar".Split(Environment.NewLine.ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
            sw.Start();
            var strPass = Day06Solution.GetPart1(strTest);
            sw.Stop();
            NUnit.Framework.Assert.AreEqual("easter", strPass);
        }

        public static void TestDay06Part2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var strTest =
@"eedadn
drvtee
eandsr
raavrd
atevrs
tsrnev
sdttsa
rasrtv
nssdts
ntnada
svetve
tesnvt
vntsnd
vrdear
dvrsen
enarar".Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var strPass = Day06Solution.GetPart2(strTest);
            sw.Stop();
            NUnit.Framework.Assert.AreEqual("advent", strPass);
        }
    }
}