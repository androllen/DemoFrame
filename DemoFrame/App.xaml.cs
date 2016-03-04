using Caliburn.Micro;
using DemoFrame.ViewModels;

namespace DemoFrame
{
    /// <summary>
    /// 提供特定于应用程序的行为，以补充默认的应用程序类。
    /// </summary>
    public sealed partial class App
    {
        /// <summary>
        /// 初始化单一实例应用程序对象。这是执行的创作代码的第一行，
        /// 已执行，逻辑上等同于 main() 或 WinMain()。
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }
        protected override void Configure()
        {
            base.Configure();

            DataSettingHelper.init();
            DataSettingHelper.getInstance.setValues<string>("", string.Empty);

            _container.PerRequest<ShellViewModel>();
        }


    }
}
