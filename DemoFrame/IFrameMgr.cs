using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFrame
{
    public interface IFrameMgr
    {
        INavigationService MainNavigationService { get; }
        INavigationService ContentNavigationService { get; }
        INavigationService PhoneNavigationService { get; }
    }
}
