using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeYa.Domain;

namespace WeYa.Core
{
    public delegate void RestCallback<T>(Callback<T> response);

    public interface INotifyService
    {
        Task Get(Dictionary<string, object> Dic, RestCallback<string> callBack);
        Task Get(string url, RestCallback<string> callBack);
    }
}
