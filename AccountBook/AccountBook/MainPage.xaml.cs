using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AccountBook
{
    //页面继承了INotifyPropertyChanged接口用于实现绑定属性更改事件
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        // 总收入属性
        private string summaryIncome;
        public List<Voucher> data = new List<Voucher>();
        Voucher n = new Voucher();

        public string SummaryIncome
        {
            get
            {
                return summaryIncome;
            }
            set
            {
                summaryIncome = value;
                OnPropertyChanged("SummaryIncome");
            }
        }
        // 总支出属性
        private string summaryExpenses;
        public string SummaryExpenses
        {
            get
            {
                return summaryExpenses;
            }
            set
            {
                summaryExpenses = value;
                OnPropertyChanged("SummaryExpenses");
            }
        }
        // 月结余属性
        private string mouthBalance;
        public string MouthBalance
        {
            get
            {
                return mouthBalance;
            }
            set
            {
                mouthBalance = value;
                OnPropertyChanged("MouthBalance");
            }
        }
        // 年结余属性
        private string yearBalance;
        public string YearBalance
        {
            get
            {
                return yearBalance;
            }
            set
            {
                yearBalance = value;
                OnPropertyChanged("YearBalance");
            }
        }
        public MainPage()
        {
            this.InitializeComponent();
            // 设置磁贴一侧的数据上下文为当前的对象，用于显示上面所定义的属性更改
            var viewTitleBar = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar;
            viewTitleBar.BackgroundColor = Windows.UI.Colors.CornflowerBlue;
            viewTitleBar.ButtonBackgroundColor = Windows.UI.Colors.CornflowerBlue;
            _columnItem.DataContext = this;
            Loaded += MainPage_Loaded;
            DataTransferManager.GetForCurrentView().DataRequested += Mainpage_DataRequested;
        }
        //页面加载处理
        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //设置收入Tile的总收入金额
            SummaryIncome = "总收入：" + (await Common.GetSummaryIncome()).ToString() + "元";
            //设置支出Tile的总支出金额
            SummaryExpenses = "总支出：" + (await Common.GetSummaryExpenses()).ToString() + "元";
            //计算月结余
            double mouthIncome = await Common.GetThisMouthSummaryIncome();
            double mouthExpenses = await Common.GetThisMouthSummaryExpenses();
            MouthBalance = "月结余：" + (mouthIncome - mouthExpenses).ToString() + "元";
            //计算年结余
            double yearIncome = await Common.GetThisYearSummaryIncome();
            double yearExpenses = await Common.GetThisYearSummaryExpenses();
            YearBalance = "年结余：" + (yearIncome - yearExpenses).ToString() + "元";
            //获取今日的账单记录，并绑定到首页的列表控件进行显示
            var items = await Common.GetThisDayAllRecords(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            XmlDocument tilexml = new XmlDocument();
            tilexml.LoadXml(File.ReadAllText("title.xml"));
            XmlNodeList str = tilexml.GetElementsByTagName("text");
            for (int i = 4; i < str.Count; i++)
            {
                ((XmlElement)str[i]).InnerText = SummaryIncome;
                i++;
                ((XmlElement)str[i]).InnerText = SummaryExpenses;
                i++;
                ((XmlElement)str[i]).InnerText = MouthBalance;
                i++;
                ((XmlElement)str[i]).InnerText = YearBalance;
            }
            TileNotification notifi = new TileNotification(tilexml);
            var update = TileUpdateManager.CreateTileUpdaterForApplication();
            update.Update(notifi);
            cvs1.Source = items;
        }
        //跳转到新增一笔收入页面
        private void Income_Tile_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddAccount), 0);
        }
        //跳转到新增一笔支出页面
        private void Expenses_Tile_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddAccount), 1);
        }
        //跳转到图表分析页面
        private void Chart_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ChartPage));
        }
        //跳转到月报表页面
        private void MouthReport_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MouthReport));
        }
        //跳转到年报表页面
        private void YearReport_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(YearReport));
        }
        //跳转到查询页面
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Search));
        }
        // 属性改变事件
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
        private void Mainpage_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            var def1 = args.Request.GetDeferral();
            DataPackage dp = new DataPackage();
            dp.Properties.Title = "共享文本";
            int i = n.Type;
            if (n.Money != 0)
            {
                    dp.Properties.Description = n.Category.ToString() + " " + n.Money.ToString() + "元 " + n.Desc.ToString() + " " + n.DT.ToString();
            }
            else
            {
                dp.Properties.Description = "You have not selected a bill.";
            }
            dp.SetText(n.Type.ToString());
            args.Request.Data = dp;
            def1.Complete();
        }
        private async void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            //var i = new MessageDialog(g).ShowAsync();
            data = await App.voucherHelper.Getdata();
            n = (dynamic)((MenuFlyoutItem)sender).DataContext;
            if (n.Money != 0)
            {
                App.voucherHelper.Remove(n);
                App.voucherHelper.SaveToFile();
                Frame.Navigate(typeof(MainPage), "");
            } else
            {
                var i = new MessageDialog("You have not selected a bill.").ShowAsync();
            }
        }

        private void MenuFlyoutItem_Click_1(object sender, RoutedEventArgs e)
        {
            n = (dynamic)((MenuFlyoutItem)sender).DataContext;
            DataTransferManager.ShowShareUI();
        }

        private void listToday_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (e.ClickedItem != null)
            //{
            //    n = (AccountBook.Voucher)(e.ClickedItem);
            //}
        }
    }
}
