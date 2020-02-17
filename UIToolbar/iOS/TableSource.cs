using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace UIToolbar.iOS
{
    public class TableSource : UITableViewSource
    {
        List<UITextField> listItems;

        public TableSource(List<UITextField> items)
        {
            listItems = items;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {

            var cell = tableView.DequeueReusableCell(CellTable.Key, indexPath) as CellTable;

            UITextField item = listItems[indexPath.Row];

            cell.TextLabel.Text = item.Placeholder;

            return cell;


            //if there are no cells to reuse, create a new one
            //if (cell == null)
            //{
            //    cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
            //}

            //cell.TextLabel.Text = item;

        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return listItems.Count;
        }
    }
}
