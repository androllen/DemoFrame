/********************************************************************************
** 作者： androllen
** 日期： 16/4/12 19:15:40
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System.Linq;
using Caliburn.Micro;
using Windows.UI.Xaml.Controls;
using Windows.UI.Core;
using Windows.UI.Xaml;
using CCUWPToolkit.Controls;
using System;

namespace WeYa.Core
{
    public class PhoneFrameMgr : BaseFrame
    {
        private SystemNavigationManager systemNavigationManager;
        private bool _readyToExit;
        private bool _isHas=false;
        public PhoneFrameMgr(WinRTContainer container)
            : base(container)
        {
            this.systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            systemNavigationManager.BackRequested += FrameManager_BackRequested;
        }

        public override bool IsHasContent()
        {
            return _isHas;
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

            _isHas = bs_Count > 0 ? true : false;

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
                        var toast = new WYToastDialog();
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
