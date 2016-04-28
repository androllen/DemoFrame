/********************************************************************************
** 作者： androllen
** 日期： 16/4/12 19:15:40
** 微博： http://weibo.com/Androllen
*********************************************************************************/
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
