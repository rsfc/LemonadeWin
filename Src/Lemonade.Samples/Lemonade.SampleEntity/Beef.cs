using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Samples.SampleEntity
{
    /// <summary>
    /// Beef是一种食物
    /// </summary>
    public class Beef:Food
    {
        /// <summary>
        /// 初始化时指定淋巴含量
        /// </summary>
        public Beef()
        {
            this.Name = "牛肉";
            this.Weight = 1.0;
            base.Transgenosis = false;
            this.Lymph = 0.000001;
        }
        /// <summary>
        /// 淋巴含量
        /// </summary>
        public double Lymph { get; set; }
    }
}
