using System;
using System.Linq;
using System.Threading.Tasks;

namespace Itsho.AoC2016.Solutions
{
    public static class Day05Solution
    {
        private const string HASH_TO_FIND = "00000";
        private const int PASSWORD_LENGTH = 8;

        public static string GetPart1(string p_strRiddleSource)
        {
            var strPassword = string.Empty;

            for (int intNumbersPadding = 0; strPassword.Length < PASSWORD_LENGTH && intNumbersPadding < int.MaxValue; intNumbersPadding++)
            {
                var strHash = CreateMD5(p_strRiddleSource + intNumbersPadding.ToString());
                if (strHash.StartsWith(HASH_TO_FIND))
                {
                    strPassword += strHash[5];
                }
            }

            return strPassword;
        }

        public static string GetPart2(string p_strRiddleSource)
        {
            const char EMPTY_CHAR = ' ';

            char[] arrPassword = new char[PASSWORD_LENGTH] { EMPTY_CHAR, EMPTY_CHAR, EMPTY_CHAR, EMPTY_CHAR, EMPTY_CHAR, EMPTY_CHAR, EMPTY_CHAR, EMPTY_CHAR };

            for (int intNumbersPadding = 0; intNumbersPadding < int.MaxValue; intNumbersPadding++)
            {
                var strHash = CreateMD5(p_strRiddleSource + intNumbersPadding);
                if (strHash.StartsWith(HASH_TO_FIND))
                {
                    const int POSITION_CHAR = 5;

                    if ((char)strHash[POSITION_CHAR] < '0' ||
                        (char)strHash[POSITION_CHAR] > '7')
                    {
                        // move to next padding
                        //return;
                        continue;
                    }

                    int intPosition = int.Parse(strHash[POSITION_CHAR].ToString());
                    char chrValue = strHash[6];

                    // only if placeholder IS empty
                    if (arrPassword[intPosition] == EMPTY_CHAR)
                    {
                        // use new char
                        arrPassword[intPosition] = chrValue;
                    }
                }
                var strPasswordTemp = String.Join("", arrPassword);
                if (strPasswordTemp.Length == 8 && !strPasswordTemp.Contains(EMPTY_CHAR))
                {
                    return strPasswordTemp;
                }
            }
            var strPassword = String.Join("", arrPassword);

            return strPassword;
        }

        public static string GetPart2MultiThread(string p_strRiddleSource)
        {
            const char EMPTY_CHAR = ' ';

            char[] arrPassword = new char[PASSWORD_LENGTH] { EMPTY_CHAR, EMPTY_CHAR, EMPTY_CHAR, EMPTY_CHAR, EMPTY_CHAR, EMPTY_CHAR, EMPTY_CHAR, EMPTY_CHAR };

            var range = Enumerable.Range(0, int.MaxValue / 100).ToArray();

            Parallel.ForEach(range,
                (value, loopState, index) =>
                {
                    if (loopState.IsStopped || loopState.IsExceptional)
                    {
                        return;
                    }

                    var strHash = CreateMD5(p_strRiddleSource + value);
                    if (strHash.StartsWith(HASH_TO_FIND))
                    {
                        const int POSITION_CHAR = 5;

                        if ((char)strHash[POSITION_CHAR] < '0' ||
                            (char)strHash[POSITION_CHAR] > '7')
                        {
                            // move to next padding
                            return;
                        }

                        int intPosition = int.Parse(strHash[POSITION_CHAR].ToString());
                        char chrValue = strHash[6];

                        // only if placeholder IS empty
                        if (arrPassword[intPosition] == EMPTY_CHAR)
                        {
                            // use new char
                            arrPassword[intPosition] = chrValue;
                        }
                    }
                    var strPasswordTemp = String.Join("", arrPassword);
                    if (strPasswordTemp.Length == 8 && !strPasswordTemp.Contains(EMPTY_CHAR))
                    {
                        loopState.Break();
                        return;// strPasswordTemp;
                    }
                });

            var strPassword = String.Join("", arrPassword);

            return strPassword;
        }

        private static string CreateMD5(string p_strInput)
        {
            // http://stackoverflow.com/a/9770519/426315
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(p_strInput);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            }
        }
    }
}