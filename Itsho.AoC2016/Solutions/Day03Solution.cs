using System;

namespace Itsho.AoC2016.Solutions
{
    public static class Day03Solution
    {
        public static int GetPart1TotalPossibleTriangles(string[] p_strRiddleSource)
        {
            int intCounter = 0;
            foreach (var strTriangle in p_strRiddleSource)
            {
                if (IsValidTriangle(strTriangle))
                {
                    intCounter++;
                }
            }

            return intCounter;
        }

        public static int GetPart2TotalPossibleTrianglesVertically(string[] p_strRiddleSource)
        {
            if (p_strRiddleSource.Length % 3 != 0)
            {
                throw new Exception("This code does NOT work if source has total rows non divisable by 3");
            }
            int intCounter = 0;

            // get 3 triangles VERTICALLY every time
            for (int intThreeTriangle = 0; intThreeTriangle < p_strRiddleSource.Length; intThreeTriangle += 3)
            {
                // read 3 lines:
                var arrLine1 = p_strRiddleSource[intThreeTriangle].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var arrLine2 = p_strRiddleSource[intThreeTriangle + 1].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var arrLine3 = p_strRiddleSource[intThreeTriangle + 2].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                var strTriangle1 = arrLine1[0] + ' ' + arrLine2[0] + ' ' + arrLine3[0];
                var strTriangle2 = arrLine1[1] + ' ' + arrLine2[1] + ' ' + arrLine3[1];
                var strTriangle3 = arrLine1[2] + ' ' + arrLine2[2] + ' ' + arrLine3[2];

                if (IsValidTriangle(strTriangle1))
                {
                    intCounter++;
                }
                if (IsValidTriangle(strTriangle2))
                {
                    intCounter++;
                }
                if (IsValidTriangle(strTriangle3))
                {
                    intCounter++;
                }
            }
            return intCounter;
        }

        public static bool IsValidTriangle(string p_stringTriangle)
        {
            var arrTriangle = p_stringTriangle.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            int intPart1 = Convert.ToInt32(arrTriangle[0]);
            int intPart2 = Convert.ToInt32(arrTriangle[1]);
            int intPart3 = Convert.ToInt32(arrTriangle[2]);
            if (intPart1 + intPart2 > intPart3 &&
                intPart2 + intPart3 > intPart1 &&
                intPart3 + intPart1 > intPart2)
            {
                return true;
            }
            return false;
        }
    }
}