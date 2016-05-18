/********************************************************************************
** 作者： androllen
** 日期： 16/5/18 16:00:44
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WeYa.Domain
{
    /// <summary>
    /// 反序列化器管理器，根据数据类型返回用户所需要的反序列化器.
    /// </summary>
    public class DeserializerManager
    {
        private static DeserializerManager instance = new DeserializerManager();

        private DeserializerManager()
        { }

        /// <summary>
        /// 获取反序列化器管理器实例.
        /// </summary>
        public static DeserializerManager Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// 构造(SearchLove)对象的反序列化器.
        /// </summary>
        /// <returns>返回 BuildSearchLoveDeserializer 对象</returns>
        public BaseDeserializer BuildPubDeserializer()
        {
            return BuildDeserializer( "PubDeserializer", null);
        }

        private BaseDeserializer BuildDeserializer(string serviceName, object[] parameters)
        {
            Type type = GetType("", serviceName);

            if (null != type)
            {
                Type[] types = new Type[] { };

                if (null != parameters)
                {
                    types = new Type[] { parameters[0].GetType() };
                }

                ConstructorInfo conInfo = type.GetConstructor(types);
                return conInfo.Invoke(parameters) as BaseDeserializer;
            }

            return null;
        }

        private Type GetType(object format, string sericeName)
        {
            string uri = String.Format("MeiPai3.Service.Deserializer.Json.{1}", format, sericeName);
            Type type = Type.GetType(uri);

            return type;
        }
    }
}
