using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace DemoFrame
{
    public class PhoneFrameMgr :BaseFrame
    {
        private readonly WinRTContainer mcontainer;
        public PhoneFrameMgr(WinRTContainer container):base(container)
        {
            mcontainer = container;
        }

        public override void onBackKeyPressed()
        {
         
        }
    }
}
