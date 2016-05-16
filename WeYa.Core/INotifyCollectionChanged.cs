using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeYa.Core
{
    interface INotifyCollectionChanged
    {
        int Index { get; set; }
        int Page { get; set; }
        int PageCount { get; set; }
        bool HasMore { get; set; }
        int maxid { get; set; }
    }
}
