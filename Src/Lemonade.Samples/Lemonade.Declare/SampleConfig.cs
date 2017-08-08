using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lemonade.Samples.Declare
{
    /// <summary>
    /// 示例配置，使用框架扩展配置
    /// </summary>
    public class SampleConfig
    {
        public string FieldString { get; set; }
        public int FieldInt { get; set; }
        public DateTime FieldDate { get; set; }
        public double FieldDouble { get; set; }
        public Coffee CoffeeSet { get; set; }
        public List<Coffee> CoffeeSetList { get; set; }
    }

    /// <summary>
    /// 咖啡
    /// </summary>
    public class Coffee
    {
        public int Smell{get;set;}
        public int Sour { get; set; }
        public int Bitter { get; set; }
        public int Puckery { get; set; }
    }

     

}
