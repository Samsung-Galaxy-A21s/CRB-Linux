using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using LocalAPK.QR.Properties;

namespace LocalAPK.QR
{
    public class QRCodeEncoder
    {
        public enum ENCODE_MODE
        {
            ALPHA_NUMERIC,
            NUMERIC,
            BYTE
        }
        public enum ERROR_CORRECTION
        {
            L,
            M,
            Q,
            H
        }
        internal QRCodeEncoder.ERROR_CORRECTION qrcodeErrorCorrect;
        internal QRCodeEncoder.ENCODE_MODE qrcodeEncodeMode;
        internal int qrcodeVersion;
        internal int qrcodeStructureappendN;
        internal int qrcodeStructureappendM;
        internal int qrcodeStructureappendParity;
        internal Color qrCodeBackgroundColor;
        internal Color qrCodeForegroundColor;
        internal int qrCodeScale;
        internal string qrcodeStructureappendOriginaldata;
        public virtual QRCodeEncoder.ERROR_CORRECTION QRCodeErrorCorrect
        {
            get
            {
                return this.qrcodeErrorCorrect;
            }
            set
            {
                this.qrcodeErrorCorrect = value;
            }
        }
        public virtual int QRCodeVersion
        {
            get
            {
                return this.qrcodeVersion;
            }
            set
            {
                if (value >= 0 && value <= 40)
                {
                    this.qrcodeVersion = value;
                }
            }
        }
        public virtual QRCodeEncoder.ENCODE_MODE QRCodeEncodeMode
        {
            get
            {
                return this.qrcodeEncodeMode;
            }
            set
            {
                this.qrcodeEncodeMode = value;
            }
        }
        public virtual int QRCodeScale
        {
            get
            {
                return this.qrCodeScale;
            }
            set
            {
                this.qrCodeScale = value;
            }
        }
        public virtual Color QRCodeBackgroundColor
        {
            get
            {
                return this.qrCodeBackgroundColor;
            }
            set
            {
                this.qrCodeBackgroundColor = value;
            }
        }
        public virtual Color QRCodeForegroundColor
        {
            get
            {
                return this.qrCodeForegroundColor;
            }
            set
            {
                this.qrCodeForegroundColor = value;
            }
        }
        public QRCodeEncoder()
        {
            this.qrcodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            this.qrcodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            this.qrcodeVersion = 7;
            this.qrcodeStructureappendN = 0;
            this.qrcodeStructureappendM = 0;
            this.qrcodeStructureappendParity = 0;
            this.qrcodeStructureappendOriginaldata = "";
            this.qrCodeScale = 4;
            this.qrCodeBackgroundColor = Color.White;
            this.qrCodeForegroundColor = Color.Black;
        }
        public virtual void setStructureappend(int m, int n, int p)
        {
            if (n > 1 && n <= 16 && m > 0 && m <= 16 && p >= 0 && p <= 255)
            {
                this.qrcodeStructureappendM = m;
                this.qrcodeStructureappendN = n;
                this.qrcodeStructureappendParity = p;
            }
        }
        public virtual int calStructureappendParity(sbyte[] originaldata)
        {
            int i = 0;
            int num = 0;
            int num2 = originaldata.Length;
            if (num2 > 1)
            {
                num = 0;
                while (i < num2)
                {
                    num ^= ((int)originaldata[i] & 255);
                    i++;
                }
            }
            else
            {
                num = -1;
            }
            return num;
        }
        public virtual bool[][] calQrcode(byte[] qrcodeData)
        {
            int num = 0;
            int num2 = qrcodeData.Length;
            int[] array = new int[num2 + 32];
            sbyte[] array2 = new sbyte[num2 + 32];
            bool[][] result;
            if (num2 <= 0)
            {
                bool[][] array3 = new bool[1][];
                bool[][] arg_3B_0 = array3;
                int arg_3B_1 = 0;
                bool[] array4 = new bool[1];
                arg_3B_0[arg_3B_1] = array4;
                bool[][] array5 = array3;
                result = array5;
            }
            else
            {
                if (this.qrcodeStructureappendN > 1)
                {
                    array[0] = 3;
                    array2[0] = 4;
                    array[1] = this.qrcodeStructureappendM - 1;
                    array2[1] = 4;
                    array[2] = this.qrcodeStructureappendN - 1;
                    array2[2] = 4;
                    array[3] = this.qrcodeStructureappendParity;
                    array2[3] = 8;
                    num = 4;
                }
                array2[num] = 4;
                int[] array6;
                int num3;
                switch (this.qrcodeEncodeMode)
                {
                    case QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC:
                        {
                            array6 = new int[]
							{
								0, 
								0, 
								0, 
								0, 
								0, 
								0, 
								0, 
								0, 
								0, 
								0, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								4, 
								4, 
								4, 
								4, 
								4, 
								4, 
								4, 
								4, 
								4, 
								4, 
								4, 
								4, 
								4, 
								4
							};
                            array[num] = 2;
                            num++;
                            array[num] = num2;
                            array2[num] = 9;
                            num3 = num;
                            num++;
                            for (int i = 0; i < num2; i++)
                            {
                                char c = (char)qrcodeData[i];
                                sbyte b = 0;
                                if (c >= '0' && c < ':')
                                {
                                    b = (sbyte)(c - '0');
                                }
                                else
                                {
                                    if (c >= 'A' && c < '[')
                                    {
                                        b = (sbyte)(c - '7');
                                    }
                                    else
                                    {
                                        if (c == ' ')
                                        {
                                            b = 36;
                                        }
                                        if (c == '$')
                                        {
                                            b = 37;
                                        }
                                        if (c == '%')
                                        {
                                            b = 38;
                                        }
                                        if (c == '*')
                                        {
                                            b = 39;
                                        }
                                        if (c == '+')
                                        {
                                            b = 40;
                                        }
                                        if (c == '-')
                                        {
                                            b = 41;
                                        }
                                        if (c == '.')
                                        {
                                            b = 42;
                                        }
                                        if (c == '/')
                                        {
                                            b = 43;
                                        }
                                        if (c == ':')
                                        {
                                            b = 44;
                                        }
                                    }
                                }
                                if (i % 2 == 0)
                                {
                                    array[num] = (int)b;
                                    array2[num] = 6;
                                }
                                else
                                {
                                    array[num] = array[num] * 45 + (int)b;
                                    array2[num] = 11;
                                    if (i < num2 - 1)
                                    {
                                        num++;
                                    }
                                }
                            }
                            num++;
                            break;
                        }
                    case QRCodeEncoder.ENCODE_MODE.NUMERIC:
                        {
                            array6 = new int[]
							{
								0, 
								0, 
								0, 
								0, 
								0, 
								0, 
								0, 
								0, 
								0, 
								0, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								2, 
								4, 
								4, 
								4, 
								4, 
								4, 
								4, 
								4, 
								4, 
								4, 
								4, 
								4, 
								4, 
								4, 
								4
							};
                            array[num] = 1;
                            num++;
                            array[num] = num2;
                            array2[num] = 10;
                            num3 = num;
                            num++;
                            for (int i = 0; i < num2; i++)
                            {
                                if (i % 3 == 0)
                                {
                                    array[num] = (int)(qrcodeData[i] - 48);
                                    array2[num] = 4;
                                }
                                else
                                {
                                    array[num] = array[num] * 10 + (int)(qrcodeData[i] - 48);
                                    if (i % 3 == 1)
                                    {
                                        array2[num] = 7;
                                    }
                                    else
                                    {
                                        array2[num] = 10;
                                        if (i < num2 - 1)
                                        {
                                            num++;
                                        }
                                    }
                                }
                            }
                            num++;
                            break;
                        }
                    default:
                        {
                            array6 = new int[]
							{
								0, 
								0, 
								0, 
								0, 
								0, 
								0, 
								0, 
								0, 
								0, 
								0, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8, 
								8
							};
                            array[num] = 4;
                            num++;
                            array[num] = num2;
                            array2[num] = 8;
                            num3 = num;
                            num++;
                            for (int i = 0; i < num2; i++)
                            {
                                array[i + num] = (int)(qrcodeData[i] & 255);
                                array2[i + num] = 8;
                            }
                            num += num2;
                            break;
                        }
                }
                int num4 = 0;
                for (int i = 0; i < num; i++)
                {
                    num4 += (int)array2[i];
                }
                int num5;
                switch (this.qrcodeErrorCorrect)
                {
                    case QRCodeEncoder.ERROR_CORRECTION.L:
                        {
                            num5 = 1;
                            goto IL_3D0;
                        }
                    case QRCodeEncoder.ERROR_CORRECTION.Q:
                        {
                            num5 = 3;
                            goto IL_3D0;
                        }
                    case QRCodeEncoder.ERROR_CORRECTION.H:
                        {
                            num5 = 2;
                            goto IL_3D0;
                        }
                }
                num5 = 0;
            IL_3D0:
                int[][] array7 = new int[][]
					{
						new int[]
						{
							0, 
							128, 
							224, 
							352, 
							512, 
							688, 
							864, 
							992, 
							1232, 
							1456, 
							1728, 
							2032, 
							2320, 
							2672, 
							2920, 
							3320, 
							3624, 
							4056, 
							4504, 
							5016, 
							5352, 
							5712, 
							6256, 
							6880, 
							7312, 
							8000, 
							8496, 
							9024, 
							9544, 
							10136, 
							10984, 
							11640, 
							12328, 
							13048, 
							13800, 
							14496, 
							15312, 
							15936, 
							16816, 
							17728, 
							18672
						}, 
						new int[]
						{
							0, 
							152, 
							272, 
							440, 
							640, 
							864, 
							1088, 
							1248, 
							1552, 
							1856, 
							2192, 
							2592, 
							2960, 
							3424, 
							3688, 
							4184, 
							4712, 
							5176, 
							5768, 
							6360, 
							6888, 
							7456, 
							8048, 
							8752, 
							9392, 
							10208, 
							10960, 
							11744, 
							12248, 
							13048, 
							13880, 
							14744, 
							15640, 
							16568, 
							17528, 
							18448, 
							19472, 
							20528, 
							21616, 
							22496, 
							23648
						}, 
						new int[]
						{
							0, 
							72, 
							128, 
							208, 
							288, 
							368, 
							480, 
							528, 
							688, 
							800, 
							976, 
							1120, 
							1264, 
							1440, 
							1576, 
							1784, 
							2024, 
							2264, 
							2504, 
							2728, 
							3080, 
							3248, 
							3536, 
							3712, 
							4112, 
							4304, 
							4768, 
							5024, 
							5288, 
							5608, 
							5960, 
							6344, 
							6760, 
							7208, 
							7688, 
							7888, 
							8432, 
							8768, 
							9136, 
							9776, 
							10208
						}, 
						new int[]
						{
							0, 
							104, 
							176, 
							272, 
							384, 
							496, 
							608, 
							704, 
							880, 
							1056, 
							1232, 
							1440, 
							1648, 
							1952, 
							2088, 
							2360, 
							2600, 
							2936, 
							3176, 
							3560, 
							3880, 
							4096, 
							4544, 
							4912, 
							5312, 
							5744, 
							6032, 
							6464, 
							6968, 
							7288, 
							7880, 
							8264, 
							8920, 
							9368, 
							9848, 
							10288, 
							10832, 
							11408, 
							12016, 
							12656, 
							13328
						}
					};
                int num6 = 0;
                if (this.qrcodeVersion == 0)
                {
                    this.qrcodeVersion = 1;
                    for (int i = 1; i <= 40; i++)
                    {
                        if (array7[num5][i] >= num4 + array6[this.qrcodeVersion])
                        {
                            num6 = array7[num5][i];
                            break;
                        }
                        this.qrcodeVersion++;
                    }
                }
                else
                {
                    num6 = array7[num5][this.qrcodeVersion];
                }
                num4 += array6[this.qrcodeVersion];
                array2[num3] = (sbyte)((int)array2[num3] + array6[this.qrcodeVersion]);
                int[] array8 = new int[]
					{
						0, 
						26, 
						44, 
						70, 
						100, 
						134, 
						172, 
						196, 
						242, 
						292, 
						346, 
						404, 
						466, 
						532, 
						581, 
						655, 
						733, 
						815, 
						901, 
						991, 
						1085, 
						1156, 
						1258, 
						1364, 
						1474, 
						1588, 
						1706, 
						1828, 
						1921, 
						2051, 
						2185, 
						2323, 
						2465, 
						2611, 
						2761, 
						2876, 
						3034, 
						3196, 
						3362, 
						3532, 
						3706
					};
                int num7 = array8[this.qrcodeVersion];
                int num8 = 17 + (this.qrcodeVersion << 2);
                int[] array9 = new int[]
					{
						0, 
						0, 
						7, 
						7, 
						7, 
						7, 
						7, 
						0, 
						0, 
						0, 
						0, 
						0, 
						0, 
						0, 
						3, 
						3, 
						3, 
						3, 
						3, 
						3, 
						3, 
						4, 
						4, 
						4, 
						4, 
						4, 
						4, 
						4, 
						3, 
						3, 
						3, 
						3, 
						3, 
						3, 
						3, 
						0, 
						0, 
						0, 
						0, 
						0, 
						0
					};
                int num9 = array9[this.qrcodeVersion] + (num7 << 3);
                sbyte[] array10 = new sbyte[num9];
                sbyte[] array11 = new sbyte[num9];
                sbyte[] array12 = new sbyte[num9];
                sbyte[] array13 = new sbyte[15];
                sbyte[] array14 = new sbyte[15];
                sbyte[] array15 = new sbyte[1];
                sbyte[] array16 = new sbyte[128];
                try
                {
                    string name = "qrv" + Convert.ToString(this.qrcodeVersion) + "_" + Convert.ToString(num5);
                    MemoryStream memoryStream = new MemoryStream(Resources.ResourceManager.GetObject(name) as byte[]);
                    BufferedStream bufferedStream = new BufferedStream(memoryStream);
                    SystemUtils.ReadInput(bufferedStream, array10, 0, array10.Length);
                    SystemUtils.ReadInput(bufferedStream, array11, 0, array11.Length);
                    SystemUtils.ReadInput(bufferedStream, array12, 0, array12.Length);
                    SystemUtils.ReadInput(bufferedStream, array13, 0, array13.Length);
                    SystemUtils.ReadInput(bufferedStream, array14, 0, array14.Length);
                    SystemUtils.ReadInput(bufferedStream, array15, 0, array15.Length);
                    SystemUtils.ReadInput(bufferedStream, array16, 0, array16.Length);
                    bufferedStream.Close();
                    memoryStream.Close();
                }
                catch (Exception throwable)
                {
                    SystemUtils.WriteStackTrace(throwable, Console.Error);
                }
                sbyte b2 = 1;
                sbyte b3 = 1;
                while ((int)b3 < 128)
                {
                    if (array16[(int)b3] == 0)
                    {
                        b2 = b3;
                        break;
                    }
                    b3 += 1;
                }
                sbyte[] array17 = new sbyte[(int)b2];
                Array.Copy(array16, 0, array17, 0, (int)((byte)b2));
                sbyte[] array18 = new sbyte[]
					{
						0, 
						1, 
						2, 
						3, 
						4, 
						5, 
						7, 
						8, 
						8, 
						8, 
						8, 
						8, 
						8, 
						8, 
						8
					};
                sbyte[] array19 = new sbyte[]
					{
						8, 
						8, 
						8, 
						8, 
						8, 
						8, 
						8, 
						8, 
						7, 
						5, 
						4, 
						3, 
						2, 
						1, 
						0
					};
                int maxDataCodewords = num6 >> 3;
                int num10 = 4 * this.qrcodeVersion + 17;
                int num11 = num10 * num10;
                sbyte[] array20 = new sbyte[num11 + num10];
                try
                {
                    string name = "qrvfr" + Convert.ToString(this.qrcodeVersion);
                    MemoryStream memoryStream = new MemoryStream(Resources.ResourceManager.GetObject(name) as byte[]);
                    BufferedStream bufferedStream = new BufferedStream(memoryStream);
                    SystemUtils.ReadInput(bufferedStream, array20, 0, array20.Length);
                    bufferedStream.Close();
                    memoryStream.Close();
                }
                catch (Exception throwable)
                {
                    SystemUtils.WriteStackTrace(throwable, Console.Error);
                }
                if (num4 <= num6 - 4)
                {
                    array[num] = 0;
                    array2[num] = 4;
                }
                else
                {
                    if (num4 < num6)
                    {
                        array[num] = 0;
                        array2[num] = (sbyte)(num6 - num4);
                    }
                    else
                    {
                        if (num4 > num6)
                        {
                            Console.Out.WriteLine("overflow");
                        }
                    }
                }
                sbyte[] codewords = QRCodeEncoder.divideDataBy8Bits(array, array2, maxDataCodewords);
                sbyte[] array21 = QRCodeEncoder.calculateRSECC(codewords, array15[0], array17, maxDataCodewords, num7);
                sbyte[][] array22 = new sbyte[num10][];
                for (int j = 0; j < num10; j++)
                {
                    array22[j] = new sbyte[num10];
                }
                for (int i = 0; i < num10; i++)
                {
                    for (int k = 0; k < num10; k++)
                    {
                        array22[k][i] = 0;
                    }
                }
                for (int i = 0; i < num7; i++)
                {
                    sbyte b4 = array21[i];
                    for (int k = 7; k >= 0; k--)
                    {
                        int num12 = i * 8 + k;
                        array22[(int)array10[num12] & 255][(int)array11[num12] & 255] = (sbyte)(255 * (int)(b4 & 1) ^ (int)array12[num12]);
                        b4 = (sbyte)SystemUtils.URShift((int)b4 & 255, 1);
                    }
                }
                for (int l = array9[this.qrcodeVersion]; l > 0; l--)
                {
                    int num13 = l + num7 * 8 - 1;
                    array22[(int)array10[num13] & 255][(int)array11[num13] & 255] = (sbyte)(255 ^ (int)array12[num13]);
                }
                sbyte b5 = QRCodeEncoder.selectMask(array22, array9[this.qrcodeVersion] + num7 * 8);
                sbyte b6 = (sbyte)(1 << (int)b5);
                sbyte b7 = (sbyte)(num5 << 3 | b5);
                string[] array23 = new string[]
					{
						"101010000010010", 
						"101000100100101", 
						"101111001111100", 
						"101101101001011", 
						"100010111111001", 
						"100000011001110", 
						"100111110010111", 
						"100101010100000", 
						"111011111000100", 
						"111001011110011", 
						"111110110101010", 
						"111100010011101", 
						"110011000101111", 
						"110001100011000", 
						"110110001000001", 
						"110100101110110", 
						"001011010001001", 
						"001001110111110", 
						"001110011100111", 
						"001100111010000", 
						"000011101100010", 
						"000001001010101", 
						"000110100001100", 
						"000100000111011", 
						"011010101011111", 
						"011000001101000", 
						"011111100110001", 
						"011101000000110", 
						"010010010110100", 
						"010000110000011", 
						"010111011011010", 
						"010101111101101"
					};
                for (int i = 0; i < 15; i++)
                {
                    sbyte b8 = sbyte.Parse(array23[(int)b7].Substring(i, i + 1 - i));
                    array22[(int)array18[i] & 255][(int)array19[i] & 255] = (sbyte)((int)b8 * 255);
                    array22[(int)array13[i] & 255][(int)array14[i] & 255] = (sbyte)((int)b8 * 255);
                }
                bool[][] array24 = new bool[num10][];
                for (int m = 0; m < num10; m++)
                {
                    array24[m] = new bool[num10];
                }
                int num14 = 0;
                for (int i = 0; i < num10; i++)
                {
                    for (int k = 0; k < num10; k++)
                    {
                        if ((array22[k][i] & b6) != 0 || array20[num14] == 49)
                        {
                            array24[k][i] = true;
                        }
                        else
                        {
                            array24[k][i] = false;
                        }
                        num14++;
                    }
                    num14++;
                }
                result = array24;
            }
            return result;
        }
        private static sbyte[] divideDataBy8Bits(int[] data, sbyte[] bits, int maxDataCodewords)
        {
            /* divide Data By 8bit and add padding char */
            int l1 = bits.Length;
            int l2;
            int codewordsCounter = 0;
            int remainingBits = 8;
            int max = 0;
            int buffer;
            int bufferBits;
            bool flag;

            if (l1 != data.Length)
            {
            }
            for (int i = 0; i < l1; i++)
            {
                max += bits[i];
            }
            l2 = (max - 1) / 8 + 1;
            sbyte[] codewords = new sbyte[maxDataCodewords];
            for (int i = 0; i < l2; i++)
            {
                codewords[i] = 0;
            }
            for (int i = 0; i < l1; i++)
            {
                buffer = data[i];
                bufferBits = bits[i];
                flag = true;

                if (bufferBits == 0)
                {
                    break;
                }
                while (flag)
                {
                    if (remainingBits > bufferBits)
                    {
                        codewords[codewordsCounter] = (sbyte)((codewords[codewordsCounter] << bufferBits) | buffer);
                        remainingBits -= bufferBits;
                        flag = false;
                    }
                    else
                    {
                        bufferBits -= remainingBits;
                        codewords[codewordsCounter] = (sbyte)((codewords[codewordsCounter] << remainingBits) | (buffer >> bufferBits));

                        if (bufferBits == 0)
                        {
                            flag = false;
                        }
                        else
                        {
                            buffer = (buffer & ((1 << bufferBits) - 1));
                            flag = true;
                        }
                        codewordsCounter++;
                        remainingBits = 8;
                    }
                }
            }
            if (remainingBits != 8)
            {
                codewords[codewordsCounter] = (sbyte)(codewords[codewordsCounter] << remainingBits);
            }
            else
            {
                codewordsCounter--;
            }
            if (codewordsCounter < maxDataCodewords - 1)
            {
                flag = true;
                while (codewordsCounter < maxDataCodewords - 1)
                {
                    codewordsCounter++;
                    if (flag)
                    {
                        codewords[codewordsCounter] = -20;
                    }
                    else
                    {
                        codewords[codewordsCounter] = 17;
                    }
                    flag = !(flag);
                }
            }
            return codewords;
        }
        private static sbyte[] calculateRSECC(sbyte[] codewords, sbyte rsEccCodewords, sbyte[] rsBlockOrder, int maxDataCodewords, int maxCodewords)
        {
            sbyte[][] array = new sbyte[256][];
            for (int i = 0; i < 256; i++)
            {
                array[i] = new sbyte[(int)rsEccCodewords];
            }
            try
            {
                string name = "rsc" + rsEccCodewords.ToString();
                MemoryStream memoryStream = new MemoryStream(Resources.ResourceManager.GetObject(name) as byte[]);
                BufferedStream bufferedStream = new BufferedStream(memoryStream);
                for (int i = 0; i < 256; i++)
                {
                    SystemUtils.ReadInput(bufferedStream, array[i], 0, array[i].Length);
                }
                bufferedStream.Close();
                memoryStream.Close();
            }
            catch (Exception throwable)
            {
                SystemUtils.WriteStackTrace(throwable, Console.Error);
            }
            int j = 0;
            int k = 0;
            int l = 0;
            sbyte[][] array2 = new sbyte[rsBlockOrder.Length][];
            sbyte[] array3 = new sbyte[maxCodewords];
            Array.Copy(codewords, 0, array3, 0, codewords.Length);
            for (j = 0; j < rsBlockOrder.Length; j++)
            {
                array2[j] = new sbyte[((int)rsBlockOrder[j] & 255) - (int)rsEccCodewords];
            }
            for (j = 0; j < maxDataCodewords; j++)
            {
                array2[l][k] = codewords[j];
                k++;
                if (k >= ((int)rsBlockOrder[l] & 255) - (int)rsEccCodewords)
                {
                    k = 0;
                    l++;
                }
            }
            for (l = 0; l < rsBlockOrder.Length; l++)
            {
                sbyte[] array4 = new sbyte[array2[l].Length];
                array2[l].CopyTo(array4, 0);
                int num = (int)rsBlockOrder[l] & 255;
                int num2 = num - (int)rsEccCodewords;
                for (k = num2; k > 0; k--)
                {
                    sbyte b = array4[0];
                    if (b != 0)
                    {
                        sbyte[] array5 = new sbyte[array4.Length - 1];
                        Array.Copy(array4, 1, array5, 0, array4.Length - 1);
                        sbyte[] xb = array[(int)b & 255];
                        array4 = QRCodeEncoder.calculateByteArrayBits(array5, xb, "xor");
                    }
                    else
                    {
                        if ((int)rsEccCodewords < array4.Length)
                        {
                            sbyte[] array6 = new sbyte[array4.Length - 1];
                            Array.Copy(array4, 1, array6, 0, array4.Length - 1);
                            array4 = new sbyte[array6.Length];
                            array6.CopyTo(array4, 0);
                        }
                        else
                        {
                            sbyte[] array6 = new sbyte[(int)rsEccCodewords];
                            Array.Copy(array4, 1, array6, 0, array4.Length - 1);
                            array6[(int)(rsEccCodewords - 1)] = 0;
                            array4 = new sbyte[array6.Length];
                            array6.CopyTo(array4, 0);
                        }
                    }
                }
                Array.Copy(array4, 0, array3, codewords.Length + l * (int)rsEccCodewords, (int)((byte)rsEccCodewords));
            }
            return array3;
        }
        private static sbyte[] calculateByteArrayBits(sbyte[] xa, sbyte[] xb, string ind)
        {
            int ll;
            int ls;
            sbyte[] res;
            sbyte[] xl;
            sbyte[] xs;

            if (xa.Length > xb.Length)
            {
                xl = new sbyte[xa.Length];
                xa.CopyTo(xl, 0);
                xs = new sbyte[xb.Length];
                xb.CopyTo(xs, 0);
            }
            else
            {
                xl = new sbyte[xb.Length];
                xb.CopyTo(xl, 0);
                xs = new sbyte[xa.Length];
                xa.CopyTo(xs, 0);
            }
            ll = xl.Length;
            ls = xs.Length;
            res = new sbyte[ll];

            for (int i = 0; i < ll; i++)
            {
                if (i < ls)
                {
                    if ((System.Object)ind == (System.Object)"xor")
                    {
                        res[i] = (sbyte)(xl[i] ^ xs[i]);
                    }
                    else
                    {
                        res[i] = (sbyte)(xl[i] | xs[i]);
                    }
                }
                else
                {
                    res[i] = xl[i];
                }
            }
            return res;
        }
        private static sbyte selectMask(sbyte[][] matrixContent, int maxCodewordsBitWithRemain)
        {
            int num = matrixContent.Length;
            int[] array = new int[8];
            int[] array2 = array;
            array = new int[8];
            int[] array3 = array;
            array = new int[8];
            int[] array4 = array;
            array = new int[8];
            int[] array5 = array;
            int num2 = 0;
            int num3 = 0;
            array = new int[8];
            int[] array6 = array;
            for (int i = 0; i < num; i++)
            {
                array = new int[8];
                int[] array7 = array;
                array = new int[8];
                int[] array8 = array;
                bool[] array9 = new bool[8];
                bool[] array10 = array9;
                array9 = new bool[8];
                bool[] array11 = array9;
                for (int j = 0; j < num; j++)
                {
                    if (j > 0 && i > 0)
                    {
                        num2 = ((int)(matrixContent[j][i] & matrixContent[j - 1][i] & matrixContent[j][i - 1] & matrixContent[j - 1][i - 1]) & 255);
                        num3 = (((int)matrixContent[j][i] & 255) | ((int)matrixContent[j - 1][i] & 255) | ((int)matrixContent[j][i - 1] & 255) | ((int)matrixContent[j - 1][i - 1] & 255));
                    }
                    for (int k = 0; k < 8; k++)
                    {
                        array7[k] = ((array7[k] & 63) << 1 | (SystemUtils.URShift((int)matrixContent[j][i] & 255, k) & 1));
                        array8[k] = ((array8[k] & 63) << 1 | (SystemUtils.URShift((int)matrixContent[i][j] & 255, k) & 1));
                        if (((int)matrixContent[j][i] & 1 << k) != 0)
                        {
                            array6[k]++;
                        }
                        if (array7[k] == 93)
                        {
                            array4[k] += 40;
                        }
                        if (array8[k] == 93)
                        {
                            array4[k] += 40;
                        }
                        if (j > 0 && i > 0)
                        {
                            if ((num2 & 1) != 0 || (num3 & 1) == 0)
                            {
                                array3[k] += 3;
                            }
                            num2 >>= 1;
                            num3 >>= 1;
                        }
                        if ((array7[k] & 31) == 0 || (array7[k] & 31) == 31)
                        {
                            if (j > 3)
                            {
                                if (array10[k])
                                {
                                    array2[k]++;
                                }
                                else
                                {
                                    array2[k] += 3;
                                    array10[k] = true;
                                }
                            }
                        }
                        else
                        {
                            array10[k] = false;
                        }
                        if ((array8[k] & 31) == 0 || (array8[k] & 31) == 31)
                        {
                            if (j > 3)
                            {
                                if (array11[k])
                                {
                                    array2[k]++;
                                }
                                else
                                {
                                    array2[k] += 3;
                                    array11[k] = true;
                                }
                            }
                        }
                        else
                        {
                            array11[k] = false;
                        }
                    }
                }
            }
            int num4 = 0;
            sbyte result = 0;
            int[] array12 = new int[]
				{
					90, 
					80, 
					70, 
					60, 
					50, 
					40, 
					30, 
					20, 
					10, 
					0, 
					0, 
					10, 
					20, 
					30, 
					40, 
					50, 
					60, 
					70, 
					80, 
					90, 
					90
				};
            for (int k = 0; k < 8; k++)
            {
                array5[k] = array12[20 * array6[k] / maxCodewordsBitWithRemain];
                int num5 = array2[k] + array3[k] + array4[k] + array5[k];
                if (num5 < num4 || k == 0)
                {
                    result = (sbyte)k;
                    num4 = num5;
                }
            }
            return result;
        }
        public virtual Bitmap Encode(string content, Encoding encoding)
        {
            bool[][] array = this.calQrcode(encoding.GetBytes(content));
            SolidBrush solidBrush = new SolidBrush(this.qrCodeBackgroundColor);
            Bitmap bitmap = new Bitmap(array.Length * this.qrCodeScale + 1, array.Length * this.qrCodeScale + 1);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.FillRectangle(solidBrush, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            solidBrush.Color = this.qrCodeForegroundColor;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j][i])
                    {
                        graphics.FillRectangle(solidBrush, j * this.qrCodeScale, i * this.qrCodeScale, this.qrCodeScale, this.qrCodeScale);
                    }
                }
            }
            return bitmap;
        }
        public virtual Bitmap Encode(string content)
        {
            Bitmap result;
            if (QRCodeUtility.IsUniCode(content))
            {
                result = this.Encode(content, Encoding.Unicode);
            }
            else
            {
                result = this.Encode(content, Encoding.ASCII);
            }
            return result;
        }
    }
}
