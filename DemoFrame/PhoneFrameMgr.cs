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
        SystemNavigationManager systemNavigationManager;

        public PhoneFrameMgr(WinRTContainer container)
            : base(container)
        {
            this.systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            systemNavigationManager.BackRequested += FrameManager_BackRequested;
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

        protected override void UpdateMainBackButton()
        {
            systemNavigationManager.AppViewBackButtonVisibility =
                this.MainNavigationService.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
        }

        protected override void UpdateContentBackButton()
        {
            int bs_Count = this.ContentNavigationService.BackStack.Count;
            int fs_Count= this.ContentNavigationService.ForwardStack.Count;

            systemNavigationManager.AppViewBackButtonVisibility =
                this.ContentNavigationService.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
        }

        protected override void UpdatePhoneBackButton()
        {
            systemNavigationManager.AppViewBackButtonVisibility =
                this.PhoneNavigationService.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
        }


        protected override void OnDesktopContentGoBack()
        {
            if (ContentNavigationService.CanGoBack)
            {
                ContentNavigationService.GoBack();
            }
            systemNavigationManager.AppViewBackButtonVisibility = ContentNavigationService.CanGoBack
                ? AppViewBackButtonVisibility.Visible
                : AppViewBackButtonVisibility.Collapsed;

        }
        protected override void OnDesktopMainGoBack()
        {
            if (MainNavigationService.CanGoBack)
            {
                MainNavigationService.GoBack();
            }
            systemNavigationManager.AppViewBackButtonVisibility = MainNavigationService.CanGoBack
                ? AppViewBackButtonVisibility.Visible
                : AppViewBackButtonVisibility.Collapsed;
        }
        protected override void OnPhoneGoBack()
        {
            if (PhoneNavigationService.CanGoBack)
            {
                PhoneNavigationService.GoBack();
            }
            systemNavigationManager.AppViewBackButtonVisibility = PhoneNavigationService.CanGoBack
                ? AppViewBackButtonVisibility.Visible
                : AppViewBackButtonVisibility.Collapsed;
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
                    if (ContentNavigationService.CanGoBack)
                    {
                        OnDesktopContentGoBack();
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
            //MainNavigationService.Navigate(typeof(T));
            MainNavigationService.Navigate<T>();
        }
    }
}
