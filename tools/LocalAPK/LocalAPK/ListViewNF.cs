using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using LocalAPK.Data;

namespace LocalAPK
{
    public partial class ListViewNF : ListView
    {
        private readonly Color _highlight = Color.FromArgb(204, 232, 255);
        private readonly Color _highlightBorder = Color.FromArgb(153, 209, 255);

        public delegate void RefreshClickedDelegate(object sender, ApkFile apkFile);
        public event RefreshClickedDelegate RefreshClicked;

        public readonly ListViewSorter LvwColumnSorter;

        public ListViewNF()
        {
            OwnerDraw = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            //Set Listview Sorter
            LvwColumnSorter = new ListViewSorter();
            ListViewItemSorter = LvwColumnSorter;

            this.ColumnClick += ListViewNF_ColumnClick;
        }

        public void EmulateColumnClick(int columnIndex)
        {
            ListViewNF_ColumnClick(this, new ColumnClickEventArgs(columnIndex));
        }

        private void ListViewNF_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == LvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (LvwColumnSorter.Order == SortOrder.Ascending)
                {
                    LvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    LvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                LvwColumnSorter.SortColumn = e.Column;
                LvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            Sort();

            SetSortIcon(e.Column, LvwColumnSorter.Order);
        }

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            var selected = e.Item.Selected;

            if (selected)
            {
                using (var backBrush = new SolidBrush(_highlight))
                {
                    e.Graphics.FillRectangle(backBrush, e.Bounds);
                }
            }
            else
            {
                using (var backBrush = new SolidBrush(e.SubItem.BackColor))
                {
                    e.Graphics.FillRectangle(backBrush, e.Bounds);
                }
            }

            if (e.ColumnIndex == (int) ApkColumn.Refresh)
            {
                e.Graphics.DrawImage(SharedResources.Shared.RefreshSmall, new Point(e.Bounds.X + 6, e.Bounds.Y + 2));
            }
            else
            {
                using (var textBrush = new SolidBrush(SystemColors.WindowText))
                {
                    using (var sf = new StringFormat())
                    {
                        sf.FormatFlags = StringFormatFlags.NoWrap;
                        sf.Trimming = StringTrimming.EllipsisCharacter;
                        sf.Alignment = StringAlignment.Near;
                        e.Graphics.TextRenderingHint = TextRenderingHint.SystemDefault;

                        var columnWidth = 0;
                        if (e.ColumnIndex == 0)
                        {
                            for (var i = 1; i < Columns.Count; i++)
                            {
                                columnWidth += Columns[i].Width;
                            }
                            columnWidth = e.SubItem.Bounds.Width - columnWidth;
                        }
                        else
                        {
                            columnWidth = e.SubItem.Bounds.Width;
                        }
                        e.Graphics.DrawString(e.SubItem.Text, Font, textBrush, new Rectangle(e.Bounds.X, e.Bounds.Y + 2, columnWidth, e.SubItem.Bounds.Height), sf);
                    }
                }
            }
        }

        protected override void OnColumnWidthChanging(ColumnWidthChangingEventArgs e)
        {
            base.OnColumnWidthChanging(e);

            //Do not allow resizing the refresh column
            if (e.ColumnIndex == (int) ApkColumn.Refresh)
            {
                e.Cancel = true;
                e.NewWidth = Columns[e.ColumnIndex].Width;
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            ListViewItem item;
            ListViewItem.ListViewSubItem sub;
            var column = GetColumnAt(e.X, e.Y, out item, out sub);
            if (column != null && column.Value == ApkColumn.Refresh && RefreshClicked != null)
            {
                RefreshClicked(this, (ApkFile) item.Tag);
            }
        }

        public ApkColumn? GetColumnAt(int x, int y, out ListViewItem item, out ListViewItem.ListViewSubItem subItem)
        {
            subItem = null;
            item = GetItemAt(x, y);
            if (item == null)
                return null;

            subItem = item.GetSubItemAt(x, y);
            if (subItem == null)
                return null;

            for (int i = 0; i < item.SubItems.Count; i++)
            {
                if (item.SubItems[i] == subItem)
                    return (ApkColumn) i;
            }
            return null;
        }

        #region Sorting Indicator
        [StructLayout(LayoutKind.Sequential)]
        public struct HDITEM
        {
            public Mask mask;
            public int cxy;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pszText;
            public IntPtr hbm;
            public int cchTextMax;
            public Format fmt;
            public IntPtr lParam;
            // _WIN32_IE >= 0x0300 
            public int iImage;
            public int iOrder;
            // _WIN32_IE >= 0x0500
            public uint type;
            public IntPtr pvFilter;
            // _WIN32_WINNT >= 0x0600
            public uint state;

            [Flags]
            public enum Mask
            {
                Format = 0x4,       // HDI_FORMAT
            };

            [Flags]
            public enum Format
            {
                SortDown = 0x200,   // HDF_SORTDOWN
                SortUp = 0x400,     // HDF_SORTUP
            };
        };

        public const int LVM_FIRST = 0x1000;
        public const int LVM_GETHEADER = LVM_FIRST + 31;

        public const int HDM_FIRST = 0x1200;
        public const int HDM_GETITEM = HDM_FIRST + 11;
        public const int HDM_SETITEM = HDM_FIRST + 12;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, ref HDITEM lParam);

        public void SetSortIcon(int columnIndex, SortOrder order)
        {
            IntPtr columnHeader = SendMessage(Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
            for (int columnNumber = 0; columnNumber <= Columns.Count - 1; columnNumber++)
            {
                var columnPtr = new IntPtr(columnNumber);
                var item = new HDITEM
                {
                    mask = HDITEM.Mask.Format
                };

                if (SendMessage(columnHeader, HDM_GETITEM, columnPtr, ref item) == IntPtr.Zero)
                {
                    throw new Win32Exception();
                }

                if (order != SortOrder.None && columnNumber == columnIndex)
                {
                    switch (order)
                    {
                        case SortOrder.Ascending:
                            item.fmt &= ~HDITEM.Format.SortDown;
                            item.fmt |= HDITEM.Format.SortUp;
                            break;
                        case SortOrder.Descending:
                            item.fmt &= ~HDITEM.Format.SortUp;
                            item.fmt |= HDITEM.Format.SortDown;
                            break;
                    }
                }
                else
                {
                    item.fmt &= ~HDITEM.Format.SortDown & ~HDITEM.Format.SortUp;
                }

                if (SendMessage(columnHeader, HDM_SETITEM, columnPtr, ref item) == IntPtr.Zero)
                {
                    throw new Win32Exception();
                }
            }
        }
        #endregion
    }

    #region Sorting
    public class ListViewSorter : IComparer
    {
        /// <summary>
	    /// Specifies the column to be sorted
	    /// </summary>
	    private int ColumnToSort;
        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private SortOrder OrderOfSort;
        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public ListViewSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Compare the two items
            if ((listviewX.ListView.Columns[ColumnToSort].Text == "Local Version"))
            {
                compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].BackColor.ToString(), listviewY.SubItems[ColumnToSort].BackColor.ToString());
            }
            else
            {
                compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
            }


            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }
    }
    #endregion
}
