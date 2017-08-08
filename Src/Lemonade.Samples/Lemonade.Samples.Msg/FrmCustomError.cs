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

namespace Lemonade.Samples.Msg
{
    public partial class FrmCustomError : Form
    {
        IMsgProcess process = null;
        public FrmCustomError()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            process = new CustomErrorProcess(this);
            Lemon.AddMsgProcess(process); 
        }


        public virtual void ShowMsg(object Msg)
        {
            if (Msg.GetType() == typeof(Exception))
            {
                this.listBox1.Items.Add(((Exception)Msg).Message.ToString() + "::::" + ((Exception)Msg).StackTrace.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lemon.RemoveMsgProcess(process); 
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //Sunisoft.IrisSkin.SkinEngine skinengine = new Sunisoft.IrisSkin.SkinEngine();
            //skinengine.SkinFile = "DeepCyan.ssk";
            //skinengine.AddForm(this);
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            //skinUI1.LoadSkinFile(@"D:\Program Files\LinkRank\DotNetSkin2005\Skins\luna-BLUE.skn");
            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.InitialDirectory = @"..\skins";
            //dialog.Filter = "skin files (*.skn)|*.skn";
            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    skinUI1.LoadSkinFile(dialog.FileName);
            //}
            Lemon.SetSkill(0);
        }

    }
}
