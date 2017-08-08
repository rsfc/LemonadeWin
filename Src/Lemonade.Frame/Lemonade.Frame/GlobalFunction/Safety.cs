using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.Repository;

namespace Lemonade.Frame
{
    /// <summary>
    /// 框架通用功能入口
    /// </summary>
    public static partial class Lemon
    {
        #region 安全功能函数集合 
        /// <summary>
        /// 使用内置密钥解密字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string SafetyDecryptDES(this string s)
        {
            return s.CipherDecryptDES();
        } 
        /// <summary>
        /// 使用内置密钥加密字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string SafetyEncryptDES(this string s)
        {
            return s.CipherEncryptDES();
        }  
        #endregion
    }
}
