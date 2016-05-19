/********************************************************************************
** 作者： androllen
** 日期： 16/5/18 15:24:58
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using WeYa.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Net.Http;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Xml;
using System;
using WeYa.Domain;

namespace WeYa.Core
{
    public abstract class BaseService 
    {
        public delegate void RestCallback<T>(Callback<T> response);

        protected async Task Get(Dictionary<string,object> Dic,  RestCallback<string> callBack)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var i in Dic)
            {
                sb.Append(i.Key);
                sb.Append("=");
                sb.Append(i.Value);
                sb.Append("&");
            }
            await Get(string.Concat(Const_def.API_Category, sb.ToString().TrimEnd('&')), callBack);
        }

        private async Task Get(string url, RestCallback<string> callBack)
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                UseCookies = true,
                UseDefaultCredentials = false,
                AllowAutoRedirect = false
            };
            try
            {
                using (var client = new HttpClient(handler))
                {
                    var token = new CancellationToken();
                    token.ThrowIfCancellationRequested();
                    Debug.WriteLine(url);
                    var response = await client.GetAsync(url, token);
                    var json = await response.Content.ReadAsStringAsync();

                    callBack?.Invoke(new Callback<string>(json));
                }
            }
            catch (XmlException e)
            {
                Debug.WriteLine(e);
                callBack?.Invoke(new Callback<string>(HttpErrorStatus.JsonError, e));
            }
            catch (OperationCanceledException e)
            {
                Debug.WriteLine(e);
                callBack?.Invoke(new Callback<string>(HttpErrorStatus.UserCancelOperation, e));
            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine(e);
                callBack?.Invoke(new Callback<string>(HttpErrorStatus.NetworkError, e));
            }
            catch (WebException e)
            {
                Debug.WriteLine(e);
                callBack?.Invoke(new Callback<string>(HttpErrorStatus.NetworkError, e));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                callBack?.Invoke(new Callback<string>(HttpErrorStatus.UnknownError, e));
            }
        }


        //private async Task<BindableCollection<T>> Post<T>(int index)
        //{
        //    var cookieContainer = new CookieContainer();
        //    var handler = new HttpClientHandler
        //    {
        //        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
        //        UseCookies = true,
        //        UseDefaultCredentials = false,
        //        CookieContainer = cookieContainer
        //    };

        //    try
        //    {
        //        using (var client = new HttpClient(handler))
        //        {
        //            var dic = new Dictionary<string, string>
        //            {
        //                ["action"] = "login",
        //            };
        //            client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue()
        //            {
        //                NoCache = true
        //            };
        //            var header = new FormUrlEncodedContent(dic);
        //            var response = await client.PostAsync(new Uri(Const_def.API_Category), header);
        //            var json = await response.Content.ReadAsStringAsync();

        //            var taskModels = JsonConvert.DeserializeObject<BindableCollection<T>>(json);
        //            return taskModels;
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
