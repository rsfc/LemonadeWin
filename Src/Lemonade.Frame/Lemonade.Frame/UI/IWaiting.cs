using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonade.Frame.UI
{
    /// <summary>
    /// �ȴ�������ӿ�
    /// </summary>
    public interface IWaitingProgram
    {
        /// <summary>
        /// ���õȴ��Ի�����
        /// </summary>
        /// <param name="Content"></param>
        void SetContent(string Content);
        /// <summary>
        /// ��ʾ�Ի�����
        /// </summary>
        void ShowDialog();
        /// <summary>
        /// �ر�
        /// </summary>
        void CloseDialog();
        /// <summary>
        /// ������ʾ�Ĵ��� ��ʱ������ȴ��������
        /// </summary>
        /// <param name="WaitingForm"></param>
        void SetForm(IWaitionForm WaitingForm);
    }
}
