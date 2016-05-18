using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace WeYa.Domain
{
    public interface INotifyService : INotifyCache
    {
        //Task<BindableCollection<T>> getUserInfo<T>(int index);


        //链接地址
        Task<string> getUrl();
        //序列化

        //getdata
        Task<T> GetData<T>();

    }
}
