using KLS.AuthManage.Component.Data.Context;
using KLS.AuthManage.Component.Tools.Configs;
using KLS.AuthManage.Data.Model.Member;
using KLS.AuthManage.Data.Model.ViewModel;
using KLS.AuthManage.IService.IUserService;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Service.UserService
{
    public class AuthService : IAuthService, IDisposable
    {
        private readonly ApplicationUserManager _userManager;
        public AuthService()
        {
            _userManager = new ApplicationUserManager(new ApplicationUserStore(new EFQuestion()));
        }

        public async Task<User> FindUserAsync(UserModel model)
        {
            User user = await _userManager.FindAsync(model.UserName, model.Password);
            return user;
        }

        public async Task<bool> UpdateUserPwAsync(int userId, string oldPassword, string newPassword)
        {
            var result = await _userManager.ChangePasswordAsync(userId, oldPassword, newPassword);
            return result.Succeeded;
        }

        public async Task<User> FindUserByName(string uName)
        {
            User user = await _userManager.FindByNameAsync(uName);
            return user;
        }

        public async Task<bool> Register(User user)
        {
            var result = await _userManager.CreateAsync(user, user.PasswordHash);
            return result.Succeeded;
        }

        public void Dispose()
        {
            _userManager.Dispose();
        }

        public async Task<bool> UpdateRolesById(int userId, int[] roleIds)
        {
            User user = await _userManager.FindByIdAsync(userId);
            user.Roles.Clear();
            //必要的判断....是否为空
            foreach (var roleId in roleIds)
            {
                user.Roles.Add(new ApplicationUserRole
                {
                    RoleId = roleId,
                    UserId = user.Id
                });
            }
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<User> FindUserById(int userId)
        {
            User user = await _userManager.FindByIdAsync(userId);
            return user;
        }

        public async Task<IList<string>> GetUserRoleNameByIds(int userId)
        {
            return await _userManager.GetRolesAsync(userId);
        }
    }
}
