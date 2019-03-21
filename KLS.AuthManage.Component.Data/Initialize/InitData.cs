using KLS.AuthManage.Component.Data.Context;
using KLS.AuthManage.Data.Model.Member;
using KLS.AuthManage.Data.Model.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Component.Data.Initialize
{
    public class InitData : CreateDatabaseIfNotExists<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            //usermanage初始化用户及权限
            User _users = new User()
            {
                UserName = "超级管理员",
                Address = "",
                CertificateNo = "000000000000000000",
                Email = "kuaileshuo@126.com",
                Enabled = true,
                PasswordHash = "admin",
                Phone = "",
                TrueName = "admin",
                CreateTime = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            var _userManager = new UserManager<User, int>(new ApplicationUserStore(new EFDbContext()));
            _userManager.CreateAsync(_users);
            _userManager.AddToRoleAsync(_users.Id, "admin");
            base.Seed(context);
        }
    }



    public class InitCreateDatabase : DropCreateDatabaseIfModelChanges<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            //usermanage初始化用户及权限
            User _users = new User()
            {
                UserName = "超级管理员",
                Address = "",
                CertificateNo = "000000000000000000",
                Email = "kuaileshuo@126.com",
                Enabled = true,
                PasswordHash = "123456",
                Phone = "",
                TrueName = "admin",
                CreateTime = DateTime.Now,
                UpdateDate = DateTime.Now
            };
            context.Users.Add(_users);
            context.SaveChanges();
            //IAuthService authService = new AuthService();
            //var _authService = DependencyResolver.Current.GetService<IAuthService>();
            //authService
            //var _userManager = new ApplicationUserManager(new ApplicationUserStore(context));

            base.Seed(context);
        }

        private string GetMd5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
