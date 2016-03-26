using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caliburn.Micro;

namespace DemoFrame.ViewModels
{
    public abstract class BaseViewModel : Screen
    {
        public virtual string Title { get; set; }
        protected readonly INotifyFrameChanged _frame;

        public BaseViewModel(INotifyFrameChanged frame)
        {
            _frame = frame;
        }

    }
}
