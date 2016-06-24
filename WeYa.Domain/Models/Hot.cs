/********************************************************************************
** 作者： androllen
** 日期： 16/5/19 19:24:09
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
    public class Hot : BaseModel
    {
        [JsonProperty("recommend_cover_pic")]
        public string RecommendCoverPic { get; set; }

        [JsonProperty("recommend_caption")]
        public string RecommendCaption { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("recommend_cover_pic_size")]
        public string RecommendCoverPicSize { get; set; }

        [JsonProperty("media")]
        public Media Media { get; set; }


    }
    public class CollectHot : List<Hot>
    {
        public string Result { get; set; }
    }
}
