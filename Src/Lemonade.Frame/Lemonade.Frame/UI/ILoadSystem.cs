using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonade.Frame.UI
{
    /// <summary>
    /// ��������
    /// </summary>
    /// <param name="Content"></param>
    public delegate void SetContent(object Content);
    /// <summary>
    /// ���ö���
    /// </summary>
    public delegate void SetActive();
     
     

    /// <summary>
    /// ��������ϵͳģ��ӿ�
    /// </summary>
    public interface ILoadSystem : Lemonade.Frame.Design.ISubject
    {
        
        /// <summary>
        /// ǰ�ô����¼�
        /// </summary>
        event SetActive Prepose; 
        /// <summary>
        /// ��ʼ����
        /// </summary>
        void StartProcess();  
        /// <summary>
        /// ��ɽ�����������
        /// </summary>
        void Finish();
    }
}
