using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace WeYa.Domain
{
    public class NavLink : BaseModel
    {
        private string label;
        public string Label
        {
            get { return label; }
            set { SetProperty(ref label, value); }
        }


        private Symbol sysbol;
        public Symbol Symbol
        {
            get { return sysbol; }
            set { SetProperty(ref sysbol, value); }
        }
    }
}
