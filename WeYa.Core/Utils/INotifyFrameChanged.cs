/********************************************************************************
** 作者： androllen
** 日期： 16/4/12 19:15:40
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using Caliburn.Micro;
using System;
using WeYa.Domain;
using WeYa.Domain.Models;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace WeYa.Core
{
    public interface INotifyFrameChanged
    {
        event EventHandler<BackRequestedEventArgs> BackKeyPressing;
        event EventHandler<int> Back2MainView;
        event EventHandler<AdaptiveEventArgs> ItemsWrapGridType;
        event EventHandler ContentNotify;
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
        void ClearPivotItemView(Action<INavigationService> action, int Index);
        void Go2ContentView(Action<INavigationService> action);

        INavigationService MainNavigationService { get; }
        INavigationService ContentNavigationService { get; }
        INavigationService PhoneNavigationService { get; }


        //void MainFrame(Frame frame);
        //void ContentFrame(Frame frame);
        void OnPhoneFrame(Frame frame);
        bool IsHasContent();

        Frame MainFrame { get; set; }
        Frame ContentFrame { get; set; }
        Frame PhoneFrame { get; set; }

        void IsAdaptiveType(AdaptiveType type,Size size);
    }
}
