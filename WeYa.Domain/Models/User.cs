/********************************************************************************
** 作者： androllen
** 日期： 16/5/19 19:20:20
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeYa.Domain
{
    public class User : BaseModel
    {
        public int id { get; set; }

        private string _screen_name = string.Empty;
        public string screen_name
        {
            get
            {
                return _screen_name;
            }
            set
            {
                if (_screen_name != value)
                    _screen_name = value;
                NotifyOfPropertyChange(nameof(screen_name));
            }
        }
        public int country { get; set; }
        public int province { get; set; }
        public int city { get; set; }
        private string _avatar = string.Empty;
        public string avatar
        {
            get
            {
                return _avatar;
            }
            set
            {
                if (_avatar != value)
                    _avatar = value;
                NotifyOfPropertyChange(nameof(avatar));
            }
        }
        public string gender { get; set; }
        public string birthday { get; set; }
        public string age { get; set; }
        public string constellation { get; set; }
        private bool _verified = false;
        public bool verified
        {
            get
            {
                return _verified;
            }
            set
            {
                if (_verified != value)
                    _verified = value;
                NotifyOfPropertyChange(nameof(verified));
            }
        }

        public int followers_count { get; set; }
        public int friends_count { get; set; }
        public int reposts_count { get; set; }
        public int videos_count { get; set; }
        public int created_at { get; set; }

        public int real_videos_count { get; set; }
        public int photos_count { get; set; }
        public int be_liked_count { get; set; }
        public bool following { get; set; }
        public bool followed_by { get; set; }
        public bool blocking { get; set; }
        public bool blocked_by { get; set; }
        public string url { get; set; }

        public string weibo_share_caption { get; set; }
        public string facebook_share_caption { get; set; }
        public string weixin_share_caption { get; set; }
        public string weixin_friendfeed_share_caption { get; set; }
        public string qzone_share_caption { get; set; }
        public string share_pic { get; set; }
        public string description { get; set; }
    }
}
