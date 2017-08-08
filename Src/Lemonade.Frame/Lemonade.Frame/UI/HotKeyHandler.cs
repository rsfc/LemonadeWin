using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Protein.Enzyme.Repository;

namespace Lemonade.Frame.UI
{ 
    /// <summary>
    /// 热键管理
    /// </summary>
    internal class HotKeyHandler
    {
        protected Dictionary<KeyEventHandler, Keys> keyshandler = new Dictionary<KeyEventHandler, Keys>();
        /// <summary>
        /// 目标窗体
        /// </summary>
        public Form TargetForm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TargetForm"></param>
        public HotKeyHandler(Form TargetForm)
        {
            this.TargetForm = TargetForm;
        }

        /// <summary>
        /// 注册快捷键
        /// </summary>
        public void RegisterHotKey(Keys HotKeyValue,KeyEventHandler Handler)
        {
            if (!this.keyshandler.Keys.Contains(Handler))
            {
                this.keyshandler.Add(Handler, HotKeyValue);
            }
        }

        /// <summary>
        /// 注销快捷键
        /// </summary>
        public void UnRegisterHotKey(KeyEventHandler Handler)
        {
            this.keyshandler.Remove(Handler); 
        }
        /// <summary>
        /// 使用热键
        /// </summary>
        public   void UseHotkeys()
        { 
            if (this.TargetForm != null)
            {
                this.TargetForm.KeyDown += new KeyEventHandler(TargetForm_KeyDown);
            }
        }
        /// <summary>
        /// 不使用热键
        /// </summary>
        public   void UnUseHotkeys()
        {
            if (this.TargetForm != null)
            {
                this.TargetForm.KeyDown -= new KeyEventHandler(TargetForm_KeyDown);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected   void TargetForm_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (KeyEventHandler k in this.keyshandler.Keys)
            {
                if (this.keyshandler[k] == e.KeyCode)
                {
                    k(sender, e);
                    if (e.SuppressKeyPress)
                    {
                        break;
                    }
                }
            } 
        }


    }
}
