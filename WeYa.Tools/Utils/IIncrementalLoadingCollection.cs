/********************************************************************************
** 作者： androllen
** 日期： 16/4/28 14:05:14
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace WeYa.Tools.Utils
{
    public interface IIncrementalLoadingCollection<T> :
        IVirtualisedCollection<T>,
        ISupportIncrementalLoading
    {
    }
}
