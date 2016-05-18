using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeYa.Domain.Util
{
    public interface INotifyCollectionChanged
    {
        bool IsLoaded { get; set; }
        bool IsLoading { get; set; }

        bool IsRefreshing { get; set; }
        bool IsRefreshed { get; set; }

        int Page { get; set; }
        int PageCount { get; set; }
        int maxid { get; set; }
    }
}
