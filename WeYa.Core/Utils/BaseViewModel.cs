/********************************************************************************
** 作者： androllen
** 日期： 16/4/12 19:15:40
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using Caliburn.Micro;

namespace WeYa.Core
{
    public abstract class BaseViewModel : Screen
    {
        public virtual string Title { get; set; }
        protected readonly INotifyFrameChanged _frame;

        public BaseViewModel(INotifyFrameChanged frame)
        {
            _frame = frame;

        }

    }
}
