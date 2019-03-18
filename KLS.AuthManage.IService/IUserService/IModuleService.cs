using KLS.AuthManage.Data.Model.Member;
using KLS.AuthManage.Data.Model.SysModel;
using KLS.AuthManage.Data.Model.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.IService.IUserService
{
    public interface IModuleService
    {
        /// <summary>
        /// 贪婪加载Module实体数据集
        /// </summary>
        /// <param name="inclueList"></param>
        /// <returns></returns>
        IQueryable<SysModule> GetEntitiesByEager(IEnumerable<string> inclueList);

        /// <summary>
        /// 获取模块分页列表
        /// </summary>
        /// <returns></returns>
        IList<ModuleModel> GetListModuleByPage();

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        OperationResult Insert(ModuleModel model);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        OperationResult Update(ModuleModel model);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        OperationResult Delete(IEnumerable<ModuleModel> list);
    }
}
