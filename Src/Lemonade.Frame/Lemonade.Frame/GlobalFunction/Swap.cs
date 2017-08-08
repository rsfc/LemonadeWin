using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame.Running;
using Lemonade.Frame.Swapping;
using Protein.Enzyme.Repository;

namespace Lemonade.Frame
{
    /// <summary>
    /// 框架通用功能入口
    /// </summary>
    public static partial class Lemon
    {
        #region 数据交换对象的封装函数

        /// <summary>
        /// 添加数据交换对象
        /// </summary>
        public static int SwapAppend(object Obj)
        { 
            ISwap swap=LemonEnvironment.GetInstance().SwapPool.CreateSwap(Obj);
            return LemonEnvironment.GetInstance().SwapPool.AddSwapping(swap);
        }
        
        /// <summary>
        /// 添加数据交换对象,同时添加自定义关键字
        /// </summary>
        public static int SwapAppend(object Obj, params object[] CustomKey)
        {
            List<object> ck = new List<object>();
            if (CustomKey != null)
            {
                foreach (object s in CustomKey)
                {
                    ck.Add(s);
                }
            }
            ISwap swap = LemonEnvironment.GetInstance().SwapPool.CreateSwap(Obj,ck); 
            return LemonEnvironment.GetInstance().SwapPool.AddSwapping(swap);
        }

        /// <summary>
        /// 添加数据交换对象,自动将包装的对象属性值作为自定义关键字
        /// </summary>
        public static int SwapAppend(object Obj, bool PropertyToKey)
        { 
            ISwap swap = LemonEnvironment.GetInstance().SwapPool.CreateSwap(Obj, PropertyToKey);
            return LemonEnvironment.GetInstance().SwapPool.AddSwapping(swap);
        }
        
        /// <summary>
        /// 根据类全名查找交换池中的对象实例
        /// <param name="IsMulti">是否查询多个</param>
        /// <param name="Keys">任意多个参数，待查询对象的关键字必须完全包含该参数</param>
        /// </summary>
        public static List<object> SwapFindObject(bool IsMulti,params object[] Keys)
        {
            List<object> result = new List<object>(); 
            if (Keys == null)
            {
                return null;
            }
            if (IsMulti)
            {
                List<ISwap> swaps = LemonEnvironment.GetInstance().SwapPool.FindSwaps(Keys.ToList());
                if (swaps != null)
                {
                    foreach (ISwap swap in swaps)
                    {
                        if (swap != null)
                        {
                            if (swap.PackageObject != null)
                            {
                                result.Add(swap.PackageObject);
                            }
                        }
                    }
                }
            }
            else
            {
                ISwap swap = LemonEnvironment.GetInstance().SwapPool.FindSwap(Keys.ToList());
                if (swap != null)
                {
                    if (swap.PackageObject != null)
                    {
                        result.Add(swap.PackageObject);
                    }
                }
            }
            return result;
        }

 
        /// <summary>
        /// 根据关键字查找
        /// <param name="Keys">任意多个参数，待查询对象的关键字必须完全包含该参数</param>
        /// </summary>
        public static T SwapFindOneObject<T>(params object[] Keys)
        {
            T result = default(T); 
            if (Keys == null)
            {
                return result;  
            }
            else
            { 
                ISwap swap = LemonEnvironment.GetInstance().SwapPool.FindSwap(Keys.ToList());
                if (swap != null)
                {
                    if (swap.PackageObject != null)
                    {
                        if (swap.PackageObject.GetObjTypeFromProxy() == typeof(T))
                        {
                            result = (T)swap.PackageObject;
                        }
                        
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 根据类全名查找交换池中的对象实例
        /// </summary>
        public static List<ISwap> SwapFindObjects(string FullClassName)
        {
            List<ISwap> result = null;
            result = LemonEnvironment.GetInstance().SwapPool.FindSwaps(FullClassName);
            //if (result != null)
            //{
            //    if (swap.PackageObject != null)
            //    {
            //        result = swap.PackageObject;
            //    }
            //}
            return result;
        }


        /// <summary>
        /// 根据类全名查找交换池中的对象实例
        /// </summary>
        public static object SwapFindObject(string FullClassName)
        {
            object result = null;
            ISwap swap = LemonEnvironment.GetInstance().SwapPool.FindSwap(FullClassName);
            if (swap != null)
            {
                if (swap.PackageObject != null)
                {
                    result = swap.PackageObject;
                }
            }
            return result;
        }

        /// <summary>
        /// 根据类全名查找交换池中的对象实例，如果对象存在直接转换为泛型类型
        /// </summary>
        /// <param name="FullClassName"></param>
        /// <returns></returns>
        public static T SwapFindObject<T>(string FullClassName)
        {
            T result = default(T);
            object obj = SwapFindObject(FullClassName);
            if (obj != null)
            {
                result = (T)obj;
            }
            return result;
        }


        /// <summary>
        /// 根据类型查找交换池中的对象实例
        /// </summary>
        public static object SwapFindObject(Type ObjectType)
        {
            object result = null;
            ISwap swap = LemonEnvironment.GetInstance().SwapPool.FindSwap(ObjectType);
            if (swap != null)
            {
                if (swap.PackageObject != null)
                {
                    result = swap.PackageObject;
                }
            }
            return result;
        }

        /// <summary>
        /// 根据类型查找交换池中的对象实例，如果对象存在直接转换为泛型类型
        /// </summary>
        /// <param name="ObjectType"></param>
        /// <returns></returns>
        public static T SwapFindObject<T>(Type ObjectType)
        {
            T result = default(T);
            object obj = SwapFindObject(ObjectType);
            if (obj != null)
            {
                result = (T)obj;
            }
            return result;
        }

        /// <summary>
        /// 根据类型查找交换池中的对象实例，如果对象存在直接转换为泛型类型
        /// </summary> 
        /// <returns></returns>
        public static T SwapFindObject<T>()
        {
            Type ObjectType = typeof(T);
            return SwapFindObject<T>(ObjectType) ;
        }

        /// <summary>
        /// 获取主窗体对象
        /// </summary>
        /// <returns></returns>
        public static IMainForm GetMainForm()
        {
            return LemonEnvironment.GetInstance().CSFMain;
        }

        /// <summary>
        /// 根据自定义交换匹配实例查找交换池中的对象实例
        /// </summary>
        public static object SwapFindObject(ISwapMatch Match)
        {
            object result = null;
            ISwap swap = LemonEnvironment.GetInstance().SwapPool.FindSwap(Match);
            if (swap != null)
            {
                if (swap.PackageObject != null)
                {
                    result = swap.PackageObject;
                }
            }
            return result;
        }
        
        

        #endregion
    }
}
