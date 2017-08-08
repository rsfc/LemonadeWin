using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;
using Lemonade.Frame.UI;
using Lemonade.Frame.Solon;
using System.Diagnostics;
using System.Windows.Forms;
using Lemonade.Frame.Tools;

namespace Lemonade.Nazgul.UIElement
{
    /// <summary>
    /// 设置元素
    /// </summary>
    public class SetElement : INazgulSkill
    {
        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="ControlObj"></param>
        /// <param name="UIE"></param>
        delegate void SetValue(object ControlObj, IUIElement UIE);
        private Object thisLock = new Object(); 
        /// <summary>
        /// 
        /// </summary>
        public int Cooldown
        {
            get { return 200; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsContinuous
        {
            get { 
                return true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SkillName
        {
            get { return "设置ui元素"; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UseSkill(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (thisLock)
            {
                this.SetToolItems();
            }
        }

        /// <summary>
        /// 设置工具栏项
        /// </summary>
        protected void SetToolItems()
        {
            try
            {
                List<IToolsItem> items = Lemon.GetToolsItem();
                if (items != null)
                {
                    foreach (IToolsItem item in items)
                    {
                        if (Lemon.GetObjType(item.HostObject) == typeof(ToolStripButton))
                        {
                            Control mf = (Control)Lemon.GetMainForm();
                            mf.Invoke(new SetValue(SetToolStripButtonValue), item.HostObject, item.UIElement);
                        }
                        else if (Lemon.GetObjType(item.HostObject) == typeof(ToolStripComboBox))
                        {  
                            Control mf = (Control)Lemon.GetMainForm();
                            mf.Invoke(new SetValue(SetToolStripComboBoxValue), item.HostObject, item.UIElement);
                        }
                       

                    }
                }
            }
            catch
            { 
            
            }
        }

        /// <summary>
        /// 设置工具栏按钮的界面元素值
        /// </summary>
        /// <param name="Tsb"></param>
        /// <param name="UIE"></param>
        protected void SetToolStripButtonValue(object ControlObj, IUIElement UIE)
        { 
         
            ToolStripButton Tsb = (ToolStripButton)ControlObj;
            Tsb.Visible = UIE.IsVisible();
            Tsb.Enabled = UIE.IsEnabled();
            Tsb.Checked = UIE.IsActive(); 
          
        }

        /// <summary>
        /// 设置工具栏按钮的界面元素值
        /// </summary>
        /// <param name="Tsb"></param>
        /// <param name="UIE"></param>
        protected void SetToolStripComboBoxValue(object ControlObj, IUIElement UIE)
        { 
            ToolStripComboBox Tsb = (ToolStripComboBox)ControlObj;
            if (UIE != null)
            {
                Tsb.Visible = UIE.IsVisible();
                Tsb.Enabled = UIE.IsEnabled();
            }
            int selectindex = -1;
            foreach (object obj in Tsb.Items)
            {
                IToolsItem tt = obj as IToolsItem;
                if (tt != null)
                {
                    if (tt.UIElement != null)
                    {
                        if (tt.UIElement.IsActive())
                        {
                            selectindex = Tsb.Items.IndexOf(obj);
                        }
                    }
                }
            }
            if (selectindex != -1 && Tsb.DroppedDown == false)
            { 
                Tsb.SelectedIndex = selectindex; 
            }
            
        }






    }
}
