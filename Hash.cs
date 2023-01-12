using System.Security.Cryptography;
using System.Text;

namespace RocketLeagueGui
{
    public static class Hash
    {
        private static readonly MD5 Md5 = MD5.Create();

        internal static string GetMd5(string input)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = Md5.ComputeHash(inputBytes);
            //byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            foreach (byte t in hashBytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
