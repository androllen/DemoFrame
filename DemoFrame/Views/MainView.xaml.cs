﻿using System;
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