/********************************************************************************
** 作者： androllen
** 日期： 16/5/18 14:26:44
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeYa.Utils;
using WeYa.Domain;
using System.Threading.Tasks;

namespace WeYa.Domain.Deserializer
{
    public abstract class BaseDeserializer
    {
        public BaseDeserializer()
        {
        }
        /// <summary>
        /// 反序列化单个对象.
        /// </summary>
        /// <param name="content">需要反序列化成单个对象的字符串.</param>
        /// <returns>返回对象.</returns>
        public abstract BaseModel Read(string content);
        /// <summary>
        /// 反序列化对象列表.
        /// </summary>
        /// <param name="content">需要反序列化成列表的字符串.</param>
        /// <returns>返回对象列表</returns>
        public abstract IList ReadList(string content);
    }
}
