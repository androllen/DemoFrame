/********************************************************************************
** 作者： androllen
** 日期： 16/5/23 15:22:44
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeYa.Domain
{
    public class SquareCategories
    {
        [JsonProperty("id")]
        public object Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("is_parent")]
        public bool IsParent { get; set; }

        [JsonProperty("has_hot_feature")]
        public bool HasHotFeature { get; set; }

        [JsonProperty("topic_id")]
        public string TopicId { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("scheme")]
        public string Scheme { get; set; }

        [JsonProperty("section")]
        public string Section { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("section_display_order")]
        public string SectionDisplayOrder { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }
}
