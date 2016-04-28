/********************************************************************************
** 作者： androllen
** 日期： 16/4/12 19:15:40
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using Windows.UI.Xaml.Controls;

namespace WeYa.Domain
{
    public class NavLink : BaseModel
    {
        private string label;
        public string Label
        {
            get { return label; }
            set { SetProperty(ref label, value); }
        }


        private Symbol sysbol;
        public Symbol Symbol
        {
            get { return sysbol; }
            set { SetProperty(ref sysbol, value); }
        }
    }
}
