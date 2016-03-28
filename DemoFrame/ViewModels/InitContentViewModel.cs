using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFrame.ViewModels
{
    public class InitContentViewModel : BaseViewModel
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

        public InitContentViewModel(INotifyFrameChanged frame) 
            : base(frame)
        {
        }
        public void ShowClickItem()
        {
            //_frame.ContentNavigationService.For<AboutViewModel>().Navigate();
            //_frame.MainNavigationService.For<InitMainViewModel>()
            //  .WithParam(vm => vm.Title, categoryInfo.Label)
            //  .Navigate();
        }
    }
}
