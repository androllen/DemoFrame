/********************************************************************************
** 作者： androllen
** 日期： 16/3/29 17:30:14
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DemoFrame.ViewModels;

namespace DemoFrame
{
    public class NavigationManager
    {
        private INotifyFrameChanged _frame => IoC.Get<INotifyFrameChanged>();

        public void ShowClickItem()
        {
            _frame.Go2ContentView((goView) => 
            {
                goView.For<ShellViewModel>().Navigate();
            });
        }

        public void ShowDevices()
        {
            _frame.Go2ContentView((goView) =>
            {
                goView.For<ContentViewModel>().Navigate();
            });
        }
    }
}
