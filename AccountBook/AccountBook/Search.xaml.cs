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

namespace AccountBook
{
    public sealed partial class Search : Page
    {
        public List<Voucher> data = new List<Voucher>();
        Voucher n = new Voucher();
        public Search()
        {

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {

        }

        // 处理菜单栏单击事件，查询记账记录
        private async void ApplicationBarIconButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void listReport_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
