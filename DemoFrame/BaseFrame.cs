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
        public INavigationService MainNavigationService { get; private set; }
        public INavigationService ContentNavigationService { get; private set; }
        public INavigationService PhoneNavigationService { get; private set; }

        public abstract void OnBackKeyPressed();
        public abstract void CategoryNavService<T>();

        protected abstract void OnDesktopContentGoBack();
        protected abstract void OnDesktopMainGoBack();
        protected abstract void OnPhoneGoBack();

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
                MainNavigationService = new FrameAdapter(value);
                _container.RegisterInstance(typeof(INavigationService), "MainFrame", MainNavigationService);
                MainNavigationService.Navigated += (s, e) => OnDesktopMainGoBack();
                _mainFrame = value;
            }
        }
        private Frame _contentFrame;
        public Frame ContentFrame
        {
            get { return _contentFrame; }
            set
            {
                ContentNavigationService = new FrameAdapter(value);
                _container.RegisterInstance(typeof(INavigationService), "ContentFrame", ContentNavigationService);
                _contentFrame = value;
                ContentNavigationService.Navigated += (s, e) => OnDesktopContentGoBack();
            }
        }

        public void PhoneFrame(Frame frame)
        {
            PhoneNavigationService = _container.RegisterNavigationService(frame);
            PhoneNavigationService.Navigated += (s, e) => OnPhoneGoBack();
        }

        protected virtual void OnBackKeyPressing(BackRequestedEventArgs args)
        {
            BackKeyPressing?.Invoke(this, args);
        }

    }
}
