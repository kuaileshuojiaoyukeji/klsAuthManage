using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace KLS.AuthManage.AuthFilters
{
    public class AuthorizeFilter : AuthorizeAttribute
    {
        private void AuthorizeRequest(HttpActionContext actionContext)
        {
            string token = string.Empty;
            AuthenticationTicket ticket;

            token = (actionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? actionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

            if (token == string.Empty)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Missing 'Authorization' header. Access denied.");
                return;
            }

            //your OAuth startup class may be called something else...
            ticket = Startup.OAuthOptions.AccessTokenFormat.Unprotect(token);

            if (ticket == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid token decrypted.");
                return;
            }

            // you could perform some logic on the ticket here...

            // you will be able to retrieve the ticket in all controllers by querying properties and looking for "Ticket"... 
            actionContext.Request.Properties.Add(new KeyValuePair<string, object>("Ticket", ticket));
        }
    }
}