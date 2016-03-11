using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Windows.UI.Xaml.Controls;

namespace DemoFrame
{
    public class PhoneFrameMgr :BaseFrame
    {
        private readonly WinRTContainer mcontainer;
        public PhoneFrameMgr(WinRTContainer container):base(container)
        {
            mcontainer = container;
        }
        public INavigationService MainNavService { get; private set; }
        public INavigationService RootNavService { get; private set; }
        public INavigationService ContentNavService { get; private set; }
        public override void onBackKeyPressed()
        {

        }

        public override INavigationService ContentNavService(Frame frame)
        {
            return ContentNavService;
        }

        public override INavigationService MainNavService(Frame frame)
        {
            throw new NotImplementedException();
        }


        public override INavigationService RightNavService(Frame frame)
        {
            throw new NotImplementedException();
        }
        
    }
}
