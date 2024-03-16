namespace LocalAPK.DA
{
    public static class clsUpgrade
    {
        public static void Upgrade()
        {
            var dbVersion = SqliteConnector.GetDbVersion();

            if (string.IsNullOrWhiteSpace(dbVersion)) return;

            if (dbVersion == "1")
            {
                SqliteConnector.UpgradeDatabaseVersion1To2();
            }
        }
    }
}
