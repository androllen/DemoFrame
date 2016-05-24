/********************************************************************************
** 作者： androllen
** 日期： 16/5/19 18:23:32
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeYa.Utils;

namespace WeYa.Core
{
    public class ServiceArgument
    {
        /// <summary>
        ///话题 id 或频道 id，其中频道目前支持的有：
        ///热门(ID:1)
        /// 搞笑(ID:13)
        /// 明星名人(ID:16)
        /// 逗比(ID:64)
        /// 男神(ID:31)
        /// 女神(ID:19)
        /// 舞蹈(ID:63)
        /// 音乐(ID:62)
        /// 旅行(ID:3)
        /// 美食(ID:59)
        /// 美妆时尚(ID:27)
        /// 姿势(ID:5)
        /// 萌宠乐园(ID:6)
        /// 宝宝(ID:18)
        /// 二次元(ID:193)
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 话题名称（若传了话题名称则根据话题名称搜索不根据 id 搜索，id 字段可不传）
        /// </summary>
        public string topic_name { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string uid { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 排序方式，new 表示最新，hot 表示最热，频道默认为最新，话题默认为最热
        /// </summary>
        public string feature { get; set; }
        /// <summary>
        /// 返回结果的页码，默认为1。
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 若取话题最新，需传此字段，为当前分页最后一个美拍的 ID，用于获取下一页时定位
        /// </summary>
        public int maxid { get; set; }
        public string topic { get; set; }
        public string section { get; set; }
        public string source { get; set; }
        public Dictionary<string, object> Dic { get; set; }
        public string Uri { get; set; }
        //"id=16
        //&type=1
        //&feature=new
        //&page=1
        //&language=zh-Hans
        //&client_id=1039857302
        //&device_id=869576010322039
        //&version=180
        //&channel=oppo";
    }
}
