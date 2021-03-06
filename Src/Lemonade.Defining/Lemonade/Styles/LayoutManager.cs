﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.UI;
using Lemonade.Frame;
using System.Windows.Forms;
using System.IO;

namespace Lemonade.Styles
{
    /// <summary>
    /// ui管理器
    /// </summary>
    public class LayoutManager : ILayoutManager
    { 
        /// <summary>
        /// 当前布局名称
        /// </summary>
        private string currentLayoutName = "";
        /// <summary>
        /// 布局集合
        /// </summary>
        List<ILayout> layouts = new List<ILayout>();
        /// <summary>
        /// 窗体样式设置器，这是设置器不是具体样式
        /// </summary>
        List<IWindowStyle> winstyles = new List<IWindowStyle>();
        ///// <summary>
        ///// 样式参数集合
        ///// </summary>
        //Dictionary<string, StylePar> styleparList = new Dictionary<string, StylePar>();
        /// <summary>
        ///  ui管理器
        /// </summary>
        public LayoutManager()
        {
            LocaStyle();
        }
         
        /// <summary>
        ///  获取指定名称的布局
        /// </summary>
        public ILayout GetLayout(string LayoutName)
        {
            var l = this.layouts.Find(delegate(ILayout tl) { return tl.LayoutName == LayoutName; });
                  
            return l;
        }
          
        /// <summary>
        /// 搜索所有模块程序集
        /// </summary>
        /// <returns></returns>
        protected  virtual void LocaStyle()
        {
            this.winstyles = new List<IWindowStyle>();
            string styledir = Lemon.GetCSFRootDirectory() + @"\Styles\"; 
            this.winstyles= Lemon.FindInstanceFromDirectory<IWindowStyle>(styledir,false);
            this.layouts = Lemon.FindInstanceFromDirectory<ILayout>(styledir, false);
            //styledir = Lemon.GetCSFRootDirectory() + @"\Styles\Data\"; 
            //LoadStyleXml(styledir);
        }

        

        /// <summary>
        /// 获取布局设计数量
        /// </summary>
        public int LayoutDesignCount
        {
            get { return this.layouts.Count; }
        }

        /// <summary>
        /// 获取窗体设计数量
        /// </summary>
        public int WindowStyleCount
        {
            get { return this.winstyles.Count; }
        }

        /// <summary>
        /// 获取布局设计器名称列表
        /// </summary>
        public List<string> LayoutNames
        {
            get { 
                List<string> s = new List<string>();
                foreach (ILayout l in this.layouts)
                {
                    s.Add(l.LayoutName);
                }
                return s;
            }
        }

        /// <summary>
        /// 设置布局
        /// </summary>
        /// <param name="LayoutName"></param>
        public virtual void SetLayout(string LayoutName)
        {
            if (this.layouts.Count > 0)
            {
                if (LayoutName != this.currentLayoutName)
                {
                    //先取消布局
                    this.CancelLayout();
                    ILayout culayout = this.GetLayout(LayoutName);
                    if (culayout != null)
                    {
                        culayout.CreateLayout(Lemon.GetMainForm());
                        this.currentLayoutName = LayoutName;
                    }
                    else
                    {
                        Lemon.SendMsgWarning("没有找到名称为：" + LayoutName+" 的布局");
                    }
                    
                } 
            }
        }

        /// <summary>
        /// 设置窗体样式
        /// </summary>
        /// <param name="TargetForm"></param>
        protected virtual void SetWinStyle(Form TargetForm)
        {
            for (int i = 0; i < this.winstyles.Count; i++)
            {
                if (this.winstyles[i].IsUse(TargetForm))
                {
                    this.winstyles[i].SetWindows(TargetForm,this);
                }
            }
        }

        /// <summary>
        /// 设置窗体样式,对参数传递的窗体是用所有的窗体设置器进行设置
        /// </summary>
        /// <param name="TargetForm"></param>
        public virtual bool SetLayoutWindow(Form TargetForm)
        {
            //先判断是否属于布局控制的窗体
            if (this.GetControlleds.Contains(Lemon.GetObjType(TargetForm).FullName))
            { 
                return this.GetLayout(this.currentLayoutName).SetLayoutForm(TargetForm);
            }
            else
            { 
                this.SetWinStyle(TargetForm);
                return true;
            }
           
        }
         
        /// <summary>
        /// 获取样式参数
        /// </summary>
        /// <param name="WindowClassFullName"></param>
        /// <returns></returns>
        public StylePar GetStyleParameter(string WindowClassFullName)
        {
            string xmlfile = Lemon.GetCSFRootDirectory() + @"\Styles\Data\" + WindowClassFullName + ".xml";
            if (File.Exists(xmlfile))
            {
                object tmpobj = Lemon.Deserialize(typeof(StylePar), xmlfile);
                if (tmpobj != null)
                {
                    if (Lemon.GetObjType(tmpobj) == typeof(StylePar))
                    {
                        return (StylePar)tmpobj;
                    } 
                }
            }
            return null;
        } 

        /// <summary>
        /// 当前界面布局名称
        /// </summary>
        public string CurrentLayoutName
        {
            get { return this.currentLayoutName;}
        }

        /// <summary>
        /// 取消当前布局
        /// </summary>
        public void CancelLayout()
        { 
            //这里运行取消布局的功能，实际上是一个内置的布局 
            var l = this.layouts.Find(delegate(ILayout tl) { return tl.LayoutName == this.currentLayoutName; });
            if (l != null)
            {
                l.CancelLayout();
            }
        }

        /// <summary>
        /// 获取当前布局所有受控窗体的名称
        /// </summary>
        public List<string> GetControlleds
        {
            get {
                foreach (ILayout l in this.layouts)
                {
                    if(l.LayoutName==this.currentLayoutName)
                    {
                        return l.Controlleds;
                    }
                }
                return new List<string>();
            }
        }




         
    }
}
