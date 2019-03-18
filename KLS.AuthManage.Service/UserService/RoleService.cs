using EntityFramework.Extensions;
using KLS.AuthManage.Component.Data.Context;
using KLS.AuthManage.Component.Data.DbService;
using KLS.AuthManage.Data.Model.Member;
using KLS.AuthManage.IService.IUserService;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Service.UserService
{
    public class RoleService : IRoleService
    {
        private readonly IModuleService _moduleService;
        private readonly IPermissionService _permissionService;
        private readonly IDbServiceReposity _dbServiceReposity;
        private readonly ApplicationRoleStore _roleStore;
        public RoleService(ApplicationRoleStore roleStore, IModuleService moduleService, IPermissionService permissionService, IDbServiceReposity dbServiceReposity)
        {
            _roleStore = roleStore;
            _moduleService = moduleService;
            _permissionService = permissionService;
            _dbServiceReposity = dbServiceReposity;
        }

        public OperationResult Delete(IEnumerable<RoleModel> list)
        {
            try
            {
                if (list != null)
                {
                    var roleIds = list.Select(c => c.Id).ToList();
                    int count = _roleStore.Roles.Where(c => roleIds.Contains(c.Id)).Delete();
                    if (count > 0)
                    {
                        return new OperationResult(OperationResultType.Success, "删除数据成功！");
                    }
                    else
                    {
                        return new OperationResult(OperationResultType.Error, "删除数据失败!");
                    }
                }
                else
                {
                    return new OperationResult(OperationResultType.ParamError, "参数错误，请选择需要删除的数据!");
                }
            }
            catch
            {
                return new OperationResult(OperationResultType.Error, "删除数据失败!");
            }
        }

        public IList<ZTreeVM> GetListZTreeVM(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult> InsertAsync(RoleModel model)
        {
            try
            {
                Role oldRole = _roleStore.Roles.FirstOrDefault(c => c.Name == model.RoleName.Trim());
                if (oldRole != null)
                {
                    return new OperationResult(OperationResultType.Warning, "数据库中已经存在相同名称的角色，请修改后重新提交！");
                }
                var role = new Role
                {
                    Name = model.RoleName.Trim(),
                    Description = model.Description,
                    OrderSort = model.OrderSort,
                    Enabled = model.Enabled,
                };
                await _roleStore.CreateAsync(role);
                return new OperationResult(OperationResultType.Success, "新增数据成功！");
            }
            catch
            {
                return new OperationResult(OperationResultType.Error, "新增数据失败，数据库插入数据时发生了错误!");
            }
        }

        public async Task<OperationResult> UpdateAsync(RoleModel model)
        {
            try
            {
                var oldRole = _roleStore.Roles.FirstOrDefault(c => c.Id == model.Id);
                if (oldRole == null)
                {
                    throw new Exception();
                }
                var other = _roleStore.Roles.FirstOrDefault(c => c.Id != model.Id && c.Name == model.RoleName.Trim());
                if (other != null)
                {
                    return new OperationResult(OperationResultType.Warning, "数据库中已经存在相同名称的角色，请修改后重新提交！");
                }
                oldRole.Name = model.RoleName.Trim();
                oldRole.Description = model.Description;
                oldRole.OrderSort = model.OrderSort;
                oldRole.Enabled = model.Enabled;
                await _roleStore.UpdateAsync(oldRole);
                return new OperationResult(OperationResultType.Success, "更新数据成功！");
            }
            catch
            {
                return new OperationResult(OperationResultType.Error, "更新数据失败!");
            }
        }

        public Task<OperationResult> UpdateAuthorize(int roleId, int[] ids)
        {
            return null;
            //try
            //{
            //    var oldRole = Roles.FirstOrDefault(c => c.Id == roleId);
            //    if (oldRole == null)
            //    {
            //        throw new Exception();
            //    }

            //    oldRole.Permissions.Clear();
            //    var permissions = _permissionService..Where(c => ids.Contains(c.Id)).AsEnumerable().ToList();
            //    oldRole.Permissions = permissions;
            //    await _RoleStore.UpdateAsync(oldRole);
            //    return new OperationResult(OperationResultType.Success, "更新角色权限成功！");
            //}
            //catch (Exception ex)
            //{
            //    return new OperationResult(OperationResultType.Error, "更新角色权限失败!");
            //}
        }
    }
}
