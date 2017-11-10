using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;
using System.Windows.Forms;
using Lemonade.Ribbon.Data;
using DevExpress.XtraBars.Ribbon;
using Lemonade.Ribbon.Items;
using Lemonade.Frame.Tools;
using Lemonade.Frame.Ribbon;

namespace Lemonade.Ribbon
{
    /// <summary>
    /// 工具栏工厂，用于处理创建工具栏、工具项、排序分组等逻辑，这里创建的业务上封装的对象
    /// </summary>
    public class RibbonFactroy
    {
        /// <summary>
        /// 用于分组的匿名类型的实体便于编码
        /// </summary>
        protected class VarGroup<W>
        {
            /// <summary>
            /// 
            /// </summary>
            public string key { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<W> lists { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public RibbonSetting BarSetting {get;set;}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        public RibbonFactroy(RibbonData Data)
        {
            BarSetting = DataConvterCtrl(Data);
        }


        /// <summary>
        /// 数据转换到控件
        /// </summary>
        protected RibbonSetting DataConvterCtrl(RibbonData BarData)
        {
            string pathbase = Lemon.GetCSFRootDirectory();
            RibbonSetting result = new RibbonSetting();
            //工具栏
            foreach (RPage pd in BarData.Pages)
            {
                FunPage newPage = new FunPage();
                newPage.ContentCode = pd.RibbonPageCode;
                newPage.RibbonPageName = pd.RibbonPageName;
                newPage.ContentIndex = pd.Index;
                newPage.Groups = pd.Groups;
                result.Pages.Add(newPage);
            }
            //按钮
            foreach (RBarButton tbtn in BarData.Buttons)
            {
                FunButton newBtn = new FunButton();
                newBtn.Assembly = pathbase+tbtn.Assembly;
                newBtn.FullClassName = tbtn.FullClassName; 
                newBtn.ButtonImage = pathbase + tbtn.ButtonImage;
                newBtn.ContentIndex = tbtn.Index;
                newBtn.ContentCode = tbtn.ButtonCode;
                newBtn.ButtonTitle = tbtn.ButtonTitle;
                IRibbonButtonItem elm = Lemon.GetInstance<IRibbonButtonItem>(newBtn.Assembly, newBtn.FullClassName); 
                if (elm != null)
                {
                    newBtn.UIElement = elm;
                    
                }
                else
                {
                    Lemon.SendMsgDebug("配置的功能区按钮" + newBtn.ContentCode + "没有实现IUIElement接口"); 
                }
                result.Buttons.Add(newBtn);
            }
            ////下拉框
            //foreach (TComboBox tcb in BarData.ComboBoxs)
            //{
            //    ToolsComboBox newCb = new ToolsComboBox();  
            //    newCb.GroupName = tcb.GroupName; 
            //    newCb.ItemIndex = tcb.ItemIndex;
            //    newCb.ToolsBarCode = tcb.ToolsBarCode;
            //    IControlToolsComoBoxItem cbelm = Lemon.GetInstance<IControlToolsComoBoxItem>(tcb.Assembly, tcb.FullClassName);
            //    if (cbelm != null)
            //    {
            //        newCb.UIElement = cbelm; 
            //    }
            //    else
            //    {
            //        Lemon.SendMsgDebug("配置的工具栏下拉框" + newCb.ToolsBarCode + "没有实现IUIElement接口");
            //    } 
            //    foreach (TComboBoxItem ti in tcb.Items)
            //    {
            //        ToolsComboBoxItem newItem = new ToolsComboBoxItem();
            //        ti.Assembly = pathbase + ti.Assembly;
            //        newItem.ItemData = ti;
            //        IControlToolsComoBoxItem elm = Lemon.GetInstance<IControlToolsComoBoxItem>(ti.Assembly, ti.FullClassName);
            //        if (elm != null)
            //        {
            //            newItem.UIElement = elm;
            //            newCb.Items.Add(newItem);  
            //        }
            //        else
            //        {
            //            Lemon.SendMsgDebug("配置的工具栏下拉框的选项" + ti.Title + "没有实现IUIElement接口");
            //        } 
            //    } 
            //    result.ComboBoxs.Add(newCb);
            //}

            //分组
            foreach (RPageGroup tsep in BarData.Groups)
            {
                FunGroup newSep = new FunGroup();
                newSep.ContentCode = tsep.GroupCode;
                newSep.ContentIndex = tsep.Index;
                newSep.Title = tsep.Title;
                newSep.Image = pathbase+tsep.Image;
                newSep.Buttons = tsep.Buttons;
                result.Groups.Add(newSep);
            }
            return result;
        }


        /// <summary>
        /// 构建功能区，按照分页构造功能区
        /// </summary>
        public void Build()
        {
            if (this.BarSetting == null)
            {
                return;
            } 
            Dictionary<string, List<IToolsItem>> btngroup = SetToolsBarGroup(); 
            //将分栏分组按钮写入工具栏
            foreach (IToolsBar tb in this.BarSetting.Pages)
            {
                var skey = from bgr in btngroup
                           where bgr.Key == tb.ToolsBarCode
                           select bgr.Value;
                if (skey != null)
                {
                    ////根据index排序 
                    //List<IToolsItem> items = skey.ToList()[0].OrderBy(a => a.ItemIndex).ToList(); 
                    foreach (IToolsItem tmpbtn in skey.ToList()[0])
                    {
                        tb.AddItem(tmpbtn);
                    }
                }
            }
        }


        /// <summary>
        /// 对按钮进行分栏分组，便于循环添加到对应的工具栏中
        /// </summary>
        /// <returns></returns>
        protected Dictionary<string, List<IToolsItem>> SetToolsBarGroup()
        {
            Dictionary<string, List<IToolsItem>> result = new Dictionary<string, List<IToolsItem>>();
            this.SetAddGroupItems(result, this.DismantledSettingToGroup(this.BarSetting.Buttons));
            //this.SetAddGroupItems(result, this.DismantledSettingToGroup(this.BarSetting.ComboBoxs));
            //this.SetAddGroupItems(result, this.DismantledSettingToGroup(this.BarSetting.Separator));
            return result;

        }

        /// <summary>
        /// 插接设置中的每个项列表到分组
        /// </summary>
        protected List<VarGroup<T>> DismantledSettingToGroup<T>(List<T> ItemList)
        {
            var itemgroup = from bg in ItemList
                            group bg by ((IToolsItem)bg).ToolsBarCode into g
                            select new
                            {
                                key = g.Key,
                                lists = from m in g select m
                            };
            List<VarGroup<T>> result = new List<VarGroup<T>>();
            foreach (var a in itemgroup)
            {
                result.Add(new VarGroup<T>() { key = a.key, lists = new List<T>(a.lists.ToArray()) });
            }
            return result;
        }

        /// <summary>
        /// 设置添加分组项
        /// </summary>
        /// <param name="Dic"></param>
        /// <param name="Group"></param>
        protected void SetAddGroupItems<T>(Dictionary<string, List<IToolsItem>> Dic, List<VarGroup<T>> Group)
        {
            foreach (VarGroup<T> vg in Group)
            {
                if (!Dic.ContainsKey(vg.key))
                {
                    Dic.Add(vg.key, new List<IToolsItem>());
                }
                foreach (T tmpT in vg.lists)
                {
                    Dic[vg.key].Add((IToolsItem)tmpT);
                }

            }
        }
    }
}
