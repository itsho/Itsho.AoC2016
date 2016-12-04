using System.Diagnostics;
using System.Drawing;

namespace Itsho.AoC2016.Solutions
{
    public static class Day02Solution
    {
        public static string GetPart1(string[] p_strRiddleSource)
        {
            int[,] arrKeyPad =
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            string strCode = string.Empty;

            Point pntLocation = new Point(1, 1);
            foreach (string strDigitCommands in p_strRiddleSource)
            {
                foreach (var chrCommand in strDigitCommands)
                {
                    var newLocation = Move(pntLocation, chrCommand, arrKeyPad);
                    var debugNewChar = arrKeyPad[newLocation.Y, newLocation.X];
                    Trace.Write(debugNewChar);

                    pntLocation = newLocation;
                }
                Trace.WriteLine("");
                var newCodeChar = arrKeyPad[pntLocation.Y, pntLocation.X];
                if (strCode == string.Empty || strCode[strCode.Length - 1].ToString() != newCodeChar.ToString())
                {
                    strCode += newCodeChar;
                }
            }

            return strCode;
        }

        private static Point Move(Point pntStartLocation, char p_chrCommand, int[,] p_arrKeyPad)
        {
            Point pntDestination = new Point(pntStartLocation.X, pntStartLocation.Y);

            if (p_chrCommand == 'U' && pntDestination.Y > 0)
            {
                pntDestination.Y--;
            }
            else if (p_chrCommand == 'L' && pntDestination.X > 0)
            {
                pntDestination.X--;
            }
            else if (p_chrCommand == 'R' && pntDestination.X < p_arrKeyPad.GetLength(0) - 1)
            {
                pntDestination.X++;
            }
            else if (p_chrCommand == 'D' && pntDestination.Y < p_arrKeyPad.GetLength(0) - 1)
            {
                pntDestination.Y++;
            }

            return pntDestination;
        }

        public static string GetPart2(string[] p_strRiddleSource)
        {
            char[,] arrKeyPad =
            {
                {'-', '-', '1','-','-'},
                {'-', '2', '3','4','-'},
                {'5', '6', '7','8','9'},
                {'-', 'A', 'B','C','-'},
                {'-', '-', 'D','-','-'},
            };

            string strCode = string.Empty;

            // start location is [0,2] == digit '5'
            Point pntLocation = new Point(0, 2);

            foreach (string strDigitCommands in p_strRiddleSource)
            {
                foreach (var chrCommand in strDigitCommands)
                {
                    var debugCurrChar = arrKeyPad[pntLocation.Y, pntLocation.X];
                    var newLocation = Move2(pntLocation, chrCommand, arrKeyPad);
                    var debugNewChar = arrKeyPad[newLocation.Y, newLocation.X];

                    Trace.WriteLine($@"Start: {debugCurrChar} Direction: {chrCommand} End: {debugNewChar}");

                    pntLocation = newLocation;
                }
                var newCodeChar = arrKeyPad[pntLocation.Y, pntLocation.X];
                if (strCode == string.Empty || strCode[strCode.Length - 1].ToString() != newCodeChar.ToString())
                {
                    strCode += newCodeChar;
                }
            }

            return strCode;
        }

        private static Point Move2(Point p_pntStartLocation, char p_chrCommand, char[,] p_arrKeyPad)
        {
            var pntDestination = new Point(p_pntStartLocation.X, p_pntStartLocation.Y);

            const char ILLEGAL_CHAR = '-';

            if (p_chrCommand == 'U' && pntDestination.Y > 0 &&
                p_arrKeyPad[pntDestination.Y - 1, pntDestination.X] != ILLEGAL_CHAR)
            {
                pntDestination.Y--;
            }
            else if (p_chrCommand == 'L' && pntDestination.X > 0 &&
                p_arrKeyPad[pntDestination.Y, pntDestination.X - 1] != ILLEGAL_CHAR)
            {
                pntDestination.X--;
            }
            else if (p_chrCommand == 'R' && pntDestination.X < p_arrKeyPad.GetLength(0) - 1 &&
                p_arrKeyPad[pntDestination.Y, pntDestination.X + 1] != ILLEGAL_CHAR)
            {
                pntDestination.X++;
            }
            else if (p_chrCommand == 'D' &&
                pntDestination.Y < p_arrKeyPad.GetLength(1) - 1 &&
                 p_arrKeyPad[pntDestination.Y + 1, pntDestination.X] != ILLEGAL_CHAR)
            {
                pntDestination.Y++;
            }

            return pntDestination;
        }
    }
}