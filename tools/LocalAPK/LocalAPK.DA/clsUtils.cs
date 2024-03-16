using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;
using LocalAPK.Data;

namespace LocalAPK.DA
{
    public static class clsUtils
    {
        private const string DbFileName = "localapk.db";

        public static string GetAppDataFolderPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\LocalAPK";
        }

        public static string GetSystemRootPath()
        {
            return Path.GetPathRoot(Environment.SystemDirectory);
        }

        public static string GetSystemRootTempPath()
        {
            return Path.Combine(GetSystemRootPath(), "Temp");
        }

        public static string GetSqliteDbFile()
        {
            if (clsSettings.Portable)
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DbFileName);
            }
            else
            {
                return Path.Combine(GetAppDataFolderPath(), DbFileName);
            }
        }

        public static void CheckDirectories()
        {
            //Create system root temp path if needed
            if (!Directory.Exists(GetSystemRootTempPath()))
            {
                Directory.CreateDirectory(GetSystemRootTempPath());
            }

            //Create LocalAPK folder under AppData if needed
            if (!Directory.Exists(GetAppDataFolderPath()))
            {
                Directory.CreateDirectory(GetAppDataFolderPath());
            }

            //Create empty SqliteDb file if none present
            if (!File.Exists(GetSqliteDbFile()))
            {
                CreateEmptySqliteDbFile();
            }

            //Migrate settings when needed
            clsMigrate.Migrate();

            //Upgrade when needed
            clsUpgrade.Upgrade();
        }

        private static void CreateEmptySqliteDbFile()
        {
            using (var stream = Assembly.UnsafeLoadFrom("LocalAPK.SharedResources.dll").GetManifestResourceStream("LocalAPK.SharedResources.Resources.localapk.db"))
            {
                using (var fileStream = new FileStream(GetSqliteDbFile(), FileMode.Create))
                {
                    for (int i = 0; i < stream.Length; i++)
                    {
                        fileStream.WriteByte((byte)stream.ReadByte());
                    }
                    fileStream.Close();
                }
            }
        }

        public static void RegisterShellExt()
        {
	        try
	        {
		        var dllPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\LocalAPK.ShellExt.dll";
		        var a = Assembly.LoadFile(dllPath);

		        var regService = new RegistrationServices();
		        regService.RegisterAssembly(a, AssemblyRegistrationFlags.SetCodeBase);
	        }
	        catch
	        {

	        }
        }

        public static void UnregisterShellExt()
        {
	        try
	        {
		        var dllPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\LocalAPK.ShellExt.dll";
		        var a = Assembly.LoadFile(dllPath);

		        var regService = new RegistrationServices();
		        regService.UnregisterAssembly(a);

                //Do cleanup after uninstall
                CleanupShellExt();
            }
	        catch
	        {

	        }
        }

		private static void CleanupShellExt()
		{
			try
			{
                //Try to gracefully exit explorer
                GracefullyExitExplorer();

                //Try to close all remaining explorer processes
			    ExitExplorer();

                //Delete explorer icon cache
                var p = new Process();
				var info = new ProcessStartInfo();
				info.CreateNoWindow = true;
				info.FileName = "cmd.exe";
				info.RedirectStandardInput = true;
				info.UseShellExecute = false;
				p.StartInfo = info;
				p.Start();
				using (var sw = p.StandardInput)
				{
					if (sw.BaseStream.CanWrite)
					{
						sw.WriteLine(@"cd /d %userprofile%\AppData\Local");
						sw.WriteLine("del IconCache.db");
					}
				}

                //Start explorer
			    StartExplorer();
			}
			catch
			{

			}
		}

        public static bool IsShellExtInstalled()
        {
            try
            {
                var rk = Registry.ClassesRoot.OpenSubKey("CLSID\\{2D0690B5-CFA3-47E4-B1E3-45BE4279B6D7}");
                if (rk != null)
                {
                    return true;
                }
                else
                {
                    return false;
                } 
            }
            catch
            {
                return true;
            }
        }

        public static string LegalizeFilename(string filename)
        {
            var newFilename = filename;
            var illegalChars = Path.GetInvalidFileNameChars();

            foreach (var c in illegalChars)
            {
                newFilename = newFilename.Replace(c.ToString(), "");
            }

            return newFilename;
        }

        public static List<string> CheckRemovedScanFolders()
        {
            var removedDirs = new List<string>();
            foreach (var dir in SqliteConnector.GetScanFolders())
            {
                if (!Directory.Exists(dir))
                {
                    removedDirs.Add(dir);
                }
            }
            return removedDirs;
        }

        public static void RunCommand(string command)
        {
            string fileName;
            var arguments = string.Empty;

            if(command.StartsWith("\""))
            {
                var fileNameEnd = command.IndexOf("\"", 1);// - 1;
                if (fileNameEnd == -1)
                {
                    fileName = command.Trim();
                }
                else
                {
                    fileName = command.Substring(1, fileNameEnd - 1).Trim();
                    arguments = command.Substring(fileNameEnd + 2, command.Length - fileNameEnd - 2).Trim();
                }
            }
            else
            {
                var fileNameEnd = command.IndexOf(" ");
                if (fileNameEnd == -1)
                {
                    fileName = command.Trim();
                }
                else
                {
                    fileName = command.Substring(0, fileNameEnd).Trim();
                    arguments = command.Substring(fileNameEnd, command.Length - fileNameEnd).Trim();
                }
            }

            var pci = new ProcessStartInfo(fileName, arguments) {UseShellExecute = true};
            Process.Start(pci);
        }

        public static string SanitizePrice(string price, Encoding enc)
        {
            var isoEncoding = Encoding.GetEncoding("iso-8859-1");
            var source = isoEncoding.GetBytes(price);
            return Encoding.UTF8.GetString(Encoding.Convert(isoEncoding, Encoding.UTF8, source));
        }

		public enum ArchitectureMode { x86, x64 }

		public static ArchitectureMode GetAssemblyArchitecture()
		{
			if (Environment.Is64BitProcess)
			{
				return ArchitectureMode.x64;
			}
			else
			{
				return ArchitectureMode.x86;
			}
		}

		public static ArchitectureMode GetOsArchitecture()
		{
			if (Environment.Is64BitOperatingSystem)
			{
				return ArchitectureMode.x64;
			}
			else
			{
				return ArchitectureMode.x86;
			}
		}

		public static ArchitectureMode GetProcessorArchitecture()
		{
			if (Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE").Contains("x86"))
			{
				return ArchitectureMode.x86;
			}
			else
			{
				return ArchitectureMode.x64;
			}
		}

		public static void SendFileToRecycleBin(string fileName){
			if (GetProcessorArchitecture() == ArchitectureMode.x64)
			{
				FileOperationAPIWrapper64.MoveToRecycleBin(fileName);
			}
			else
			{
				FileOperationAPIWrapper32.MoveToRecycleBin(fileName);
			}
		}

		public static void SendFilesToRecycleBin(string[] fileNames)
		{
			var deletionString = new StringBuilder();
			foreach (var fileName in fileNames)
			{
				deletionString.AppendFormat("{0}\0", fileName);
			}
			if (GetProcessorArchitecture() == ArchitectureMode.x64)
			{
				FileOperationAPIWrapper64.MoveToRecycleBin(deletionString.ToString());
			}
			else
			{
				FileOperationAPIWrapper32.MoveToRecycleBin(deletionString.ToString());
			}
		}

		public static string TranslateSdkVersion(string sdkVersion)
		{
			switch (sdkVersion){
                case "29":
                    return "29 (Android 10.0)";
                case "28":
                    return "28 (Android 9.0 Pie)";
                case "27":
			        return "27 (Android 8.1 Oreo)";
                case "26":
			        return "26 (Android 8.0 Oreo)";
                case "25":
                    return "25 (Android 7.1 - 7.1.2 Nougat)";
                case "24":
                    return "24 (Android 7.0 Nougat)";
                case "23":
                    return "23 (Android 6.0 - 6.0.1 Marshmallow)";
                case "22":
                    return "22 (Android 5.1 - 5.1.1 Lollipop)";
                case "21":
                    return "21 (Android 5.0 - 5.0.2 Lollipop)";
                case "20":
                    return "20 (Android 4.4W(.2) KitKat, with wearable extensions)";
				case "19":
					return "19 (Android 4.4 - 4.4.4 KitKat)";
				case "18":
					return "18 (Android 4.3 - 4.3.1 Jelly Bean)";
				case "17":
					return "17 (Android 4.2 - 4.2.2 Jelly Bean)";
				case "16":
					return "16 (Android 4.1 - 4.1.2 Jelly Bean)";
				case "15":
					return "15 (Android 4.0.3 - 4.0.4 Ice Cream Sandwich)";
				case "14":
					return "14 (Android 4.0 - 4.0.2 Ice Cream Sandwich)";
				case "13":
					return "13 (Android 3.2 - 3.2.6 Honeycomb)";
				case "12":
					return "12 (Android 3.1 Honeycomb)";
				case "11":
					return "11 (Android 3.0 Honeycomb)";
				case "10":
					return "10 (Android 2.3.3 - 2.3.7 Gingerbread)";
				case "9":
					return "9 (Android 2.3 - 2.3.2 Gingerbread)";
				case "8":
					return "8 (Android 2.2 - 2.2.3 Froyo)";
				case "7":
					return "7 (Android 2.1 Eclair)";
				case "6":
					return "6 (Android 2.0.1 Eclair)";
				case "5":
					return "5 (Android 2.0 Eclair)";
				case "4":
					return "4 (Android 1.6 Donut)";
				case "3":
					return "3 (Android 1.5 Cupcake)";
				case "2":
					return "2 (Android 1.1)";
				case "1":
					return "1 (Android 1.0)";
				default:
					return sdkVersion;
			}
		}

		public static List<string> GetQuotedOccurencesInString(string text)
		{
			var returnVal = new List<string>();
			var positions = new List<int>();
			var pos = 0;
			while ((pos < text.Length) && (pos = text.IndexOf("'", pos)) != -1)
			{
				positions.Add(pos);
				pos ++;
			}

			for (var i = 0; i < positions.Count; i+=2)
			{
				returnVal.Add(text.Substring(positions[i] + 1, positions[i + 1] - positions[i] - 1));
			}

			return returnVal;
		}

		public static bool ContainsUnicodeCharacter(string input)
		{
			const int maxAnsiCode = 255;
			return input.Any(c => c > maxAnsiCode);
		}

        public static byte[] ResizeIcon(byte[] iconBytes)
        {
            using (var ms = new MemoryStream(iconBytes))
            {
                //Expand canvas to square
                var img = Image.FromStream(ms);
                if (img.Width != img.Height)
                {
                    var highestDimension = Math.Max(img.Width, img.Height);
                    var expandedImg = new Bitmap(highestDimension, highestDimension);
                    using (var gfx = Graphics.FromImage(expandedImg))
                    {
                        var xPos = img.Width < img.Height ? (highestDimension - img.Width) / 2 : 0;
                        var yPos = img.Height < img.Width ? (highestDimension - img.Height) / 2 : 0;
                        gfx.DrawImage(img, xPos, yPos, img.Width, img.Height);
                        img = expandedImg;
                    }
                }

                //If image dimensions are of the allowed size, return as is
                if (img.Width == 256 || img.Width == 180 || img.Width == 128 || img.Width == 96 || img.Width == 72 ||
                    img.Width == 64 || img.Width == 48 || img.Width == 32 || img.Width == 24 || img.Width == 16)
                {
                    using (var msResult = new MemoryStream())
                    {
                        img.Save(msResult, ImageFormat.Png);
                        return msResult.ToArray();
                    }
                }

                //If image is not of wanted size, resize to one of the allowed sizes
                int finalDimension;
                if (img.Width > 256)
                {
                    finalDimension = 256;
                }
                else if (img.Width > 180)
                {
                    finalDimension = 180;
                }
                else if (img.Width > 128)
                {
                    finalDimension = 128;
                }
                else if (img.Width > 96)
                {
                    finalDimension = 96;
                }
                else if (img.Width > 72)
                {
                    finalDimension = 72;
                }
                else if (img.Width > 64)
                {
                    finalDimension = 64;
                }
                else if (img.Width > 48)
                {
                    finalDimension = 48;
                }
                else if (img.Width > 32)
                {
                    finalDimension = 32;
                }
                else if (img.Width > 24)
                {
                    finalDimension = 24;
                }
                else
                {
                    finalDimension = 16;
                }
                var resizedImg = new Bitmap(finalDimension, finalDimension);
                using (var gfx = Graphics.FromImage(resizedImg))
                {
                    using (var wrapMode = new ImageAttributes())
                    {
                        var destRect = new Rectangle(0, 0, finalDimension, finalDimension);
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        gfx.DrawImage(img, destRect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, wrapMode);
                        img = resizedImg;
                    }
                }

                //Return resized image
                using (var msResult = new MemoryStream())
                {
                    img.Save(msResult, ImageFormat.Png);
                    return msResult.ToArray();
                }
            }
        }

        public static List<string> GetParentDirectories(string fileName)
        {
            var allDirectories = new List<string>();

            var di = new DirectoryInfo(fileName);
            do
            {
                di = di.Parent;
                if (di != null)
                {
                    allDirectories.Add(di.FullName);
                }
            } while (di != null && di.FullName != di.Root.FullName);

            allDirectories.Reverse();

            return allDirectories;
        }

        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteFile(string name);

        public static bool UnblockFile(string fileName)
        {
            return DeleteFile(fileName + ":Zone.Identifier");
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        public static void GracefullyExitExplorer()
        {
            var hWndTray = FindWindow("Shell_TrayWnd", null);
            PostMessage(hWndTray, 0x5B4, 0, 0);

            //Wait until explorer is closed
            do
            {
                hWndTray = FindWindow("Shell_TrayWnd", null);

                if (hWndTray.ToInt32() == 0)
                {
                    break;
                }

                Thread.Sleep(200);
            } while (true);
        }

        public static void ExitExplorer()
        {
            var explorerProcesses = Process.GetProcessesByName("explorer");
            foreach (var explorerProcess in explorerProcesses)
            {
                try
                {
                    explorerProcess.CloseMainWindow();
                }
                catch
                {
                    
                }
            }

            explorerProcesses = Process.GetProcessesByName("explorer");

            foreach (var explorerProcess in explorerProcesses)
            {
                try
                {
                    explorerProcess.Kill();
                }
                catch
                {

                }
            }
        }

        public static void StartExplorer()
        {
            Process.Start("explorer");
        }
	}
}
