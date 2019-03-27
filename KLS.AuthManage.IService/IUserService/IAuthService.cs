using KLS.AuthManage.Data.Model.Member;
using KLS.AuthManage.Data.Model.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.IService.IUserService
{
    /// <summary>
    /// 用户验证操作基于UserManager
    /// </summary>
    public interface IAuthService
    {
        Task<bool> Register(User model);
        Task<User> FindUserAsync(UserModel model);
        Task<User> FindUserByName(string uName);
        Task<bool> UpdateRolesById(int userId, int[] roleIds);
        Task<User> FindUserById(int userId);
        Task<IList<string>> GetUserRoleNameByIds(int userId);
        Task<bool> UpdateUserPwAsync(int userId, string oldPassword, string newPassword);
    }
}
