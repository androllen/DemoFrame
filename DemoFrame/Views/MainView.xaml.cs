using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace DemoFrame.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainView
    {
        public MainView()
        {
            this.InitializeComponent();
            Loaded += MainShellView_Loaded;
        }

        private void MainShellView_Loaded(object sender, RoutedEventArgs e)
        {
            IoC.Get<INotifyFrameChanged>().Back2MainView += MainView_Back2MainView;
        }

        private void MainView_Back2MainView(object sender, int e)
        {
            switch (e)
            {
                case 0:
                    this.NavLinksList.SelectedIndex = 0;
                    break;
                case 1:
                    this.NavLinksList.SelectedIndex = 1;
                    break;
                case 2:
                    this.NavLinksList.SelectedIndex = 2;
                    break;
            }
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
    }
}
