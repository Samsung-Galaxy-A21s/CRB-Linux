using System;
using System.IO;
using System.Security.Cryptography;

namespace LocalAPK.DA
{
    public static class HashHelper
    {
        public static string GetMd5HashForFile(string pathAndFileName)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(pathAndFileName))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "‌​").ToUpper();
                }
            }
        }
    }
}
