using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lemonade.Frame;
using Lemonade.Frame.Message;

namespace Lemonade.StatusBox
{
    /// <summary>
    /// 
    /// </summary>
    public class MsgProcessError : MsgProcess
    {

        public MsgProcessError(FrmStatusBox StatusFrame)
            :base(StatusFrame)
        { 

        }


        protected override MsgType ProType()
        {
            return MsgType.Error;
        }
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Msg"></param>
        protected override  void ShowMsg(object Msg,DateTime Date)
        {
            if (Msg.GetType().IsSubclassOf(typeof(Exception)))
            {
                string strMes = "";
                string strSt = "";
                if (((Exception)Msg).Message != null)
                {
                    strMes = ((Exception)Msg).Message; 
                }
                if (((Exception)Msg).StackTrace != null)
                {
                    strSt = ((Exception)Msg).StackTrace; 
                }
                this.TargetFrom.InsertRow(MsgType.Error, strMes + Environment.NewLine + strSt, Date);
                this.TargetFrom.SetCellFontColor(this.TargetFrom.dataGridView1.Rows[this.rowindex], Color.Red);
            }
            
        }
    }


}
