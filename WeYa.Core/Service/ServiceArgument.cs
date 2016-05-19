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
        /// 获取或设置每次请求记录的条数 .
        /// </summary>
        public int Reqnum { get; set; }
        public int Pagesize { get; set; }
        public string id { get; set; }
        public string parent { get; set; }
        public string uid { get; set; }
        public int type { get; set; }
        public string q { get; set; }

        public string feature { get; set; }
        /// <summary>
        /// 获取或设置起始位置.第一页填0，继续向下翻页：填【reqnum*（page-1）】.  //20
        /// </summary>

        public int page { get; set; }
        public int count { get; set; }
        public string topic { get; set; }
        public string section { get; set; }
        public string source { get; set; }
        private string _maxid = string.Empty;
        public string maxid
        {
            get { return _maxid; }
            set { _maxid = value; }
        }
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
