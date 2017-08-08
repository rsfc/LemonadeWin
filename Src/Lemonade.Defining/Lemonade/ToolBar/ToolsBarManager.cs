using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;
using System.Windows.Forms;
using Lemonade.Frame.Tools;
using Lemonade.ToolBar.Items;
using Lemonade.ToolBar.Datas;

namespace Lemonade.ToolBar
{
    /// <summary>
    /// 工具栏管理器
    /// </summary>
    public class ToolsBarManager :IToolsBarManager
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TargetForm"></param>
        /// <param name="ToolStrip"></param>
        delegate void SetToolsBar(Form TargetForm,ToolStrip ToolStrip);
        /// <summary>
        /// 工具栏设置
        /// </summary>
        ToolsBarSetting barsetting = null;
        /// <summary>
        /// 工具栏构造器
        /// </summary>
        ToolsItemProcess tiemProcess = null;
        /// <summary>
        /// 工具栏管理器
        /// </summary>
        public ToolsBarManager()
        {
            tiemProcess = new ToolsItemProcessButton();
            tiemProcess.NextProcess = new ToolsItemProcessSeparator();
            tiemProcess.NextProcess.NextProcess = new ToolsItemProcessComboBox();
        }
        /// <summary>
        /// 加载工具栏
        /// </summary>
        public  void LoadToolsBar()
        {
            object tbs = Lemon.Deserialize(typeof(ToolsBarData), Lemon.GetCSFRootDirectory() + @"\ToolBar\ToolsBarData.xml"); 
            if (tbs != null)
            {
               //转换为工具栏  
               ToolsBarFactroy tbfac = new ToolsBarFactroy((ToolsBarData)tbs);
               this.barsetting = tbfac.BarSetting;
               if (this.barsetting != null)
               {
                   tbfac.BuildToolsButton();
               }
           
            }

        }
      
 
        /// <summary>
        /// 获取工具栏数量
        /// </summary>
        public int ToolsBarCount
        {
            get { return this.barsetting.Bars.Count; }
        }

        /// <summary>
        /// 获取工具栏名称集合
        /// </summary>
        public List<string> ToolsBarNames
        {
            get {
                List<string> result = new List<string>();
                foreach (IToolsBar tb in this.barsetting.Bars)
                {
                    result.Add(tb.ToolsBarName);
                }
                return result; 
            }
        }

        /// <summary>
        /// 工具栏所属窗体集合
        /// </summary>
        public List<string> ParentFormNames
        {
            get
            {
                List<string> result = new List<string>();
                foreach (IToolsBar tb in this.barsetting.Bars)
                {
                    result.Add(tb.ParentFormName);
                }
                return result;
            }
        }


        /// <summary>
        /// 获取指定索引的工具栏对象
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public IToolsBar this[int Index]
        {
            get {
                if (this.barsetting.Bars.Count > Index)
                {
                    IToolsBar tb = this.barsetting.Bars[Index];
                    return tb;
                }
                else
                {
                    return null;
                }
            
            }
        }

 
        /// <summary>
        /// 根据窗体名称创建工具栏
        /// </summary>
        /// <param name="TargetForm"></param>
        public void CreateToolsBarToForm(Form TargetForm)
        {
            ToolStrip strip = this.CreateToolsBar(TargetForm); 
            if (strip!=null)
            {
                strip.MouseMove += new MouseEventHandler(Strip_MouseMove);
                TargetForm.Invoke(new SetToolsBar(AddControl), TargetForm,strip);  
            } 
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Strip_MouseMove(object sender, MouseEventArgs e)
        {
            ((ToolStrip)sender).Focus();
        }
        /// <summary>
        /// 添加到窗体中,判断控件的索引
        /// </summary>
        /// <param name="TargetForm"></param>
        /// <param name="Strip"></param>
        protected virtual void AddControl(Form TargetForm,ToolStrip Strip)
        {
            Control extCtrl = TargetForm.Controls[Strip.Name];
            if (extCtrl != null)
            {
                TargetForm.Controls.Remove(extCtrl);
            }
            TargetForm.Controls.Add(Strip);
            TargetForm.Controls.SetChildIndex(Strip,0);
            TargetForm.Refresh();
        }

        /// <summary>
        /// 创建工具栏   
        /// </summary>
        protected ToolStrip CreateToolsBar(Form TargetForm) 
        {
            ToolStrip ts=null;
            try
            {
                foreach (IToolsBar tb in this.barsetting.Bars)
                {
                    if (tb.ParentFormName == TargetForm.Text)
                    {
                        List<ToolStripItem> tsis = new List<ToolStripItem>();
                        //
                        foreach (IToolsItem iti in tb.GetItems())
                        {

                            ToolStripItem newTsi = this.tiemProcess.BuildItem(iti);
                            if (newTsi != null)
                            {
                                iti.HostObject = newTsi;
                                if (iti.UIElement != null)
                                {
                                    iti.UIElement.ParentForm = TargetForm;
                                }
                                tsis.Add(newTsi);
                            }
                        }


                        //判断当前窗体是否已经存在同名的工具栏
                        Control control = TargetForm.Controls[tb.ToolsBarName];
                        if (control != null)
                        {
                            if (control.GetType() == typeof(ToolStrip))
                            {
                                ts = control as ToolStrip;
                                ts.Items.AddRange(tsis.ToArray());
                            }
                        }

                        if (ts == null)
                        {
                            ts = new ToolStrip(tsis.ToArray());
                            ts.Name = tb.ToolsBarName;
                        }

                    }
                }
                return ts;
            }
            catch (Exception ex)
            {
                Lemon.SendMsgError(ex);
                return null;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="GroupName"></param>
        /// <returns></returns>
        public List<IToolsItem> GetGroupItem(string GroupName)
        {
            var s = this.barsetting.Buttons.FindAll(delegate(ToolsButton tb) { return tb.GroupName == GroupName; });
            List<IToolsItem> result=new List<IToolsItem>();
            if (s != null)
            {
                foreach (ToolsButton tmpTb in s)
                {
                    result.Add((IToolsItem)tmpTb);
                }
            }
            return result;
        }

        /// <summary>
        /// 获取工具栏项
        /// </summary>
        /// <returns></returns>
        public List<IToolsItem> GetItemAll()
        {
            List<IToolsItem> result = new List<IToolsItem>();
            foreach (IToolsBar tb in this.barsetting.Bars)
            {  
                foreach (IToolsItem iti in tb.GetItems())
                {
                    result.Add(iti);
                }
                
            } 
            return result;
        }
    }

}
