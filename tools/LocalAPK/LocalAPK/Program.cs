using System;
using System.IO;
using System.Windows.Forms;
using LocalAPK.DA;

namespace LocalAPK
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //Unblock files
            foreach (var file in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory))
            {
                try
                {
                    clsUtils.UnblockFile(file);
                }
                catch
                {
                    
                }
            }

            if (args.Length == 0 || (args.Length == 1 && args[0].ToLower() == "/portable"))
            {
                if (args.Length  == 1 && args[0].ToLower() == "/portable")
                {
                    clsSettings.Portable = true;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
            else
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i].ToLower() == "/registershellext")
                    {
                        clsUtils.RegisterShellExt();
                    }
                    if (args[i].ToLower() == "/unregistershellext")
                    {
						clsUtils.UnregisterShellExt();
                    }
					if (args[i].ToLower() == "/programuninstall")
					{
						if (clsUtils.IsShellExtInstalled())
						{
							clsUtils.UnregisterShellExt();
						}
					}
                }
            }
        }
    }
}
