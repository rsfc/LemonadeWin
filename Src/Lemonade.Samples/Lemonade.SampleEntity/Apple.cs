using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Samples.SampleEntity
{
    /// <summary>
    /// apple是一种食物
    /// </summary>
    public class Apple:Food
    {
        /// <summary>
        /// 初始化时指定是转基因的
        /// </summary>
        public Apple()
        {
            this.Name = "苹果";
            this.Weight = 0.01;
            base.Transgenosis = true;
        }
    }
}
