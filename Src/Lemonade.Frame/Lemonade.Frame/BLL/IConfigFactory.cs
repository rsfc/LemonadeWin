using System;
using Lemonade.Frame;
using Lemonade.Frame.Running;
namespace Lemonade.Frame.BLL
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConfigFactory
    {
        /// <summary>
        /// 
        /// </summary>
         ILemonEnvironment Config { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string Configfolder { get; set; }
        /// <summary>
        /// 
        /// </summary>
        void Processing();
        /// <summary>
        /// 
        /// </summary>
        void InsConfig();
    }
}
