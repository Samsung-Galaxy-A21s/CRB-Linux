using System;
using System.Drawing;

namespace LocalAPK.Data
{
	[Serializable]
	public class WindowInfo
	{
		public Point Location { get; set; }
		public Size Size { get; set; }
		public bool Maximized { get; set; }
		public bool Minimized { get; set; }
	}
}
