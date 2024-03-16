using System;

namespace LocalAPK.Data
{
    public static class SettingHelper
    {
        public static string GetString(SettingEnum setting)
        {
            switch (setting)
            {
                case SettingEnum.MassRenameString:
                    return "mass_rename_string";
                case SettingEnum.StartupRefresh:
                    return "startup_refresh";
                case SettingEnum.AutoFetchGooglePlay:
                    return"auto_fetch_google_play";
                case SettingEnum.GroupResults:
                    return"group_results";
                case SettingEnum.SubdirGroup:
                    return"subdir_group";
                case SettingEnum.RefreshDays:
                    return"refresh_days";
                case SettingEnum.WindowLocX:
                    return"window_loc_x";
                case SettingEnum.WindowLocY:
                    return"window_loc_y";
                case SettingEnum.WindowSizeWidth:
                    return"window_size_width";
                case SettingEnum.WindowSizeHeight:
                    return"window_size_height";
                case SettingEnum.WindowMaximized:
                    return"window_maximized";
                case SettingEnum.WindowMinimized:
                    return"window_minimized";
                case SettingEnum.LicenceEmail:
                    return"licence_email";
                case SettingEnum.LicenceCode:
                    return"licence_code";
                case SettingEnum.ExportDelimiter:
                    return "export_delimiter";
                case SettingEnum.ExportFilename:
                    return "export_filename";
                case SettingEnum.BottomPanelHeight:
                    return "bottom_panel_height";
                case SettingEnum.ColumnWidthFilename:
                    return "column_width_filename";
                case SettingEnum.ColumnWidthPackage:
                    return "column_width_package";
                case SettingEnum.ColumnWidthInternalname:
                    return "column_width_internalname";
                case SettingEnum.ColumnWidthGoogleplayname:
                    return "column_width_googleplayname";
                case SettingEnum.ColumnWidthCategory:
                    return "column_width_category";
                case SettingEnum.ColumnWidthLocalversion:
                    return "column_width_localversion";
                case SettingEnum.ColumnWidthLatestversion:
                    return "column_width_latestversion";
                case SettingEnum.ColumnWidthPrice:
                    return "column_width_price";
                case SettingEnum.ColumnWidthGoogleplayfetch:
                    return "column_width_googleplayfetch";
                case SettingEnum.ColumnSortIndex:
                    return "column_sort_index";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
