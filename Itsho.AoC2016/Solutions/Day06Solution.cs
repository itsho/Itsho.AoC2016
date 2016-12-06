using System.Collections.Generic;
using System.Linq;

namespace Itsho.AoC2016.Solutions
{
    /// <summary>
    /// we assume all rows have the same length
    /// </summary>
    public static class Day06Solution
    {
        public static string GetPart1(string[] p_strRiddleSource)
        {
            var dicColumnAsString = GetColumnsAsStrings(p_strRiddleSource);

            string strPassword = string.Empty;

            foreach (int intColumn in dicColumnAsString.Keys)
            {
                var lstCharsInColumn = dicColumnAsString[intColumn].ToCharArray();
                var mostCommonChar = (from singleChar in lstCharsInColumn
                                      group singleChar by singleChar into charsGroup
                                      orderby charsGroup.Count() descending
                                      select charsGroup.Key).First();

                strPassword += mostCommonChar;
            }
            return strPassword;
        }

        public static string GetPart2(string[] p_strRiddleSource)
        {
            var dicColumnAsString = GetColumnsAsStrings(p_strRiddleSource);
            string strPassword = string.Empty;

            foreach (int intColumn in dicColumnAsString.Keys)
            {
                var lstCharsInColumn = dicColumnAsString[intColumn].ToCharArray();
                var mostCommonChar = (from singleChar in lstCharsInColumn
                                      group singleChar by singleChar into charsGroup
                                      orderby charsGroup.Count() ascending
                                      select charsGroup.Key).First();

                strPassword += mostCommonChar;
            }
            return strPassword;
        }

        private static Dictionary<int, string> GetColumnsAsStrings(string[] p_strRiddleSource)
        {
            Dictionary<int, string> dicColumnAsString = new Dictionary<int, string>();
            for (int intColumn = 0; intColumn < p_strRiddleSource[0].Length; intColumn++)
            {
                for (int intRow = 0; intRow < p_strRiddleSource.Length; intRow++)
                {
                    if (dicColumnAsString.ContainsKey(intColumn))
                    {
                        dicColumnAsString[intColumn] += p_strRiddleSource[intRow][intColumn];
                    }
                    else
                    {
                        dicColumnAsString.Add(intColumn, p_strRiddleSource[intRow][intColumn].ToString());
                    }
                }
            }

            return dicColumnAsString;
        }
    }
}