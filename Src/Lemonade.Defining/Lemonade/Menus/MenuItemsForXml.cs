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
//using Lemonade.Frame.Manage.Base;
//using Lemonade.Frame;
//using Lemonade.Frame.Manage;
//using System.Threading;

//namespace Lemonade.Menus
//{
//    /// <summary>
//    /// 从xml创建菜单,直接从xml创建菜单
//    /// (该类直接从固定路径的xml读取菜单，绕过了框架IManager接口的各项操作。
//    /// 现在正常的做法应该是使用MenuItemsForDataBase然后在数据库对象关系映射机制中使用xml作为数据库读取
//    /// 但是该类能够快速的实现无关数据库的菜单存取功能)
//    /// </summary>
//    public class MenuItemsForXml : IMenuItemFactory
//    {
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
//        public MenuItemsForXml()
//        { 
        
//        }

//        /// <summary>
//        /// 从xml创建菜单
//        /// </summary>
//        public MenuItemsForXml(IEventBinder Binder, IMainForm RunMainForm)
//        {
//            //this.xmlfilepath = XmlFilePath;
//            this.Mainform = RunMainForm;
//            this.Eventbinder = Binder;
//        }

//        #region IMenuItemFactory 成员

//        /// <summary>
//        /// 创建菜单项目集合
//        /// </summary>
//        /// <returns></returns>
//        public Dictionary<string, PtMenuItem> CreateMenuItems()
//        {
//            this.xmlfilepath = Lemon.GetCSFRootDirectory() + "\\Menu.xml";
//            CreateMenu();
//            //EasyComeEasyGo();
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
//            item.Text = RowView["Title"].ToString();
//            item.FullClassName = RowView["FullClassName"].ToString();
//            item.AssemblyPath = RowView["AssemblyPath"].ToString(); 
//            item.IsChild = Convert.ToBoolean(int.Parse(RowView["IsChild"].ToString()));
//            item.ItemID = int.Parse(RowView["ItemID"].ToString());
//            if (item.ImageName.ToString().Length > 0)
//            {
//                Image img = Image.FromFile(item.ImageName);
//                item.Image = img;  
//            }
//            this.Eventbinder.Binder(item);
//            Lemon.SendMsgDebug("加载菜单项:" + item.Text);
//            return item;
//        }
      
//        /// <summary>  
//        /// 动态创建菜单  
//        /// </summary>  
//        protected virtual void CreateMenu()
//        { 
//            DataSet ds = new DataSet();
//            ds.ReadXml(this.xmlfilepath);
//            DataView dv = ds.Tables[0].DefaultView;
//            dv.RowFilter = "ParentItemID=0"; 
//            foreach (DataRowView drv in dv)
//            {
//                PtMenuItem menuItem = CreateItem(drv);
//                if (menuItem.IsChild)
//                {
//                    CreateSubMenu(menuItem, ds.Tables[0]); 
//                }
//                this.items.Add(menuItem.ItemID.ToString(), menuItem); 
//            }
         
//        }


//        /// <summary>  
//        /// 创建子菜单  
//        /// </summary>  
//        protected virtual void CreateSubMenu(PtMenuItem MenuItem, DataTable Dt)
//        {
//            DataView dv = new DataView(Dt);
//            dv.RowFilter = "ParentItemID=" + MenuItem.ItemID.ToString();
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
