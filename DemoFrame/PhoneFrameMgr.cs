using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Windows.UI.Xaml.Controls;
using Windows.UI.Core;

namespace DemoFrame
{
    public class PhoneFrameMgr : BaseFrame
    {
        private readonly IFrameMgr _framemgr;
        public PhoneFrameMgr(WinRTContainer container, IFrameMgr framemgr)
            : base(container)
        {
            _framemgr = framemgr;
            SystemNavigationManager.GetForCurrentView().BackRequested += FrameManager_BackRequested;

        }
        private void FrameManager_BackRequested(object sender, BackRequestedEventArgs e)
        {
            OnBackKeyPressing(e);
            if (!e.Handled)
            {
                OnBackKeyPressed();
            }

            e.Handled = true;
        }
        protected override void OnDesktopContentGoBack()
        {
            if (ContentNavigationService.CanGoBack)
            {
                ContentNavigationService.GoBack();
            }
        }
        protected override void OnDesktopMainGoBack()
        {
            if (MainNavigationService.CanGoBack)
            {
                MainNavigationService.GoBack();
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = MainNavigationService.CanGoBack
                    ? AppViewBackButtonVisibility.Visible
                    : AppViewBackButtonVisibility.Collapsed;

            }
        }
        protected override void OnPhoneGoBack()
        {

        }

        public override void OnBackKeyPressed()
        {
            if (PhoneNavigationService != null)
            {

            }
            else
            {
                if (MainNavigationService != null && ContentNavigationService != null)
                {
                    if (ContentNavigationService.CanGoBack&& MainNavigationService.CanGoBack)
                    {
                        OnDesktopContentGoBack();

                        SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = 
                            AppViewBackButtonVisibility.Visible;
                    }
                    else
                    {
                        OnDesktopMainGoBack();
                    }


                }
            }
        }

        public override void CategoryNavService<T>()
        {
            Type t = typeof(T);

        }
    }
}
