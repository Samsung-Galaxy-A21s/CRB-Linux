using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using LocalAPK.Data;

namespace LocalAPK.DA
{
    public static class clsMigrate
    {
        public static void Migrate()
        {
            //Folders
            var foldersFile = Path.Combine(clsUtils.GetAppDataFolderPath(), "folders.xml");
            if (File.Exists(foldersFile))
            {
                MigrateFolders(foldersFile);
            }

            //Commands
            var commandsFile = Path.Combine(clsUtils.GetAppDataFolderPath(), "commands.xml");
            if (File.Exists(commandsFile))
            {
                MigrateCommands(commandsFile);
            }

            //Settings
            var settingsFile = Path.Combine(clsUtils.GetAppDataFolderPath(), "settings.xml");
            if (File.Exists(settingsFile))
            {
                MigrateSettings(settingsFile);
            }

            //Mass rename
            var massRenameFile = Path.Combine(clsUtils.GetAppDataFolderPath(), "massrename.xml");
            if (File.Exists(massRenameFile))
            {
                MigrateMassRename(massRenameFile);
            }

            //Window Info
            var windowInfoFile = Path.Combine(clsUtils.GetAppDataFolderPath(), "windowinfo.xml");
            if (File.Exists(windowInfoFile))
            {
                MigrateWindowInfo(windowInfoFile);
            }

            //Licence
            var licenceFile = Path.Combine(clsUtils.GetAppDataFolderPath(), "license.xml");
            if (File.Exists(licenceFile))
            {
                MigrateLicence(licenceFile);
            }
        }

        private static void MigrateFolders(string path)
        {
            var lstFolders = new List<string>();

            var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            var oXmlDoc = new XmlDocument();
            oXmlDoc.Load(fs);

            var xmlNodes = oXmlDoc.GetElementsByTagName("item");

            foreach (XmlNode oNode in xmlNodes)
            {
                lstFolders.Add(oNode.InnerText);
            }

            fs.Close();
            fs.Dispose();

            SqliteConnector.SetScanFolders(lstFolders);

            File.Delete(path);
        }

        private static void MigrateCommands(string path)
        {
            var lstCommands = new List<ApkCommand>();

            var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            var oXmlDoc = new XmlDocument();
            oXmlDoc.Load(fs);

            var xmlNodes = oXmlDoc.GetElementsByTagName("item");

            foreach (XmlNode oNode in xmlNodes)
            {
                var co = new ApkCommand();

                co.Title = oNode.ChildNodes[0].InnerText;
                co.Command = oNode.ChildNodes[1].InnerText;

                lstCommands.Add(co);
            }

            fs.Close();
            fs.Dispose();

            SqliteConnector.SetCommands(lstCommands);

            File.Delete(path);
        }

        private static void MigrateSettings(string path)
        {
            var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            var oXmlDoc = new XmlDocument();
            oXmlDoc.Load(fs);

            //Fetch google play
            var downloadLatestVersionInfoNode = oXmlDoc.GetElementsByTagName("downloadLatestVersionInfo")[0];
            if (downloadLatestVersionInfoNode.InnerText == "true")
            {
                SqliteConnector.SetSettingValue(SettingEnum.AutoFetchGooglePlay, "true");
            }
            else
            {
                SqliteConnector.SetSettingValue(SettingEnum.AutoFetchGooglePlay, "false");
            }

            //New group for every subdir
            var newGroupSub = oXmlDoc.GetElementsByTagName("newGroupSub")[0];
            if (newGroupSub.InnerText == "true")
            {
                SqliteConnector.SetSettingValue(SettingEnum.SubdirGroup, "true");
            }
            else
            {
                SqliteConnector.SetSettingValue(SettingEnum.SubdirGroup, "false");
            }

            //Group dirs
            var groupResults = oXmlDoc.GetElementsByTagName("groupResults")[0];
            if (groupResults.InnerText == "true")
            {
                SqliteConnector.SetSettingValue(SettingEnum.GroupResults, "true");
            }
            else
            {
                SqliteConnector.SetSettingValue(SettingEnum.GroupResults, "false");
            }

            //Startup refresh
            var startupRefresh = oXmlDoc.GetElementsByTagName("startupRefresh")[0];
            if (startupRefresh.InnerText == "true")
            {
                SqliteConnector.SetSettingValue(SettingEnum.StartupRefresh, "true");
            }
            else
            {
                SqliteConnector.SetSettingValue(SettingEnum.StartupRefresh, "false");
            }

            fs.Close();
            fs.Dispose();

            File.Delete(path);
        }

        private static void MigrateMassRename(string path)
        {
            var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            var oXmlDoc = new XmlDocument();
            oXmlDoc.Load(fs);

            var massRename = oXmlDoc.GetElementsByTagName("currentValue")[0];
            SqliteConnector.SetSettingValue(SettingEnum.MassRenameString, massRename.InnerText);

            fs.Close();
            fs.Dispose();

            File.Delete(path);
        }

        private static void MigrateWindowInfo(string path)
        {
            var deserializer = new XmlSerializer(typeof(WindowInfo));
            TextReader reader = new StreamReader(path);
            var obj = deserializer.Deserialize(reader);
            reader.Close();

            var windowInfo = (WindowInfo) obj;

            clsSettings.SaveMainWindowInfo(windowInfo);

            File.Delete(path);
        }

        private static void MigrateLicence(string path)
        {
            var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            var oXmlDoc = new XmlDocument();
            oXmlDoc.Load(fs);

            var xmlNodes = oXmlDoc.GetElementsByTagName("license");

            var xmlNode = xmlNodes.Item(0);
            if (xmlNode != null)
            {
                foreach (XmlElement xe in xmlNode)
                {
                    if (xe.Name == "email" && !string.IsNullOrWhiteSpace(xe.InnerText))
                    {
                        SqliteConnector.SetSettingValue(SettingEnum.LicenceEmail, xe.InnerText);
                    }
                    if (xe.Name == "code" && !string.IsNullOrWhiteSpace(xe.InnerText))
                    {
                        SqliteConnector.SetSettingValue(SettingEnum.LicenceCode, xe.InnerText);
                    }
                }
            }

            fs.Close();
            fs.Dispose();

            File.Delete(path);
        }
    }
}