using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Windows.UI.Xaml.Controls;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace DemoFrame
{
    public class PhoneFrameMgr : BaseFrame
    {
        private SystemNavigationManager systemNavigationManager;
        private bool _readyToExit;

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
            if (PhoneNavigationService.CanGoBack)
            {
                PhoneNavigationService.GoBack();
            }
        }

        protected override void OnDesktopMainGoBack()
        {
            if (MainNavigationService.CanGoBack)
            {
                MainNavigationService.GoBack();
            }

        }

        protected override void OnDesktopContentGoBack()
        {
            if (ContentNavigationService.CanGoBack)
            {
                ContentNavigationService.GoBack();
            }
        }
        protected override void OnPhoneGoBack()
        {
            if (PhoneNavigationService.CanGoBack)
            {
                PhoneNavigationService.GoBack();
            }
            systemNavigationManager.AppViewBackButtonVisibility =
                this.PhoneNavigationService.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
        }

        public override void OnBackKeyPressed()
        {
            if (PhoneNavigationService != null)
            {
                if (PhoneNavigationService.BackStack.Count > 0 &&
                    PhoneNavigationService.BackStack.First().SourcePageType != PhoneNavigationService.CurrentSourcePageType)
                {
                    while (PhoneNavigationService.BackStack.Count > 1)
                    {
                        PhoneNavigationService.BackStack.RemoveAt(1);
                    }
                    UpdatePhoneBackButton();
                    OnBack2MainView(0);
                }
                else
                {
                    if (_readyToExit)
                    {
                        Application.Current.Exit();
                    }
                    else
                    {
                        var toast = new CCUWPToolkit.Controls.WYToastDialog();
                        toast.ShowAsync("再按一次退出App",()=> 
                        {
                            _readyToExit = false;
                        });
                        _readyToExit = true;
                    }
                }
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
                        OnBack2MainView(0);
                    }


                }
            }
        }
        protected override void OnBack2MainView(int Index)
        {
            base.OnBack2MainView(Index);
        }
    }
}
