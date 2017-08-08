using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lemonade.Frame;
using Lemonade.Samples.SampleEntity;

namespace Lemonade.Samples.AutoStart
{
    /// <summary>
    /// 示例功能函数，实现了IModule接口，表示对框架来说这个是一个插件模块
    /// </summary>
    public class AutoStartFunction:IModule
    {
         
        /// <summary>
        /// 实现接口方法，框架默认的运行模块后自动调用初始化方法
        /// </summary>
        public void Initialize()
        {
            //创建一个苹果对象实例，这里是一个食物
            Food fd1 = new Apple();  
            //通过调用SwapAppend通知框架fd对象是可以用于交换的对象
            Lemon.SwapAppend(fd1);
            //创建牛肉实例
            Food fd2 = new Beef();
            //设置交换,指定将牛肉对象的所有属性值作为自定义关键字
            Lemon.SwapAppend(fd2, true);
            //创建转基因牛肉实例
            Food fd4 = new Beef();
            fd4.Transgenosis = true;
            //设置交换,指定将牛肉对象的所有属性值作为自定义关键字
            Lemon.SwapAppend(fd4, true);
            //创建榛子实例
            Food Fd3 = new Filbert();
            //设置交换，指定输入的对象作为自定义关键字
            Lemon.SwapAppend(Fd3, "榛子", "铁岭", "开原", "好吃的", 88);
            
        }

        /// <summary>
        /// 实现接口属性，该属性用于对象传递主窗体对象，在某些需要的场景下调用
        /// </summary>
        public IMainForm MainForm
        {
            get;
            set;
        }
        /// <summary>
        /// 实现接口属性，该模块别名
        /// </summary>
        public string ModuleAlias
        {
            get { return "自动运行模块"; }
        }
        /// <summary>
        /// 实现接口属性，该模块的唯一名称，由框架维护，不需要认为指定
        /// </summary>
        public string ModuleName
        {
            get;
            set;
        }
        /// <summary>
        /// 实现接口方法，运行缓存，当模块在框架中已经存在实例是，框架默认运行的方法
        /// </summary>
        public void RunCache()
        {
            Lemon.SendMsgNote("再次运行");
        }
    }
}
