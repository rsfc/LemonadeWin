using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.UI;
using Lemonade.Frame.Running;
using System.Windows.Forms;
using Lemonade.Frame.Tools;
namespace Lemonade.Frame
{
    /// <summary>
    /// 框架通用功能入口 
    /// </summary>
    public static partial class Lemon
    {
        #region 界面功能
        delegate void SetWindow(Form TargetForm);
        /// <summary>
        /// 获取当前框架运行的界面布局名称
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentLayoutName()
        {
            if (LemonEnvironment.GetInstance().UIManager != null)
            {
                return LemonEnvironment.GetInstance().UIManager.CurrentLayoutName;
            }
            else {
                return "";
            }
        }

        /// <summary>
        /// 获取当前所有打开的窗体，如果需要使用类似功能请使用框架封装的函数，而不是直接使用.net的功能，这是除了等待窗体以外的所有窗体
        /// </summary>
        /// <returns></returns>
        public static List<Form> GetOpenAllForms()
        {
            //这里有个问题 在默认布局打开新窗体时 无法获取到这个窗体
            FormCollection forms = Application.OpenForms;
            //排除等待窗体
            List<Form> list = new List<Form>();
            foreach (Form f in forms)
            {
                if (f.GetType().GetInterface("IWaitionForm") == null )
                {
                    list.Add(f);
                }
            }
            return list;
        }
        /// <summary>
        /// 再打开的窗体中获取指定名称的窗体
        /// </summary>
        /// <param name="FormName"></param>
        /// <returns></returns>
        public static Form GetForm(string FormName)
        {
            List<Form> forms = Lemon.GetOpenAllForms();
            var f = forms.Find(delegate(Form frm) { return frm.Text == FormName; });
            return f;
        }

        /// <summary>
        /// 获取当前所有打开的窗体，如果需要使用类似功能请使用框架封装的函数，而不是直接使用.net的功能
        /// </summary>
        /// <returns></returns>
        public static List<Form> GetOpenForms()
        {
            //这里有个问题 在默认布局打开新窗体时 无法获取到这个窗体
            FormCollection forms = Application.OpenForms;
            //排除等待窗体
            List<Form> list = new List<Form>();
            foreach (Form f in forms)
            {
                if (f.GetType().GetInterface("ILoadDisplay") == null
                    && f.GetType().GetInterface("IWaitionForm") == null
                    && f.GetType().GetInterface("ILoadSystem") == null)
                {
                    list.Add(f);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取当前可以控制的窗体名称
        /// </summary>
        /// <returns></returns>
        public static List<string> GetLayoutForms()
        {
            return LemonEnvironment.GetInstance().UIManager.GetControlleds;
        }

        /// <summary>
        /// 获取当前打开的允许框架托管样式的窗口，
        /// 也就是运行布局控制的窗口
        /// </summary>
        /// <returns></returns>
        public static List<Form> GetOpenFormsFrame()
        {
            FormCollection forms = Application.OpenForms; 
            List<string> ctlFrms = Lemon.GetLayoutForms(); 
            List<Form> list = new List<Form>();
            foreach (Form f in forms)
            {
                if (ctlFrms.Contains(Lemon.GetObjType(f).FullName))
                {
                    list.Add(f);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取框架的界面管理器,设置窗体的样式，这是框架对所有窗体设置的入口方法
        /// </summary>
        /// <returns></returns>
        public static bool SetLayoutWindowStyle(Form TargetWindow)
        {
            if (LemonEnvironment.GetInstance().UIManager != null)
            {
                return LemonEnvironment.GetInstance().UIManager.SetLayoutWindow(TargetWindow);
            }
            else
            {
                Lemon.SendMsgError("UI管理器没有正常实例化，框架无法设置窗体样式。");
                return false;
            }
        }
        ///// <summary>
        ///// 对参数窗体进行基本样式设置， 置顶窗口
        ///// </summary>
        ///// <param name="TargetForm"></param>
        //public static void SetFormDefaultStyleTopMost(Form TargetForm)
        //{
        //    TargetForm.WindowState = FormWindowState.Normal;
        //    TargetForm.FormBorderStyle = FormBorderStyle.FixedDialog;
        //    TargetForm.TopMost = true;
        //    TargetForm.ShowIcon = false;
        //    TargetForm.ShowInTaskbar = false; 
        //    TargetForm.MaximizeBox = false;
        //    TargetForm.MinimizeBox = false;
        //    TargetForm.Dock = DockStyle.None;
        //}
        ///// <summary>
        ///// 对参数窗体进行基本样式设置，使其融入框架风格
        ///// </summary>
        ///// <param name="TargetForm"></param>
        //public static void SetFormDefaultStyle(Form TargetForm)
        //{
        //    TargetForm.Invoke(new SetWindow(FormDefaultStyle),TargetForm);
            
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="TargetForm"></param>
        //private static void FormDefaultStyle(Form TargetForm)
        //{
        //    TargetForm.WindowState = FormWindowState.Normal;
        //    TargetForm.FormBorderStyle = FormBorderStyle.FixedDialog;
        //    TargetForm.TopMost = true;
        //    TargetForm.ShowIcon = false;
        //    TargetForm.ShowInTaskbar = false;
        //    TargetForm.MdiParent = (Form)Lemon.GetMainForm();
        //    TargetForm.MaximizeBox = false;
        //    TargetForm.MinimizeBox = false;
        //    TargetForm.Dock = DockStyle.None; 
        //}
        /// <summary>
        /// 设置框架的布局
        /// </summary>
        /// <param name="LayoutName"></param>
        public static void SetLayout(string LayoutName)
        {
            if (LemonEnvironment.GetInstance().UIManager != null)
            {
                LemonEnvironment.GetInstance().UIManager.SetLayout(LayoutName);
            } 
        }
        /// <summary>
        /// 获取当前的布局
        /// </summary>
        /// <returns></returns>
        public static ILayout GetLayoutCurrent()
        {
            if (LemonEnvironment.GetInstance().UIManager != null)
            {
                return LemonEnvironment.GetInstance().UIManager.GetLayout(LemonEnvironment.GetInstance().UIManager.CurrentLayoutName);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取具备工具栏配置的窗体名称列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetToolsBarFormName()
        {
            Tools.IToolsBarManager manager = LemonEnvironment.GetInstance().ToolsBarManager;
            if (manager != null)
            {
                return manager.ParentFormNames;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 设置窗体工具栏
        /// </summary>
        /// <returns></returns>
        public static void SetWindowToolsBar(Form TargetForm)
        {
            Tools.IToolsBarManager manager = LemonEnvironment.GetInstance().ToolsBarManager;
            if (manager != null)
            {
                manager.CreateToolsBarToForm(TargetForm);
            } 
        }

        /// <summary>
        /// 获取分组工具栏项
        /// </summary>
        /// <returns></returns>
        public static List<IToolsItem> GetGroupToolsItem(string GroupName)
        {
            Tools.IToolsBarManager manager = LemonEnvironment.GetInstance().ToolsBarManager;
            if (manager != null)
            {
                return manager.GetGroupItem(GroupName);
            }
            return null;
        }

        /// <summary>
        /// 获取分组工具栏项
        /// </summary>
        /// <returns></returns>
        public static List<IToolsItem> GetToolsItem()
        {
            Tools.IToolsBarManager manager = LemonEnvironment.GetInstance().ToolsBarManager;
            if (manager != null)
            {
                return manager.GetItemAll();
            }
            return null;
        }

        
        /// <summary>
        /// 设置皮肤
        /// </summary>
        /// <param name="Index"></param>
        public static void SetSkill(int Index)
        {
            if (Lemon.GetMainForm() != null)
            {
                //Lemon.GetMainForm().SetSkill(Index);
            }
        }

        
       

        #endregion

        #region 热键

        //static HotKeyHandler systemhotkeyhandle=null;
        ///// <summary>
        ///// 使用系统热键
        ///// </summary>
        //public static void UseSystemHotkeys()
        //{
        //    Form main = Lemon.GetMainForm() as Form;
        //    if (main != null)
        //    {
        //        systemhotkeyhandle=new HotKeyHandler(main);
        //        systemhotkeyhandle.UseHotkeys(); 
        //    }
        //}

        ///// <summary>
        ///// 不使用系统热键
        ///// </summary>
        //public static void UnUseSystemHotkeys()
        //{
        //    if (systemhotkeyhandle != null)
        //    {
        //        systemhotkeyhandle.UnUseHotkeys();
        //    } 
        //}

        ///// <summary>
        ///// 注册快捷键处理委托
        ///// </summary>
        ///// <param name="HotKeyValue"></param>
        ///// <param name="Handler"></param>
        //public static void RegisterHotKey(Keys HotKeyValue, KeyEventHandler Handler)
        //{
        //    if (systemhotkeyhandle != null)
        //    {
        //        systemhotkeyhandle.RegisterHotKey(HotKeyValue, Handler);
        //    } 
        //}

        ///// <summary>
        ///// 取消快捷键处理委托
        ///// </summary>
        ///// <param name="Handler"></param>
        //public static void UnRegisterHotKey(KeyEventHandler Handler)
        //{
        //    if (systemhotkeyhandle != null)
        //    {
        //        systemhotkeyhandle.UnRegisterHotKey(Handler);
        //    }
        //}

        #endregion
    }
}
