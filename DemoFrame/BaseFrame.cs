using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using DemoFrame.ViewModels;

namespace DemoFrame
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

        public void PhoneFrame(Frame frame)
        {
            PhoneNavigationService = _container.RegisterNavigationService(frame);
            PhoneNavigationService.Navigated += (s, e) => UpdatePhoneBackButton();
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
