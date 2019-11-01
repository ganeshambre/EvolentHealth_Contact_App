using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EvolentHealth_Contact_App.Filters
{
    public class BasicAuthorizationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //Check for the Authorization header
            if (actionContext.Request.Headers.Authorization == null)
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            else
            {
                var authHeader = actionContext.Request.Headers.Authorization.Parameter;
                var headerData = Convert.FromBase64String(authHeader);
                var credentials = (Encoding.UTF8.GetString(headerData)).Split(':');
                var username = credentials[0];
                var password = credentials[1];

                //Validate User credentials
                if (!ValidateUser(username, password))
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }

            }
            base.OnAuthorization(actionContext);
        }

        private bool ValidateUser(string username, string password)
        {
            var localUser = ConfigurationManager.AppSettings["user"].Split(':');
            var localUsername = localUser[0];
            var localPassword = localUser[1];

            if (String.Equals(username, localUsername, StringComparison.InvariantCultureIgnoreCase) &&
                String.Equals(password, localPassword))
            {
                return true;
            }

            return false;
        }
    }

}