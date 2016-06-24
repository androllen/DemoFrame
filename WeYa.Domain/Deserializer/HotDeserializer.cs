using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WeYa.Domain.Deserializer;
using WeYa.Utils;

namespace WeYa.Domain.Deserializer
{
    public class HotDeserializer : BaseDeserializer
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public HotDeserializer() { }
        public override BaseModel Read(string content)
        {
            return null;
        }

        public override IList ReadList(string content)
        {
            CollectHot list = new CollectHot();
            try
            {
                JArray jsonArray = JArray.Parse(content);

                Hot status = null;
                if (jsonArray != null)
                {
                    foreach (var j in jsonArray.Children())
                    {
                        status = j.ToObject<Hot>();
                        //status.recommend_cover_pic = status.recommend_cover_pic.Replace(Const_def.Hot320Url, Const_def.Hot240Url);
                        status.Media.User.Avatar= string.Concat(status.Media.User.Avatar, Const_def.Hot60Url);
                        list.Add(status);
                    }
                }
            }
            catch { }
           return list;           
        }
    }
}
