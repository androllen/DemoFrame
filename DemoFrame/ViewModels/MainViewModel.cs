using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using WeYa.Core.Extends;
using WeYa.Domain;

namespace DemoFrame.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<NavLink> _navLinks = new ObservableCollection<NavLink>()
        {
            new NavLink() { Label = "首页", Symbol = Symbol.People},
            new NavLink() { Label = "收藏", Symbol = Symbol.Globe},
            new NavLink() { Label = "下载", Symbol = Symbol.Message},
            new NavLink() { Label = "关于", Symbol = Symbol.Delete },
            new NavLink() { Label = "设置", Symbol = Symbol.Mail }
        };
        public ObservableCollection<NavLink> NavLinks
        {
            get { return _navLinks; }
        }
        protected readonly WinRTContainer _container;
        private int _index;
        public int SelectedIndex
        {
            get { return _index; }
            set
            {
                if (_index != value)
                {
                    _index = value;
                    NotifyOfPropertyChange(nameof(SelectedIndex));
                }
            }
        }
        protected override void OnActivate()
        {
            base.OnActivate();
        }
        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
        }

        public MainViewModel(WinRTContainer container, INotifyFrameChanged frame) 
            : base(frame)
        {
            _container = container;
            SelectedIndex = 0;
        }
        public void ListViewItemClick(ItemClickEventArgs args)
        {
            var categoryInfo = (NavLink)args.ClickedItem;
            switch (categoryInfo.Label)
            {
                case "首页":
                    {
                        _frame.ClearPivotItemView(mainService => 
                        {
                            mainService.For<InitMainViewModel>().WithParam(vm => vm.Title, categoryInfo.Label).Navigate();
                        }, 0);
                    }
                    break;
                case "收藏":
                    {
                        _frame.ClearPivotItemView(mainService =>
                        {
                            mainService.For<CollectViewModel>().WithParam(vm => vm.Title, categoryInfo.Label).Navigate();
                        }, 1);
                    }
                    break;
                case "下载":
                    {
                        _frame.ClearPivotItemView(mainService =>
                        {
                            mainService.For<DownloadViewModel>().WithParam(vm => vm.Title, categoryInfo.Label).Navigate();
                        }, 2);
                    }
                    break;
                case "关于":
                    {
                        _frame.MainNavigationService.For<AboutViewModel>()
                          .WithParam(vm => vm.Title, categoryInfo.Label)
                          .Navigate();
                    }
                    break;
                case "设置":
                    {
                        _frame.MainNavigationService.For<SettingViewModel>()
                          .WithParam(vm => vm.Title, categoryInfo.Label)
                          .Navigate();
                    }
                    break;
            }
        }
        public void SetupPhoneNavigationService(Frame frame)
        {
            _frame.PhoneFrame(frame);
        }

        public void SetupDesktopMainNavigationService(Frame frame)
        {
            _frame.MainFrame= frame;
            _frame.MainNavigationService.For<InitMainViewModel>().WithParam(vm => vm.Title, "首页").Navigate();
        }
        public void SetupDesktopContentNavigationService(Frame frame)
        {
            _frame.ContentFrame= frame;
            _frame.ContentNavigationService.For<InitContentViewModel>().Navigate();
        }

        public void TitleClick(ItemClickEventArgs e)
        {
            NavLink link = e.ClickedItem as NavLink;
            //_frame.MainNavigationService.GoTo<MainViewModel>();
        }

        public void onBackKeyPressed()
        {

        }
    }
}
