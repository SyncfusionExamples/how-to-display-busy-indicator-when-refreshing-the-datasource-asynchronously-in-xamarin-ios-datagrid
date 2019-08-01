using Syncfusion.SfDataGrid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace BusyIndicatorInIOS
{
    public class MyViewController:UIViewController
    {
        SfDataGrid sfDataGrid;
        ViewModel viewModel;
        UIActivityIndicatorView activityIndicator;
        UIButton refresh_button;

        public MyViewController()
        {
            sfDataGrid = new SfDataGrid();
            viewModel = new ViewModel();
            sfDataGrid.ItemsSource = viewModel.OrdersInfo;
            activityIndicator = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.Gray);
            refresh_button = new UIButton();            
            refresh_button.TouchUpInside += Refresh_button_TouchUpInside;
            refresh_button.SetTitle ( "Refresh",UIControlState.Normal);
            refresh_button.SetTitleColor(UIColor.Black,UIControlState.Normal);
            View.AddSubview(refresh_button);
            View.AddSubview(sfDataGrid);
            View.AddSubview(activityIndicator);
            View.BackgroundColor = UIColor.White ;
           
        }

        private async void Refresh_button_TouchUpInside(object sender, EventArgs e)
        {
            activityIndicator.Frame = new CoreGraphics.CGRect(0, 50, this.View.Frame.Width, this.View.Frame.Height);
            activityIndicator.StartAnimating();
            await Task.Delay(new TimeSpan(0, 0, 3));
            viewModel.LoadMoreItems();
            activityIndicator.StopAnimating();
           
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            refresh_button.Frame = new CoreGraphics.CGRect(0, 20, this.View.Frame.Width, 30);
            sfDataGrid.Frame = new CoreGraphics.CGRect(0,50, this.View.Frame.Width, this.View.Frame.Height);
        }
    }
}
