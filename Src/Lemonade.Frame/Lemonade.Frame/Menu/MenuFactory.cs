
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO; 

namespace Lemonade.Frame.Menu 
{
    /// <summary>
    /// 菜单工厂
    /// </summary>
    public class MenuFactory
    {
        /// <summary>
        /// 主窗体
        /// </summary>
        protected Form menuForm = null;
        /// <summary>
        /// 菜单工程接口
        /// </summary>
        protected IMenuItemFactory itemFac = null;
        /// <summary>
        /// 系统菜单
        /// </summary>
        protected MenuStrip strip = null;
         
        /// <summary>
        /// 菜单工厂
        /// </summary>
        /// <param name="MenuForm">菜单窗口</param>
        /// <param name="ItemFac">菜单项工厂实例</param>
        public MenuFactory(Form MenuForm,IMenuItemFactory ItemFac)
        {
            this.menuForm = MenuForm;
            this.itemFac = ItemFac;
        }

        /// <summary>
        /// 设置菜单
        /// </summary>
        /// <returns></returns>
        public void SetMenuStrip()
        {
            Dictionary<string, PtMenuItem> items = this.itemFac.CreateMenuItems(); 
            strip = CreateStrip(items);
            strip.Dock = DockStyle.Top; 
           
        }
       
        /// <summary>
        /// 添加菜单控件到窗体
        /// </summary>
        public void AddMenuControl()
        {
            this.menuForm.MainMenuStrip = strip;
            this.menuForm.Controls.Add(strip); 
 
        }
        /// <summary>
        /// 创建菜单栏实例
        /// </summary>
        /// <param name="Items"></param>
        /// <returns></returns>
        protected virtual MenuStrip CreateStrip(Dictionary<string, PtMenuItem> Items)
        {
            MenuStrip strip = new MenuStrip();
            Lemonade.Frame.Running.IRunningRules rules = Lemonade.Frame.Running.LemonEnvironment.GetInstance().Rules;
            foreach (PtMenuItem item in Items.Values)
            {
                if (rules.IsVisibleMenuItem(item))
                {
                    strip.MdiWindowListItem = item;
                    strip.Items.Add(item);
                }
            } 
            return strip;
        }


 
    }
}
