using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonade.Frame.Design
{
    /// <summary>
    /// ����ӿ�
    /// </summary>
    public interface ISubject
    { 
        /// <summary>
        /// ע��۲���
        /// </summary>
        /// <param name="Obser"></param>
        void Regidit(IObserver Obser);
        /// <summary>
        /// ж�ع۲���
        /// </summary>
        /// <param name="Obser"></param>
        void UnRegidit(IObserver Obser);
    }
}
