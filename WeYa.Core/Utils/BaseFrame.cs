/********************************************************************************
** 作者： androllen
** 日期： 16/4/12 19:15:40
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Linq;
using Caliburn.Micro;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace WeYa.Core
{
    public abstract class BaseFrame : INotifyFrameChanged
    {
        public event EventHandler<BackRequestedEventArgs> BackKeyPressing;
        public event EventHandler<int> Back2MainView;

        public INavigationService MainNavigationService { get; private set; }
        public INavigationService ContentNavigationService { get; private set; }
        public INavigationService PhoneNavigationService { get; private set; }

        public abstract void OnBackKeyPressed();
        protected abstract void OnDesktopContentGoBack();
        protected abstract void OnDesktopMainGoBack();
        protected abstract void OnPhoneGoBack();
        public abstract bool IsHasContent();

        protected virtual void UpdateMainBackButton() { }
        protected virtual void UpdateContentBackButton() { }
        protected virtual void UpdatePhoneBackButton() { }

        protected readonly WinRTContainer _container;

        public BaseFrame(WinRTContainer container)
        {
            _container = container;
        }

        private Frame _mainFrame;
        public Frame MainFrame
        {
            get { return _mainFrame; }
            set
            {
                if (MainNavigationService == null)
                {
                    MainNavigationService = new FrameAdapter(value);
                    _container.RegisterInstance(typeof(INavigationService), "MainFrame", MainNavigationService);
                    MainNavigationService.Navigated += (s, e) => UpdateMainBackButton();
                    _mainFrame = value;
                }
            }
        }
        private Frame _contentFrame;
        public Frame ContentFrame
        {
            get { return _contentFrame; }
            set
            {
                if (ContentNavigationService == null)
                {

                    ContentNavigationService = new CachingFrameAdapter(value);
                    _container.RegisterInstance(typeof(INavigationService), "ContentFrame", ContentNavigationService);
                    _contentFrame = value;
                    ContentNavigationService.Navigated += (s, e) => UpdateContentBackButton();
                }
            }
        }

        private Frame _phoneFrame;
        public Frame PhoneFrame
        {
            get
            {
                return _phoneFrame;
            }

            set
            {
                if (PhoneNavigationService == null)
                {
                    _phoneFrame = value;
                    PhoneNavigationService = _container.RegisterNavigationService(_phoneFrame);
                    PhoneNavigationService.Navigated += (s, e) => UpdatePhoneBackButton();
                }
            }
        }

        public void OnPhoneFrame(Frame frame)
        {
            PhoneFrame = frame;
        }

        protected virtual void OnBackKeyPressing(BackRequestedEventArgs args)
        {
            BackKeyPressing?.Invoke(this, args);
        }
        protected virtual void OnBack2MainView(int Index)
        {
            Back2MainView?.Invoke(this, Index);
        }
        public void ClearPivotItemView(Action<INavigationService> action, int Index)
        {
            action(MainNavigationService);
            while (ContentNavigationService.BackStack.Count > 0)
            {
                OnDesktopContentGoBack();
            }
            while (MainNavigationService.BackStack.Count > 1)
            {
                MainNavigationService.BackStack.RemoveAt(1);
            }
            if (MainNavigationService.CurrentSourcePageType != MainNavigationService.BackStack.First().SourcePageType)
                UpdateMainBackButton();
            else
                OnDesktopMainGoBack();

            OnBack2MainView(Index);
        }

        public void Go2ContentView(Action<INavigationService> action)
        {
            action(ContentNavigationService);
            UpdateContentBackButton();
        }

    }
}
