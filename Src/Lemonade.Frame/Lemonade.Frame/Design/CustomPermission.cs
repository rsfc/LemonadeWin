//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Security;
//using System.Security.Permissions;
//namespace CSF.Frame.Design
//{
//    [SerializableAttribute()]
//    public sealed class CustomPermission : CodeAccessPermission, IUnrestrictedPermission
//    {
//        private bool unrestricted;

//        public CustomPermission(PermissionState state)
//        {
//            if (state == PermissionState.Unrestricted)
//            {
//                unrestricted = true;
//            }
//            else
//            {
//                unrestricted = false;
//            }
//        }

//        //Define the rest of your custom permission here. You must 
//        //implement IsUnrestricted and override the Copy, Intersect, 
//        //IsSubsetOf, ToXML, and FromXML methods.

//        public override IPermission Copy()
//        {
//            throw new NotImplementedException();
//        }

//        public override void FromXml(SecurityElement elem)
//        {
//            throw new NotImplementedException();
//        }

//        public override IPermission Intersect(IPermission target)
//        {
//            throw new NotImplementedException();
//        }

//        public override bool IsSubsetOf(IPermission target)
//        {
//            throw new NotImplementedException();
//        }

//        public override SecurityElement ToXml()
//        {
//            throw new NotImplementedException();
//        }

//        public bool IsUnrestricted()
//        {
//            throw new NotImplementedException();
//        }
//    }

//}
