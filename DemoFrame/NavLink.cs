using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;

namespace DemoFrame.model
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
        private string page;
        public string PageItem
        {
            get { return page; }
            set { SetProperty(ref page, value); }
        }
    }
    public class BaseModel : INotifyPropertyChanged
    {
        private string items;
        public string Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
