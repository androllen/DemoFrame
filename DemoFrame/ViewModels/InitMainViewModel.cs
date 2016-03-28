using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace DemoFrame.ViewModels
{
    public class InitMainViewModel : BaseViewModel
    {
        private string _title;
        public override string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    NotifyOfPropertyChange(nameof(Title));
                }
            }
        }

        public InitMainViewModel(INotifyFrameChanged frame)
            : base(frame)
        {
        }
        public void ShowClickItem()
        {
            _frame.ContentNavigationService.For<AboutViewModel>()
            //_frame.MainNavigationService.For<InitMainViewModel>()
              .WithParam(vm => vm.Title, "关于")
              .Navigate();
        }
    }
}
