/********************************************************************************
** 作者： androllen
** 日期： 16/4/12 19:15:40
** 微博： http://weibo.com/Androllen
** 来源： https://github.com/LanceMcCarthy/UwpProjects
** 关于： https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh780657.aspx
*********************************************************************************/
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Data;
using Caliburn.Micro;
using System.Collections;
using System.Threading;
using System.Collections.Generic;

namespace WeYa.Domain.Util
{
    public class IncrementalLoadingCollection<T> :
        BindableCollection<T>,
        IList, 
        ISupportIncrementalLoading
    {
        private readonly Func<CancellationToken, uint, Task<BindableCollection<T>>> func;
        private CancellationToken token;

        public bool IsLoaded { get; set; }
        public bool IsLoading { get; set; }

        private readonly int _dataSourceCount;

        public IncrementalLoadingCollection(Func<CancellationToken, uint, Task<BindableCollection<T>>> func)
        {
            this.func = func;
            _dataSourceCount = 10000;
        }

        private uint AddRange(BindableCollection<T> items)
        {
            uint count = 0;

            foreach (var item in items)
            {
                Add(item);
                ++count;
            }

            return count;
        }
        /// <summary>
        /// 加载更多
        /// IsLoading 作为标志位
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private async Task<LoadMoreItemsResult> LoadMoreItemsFromDataSourceAsync(CancellationToken passedToken, uint count)
        {
            var result = new LoadMoreItemsResult();
            IsLoading = true;
            this.token = passedToken;
            BindableCollection<T> tempList = null;

            try
            {
                var startIndex = (uint)Count;
                tempList = await func(passedToken, startIndex);
                var itemsAddedCount = AddRange(tempList);
                _hasMoreItems = (_dataSourceCount > Count);

                result.Count = itemsAddedCount;
            }
            finally
            {
                IsLoading = false;
            }

            return result;
        }

        private bool _hasMoreItems = true;
        public bool HasMoreItems
        {
            set { _hasMoreItems = value; }
            get { return _hasMoreItems; }
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            if (IsLoading)
            {
                throw new InvalidOperationException();
            }
            return AsyncInfo.Run(token => LoadMoreItemsFromDataSourceAsync(token, count));
        }
    }
}
