/********************************************************************************
** 作者： androllen
** 日期： 16/4/15 16:44:53
** 微博： http://weibo.com/Androllen
** https://msdn.microsoft.com/zh-cn/library/dn986595.aspx about ?? ?.
**  _frameManager.RightFrame?.Content != null 
**  如果 RightFrame==null 返回 true 如果不为空 取Content != null 返回真假
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using WeYa.Domain.Models;
using Windows.Devices.Power;
using Windows.Networking.Connectivity;
using Windows.UI.Xaml;
using Newtonsoft.Json;
using WeYa.Utils.EnumType;

namespace WeYa.Domain
{
    public class GlobalInfoManager : BaseModel
    {
        //DataJsonResult IsSuccess = (DataJsonResult)Enum.ToObject(typeof(DataJsonResult), json);
        //DataJsonResult IsSuccess = (DataJsonResult)serializer.ReadIsSuccess(response);

        //public override event EventHandler<WwanConnectionProfileDetails> notifyConnectionEvent;
        public override event EventHandler<ElementTheme> notifyElementThemeEvent;
        public override event EventHandler<LoginResult> notifyLoginResultEvent;
        //public override event EventHandler<BatteryReport> notifyBatteryStatusEvent;


        public GlobalInfoManager()
        {
            OnThemeChanged(mAppTheme);

        }
        public string ErrorInfo
        {
            get { return GetGlobalInfo<string>("errorInfo", null); }
            set { SetGlobalInfo("errorInfo", value); }
        }
        #region ElementTheme
        public ElementTheme mAppTheme => mIsNightMode ? ElementTheme.Dark : ElementTheme.Light;

        public bool mIsNightMode
        {
            get { return GetGlobalInfo("IsNightMode", false); }
            set
            {
                SetGlobalInfo("IsNightMode", value);
                NotifyOfPropertyChange(nameof(mIsNightMode));
                NotifyOfPropertyChange(nameof(mAppTheme));
                OnThemeChanged(mAppTheme);
            }
        }

        private void OnThemeChanged(ElementTheme e)
        {
            notifyElementThemeEvent?.Invoke(this, e);
        }

        #endregion

        #region LoginResult
        private LoginResult loginResult;
        public LoginResult mLoginResult
        {
            get
            {
                if (loginResult == null)
                {
                    if (_userSettingContainer.Values.ContainsKey("LoginResult"))
                    {
                        var value = _userSettingContainer.Values["LoginResult"];
                        loginResult = JsonConvert.DeserializeObject<LoginResult>((string)value);
                    }
                }
                return loginResult;
            }
            set
            {
                if (value == null)
                    _userSettingContainer.Values.Remove("LoginResult");
                else
                    _userSettingContainer.Values["LoginResult"] = JsonConvert.SerializeObject(value);
                NotifyOfPropertyChange(nameof(mLoginResult));
                NotifyOfPropertyChange(nameof(mUserInfo));
                NotifyOfPropertyChange(nameof(mIsLogin));
            }
        }

        public UserInfo mUserInfo => new UserInfo() { Avatar = mLoginResult?.Avatar, Name = mLoginResult?.Name };
        /// <summary>
        /// 点击头像
        /// 点击评论
        /// 点击关注
        /// 查看照片 
        /// 点击分享 
        /// 点击收藏 
        /// 点击点赞
        /// </summary>
        public bool mIsLogin => mUserInfo?.Id > 0;

        private void OnLoginChanged(LoginResult e)
        {
            notifyLoginResultEvent?.Invoke(this, e);
        }
        #endregion

        public CacheType mIsCacheMode
        {
            get { return GetGlobalInfo("IsCacheMode", CacheType.Open); }
            set
            {
                SetGlobalInfo("IsCacheMode", value);
            }
        }

    }
}
