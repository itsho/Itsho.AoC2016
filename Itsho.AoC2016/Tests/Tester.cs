using Itsho.AoC2016.Solutions;

namespace Itsho.AoC2016.Tests
{
    public static class Tester
    {
        public static void TestDay1Part1()
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

        public static void TestDay1Part2()
        {
            var intPart2 = Day01Solution.GetPart2DistanceFromAlreadyVisit("R8, R4, R4, R8");
            NUnit.Framework.Assert.AreEqual(4, intPart2);

            intPart2 = Day01Solution.GetPart2DistanceFromAlreadyVisit("R1, R1, R2, R2, R3, R3, R2, R2");
            NUnit.Framework.Assert.AreEqual(1, intPart2);

            intPart2 = Day01Solution.GetPart2DistanceFromAlreadyVisit("R1, R2, R2, R3, R3, R2, R5");
            NUnit.Framework.Assert.AreEqual(2, intPart2);
        }

        public static void TestDay2Part1()
        {
        }

        public static void TestDay2Part2()
        {
        }
    }
}