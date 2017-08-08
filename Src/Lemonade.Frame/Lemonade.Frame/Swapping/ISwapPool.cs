using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Frame.Swapping
{
    /// <summary>
    /// 交换对象池
    /// </summary>
    public interface ISwapPool
    {
        /// <summary>
        /// 创建数据交换对象
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        ISwap CreateSwap(object Obj);

        /// <summary>
        /// 创建数据交换对象
        /// </summary>
        /// <param name="Obj"></param>
        /// <param name="CustomKey"></param>
        /// <returns></returns>
        ISwap CreateSwap(object Obj, List<object> CustomKey);

        /// <summary>
        /// 创建数据交换对象
        /// </summary>
        /// <param name="Obj"></param>
        /// <param name="PropertyToKey">自动将对象的属性作为自定义关键字</param>
        /// <returns></returns>
        ISwap CreateSwap(object Obj, bool PropertyToKey);

        /// <summary>
        /// 添加数据交换对象
        /// </summary> 
        /// <param name="Swap"></param>
        int AddSwapping(ISwap Swap);
        /// <summary>
        /// 是否已经存在参数指定的数据交换对象
        /// </summary>
        /// <param name="Swap"></param>
        /// <returns></returns>
        int HasSwap(ISwap Swap);
        /// <summary>
        /// 交换对象总数量
        /// </summary>
        /// <returns></returns>
        int SwappingCount{get;}
        /// <summary>
        /// 获取指定索引的自定义关键字列表
        /// </summary>
        List<object> SwappingKeys(int Index);
        /// <summary>
        /// 根据参数提供的匹配对象查找数据交换对象
        /// </summary>
        /// <param name="Match"></param>
        /// <returns></returns>
        ISwap FindSwap(ISwapMatch Match);
        /// <summary>
        /// 根据参数提供的匹配对象查找数据交换对象
        /// </summary>
        /// <param name="Match"></param>
        /// <returns></returns>
        List<ISwap> FindSwaps(ISwapMatch Match);
        /// <summary>
        /// 根据类全名查找数据交换对象
        /// </summary>
        /// <param name="ObjectFullClassName"></param>
        /// <returns></returns>
        ISwap FindSwap(string ObjectFullClassName);
        /// <summary>
        /// 根据类全名查找指定的交换对象
        /// </summary>
        /// <param name="ObjectFullClassName"></param>
        /// <returns></returns>
        List<ISwap> FindSwaps(string ObjectFullClassName);
        /// <summary>
        /// 根据type查找数据交换对象
        /// </summary>
        /// <param name="ObjectType"></param>
        /// <returns></returns>
        ISwap FindSwap(Type ObjectType);
        /// <summary>
        /// 根据type查找数据交换对象
        /// </summary>
        /// <param name="Keys"></param>
        /// <returns></returns>
        ISwap FindSwap(List<object> Keys);
        /// <summary>
        /// 根据type查找数据交换对象
        /// </summary>
        /// <param name="Keys"></param>
        /// <returns></returns>
        List<ISwap> FindSwaps(List<object> Keys);
        /// <summary>
        /// 获取指定索引的交换对象
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        ISwap this[int Index] { get; }
    }
}
