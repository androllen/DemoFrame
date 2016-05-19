/********************************************************************************
** 作者： androllen
** 日期： 16/5/19 19:22:11
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeYa.Domain
{
    public class Geo : BaseModel
    {
        [JsonProperty("latitude")]
        public double latitude { get; set; }
        [JsonProperty("longitude")]
        public double longitude { get; set; }
        [JsonProperty("location")]
        public string location { get; set; }
    }
    public class Media : BaseModel
    {
        public int id { get; set; }
        private string _caption = string.Empty;
        [JsonProperty("caption")]
        public string caption
        {
            get
            {
                return _caption;
            }
            set
            {
                if (_caption != value)
                    _caption = value;
                NotifyOfPropertyChange(nameof(caption));
            }
        }
        public string weibo_share_caption { get; set; }
        public string facebook_share_caption { get; set; }
        public string weixin_share_caption { get; set; }
        public string weixin_friendfeed_share_caption { get; set; }
        public string qzone_share_caption { get; set; }
        public string qq_share_caption { get; set; }
        public string instagram_share_caption { get; set; }
        public Geo geo { get; set; }
        [JsonProperty("video")]
        public string video { get; set; }
        [JsonProperty("url")]
        public string url { get; set; }
        private string coverpic;
        [JsonProperty("cover_pic")]
        public string cover_pic
        {
            get
            {
                return coverpic;
            }
            set
            {
                coverpic = value;
                NotifyOfPropertyChange(nameof(cover_pic));
            }
        }
        [JsonProperty("category")]
        public int category { get; set; }
        [JsonProperty("time")]
        public int time { get; set; }
        [JsonProperty("is_long")]
        public bool is_long { get; set; }
        [JsonProperty("created_at")]
        public string created_at { get; set; }
        [JsonProperty("comments_count")]
        public int comments_count { get; set; }
        [JsonProperty("likes_count")]
        public int likes_count { get; set; }
        [JsonProperty("reposts_count")]
        public int reposts_count { get; set; }
        [JsonProperty("is_popular")]
        public bool is_popular { get; set; }
        private User _user;
        [JsonProperty("user")]
        public User user
        {
            get
            {
                return _user;
            }
            set
            {
                if (_user != value)
                    _user = value;
                NotifyOfPropertyChange(nameof(user));
            }
        }
        public long feed_id { get; set; }

    }
}
