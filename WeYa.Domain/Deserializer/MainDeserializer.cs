/********************************************************************************
** 作者： androllen
** 日期： 16/5/18 18:19:53
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Windows.Storage;
using WeYa.Utils;
using System.IO;

namespace WeYa.Domain
{
    public class MainDeserializer : INotifyCache
    {
        public MainDeserializer()
        {
        }

        public async Task<bool> Delete(string path)
        {
            StorageFile file = await FileUtil.GetFile(path);
            return await FileUtil.DeleteFile(path);
        }

        public async Task<Stream> ReadStream(string path)
        {
            StorageFile file = await FileUtil.GetFile(path);
            return await FileUtil.ReadStream(file, path);
        }

        public async Task<string> ReadString(string path)
        {
            StorageFile file = await FileUtil.GetFile(path);
            return await FileUtil.ReadText(file,path);
        }
  
        public async Task SaveFile(string path, object value)
        {
            var json = JsonConvert.SerializeObject(value);
            StorageFile file = await FileUtil.GetFile(path);
            await FileUtil.WriteText(file, json);
        }
    }
}
