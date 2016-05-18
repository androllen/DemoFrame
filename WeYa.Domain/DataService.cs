/********************************************************************************
** 作者： androllen
** 日期： 16/5/17 16:44:38
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeYa.Domain.Models;

namespace WeYa.Domain
{
    public class DataService
    {
        ////获取分类
        //public static async Task<Callback<UserInfo>> GetCategory()
        //{
        //    var url = string.Format("http://news-at.zhihu.com/api/4/themes");
        //    return await Get<UserInfo>(url);
        //}

        //private static async Task<Callback<T>> Get<T>(string url, Dictionary<string, string> header = null)
        //{
        //    return await Get(url, stream => 
        //    {
        //        using(var reader = new StreamReader(stream))
        //        {
        //            var json = reader.ReadToEnd();

        //            return JsonConvert.DeserializeObject<T>(json);
        //        }
        //    },header);
        //}
     
        //private static async Task<Callback<T>> Get<T>(string url, Func<Stream,T> func, Dictionary<string, string> header = null)
        //{
        //    using (var http = new HttpClient(new HttpClientHandler() { AllowAutoRedirect = false }))
        //    {
        //        foreach(var item in header)
        //        {
        //            http.DefaultRequestHeaders.Add(item,)
        //        }
        //    }
           
        //}
    }
}
