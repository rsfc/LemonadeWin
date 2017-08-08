//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;
//using System.Reflection;
//using System.IO;
//using Lemonade.Frame.Menu;
//using Protein.Enzyme.DAL;
//using Protein.Enzyme.Design; 
//using Lemonade.Manage.Base;
//using Lemonade.Frame;
//using Lemonade.Manage;


//namespace Lemonade.Menus
//{
//    /// <summary>
//    /// 从数据库创建菜单
//    /// </summary>
//    public class MenuItemsForDataBase : IMenuItemFactory
//    { 
//        private List<IMenu> mlist = null;
//        /// <summary>
//        /// 主窗体
//        /// </summary>
//        public IMainForm Mainform
//        {
//            get;
//            set;
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        protected string xmlfilepath = "";
//        /// <summary>
//        /// 菜单项
//        /// </summary>
//        protected Dictionary<string, PtMenuItem> items = new Dictionary<string, PtMenuItem>();
        
//        /// <summary>
//        /// 事件绑定
//        /// </summary>
//        public IEventBinder Eventbinder
//        {
//            get;
//            set;
//        }
//        ///// <summary>
//        ///// 实体对象创建者
//        ///// </summary>
//        //IEntityFactory entityfactory;
//        /// <summary>
//        /// 
//        /// </summary>
//        public MenuItemsForDataBase()
//        { 
        
//        }
//        /// <summary>
//        /// 从数据库创建菜单
//        /// </summary>
//        public MenuItemsForDataBase (IEventBinder Binder,IMainForm RunMainForm)
//        {
//            this.Mainform = RunMainForm;
//            this.Eventbinder = Binder;  
//        }

//        #region IMenuItemFactory 成员 
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        public Dictionary<string, PtMenuItem> CreateMenuItems()
//        {
//            IDBInfo dbh = new FramDbInfo();
//            //CreateDALFactory cdf = new CreateDALFactory();
//            //this.entityfactory = cdf.GetInstance(dbh);
//            CreateMenu();
//            return this.items;
//        }

//        #endregion
 
//        /// <summary>
//        /// 创建菜单项
//        /// </summary>
//        /// <returns></returns>
//        protected virtual PtMenuItem CreateItem(DataRowView RowView)
//        { 
//            PtMenuItem item = new PtMenuItem();
//            item.ShortcutKey = RowView["ShortcutKey"].ToString();
//            item.Text = RowView["MENUTITLE"].ToString() + item.ShortcutKey;
//            item.FullClassName = RowView["FULLCLASSNAME"].ToString();
//            item.AssemblyPath = RowView["TARGETPATH"].ToString();
//            item.IsChild = FindChild(RowView["MENUCODE"].ToString());// Convert.ToBoolean(int.Parse(RowView["ISCHILD"].ToString()));
//            item.ItemID = int.Parse(RowView["MENUCODE"].ToString());
//            //item.ShowShortcutKeys = true; 
//            //item.ShortcutKeys=((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | (Keys)Enum.Parse(typeof(Keys),"k" , true))));
//            ////item.ShortcutKeyDisplayString = "K";
//            if (item.ImageName.ToString().Length > 0)
//            {
//                Image img = Image.FromFile(item.ImageName);
//                item.Image = img;
//            }
//            this.Eventbinder.Binder(item);
//            //这样的逻辑应该是加入消息总线中 然后框架处理
//            //this.NotifyObsers("加载菜单 " + item.Name);
//            return item;
//        }
//        /// <summary>
//        /// 判断是否存在子菜单 判断集合中是否存在父节点编号等于该节点编号的对象
//        /// </summary>
//        /// <param name="MenuCode"></param>
//        /// <returns></returns>
//        protected virtual bool FindChild(string MenuCode)
//        { 
//            foreach (IMenu m in this.mlist)
//            {
//                if (MenuCode == m.PARENTCODE)
//                {
//                    return true;
//                }
//            }
//            return false;
//        }
//        /// <summary>  
//        /// 动态创建菜单  
//        /// </summary>  
//        protected virtual void CreateMenu()
//        {
//            //IDBInfo Dbh = new FramDbInfo();
//            //DataHelper dh = new DataHelper();
//            //IManager mc = new Manager(Dbh);
//            //if (this.Mainform.SysConfig.BllConfig.GetConfig<CSF.Frame.Running.IConfig>().IsCheckMenuAuth)
//            //{
//            //    this.mlist = mc.QueryMenus(this.Mainform.SysState.LogonUser, MenuType.CS); 
//            //}
//            //else
//            //{
//            //    this.mlist = mc.QueryMenus(MenuType.CS);
//            //}
//            //if (mlist == null || mlist.Count == 0)
//            //{
//            //    MenuNull();
//            //    return;
//            //}
//            //DataSet ds = dh.ConvertToSet<IMenu>(mlist);  
//            //DataView dv = ds.Tables[0].DefaultView;
//            //dv.RowFilter = "PARENTCODE=0";
//            //foreach (DataRowView drv in dv)
//            //{
//            //    PtMenuItem menuItem = CreateItem(drv);
//            //    if (menuItem.IsChild)
//            //    {
//            //        CreateSubMenu(menuItem, ds.Tables[0]);
//            //    }
//            //    this.items.Add(menuItem.ItemID.ToString(), menuItem);
//            //}

//        }

//        /// <summary>
//        /// 菜单为空
//        /// </summary>
//        protected virtual void MenuNull()
//        {
//            Protein.Enzyme.Message.MessageObject mo
//                = new Protein.Enzyme.Message.MessageObject(Protein.Enzyme.Message.MessageType.Note);
//            mo.Message = "用户关联的菜单权限为空没有加载菜单";
//            //this.Mainform.SysState.SysMessageBus.Send(mo);
//        }


//        /// <summary>  
//        /// 创建子菜单  
//        /// </summary>  
//        /// <param name="MenuItem">父菜单项</param>  
//        /// <param name="Dt">父菜单的ID</param>   
//        protected virtual void CreateSubMenu(PtMenuItem MenuItem, DataTable Dt)
//        {
//            DataView dv = new DataView(Dt);
//            dv.RowFilter = "PARENTCODE=" + MenuItem.ItemID.ToString();
//            foreach (DataRowView drv in dv)
//            {
//                PtMenuItem subMenu = this.CreateItem(drv);
//                if (subMenu.IsChild)
//                {
//                    CreateSubMenu(subMenu, Dt);
//                }
//                MenuItem.DropDownItems.Add(subMenu);

//            }
//        }
//    }
//}
