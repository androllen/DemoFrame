/********************************************************************************
** 作者： androllen
** 日期： 16/5/18 14:12:49
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeYa.Domain
{
    public interface INotifyFileCache
    {
        //保存缓存数据
        Task SaveFile(string path, object value);
        //删除
        Task<bool> Delete(string path);
        //读缓存文件
        Task<string> ReadString(string path);
        Task<Stream> ReadStream(string path);
    }
}
