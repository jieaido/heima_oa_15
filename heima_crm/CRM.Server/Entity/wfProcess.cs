//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using CRM.IRepository;
using CRM.IServer;
using CRM.Server;

namespace CRM.Server
{

    using CRM.Model;
    /// <summary>
    /// 负责每个数据表的数据操作
    /// </summary>
    public partial class wfProcessServices :BaseServices<wfProcess>,IwfProcessServices
    {
       IwfProcessRepository dal;
      #region 定义构造函数，接收autofac将数据仓储层的具体实现类的对象注入到此类中
    	public wfProcessServices(IwfProcessRepository dal)
    	{
    		this.dal = dal;
    		base.baseDal = dal;
    	}
      #endregion
    
    
       #region 针对此表的特殊操作写在此处
            
      #endregion
    }
}
