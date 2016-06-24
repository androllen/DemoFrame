/********************************************************************************
** 作者： Androllen
** 日期： 16/5/30 1:12:04
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeYa.Utils;

namespace WeYa.Domain.Deserializer
{
    public class MediasDeserializer : BaseDeserializer
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public MediasDeserializer() { }

        public override BaseModel Read(string content)
        {
            throw new NotImplementedException();
        }
        public override IList ReadList(string content)
        {
            //CollectMedias list = new CollectMedias();
            //try
            //{
            //    JArray jsonArray = JArray.Parse(content);

            //    Media status = null;
            //    if (jsonArray != null)
            //    {
            //        foreach (var j in jsonArray.Children())
            //        {
            //            status = j.ToObject<Media>();
            //            list.Add(status);
            //        }
            //    }
            //}
            //catch { }
            return null;
        }
    }
}
