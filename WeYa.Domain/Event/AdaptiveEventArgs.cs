/********************************************************************************
** 作者： androllen
** 日期： 16/4/29 16:57:14
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeYa.Domain.Models;
using Windows.Foundation;

namespace WeYa.Domain
{
    public class AdaptiveEventArgs
    {
        public AdaptiveType type { get; set; }
        public Size NewSize { get; set; }
    }
}
