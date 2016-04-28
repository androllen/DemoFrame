/********************************************************************************
** 作者： androllen
** 日期： 16/4/15 16:59:17
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using WeYa.Domain.Models;
using Windows.Devices.Power;
using Windows.Networking.Connectivity;
using Windows.System.Power;
using Windows.UI.Xaml;

namespace WeYa.Domain
{
    public interface INotifyAppChanged
    {
        /// <summary>
        /// call when theme changed 
        /// </summary>
        event EventHandler<ElementTheme> notifyElementThemeEvent;
        // call  when wifi to 3g to 2g to 4g
        event EventHandler<WwanConnectionProfileDetails> notifyConnectionEvent;
        /// <summary>
        /// call when Battery 电量低的时候.
        /// https://msdn.microsoft.com/zh-cn/library/windows/apps/xaml/dn895210.aspx
        /// </summary>
        event EventHandler<BatteryReport> notifyBatteryStatusEvent;
        /// <summary>
        ///  call 登录注册提示
        /// </summary>
        event EventHandler<LoginResult> notifyLoginResultEvent;

    }
}
