using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Windows.UI.Xaml.Controls;

namespace DemoFrame.ViewModels
{
    public class ShellViewModel : Screen
    {
        private INavigationService _navigationService;
        private readonly WinRTContainer _container;

        public ShellViewModel(WinRTContainer container)
        {
            _container = container;
        }
        protected override void OnInitialize()
        {
            base.OnInitialize();
        }
        protected override void OnActivate()
        {
            base.OnActivate();
        }
        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(true);
        }

        public void SetupNavigationService(Frame frame)
        {
            _navigationService = _container.RegisterNavigationService(frame);

        }

        public void ShowDevices()
        {
            _navigationService.For<ShellViewModel>().Navigate();
        }

    }
}
