using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Samples.SampleEntity
{
    /// <summary>
    /// filbert是一种食物
    /// </summary>
    public class Filbert:Food
    {
        /// <summary>
        /// 非转基因的
        /// </summary>
        public Filbert()
        {
            this.Name = "榛子";
            this.Weight = 0.001;
            base.Transgenosis = false;
        }
    }
}
