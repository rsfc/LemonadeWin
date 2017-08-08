using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using Lemonade.Daemon.Turbo; 
using Protein.Enzyme.Design;
using Protein.Enzyme.Message;
using Lemonade.Frame;

namespace Lemonade.Daemon
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThreadAttribute]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false); 
            StartUp startup = Lemon.GetInstance<StartUp>(typeof(StartUp));  
            Application.Run(startup);
 
           
        }

        
    }
}