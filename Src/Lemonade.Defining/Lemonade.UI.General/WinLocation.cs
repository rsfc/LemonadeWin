using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;
using Lemonade.Frame.UI;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization; 
using System.Xml;
using System.Reflection;

namespace Lemonade.UI.General
{
    /// <summary>
    /// 窗体位置
    /// </summary>
    public class WinLocation : WindowStyle
    {  
        /// <summary>
        /// 窗体位置
        /// </summary>
        public WinLocation()
        {
            
        }
        
        /// <summary>
        /// 是否使用此设置器进行ui管理
        /// </summary>
        /// <param name="TargetForm"></param>
        /// <returns></returns>
        public override bool IsUse(System.Windows.Forms.Form TargetForm)
        {
            return true;
        } 

        /// <summary>
        /// 设置位置参数
        /// </summary>
        /// <param name="TargetForm"></param>
        /// <param name="MainForm"></param>
        protected override void WinStyle(Form TargetForm, Form MainForm, ILayoutManager Manager)
        {
 
            string key = Lemon.GetObjType(TargetForm).FullName;
            StylePar sp = Manager.GetStyleParameter(key);
            if (sp != null)
            {
                TargetForm.Location = sp.Location;
                //TargetForm.Refresh();
            }
            else
            {
                StylePar newsp = new StylePar(TargetForm);
                this.UpdataStyleXML(newsp); 
            }
            TargetForm.Move -= new EventHandler(TargetForm_Move);
            TargetForm.Move += new EventHandler(TargetForm_Move); 
        }

        /// <summary>
        /// 创建样式xml
        /// </summary>
        /// <param name="TargetForm"></param>
        protected virtual void CreateStyleXML(StylePar Sp)
        { 
            string xmlfile = Lemon.GetCSFRootDirectory() + @"\Styles\Data\" + Sp.WindowClassFullName + ".xml";
            Lemon.XmlSerialize<StylePar>(xmlfile, Encoding.Unicode, Sp);
 
        }

        /// <summary>
        /// 更新样式文件
        /// </summary>
        protected virtual void UpdataStyleXML(StylePar Par)
        {
            string xmlfile=Lemon.GetCSFRootDirectory() + @"\Styles\Data\"+Par.WindowClassFullName+".xml";
            File.Delete(xmlfile);
            CreateStyleXML(Par);
        }

        /// <summary>
        /// 目标窗体移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void TargetForm_Move(object sender, EventArgs e)
        {
            StylePar sp = new StylePar((Form)sender);
            this.UpdataStyleXML(sp);
        }
    }
}
