using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

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

        public INavigationService ContentFrame(Frame frame)
        {
            ContentNavigationService = _container.RegisterNavigationService(frame);
            return ContentNavigationService;
        }
        public INavigationService MainFrame(Frame frame)
        {
            MainNavigationService = _container.RegisterNavigationService(frame);
            return MainNavigationService;
        }
        public INavigationService PhoneFrame(Frame frame)
        {
            PhoneNavigationService = _container.RegisterNavigationService(frame);
            return PhoneNavigationService;
        }

        protected virtual void OnBackKeyPressing(BackRequestedEventArgs args)
        {
            BackKeyPressing?.Invoke(this, args);
        }

    }
}
