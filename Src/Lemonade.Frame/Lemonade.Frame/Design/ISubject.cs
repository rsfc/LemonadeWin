using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonade.Frame.Design
{
    /// <summary>
    /// 主题接口
    /// </summary>
    public interface ISubject
    { 
        /// <summary>
        /// 注册观察者
        /// </summary>
        /// <param name="Obser"></param>
        void Regidit(IObserver Obser);
        /// <summary>
        /// 卸载观察者
        /// </summary>
        /// <param name="Obser"></param>
        void UnRegidit(IObserver Obser);
    }
}
