/********************************************************************************
** 作者： androllen
** 日期： 16/4/28 14:06:33
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeYa.Tools.Utils
{
    public interface IVirtualisedDataSource<T>
    {
        Task<int> GetCountAsync();
        Task<ObservableCollection<T>> GetItemsAsync(uint startIndex, uint count);
    }
}
