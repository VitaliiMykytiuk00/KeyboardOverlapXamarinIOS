using System;
using Foundation;
using UIKit;

namespace UIToolbar.iOS
{
    public partial class CellTable : UITableViewCell
    {
        public static readonly NSString Key = new NSString("CellTable");
        public static readonly UINib Nib;

        static CellTable()
        {
            Nib = UINib.FromName("CellTable", NSBundle.MainBundle);
        }

        protected CellTable(IntPtr handle) : base(handle)
        {
        }
    }
}
