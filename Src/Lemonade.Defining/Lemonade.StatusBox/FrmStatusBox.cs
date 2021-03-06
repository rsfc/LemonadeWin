﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lemonade.Frame;
using Lemonade.Frame.Message;
using Protein.Enzyme.DAL;
using Protein.Enzyme.DAL.MDB.Entity;
using Protein.Enzyme.Repository;
using Protein.Enzyme.Log;

namespace Lemonade.StatusBox
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Type"></param>
    /// <param name="Msg"></param>
    /// <param name="Date"></param>
    public delegate void SetStatusBoxData(MsgType Type, string Msg, DateTime Date);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Row"></param>
    /// <param name="C"></param>
    public delegate void SetCellStyle(DataGridViewRow Row, Color C);
    /// <summary>
    /// 状态盒子
    /// </summary>
    public partial class FrmStatusBox : Form, IModule
    {
        #region 属性
        delegate void ShowData(FrmStatusBox Frm, object Msg);

        MsgProcessError perror =null;
        MsgProcessNote penote = null; 
        MsgProcessDebug pedebug = null;

        public List<ProteinLog> LogList { get; set; }

        public int Pagenum { get; set; }

        public int PageIndex { get; set; }
        /// <summary>
        /// 状态盒子
        /// </summary>
        public FrmStatusBox()
        {
            InitializeComponent();
        }
        #endregion

        #region 插件接口
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void FrmStatusBox_Load(object sender, EventArgs e)
        {
           
           
            //this.dataGridView1.FirstDisplayedScrollingRowIndex = this.dataGridView1.RowCount-1;
            //this.dataGridView1.SelectedRows[0].Selected = false;
            //this.dataGridView1.SelectedCells[0].Selected = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStatusBox_Shown(object sender, EventArgs e)
        {
            this.perror = new MsgProcessError(this);
            this.penote = new MsgProcessNote(this);
            this.pedebug = new MsgProcessDebug(this);
            this.LogList = new List<ProteinLog>();
            this.ToolStripMenuItemRn.Checked = true;
            this.ToolStripMenuItemRe.Checked = true;
            this.ToolStripMenuItemRd.Checked = true;
            Lemon.AddMsgProcess(perror);
            Lemon.AddMsgProcess(penote);
            Lemon.AddMsgProcess(pedebug);
            this.RefCheckData();
            //this.dataGridView1.FirstDisplayedScrollingRowIndex = this.dataGridView1.RowCount;
        } 
        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        { 
            this.Show(); 
             
        }
        /// <summary>
        /// 
        /// </summary>
        public IMainForm MainForm
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string ModuleAlias
        {
            get { return "消息"; ; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ModuleName
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public void RunCache()
        {
            
        }
        #endregion 

        #region 实时消息

        /// <summary>
        /// 设置颜色
        /// </summary>
        /// <param name="Row"></param>
        /// <param name="C"></param>
        public void SetCellFontColor(DataGridViewRow Row, Color C)
        { 
            if (this.dataGridView1.InvokeRequired)
            {
                SetCellStyle stcb = new SetCellStyle(SetCellFontColor);
                this.BeginInvoke(stcb, new object[] { Row, C });
            }
            else
            {
                Row.Cells[0].Style.ForeColor = C;
                Row.Cells[0].Style.SelectionForeColor = C;
                Row.Cells[1].Style.ForeColor = C;
                Row.Cells[1].Style.SelectionForeColor = C;
                Row.Cells[2].Style.ForeColor = C;
                Row.Cells[2].Style.SelectionForeColor = C;
            } 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void 提示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ToolStripMenuItemRn.Checked)
            {
                Lemon.RemoveMsgProcess(penote); 
                this.dataGridView1.Rows.Clear();  
                this.ToolStripMenuItemRn.Checked = false;
            }
            else
            {
                Lemon.RemoveMsgProcess(penote); 
                this.dataGridView1.Rows.Clear();
                Lemon.AddMsgProcess(penote); 
                this.ToolStripMenuItemRn.Checked = true;
            }
            RefCheckData();
        }
        /// <summary>
        /// 刷新历史数据
        /// </summary>
        protected virtual void RefCheckData()
        {
            List<LemonMessage> datalist = new List<LemonMessage>();
            if (this.ToolStripMenuItemRn.Checked)
            {
                datalist.AddRange(Lemon.GetMsgHistory(MsgType.Note));
            }
            if (this.ToolStripMenuItemRe.Checked)
            {
                datalist.AddRange(Lemon.GetMsgHistory(MsgType.Error));
            }
            if (this.ToolStripMenuItemRd.Checked)
            {
                datalist.AddRange(Lemon.GetMsgHistory(MsgType.Debug));
            }
            this.AddData(datalist);
             
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void 调试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ToolStripMenuItemRd.Checked)
            {
                Lemon.RemoveMsgProcess(pedebug);
                this.dataGridView1.Rows.Clear();  
                this.ToolStripMenuItemRd.Checked = false;
            }
            else
            {
                Lemon.RemoveMsgProcess(pedebug);
                this.dataGridView1.Rows.Clear();
                Lemon.AddMsgProcess(pedebug); 
                this.ToolStripMenuItemRd.Checked = true;
            }
            RefCheckData();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual  void 异常ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ToolStripMenuItemRe.Checked)
            {
                Lemon.RemoveMsgProcess(perror);
                this.dataGridView1.Rows.Clear();  
                this.ToolStripMenuItemRe.Checked = false ;
            }
            else
            {
                Lemon.RemoveMsgProcess(perror);
                this.dataGridView1.Rows.Clear();
                Lemon.AddMsgProcess(perror); 
                this.ToolStripMenuItemRe.Checked = true;
            }
            RefCheckData();
        }
         
        /// <summary>
        /// 插入数据行
        /// </summary>
        /// <param name="Ico"></param>
        /// <param name="Msg"></param>
        public  virtual void InsertRow(MsgType Type, string Msg,DateTime Date)
        { 
            if (this.dataGridView1.InvokeRequired)
            {
                SetStatusBoxData stcb = new SetStatusBoxData(InsertRow);
                this.BeginInvoke(stcb, new object[] { Type, Msg, Date });
            }
            else
            {
                Bitmap BackgroundImg = null;
                if (Type == MsgType.Debug)
                {
                    System.IO.Stream streamSmall = Lemon.GetObjType(this).Assembly.GetManifestResourceStream("Lemonade.StatusBox.img.debug16.png");
                    BackgroundImg = new Bitmap(streamSmall);
                }
                else if (Type == MsgType.Error)
                {
                    System.IO.Stream streamSmall = Lemon.GetObjType(this).Assembly.GetManifestResourceStream("Lemonade.StatusBox.img.error16.png");
                    BackgroundImg = new Bitmap(streamSmall);
                }
                else if (Type == MsgType.Note)
                {
                    System.IO.Stream streamSmall = Lemon.GetObjType(this).Assembly.GetManifestResourceStream("Lemonade.StatusBox.img.info16.png");
                    BackgroundImg = new Bitmap(streamSmall);
                }
                this.dataGridView1.Rows.Insert(0, 1);
                DataGridViewRow dgvr = this.dataGridView1.Rows[0];
                DataGridViewCell cell0 = dgvr.Cells[0];
                cell0.Value = BackgroundImg;
                DataGridViewCell cell1 = dgvr.Cells[1];
                cell1.Value = Date.ToString("MM-dd hh:mm:ss").ToString();
                DataGridViewCell cell2 = dgvr.Cells[2];
                cell2.Value = Msg;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objlist"></param>
        protected virtual void AddData(List<LemonMessage> objlist)
        {
            objlist.Sort(SortOrderLmTime);
            foreach (LemonMessage obj in objlist)
            {
                if (obj.MsgObject.GetType() == typeof(string))
                {
                    this.InsertRow(obj.Type, obj.MsgObject.ToString(),obj.RecordTime);
                   
                }
                if (obj.MsgObject.GetType() == typeof(Exception))
                {
                    this.InsertRow(obj.Type, ((Exception)obj.MsgObject).Message.ToString() + Environment.NewLine + ((Exception)obj.MsgObject).StackTrace.ToString(), obj.RecordTime);
                    
                }
                if (this.dataGridView1.Rows.Count > 0)
                {
                    if (obj.Type == MsgType.Debug)
                    {
                        this.SetCellFontColor(this.dataGridView1.Rows[0], Color.Black);
                    }
                    else if (obj.Type == MsgType.Error)
                    {
                        this.SetCellFontColor(this.dataGridView1.Rows[0], Color.Red);
                    }
                    else
                    {
                        this.SetCellFontColor(this.dataGridView1.Rows[0], Color.Blue);
                    }
                }
                
            } 

        }

        protected virtual int SortOrderLmTime(LemonMessage lmA, LemonMessage lmb)
        {
            return lmA.RecordTime.CompareTo(lmb.RecordTime);
        }

        /// <summary>
        /// 加载历史数据
        /// </summary>
        protected virtual void ReadHistoryData(List<LemonMessage> objlist)
        { 
            foreach (LemonMessage obj in objlist)
            {
                if (obj.MsgObject.GetType() == typeof(string))
                {
                    this.InsertRow(obj.Type, obj.MsgObject.ToString(), obj.RecordTime);
                }
                else if (obj.MsgObject.GetType() == typeof(Exception))
                {
                    this.InsertRow(obj.Type, ((Exception)obj.MsgObject).Message.ToString() + Environment.NewLine + ((Exception)obj.MsgObject).StackTrace.ToString(), obj.RecordTime);
                }
            }
        }

        #endregion


        #region 日志


        /// <summary>
        /// 首页
        /// </summary>
        protected virtual void FirstPage()
        {
            int rownum = int.Parse(this.toolStripComboBox1.Text);
            this.Pagenum = this.LogList.Count / rownum;
            this.PageIndex = 1;
            for (int i = this.PageIndex - 1; i < rownum; i++)
            {
                this.InsertLogRow(this.LogList[i].LOGTYPE, this.LogList[i].CONTENT, this.LogList[i].LOGTIME);
            }
            this.weToolStripMenuItem.Text = this.PageIndex.ToString() + "/" + this.Pagenum + " " + "每页行数：";
        }

        /// <summary>
        /// 末页
        /// </summary>
        protected virtual void EndPage()
        {
            int rownum = int.Parse(this.toolStripComboBox1.Text);
            this.Pagenum = this.LogList.Count / rownum;
            this.PageIndex = this.Pagenum;
            for (int i = rownum * (this.PageIndex - 1); i < rownum * this.Pagenum; i++)
            {
                this.InsertLogRow(this.LogList[i].LOGTYPE, this.LogList[i].CONTENT,this.LogList[i].LOGTIME);
            }
            this.weToolStripMenuItem.Text = this.PageIndex.ToString() + "/" + this.Pagenum + " " + "每页行数：";
        }

        /// <summary>
        /// 下一页
        /// </summary>
        protected virtual void NextPage()
        {
            int rownum = int.Parse(this.toolStripComboBox1.Text);
            this.Pagenum = this.LogList.Count / rownum;
            if (this.PageIndex + 1 <= this.Pagenum)
            {
                this.PageIndex++;
                for (int i = rownum * (this.PageIndex - 1); i < rownum * this.PageIndex; i++)
                {
                    this.InsertLogRow(this.LogList[i].LOGTYPE, this.LogList[i].CONTENT, this.LogList[i].LOGTIME);
                }
                this.weToolStripMenuItem.Text = this.PageIndex.ToString() + "/" + this.Pagenum + " " + this.weToolStripMenuItem.Text;
            }
            this.weToolStripMenuItem.Text = this.PageIndex.ToString() + "/" + this.Pagenum + " " + "每页行数：";
        }

        /// <summary>
        /// 上一页
        /// </summary>
        protected virtual void LastPage()
        {
            int rownum = int.Parse(this.toolStripComboBox1.Text);
            this.Pagenum = this.LogList.Count / rownum;
            if (this.PageIndex - 1 >0)
            {
                this.PageIndex--;
                for (int i = rownum * (this.PageIndex - 1); i < rownum * this.PageIndex; i++)
                {
                    this.InsertLogRow(this.LogList[i].LOGTYPE, this.LogList[i].CONTENT, this.LogList[i].LOGTIME);
                }
                this.weToolStripMenuItem.Text = this.PageIndex.ToString() + "/" + this.Pagenum + " " + this.weToolStripMenuItem.Text;
            }
            this.weToolStripMenuItem.Text = this.PageIndex.ToString() + "/" + this.Pagenum + " " + "每页行数：";
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        protected virtual void LoadData()
        {
            this.LogList.Clear(); 
            DalHandler dh = new DalHandler(); 
            ProteinLog plog = new ProteinLog();
            this.LogList = dh.QueryAll<ProteinLog>(plog);
            this.LogList.Sort(SortOrderTime);
            this.fToolStripMenuItem.Enabled = true;
            this.lToolStripMenuItem.Enabled = true;
            this.nToolStripMenuItem1.Enabled = true;
            this.eToolStripMenuItem.Enabled = true; 
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LogA"></param>
        /// <param name="LogB"></param>
        /// <returns></returns>
        protected virtual int SortOrderTime(ProteinLog LogA, ProteinLog LogB)
        {
            return LogA.LOGTIME.CompareTo(LogB.LOGTIME);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
            FirstPage();
        }

        /// <summary>
        /// 插入数据行
        /// </summary>
        /// <param name="Ico"></param>
        /// <param name="Msg"></param>
        public virtual void InsertLogRow(string Type, string Msg, DateTime Time)
        {
            Bitmap BackgroundImg = null;
            if (Type.ToUpper().Trim() == Protein.Enzyme.Message.MessageType.Debug.GetEnumDescription().ToUpper()
                || Type.ToUpper().Trim() == Protein.Enzyme.Message.MessageType.PtDebug.GetEnumDescription().ToUpper())
            {
                System.IO.Stream streamSmall = Lemon.GetObjType(this).Assembly.GetManifestResourceStream("Lemonade.StatusBox.img.debug16.png");
                BackgroundImg = new Bitmap(streamSmall);
            }
            else if (Type.ToUpper().Trim() == Protein.Enzyme.Message.MessageType.Error.GetEnumDescription().ToUpper()
                || Type.ToUpper().Trim() == Protein.Enzyme.Message.MessageType.Warning.GetEnumDescription().ToUpper())
            {
                System.IO.Stream streamSmall = Lemon.GetObjType(this).Assembly.GetManifestResourceStream("Lemonade.StatusBox.img.error16.png");
                BackgroundImg = new Bitmap(streamSmall);
            }
            else if (Type.ToUpper().Trim() == Protein.Enzyme.Message.MessageType.Note.GetEnumDescription().ToUpper()
                || Type.ToUpper().Trim() == Protein.Enzyme.Message.MessageType.InsideInfo.GetEnumDescription().ToUpper())
            {
                System.IO.Stream streamSmall = Lemon.GetObjType(this).Assembly.GetManifestResourceStream("Lemonade.StatusBox.img.info16.png");
                BackgroundImg = new Bitmap(streamSmall);
            }
            this.dataGridView2.Rows.Insert(0, 1);
            DataGridViewRow dgvr = this.dataGridView2.Rows[0];
            DataGridViewCell cell0 = dgvr.Cells[0];
            cell0.Value = BackgroundImg;
            DataGridViewCell cell1 = dgvr.Cells[1];
            cell1.Value = Time.ToString("MM-dd hh:mm:ss").ToString(); ;
            DataGridViewCell cell2 = dgvr.Cells[2];
            cell2.Value = Msg;

            //this.SetCellFontColor(this.dataGridView1.Rows[0], Color.Red);

            if (Type.ToUpper().Trim() == Protein.Enzyme.Message.MessageType.Debug.GetEnumDescription().ToUpper()
                || Type.ToUpper().Trim() == Protein.Enzyme.Message.MessageType.PtDebug.GetEnumDescription().ToUpper())
            {
                this.SetCellFontColor(this.dataGridView2.Rows[0], Color.Black);
            }
            else if (Type.ToUpper().Trim() == Protein.Enzyme.Message.MessageType.Error.GetEnumDescription().ToUpper()
                || Type.ToUpper().Trim() == Protein.Enzyme.Message.MessageType.Warning.GetEnumDescription().ToUpper())
            {
                this.SetCellFontColor(this.dataGridView2.Rows[0], Color.Red);
            }
            else if (Type.ToUpper().Trim() == Protein.Enzyme.Message.MessageType.Note.GetEnumDescription().ToUpper()
                || Type.ToUpper().Trim() == Protein.Enzyme.Message.MessageType.InsideInfo.GetEnumDescription().ToUpper())
            {
                this.SetCellFontColor(this.dataGridView2.Rows[0], Color.Blue);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void toolStripComboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        protected virtual void 尾页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView2.Rows.Clear();
            //this.LoadData();
            this.EndPage();

        }

        protected virtual void 上一页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView2.Rows.Clear();
            this.FirstPage();
        }

        private void 下一页ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.dataGridView2.Rows.Clear();
            //this.LoadData();
            this.NextPage();
        }

        private void 下一页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView2.Rows.Clear();
            //this.LoadData();
            this.LastPage();
        }


        protected virtual void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((TabControl)sender).SelectedTab == this.tabPage2)
            {
                LoadData();
                FirstPage();
            }
        }

        #endregion

      
         

       

       

       
       
    }
}
