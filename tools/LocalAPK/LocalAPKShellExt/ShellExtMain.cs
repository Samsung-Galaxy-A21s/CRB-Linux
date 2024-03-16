using LocalAPK.DA;
using LocalAPK.SharedResources;
using LocalAPK.ShellExt;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using LocalAPK.Data;

namespace LocalAPKShellExt
{
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("2D0690B5-CFA3-47E4-B1E3-45BE4279B6D7"), ComVisible(true)]
	public class ShellExtMain : IExtractIconA, IExtractIconW, IPersistFile, IShellExtInit, IContextMenu
	{
		private const string Guid = "{2D0690B5-CFA3-47E4-B1E3-45BE4279B6D7}";
		private string currentFile;

		public ShellExtMain(){
			// Load the bitmap for the menu item.
            Bitmap bmp = LocalAPK.SharedResources.Shared.Logo16;

			//Make the ContextMenuIcon transparant
            //bmp.MakeTransparent(bmp.GetPixel(0, 0));

            this.menuBmp = bmp.GetHbitmap();
		}

		~ShellExtMain()
        {
            if (this.menuBmp != IntPtr.Zero)
            {
                NativeMethods.DeleteObject(this.menuBmp);
                this.menuBmp = IntPtr.Zero;
            }
        }

		#region Shell Extension Registration
		[ComRegisterFunction()]
		public static void Register(Type t)
		{
			ShellExtReg.RegisterShellExtHandlers(t.GUID, "LocalAPK.ShellExt.ShellExtMain Class");
		}

		[ComUnregisterFunction()]
		public static void Unregister(Type t)
		{
			ShellExtReg.UnregisterShellExtHandlers(t.GUID);
		}
		#endregion

		#region IShellExtInit Members

		/// <summary>
		/// Initialize the context menu handler.
		/// </summary>
		/// <param name="pidlFolder">
		/// A pointer to an ITEMIDLIST structure that uniquely identifies a folder.
		/// </param>
		/// <param name="pDataObj">
		/// A pointer to an IDataObject interface object that can be used to retrieve 
		/// the objects being acted upon.
		/// </param>
		/// <param name="hKeyProgID">
		/// The registry key for the file object or folder type.
		/// </param>
		public void Initialize(IntPtr pidlFolder, IntPtr pDataObj, IntPtr hKeyProgID)
		{
			if (pDataObj == IntPtr.Zero)
			{
				throw new ArgumentException();
			}

			FORMATETC fe = new FORMATETC();
			fe.cfFormat = (short)CLIPFORMAT.CF_HDROP;
			fe.ptd = IntPtr.Zero;
			fe.dwAspect = DVASPECT.DVASPECT_CONTENT;
			fe.lindex = -1;
			fe.tymed = TYMED.TYMED_HGLOBAL;
			STGMEDIUM stm = new STGMEDIUM();

			// The pDataObj pointer contains the objects being acted upon. In this 
			// example, we get an HDROP handle for enumerating the selected files 
			// and folders.
			IDataObject dataObject = (IDataObject)Marshal.GetObjectForIUnknown(pDataObj);
			dataObject.GetData(ref fe, out stm);

			try
			{
				// Get an HDROP handle.
				IntPtr hDrop = stm.unionmember;
				if (hDrop == IntPtr.Zero)
				{
					throw new ArgumentException();
				}

				// Determine how many files are involved in this operation.
				uint nFiles = NativeMethods.DragQueryFile(hDrop, UInt32.MaxValue, null, 0);

				// This code sample displays the custom context menu item when only 
				// one file is selected. 
				if (nFiles == 1)
				{
					// Get the path of the file.
					StringBuilder fileName = new StringBuilder(260);
					if (0 == NativeMethods.DragQueryFile(hDrop, 0, fileName,
						fileName.Capacity))
					{
						Marshal.ThrowExceptionForHR(WinError.E_FAIL);
					}
					this.currentFile = fileName.ToString();
				}
				else
				{
					Marshal.ThrowExceptionForHR(WinError.E_FAIL);
				}
			}
			finally
			{
				NativeMethods.ReleaseStgMedium(ref stm);
			}
		}

		#endregion

		#region IPersistFile Members
		public void GetClassID(out Guid pClassID)
		{
			pClassID = new Guid(Guid);
		}

		public void GetCurFile(out string ppszFileName)
		{
			//Not needed for shell extensions
			ppszFileName = null;
		}

		public int IsDirty()
		{
			//Not needed for shell extensions
			return 0;
		}

		public void Load(string pszFileName, int dwMode)
		{
			currentFile = pszFileName;
		}

		public void Save(string pszFileName, bool fRemember)
		{
			//Not needed for shell extensions
		}

		public void SaveCompleted(string pszFileName)
		{
			//Not needed for shell extensions
		}
		#endregion

		#region IContextMenu Members

		/// <summary>
		/// Add commands to a shortcut menu.
		/// </summary>
		/// <param name="hMenu">A handle to the shortcut menu.</param>
		/// <param name="iMenu">
		/// The zero-based position at which to insert the first new menu item.
		/// </param>
		/// <param name="idCmdFirst">
		/// The minimum value that the handler can specify for a menu item ID.
		/// </param>
		/// <param name="idCmdLast">
		/// The maximum value that the handler can specify for a menu item ID.
		/// </param>
		/// <param name="uFlags">
		/// Optional flags that specify how the shortcut menu can be changed.
		/// </param>
		/// <returns>
		/// If successful, returns an HRESULT value that has its severity value set 
		/// to SEVERITY_SUCCESS and its code value set to the offset of the largest 
		/// command identifier that was assigned, plus one.
		/// </returns>
		public int QueryContextMenu(
			IntPtr hMenu,
			uint iMenu,
			uint idCmdFirst,
			uint idCmdLast,
			uint uFlags)
		{
			// If uFlags include CMF_DEFAULTONLY then we should not do anything.
			if (((uint)CMF.CMF_DEFAULTONLY & uFlags) != 0)
			{
				return WinError.MAKE_HRESULT(WinError.SEVERITY_SUCCESS, 0, 0);
			}

			MENUINFO mnfo = new MENUINFO();
			mnfo.cbSize = (UInt32)Marshal.SizeOf(mnfo);
			mnfo.fMask = MIM.MIM_STYLE;
			mnfo.dwStyle = MNS.MNS_CHECKORBMP;
			NativeMethods.SetMenuInfo(hMenu, ref mnfo);

			// Use either InsertMenu or InsertMenuItem to add menu items.
			MENUITEMINFO mii = new MENUITEMINFO();
			mii.cbSize = (uint)Marshal.SizeOf(mii);
			mii.fMask = MIIM.MIIM_BITMAP | MIIM.MIIM_STRING | MIIM.MIIM_FTYPE |
				MIIM.MIIM_ID | MIIM.MIIM_STATE;
			mii.wID = idCmdFirst + IDM_DISPLAY;
			mii.fType = MFT.MFT_STRING;
			mii.dwTypeData = this.menuText;
			mii.fState = MFS.MFS_ENABLED;
			mii.hbmpItem = this.menuBmp;
			if (!NativeMethods.InsertMenuItem(hMenu, iMenu, true, ref mii))
			{
				return Marshal.GetHRForLastWin32Error();
			}

			// Add a separator.
			MENUITEMINFO sep = new MENUITEMINFO();
			sep.cbSize = (uint)Marshal.SizeOf(sep);
			sep.fMask = MIIM.MIIM_TYPE;
			sep.fType = MFT.MFT_SEPARATOR;
			if (!NativeMethods.InsertMenuItem(hMenu, iMenu + 1, true, ref sep))
			{
				return Marshal.GetHRForLastWin32Error();
			}

			// Return an HRESULT value with the severity set to SEVERITY_SUCCESS. 
			// Set the code value to the offset of the largest command identifier 
			// that was assigned, plus one (1).
			return WinError.MAKE_HRESULT(WinError.SEVERITY_SUCCESS, 0,
				IDM_DISPLAY + 1);
		}

		/// <summary>
		/// Carry out the command associated with a shortcut menu item.
		/// </summary>
		/// <param name="pici">
		/// A pointer to a CMINVOKECOMMANDINFO or CMINVOKECOMMANDINFOEX structure 
		/// containing information about the command. 
		/// </param>
		public void InvokeCommand(IntPtr pici)
		{
			bool isUnicode = false;

			// Determine which structure is being passed in, CMINVOKECOMMANDINFO or 
			// CMINVOKECOMMANDINFOEX based on the cbSize member of lpcmi. Although 
			// the lpcmi parameter is declared in Shlobj.h as a CMINVOKECOMMANDINFO 
			// structure, in practice it often points to a CMINVOKECOMMANDINFOEX 
			// structure. This struct is an extended version of CMINVOKECOMMANDINFO 
			// and has additional members that allow Unicode strings to be passed.
			CMINVOKECOMMANDINFO ici = (CMINVOKECOMMANDINFO)Marshal.PtrToStructure(
				pici, typeof(CMINVOKECOMMANDINFO));
			CMINVOKECOMMANDINFOEX iciex = new CMINVOKECOMMANDINFOEX();
			if (ici.cbSize == Marshal.SizeOf(typeof(CMINVOKECOMMANDINFOEX)))
			{
				if ((ici.fMask & CMIC.CMIC_MASK_UNICODE) != 0)
				{
					isUnicode = true;
					iciex = (CMINVOKECOMMANDINFOEX)Marshal.PtrToStructure(pici,
						typeof(CMINVOKECOMMANDINFOEX));
				}
			}

			// Determines whether the command is identified by its offset or verb.
			// There are two ways to identify commands:
			// 
			//   1) The command's verb string 
			//   2) The command's identifier offset
			// 
			// If the high-order word of lpcmi->lpVerb (for the ANSI case) or 
			// lpcmi->lpVerbW (for the Unicode case) is nonzero, lpVerb or lpVerbW 
			// holds a verb string. If the high-order word is zero, the command 
			// offset is in the low-order word of lpcmi->lpVerb.

			// For the ANSI case, if the high-order word is not zero, the command's 
			// verb string is in lpcmi->lpVerb. 
			if (!isUnicode && NativeMethods.HighWord(ici.verb.ToInt32()) != 0)
			{
				// Is the verb supported by this context menu extension?
				if (Marshal.PtrToStringAnsi(ici.verb) == this.verb)
				{
					OnVerbDisplayFileName(ici.hwnd);
				}
				else
				{
					// If the verb is not recognized by the context menu handler, it 
					// must return E_FAIL to allow it to be passed on to the other 
					// context menu handlers that might implement that verb.
					Marshal.ThrowExceptionForHR(WinError.E_FAIL);
				}
			}

			// For the Unicode case, if the high-order word is not zero, the 
			// command's verb string is in lpcmi->lpVerbW. 
			else if (isUnicode && NativeMethods.HighWord(iciex.verbW.ToInt32()) != 0)
			{
				// Is the verb supported by this context menu extension?
				if (Marshal.PtrToStringUni(iciex.verbW) == this.verb)
				{
					OnVerbDisplayFileName(ici.hwnd);
				}
				else
				{
					// If the verb is not recognized by the context menu handler, it 
					// must return E_FAIL to allow it to be passed on to the other 
					// context menu handlers that might implement that verb.
					Marshal.ThrowExceptionForHR(WinError.E_FAIL);
				}
			}

			// If the command cannot be identified through the verb string, then 
			// check the identifier offset.
			else
			{
				// Is the command identifier offset supported by this context menu 
				// extension?
				if (NativeMethods.LowWord(ici.verb.ToInt32()) == IDM_DISPLAY)
				{
					OnVerbDisplayFileName(ici.hwnd);
				}
				else
				{
					// If the verb is not recognized by the context menu handler, it 
					// must return E_FAIL to allow it to be passed on to the other 
					// context menu handlers that might implement that verb.
					Marshal.ThrowExceptionForHR(WinError.E_FAIL);
				}
			}
		}

		/// <summary>
		/// Get information about a shortcut menu command, including the help string 
		/// and the language-independent, or canonical, name for the command.
		/// </summary>
		/// <param name="idCmd">Menu command identifier offset.</param>
		/// <param name="uFlags">
		/// Flags specifying the information to return. This parameter can have one 
		/// of the following values: GCS_HELPTEXTA, GCS_HELPTEXTW, GCS_VALIDATEA, 
		/// GCS_VALIDATEW, GCS_VERBA, GCS_VERBW.
		/// </param>
		/// <param name="pReserved">Reserved. Must be IntPtr.Zero</param>
		/// <param name="pszName">
		/// The address of the buffer to receive the null-terminated string being 
		/// retrieved.
		/// </param>
		/// <param name="cchMax">
		/// Size of the buffer, in characters, to receive the null-terminated string.
		/// </param>
		public void GetCommandString(
			UIntPtr idCmd,
			uint uFlags,
			IntPtr pReserved,
			StringBuilder pszName,
			uint cchMax)
		{
			if (idCmd.ToUInt32() == IDM_DISPLAY)
			{
				switch ((GCS)uFlags)
				{
					case GCS.GCS_VERBW:
						if (this.verbCanonicalName.Length > cchMax - 1)
						{
							Marshal.ThrowExceptionForHR(WinError.STRSAFE_E_INSUFFICIENT_BUFFER);
						}
						else
						{
							pszName.Clear();
							pszName.Append(this.verbCanonicalName);
						}
						break;

					case GCS.GCS_HELPTEXTW:
						if (this.verbHelpText.Length > cchMax - 1)
						{
							Marshal.ThrowExceptionForHR(WinError.STRSAFE_E_INSUFFICIENT_BUFFER);
						}
						else
						{
							pszName.Clear();
							pszName.Append(this.verbHelpText);
						}
						break;
				}
			}
		}

		#endregion

		#region IExtractIcon Members
		private Icon generateIcon()
		{
			if (!File.Exists(currentFile))
			{
				return null;
			}

            var apkFile = new ApkFile { LongFileName = currentFile };
            apkFile = SqliteConnector.ReadApkFile(apkFile);
		    var iconAsByteArray = SqliteConnector.ReadIcon(apkFile);

		    if (iconAsByteArray != null)
		    {
                //Create stream from byte array
                var memoryStream = new MemoryStream(iconAsByteArray);

                //Create bitmap from stream
                var bitmap = new Bitmap(memoryStream);
                var iconHandle = bitmap.GetHicon();

                //Dispose memorystream for GC Cleanup
                memoryStream.Close();
                memoryStream.Dispose();

                //Return Icon
                return Icon.FromHandle(iconHandle);
            }

		    return null;
		}
		#endregion

		#region ContextMenuExt specific

		// The name of the selected file.
        private string menuText = "LocalAPK Info...";
        private IntPtr menuBmp = IntPtr.Zero;
        private string verb = "localapkinfo";
        private string verbCanonicalName = "LocalAPKInfo";
        private string verbHelpText = "LocalAPK Info...";
        private uint IDM_DISPLAY = 0;

		void OnVerbDisplayFileName(IntPtr hWnd)
		{
			frmFileInfo fileInfoForm = new frmFileInfo(currentFile);
			int startPosX = System.Windows.Forms.Cursor.Position.X;
			int startPosY = System.Windows.Forms.Cursor.Position.Y;
			System.Windows.Forms.Screen currentScreen = System.Windows.Forms.Screen.FromPoint(System.Windows.Forms.Cursor.Position);
			Rectangle workingArea = currentScreen.WorkingArea;
			if (System.Windows.Forms.Cursor.Position.X + fileInfoForm.Width > workingArea.Width + workingArea.Left)
			{
				startPosX = workingArea.Left + workingArea.Width - fileInfoForm.Width;
			}
			if (System.Windows.Forms.Cursor.Position.Y + fileInfoForm.Height > workingArea.Height + workingArea.Top)
			{
				startPosY = workingArea.Top + workingArea.Height - fileInfoForm.Height;
			}
			fileInfoForm.Left = startPosX;
			fileInfoForm.Top = startPosY;
			fileInfoForm.Show();
		}
		#endregion



		int IExtractIconA.GetIconLocation(ExtractIconOptions uFlags, StringBuilder szIconFile, int cchMax, out int piIndex, out ExtractIconFlags pwFlags)
		{
			return GetIconLocation(uFlags, out piIndex, out pwFlags);
		}

		int IExtractIconW.GetIconLocation(ExtractIconOptions uFlags, StringBuilder szIconFile, int cchMax, out int piIndex, out ExtractIconFlags pwFlags)
		{
			return GetIconLocation(uFlags, out piIndex, out pwFlags);
		}

		private int GetIconLocation(ExtractIconOptions uFlags, out int piIndex, out ExtractIconFlags pwFlags)
		{
			//No need for an index
			piIndex = 0;

			//Check ShellExtLib.cs for more info on these flags
			pwFlags = ExtractIconFlags.NotFilename | ExtractIconFlags.PerInstance | ExtractIconFlags.DontCache;

			//Return the name for the icon cache
			//szIconFile = Marshal.StringToHGlobalAuto(currentFile);

			//I got this under control!
			return WinError.S_OK;
		}

		int IExtractIconA.Extract(string pszFile, uint nIconIndex, out IntPtr phiconLarge, out IntPtr phiconSmall, uint nIconSize)
		{
			return Extract(out phiconLarge, out phiconSmall, nIconSize);
		}


		int IExtractIconW.Extract(string pszFile, uint nIconIndex, out IntPtr phiconLarge, out IntPtr phiconSmall, uint nIconSize)
		{
			return Extract(out phiconLarge, out phiconSmall, nIconSize);
		}

		private int Extract(out IntPtr phiconLarge, out IntPtr phiconSmall, uint nIconSize)
		{
			Icon icon = null;

			try
			{
				icon = generateIcon();
				if (icon == null)
				{
					phiconLarge = IntPtr.Zero;
					phiconSmall = IntPtr.Zero;
				}
			}
			catch
			{
				phiconLarge = IntPtr.Zero;
				phiconSmall = IntPtr.Zero;
			}

			var s_size = (int)nIconSize >> 16;
			var l_size = (int)nIconSize & 0xffff;
			phiconLarge = (new Icon(icon, l_size, l_size)).Handle;
			phiconSmall = (new Icon(icon, s_size, s_size)).Handle;

			//Set icon null for GC cleanup
			icon = null;

			//I got this under control!
			return WinError.S_OK;
		}
	}
}
