using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace DemoFrame
{
    interface INotifyFrameChanged
    {
        /// <summary>
        ///  当注册页面启动的时候发起
        /// </summary>
        event EventHandler NotifyLeftFramePage;
        /// <summary>
        /// 当注册页面结束的时候发起
        /// </summary>
        event EventHandler NotifyRightFramePage;

        event EventHandler<BackRequestedEventArgs> BackKeyPressing;
    }
}
