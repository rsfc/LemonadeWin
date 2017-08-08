using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;     
using Lemonade.Frame; 
using Lemonade.Frame.UI;
using System.Runtime.InteropServices;


namespace Lemonade.Samples.LayoutSplitB
{
    /// <summary>
    /// 框架布局分栏B
    /// </summary>
    public class LayoutSplitB :ILayout
    {
        private delegate void ProcessCallBack(Form Target);  
        /// <summary>
        /// 容器集合
        /// </summary>
        public Dictionary<int, Panel> panels = new Dictionary<int, Panel>();
        /// <summary>
        /// 分栏集合
        /// </summary>
        public Dictionary<int, SplitContainer> splitconts = new Dictionary<int, SplitContainer>();
        /// <summary>
        /// 存在的窗体
        /// </summary>
        public Dictionary<int, Form> existForm = new Dictionary<int, Form>();
        /// <summary>
        /// 主界面
        /// </summary>
        IMainForm mainForm = null;
        /// <summary>
        /// 主分栏
        /// </summary>
        SplitContainer spc = null;

        /// <summary>
        /// 
        /// </summary>
        public LayoutSplitBConfig UIConfig
        {
            get;
            set;
        }
         
        /// <summary>
        /// 
        /// </summary>
        public LayoutSplitB() 
        {
            object tmpobj = Lemon.Deserialize(typeof(LayoutSplitBConfig), Lemon.GetCSFRootDirectory() + @"Styles\LayoutSplitBConfig.xml");
            if (tmpobj != null)
            {
                this.UIConfig = (LayoutSplitBConfig)tmpobj;
                
            }
        }

        /// <summary>
        /// 创建布局
        /// </summary>
        public virtual void CreateLayout(IMainForm MainForm)
        { 
            this.spc = this.CreateSplitVertical();
            ((Form)MainForm).Controls.Add(spc);
            this.mainForm = MainForm;
            ExamineForm();
        }
        /// <summary>
        /// 检查当前的窗体 在创建布局时运行
        /// </summary>
        protected virtual void ExamineForm()
        { 
            List<Form> frms = Lemon.GetOpenForms();
            foreach (Form f in frms)
            {
                this.SetLayoutForm(f);
            }
        }

        /// <summary>
        /// 创建分栏 
        /// </summary>
        protected virtual SplitContainer CreateSplitVertical()
        { 
            ///主分栏
            SplitContainer spc1 = new SplitContainer();
            spc1.Name = "LayoutSplitBSplitContainer1";
            spc1.Parent = (Form)this.mainForm;
            spc1.Dock = DockStyle.Fill;
            //spc1.Width = ((Form)this.mainForm).Width;
            //spc1.Height = ((Form)this.mainForm).Height - ((Form)this.mainForm).MainMenuStrip.Height-20;
            spc1.Orientation = Orientation.Vertical;
            this.splitconts.Add(1, spc1);
            ///左分栏
            SplitContainer spc2 = new SplitContainer();
            spc2.Dock = DockStyle.Fill;
            spc2.Orientation = Orientation.Horizontal;
            spc1.Panel1.Controls.Add(spc2);
            this.panels.Add(1, spc2.Panel1);
            this.panels.Add(2, spc2.Panel2);
            this.splitconts.Add(2, spc2);
            //设置spc1宽度  
            SplitRegion sp = this.UIConfig.LayoutRegion.Find(delegate(SplitRegion sr) { return sr.SplitPanelIndex == 1; });
            if (sp != null)
            {
                spc1.SplitterDistance = sp.Width;
                spc2.SplitterDistance = sp.Height;
            }

            ///右分栏A
            SplitContainer spc3 = new SplitContainer();
            spc3.Dock = DockStyle.Fill;
            spc3.Orientation = Orientation.Horizontal;
            spc1.Panel2.Controls.Add(spc3);
            this.panels.Add(3, spc3.Panel1);
            this.splitconts.Add(3, spc3);
            //设置spc3宽度和高度
            sp = this.UIConfig.LayoutRegion.Find(delegate(SplitRegion sr) { return sr.SplitPanelIndex == 3; });
            if (sp != null)
            {
                spc3.SplitterDistance = sp.Height;
            }
            this.panels.Add(4, spc3.Panel2);
            return spc1;
        }



        /// <summary>
        /// 查找打开的窗口
        /// </summary>
        /// <returns></returns>
        protected Dictionary<SplitRegion, Form> FindOpenForm(Form TargetForm)
        {
            Dictionary<SplitRegion, Form> forms = new Dictionary<SplitRegion, Form>();  
            this.SetCheckForm(TargetForm, this.UIConfig.LayoutRegion.Find(delegate(SplitRegion sr) { return sr.SplitPanelIndex == 1; }), forms);
            this.SetCheckForm(TargetForm, this.UIConfig.LayoutRegion.Find(delegate(SplitRegion sr) { return sr.SplitPanelIndex == 2; }), forms);
            this.SetCheckForm(TargetForm, this.UIConfig.LayoutRegion.Find(delegate(SplitRegion sr) { return sr.SplitPanelIndex == 3; }), forms);
            this.SetCheckForm(TargetForm, this.UIConfig.LayoutRegion.Find(delegate(SplitRegion sr) { return sr.SplitPanelIndex == 4; }), forms);
            return forms;
        }


        /// <summary>
        /// 判断指定的窗体集合中是否包含当前参数指定的区域所赋值的窗体名称
        /// </summary>
        /// <param name="Region"></param>
        /// <returns></returns>
        protected void SetCheckForm(Form Frm, SplitRegion Region, Dictionary<SplitRegion, Form> DesDic)
        { 
            if (Region.FormClassName.Contains(Lemon.GetObjType(Frm).FullName))
            {
                DesDic.Add(Region, Frm);
            } 
        }
        /// <summary>
        /// 设置布局窗口和调整样式
        /// </summary>
        /// <param name="TargetForm"></param>
        public bool SetLayoutForm(Form TargetForm)
        {
            //判断是否属于受控制的窗体
            if (this.Controlleds.Contains(Lemon.GetObjType(TargetForm).FullName))
            {
                ProcessCallBack pcb = new ProcessCallBack(ThePCB);
                ((Form)this.mainForm).Invoke(pcb, TargetForm);
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 设置布局窗口和调整样式
        /// </summary>
        protected virtual void ThePCB(Form Target)
        {
            this.SetPanel(Target);
            //this.SetStyle();
            this.SetStyle2();
        }



        /// <summary>
        /// 设置当前所有窗口的布局样式
        /// </summary>
        protected void SetPanel(Form TargetForm)
        {
            //获取当前所有运行的模块
            Dictionary<SplitRegion, Form> formlist = this.FindOpenForm(TargetForm); 
            //运行配置中已经指定样式的模块，判断是否自动运行  
            //构造ui结构 有些小bug需要分开处理
            foreach (SplitRegion sr in formlist.Keys)
            {
                int tmpIndex = sr.SplitPanelIndex;//formlist.Keys.ToList().IndexOf(sr)+1;
                if (this.existForm.ContainsKey(tmpIndex))
                {
                    if (this.existForm[tmpIndex] != null)
                    {
                        this.existForm[tmpIndex].Close();
                    }
                    this.existForm.Remove(tmpIndex);
                } 
                this.existForm.Add(tmpIndex, TargetForm); 
                Form frm = formlist[sr];
                frm.WindowState = FormWindowState.Maximized;
                if (tmpIndex == 1 || tmpIndex == 3 )
                {
                    frm.FormBorderStyle = FormBorderStyle.FixedDialog;
                }
                else
                {
                    frm.FormBorderStyle = FormBorderStyle.None;
                }
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.ShowIcon = false;
                frm.ShowInTaskbar = false;
                frm.TopLevel = false;
                //判断是否存在对象
                this.panels[tmpIndex].Controls.Add(frm); 
                frm.Dock = DockStyle.Fill; 
            } 
        }
         
       
        /// <summary>
        /// 设置样式
        /// </summary>
        protected void SetStyle()
        {
            foreach (int index in this.splitconts.Keys)
            {
                SplitRegion tmpsr= this.UIConfig.LayoutRegion.Find(delegate(SplitRegion sr) { return sr.SplitPanelIndex == index; });
                if (this.splitconts[index].Orientation == Orientation.Horizontal)
                {
                    SetPanelStyleVertical(this.splitconts[index], tmpsr);
                }
                else
                {
                    SetPanelStyleHorizontal(this.splitconts[index], tmpsr);
                } 
            }
        }
        /// <summary>
        /// 写死设置样式 完全靠配置文件调整宽度和大小
        /// </summary>
        protected void SetStyle2()
        {
            SetSplitterDis(this.splitconts[2], this.UIConfig.LayoutRegion[0].Height);
            SetSplitterDis(this.splitconts[1], this.UIConfig.LayoutRegion[0].Width);
            SetSplitterDis(this.splitconts[3], this.UIConfig.LayoutRegion[2].Width);
        }
        /// <summary>
        /// 设置分栏样式高设置
        /// </summary>
        /// <param name="TargetSc"></param>
        /// <param name="Sr"></param>
        protected void SetPanelStyleVertical(SplitContainer TargetSc, SplitRegion Sr)
        {
            bool tophas = IsSetChild(TargetSc.Panel1);
            bool downhas = IsSetChild(TargetSc.Panel2);
            //上有下没有
            if (tophas && !downhas)
            {
                this.SetSplitterDis(TargetSc, TargetSc.Height);
            }
            //上有下有
            if (tophas && downhas)
            {
                this.SetSplitterDis(TargetSc, Sr.Height);
            }
            //上没有下有
            if (!tophas && downhas)
            {
                this.SetSplitterDis(TargetSc, 0);
            } 
        }

        /// <summary>
        /// 设置分栏样式高设置
        /// </summary>
        /// <param name="TargetSc"></param>
        /// <param name="Sr"></param>
        protected void SetPanelStyleHorizontal(SplitContainer TargetSc, SplitRegion Sr)
        {
            bool lefthas = IsSetChild(TargetSc.Panel1);
            bool righthas=IsSetChild(TargetSc.Panel2);
            //左有右没有
            if (lefthas && !righthas)
            {
                this.SetSplitterDis(TargetSc, TargetSc.Width);
            }
            else
            { 
            
            }
            //左有右有
            if (lefthas && righthas)
            {
                this.SetSplitterDis(TargetSc, Sr.Width);
            }
            //左没有右有
            if (lefthas && righthas)
            {
                this.SetSplitterDis(TargetSc, 0);
            }
        }
        
        /// <summary>
        /// 设置分栏距离,确保不会出现异常值
        /// </summary>
        protected virtual void SetSplitterDis(SplitContainer Sc,int TargetDis)
        {
            int n1 = Sc.Width - Sc.Panel2MinSize;
            if (n1 == 0)
            {
                return;
            }
            if (Sc.Panel1MinSize < TargetDis && TargetDis < n1)
            {
                Sc.SplitterDistance = TargetDis;
            }
            else 
            {
                int dsi = TargetDis - 1;
                if (dsi > 0)
                {
                    Sc.SplitterDistance = dsi;
                }
            }
        }


        /// <summary>
        /// 是否存在非分栏控件的控件对象
        /// </summary>
        /// <param name="SplitCont"></param>
        /// <returns></returns>
        protected virtual bool IsSetChild(Panel PanelObj)
        { 
            bool result=false;
            if (PanelObj.Controls.Count >= 0)
            {
                foreach (Control ctl in PanelObj.Controls)
                {
                    if (ctl.GetType() != typeof(SplitContainer))
                    {
                        result=true;
                        return result;
                    }
                    else
                    { 
                        //判断子控件
                        result = IsSetChild(((SplitContainer)ctl).Panel1);
                        if (result)
                        {
                            return result; 
                        }
                        result = IsSetChild(((SplitContainer)ctl).Panel2);
                        if (result)
                        {
                            return result; 
                        }
                    }
                } 
            } 
            return result;
        } 

        /// <summary>
        /// 布局名称
        /// </summary>
        public string LayoutName
        {
            get { return "框架布局分栏B"; }
        }
        
        
        /// <summary>
        /// 保存大小等
        /// </summary>
        /// <param name="MainForm"></param>
        public void SaveLayout(IMainForm MainForm)
        {
             
        }

        /// <summary>
        /// 当前布局控制的窗体名称集合
        /// </summary>
        public List<string> Controlleds
        {
            get {
                List<string> result = new List<string>();
                result.AddRange(this.GetNames(this.UIConfig.LayoutRegion.Find(delegate(SplitRegion sr) { return sr.SplitPanelIndex == 1; })));
                result.AddRange(this.GetNames(this.UIConfig.LayoutRegion.Find(delegate(SplitRegion sr) { return sr.SplitPanelIndex == 2; })));
                result.AddRange(this.GetNames(this.UIConfig.LayoutRegion.Find(delegate(SplitRegion sr) { return sr.SplitPanelIndex == 3; })));
                result.AddRange(this.GetNames(this.UIConfig.LayoutRegion.Find(delegate(SplitRegion sr) { return sr.SplitPanelIndex == 4; })));
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Region"></param>
        /// <returns></returns>
        private List<string> GetNames(SplitRegion Region)
        {
            List<string> result = new List<string>();
            foreach (string s in Region.FormClassName)
            {
                result.Add(s);
            }
            return result; 
        }

        /// <summary>
        /// 取消布局
        /// </summary>
        public void CancelLayout()
        { 
            List<int> tmpList = new List<int>();
            foreach (int key in this.existForm.Keys)
            {
                tmpList.Add(key);
            }
            foreach (int index in tmpList)
            {
                if (!this.existForm[index].IsDisposed)
                {
                    this.existForm[index].Parent.Controls.Remove(this.existForm[index]);
                    ((Form)this.mainForm).Controls.Add(this.existForm[index]);
                    this.existForm[index].MdiParent = ((Form)this.mainForm); 
                }  
                //Lemon.SetFormDefaultStyle(this.existForm[index]);
                this.existForm.Remove(index);
            }

            ((Form)this.mainForm).Controls.Remove(this.spc);
            this.spc.Visible = false;
            this.spc.Dispose();
            this.spc = null;
            this.panels=new Dictionary<int,Panel>();
            this.splitconts=new Dictionary<int,SplitContainer>();
            this.existForm=new Dictionary<int,Form>();
       
        }

       
    }
}
