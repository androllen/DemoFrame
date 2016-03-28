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
    public class MainViewModel : Screen
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
        protected readonly INotifyFrameChanged _frame;
        protected readonly WinRTContainer _container;

        protected override void OnActivate()
        {
            base.OnActivate();
        }
        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
        }

        public MainViewModel(WinRTContainer container, INotifyFrameChanged frame)
        {
            _container = container;
            _frame = frame;
        }
        public void ListViewItemClick(ItemClickEventArgs args)
        {
            var categoryInfo = (NavLink)args.ClickedItem;
            switch (categoryInfo.Label)
            {
                case "首页":
                    _frame.MainNavigationService.For<CategoryDetailViewModel>()
                          .WithParam(vm => vm.Title, categoryInfo.Label)
                          .Navigate();
                    break;
                case "收藏":
                    {
                        _frame.MainNavigationService.For<CollectViewModel>()
                          .WithParam(vm => vm.Title, categoryInfo.Label)
                          .Navigate();
                    }
                    break;
                case "下载":
                    {
                        _frame.MainNavigationService.For<DownloadViewModel>()
                          .WithParam(vm => vm.Title, categoryInfo.Label)
                          .Navigate();
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
            _frame.MainNavigationService.For<InitMainViewModel>().Navigate();
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
