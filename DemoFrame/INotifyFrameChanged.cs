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
        event EventHandler<int> Back2MainView;
        /// <summary>
        /// 处理分类信息
        /// 1.导航
        /// 2.清除所有的frame
        /// 3.本持一个原则 
        /// 当启动的时候 初始化页面 InitMainView 和 初始化内容页 InitContentView
        /// 当点击MainView 如果有内容页 则弹出返回键
        /// 当点击MainView 如果没有内容页 则不弹出返回键
        /// 
        /// 当点击 split item其他栏目，使用初始化页面
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        void CategoryNavService<T>();

        INavigationService MainNavigationService { get; }
        INavigationService ContentNavigationService { get; }
        INavigationService PhoneNavigationService { get; }

        void ClearAllContentView(Action<INavigationService> action);
        void ClearPivotItemView(Action<INavigationService> action, int Index);
        void Go2ContentView(Action<INavigationService> action);

        //void MainFrame(Frame frame);
        //void ContentFrame(Frame frame);
        void PhoneFrame(Frame frame);

        Frame MainFrame { get; set; }
        Frame ContentFrame { get; set; }
    }
}
