using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Protein.Enzyme.Log;
using Lemonade.Frame.Design;
using System.Security;
using System.Security.Permissions;
namespace Lemonade.Frame
{
    /// <summary>
    /// ��ܲ���ӿ�
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// ģ����� ������ʾ�Ѻ���ʾ 
        /// </summary>
        string ModuleAlias { get;}
        /// <summary>
        /// ģ������,��ģ�鴴��ʱ�ɿ�ܸ�ֵ
        /// </summary>
        string ModuleName { get; set; }
        /// <summary>
        /// ��ʼ��
        /// </summary> 
        void Initialize();
        /// <summary>
        /// �ٴ�����
        /// </summary>
        void RunCache();
        /// <summary>
        /// ������ӿ�
        /// </summary>
        IMainForm MainForm { get;set;} 
    }
}
