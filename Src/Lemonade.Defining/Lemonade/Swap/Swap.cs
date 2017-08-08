using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;
using Lemonade.Frame.Swapping; 

namespace Lemonade.Swap
{
    /// <summary>
    /// 交换对象
    /// </summary>
    public class Swap:ISwap
    {
        /// <summary>
        /// 
        /// </summary>
        public Swap(bool IsFree=true)
        {
            //this.LastUseinTime = DateTime.Now;
            //this.IsFree = IsFree;
        }
        List<object> customkes = new List<object>();
        /// <summary>
        /// 
        /// </summary>
        public List<object> CustomKeys
        {
            get
            {
                return this.customkes;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Index
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public object PackageObject
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public Type ThisType
        {
            get;
            set;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public bool IsFree
        //{
        //    get;
        //    set;
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public DateTime LastUseinTime
        //{
        //    get;
        //    set;
        //}

     

         
    }
}
