using System;
using System.Collections.Generic;
using System.Text; 
using System.Windows.Forms;
using Lemonade.Frame.Swapping;
using Protein.Enzyme.Log;
using Lemonade.Frame.Running;
using Lemonade.Frame.UI;

namespace Lemonade.Frame
{
    /// <summary>
    /// ������ӿ� 
    /// </summary>
    public interface IMainForm
    {  
        /// <summary>
        /// ������л���
        /// </summary>
        ILemonEnvironment Envir { get;set;}  
        /// <summary>
        /// ϵͳ���еȴ��ӿ�
        /// </summary>
        IWaitingProgram WatingProgram { get;}
        /// <summary>
        /// Ƥ��������
        /// </summary> 
        ISkin SkinManager();
        DevExpress.XtraBars.Ribbon.RibbonControl getRibbon { get; }

    }
}
