using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Itsho.AoC2016.Solutions
{
    public static class Day04Solution
    {
        public static double GetPart1SumOfSectorIDsOfTheRealRooms(string[] p_strRiddleSource)
        {
            double intValidRoomSectorsIDSum = 0;
            foreach (var strRoom in p_strRiddleSource)
            {
                if (IsRealRoom(strRoom))
                {
                    intValidRoomSectorsIDSum += GetSectorID(strRoom);
                }
            }
            return intValidRoomSectorsIDSum;
        }

        public static bool IsRealRoom(string p_strRoom)
        {
            var arrRoomParts = p_strRoom.Split('-');
            // last part is sectorid[checksum]

            // count distinct letters
            Dictionary<char, int> dictionaryCharsCounter = new Dictionary<char, int>();
            for (int intRoomPart = 0; intRoomPart < arrRoomParts.Length - 1; intRoomPart++)
            {
                foreach (var chrSingleChar in arrRoomParts[intRoomPart])
                {
                    if (dictionaryCharsCounter.ContainsKey(chrSingleChar))
                    {
                        dictionaryCharsCounter[chrSingleChar]++;
                    }
                    else
                    {
                        dictionaryCharsCounter.Add(chrSingleChar, 1);
                    }
                }
            }

            // sort alphabetically

            // get checksum
            var strCheckSum = GetCheckSum(arrRoomParts);
            //var strSectorID = GetSectorID(arrRoomParts);
            var lstCharsByOrder = (from singlePair in dictionaryCharsCounter
                                   orderby singlePair.Key ascending
                                   orderby singlePair.Value descending
                                   select singlePair.Key).ToList();

            var blnIsChecksumValid = IsCheckSumValid(strCheckSum, lstCharsByOrder);

            return blnIsChecksumValid;
        }

        private static int GetSectorID(string p_strSingleRoom)
        {
            var arrRoomParts = p_strSingleRoom.Split('-');

            var arrLastPart = arrRoomParts[arrRoomParts.Length - 1].TrimEnd(']').Split('[');
            var strSectorID = arrLastPart[0];
            return int.Parse(strSectorID);
        }

        private static string GetCheckSum(string[] p_arrRoomParts)
        {
            var arrLastPart = p_arrRoomParts[p_arrRoomParts.Length - 1].TrimEnd(']').Split('[');
            var strCheckSum = arrLastPart[1];
            return strCheckSum;
        }

        private static bool IsCheckSumValid(string p_strCheckSum, IReadOnlyList<char> p_lstCharsByOrder)
        {
            bool blnIsChecksumValid = true;
            for (int intSingleChecksumIndex = 0;
                blnIsChecksumValid && intSingleChecksumIndex < p_strCheckSum.Length;
                intSingleChecksumIndex++)
            {
                if (p_lstCharsByOrder[intSingleChecksumIndex] != p_strCheckSum[intSingleChecksumIndex])
                {
                    blnIsChecksumValid = false;
                }
            }
            return blnIsChecksumValid;
        }

        public static int GetPart2GetSectorID(string[] p_strRiddleSource)
        {
            var dicrionaryDecryptedRoomsWithSectorId= new Dictionary<string,int>();

            foreach (var strRoom in p_strRiddleSource)
            {
                dicrionaryDecryptedRoomsWithSectorId.Add(DecryptRoomName(strRoom),GetSectorID(strRoom));
            }

            var intSectorIdNorthRoom = dicrionaryDecryptedRoomsWithSectorId.FirstOrDefault(r => r.Key.Contains("north")).Value;
           
            return intSectorIdNorthRoom;
             
        }

        public static string DecryptRoomName(string p_strRoom)
        {
            string strTemp = string.Empty;
            int intSectorId = GetSectorID(p_strRoom);

            var strRoomNameEncrypted = p_strRoom.Substring(0, p_strRoom.LastIndexOf('-'));

            foreach (var chrInRoom in strRoomNameEncrypted)
            {
                // '-' ALWAYS become space
                if (chrInRoom == '-')
                {
                    strTemp += ' ';
                }
                else
                {
                    char chrResult = ShiftChar(chrInRoom, intSectorId);
                    strTemp += chrResult;
                }
            }

            return strTemp;
        }

        private static char ShiftChar(char p_chrInRoom, int p_intSectorId)
        {
            char chrResult = p_chrInRoom;

            // a + 1 == b
            // z + 1 == a
            // shift char X times (according to the room sector id)
            for (int intShift = 0; intShift < p_intSectorId; intShift++)
            {
                if (chrResult < 'z')
                {
                    chrResult++;
                }
                else if (chrResult == 'z')
                {
                    chrResult = 'a';
                }
                else
                {
                    Debugger.Break();
                }
            }
            return chrResult;
        }
    }
}