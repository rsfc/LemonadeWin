namespace Lemonade.Frame.Menu
{
    /// <summary>
    /// 菜单工厂接口
    /// </summary>
    public interface IMenuFactory
    {
        /// <summary>
        /// 将菜单添加到窗体
        /// </summary>
        void AddMenuControl();
        /// <summary>
        /// 设置菜单项
        /// </summary>
        void SetMenuStrip();
    }
}