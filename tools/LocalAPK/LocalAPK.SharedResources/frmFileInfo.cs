using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LocalAPK.Data;
using System.Web;
using LocalAPK.DA;

namespace LocalAPK.SharedResources
{
    public partial class frmFileInfo : Form
    {
	    private readonly string _fileName;
        public frmFileInfo(string fileName)
        {
            InitializeComponent();
            _fileName = fileName;
        }

        private void frmFileInfo_Load(object sender, EventArgs e)
        {
            //Select OK Button
            btnOK.Select();

            //Load info
            ShowInfo();

			//Change permissions/features backcolors
			txtFeaturesValue.BackColor = SystemColors.Window;
			txtPermissionsValue.BackColor = SystemColors.Window;
        }

        private void ShowInfo()
        {
            var apkFile = new ApkFile { LongFileName = _fileName };

            //Filename
            lblFilenameValue.Text = apkFile.ShortFileName;

            Text = string.Format("Properties of {0}", apkFile.ShortFileName);

            //Read APK File
            apkFile = SqliteConnector.ReadApkFile(apkFile);

            //Package
            lblPackageNameValue.Text = apkFile.PackageName;

            //Internal name
			lblInternalNameValue.Text = apkFile.InternalName;

            //Google Play name
            lblGooglePlayNameValue.Text = apkFile.GooglePlayName;

            //Local Version
            lblLocalVersionValue.Text = apkFile.LocalVersion;

            //Latest Version
            lblLatestVersionValue.Text = apkFile.LatestVersion;

            //Category
            lblCategoryValue.Text = apkFile.Category;

            //Price
            lblPriceValue.Text = apkFile.Price;

			//Version code
			lblVersionCodeValue.Text = apkFile.VersionCode;

			//Minium SDK Version
			lblMinSDKVersionValue.Text = clsUtils.TranslateSdkVersion(apkFile.MinimumSdkVersion);
			
			//Target SDK Version
			lblTargetSDKVersionValue.Text = clsUtils.TranslateSdkVersion(apkFile.TargetSdkVersion);

			//Permissions
			if (apkFile.Permissions.Count > 0)
			{
				txtPermissionsValue.Text = string.Empty;
				foreach (var permission in apkFile.Permissions)
				{
					txtPermissionsValue.Text += string.Format("{0}\r\n", permission);
				}
				txtPermissionsValue.Text = txtPermissionsValue.Text.Remove(txtPermissionsValue.Text.Length - 2, 2);
			}

			//Features
			if (apkFile.Features.Count > 0)
			{
				txtFeaturesValue.Text = string.Empty;
				foreach (var feature in apkFile.Features)
				{
					txtFeaturesValue.Text += string.Format("{0}\r\n", feature);
				}
				txtFeaturesValue.Text = txtFeaturesValue.Text.Remove(txtFeaturesValue.Text.Length - 2, 2);
			}

			//Screen sizes
			if (apkFile.ScreenSizes.Count > 0)
			{
				lblScreenSizesValue.Text = string.Empty;
				foreach (var screenSize in apkFile.ScreenSizes)
				{
					lblScreenSizesValue.Text += string.Format("{0}, ", screenSize);
				}
				lblScreenSizesValue.Text = lblScreenSizesValue.Text.Remove(lblScreenSizesValue.Text.Length - 2, 2);
			}

			//Screen densities
			if (apkFile.ScreenDensities.Count > 0)
			{
				lblScreenDensitiesValue.Text = string.Empty;
				foreach (var screenDensity in apkFile.ScreenDensities)
				{
					lblScreenDensitiesValue.Text += string.Format("{0}, ", screenDensity);
				}
				lblScreenDensitiesValue.Text = lblScreenDensitiesValue.Text.Remove(lblScreenDensitiesValue.Text.Length - 2, 2);
			}

            //Icon
            Task.Factory.StartNew(() => SqliteConnector.ReadIcon(apkFile)).ContinueWith(t => SetApkIcon(t.Result));

            //Fetch details
            if (!apkFile.LastGooglePlayFetch.HasValue && (!apkFile.GooglePlayFetchFail.HasValue || !apkFile.GooglePlayFetchFail.Value) && Convert.ToBoolean(SqliteConnector.GetSettingValue(SettingEnum.AutoFetchGooglePlay)))
            {
                btnRefreshDetails.Enabled = false;
                var wc = new WebClient {Encoding = Encoding.UTF8};
                wc.DownloadStringCompleted += Wc_DownloadStringCompleted;
                wc.DownloadStringAsync(new Uri(GooglePlayHelper.GetUrlForPackageName(apkFile.PackageName, true)), apkFile.PackageName);
            }
            else
            {
                btnRefreshDetails.Enabled = true;
            }
        }

        private void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var googlePlayPage = new HtmlAgilityPack.HtmlDocument();
            try
            {
                googlePlayPage.LoadHtml(e.Result);

                //Current Version
                string currentVersion = null;
                if (googlePlayPage.DocumentNode.SelectNodes("//div[.='Current Version']")?.Count >= 1)
                {
                    var currentVersionNode = googlePlayPage.DocumentNode.SelectNodes("//div[.='Current Version']").First();
                    var nextNodeAfterCurrentVersionNode = currentVersionNode.NextSibling;
                    if (!string.IsNullOrWhiteSpace(nextNodeAfterCurrentVersionNode?.InnerText))
                    {
                        currentVersion = nextNodeAfterCurrentVersionNode.InnerText;
                    }
                }

                //Genre
                string genre = null;
                if (googlePlayPage.DocumentNode.SelectNodes("//a[@itemprop='genre']")?.Count >= 1)
                {
                    genre = googlePlayPage.DocumentNode.SelectNodes("//a[@itemprop='genre']").First().InnerText;
                }

                //Name
                string name = null;
                if (googlePlayPage.DocumentNode.SelectNodes("//h1[@itemprop='name']")?.Count >= 1)
                {
                    var nameNode = googlePlayPage.DocumentNode.SelectNodes("//h1[@itemprop='name']").First();
                    var innerNameNode = nameNode.FirstChild;
                    if (innerNameNode != null && !string.IsNullOrWhiteSpace(innerNameNode.InnerText))
                    {
                        name = innerNameNode.InnerText;
                    }
                }

                //Price
                string price = null;
                if (googlePlayPage.DocumentNode.SelectNodes("//meta[@itemprop='price']")?.Count >= 1)
                {
                    var priceNode = googlePlayPage.DocumentNode.SelectNodes("//meta[@itemprop='price']").First();
                    if (priceNode.Attributes.Contains("content") && !string.IsNullOrWhiteSpace(priceNode.Attributes["content"].Value))
                    {
                        price = priceNode.Attributes["content"].Value;
                    }
                }

                if (!string.IsNullOrWhiteSpace(currentVersion) && !string.IsNullOrWhiteSpace(genre) && !string.IsNullOrWhiteSpace(name))
                {
                    //HtmlDecode
                    currentVersion = WebUtility.HtmlDecode(currentVersion);
                    genre = WebUtility.HtmlDecode(genre);
                    name = WebUtility.HtmlDecode(name);

                    var lastGooglePlayFetch = DateTime.Now;

                    string fixedPrice;
                    if (string.IsNullOrWhiteSpace(price) || price.Trim() == "0")
                    {
                        fixedPrice = "Free";
                    }
                    else
                    {
                        fixedPrice = price;
                    }

                    lblGooglePlayNameValue.Text = name;
                    lblLatestVersionValue.Text = currentVersion;
                    lblCategoryValue.Text = genre;
                    lblPriceValue.Text = fixedPrice;

                    //Update database
                    var apkFileToUpdate = new ApkFile
                    {
                        PackageName = Convert.ToString(e.UserState),
                        LatestVersion = currentVersion,
                        GooglePlayName = name,
                        Price = fixedPrice,
                        Category = genre,
                        LastGooglePlayFetch = lastGooglePlayFetch,
                        GooglePlayFetchFail = false
                    };
                    SqliteConnector.UpdateApkFile(apkFileToUpdate);
                }
                else
                {
                    SqliteConnector.SetGooglePlayFetchFail(Convert.ToString(e.UserState));
                }
            }
            catch
            {
                SqliteConnector.SetGooglePlayFetchFail(Convert.ToString(e.UserState));
            }
            finally
            {
                btnRefreshDetails.Enabled = true;
            }
        }

        private void SetApkIcon(byte[] imageAsByteArray)
        {
            if (imageAsByteArray != null)
            {
                Invoke((MethodInvoker)delegate {
                    using (var ms = new MemoryStream(imageAsByteArray))
                    {
                        picIcon.Image = Image.FromStream(ms);
                        if (picIcon.Image.Width > picIcon.Width || picIcon.Image.Height > picIcon.Height)
                        {
                            picIcon.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        else
                        {
                            picIcon.SizeMode = PictureBoxSizeMode.CenterImage;
                        }
                    }
                });
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmFileInfo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnCommands_Click(object sender, EventArgs e)
        {
            var cms = new ContextMenuStrip();

            foreach (var cd in SqliteConnector.GetCommands())
            {
                var cdItem = new ToolStripMenuItem();
                cdItem.Tag = cd;
                cdItem.Text = cd.Title;
                cdItem.Click += new EventHandler(cdItem_Click);
                cms.Items.Add(cdItem);
            }

            var pButtonPosition = PointToScreen(btnCommands.Location);
            var pMenuPosition = new Point(pButtonPosition.X + 10, pButtonPosition.Y + 50);
            cms.Show(pMenuPosition);
        }

        void cdItem_Click(object sender, EventArgs e)
        {
            var cdItem = (ToolStripMenuItem)sender;
            var cd = (ApkCommand) cdItem.Tag;

            //Selection Info
            var fileName = lblFilenameValue.Text;
            var packageName = lblPackageNameValue.Text;
            var longFileName = _fileName;
            var appName = lblGooglePlayNameValue.Text;
			var playName = lblGooglePlayNameValue.Text;
	        var category = lblCategoryValue.Text;
            var localVersion = lblLocalVersionValue.Text;
            var latestVersion = lblLatestVersionValue.Text;

            var command = cd.Command;
            command = command.Replace("{filename}", fileName);
            command = command.Replace("{packagename}", packageName);
            command = command.Replace("{longfilename}", longFileName);
            command = command.Replace("{appname}", appName);
			command = command.Replace("{playname}", playName);
			command = command.Replace("{category}", category);
            command = command.Replace("{localversion}", localVersion);
            command = command.Replace("{latestversion}", latestVersion);

            try
            {
                clsUtils.RunCommand(command);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("The command could not be parsed.\n{0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSendToDevice_Click(object sender, EventArgs e)
        {
            var sendToDeviceForm = new frmQRDownload(_fileName);
            sendToDeviceForm.ShowDialog();
        }

		private void btnOpenGooglePlayPage_Click(object sender, EventArgs e)
		{
		    var url = GooglePlayHelper.GetUrlForPackageName(lblPackageNameValue.Text, false);
			Process.Start(url);
		}

        private void btnRefreshDetails_Click(object sender, EventArgs e)
        {
            btnRefreshDetails.Enabled = false;
            var wc = new WebClient { Encoding = Encoding.UTF8 };
            wc.DownloadStringCompleted += Wc_DownloadStringCompleted;
            wc.DownloadStringAsync(new Uri(GooglePlayHelper.GetUrlForPackageName(lblPackageNameValue.Text, true)), lblPackageNameValue.Text);
        }
    }
}
