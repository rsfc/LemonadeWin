//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Security; 
//using System.Security.Permissions;

//namespace CSF.Frame.Design
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    [AttributeUsageAttribute(AttributeTargets.All, AllowMultiple = true)]
//    public class CustomPermissionAttribute : CodeAccessSecurityAttribute
//    {
//        bool unrestricted = false;

//        public new bool Unrestricted
//        {
//            get { return unrestricted; }
//            set { unrestricted = value; }
//        }

//        public CustomPermissionAttribute(SecurityAction action)
//            : base(action)
//        {
//        }
//        public override IPermission CreatePermission()
//        {
//            if (Unrestricted)
//            {
//                return new CustomPermission(PermissionState.Unrestricted);
//            }
//            else
//            {
//                return new CustomPermission(PermissionState.None);
//            }
//        }
//    }

//}
