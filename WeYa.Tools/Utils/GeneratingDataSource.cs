/********************************************************************************
** 作者： androllen
** 日期： 16/4/28 14:02:37
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeYa.Domain.Models;

namespace WeYa.Tools.Utils
{
    public class GeneratingDataSource : IVirtualisedDataSource<IncrementedItem>
    {
        private readonly int _count;

        public GeneratingDataSource(int count = 1000000)
        {
            _count = count;
        }

        public Task<int> GetCountAsync()
        {
            return Task.FromResult(_count);
        }

        public Task<ObservableCollection<IncrementedItem>> GetItemsAsync(uint startIndex, uint count)
        {
            return Task.Run(() =>
            {
                var items = new ObservableCollection<IncrementedItem>();

                for (int i = (int)startIndex; i < count+ startIndex; i++)
                {
                    items.Add(new IncrementedItem { Id = i, Title = "https://ss0.bdstatic.com/5aV1bjqh_Q23odCf/static/superman/img/logo/logo_white_fe6da1ec.png" });
                }

                return items;
            });
        }

    }
}
