using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lemonade.Frame;
using System.Reflection;
using Lemonade.Frame.Module;
using Lemonade.Frame.Running;
namespace Lemonade.Samples.Console
{ 
    /// <summary>
    /// 关于
    /// </summary>
    public partial class FrmLemonadeModuleInfo:Form,IModule
    {
        /// <summary>
        /// 
        /// </summary>
        public FrmLemonadeModuleInfo()
        {
            InitializeComponent();
        } 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual  void FrmAbout_Load(object sender, EventArgs e)
        {
            LemonadeVersion();
            ModulesVersion();
        }

        /// <summary>
        /// 框架版本
        /// </summary>
        protected virtual void LemonadeVersion()
        {
            this.listBox2.Items.Clear(); 
            ILemonEnvironment envir = LemonEnvironment.GetInstance(); 
            Dictionary<string, string> asmdic = new Dictionary<string, string>();
            this.SetValue(envir.ActionsManager,ref asmdic);
            this.SetValue(envir.CSFMain, ref asmdic);
            this.SetValue(envir.Guardian, ref asmdic);
            this.SetValue(envir.MenuItemFactory, ref asmdic);
            this.SetValue(envir.ModuleHandles, ref asmdic);
            this.SetValue(envir.ModuleManager, ref asmdic);
            this.SetValue(envir.SwapPool, ref asmdic);
            this.SetValue(envir.ToolsBarManager, ref asmdic);
            this.SetValue(envir.UIManager, ref asmdic);
            //foreach (ModuleInfo info in Lemon.ModuleInfos)
            //{  

            //    string name = envir.ActionsManager.GetType().Name;
            //    string version = envir.ActionsManager.GetType().Assembly.GetName().Version.ToString();
            //    if (!asmdic.ContainsKey(name))
            //    {
            //        asmdic.Add(name, version);
            //    }
            //}  
            foreach (string kname in asmdic.Keys)
            {
                this.listBox2.Items.Add(kname + "    " + asmdic[kname].ToString());
            }

        }
        /// <summary>
        /// 
        /// </summary>
        protected virtual void SetValue(object Obj, ref  Dictionary<string, string> Dic)
        {
            if (Obj != null)
            {
                Type t = Lemon.GetObjType(Obj);
                string name = t.Name;
                string version = t.Assembly.GetName().Version.ToString();
                if (!Dic.ContainsKey(name))
                {
                    Dic.Add(name, version);
                }
            }
            
            
        }
        /// <summary>
        /// 插件版本
        /// </summary>
        protected virtual void ModulesVersion()
        {
            this.listBox1.Items.Clear();
            Dictionary<string, string> asmdic = new Dictionary<string, string>(); 
            foreach (ModuleInfo info   in Lemon.ModuleInfos)
            {  
                //加载模块读取版本 
                if (!System.IO.File.Exists(info.AssemblyPath))
                {
                    continue;
                }
                Assembly asm = Assembly.LoadFile(info.AssemblyPath);
                string name = asm.GetName().Name;
                string version = asm.GetName().Version.ToString(); 
                if (!asmdic.ContainsKey(name))
                {
                    asmdic.Add(name, version);
                }  
            } 
            string mainversion = this.MainForm.GetType().Assembly.GetName().Version.ToString();
            this.listBox1.Items.Add(this.MainForm.GetType().Assembly.GetName().Name+ "    " + mainversion); 
            foreach (string kname in asmdic.Keys)
            {
                this.listBox1.Items.Add(kname + "    " + asmdic[kname].ToString());
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Initialize()
        {
            //Lemon.SetFormDefaultStyle(this);
            this.Show();
        }

        public IMainForm MainForm
        {
            get;
            set;
        }

        public string ModuleAlias
        {
            get {
                return "关于";
            }
        }

        public string ModuleName
        {
            get;
            set;
        }

        public void RunCache()
        {
            this.Show();
        }
    }



}