/********************************************************************************
** 作者： androllen
** 日期： 16/4/12 19:15:40
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System.Threading.Tasks;
using Caliburn.Micro;
using WeYa.Tools.Utils;
using System.Collections.ObjectModel;
using Windows.ApplicationModel;

namespace DemoFrame.ViewModels
{
    public class InitMainViewModel : BaseViewModel
    {
        private int currentPage = 1;
        public IncrementalLoadingCollection<IncrementedItem> InfiniteItems { get; set; }

        private string _title;
        public override string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    NotifyOfPropertyChange(()=> Title);
                }
            }
        }  

        public InitMainViewModel(INotifyFrameChanged frame) 
            : base(frame)
        {
            InitializeData();

        }
        protected override void OnActivate()
        {
            base.OnActivate();
        }
        protected override void OnInitialize()
        {
            base.OnInitialize();

        }
        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

        }
        private void InitializeData()
        {
            if (DesignMode.DesignModeEnabled)
                return;

            //when instantiating the collection, you pass it the task that gets more item, in this case it's "GetMoreData"
            //NOTE: This is for infinite items. if you have a max or total count, use the overload and pass the total as the 2nd parameter
            InfiniteItems = new IncrementalLoadingCollection<IncrementedItem>((cancellationToken, count) => Task.Run(GetMoreData, cancellationToken));
            //InfiniteItems = new IncrementalLoadingCollection<IncrementedItem>((cancellationToken, count) => Task.Run(GetMoreData, cancellationToken), 150,(isha)=>Task.Run(getMoreOver));
            //InfiniteItems = new IncrementalLoadingCollection<IncrementedItem>((cancellationToken, count) => Task.Run(GetMoreData, cancellationToken), 450, () =>
            //{
            //    System.Diagnostics.Debug.WriteLine("sss");
            //});
        }

        private async Task<ObservableCollection<IncrementedItem>> GetMoreData()
        {
            //I'm just simulating an API that supports paging
            return await FakeApiCallAsync(currentPage++, 25);
        }

        //Super Awesome API :D
        private async Task<ObservableCollection<IncrementedItem>> FakeApiCallAsync(int pageNumber, int itemsPerPage)
        {
            return await Task.Run(() =>
            {
                var items = new ObservableCollection<IncrementedItem>();

                var startingRecordToUse = itemsPerPage * (pageNumber - 1);
                var endingRecordToUse = startingRecordToUse + itemsPerPage;

                for (int i = startingRecordToUse; i < endingRecordToUse; i++)
                {
                    items.Add(new IncrementedItem { Id = i, Title = $"Item {i}" });
                }

                return items;
            });
        }

        public class IncrementedItem
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }
    }
}
