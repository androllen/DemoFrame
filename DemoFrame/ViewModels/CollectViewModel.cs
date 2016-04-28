/********************************************************************************
** 作者： androllen
** 日期： 16/4/12 19:15:40
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using Caliburn.Micro;

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
