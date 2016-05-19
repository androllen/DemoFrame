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
        private string _recommend_caption = string.Empty;


        [JsonProperty("recommend_caption")]
        public string recommend_caption
        {
            get
            {
                return _recommend_caption;
            }
            set
            {
                if (_recommend_caption != value)
                    _recommend_caption = value;
                NotifyOfPropertyChange(nameof(recommend_caption));
            }
        }
        private string _recommend_cover_pic = string.Empty;
        [JsonProperty("recommend_cover_pic")]
        public string recommend_cover_pic
        {
            get
            {
                return _recommend_cover_pic;
            }
            set
            {
                if (_recommend_cover_pic != value)
                    _recommend_cover_pic = value;

                NotifyOfPropertyChange(nameof(recommend_cover_pic));
            }
        }

        private Media _media;
        [JsonProperty("media")]
        public Media media
        {
            get
            {
                return _media;
            }
            set
            {
                if (_media != value)
                    _media = value;
                NotifyOfPropertyChange(nameof(media));
            }
        }
    }
}
