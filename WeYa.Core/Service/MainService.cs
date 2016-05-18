/********************************************************************************
** 作者： androllen
** 日期： 16/5/17 18:03:39
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using WeYa.Utils;
using System.Threading.Tasks;
using WeYa.Domain.Models;
using Caliburn.Micro;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading;
using WeYa.Domain;
using System.Text;
using System.Diagnostics;
using System.Xml;

namespace WeYa.Core
{
    public class MainService : BaseService
    {
        private int _pagecount;
        private readonly INotifyCache _baseDeserializer;

        public MainService(INotifyCache deser)
        {
            _baseDeserializer = deser;
        }

        //获取分类
        public async Task<BindableCollection<UserInfo>> GetCategory(int page)
        {
            var pair = new Dictionary<string, object>();
            pair.Add("id", 1);
            pair.Add("count", 2);
            pair.Add("page", page);

            StringBuilder sb = new StringBuilder();
            foreach (var i in pair)
            {
                sb.Append(i.Key);
                sb.Append("=");
                sb.Append(i.Value);
                sb.Append("&");
            }

            return await Get<UserInfo>(string.Concat(Const_def.API_Category, sb.ToString().TrimEnd('&')));
        }

        private async Task<T> Get<T>(string url)
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

                    var response = await client.GetAsync(url, token);
                    var json = await response.Content.ReadAsStringAsync();

                    //序列化 分开
                    var taskModels = JsonConvert.DeserializeObject<T>(json);
                    //缓存分开
                    var taskCache = _baseDeserializer.SaveFile("",taskModels);

                    return taskModels;
                }
            }
            catch (XmlException e)
            {
                Debug.WriteLine(e);
                return new RequestResult<T>
                {
                    ResultType = RequestResultType.Error,
                    ErrorMessage = Constants.JsonError,
                };
            }
            catch (OperationCanceledException e)
            {
                Debug.WriteLine(e);
                return new RequestResult<T>
                {
                    ResultType = RequestResultType.Cancel,
                    ErrorMessage = Constants.UserCancelOperation,
                };
            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine(e);
                return new RequestResult<T>
                {
                    ResultType = RequestResultType.Error,
                    ErrorMessage = Constants.NetworkError,
                };
            }
            catch (WebException e)
            {
                Debug.WriteLine(e);
                return new RequestResult<T>
                {
                    ResultType = RequestResultType.Error,
                    ErrorMessage = Constants.NetworkError,
                };
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return new RequestResult<T>
                {
                    ResultType = RequestResultType.Error,
                    ErrorMessage = Constants.UnknownError,
                };
            }
        }
        private async Task<BindableCollection<T>> Post<T>(int index)
        {
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                UseCookies = true,
                UseDefaultCredentials = false,
                CookieContainer = cookieContainer
            };

            try
            {
                using (var client = new HttpClient(handler))
                {
                    var dic = new Dictionary<string, string>
                    {
                        ["action"] = "login",
                    };
                    client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue()
                    {
                        NoCache = true
                    };
                    var header = new FormUrlEncodedContent(dic);
                    var response = await client.PostAsync(new Uri(Const_def.API_Category), header);
                    var json = await response.Content.ReadAsStringAsync();
                
                    var taskModels = JsonConvert.DeserializeObject<BindableCollection<T>>(json);
                    return taskModels;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
