/********************************************************************************
** 作者： androllen
** 日期： 16/5/17 16:46:08
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using WeYa.Utils.EnumType;

namespace WeYa.Domain
{
    public class Callback<T>
    {
        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="data">回调数据实例, 若无数据返回，该值可以为 null.</param>
        public Callback(T data)
            : this(DataResult.Result_OK, data)
        {

        }

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="succeed">指示 Service 是否成功取得数据，默认为 true.</param>
        /// <param name="data">回调数据实例, 若无数据返回，该值可以为 null.</param>
        public Callback(DataResult succeed, T data)
            : this(succeed, data, null)
        {
            this.Data = data;
            this.Succeed = succeed;
        }
        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="succeed">指示 Service 是否成功取得数据，默认为 true.</param>
        /// <param name="data">回调数据实例, 若无数据返回，该值可以为 null.</param>
        public Callback(DataResult succeed, string result, T data)
            : this(succeed, data, null)
        {
            this.Data = data;
            this.Result = result;
            this.Succeed = succeed;
        }
        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="succeed">指示 Service 是否成功取得数据，默认为 true.</param>
        /// <param name="data">回调数据实例, 若无数据返回，该值可以为 null.</param>
        /// <param name="innerException">若有网络或数据异常发生，可以使用此参数.</param>
        public Callback(DataResult succeed, T data, Exception innerException)
        {
            this.InnerException = innerException;
            this.Data = data;
            this.Succeed = succeed;
        }

        /// <summary>
        /// 获取或设置回调过程中发生的异常.
        /// </summary>
        public Exception InnerException { get; set; }

        /// <summary>
        /// 获取或设置回调数据的实例.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 获取或设置是否成功取得数据.
        /// </summary>
        /// <remarks>
        /// 默认为 true.
        /// </remarks>
        //public bool Succeed { get; set; }

        public DataResult Succeed { get; set; }
        /// <summary>
        /// 获取或设置取得数据状态结果
        /// </summary>
        public string Result { get; set; }
    }
}
