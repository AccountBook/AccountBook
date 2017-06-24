using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace AccountBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Search : Page
    {
        public List<Voucher> data = new List<Voucher>();
        Voucher n = new Voucher();
        public Search()
        {
            this.InitializeComponent();
            if (App.IsHardwareButtonsAPIPresent)
            {
                backButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                backButton.Visibility = Visibility.Visible;
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                Frame.Navigate(typeof(MainPage), "");
            }
        }

        // 处理菜单栏单击事件，查询记账记录
        private async void ApplicationBarIconButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime? begin = DatePickerBegin.Date.Date;
            DateTime? end = DatePickerEnd.Date.Date.AddDays(1);
            if (begin >= end)
            {
                var i = new MessageDialog("Please check your date input").ShowAsync();
            }
            else
            {
                listReport.ItemsSource = await Common.Search(begin, end, keyWords.Text);
            } 
        }

        private void listReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem != null)
            {
                n = (AccountBook.Voucher)(e.ClickedItem);
            }
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            data = await App.voucherHelper.Getdata();

            if (n.Money != 0)
            {
                App.voucherHelper.Remove(n);
                App.voucherHelper.SaveToFile();
                Frame.Navigate(typeof(Search), "");
                var i = new MessageDialog("Deleted successfully, please search again.").ShowAsync();
            }
            else
            {
                var i = new MessageDialog("You have not selected a bill.").ShowAsync();
            }
        }
    }
}
