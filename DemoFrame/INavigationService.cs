﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFrame
{
    public interface INavigationService
    {
        void GoBack();
        void NavigateTo(Uri pageUri);
    }
}
