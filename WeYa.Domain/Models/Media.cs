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
    public class CaptionUrlParam
    {

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("scheme")]
        public string Scheme { get; set; }
    }
    public class PrivacyConfig
    {

        [JsonProperty("allow_save_medias")]
        public int? AllowSaveMedias { get; set; }
    }

    public class Media : BaseModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("weibo_share_caption")]
        public string WeiboShareCaption { get; set; }

        [JsonProperty("facebook_share_caption")]
        public string FacebookShareCaption { get; set; }

        [JsonProperty("weixin_share_caption")]
        public string WeixinShareCaption { get; set; }

        [JsonProperty("weixin_friendfeed_share_caption")]
        public string WeixinFriendfeedShareCaption { get; set; }

        [JsonProperty("qzone_share_caption")]
        public string QzoneShareCaption { get; set; }

        [JsonProperty("qq_share_caption")]
        public string QqShareCaption { get; set; }

        [JsonProperty("instagram_share_caption")]
        public string InstagramShareCaption { get; set; }

        [JsonProperty("weixin_share_sub_caption")]
        public string WeixinShareSubCaption { get; set; }

        [JsonProperty("weixin_friendfeed_share_sub_caption")]
        public string WeixinFriendfeedShareSubCaption { get; set; }

        [JsonProperty("qzone_share_sub_caption")]
        public string QzoneShareSubCaption { get; set; }

        [JsonProperty("qq_share_sub_caption")]
        public string QqShareSubCaption { get; set; }

        [JsonProperty("geo")]
        public object Geo { get; set; }

        [JsonProperty("video")]
        public string Video { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("cover_pic")]
        public string CoverPic { get; set; }

        [JsonProperty("pic_size")]
        public string PicSize { get; set; }

        [JsonProperty("category")]
        public int Category { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }

        [JsonProperty("is_long")]
        public bool IsLong { get; set; }

        [JsonProperty("show_controls")]
        public bool ShowControls { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("comments_count")]
        public int CommentsCount { get; set; }

        [JsonProperty("likes_count")]
        public int LikesCount { get; set; }

        [JsonProperty("reposts_count")]
        public int RepostsCount { get; set; }

        [JsonProperty("is_popular")]
        public bool IsPopular { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("feed_id")]
        public object FeedId { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        [JsonProperty("caption_url_params")]
        public CaptionUrlParam[] CaptionUrlParams { get; set; }

        [JsonProperty("privacy_config")]
        public PrivacyConfig PrivacyConfig { get; set; }

        [JsonProperty("has_watermark")]
        public int HasWatermark { get; set; }

        [JsonProperty("display_source")]
        public int DisplaySource { get; set; }

    }
}
