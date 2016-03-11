using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DemoFrame.model;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Core;

namespace DemoFrame.ViewModels
{
    public class MainViewModel : Screen
    {
        private ObservableCollection<NavLink> _navLinks = new ObservableCollection<NavLink>()
        {
            new NavLink() { Label = "People", Symbol = Windows.UI.Xaml.Controls.Symbol.People  ,PageItem="DemoFrame.View.MoreInfoPage"},
            new NavLink() { Label = "Globe", Symbol = Windows.UI.Xaml.Controls.Symbol.Globe ,PageItem="DemoFrame.View.MyFriendPage"},
            new NavLink() { Label = "Message", Symbol = Windows.UI.Xaml.Controls.Symbol.Message ,PageItem="DemoFrame.View.MyInfoPage"},
            //new NavLink() { Label = "Mail", Symbol = Windows.UI.Xaml.Controls.Symbol.Mail ,PageItem="DemoFrame.View.MoreInfoPage"},
        };
        public ObservableCollection<NavLink> NavLinks
        {
            get { return _navLinks; }
        }
        protected readonly INotifyFrameChanged _frame;
        protected readonly WinRTContainer _container;
        private INavigationService _navigationService;


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

        public void SetupPhoneFrameNavigationService(Frame frame)
        {
            //_navigationService = new FrameAdapter(frame);
            //_navigationService = _container.RegisterNavigationService(frame);
            _frame.CenterNavService = new FrameAdapter(frame);
            MainNavService = new FrameAdapter(frame);
            _container.RegisterInstance(typeof(INavigationService), "mainFrame", MainNavService);
        }
        public void SetupDesktopRootNavigationService(Frame frame)
        {
            //_navigationService = new FrameAdapter(frame);
            //_navigationService = _container.RegisterNavigationService(frame);
            MainNavService = new FrameAdapter(frame);
            _container.RegisterInstance(typeof(INavigationService), "rootFrame", RootNavService);
        }
        public void SetupDesktopContentNavigationService(Frame frame)
        {
            //_navigationService = new FrameAdapter(frame);
            //_navigationService = _container.RegisterNavigationService(frame);
            MainNavService = new FrameAdapter(frame);
            _container.RegisterInstance(typeof(INavigationService), "contentFrame", ContentNavService);
        }

        public void TitleClick(ItemClickEventArgs e)
        {
            NavLink link = e.ClickedItem as NavLink;

        }

        public void onBackKeyPressed()
        {
          
        }
    }
}
