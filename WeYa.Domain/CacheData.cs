/********************************************************************************
** 作者： androllen
** 日期： 16/5/18 18:27:01
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
    public class CacheData : INotifyCache
    {
        public Task SaveFile(string path, object value)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string path)
        {
            throw new NotImplementedException();
        }

        public Task<string> ReadString(string path)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> ReadStream(string path)
        {
            throw new NotImplementedException();
        }

        protected override 
    }
}
