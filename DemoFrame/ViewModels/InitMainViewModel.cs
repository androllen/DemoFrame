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
using WeYa.Domain.Models;

namespace DemoFrame.ViewModels
{
    public class InitMainViewModel : BaseViewModel
    {
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

            var dataSource = new GeneratingDataSource();
            InfiniteItems = new IncrementalLoadingCollection<IncrementedItem>(dataSource);
        }

    }
}
