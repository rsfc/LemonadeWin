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

namespace Lemonade.StatusBox
{
    /// <summary>
    /// 
    /// </summary>
    public class MsgProcessDebug : MsgProcess
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StatusFrame"></param>
        public MsgProcessDebug(FrmStatusBox StatusFrame)
            :base(StatusFrame)
        { 

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override MsgType ProType()
        {
            return MsgType.Debug;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Msg"></param>
        protected override void ShowMsg(object Msg,DateTime Date)
        { 
            if (Msg.GetType() == typeof(string))
            {
                this.TargetFrom.InsertRow(MsgType.Debug, Msg.ToString(),Date); 
                this.TargetFrom.SetCellFontColor(this.TargetFrom.dataGridView1.Rows[this.rowindex], Color.Black);
            }
            
        }
    }


}
