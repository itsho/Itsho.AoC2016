using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Itsho.AoC2016.Solutions
{
    public static class Day07Solution
    {
        public static int GetPart1(string[] p_strRiddleSource)
        {
            return p_strRiddleSource.Count(DoesIPv7SupportsTLS);
        }

        public static int GetPart2(string[] p_strRiddleSource)
        {
            return p_strRiddleSource.Count(DoesIPv7SupportsSSL);
        }

        private static bool DoesIPv7SupportsSSL(string p_strIPv7)
        {
            string[] arrIPv7Parts = Regex.Split(p_strIPv7, @"\[[^\]]*\]");
            foreach (string strIpPart in arrIPv7Parts)
            {
                List<string> aba = GetABAFromSeq(strIpPart);
                foreach (var val in aba)
                {
                    string bab = val[1].ToString() + val[0].ToString() + val[1].ToString();
                    foreach (Match m in Regex.Matches(p_strIPv7, @"\[(\w*)\]"))
                    {
                        if (m.Value.Contains(bab))
                            return true;
                    }
                }
            }
            return false;
        }

        private static List<string> GetABAFromSeq(string p_strIpv7Part)
        {
            List<string> lstResult = new List<string>();
            for (int intIndex = 0; intIndex < p_strIpv7Part.Length - 2; intIndex++)
            {
                if (p_strIpv7Part[intIndex] == p_strIpv7Part[intIndex + 2] &&
                    p_strIpv7Part[intIndex] != p_strIpv7Part[intIndex + 1])
                {
                    lstResult.Add(string.Format("{0}{1}{2}",
                        p_strIpv7Part[intIndex].ToString(),
                        p_strIpv7Part[intIndex + 1].ToString(),
                        p_strIpv7Part[intIndex + 2].ToString()));
                }
            }

            return lstResult;
        }

        private static bool DoesIPv7SupportsTLS(string p_strIPv7)
        {
            // Check in hypernet
            if (Regex.Matches(p_strIPv7, @"\[(\w*)\]").Cast<Match>().Any(singleMatch => DoesContainABBA(singleMatch.Value)))
            {
                return false;
            }

            string[] arrIPV7 = Regex.Split(p_strIPv7, @"\[[^\]]*\]");
            foreach (var strIPv7Part in arrIPV7)
            {
                if (DoesContainABBA(strIPv7Part))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool DoesContainABBA(string p_strIpv7Part)
        {
            for (int i = 0; i < p_strIpv7Part.Length - 3; i++)
            {
                if (p_strIpv7Part[i] == p_strIpv7Part[i + 3] &&
                    p_strIpv7Part[i + 1] == p_strIpv7Part[i + 2] &&
                    p_strIpv7Part[i] != p_strIpv7Part[i + 1])
                {
                    return true;
                }
            }

            return false;
        }
    }
}