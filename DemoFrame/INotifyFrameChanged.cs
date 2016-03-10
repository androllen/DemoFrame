﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace DemoFrame
{
    public interface INotifyFrameChanged
    {
        /// <summary>
        ///  当注册页面启动的时候发起
        /// </summary>
        event EventHandler<bool> NotifyLeftFramePage;
        /// <summary>
        /// 当注册页面结束的时候发起
        /// </summary>
        event EventHandler NotifyRightFramePage;

        event EventHandler<BackRequestedEventArgs> BackKeyPressing;
    }
}
