using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using LocalAPK.QR;
using System.Net.NetworkInformation;

namespace LocalAPK.SharedResources
{
    public partial class frmQRDownload : Form
    {
        private readonly string _fileName;
        private bool _isClosing = false;
        TcpListener _myListener;

        public frmQRDownload(string fileName)
        {
            InitializeComponent();
            this._fileName = fileName;
        }

        private void frmQRDownload_Load(object sender, EventArgs e)
        {
            _myListener = new TcpListener(getLocalIP(), 49743);
            try
            {
                _myListener.Start();
            }
            catch
            {
                MessageBox.Show("LocalAPK failed to start a webserver at port 49743.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            
            var bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
            //QR Code
            var qRCodeEncoder = new QRCodeEncoder();
            qRCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qRCodeEncoder.QRCodeScale = 4;
            qRCodeEncoder.QRCodeVersion = 7;
            qRCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            picQRCode.Image = qRCodeEncoder.Encode("http://" + getLocalIP().ToString() + ":49743/" + System.Uri.EscapeDataString(Path.GetFileName(_fileName)));
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ((BackgroundWorker) sender).Dispose();
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            while (_isClosing == false)
            {
                try
                {
                    int iStartPos = 0;
                    string sRequest;
                    string sRequestedFile;
                    string sResponse;

                    //Accept a new connection
                    var mySocket = _myListener.AcceptSocket();
                    if (mySocket.Connected)
                    {
                        //make a byte array and receive data from the client 
                        var bReceive = new Byte[1024];
                        var i = mySocket.Receive(bReceive, bReceive.Length, 0);

                        //Convert Byte to String
                        var sBuffer = Encoding.ASCII.GetString(bReceive);

                        //At present we will only deal with GET type
                        if (sBuffer.Substring(0, 3) != "GET")
                        {
                            mySocket.Close();
                            return;
                        }
                        // Look for HTTP request
                        iStartPos = sBuffer.IndexOf("HTTP", 1);

                        // Get the HTTP text and version e.g. it will return "HTTP/1.1"
                        var sHttpVersion = sBuffer.Substring(iStartPos, 8);

                        // Extract the Requested Type and Requested file/directory
                        sRequest = sBuffer.Substring(0, iStartPos - 1);

                        //Replace backslash with Forward Slash, if Any
                        sRequest.Replace("\\", "/");

                        //Extract the requested file name
                        iStartPos = sRequest.LastIndexOf("/") + 1;
                        sRequestedFile = System.Uri.UnescapeDataString(sRequest.Substring(iStartPos));

                        if (sRequestedFile == Path.GetFileName(_fileName))
                        {
                            //Get MimeType
                            var sMimeType = "application/vnd.android.package-archive";

                            var iTotBytes = 0;

                            sResponse = "";

                            var bytes = File.ReadAllBytes(_fileName);
                            sResponse += Encoding.ASCII.GetString(bytes);
                            iTotBytes = bytes.Length;

                            SendHeader(sHttpVersion, sMimeType, iTotBytes, " 200 OK", ref mySocket);
                            SendToBrowser(bytes, ref mySocket);
                        }
                        else
                        {
                            var sErrorMessage = "404 - File not found";
                            SendHeader(sHttpVersion, "", sErrorMessage.Length, " 404 Not Found", ref mySocket);
                            SendToBrowser(Encoding.ASCII.GetBytes(sErrorMessage), ref mySocket);
                        }
                        mySocket.Close();
                    }
                }
                catch
                {

                }
            }
        }

        public void SendHeader(string sHttpVersion, string sMIMEHeader, int iTotBytes, string sStatusCode, ref Socket mySocket)
        {
            var sBuffer = string.Empty;

            sBuffer = sBuffer + sHttpVersion + sStatusCode + "\r\n";
            sBuffer = sBuffer + "Connection: Close\r\n";
            sBuffer = sBuffer + "Server: QRDownload\r\n";
            sBuffer = sBuffer + "Content-Type: " + sMIMEHeader + "\r\n";
            sBuffer = sBuffer + "Accept-Ranges: bytes\r\n";
            sBuffer = sBuffer + "Content-Length: " + iTotBytes + "\r\n\r\n";

            var bSendData = Encoding.ASCII.GetBytes(sBuffer);

            SendToBrowser(bSendData, ref mySocket);
        }

        private void SendToBrowser(Byte[] bSendData, ref Socket mySocket)
        {
            if (mySocket.Connected)
            {
                mySocket.Send(bSendData, bSendData.Length, 0);
            }
        }

        private IPAddress getLocalIP()
        {
			IPAddress ipAddress = null;
			foreach (var networkInterface in NetworkInterface.GetAllNetworkInterfaces())
			{
				var addr = networkInterface.GetIPProperties().GatewayAddresses.FirstOrDefault();
				if (addr != null)
				{
					if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
					{
						foreach (var ip in networkInterface.GetIPProperties().UnicastAddresses)
						{
							if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
							{
								ipAddress = ip.Address;
							}
						}
					}
				}
			}
			return ipAddress;
        }

        private void frmQRDownload_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isClosing = true;
            _myListener.Stop();
        }

        private void frmQRDownload_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
