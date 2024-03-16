using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalAPK.Data;

namespace LocalAPK.DA
{
    public class SqliteConnector
    {
        private static string DataSource
        {
            get { return string.Format("Data Source={0};Version=3;", clsUtils.GetSqliteDbFile()); }
        }

        public static ApkFile ReadApkFile(ApkFile apkFile)
        {
            var md5Hash = HashHelper.GetMd5HashForFile(apkFile.LongFileName);
            apkFile.Md5Hash = md5Hash;

            bool alreadyCached;

            using (var dbConnection = new SQLiteConnection(DataSource))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "SELECT * FROM apk WHERE hash = ?";
                        command.Parameters.Add(new SQLiteParameter(DbType.String, "hash") { Value = md5Hash });

                        using (var reader = command.ExecuteReader())
                        {
                            alreadyCached = reader.HasRows;

                            if (alreadyCached)
                            {
                                //Read from apk table
                                while (reader.Read())
                                {
                                    //Static information
                                    apkFile.IdApkFile = Convert.ToInt32(reader["id_apk"]);
                                    if (reader["package_name"] != null && !Convert.IsDBNull(reader["package_name"]))
                                    {
                                        apkFile.PackageName = Convert.ToString(reader["package_name"]);
                                    }
                                    if (reader["internal_name"] != null && !Convert.IsDBNull(reader["internal_name"]))
                                    {
                                        apkFile.InternalName = Convert.ToString(reader["internal_name"]);
                                    }
                                    if (reader["local_version"] != null && !Convert.IsDBNull(reader["local_version"]))
                                    {
                                        apkFile.LocalVersion = Convert.ToString(reader["local_version"]);
                                    }
                                    if (reader["version_code"] != null && !Convert.IsDBNull(reader["version_code"]))
                                    {
                                        apkFile.VersionCode = Convert.ToString(reader["version_code"]);
                                    }
                                    if (reader["minimum_sdk_version"] != null && !Convert.IsDBNull(reader["minimum_sdk_version"]))
                                    {
                                        apkFile.MinimumSdkVersion = Convert.ToString(reader["minimum_sdk_version"]);
                                    }
                                    if (reader["target_sdk_version"] != null && !Convert.IsDBNull(reader["target_sdk_version"]))
                                    {
                                        apkFile.TargetSdkVersion = Convert.ToString(reader["target_sdk_version"]);
                                    }
                                    if (reader["icon_path"] != null && !Convert.IsDBNull(reader["icon_path"]))
                                    {
                                        apkFile.IconPath = Convert.ToString(reader["icon_path"]);
                                    }

                                    //Dynamic information
                                    if (reader["google_play_name"] != null && !Convert.IsDBNull(reader["google_play_name"]))
                                    {
                                        apkFile.GooglePlayName = Convert.ToString(reader["google_play_name"]);
                                    }
                                    if (reader["category"] != null && !Convert.IsDBNull(reader["category"]))
                                    {
                                        apkFile.Category = Convert.ToString(reader["category"]);
                                    }
                                    if (reader["latest_version"] != null && !Convert.IsDBNull(reader["latest_version"]))
                                    {
                                        apkFile.LatestVersion = Convert.ToString(reader["latest_version"]);
                                    }
                                    if (reader["price"] != null && !Convert.IsDBNull(reader["price"]))
                                    {
                                        apkFile.Price = Convert.ToString(reader["price"]);
                                    }
                                    if (reader["last_google_play_fetch"] != null && !Convert.IsDBNull(reader["last_google_play_fetch"]))
                                    {
                                        apkFile.LastGooglePlayFetch = Convert.ToDateTime(reader["last_google_play_fetch"]);
                                    }
                                }
                            }
                        }
                    }
                    if (alreadyCached)
                    {
                        using (var command = new SQLiteCommand(dbConnection))
                        {
                            //Read from extra table
                            command.CommandText = "SELECT id_extra, id_apk, id_extra_type, extra FROM extra WHERE id_apk = ?";
                            command.Parameters.Clear();
                            command.Parameters.Add(new SQLiteParameter(DbType.Int64, apkFile.IdApkFile));
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        var idExtraType = Convert.ToInt32(reader["id_extra_type"]);
                                        switch (idExtraType)
                                        {
                                            case 1: //Screen size
                                                apkFile.ScreenSizes.Add(Convert.ToString(reader["extra"]));
                                                break;
                                            case 2: //Screen density
                                                apkFile.ScreenDensities.Add(Convert.ToString(reader["extra"]));
                                                break;
                                            case 3: //Permission
                                                apkFile.Permissions.Add(Convert.ToString(reader["extra"]));
                                                break;
                                            case 4: //Feature
                                                apkFile.Features.Add(Convert.ToString(reader["extra"]));
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    transaction.Commit();
                }
            }

            if (!alreadyCached)
            {
                apkFile = ApkParser.ParseApk(apkFile);
                apkFile = InsertApkFile(apkFile);
            }

            return apkFile;
        }

        private static ApkFile InsertApkFile(ApkFile apkFile)
        {
            using (var dbConnection = new SQLiteConnection(DataSource))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText ="INSERT OR IGNORE INTO apk (hash, package_name, internal_name, local_version, version_code, minimum_sdk_version, target_sdk_version, icon_path) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
                        command.Parameters.Add(new SQLiteParameter(DbType.String, "hash") { Value = apkFile.Md5Hash });
                        command.Parameters.Add(new SQLiteParameter(DbType.String, "package_name") { Value = apkFile.PackageName });
                        command.Parameters.Add(new SQLiteParameter(DbType.String, "internal_name") { Value = apkFile.InternalName });
                        command.Parameters.Add(new SQLiteParameter(DbType.String, "local_version") { Value = apkFile.LocalVersion });
                        command.Parameters.Add(new SQLiteParameter(DbType.String, "version_code") { Value = apkFile.VersionCode });
                        command.Parameters.Add(new SQLiteParameter(DbType.String, "minimum_sdk_version") { Value = apkFile.MinimumSdkVersion });
                        command.Parameters.Add(new SQLiteParameter(DbType.String, "target_sdk_version") { Value = apkFile.TargetSdkVersion });
                        command.Parameters.Add(new SQLiteParameter(DbType.String, "icon_path") { Value = apkFile.IconPath });

                        command.ExecuteNonQuery();
                    }
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "SELECT id_apk FROM apk WHERE hash = ?";
                        command.Parameters.Add(new SQLiteParameter(DbType.String, "hash") { Value = apkFile.Md5Hash });
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    if (reader["id_apk"] != null && !Convert.IsDBNull(reader["id_apk"]))
                                    {
                                        apkFile.IdApkFile = Convert.ToInt64(reader["id_apk"]);
                                    }
                                }
                            }
                        }
                    }

                    var extrasInserted = false;
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "SELECT count(*) as extras_count FROM extra WHERE id_apk = ?";
                        command.Parameters.Add(new SQLiteParameter(DbType.Int64, "id_apk") { Value = apkFile.IdApkFile });
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    if (reader["extras_count"] != null && !Convert.IsDBNull(reader["extras_count"]))
                                    {
                                        var extrasCount = Convert.ToInt32(reader["extras_count"]);
                                        if (extrasCount > 0)
                                        {
                                            extrasInserted = true;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (!extrasInserted)
                    {
                        foreach (var screenSize in apkFile.ScreenSizes)
                        {
                            using (var command = new SQLiteCommand(dbConnection))
                            {
                                command.CommandText = "INSERT INTO extra (id_apk, id_extra_type, extra) VALUES (?, 1, ?)";
                                command.Parameters.Add(new SQLiteParameter(DbType.Int64, "id_apk") { Value = apkFile.IdApkFile });
                                command.Parameters.Add(new SQLiteParameter(DbType.String, "extra") { Value = screenSize });
                                command.ExecuteNonQuery();
                            }
                        }
                        foreach (var screenDensity in apkFile.ScreenDensities)
                        {
                            using (var command = new SQLiteCommand(dbConnection))
                            {
                                command.CommandText = "INSERT INTO extra (id_apk, id_extra_type, extra) VALUES (?, 2, ?)";
                                command.Parameters.Add(new SQLiteParameter(DbType.Int64, "id_apk") { Value = apkFile.IdApkFile });
                                command.Parameters.Add(new SQLiteParameter(DbType.String, "extra") { Value = screenDensity });
                                command.ExecuteNonQuery();
                            }
                        }
                        foreach (var permission in apkFile.Permissions)
                        {
                            using (var command = new SQLiteCommand(dbConnection))
                            {
                                command.CommandText = "INSERT INTO extra (id_apk, id_extra_type, extra) VALUES (?, 3, ?)";
                                command.Parameters.Add(new SQLiteParameter(DbType.Int64, "id_apk") { Value = apkFile.IdApkFile });
                                command.Parameters.Add(new SQLiteParameter(DbType.String, "extra") { Value = permission });
                                command.ExecuteNonQuery();
                            }
                        }
                        foreach (var feature in apkFile.Features)
                        {
                            using (var command = new SQLiteCommand(dbConnection))
                            {
                                command.CommandText = "INSERT INTO extra (id_apk, id_extra_type, extra) VALUES (?, 4, ?)";
                                command.Parameters.Add(new SQLiteParameter(DbType.Int64, "id_apk") { Value = apkFile.IdApkFile });
                                command.Parameters.Add(new SQLiteParameter(DbType.String, "extra") { Value = feature });
                                command.ExecuteNonQuery();
                            }
                        }
                    }

                    transaction.Commit();
                }
            }
            return apkFile;
        }

        public static void UpdateApkFile(ApkFile apkFile)
        {
            using (var dbConnection = new SQLiteConnection(DataSource))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "UPDATE apk SET google_play_name = ?, category = ?, latest_version = ?, price = ?, last_google_play_fetch = ?, google_play_fetch_fail = 0 WHERE package_name = ?";
                        command.Parameters.Add(new SQLiteParameter(DbType.String, "google_play_name") { Value = apkFile.GooglePlayName });
                        command.Parameters.Add(new SQLiteParameter(DbType.String, "category") { Value = apkFile.Category });
                        command.Parameters.Add(new SQLiteParameter(DbType.String, "latest_version") { Value = apkFile.LatestVersion });
                        command.Parameters.Add(new SQLiteParameter(DbType.String, "price") { Value = apkFile.Price });
                        command.Parameters.Add(new SQLiteParameter(DbType.DateTime, "last_google_play_fetch") { Value = apkFile.LastGooglePlayFetch });
                        command.Parameters.Add(new SQLiteParameter(DbType.String, "package_name") { Value = apkFile.PackageName });

                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
        }

        public static byte[] ReadIcon(ApkFile apkFile)
        {
            if (string.IsNullOrWhiteSpace(apkFile.IconPath))
            {
                return null;
            }

            byte[] iconBytes = null;
            var alreadyCached = false;

            using (var dbConnection = new SQLiteConnection(DataSource))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "SELECT icon FROM apk WHERE hash = ?";
                        command.Parameters.Add(new SQLiteParameter(DbType.String, "hash") { Value = apkFile.Md5Hash });

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["icon"] != null && !Convert.IsDBNull(reader["icon"]))
                                {
                                    alreadyCached = true;
                                    iconBytes = (byte[]) reader["icon"];
                                }
                            }
                        }
                    }
                    transaction.Commit();
                }
            }
            if (!alreadyCached)
            {
                iconBytes = clsUtils.ResizeIcon(ApkParser.ExtractIconAsByteArray(apkFile));
                Task.Factory.StartNew(() => UpdateIcon(apkFile, iconBytes));
            }
            
            return iconBytes;
        }

        private static void UpdateIcon(ApkFile apkFile, byte[] iconBytes)
        {
            using (var dbConnection = new SQLiteConnection(DataSource))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "UPDATE apk SET icon = ? WHERE hash = ?";
                        command.Parameters.Add(new SQLiteParameter(DbType.Binary, "icon") { Value = iconBytes });
                        command.Parameters.Add(new SQLiteParameter(DbType.String, "hash") { Value = apkFile.Md5Hash });

                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
        }

        public static List<string> GetNewPackageNamesFromHashes(HashSet<string> hashes)
        {
            var packageNames = new List<string>();

            if(hashes == null || hashes.Count == 0) return packageNames;

            var hashesAsList = hashes.ToList();
            
            using (var dbConnection = new SQLiteConnection(DataSource))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = string.Format("SELECT DISTINCT package_name FROM apk WHERE last_google_play_fetch IS NULL AND (google_play_fetch_fail IS NULL OR google_play_fetch_fail = 0) AND hash IN ({0})", MakePlaceholders(hashes.Count));
                        for (var i = 0; i < hashesAsList.Count; i++)
                        {
                            command.Parameters.Add(new SQLiteParameter { Value = hashesAsList[i] });
                        }
                        
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["package_name"] != null && !Convert.IsDBNull(reader["package_name"]))
                                {
                                    packageNames.Add(Convert.ToString(reader["package_name"]));
                                }
                            }
                        }
                    }
                    transaction.Commit();
                }
            }

            return packageNames;
        }

        public static List<string> GetPackageNamesFromHashes(HashSet<string> hashes)
        {
            var packageNames = new List<string>();

            if (hashes == null || hashes.Count == 0) return packageNames;

            var hashesAsList = hashes.ToList();

            using (var dbConnection = new SQLiteConnection(DataSource))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = string.Format("SELECT DISTINCT package_name FROM apk WHERE hash IN ({0})", MakePlaceholders(hashes.Count));
                        for (var i = 0; i < hashesAsList.Count; i++)
                        {
                            command.Parameters.Add(new SQLiteParameter { Value = hashesAsList[i] });
                        }

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["package_name"] != null && !Convert.IsDBNull(reader["package_name"]))
                                {
                                    packageNames.Add(Convert.ToString(reader["package_name"]));
                                }
                            }
                        }
                    }
                    transaction.Commit();
                }
            }

            return packageNames;
        }

        public static List<string> GetPackageNamesFromHashesAndOlderThan(HashSet<string> hashes, int days)
        {
            var packageNames = new List<string>();

            if (hashes == null || hashes.Count == 0) return packageNames;

            var hashesAsList = hashes.ToList();

            using (var dbConnection = new SQLiteConnection(DataSource))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = string.Format("SELECT DISTINCT package_name FROM apk WHERE hash IN ({0}) AND (last_google_play_fetch <= ? OR last_google_play_fetch IS NULL) AND (google_play_fetch_fail IS NULL OR google_play_fetch_fail = 0)", MakePlaceholders(hashes.Count));
                        for (var i = 0; i < hashesAsList.Count; i++)
                        {
                            command.Parameters.Add(new SQLiteParameter { Value = hashesAsList[i] });
                        }
                        var limitTime = DateTime.Now.AddDays(-days);
                        command.Parameters.Add(new SQLiteParameter(DbType.DateTime, "last_google_play_fetch") { Value = limitTime });

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["package_name"] != null && !Convert.IsDBNull(reader["package_name"]))
                                {
                                    packageNames.Add(Convert.ToString(reader["package_name"]));
                                }
                            }
                        }
                    }
                    transaction.Commit();
                }
            }

            return packageNames;
        }

        public static List<string> GetAllPackageNames()
        {
            var packageNames = new List<string>();

            using (var dbConnection = new SQLiteConnection(DataSource))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "SELECT DISTINCT package_name FROM apk";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["package_name"] != null && !Convert.IsDBNull(reader["package_name"]))
                                {
                                    packageNames.Add(Convert.ToString(reader["package_name"]));
                                }
                            }
                        }
                    }
                    transaction.Commit();
                }
            }

            return packageNames;
        }

        public static void SetGooglePlayFetchFail(string packageName)
        {
            using (var dbConnection = new SQLiteConnection(DataSource))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "UPDATE apk SET google_play_fetch_fail = 1 WHERE package_name = ?";
                        command.Parameters.Add(new SQLiteParameter(DbType.String, "package_name") { Value = packageName });

                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
        }

        public static string GetSettingValue(SettingEnum setting)
        {
            var settingName = SettingHelper.GetString(setting);
            string settingValue = null;
            using (var dbConnection = new SQLiteConnection(DataSource))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "SELECT setting_value FROM setting WHERE setting_name = ?";
                        command.Parameters.Add(new SQLiteParameter(DbType.String, "setting_name") { Value = settingName });

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["setting_value"] != null && !Convert.IsDBNull(reader["setting_value"]))
                                {
                                    settingValue = Convert.ToString(reader["setting_value"]);
                                }
                            }
                        }
                    }
                    transaction.Commit();
                }
            }

            return settingValue;
        }

        public static List<string> GetScanFolders()
        {
            var scanFolders = new List<string>();

            using (var dbConnection = new SQLiteConnection(DataSource))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "SELECT DISTINCT folder FROM scan_folder";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["folder"] != null && !Convert.IsDBNull(reader["folder"]))
                                {
                                    scanFolders.Add(Convert.ToString(reader["folder"]));
                                }
                            }
                        }
                    }
                    transaction.Commit();
                }
            }

            return scanFolders;
        }

        public static void SetScanFolders(List<string> scanFolders)
        {
            using (var dbConnection = new SQLiteConnection(DataSource))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "DELETE FROM scan_folder";
                        command.ExecuteNonQuery();
                    }

                    if (scanFolders.Count > 0)
                    {
                        using (var command = new SQLiteCommand(dbConnection))
                        {
                            command.CommandText = string.Format("INSERT INTO scan_folder (folder) VALUES {0}", MakePlaceHoldersAlt(scanFolders.Count));
                            foreach (var scanFolder in scanFolders)
                            {
                                command.Parameters.Add(new SQLiteParameter(DbType.String, "folder") { Value = scanFolder });
                            }
                            command.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
            }
        }

        public static List<ApkCommand> GetCommands()
        {
            var apkCommands = new List<ApkCommand>();

            using (var dbConnection = new SQLiteConnection(DataSource))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "SELECT command_name, command_value FROM command";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["command_name"] != null && !Convert.IsDBNull(reader["command_name"]) && reader["command_value"] != null && !Convert.IsDBNull(reader["command_value"]))
                                {
                                    var apkCommand = new ApkCommand
                                    {
                                        Title = Convert.ToString(reader["command_name"]),
                                        Command = Convert.ToString(reader["command_value"])
                                    };
                                    apkCommands.Add(apkCommand);
                                }
                            }
                        }
                    }
                    transaction.Commit();
                }
            }

            return apkCommands;
        }

        public static void SetCommands(List<ApkCommand> commands)
        {
            using (var dbConnection = new SQLiteConnection(DataSource))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "DELETE FROM command";
                        command.ExecuteNonQuery();
                    }

                    if (commands.Count > 0)
                    {
                        using (var command = new SQLiteCommand(dbConnection))
                        {
                            command.CommandText = string.Format("INSERT INTO command (command_name, command_value) VALUES {0}", MakePlaceHoldersAltAlt(commands.Count));
                            foreach (var apkCommand in commands)
                            {
                                command.Parameters.Add(new SQLiteParameter(DbType.String, "command_name") { Value = apkCommand.Title });
                                command.Parameters.Add(new SQLiteParameter(DbType.String, "command_value") { Value = apkCommand.Command });
                            }
                            command.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
            }
        }

        public static void SetSettingValue(SettingEnum setting, string value)
        {
            var settingName = SettingHelper.GetString(setting);

            using (var dbConnection = new SQLiteConnection(DataSource))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "UPDATE setting SET setting_value = ? WHERE setting_name = ?";
                        command.Parameters.Add(new SQLiteParameter(DbType.String, "setting_value") { Value = value });
                        command.Parameters.Add(new SQLiteParameter(DbType.String, "setting_name") { Value = settingName });

                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
        }

        private static string MakePlaceholders(int len)
        {
            var sb = new StringBuilder(len * 2 - 1);
            sb.Append("?");
            for (var i = 1; i < len; i++)
            {
                sb.Append(",?");
            }
            return sb.ToString();
        }

        private static string MakePlaceHoldersAlt(int len)
        {
            var sb = new StringBuilder(len > 0 ? len * 5 - 2 : 3);
            for (var i = 1; i < len; i++)
            {
                sb.Append("(?), ");
            }
            if (len != 0)
            {
                sb.Append("(?)");
            }
            return sb.ToString();
        }

        private static string MakePlaceHoldersAltAlt(int len)
        {
            var sb = new StringBuilder();
            for (var i = 1; i < len; i++)
            {
                sb.Append("(?, ?), ");
            }
            if (len != 0)
            {
                sb.Append("(?, ?)");
            }
            return sb.ToString();
        }

        private static void Vacuum()
        {
            using (var dbConnection = new SQLiteConnection(DataSource))
            {
                dbConnection.Open();
                using (var command = new SQLiteCommand(dbConnection))
                {
                    command.CommandText = "VACUUM";
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void CleanupCacheAll()
        {
            using (var dbConnection = new SQLiteConnection(DataSource))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "DELETE FROM extra";
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "DELETE FROM apk";
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
            Vacuum();
        }

        public static void CleanupCacheIcons()
        {
            using (var dbConnection = new SQLiteConnection(DataSource))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "UPDATE apk SET icon = NULL";
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
            Vacuum();
        }

        public static string GetDbVersion()
        {
            //Read current DB version
            string dbVersion = null;

            using (var dbConnection = new SQLiteConnection(DataSource))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "SELECT setting_value FROM setting WHERE setting_name ='dbversion'";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["setting_value"] != null && !Convert.IsDBNull(reader["setting_value"]))
                                {
                                    dbVersion = Convert.ToString(reader["setting_value"]);
                                }
                            }
                        }
                    }
                    transaction.Commit();
                }
            }

            return dbVersion;
        }

        public static void UpgradeDatabaseVersion1To2()
        {
            using (var dbConnection = new SQLiteConnection(DataSource))
            {
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    using (var dbVersionCommand = new SQLiteCommand(dbConnection))
                    {
                        dbVersionCommand.CommandText = "UPDATE setting SET setting_value = '2' WHERE setting_name = 'dbversion'";
                        dbVersionCommand.ExecuteNonQuery();
                    }

                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "INSERT INTO setting (setting_name) VALUES ('bottom_panel_height')";
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "INSERT INTO setting (setting_name) VALUES ('column_width_filename')";
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "INSERT INTO setting (setting_name) VALUES ('column_width_package')";
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "INSERT INTO setting (setting_name) VALUES ('column_width_internalname')";
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "INSERT INTO setting (setting_name) VALUES ('column_width_googleplayname')";
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "INSERT INTO setting (setting_name) VALUES ('column_width_category')";
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "INSERT INTO setting (setting_name) VALUES ('column_width_localversion')";
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "INSERT INTO setting (setting_name) VALUES ('column_width_latestversion')";
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "INSERT INTO setting (setting_name) VALUES ('column_width_price')";
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "INSERT INTO setting (setting_name) VALUES ('column_width_googleplayfetch')";
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SQLiteCommand(dbConnection))
                    {
                        command.CommandText = "INSERT INTO setting (setting_name) VALUES ('column_sort_index')";
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }

            CleanupCacheAll();
        }
    }
}
