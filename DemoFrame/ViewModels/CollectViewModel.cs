using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFrame.ViewModels
{
    public class CollectViewModel : BaseViewModel
    {
        public CollectViewModel(INotifyFrameChanged frame)
            : base(frame)
        {
        }
        public void ShowClickItem()
        {
            _frame.Go2ContentView(ContentNavigationService =>
            {
                ContentNavigationService.For<ShellViewModel>()
                  .Navigate();
            });

        }
    }
}
