using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.UI;

namespace Lemonade.Daemon.Skins
{
    /// <summary>
    /// 
    /// </summary>
    public class Skin:ISkin
    {
        private FrmMain mainf = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FrmMain"></param>
        public Skin(FrmMain FrmMain)
        {
            this.mainf = FrmMain;
        }
        /// <summary>
        /// 皮肤数量
        /// </summary>
        /// <returns></returns>
        public int SkinCount()
        {
            string[] maname = typeof(Properties.Resources).Assembly.GetManifestResourceNames();
            return maname.Length;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Index"></param>
        public void SetSkin(int Index)
        {
            string[] maname = typeof(Properties.Resources).Assembly.GetManifestResourceNames();
            if (maname.Length > Index)
            {
                System.IO.Stream stream = typeof(Properties.Resources).Assembly.GetManifestResourceStream(maname[Index]);//.GetManifestResourceStream("Lemonade.Daemon.Skins.BlackMesa-NORMAL.skn");
                byte[] buffer = new byte[1024];
                System.IO.MemoryStream memory = new System.IO.MemoryStream();
                while (true)
                {
                    int sz = stream.Read(buffer, 0, 1024);
                    if (sz == 0) break;
                    memory.Write(buffer, 0, sz);
                }
                memory.Position = 0;
                
            } 
        }

 
    }
}
