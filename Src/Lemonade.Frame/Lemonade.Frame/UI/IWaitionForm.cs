using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonade.Frame.UI
{
    /// <summary>
    /// �ȴ�����
    /// </summary>
    public  interface  IWaitionForm
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Content"></param>
        void SetContent(string Content);
        /// <summary>
        /// �ر�
        /// </summary>
        void ThisClose(); 
        /// <summary>
        /// ����
        /// </summary>
        void ThisOpen();
    }
}
