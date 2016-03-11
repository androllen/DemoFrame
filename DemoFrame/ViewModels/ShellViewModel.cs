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
        private readonly INavigationService _navigationService;

        public ShellViewModel(INavigationService container)
        {
            _navigationService = container;
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
            //_navigationService = _container.RegisterNavigationService(frame);

        }

        public void ShowDevices()
        {
            _navigationService.For<MainViewModel>().Navigate();
        }

    }
}
