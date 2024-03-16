using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using Ionic.Zip;
using LocalAPK.Data;

namespace LocalAPK.DA
{
    public static class ApkParser
    {
        public static ApkFile ParseApk(ApkFile apkFile)
        {
            var apk = apkFile.LongFileName;

            var aaptPath = string.Format("\"{0}\"", Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "aapt"));
            var psi = new ProcessStartInfo(aaptPath);
            var tempApk = string.Empty;
            var aaptArguments = string.Empty;
            if (clsUtils.ContainsUnicodeCharacter(apk))
            {
                tempApk = Path.Combine(clsUtils.GetSystemRootTempPath(), string.Format("{0}.apk", Guid.NewGuid()));
                File.Copy(apk, tempApk);

                aaptArguments = string.Concat(" d badging \"", tempApk, "\"");
            }
            else
            {
                aaptArguments = string.Concat(" d badging \"", apk, "\"");
            }

            psi.Arguments = aaptArguments;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            var commandLine = new Process { StartInfo = psi };
            commandLine.Start();
            var standardOutput = new StreamReader(commandLine.StandardOutput.BaseStream, Encoding.UTF8);
            var outputLines = new List<string>();
            string currentLine;
            while ((currentLine = standardOutput.ReadLine()) != null)
            {
                outputLines.Add(currentLine);
            }
            commandLine.WaitForExit();
            standardOutput.Close();

            if (!string.IsNullOrWhiteSpace(tempApk))
            {
                File.Delete(tempApk);
            }

            foreach (var outputLine in outputLines)
            {
                var currentKey = outputLine.Split(new[] { ":" }, StringSplitOptions.None)[0].Trim();
                switch (currentKey)
                {
                    case "application":
                        //Get internal name
                        apkFile.InternalName = outputLine.Substring("label='", "'");
                        break;
                    case "launchable-activity":
                        //Get internal name (if previous failed)
                        if (string.IsNullOrWhiteSpace(apkFile.InternalName))
                        {
                            apkFile.InternalName = outputLine.Substring("label='", "'");
                        }
                        break;
                    case "package":
                        //Get package name
                        apkFile.PackageName = outputLine.Substring("name='", "'");
                        //Get local version
                        apkFile.LocalVersion = outputLine.Substring("versionName='", "'");
                        //Get local version code
                        apkFile.VersionCode = outputLine.Substring("versionCode='", "'");
                        break;
                    case "uses-permission":
                        //Get permissions
                        var permission = outputLine.Substring("'", "'");
                        if (!apkFile.Permissions.Contains(permission))
                        {
                            apkFile.Permissions.Add(permission);
                        }
                        break;
                    case "uses-feature":
                    case "uses-feature-not-required":
                    case "uses-implied-feature":
                        //Get features
                        var feature = outputLine.Substring("'", "'");
                        if (!apkFile.Features.Contains(feature))
                        {
                            apkFile.Features.Add(feature);
                        }
                        break;
                    case "sdkVersion":
                        //Get min sdk version
                        apkFile.MinimumSdkVersion = outputLine.Substring("'", "'");
                        break;
                    case "targetSdkVersion":
                        //Get target sdk version
                        apkFile.TargetSdkVersion = outputLine.Substring("'", "'");
                        break;
                    case "supports-screens":
                        apkFile.ScreenSizes = clsUtils.GetQuotedOccurencesInString(outputLine);
                        break;
                    case "densities":
                        apkFile.ScreenDensities = clsUtils.GetQuotedOccurencesInString(outputLine);
                        break;
                    default:
                        if (outputLine.StartsWith("application-icon-"))
                        {
                            apkFile.IconPath = outputLine.Substring("'", "'");
                            if (!apkFile.IconPath.ToLower().EndsWith(".png"))
                            {
                                apkFile.IconPath = null;
                            }
                        }
                        break;
                }
            }

            apkFile.Permissions.Sort();
            apkFile.Features.Sort();

            return apkFile;
        }

        public static byte[] ExtractIconAsByteArray(ApkFile apkFile)
        {
            if (apkFile != null && !string.IsNullOrWhiteSpace(apkFile.IconPath))
            {
                using (var memStream = ExtractIconAsMemoryStream(apkFile))
                {
                    return memStream.ToArray();
                }
            }
            return null;
        }

        public static MemoryStream ExtractIconAsMemoryStream(ApkFile apkFile)
        {
            if (apkFile != null && !string.IsNullOrWhiteSpace(apkFile.IconPath))
            {
                //Unzip icon
                var memoryStream = new MemoryStream();
                using (var zip = ZipFile.Read(apkFile.LongFileName))
                {
                    var zf = zip[apkFile.IconPath];
                    zf.Extract(memoryStream);
                }

                return memoryStream;
            }
            return null;
        }
    }
}
