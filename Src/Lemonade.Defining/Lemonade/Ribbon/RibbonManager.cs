using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraBars.Ribbon;
using Lemonade.Frame.Ribbon;
using Lemonade.Frame;
using Lemonade.Ribbon;
using Lemonade.Ribbon.Items;
using DevExpress.XtraBars;
using System.Drawing;
using System.IO;

namespace Lemonade.Ribbon
{
    /// <summary>
    /// 
    /// </summary>
    public class RibbonManager : IRibbonManager
    {
        private List<RibbonPage> pages = null;
        private RibbonSetting ribbonsetting = null;

        /// <summary>
        /// 
        /// </summary>
        public List<string> RibbonPageNames
        {
            get
            {
                List<string> result = new List<string>();
                //foreach (RibbonPage page in this.pages)
                //{
                //    result.Add(page.n);
                //}
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TargetForm"></param>
        public void CreateRibbonPagesToForm(RibbonForm TargetForm)
        {
            this.CreateRibbonPage(TargetForm);
        }

        /// <summary>
        /// 创建功能区分页
        /// </summary>
        protected virtual List<RibbonPage>  CreateRibbonPage(RibbonForm TargetForm)
        {
            List<RibbonPage> result = new List<RibbonPage>();
            foreach (FunPage page in this.ribbonsetting.Pages)
            {
                RibbonPage newpage = new RibbonPage();
                newpage.Name = page.ContentCode;
                newpage.Text = page.RibbonPageName;
                List<RibbonPageGroup> groups =this.CreateRibbonPageGroup(TargetForm, page);
                foreach (RibbonPageGroup group in groups)
                {
                    newpage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
                    group});
                }
                TargetForm.Ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
                    newpage});
                result.Add(newpage);
            } 
            return result;
        }

        /// <summary>
        /// 创建分组
        /// </summary>
        /// <param name="TargetForm"></param>
        /// <param name="pagedata"></param> 
        protected virtual List<RibbonPageGroup> CreateRibbonPageGroup(RibbonForm TargetForm,FunPage pagedata)
        {
            List<RibbonPageGroup> result = new List<RibbonPageGroup>();
            foreach (string groupcode in pagedata.Groups)
            {
                var taggroup = this.ribbonsetting.Groups.FindAll(delegate (FunGroup tb) { return tb.ContentCode == groupcode; });
                if (taggroup != null && this.ribbonsetting.Groups.Count>0)
                { 
                    RibbonPageGroup newgroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
                    newgroup.Name = taggroup[0].ContentCode;
                    newgroup.Text = taggroup[0].Title;
                    List<BarButtonItem> butns = this.CreateRibbonButton(TargetForm,taggroup[0]);
                    foreach (BarButtonItem item in butns)
                    {
                        newgroup.ItemLinks.Add(item);
                    }
                    result.Add(newgroup);
                }
            }
            return result;
            
        }

        /// <summary>
        /// 创建按钮
        /// </summary>
        /// <param name="TargetForm"></param>
        /// <param name="group"></param> 
        protected virtual List<BarButtonItem> CreateRibbonButton(RibbonForm TargetForm,FunGroup group)
        {
            List<BarButtonItem> result = new List<BarButtonItem>();
            foreach (string butncode in group.Buttons)
            {
                var tagbutn = this.ribbonsetting.Buttons.FindAll(delegate (FunButton tb) { return tb.ContentCode == butncode; });
                if (tagbutn != null && this.ribbonsetting.Buttons.Count > 0)
                {
                    RibbonProcessButton prc = new RibbonProcessButton();
                    BarButtonItem newbutn = prc.CreateItem(TargetForm, tagbutn[0]);
                    //BarButtonItem newbutn = new BarButtonItem(); 
                    //newbutn.Caption = tagbutn[0].ButtonTitle; 
                    //newbutn.Glyph = Image.FromFile(tagbutn[0].ButtonImage);
                    //newbutn.Id = tagbutn[0].ContentIndex;
                    //newbutn.Name = tagbutn[0].ContentCode;
                    //newbutn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large; 
                    TargetForm.Ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                        TargetForm.Ribbon.ExpandCollapseItem, newbutn});
                    result.Add(newbutn); 
                }
            }
            return result;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<RibbonPage> GetPages()
        {
            return this.pages;
        }

        /// <summary>
        /// 
        /// </summary>
        public void LoadRibbon()
        {
            object tbs = Lemon.Deserialize(typeof(RibbonData), Lemon.GetCSFRootDirectory() + @"\Ribbon\RibbonData.xml");
            if (tbs != null)
            {
                //转换为功能区域 
                RibbonFactroy tbfac = new RibbonFactroy((RibbonData)tbs);
                this.ribbonsetting = tbfac.BarSetting;
                if (this.ribbonsetting != null)
                {
                    //tbfac.Build();
                }

            }
        }
    }
}
