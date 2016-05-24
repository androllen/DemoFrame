/********************************************************************************
** 作者： androllen
** 日期： 16/5/23 14:53:59
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeYa.Core
{
    public class CCDebug
    {
        private static CCDebug debug = new CCDebug();

        private readonly ILog log;
        public CCDebug()
        {
            log = LogManager.GetLog(typeof(object));
        }

        public static CCDebug Instance { get { return debug; } }

        public void Info(string format)
        {
            log.Info(format);
        }
        public void Info(string format, params object[] args)
        {
            log.Info(format, args);
        }

      

    }
}
