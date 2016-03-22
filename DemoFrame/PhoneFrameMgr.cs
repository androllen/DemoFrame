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
        public PhoneFrameMgr(WinRTContainer container):base(container)
        {
        
        }

        public override void onBackKeyPressed()
        {

        }

  
    }
}
