using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DemoFrame.model;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using WeYa.Core.Extends;

namespace DemoFrame.ViewModels
{
    public class MainViewModel : Screen
    {
        private ObservableCollection<NavLink> _navLinks = new ObservableCollection<NavLink>()
        {
            new NavLink() { Label = "People", Symbol = Windows.UI.Xaml.Controls.Symbol.People  ,PageItem="DemoFrame.View.MoreInfoPage"},
            new NavLink() { Label = "Globe", Symbol = Windows.UI.Xaml.Controls.Symbol.Globe ,PageItem="DemoFrame.View.MyFriendPage"},
            new NavLink() { Label = "Message", Symbol = Windows.UI.Xaml.Controls.Symbol.Message ,PageItem="DemoFrame.View.MyInfoPage"},
            new NavLink() { Label = "Mail", Symbol = Windows.UI.Xaml.Controls.Symbol.Mail ,PageItem="DemoFrame.View.MoreInfoPage"}
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
                case "People":
                    _frame.MainNavigationService.For<CategoryDetailViewModel>()
                          .WithParam(vm => vm.Title, categoryInfo.Label)
                          .Navigate();
                    break;
                case "Globe":
                    {
                        _frame.MainNavigationService.For<CategoryDetailViewModel>()
                          .WithParam(vm => vm.Title, categoryInfo.Label)
                          .Navigate();
                    }
                    break;
                case "Message":
                    {
                        _frame.MainNavigationService.For<CategoryDetailViewModel>()
                          .WithParam(vm => vm.Title, categoryInfo.Label)
                          .Navigate();
                    }
                    break;
                case "Mail":
                    {
                        _frame.MainNavigationService.For<CategoryDetailViewModel>()
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
            _frame.MainFrame(frame);
            //_frame.MainNavigationService.For<MainViewModel>().Navigate();
        }
        public void SetupDesktopContentNavigationService(Frame frame)
        {
            _frame.ContentFrame(frame);
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
