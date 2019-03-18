using KLS.AuthManage.Component.Tools.Helpers;
using KLS.AuthManage.Data.Model.Member;
using KLS.AuthManage.Data.Model.ViewModel;
using KLS.AuthManage.IService.IUserService;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KLS.AuthManage.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            _publicClientId = publicClientId ?? throw new ArgumentNullException("publicClientId");
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var data = await context.Request.ReadFormAsync();
            //var uniqueidentifier = data["uniqueidentifier"];
            User user;
            var _authService = DependencyResolver.Current.GetService<IAuthService>();
            string userName = null;
            {
                //此处FindUserAsync方法内部是解密后匹配如果使用UserManage.Users.FirstOrDefault需要先将密码解密后去直接匹配字段
                //string password = EncryptionHelper.GetMd5Hash(context.Password);
                UserModel userModel = new UserModel
                {
                    UserName = context.UserName,
                    Password = context.Password//正式需要加密
                };
                
                user = await _authService.FindUserAsync(userModel);
                if (user != null)
                    userName = context.UserName;
            }
            if (userName == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            IList<string> _list = await _authService.GetUserRoleNameByIds(user.Id);
            List<Claim> _claims = new List<Claim>();
            if (_list.ToList().Count > 0)
            {
                foreach (var rName in _list)
                {
                    _claims.Add(new Claim(ClaimTypes.Role, rName));
                }
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };

            claims.AddRange(_claims);
            ClaimsIdentity oAuthIdentity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
            AuthenticationProperties properties = CreateProperties(userName);
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
            bool success = context.Validated(ticket);
            await base.GrantResourceOwnerCredentials(context);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            //context.AdditionalResponseParameters.Add("ID", context.Identity.GetUserId<int>().ToString());
            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");
                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }
            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "uName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}