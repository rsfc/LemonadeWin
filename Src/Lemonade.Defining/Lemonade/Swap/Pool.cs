using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;
using Lemonade.Frame.Swapping;
using System.Reflection;

namespace Lemonade.Swap
{
    /// <summary>
    /// 池对象实现
    /// </summary>
    public class Pool:ISwapPool
    {
        List<ISwap> swaplist = null;

        /// <summary>
        /// 池对象
        /// </summary>
        public Pool()
        {
            this.swaplist = new List<ISwap>(); 
        }

        /// <summary>
        /// 当前最大索引
        /// </summary>
        /// <returns></returns>
        protected virtual int CurrentMaxIndex()
        {
            int result = 0;
            if (this.swaplist.Count > 0)
            {
                result = this.swaplist.Max(s => s.Index);
            }
            return result;
        }

        /// <summary>
        /// 添加交换对象
        /// </summary> 
        /// <param name="Swap"></param>
        public int AddSwapping(ISwap Swap)
        {
            int result =HasSwap(Swap);
            if (result>-1)
            {
                //覆盖
                this.swaplist.RemoveAt(result);
                this.swaplist.Insert(result, Swap);
            }
            else
            {  
                //添加新的
                Swap.Index = this.CurrentMaxIndex()+1;
                this.swaplist.Add(Swap);
                result = Swap.Index;
            }
            return result;
        }
        

        /// <summary>
        /// 数据交换对象总数
        /// </summary>
        public int SwappingCount
        {
            get { return this.swaplist.Count; }
        }
        /// <summary>
        /// 获取指定索引的交换对象
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public ISwap this[int Index]
        {
            get {
                return this.swaplist[Index];
            }
        }
        /// <summary>
        /// 获取关键字列表
        /// </summary>
        public List<object> SwappingKeys(int Index)
        {  
            return this[Index].CustomKeys; 
        }

        /// <summary>
        /// 是否包含
        /// </summary>
        /// <param name="Swap"></param>
        /// <returns></returns>
        public int HasSwap(ISwap Swap)
        {
            int result = -1;
            SwapMatchKeys smk = new SwapMatchKeys(Swap.CustomKeys);
            foreach (ISwap sp in this.swaplist)
            {
                if (smk.IsSwap(sp))
                {
                    result = this.swaplist.IndexOf(sp);
                }
            }
            return result;
        }

        /// <summary>
        /// 查找数据交换对象
        /// </summary>
        /// <param name="Match"></param>
        /// <returns></returns>
        public ISwap FindSwap(ISwapMatch Match)
        {
            ISwap result = null;
            foreach (ISwap swp in this.swaplist)
            {
                if (Match.IsSwap(swp))
                {
                    result= swp;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 查找数据交换对象多个
        /// </summary>
        /// <param name="Match"></param>
        /// <returns></returns>
        public List<ISwap> FindSwaps(ISwapMatch Match)
        {
            List<ISwap> result = new List<ISwap>();
            foreach (ISwap swp in this.swaplist)
            {
                if (Match.IsSwap(swp))
                {
                    result.Add(swp); 
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ObjectType"></param>
        /// <returns></returns>
        public ISwap FindSwap(Type ObjectType)
        {
            ISwapMatch sm = new SwapMatchType(ObjectType);
            return this.FindSwap(sm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ObjectFullClassName"></param>
        /// <returns></returns>
        public List<ISwap> FindSwaps(string ObjectFullClassName)
        {
            ISwapMatch sm = new SwapMatchFullClassName(ObjectFullClassName);
            return this.FindSwaps(sm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ObjectFullClassName"></param>
        /// <returns></returns>
        public ISwap FindSwap(string ObjectFullClassName)
        {
            ISwapMatch sm = new SwapMatchFullClassName(ObjectFullClassName);
            return this.FindSwap(sm);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Keys"></param>
        /// <returns></returns>
        public ISwap FindSwap(List<object> Keys)
        {
            ISwapMatch sm = new SwapMatchKeys(Keys);
            return this.FindSwap(sm);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Keys"></param>
        /// <returns></returns>
        public List<ISwap> FindSwaps(List<object> Keys)
        {
            ISwapMatch sm = new SwapMatchKeys(Keys);
            return this.FindSwaps(sm);
        }
        /// <summary>
        /// 创建数据交换对象
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public ISwap CreateSwap(object Obj)
        {
            ISwap swap = new Swap();
            swap.PackageObject = Obj;
            swap.ThisType = Lemon.GetObjType(Obj);  
            return swap;
        }


        /// <summary>
        /// 创建数据交换对象
        /// </summary>
        /// <param name="Obj"></param>
        /// <param name="PropertyToKey"></param>
        /// <returns></returns>
        public ISwap CreateSwap(object Obj, bool PropertyToKey)
        {
            ISwap swap = new Swap();
            swap.PackageObject = Obj;
            swap.ThisType = Lemon.GetObjType(Obj); 
            foreach (PropertyInfo pi in swap.ThisType.GetProperties())
            {
                object tmpvalue = pi.GetValue(Obj, null);
                if (tmpvalue != null)
                {
                    swap.CustomKeys.Add(tmpvalue);
                }
            }
            return swap;
        }
        /// <summary>
        /// 创建数据交换对象
        /// </summary>
        /// <param name="Obj"></param>
        /// <param name="CustomKey"></param>
        /// <returns></returns>
        public ISwap CreateSwap(object Obj, List<object> CustomKey)
        {
            ISwap swap = new Swap();
            swap.PackageObject = Obj;
            swap.ThisType = Lemon.GetObjType(Obj);
            swap.CustomKeys.AddRange(CustomKey); 
            return swap;
        }
         
       
    }
}
