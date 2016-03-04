using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

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

    }
}
