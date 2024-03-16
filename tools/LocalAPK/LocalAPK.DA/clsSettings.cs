using System;
using System.Drawing;
using LocalAPK.Data;

namespace LocalAPK.DA
{
    public static class clsSettings
    {
        public static bool Portable { get; set; } //Flag idicating LocalAPK is running under portable mode

	    public static WindowInfo GetMainWindowInfo()
	    {
            var locX = SqliteConnector.GetSettingValue(SettingEnum.WindowLocX);
            var locY = SqliteConnector.GetSettingValue(SettingEnum.WindowLocY);
	        var width = SqliteConnector.GetSettingValue(SettingEnum.WindowSizeWidth);
	        var height = SqliteConnector.GetSettingValue(SettingEnum.WindowSizeHeight);
	        var maximized = SqliteConnector.GetSettingValue(SettingEnum.WindowMaximized);
	        var minimized = SqliteConnector.GetSettingValue(SettingEnum.WindowMinimized);

	        if (string.IsNullOrWhiteSpace(locX) || string.IsNullOrWhiteSpace(locY) || string.IsNullOrWhiteSpace(width) ||
	            string.IsNullOrWhiteSpace(height) || string.IsNullOrWhiteSpace(maximized) ||
	            string.IsNullOrWhiteSpace(minimized))
	        {
	            return null;
	        }
	        var windowInfo = new WindowInfo
	        {
	            Location = new Point(Convert.ToInt32(locX), Convert.ToInt32(locY)),
	            Size = new Size(Convert.ToInt32(width), Convert.ToInt32(height)),
	            Maximized = Convert.ToBoolean(maximized),
	            Minimized = Convert.ToBoolean(minimized)
	        };
	        return windowInfo;
	    }
	    public static void SaveMainWindowInfo(WindowInfo wi)
	    {
			SqliteConnector.SetSettingValue(SettingEnum.WindowLocX, Convert.ToString(wi.Location.X));
            SqliteConnector.SetSettingValue(SettingEnum.WindowLocY, Convert.ToString(wi.Location.Y));
            SqliteConnector.SetSettingValue(SettingEnum.WindowSizeWidth, Convert.ToString(wi.Size.Width));
            SqliteConnector.SetSettingValue(SettingEnum.WindowSizeHeight, Convert.ToString(wi.Size.Height));
            SqliteConnector.SetSettingValue(SettingEnum.WindowMaximized, wi.Maximized.ToString().ToLower());
            SqliteConnector.SetSettingValue(SettingEnum.WindowMinimized, wi.Minimized.ToString().ToLower());
	    }
	}
}
