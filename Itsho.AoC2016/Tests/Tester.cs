using Itsho.AoC2016.Solutions;

namespace Itsho.AoC2016.Tests
{
    public static class Tester
    {
        public static void TestDay1Part1()
        {
            int? intPart2;
            var intPart1 = Day01Solution.GetDistanceFromStartingPoint("R5, L5, R5, R3", out intPart2);
            NUnit.Framework.Assert.AreEqual(12, intPart1);

            intPart1 = Day01Solution.GetDistanceFromStartingPoint("R5, R5, R5, R5", out intPart2);
            NUnit.Framework.Assert.AreEqual(0, intPart1);

            intPart1 = Day01Solution.GetDistanceFromStartingPoint("R5, R5, R5, R5, R5, R5, R5, R5", out intPart2);
            NUnit.Framework.Assert.AreEqual(0, intPart1);

            intPart1 = Day01Solution.GetDistanceFromStartingPoint("R5, R5, L5, R5, R5, L5, L5, L5", out intPart2);
            NUnit.Framework.Assert.AreEqual(20, intPart1);
        }

        public static void TestDay1Part2()
        {
            int? intPart2;
            var intPart1 = Day01Solution.GetDistanceFromStartingPoint("R8, R4, R4, R8", out intPart2);
            NUnit.Framework.Assert.AreEqual(8, intPart1);
            NUnit.Framework.Assert.AreEqual(4, intPart2);

            intPart1 = Day01Solution.GetDistanceFromStartingPoint("R1, R1, R2, R2, R3, R3, R2, R2", out intPart2);
            NUnit.Framework.Assert.AreEqual(0, intPart1);
            NUnit.Framework.Assert.AreEqual(1, intPart2);

            intPart1 = Day01Solution.GetDistanceFromStartingPoint("R1, R2, R2, R3, R3, R2, R5", out intPart2);
            NUnit.Framework.Assert.AreEqual(4, intPart1);
            NUnit.Framework.Assert.AreEqual(2, intPart2);
        }
    }
}