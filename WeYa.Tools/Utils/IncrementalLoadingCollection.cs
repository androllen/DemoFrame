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

namespace WeYa.Tools.Utils
{
    public class IncrementalLoadingCollection<T> :
        BindableCollection<T>,
        IList, 
        ISupportIncrementalLoading
    {
        private readonly IVirtualisedDataSource<T> _dataSource;
        private int? _dataSourceCount;
        private bool _isLoading;

        public IncrementalLoadingCollection(IVirtualisedDataSource<T> dataSource)
        {
            _dataSource = dataSource;
            if (dataSource == null)
            {
                throw new ArgumentNullException("dataSource", "Data Source is required.");
            }
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

        private async Task EnsureDataSourceHasBeenCount()
        {
            if (!_dataSourceCount.HasValue)
            {
                _dataSourceCount = await _dataSource.GetCountAsync();
            }
        }

        private async Task<LoadMoreItemsResult> LoadMoreItemsFromDataSourceAsync(uint count)
        {
            var result = new LoadMoreItemsResult();
            _isLoading = true;

            try
            {
                await EnsureDataSourceHasBeenCount();

                var startIndex = (uint)Count;
                var itemsToAdd = await _dataSource.GetItemsAsync(startIndex, count);
                var itemsAddedCount = AddRange(itemsToAdd);

                _hasMoreItems = (_dataSourceCount > Count);

                result.Count = itemsAddedCount;
            }
            finally
            {
                _isLoading = false;
            }

            return result;
        }

        private bool _hasMoreItems = true;
        public bool HasMoreItems { get { return _hasMoreItems; } }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            if (_isLoading)
            {
                throw new InvalidOperationException();
            }
            return AsyncInfo.Run(token => LoadMoreItemsFromDataSourceAsync(count));
        }
    }
}
