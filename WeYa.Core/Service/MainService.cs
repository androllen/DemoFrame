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
        private readonly INotifyCache _baseDeserializer;
        public MainService(INotifyCache deser)
        {
            _baseDeserializer = deser;
        }

        public async Task HotGet<T>(ServiceArgument args, Action<BindableCollection<T>> callback)
        {
            var pair = new Dictionary<string, object>();
            pair.Add("id", args.id);
            pair.Add("type", 1);
            pair.Add("feature", args.feature);
            pair.Add("page", args.page);
            pair.Add("language", DeviceUtil.Language);
            pair.Add("client_id", "1089857302");
            pair.Add("device_id", DeviceUtil.UniqueId);
            pair.Add("version", DeviceUtil.Version);
            pair.Add("channel", DeviceUtil.Channel);
            pair.Add("model", "N918St");

            await Get(pair, response =>
            {
                switch (response.Statused)
                {
                    case HttpErrorStatus.Success:
                        {
                            //缓存分开
                            //异步写入数据库 不使用文件保存 下次加载缓存数据从数据库加载
                            var taskCache = _baseDeserializer.SaveFile(Const_def.db_CacheDir, response.Data);

                            //序列化
                            var taskModels = JsonConvert.DeserializeObject<BindableCollection<T>>(response.Data);

                            callback?.Invoke(taskModels);
                            break;
                        }
                    case HttpErrorStatus.JsonError:
                        break;
                    case HttpErrorStatus.NetworkError:
                        break;
                    case HttpErrorStatus.UnknownError:
                        break;
                    case HttpErrorStatus.UserCancelOperation:
                        break;
                }
            });
        }

    }
}
