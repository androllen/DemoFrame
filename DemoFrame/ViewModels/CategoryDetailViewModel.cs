using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace DemoFrame.ViewModels
{
    public class CategoryDetailViewModel : Screen
    {
        private string _categoryId;
        public string Title
        {
            get { return _categoryId; }
            set
            {
                if (_categoryId != value)
                {
                    _categoryId = value;
                    NotifyOfPropertyChange(nameof(Title));
                }
            }
        }

        protected readonly INotifyFrameChanged _frame;
        public CategoryDetailViewModel(INotifyFrameChanged frame)
        {
            _frame = frame;
        }
    }
}
