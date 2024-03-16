using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LocalAPK.QR
{
    public class SystemUtils
    {
        public static int ReadInput(Stream sourceStream, sbyte[] target, int start, int count)
        {
            int result;
            if (target.Length == 0)
            {
                result = 0;
            }
            else
            {
                byte[] array = new byte[target.Length];
                int num = sourceStream.Read(array, start, count);
                if (num == 0)
                {
                    result = -1;
                }
                else
                {
                    for (int i = start; i < start + num; i++)
                    {
                        target[i] = (sbyte)array[i];
                    }
                    result = num;
                }
            }
            return result;
        }
        public static int ReadInput(TextReader sourceTextReader, short[] target, int start, int count)
        {
            int result;
            if (target.Length == 0)
            {
                result = 0;
            }
            else
            {
                char[] array = new char[target.Length];
                int num = sourceTextReader.Read(array, start, count);
                if (num == 0)
                {
                    result = -1;
                }
                else
                {
                    for (int i = start; i < start + num; i++)
                    {
                        target[i] = (short)array[i];
                    }
                    result = num;
                }
            }
            return result;
        }
        public static void WriteStackTrace(Exception throwable, TextWriter stream)
        {
            stream.Write(throwable.StackTrace);
            stream.Flush();
        }
        public static int URShift(int number, int bits)
        {
            int result;
            if (number >= 0)
            {
                result = number >> bits;
            }
            else
            {
                result = (number >> bits) + (2 << ~bits);
            }
            return result;
        }
        public static int URShift(int number, long bits)
        {
            return SystemUtils.URShift(number, (int)bits);
        }
        public static long URShift(long number, int bits)
        {
            long result;
            if (number >= 0L)
            {
                result = number >> bits;
            }
            else
            {
                result = (number >> bits) + (2L << ~bits);
            }
            return result;
        }
        public static long URShift(long number, long bits)
        {
            return SystemUtils.URShift(number, (int)bits);
        }
        public static byte[] ToByteArray(sbyte[] sbyteArray)
        {
            byte[] array = null;
            if (sbyteArray != null)
            {
                array = new byte[sbyteArray.Length];
                for (int i = 0; i < sbyteArray.Length; i++)
                {
                    array[i] = (byte)sbyteArray[i];
                }
            }
            return array;
        }
        public static byte[] ToByteArray(string sourceString)
        {
            return Encoding.UTF8.GetBytes(sourceString);
        }
        public static byte[] ToByteArray(object[] tempObjectArray)
        {
            byte[] array = null;
            if (tempObjectArray != null)
            {
                array = new byte[tempObjectArray.Length];
                for (int i = 0; i < tempObjectArray.Length; i++)
                {
                    array[i] = (byte)tempObjectArray[i];
                }
            }
            return array;
        }
        public static sbyte[] ToSByteArray(byte[] byteArray)
        {
            sbyte[] array = null;
            if (byteArray != null)
            {
                array = new sbyte[byteArray.Length];
                for (int i = 0; i < byteArray.Length; i++)
                {
                    array[i] = (sbyte)byteArray[i];
                }
            }
            return array;
        }
        public static char[] ToCharArray(sbyte[] sByteArray)
        {
            return Encoding.UTF8.GetChars(ToByteArray(sByteArray));
        }
        public static char[] ToCharArray(byte[] byteArray)
        {
            return Encoding.UTF8.GetChars(byteArray);
        }
    }
}
