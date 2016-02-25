using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DemoFrame.model;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace DemoFrame
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<NavLink> _navLinks = new ObservableCollection<NavLink>()
        {
            new NavLink() { Label = "People", Symbol = Windows.UI.Xaml.Controls.Symbol.People  ,PageItem="DemoFrame.View.MoreInfoPage"},
            new NavLink() { Label = "Globe", Symbol = Windows.UI.Xaml.Controls.Symbol.Globe ,PageItem="DemoFrame.View.MyFriendPage"},
            new NavLink() { Label = "Message", Symbol = Windows.UI.Xaml.Controls.Symbol.Message ,PageItem="DemoFrame.View.MyInfoPage"},
            //new NavLink() { Label = "Mail", Symbol = Windows.UI.Xaml.Controls.Symbol.Mail ,PageItem="DemoFrame.View.MoreInfoPage"},
        };
        public ObservableCollection<NavLink> NavLinks
        {
            get { return _navLinks; }
        }

        public MainPage()
        {
            this.InitializeComponent();
        }
        bool isOpen = false;
        private void splitViewToggle_Click(object sender, RoutedEventArgs e)
        {
            if (!isOpen)
            {
                splitView.IsPaneOpen = true;
                isOpen = true;
            }
            else
            {
                splitView.IsPaneOpen = false;
                isOpen = false;
            }
        }
        private void headerRoot_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double gap = e.NewSize.Width;
            System.Diagnostics.Debug.WriteLine("Width :" + gap.ToString());
            if (gap >= 800.0)
            {
                isOpen = true;
            }
        }
        private void NavLinksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void myContentPanel_Loaded(object sender, RoutedEventArgs e)
        {
            //HelpControl help = new HelpControl();
            //myContentPanelFrame.Content = help;
        }
        private void NavLinksList_ItemClick(object sender, ItemClickEventArgs e)
        {
            NavLink link = e.ClickedItem as NavLink;
            myContentPanel.Children.Clear();
            if (link.Label == "People")
            {
                //TextBlock tet = new TextBlock();
                //tet.Foreground = new SolidColorBrush(Colors.Orange);
                //tet.FontSize = 23;
                //tet.Text = "1111111111111111111111111111111111";
                //MyInfoPage info = new MyInfoPage();
                //myContentPanel.Children.Add(info);
            }
            else if (link.Label == "Message")
            {
                //TextBlock tet = new TextBlock();
                //tet.Foreground = new SolidColorBrush(Colors.Orange);
                //tet.FontSize = 23;
                //tet.Text = "2222222222222222222222222222222222";
                //MyFriendPage info = new MyFriendPage();

                //myContentPanel.Children.Add(info);

            }
            else if (link.Label == "Globe")
            {
                //TextBlock tet = new TextBlock();
                //tet.Foreground = new SolidColorBrush(Colors.Orange);
                //tet.FontSize = 23;
                //tet.Text = "333333333333333333333333333333333333";
                //MoreInfoPage info = new MoreInfoPage();

                //myContentPanel.Children.Add(info);

            }
        }
    }
}
