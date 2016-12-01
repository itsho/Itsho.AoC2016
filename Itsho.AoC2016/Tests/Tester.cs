using Itsho.AoC2016.Solutions;
using System.Diagnostics;

namespace Itsho.AoC2016.Tests
{
    public static class Tester
    {
        public static void TestDay1Part1()
        {
            int? intPart2;
            var intPart1 = Day01Solution.GetDistanceFromStartingPoint("R5, L5, R5, R3", out intPart2);
            Debug.Assert(intPart1 == 12);

            intPart1 = Day01Solution.GetDistanceFromStartingPoint("R5, R5, R5, R5", out intPart2);
            Debug.Assert(intPart1 == 0);

            intPart1 = Day01Solution.GetDistanceFromStartingPoint("R5, R5, R5, R5, R5, R5, R5, R5", out intPart2);
            Debug.Assert(intPart1 == 0);

            intPart1 = Day01Solution.GetDistanceFromStartingPoint("R5, R5, L5, R5, R5, L5, L5, L5", out intPart2);
            Debug.Assert(intPart1 == 20);
        }

        public static void TestDay1Part2()
        {
            int? intPart2;
            var intPart1 = Day01Solution.GetDistanceFromStartingPoint("R8, R4, R4, R8", out intPart2);
            Debug.Assert(intPart1 == 8 && intPart2 == 4);

            intPart1 = Day01Solution.GetDistanceFromStartingPoint("R1, R1, R2, R2, R3, R3, R2, R2", out intPart2);
            Debug.Assert(intPart1 == 0 && intPart2 == 1);

            intPart1 = Day01Solution.GetDistanceFromStartingPoint("R1, R2, R2, R3, R3, R2, R5", out intPart2);
            Debug.Assert(intPart1 == 4 && intPart2 == 2);
        }
    }
}