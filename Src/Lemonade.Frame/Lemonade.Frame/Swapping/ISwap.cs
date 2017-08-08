using System;
using System.Collections;
using System.Collections.Generic;

namespace Lemonade.Frame.Swapping
{
    /// <summary>
    /// 数据交换对象，封装需要加入框架进行共享的对象实例
    /// </summary>
    public interface ISwap
    {
        /// <summary>
        /// 封装对象
        /// </summary>
        object PackageObject { get; set; }
        /// <summary>
        /// 当前封装对象的类型
        /// </summary>
        Type ThisType { get; set; }
        /// <summary>
        /// 自定义关键字列表
        /// </summary>
        List<object> CustomKeys {   get; }
        /// <summary>
        /// 内部对象唯一索引
        /// </summary>
        int Index { get; set; }
        ///// <summary>
        ///// 最后使用事件
        ///// </summary>
        //DateTime LastUseinTime { get; set; }
        ///// <summary>
        ///// 是否允许释放
        ///// </summary>
        //bool IsFree { get; set; }
        
         
    }
}
