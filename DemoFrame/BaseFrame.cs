using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace DemoFrame
{
    public abstract class BaseFrame : INotifyFrameChanged
    {
        public event EventHandler<BackRequestedEventArgs> BackKeyPressing;
        public event EventHandler NotifyLeftFramePage;
        public event EventHandler NotifyRightFramePage;


    }
}
