using System;
using System.Linq;

namespace Itsho.AoC2016.Solutions
{
    public static class Day08Solution
    {
        #region Consts

        public const int LCD_SCREEN_WIDTH = 50;
        public const int LCD_SCREEN_HEIGHT = 6;

        private const char COMMAND_PARTS_SEPERATOR = ' ';
        private const string COMMAND_CREATE_RECTANGLE = "rect";
        private const string COMMAND_ROTATE = "rotate";
        private const string COMMAND_ROTATE_OP_COLUMN = "column";
        private const string COMMAND_ROTATE_OP_ROW = "row";

        private const char LCD_EMPTY_CELL = ' ';

        //http://www.fileformat.info/info/unicode/char/2588/index.htm
        //ASCII 219
        private const char LCD_FULL_CELL = '█';

        #endregion Consts

        #region public methods

        public static int GetPart1(string[] p_strRiddleSource)
        {
            var arrLeds = new char[LCD_SCREEN_HEIGHT, LCD_SCREEN_WIDTH];

            InitLCD(arrLeds);

            foreach (var strSingleCommand in p_strRiddleSource)
            {
                RunSingleCommand(arrLeds, strSingleCommand);
                // DEBUG: DisplayLCDContent(arrLeds);
            }

            // DEBUG: DisplayLCDContent(arrLeds);

            var intTotalLedsOn = arrLeds.Cast<char>().Count(chrLed => chrLed == LCD_FULL_CELL);

            return intTotalLedsOn;
        }

        public static char[,] GetPart2(string[] p_strRiddleSource)
        {
            var arrLeds = new char[LCD_SCREEN_HEIGHT, LCD_SCREEN_WIDTH];
            InitLCD(arrLeds);

            foreach (var strSingleCommand in p_strRiddleSource)
            {
                RunSingleCommand(arrLeds, strSingleCommand);
            }

            return arrLeds;
        }

       /* public static string[] GetPart2AsLines(string[] p_strRiddleSource)
        {
            var arrLedsPart2 = GetPart2(p_strRiddleSource);
            string.Join("", arrLedsPart2);
            var arrLedLines = new string[LCD_SCREEN_HEIGHT];
            for (int intRow = 0; intRow < LCD_SCREEN_HEIGHT; intRow++)
            {
                arrLedLines[intRow] = new string(arrLedsPart2[intRow,]);
            }
        }*/

        public static void DisplayLCDContent(char[,] p_arrLeds)
        {
            for (int intRow = 0; intRow < LCD_SCREEN_HEIGHT; intRow++)
            {
                for (int intCol = 0; intCol < LCD_SCREEN_WIDTH; intCol++)
                {
                    Console.Write(p_arrLeds[intRow, intCol]);
                }
                Console.WriteLine();
            }
        }

        #endregion public methods

        #region Private methods

        private static void InitLCD(char[,] p_arrLeds)
        {
            for (int intRow = 0; intRow < LCD_SCREEN_HEIGHT; intRow++)
            {
                for (int intCol = 0; intCol < LCD_SCREEN_WIDTH; intCol++)
                {
                    p_arrLeds[intRow, intCol] = LCD_EMPTY_CELL;
                }
            }
        }

        private static void RunSingleCommand(char[,] p_arrLeds, string p_strSingleCommand)
        {
            string strCommandName = p_strSingleCommand.Split(COMMAND_PARTS_SEPERATOR)[0];

            switch (strCommandName)
            {
                case COMMAND_CREATE_RECTANGLE:
                    var arrRectSize = p_strSingleCommand.Split(COMMAND_PARTS_SEPERATOR)[1].Split('x');
                    var intRectWidth = Convert.ToInt32(arrRectSize[0]);
                    var intRectHeight = Convert.ToInt32(arrRectSize[1]);

                    CreateRectangleOnTopLeft(p_arrLeds, intRectWidth, intRectHeight);
                    break;

                case COMMAND_ROTATE:
                    var strOperator = p_strSingleCommand.Split(COMMAND_PARTS_SEPERATOR)[1];
                    var coordVal = Convert.ToInt32(p_strSingleCommand.Split(COMMAND_PARTS_SEPERATOR)[2].Split('=')[1]);
                    var byVal = Convert.ToInt32(p_strSingleCommand.Split(COMMAND_PARTS_SEPERATOR)[4]);
                    Rotate(p_arrLeds, strOperator, coordVal, byVal);
                    break;
            }
        }

        /// <summary>
        /// Example: "rotate column x=34 by 2"
        /// Example: "rotate row y=3 by 5"
        /// </summary>
        private static void Rotate(char[,] p_arrLeds, string p_strColumnOrRow, int p_intStartIndex, int p_intByValue)
        {
            for (int intCounter = 0; intCounter < p_intByValue; intCounter++)
            {
                if (p_strColumnOrRow == COMMAND_ROTATE_OP_COLUMN)
                {
                    #region Rotate column

                    char chrCurrentValue = p_arrLeds[LCD_SCREEN_HEIGHT - 1, p_intStartIndex];

                    for (int intIndex = LCD_SCREEN_HEIGHT - 1; intIndex > 0; intIndex--)
                    {
                        p_arrLeds[intIndex, p_intStartIndex] = p_arrLeds[intIndex - 1, p_intStartIndex];
                    }
                    p_arrLeds[0, p_intStartIndex] = chrCurrentValue;

                    #endregion Rotate column
                }
                else if (p_strColumnOrRow == COMMAND_ROTATE_OP_ROW)
                {
                    #region Rotate Row

                    char chrCurrentValue = p_arrLeds[p_intStartIndex, LCD_SCREEN_WIDTH - 1];

                    for (int intIndex = LCD_SCREEN_WIDTH - 1; intIndex > 0; intIndex--)
                    {
                        p_arrLeds[p_intStartIndex, intIndex] = p_arrLeds[p_intStartIndex, intIndex - 1];
                    }
                    p_arrLeds[p_intStartIndex, 0] = chrCurrentValue;

                    #endregion Rotate Row
                }
            }
        }

        /// <summary>
        /// Example: "rect 19x1"
        /// Example: "rect 7x1"
        /// </summary>
        private static void CreateRectangleOnTopLeft(char[,] p_arrLeds, int p_intWidth, int p_intHeight)
        {
            for (int intRow = 0; intRow < p_intHeight; intRow++)
            {
                for (int intCol = 0; intCol < p_intWidth; intCol++)
                {
                    p_arrLeds[intRow, intCol] = LCD_FULL_CELL;
                }
            }
        }

        #endregion Private methods
    }
}