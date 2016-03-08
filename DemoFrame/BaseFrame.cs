using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace DemoFrame
{
    public class BaseFrame : INotifyFrameChanged
    {
        public INavigationService LeftNavService { get; }
        public Frame LeftPageFrame { get; set; }
        public INavigationService MainNavService { get; }
        public Frame MainPageFrame { get; set; }
        public INavigationService RightNavService { get; }
        public Frame RightPageFrame { get; set; }

        public event EventHandler<BackRequestedEventArgs> BackKeyPressing;
        public event EventHandler NotifyLeftFramePage;
        public event EventHandler NotifyRightFramePage;

        public void onBackKeyPressed()
        {

        }
    }
}
