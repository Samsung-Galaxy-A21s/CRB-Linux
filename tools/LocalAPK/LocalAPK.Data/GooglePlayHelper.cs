namespace LocalAPK.Data
{
    public static class GooglePlayHelper
    {
        public static string GetUrlForPackageName(string packageName, bool english)
        {
            if (english)
            {
                return "https://play.google.com/store/apps/details?id=" + packageName + "&hl=en";
            }
            else
            {
                return "https://play.google.com/store/apps/details?id=" + packageName;
            }
        }
    }
}
