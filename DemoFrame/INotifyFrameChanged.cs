using Caliburn.Micro;
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
        event EventHandler<BackRequestedEventArgs> BackKeyPressing;
        /// <summary>
        /// 处理分类信息
        /// 1.导航
        /// 2.清除所有的frame
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        void CategoryNavService<T>();

        INavigationService MainNavigationService { get; }
        INavigationService ContentNavigationService { get; }
        INavigationService PhoneNavigationService { get; }

        INavigationService MainFrame(Frame frame);
        INavigationService ContentFrame(Frame frame);
        INavigationService PhoneFrame(Frame frame);
    }
}
