/********************************************************************************
** 作者： androllen
** 日期： 16/5/19 19:20:20
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
    public class User : BaseModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }

        [JsonProperty("country")]
        public int Country { get; set; }

        [JsonProperty("province")]
        public int Province { get; set; }

        [JsonProperty("city")]
        public int City { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("age")]
        public object Age { get; set; }

        [JsonProperty("constellation")]
        public string Constellation { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }

        [JsonProperty("friends_count")]
        public int FriendsCount { get; set; }

        [JsonProperty("reposts_count")]
        public int RepostsCount { get; set; }

        [JsonProperty("videos_count")]
        public int VideosCount { get; set; }

        [JsonProperty("real_videos_count")]
        public int RealVideosCount { get; set; }

        [JsonProperty("photos_count")]
        public int PhotosCount { get; set; }

        [JsonProperty("locked_videos_count")]
        public int LockedVideosCount { get; set; }

        [JsonProperty("real_locked_videos_count")]
        public int RealLockedVideosCount { get; set; }

        [JsonProperty("locked_photos_count")]
        public int LockedPhotosCount { get; set; }

        [JsonProperty("be_liked_count")]
        public int BeLikedCount { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty("has_password")]
        public bool HasPassword { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("is_funy_core_user")]
        public bool IsFunyCoreUser { get; set; }

        [JsonProperty("funy_core_user_created_at")]
        public int FunyCoreUserCreatedAt { get; set; }

        [JsonProperty("last_publish_time")]
        public int LastPublishTime { get; set; }
    }
}
