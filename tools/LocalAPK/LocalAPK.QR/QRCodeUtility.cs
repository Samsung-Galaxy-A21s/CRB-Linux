using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalAPK.QR
{
    public class QRCodeUtility
    {
        public static int sqrt(int val)
        {
            int num = 0;
            int num2 = 32768;
            int num3 = 15;
            do
            {
                int num4;
                if (val >= (num4 = (num << 1) + num2 << (num3-- & 31)))
                {
                    num += num2;
                    val -= num4;
                }
            }
            while ((num2 >>= 1) > 0);
            return num;
        }
        public static bool IsUniCode(string value)
        {
            byte[] characters = QRCodeUtility.AsciiStringToByteArray(value);
            byte[] characters2 = QRCodeUtility.UnicodeStringToByteArray(value);
            string a = QRCodeUtility.FromASCIIByteArray(characters);
            string b = QRCodeUtility.FromUnicodeByteArray(characters2);
            return a != b;
        }
        public static bool IsUnicode(byte[] byteData)
        {
            string str = QRCodeUtility.FromASCIIByteArray(byteData);
            string str2 = QRCodeUtility.FromUnicodeByteArray(byteData);
            byte[] array = QRCodeUtility.AsciiStringToByteArray(str);
            byte[] array2 = QRCodeUtility.UnicodeStringToByteArray(str2);
            return array[0] != array2[0];
        }
        public static string FromASCIIByteArray(byte[] characters)
        {
            ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
            return aSCIIEncoding.GetString(characters);
        }
        public static string FromUnicodeByteArray(byte[] characters)
        {
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            return unicodeEncoding.GetString(characters);
        }
        public static byte[] AsciiStringToByteArray(string str)
        {
            ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
            return aSCIIEncoding.GetBytes(str);
        }
        public static byte[] UnicodeStringToByteArray(string str)
        {
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            return unicodeEncoding.GetBytes(str);
        }
    }
}
