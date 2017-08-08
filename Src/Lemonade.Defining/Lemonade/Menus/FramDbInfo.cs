using System;
using System.Collections.Generic;
using System.Text;
using Lemonade.Frame.Running;
using Lemonade.Frame.BLL;
using Protein.Enzyme.DAL;
namespace Lemonade.Menus
{
    /// <summary>
    ///框架数据库信息
    /// </summary>
    public class FramDbInfo:IDBInfo
    {
        /// <summary>
        /// 框架数据库信息
        /// </summary>
        public FramDbInfo()
        {
 
        }
        #region IDBInfo 成员
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <returns></returns>
        public string GetConnectString()
        {
            ILemonEnvironment config = LemonEnvironment.GetInstance();
            return config.BllConfig.GetConfig<ILemonEnvironment>().DatabaseConn;
            //return "";
        }

        #endregion
    }
}
