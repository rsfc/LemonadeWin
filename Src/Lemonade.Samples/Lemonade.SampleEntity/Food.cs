using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Samples.SampleEntity
{
    /// <summary>
    /// 食物
    /// </summary>
    public abstract class Food
    {
        /// <summary>
        /// 食物名称
        /// </summary>
        public string Name{get;set;}
        /// <summary>
        /// 食物重量
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// 是否转基因
        /// </summary>
        public bool Transgenosis { get; set; }
    }
}
