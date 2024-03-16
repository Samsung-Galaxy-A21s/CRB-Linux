using System;
using System.Collections.Generic;
using System.IO;

namespace LocalAPK.Data
{
	public class ApkFile
	{
		private const string UnknownString = "Unknown";

		//Constructor
		public ApkFile()
		{
			LongFileName = UnknownString;
			PackageName = UnknownString;
			InternalName = UnknownString;
			GooglePlayName = UnknownString;
			Category = UnknownString;
			LocalVersion = UnknownString;
			LatestVersion = UnknownString;
			Price = UnknownString;

			VersionCode = UnknownString;
			MinimumSdkVersion = UnknownString;
			TargetSdkVersion = UnknownString;

			ScreenSizes = new List<string>();
			ScreenDensities = new List<string>();
			Permissions = new List<string>();
			Features = new List<string>();
		}
		//Basic information
		public string LongFileName { get; set; }
		public string PackageName { get; set; }
		public string InternalName { get; set; }
		public string GooglePlayName { get; set; }
		public string Category { get; set; }
		public string LocalVersion { get; set; }
		public string LatestVersion { get; set; }
		public string Price { get; set; }

		//Derived information
		public string ShortFileName
		{
			get { return !string.IsNullOrEmpty(LongFileName) && File.Exists(LongFileName) ? Path.GetFileName(LongFileName) : null; }
		}
		public string DirectoryName
		{
			get { return !string.IsNullOrEmpty(LongFileName) && File.Exists(LongFileName) ? Path.GetDirectoryName(LongFileName) : null; }
		}
		public string GooglePlayUrl
		{
			get
			{
				return !string.IsNullOrEmpty(PackageName)
					? GooglePlayHelper.GetUrlForPackageName(PackageName, false)
					: null;
			}
		}

		//Extra information
        public string IconPath { get; set; }
		public string VersionCode { get; set; }
		public string MinimumSdkVersion { get; set; }
		public string TargetSdkVersion { get; set; }
		public List<string> ScreenSizes { get; set; }
		public List<string> ScreenDensities { get; set; }
		public List<string> Permissions { get; set; }
		public List<string> Features { get; set; }
	    public string Md5Hash { get; set; }
        public long IdApkFile { get; set; }
        public DateTime? LastGooglePlayFetch { get; set; }
        public bool? GooglePlayFetchFail { get; set; }
    }
}
