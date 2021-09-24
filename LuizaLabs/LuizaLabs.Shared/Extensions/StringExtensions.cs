using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LuizaLabs.Shared.Extensions
{
    public class StringExtensions
    {
        public static string ReadHtml(string file, Dictionary<string, string> variables)
        {
            var appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var body = File.ReadAllText($"{appPath}\\Templates\\{file}");

            foreach (var variable in variables)
                body = body.Replace($"##{variable.Key.ToUpper()}##", variable.Value);

            return body;
        }

        public static string EncryptPassword(string password)
        {
            var encoding = new UnicodeEncoding();
            byte[] hashBytes;
            using (HashAlgorithm hash = SHA1.Create())
                hashBytes = hash.ComputeHash(encoding.GetBytes(password));

            var hashValue = new StringBuilder(hashBytes.Length * 2);
            foreach (byte b in hashBytes)
            {
                hashValue.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
            }

            return hashValue.ToString();
        }
    }
}
