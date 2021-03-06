//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using CRM.IRepository;
using CRM.Model;

namespace CRM.Repository
{

    /// <summary>
    /// 负责每个数据表的数据操作
    /// </summary>
    public partial class sysUserInfoRepository : BaseRepository<sysUserInfo>, IsysUserInfoRepository
    {
        #region 针对此表的特殊操作写在此处

        #endregion
     
        IEnumerable<sysPermissList> IsysUserInfoRepository.GetPermissListByUser(int userid)
        {
            HashSet<sysPermissList> sysPermissLists=new HashSet<sysPermissList>();
            var userinfo = QueryWhere(s => s.uID == userid).FirstOrDefault();
            foreach (var sysUserInfoRole in userinfo.sysUserInfo_Role)
            {
                foreach (var VARIABLE in sysUserInfoRole.sysRole.sysPermissList)
                {
                    sysPermissLists.Add(VARIABLE);
                }
            }
            return sysPermissLists;
        }
    }
}
