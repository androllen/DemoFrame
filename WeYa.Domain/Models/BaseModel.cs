/********************************************************************************
** 作者： androllen
** 日期： 16/4/12 19:15:40
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using Caliburn.Micro;
using Windows.Devices.Power;
using Windows.Networking.Connectivity;
using Windows.Storage;
using Windows.UI.Xaml;
using WeYa.Domain.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WeYa.Domain
{
    public abstract class BaseModel : PropertyChangedBase ,INotifyAppChanged
    {
        protected readonly ApplicationDataContainer _userSettingContainer;
        public BaseModel()
        {
            _userSettingContainer = ApplicationData.Current.LocalSettings.CreateContainer("userinfo",
                ApplicationDataCreateDisposition.Always);
        }

        public virtual event EventHandler<BatteryReport> notifyBatteryStatusEvent;
        public virtual event EventHandler<WwanConnectionProfileDetails> notifyConnectionEvent;
        public virtual event EventHandler<ElementTheme> notifyElementThemeEvent;
        public virtual event EventHandler<LoginResult> notifyLoginResultEvent;


        public bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
            return true;
        }

        protected T GetGlobalInfo<T>(string key, T defaultValue)
        {
            if (_userSettingContainer.Values.ContainsKey(key))
            {
                return (T)_userSettingContainer.Values[key];
            }
            else
            {
                return defaultValue;
            }
        }

        protected void SetGlobalInfo<T>(string key, T value)
        {
            if (value == null)
            {
                _userSettingContainer.Values.Remove(key);
            }
            _userSettingContainer.Values[key] = value;
        }

    }
}
