/********************************************************************************
** 作者： androllen
** 日期： 16/4/28 14:05:48
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeYa.Tools.Utils
{
    public interface IVirtualisedCollection<T> :
        IList<T>,
        IList,
        INotifyCollectionChanged,
        INotifyPropertyChanged
    {
    }
}
