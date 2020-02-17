using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using UIKit;

namespace UIToolbar.iOS
{
    public partial class UiToolbarController : UIViewController
    {
        private nfloat _keyboardHeight = default;
        private bool _keyboardDidApear = false;
        public UiToolbarController() : base("UiToolbarController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var safeAreaInsets = UIApplication.SharedApplication.KeyWindow.SafeAreaInsets;
            AdditionalSafeAreaInsets = safeAreaInsets;

            UIKeyboard.Notifications.ObserveWillShow(OnKeyboardShow);

            UIKeyboard.Notifications.ObserveWillHide(OnKeyboardHide);

            tableView.RegisterNibForCellReuse(CellTable.Nib, CellTable.Key);


            // defaults to Plain style
            List<UITextField> tableItems = new List<UITextField> { new UITextField { Text = "test1" }, new UITextField { Text = "test1" },
            new UITextField { Text = "test1" }, new UITextField { Text = "test1" }, new UITextField { Text = "test1" },
            new UITextField { Text = "test1" }, new UITextField { Text = "test1" }, new UITextField { Text = "test1" },
            new UITextField { Text = "test1" }, new UITextField { Text = "test1" }, new UITextField { Text = "test1" },
            new UITextField { Text = "test1" }, new UITextField { Text = "test1" }, new UITextField { Text = "test1" },
            new UITextField { Text = "test1" }, new UITextField { Text = "test1" }, new UITextField { Text = "test1" },
            new UITextField { Text = "test1" }, new UITextField { Text = "test1" }, new UITextField { Text = "test1" },
            new UITextField { Text = "test1" }, new UITextField { Text = "test1" }, new UITextField { Text = "test1" },};

            tableView.Source = new TableSource(tableItems);
            Add(tableView);


            // Perform any additional setup after loading the view, typically from a nib.
        }

        private void OnKeyboardHide(object sender, UIKeyboardEventArgs e)
        {

            if (_keyboardDidApear)
            {
                saveBottomConstraint.Constant -= _keyboardHeight;
                cancelBottomConstraint.Constant -= _keyboardHeight;
                _keyboardDidApear = false;
                _keyboardHeight = 0;
            }
        }

        private void OnKeyboardShow(object sender, UIKeyboardEventArgs e)
        {

            NSValue result = (NSValue)e.Notification.UserInfo.ObjectForKey(new NSString(UIKeyboard.FrameEndUserInfoKey));
            CGSize keyboardSize = result.RectangleFValue.Size;
            if (!_keyboardDidApear && _keyboardHeight != keyboardSize.Height)
            {
                saveBottomConstraint.Constant += keyboardSize.Height;
                cancelBottomConstraint.Constant += keyboardSize.Height;
                _keyboardHeight = keyboardSize.Height;
                _keyboardDidApear = true;
            }
        }
    }
}

