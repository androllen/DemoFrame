using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Windows.UI.Xaml.Controls;

namespace DemoFrame.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        public ShellViewModel(INotifyFrameChanged frame) 
            : base(frame)
        {
        }

        public void ShowDevices()
        {
            _frame.Go2ContentView(ContentNavigationService =>
            {
                ContentNavigationService.For<ContentViewModel>().Navigate();
            });

        }

    }
}
