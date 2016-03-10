using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace DemoFrame
{
    public abstract class BaseFrame : INotifyFrameChanged
    {
        protected readonly WinRTContainer _container;
        public BaseFrame(WinRTContainer container)
        {
            _container = container;
        }
        public INavigationService LeftNavService { get; }
        public Frame LeftPageFrame { get; set; }
        public INavigationService MainNavService { get; private set; }
        public Frame MainPageFrame { get; set; }
        public INavigationService RightNavService { get; }
        public Frame RightPageFrame { get; set; }

        public event EventHandler<BackRequestedEventArgs> BackKeyPressing;
        public event EventHandler<bool> NotifyLeftFramePage;
        public event EventHandler NotifyRightFramePage;

        public abstract void onBackKeyPressed();
  



        //protected BaseFrame mCurrentFragment;
        //private bool mCloseWarned = false;

        //protected bool processBackPressed()
        //{
        //    return false;
        //}

        //public void onBackPressed()
        //{
        //    if (processBackPressed())
        //    {
        //        return;
        //    }

        //    bool enableBackPressed = true;
        //    if (this.mCurrentFragment != null)
        //        enableBackPressed = !(this.mCurrentFragment.processBackPressed);

        //    if (enableBackPressed)
        //    {
        //        int cnt = this.mCurrentFragment.BackStack.Count;

        //        if ((cnt <= 1) && ((Window.Current.Content as Frame).BackStack.Any()))
        //        {
        //            String closeWarningHint = getCloseWarning();
        //            if ((!(this.mCloseWarned)) && (!(string.IsNullOrEmpty(closeWarningHint))))
        //            {
        //                this.mCloseWarned = true;

        //                //Toast toast = Toast.makeText(this, closeWarningHint, Toast.LENGTH_SHORT);
        //                //toast.show();
        //                //handler.postDelayed(closeApp, 2000);
        //            }
        //            else
        //            {
        //                //handler.removeCallbacks(closeApp);
        //                doReturnBack();
        //            }
        //        }
        //        else
        //        {
        //            this.mCloseWarned = false;
        //            doReturnBack();
        //        }
        //    }
        //}

        //private void doReturnBack()
        //{
        //    int count = this.mCurrentFragment.BackStack.Count;
        //    if (count <= 0)
        //        App.Current.Exit();
        //    else
        //    {
        //        if (mCurrentFragment.CanGoBack)
        //            this.mCurrentFragment.GoBack();
        //    }
        //}

        //public void goToFragment(BaseFrame cls, Object data)
        //{
        //    if (cls == null)
        //    {
        //        return;
        //    }
        //    BaseFrame rootFrame = Window.Current.Content as BaseFrame;

        //    //CubeFragment fragment = (CubeFragment)getSupportFragmentManager().findFragmentByTag(cls.toString());
        //    if (rootFrame != null)
        //    {
        //        mCurrentFragment = rootFrame;
        //    }
        //    // !null 0保留自己 移除 当前导航的所有栈 除了自己
        //    //getSupportFragmentManager().popBackStackImmediate(cls.toString(), 0);
        //    while (rootFrame.BackStackDepth >= 1)
        //    {
        //        rootFrame.BackStack.RemoveAt(rootFrame.BackStackDepth - 1);
        //    }
        //}


        //public void popTopFragment()
        //{
        //    Frame rootFrame = Window.Current.Content as Frame;
        //    rootFrame.BackStack.RemoveAt(Frame.BackStackDepth - 1);
        //}

        //public void popToRoot(Type data)
        //{
        //    BaseFrame rootFrame = Window.Current.Content as BaseFrame;
        //    rootFrame.Navigate(data);
        //    rootFrame.BackStack.Clear();
        //}

        //private bool tryToUpdateCurrentAfterPop()
        //{
        //    BaseFrame fm = Window.Current.Content as BaseFrame;
        //    int cnt = fm.BackStack.Count();
        //    if (cnt > 0)
        //    {
        //        PageStackEntry rootFrame = fm.BackStack.LastOrDefault();
        //        return true;
        //    }
        //    return false;
        //}

    }
}
