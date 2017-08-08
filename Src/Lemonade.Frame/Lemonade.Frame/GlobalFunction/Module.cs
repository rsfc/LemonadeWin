using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.Design;
using Lemonade.Frame.Running;
using Lemonade.Frame.Module;
using System.IO;
using System.Reflection;
using System.Windows;

namespace Lemonade.Frame
{
    /// <summary>
    /// 框架通用功能入口
    /// </summary>
    public static partial class Lemon
    {

        #region 界面功能

        /// <summary>
        /// 启动模块，由模块管理器启动模块
        /// <param name="FullClassName">插件全名</param>
        /// <param name="Parameters">插件初始化参数，一般为空</param>
        /// </summary>
        public static IModule ModuleLaunch(string FullClassName, params object[] Parameters)
        {
            IModuleManager manager = LemonEnvironment.GetInstance().ModuleManager;
            IModule m = manager.LaunchModule(FullClassName, Parameters);
            return m;
        }

        
        /// <summary>
        /// 查找指定名称的模块
        /// </summary>
        /// <returns></returns>
        public static IModule ModuleFind(string FullClassName)
        {
            IModuleManager manager = LemonEnvironment.GetInstance().ModuleManager;
            IModule m = manager.FindRunningModule(FullClassName); 
            return m;
        }


        /// <summary>
        /// 查找插件并运行，由模块管理器启动模块
        /// <param name="FullClassName">插件全名</param>
        /// <param name="Parameters">插件初始化参数，一般为空</param>
        /// </summary>
        public static InvokeResult ModuleFindLaunch(string FullClassName, params object[] Parameters)
        {
            InvokeResult result = new InvokeResult();
            try
            {
                IModule targetModule = Lemon.ModuleFind(FullClassName);
                if (targetModule == null)
                {
                    targetModule = Lemon.ModuleLaunch(FullClassName, Parameters);
                    if (targetModule == null)
                    {
                        result.State = StateType.NonModule;
                    }
                }
                else
                {
                    targetModule.RunCache();
                }
                result.Module = targetModule;
            }
            catch(Exception ex)
            {
                result.Error = ex;
                result.State = StateType.Error;
            } 
            return result;
        }

        /// <summary>
        /// 调用模块的方法,模块必须是当前已经启动的。
        /// <param name="Module">插件全名</param>
        /// <param name="MethodName">方面名称</param>
        /// <param name="parameters">方法调用传入的参数</param>
        /// </summary>
        /// <returns></returns>
        public static InvokeResult ModuleInvoke(IModule Module, string MethodName, params object[] parameters)
        {
            InvokeResult result = new InvokeResult();
            try
            {
                if (Module != null)
                {
                    MethodInfo miAddHandler = Module.GetType().GetMethod(MethodName);
                    if (miAddHandler != null)
                    {
                        object[] addHandlerArgs = parameters;
                        result.ReturnValue=miAddHandler.Invoke(Module, addHandlerArgs);
                    }
                    else
                    {
                        result.State = StateType.NonMethod;
                    }
                }
                else
                {
                    result.State = StateType.NonModule;
                }
            }
            catch (Exception ex)
            {
                result.Error = ex;
                result.State = StateType.Error;
            }
            return result;
        }

        /// <summary>
        /// 访问插件的指定方法
        /// <param name="FullClassName">插件全名</param>
        /// <param name="MethodName">方法名称</param>
        /// <param name="parameters">参数</param>
        /// </summary>
        public static InvokeResult ModuleInvoke(string FullClassName, string MethodName, params object[] parameters)
        {
            IModule targetModule = Lemon.ModuleFind(FullClassName);
            if (targetModule == null)
            {
                targetModule = Lemon.ModuleLaunch(FullClassName);
            }
            return Lemon.ModuleInvoke(targetModule, MethodName, parameters);
        }

        /// <summary>
        /// 移除模块
        /// </summary>
        /// <param name="Module"></param>
        public static void ModuleRemove(IModule Module)
        {
            IModuleManager manager = LemonEnvironment.GetInstance().ModuleManager;
            manager.TurnOffModule(Module.ModuleName);
        }
        /// <summary>
        /// 获取所有的插件信息
        /// </summary>
        public static List<ModuleInfo> ModuleInfos
        {
            get
            { 
                IModuleManager manager = LemonEnvironment.GetInstance().ModuleManager;
                return manager.ModuleInfos;
            }
        }
        /// <summary>
        /// 获取所有正在运行的插件别名。
        /// 由于插件别名是在插件内部定义的属性，用于标识创建插件之初的功能定位。对未实例化的插件不便通过反射获取以免造成资源浪费。
        /// </summary>
        public static List<string> ModuleAliass
        {
            get {
                IModuleManager manager = LemonEnvironment.GetInstance().ModuleManager;
                return manager.RunningModuleAlias;
            }
        }

        #endregion
    }
}
